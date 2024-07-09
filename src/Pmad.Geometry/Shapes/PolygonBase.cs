using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public abstract class PolygonBase<TPrimitive, TVector, TPolygon, TAlgorithms, TConvention> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TPolygon : PolygonBase<TPrimitive, TVector, TPolygon, TAlgorithms, TConvention>
        where TAlgorithms : IVectorAlgorithms<TPrimitive, TVector>, new()
        where TConvention : Vector2ConventionBase<TPrimitive, TVector, TPolygon, TAlgorithms, TConvention>
    {
        protected static readonly IReadOnlyList<IReadOnlyList<TVector>> NoHoles = new List<IReadOnlyList<TVector>>(0);

        public PolygonBase(TConvention convention, IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes)
        {
            this.Convention = convention;
            this.Shell = shell;
            this.Holes = holes;
            Bounds = VectorEnvelope<TVector>.FromList(shell);
        }

        public TConvention Convention { get; }

        public IReadOnlyList<TVector> Shell { get; }

        public IReadOnlyList<IReadOnlyList<TVector>> Holes { get; }

        public VectorEnvelope<TVector> Bounds { get; }

        public double AreaD => Math.Abs(Convention.Algorithms.GetSignedAreaD(Shell)) - Holes.Sum(hole => Math.Abs(Convention.Algorithms.GetSignedAreaD(hole)));

        public float AreaF => Math.Abs(Convention.Algorithms.GetSignedAreaF(Shell)) - Holes.Sum(hole => Math.Abs(Convention.Algorithms.GetSignedAreaF(hole)));

        protected abstract TPolygon This { get; }

        protected abstract TPolygon CreatePolygon(IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes);

        private Paths64 ToClipper()
        {
            var paths = new Paths64(1 + Holes.Count);
            paths.Add(new Path64(Shell.Select(Convention.ToClipper)));
            paths.AddRange(Holes.Select(hole => new Path64(hole.Select(Convention.ToClipper))));
            return paths;
        }

        internal static IEnumerable<TPolygon> FromClipper(TConvention convention, PolyPath64 polyTree64)
        {
            var result = new List<TPolygon>();
            FromClipper(convention, result, polyTree64);
            return result;
        }

        private static void FromClipper(TConvention convention, List<TPolygon> result, PolyPath64 polyTree64)
        {
            foreach (PolyPath64 node in polyTree64)
            {
                var children = node.Cast<PolyPath64>();
                var shell = CreateRing(convention, node.Polygon!);
                var holes = children.Select(h => CreateRing(convention, h.Polygon!)).ToList();
                result.Add(convention.CreatePolygon(shell, holes));
                foreach (var subchild in children.SelectMany(h => h.Cast<PolyPath64>()))
                {
                    FromClipper(convention, result, subchild);
                }
            }
        }

        private static IReadOnlyList<TVector> CreateRing(TConvention convention, List<Point64> points)
        {
            var ring = new List<TVector>(points.Count + 1);
            ring.AddRange(points.Select(convention.FromClipper));
            ring.Add(convention.FromClipper(points[0]));
            return ring;
        }

        private Paths64 Offset(IEnumerable<TVector> path, double detla)
        {
            var clipper = new ClipperOffset();
            clipper.AddPath(new Path64(path.Select(Convention.ToClipper)), JoinType.Square, EndType.Polygon);
            var solution = new Paths64(); ;
            clipper.Execute(detla, solution);
            return solution;
        }

        // Offsetting
        public IEnumerable<TPolygon> Offset(double offset)
        {
            if (offset == 0)
            {
                return [This];
            }
            var scaledOffset = offset * Convention.ScaleForClipper;
            var shell = Offset(Shell, scaledOffset);
            if (Holes.Count == 0)
            {
                return shell.Select(s => CreatePolygon(s.Select(Convention.FromClipper).ToList(), NoHoles));
            }
            var holes = new Paths64(Holes.SelectMany(h => Offset(h, -scaledOffset)));
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, shell, holes, tree, FillRule.NonZero);
            return FromClipper(Convention, tree);
        }

        public Paths64 OffsetAsPaths(double offset)
        {
            if (offset == 0)
            {
                return ToClipper();
            }
            var scaledOffset = offset * Convention.ScaleForClipper;
            var shell = Offset(Shell, scaledOffset);
            if (Holes.Count == 0)
            {
                return shell;
            }
            var holes = new Paths64(Holes.SelectMany(h => Offset(h, -scaledOffset)));
            return Clipper.BooleanOp(ClipType.Difference, shell, holes, FillRule.NonZero);
        }

        public IEnumerable<TPolygon> Crown(double offset) => Crown(offset, offset);
        
        public IEnumerable<TPolygon> OuterCrown(double offset) => Crown(0, offset);

        public IEnumerable<TPolygon> InnerCrown(double offset) => Crown(offset, 0);

        public IEnumerable<TPolygon> Crown(double innnerOffset, double outerOffset)
        {
            if (innnerOffset == 0 && outerOffset == 0)
            {
                return Enumerable.Empty<TPolygon>();
            }
            var subject = OffsetAsPaths(outerOffset);
            var clip = OffsetAsPaths(-innnerOffset);
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, subject, clip, tree, FillRule.EvenOdd);
            return FromClipper(Convention, tree);
        }

        // Polygon arithmetic        
        public IEnumerable<TPolygon> SubstractAll(IEnumerable<TPolygon> others)
        {
            var result = new List<TPolygon>() { This };
            foreach (var other in others.Where(o => Bounds.Intersects(o.Bounds)))
            {
                var previousResult = result.ToList();
                result.Clear();
                foreach (var subjet in previousResult)
                {
                    result.AddRange(subjet.Substract(other));
                }
                if (result.Count == 0)
                {
                    return result;
                }
            }
            return result;
        }

        public IEnumerable<TPolygon> SubstractAllNoOverlap(IEnumerable<TPolygon> others)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, ToClipper(), new Paths64(others.SelectMany(o => o.ToClipper())), tree, FillRule.EvenOdd);
            return FromClipper(Convention, tree);
        }

        public IEnumerable<TPolygon> Substract(TPolygon other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return [This];
            }
            return BooleanOp(other, ClipType.Difference);
        }

        public IEnumerable<TPolygon> Union(TPolygon other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return [This, other];
            }
            return BooleanOp(other, ClipType.Union);
        }

        private IEnumerable<TPolygon> BooleanOp(TPolygon other, ClipType op)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(op, ToClipper(), other.ToClipper(), tree, FillRule.EvenOdd);
            return FromClipper(Convention, tree);
        }

        public IEnumerable<TPolygon> Intersection(TPolygon other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return Enumerable.Empty<TPolygon>();
            }
            return BooleanOp(other, ClipType.Intersection);
        }

        public PointInPolygonResult TestPointInPolygon(TVector vector)
        {
            if (!Bounds.Contains(vector))
            {
                return PointInPolygonResult.IsOutside;
            }
            var result = Convention.Algorithms.TestPointInPolygon(Shell, vector);
            if (result != PointInPolygonResult.IsInside)
            {
                return result;
            }
            foreach (var hole in Holes)
            {
                result = Convention.Algorithms.TestPointInPolygon(hole, vector);
                if (result == PointInPolygonResult.IsInside)
                {
                    return PointInPolygonResult.IsOutside;
                }
                else if (result == PointInPolygonResult.IsOn)
                {
                    return PointInPolygonResult.IsOn;
                }
            }
            return PointInPolygonResult.IsInside;
        }
        
        public bool IsInside(TVector vector)
        {
            return TestPointInPolygon(vector) == PointInPolygonResult.IsInside;
        }

        public bool IsInsideOrOnBoundary(TVector vector)
        {
            return TestPointInPolygon(vector) != PointInPolygonResult.IsOutside;
        }
    }
}
