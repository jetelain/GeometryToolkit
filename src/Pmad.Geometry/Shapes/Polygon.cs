using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Polygon<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private static readonly IReadOnlyList<IReadOnlyList<TVector>> NoHoles = new List<IReadOnlyList<TVector>>(0);
        
        public Polygon(IReadOnlyList<TVector> shell)
            : this(ShapeSettings<TPrimitive, TVector>.Default, shell, NoHoles)
        {

        }
        
        public Polygon(IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes)
            : this(ShapeSettings<TPrimitive,TVector>.Default, shell, holes)
        {

        }
        
        public Polygon(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> shell)
             : this(settings, shell, NoHoles)
        {

        }

        public Polygon(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes)
        {
            this.Settings = settings;
            this.Shell = shell;
            this.Holes = holes;
            Bounds = VectorEnvelope<TVector>.FromList(shell);
        }

        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        public IReadOnlyList<TVector> Shell { get; }

        public IReadOnlyList<IReadOnlyList<TVector>> Holes { get; }

        public VectorEnvelope<TVector> Bounds { get; }

        public double AreaD => Math.Abs(Shell.GetSignedAreaD()) - Holes.Sum(hole => Math.Abs(hole.GetSignedAreaD()));

        public float AreaF => Math.Abs(Shell.GetSignedAreaF()) - Holes.Sum(hole => Math.Abs(hole.GetSignedAreaF()));

        private Paths64 ToClipper()
        {
            var paths = new Paths64(1 + Holes.Count);
            paths.Add(Settings.ToClipper(Shell));
            paths.AddRange(Holes.Select(Settings.ToClipper));
            return paths;
        }

        private Paths64 Offset(IReadOnlyList<TVector> path, double detla)
        {
            var clipper = new ClipperOffset();
            clipper.AddPath(Settings.ToClipper(path), JoinType.Square, EndType.Polygon);
            var solution = new Paths64(); ;
            clipper.Execute(detla, solution);
            return solution;
        }

        // Offsetting
        public IEnumerable<Polygon<TPrimitive, TVector>> Offset(double offset)
        {
            if (offset == 0)
            {
                return [this];
            }
            var scaledOffset = offset * Settings.ScaleForClipper;
            var shell = Offset(Shell, scaledOffset);
            if (Holes.Count == 0)
            {
                return shell.Select(s => new Polygon<TPrimitive, TVector>(Settings, Settings.FromClipperToRing(s)));
            }
            var holes = new Paths64(Holes.SelectMany(h => Offset(h, -scaledOffset)));
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, shell, holes, tree, FillRule.NonZero);
            return Settings.FromClipper(tree);
        }

        public Paths64 OffsetAsPaths(double offset)
        {
            if (offset == 0)
            {
                return ToClipper();
            }
            var scaledOffset = offset * Settings.ScaleForClipper;
            var shell = Offset(Shell, scaledOffset);
            if (Holes.Count == 0)
            {
                return shell;
            }
            var holes = new Paths64(Holes.SelectMany(h => Offset(h, -scaledOffset)));
            return Clipper.BooleanOp(ClipType.Difference, shell, holes, FillRule.NonZero);
        }

        public IEnumerable<Polygon<TPrimitive, TVector>> Crown(double offset) => Crown(offset, offset);
        
        public IEnumerable<Polygon<TPrimitive, TVector>> OuterCrown(double offset) => Crown(0, offset);

        public IEnumerable<Polygon<TPrimitive, TVector>> InnerCrown(double offset) => Crown(offset, 0);

        public IEnumerable<Polygon<TPrimitive, TVector>> Crown(double innnerOffset, double outerOffset)
        {
            if (innnerOffset == 0 && outerOffset == 0)
            {
                return Enumerable.Empty<Polygon<TPrimitive, TVector>>();
            }
            var subject = OffsetAsPaths(outerOffset);
            var clip = OffsetAsPaths(-innnerOffset);
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, subject, clip, tree, FillRule.EvenOdd);
            return Settings.FromClipper(tree);
        }

        // Polygon arithmetic        
        public IEnumerable<Polygon<TPrimitive, TVector>> SubstractAll(IEnumerable<Polygon<TPrimitive, TVector>> others)
        {
            var result = new List<Polygon<TPrimitive, TVector>>() { this };
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

        public IEnumerable<Polygon<TPrimitive, TVector>> SubstractAllNoOverlap(IEnumerable<Polygon<TPrimitive, TVector>> others)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, ToClipper(), new Paths64(others.SelectMany(o => o.ToClipper())), tree, FillRule.EvenOdd);
            return Settings.FromClipper(tree);
        }

        public IEnumerable<Polygon<TPrimitive, TVector>> Substract(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return [this];
            }
            return BooleanOp(other, ClipType.Difference);
        }

        public IEnumerable<Polygon<TPrimitive, TVector>> Union(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return [this, other];
            }
            return BooleanOp(other, ClipType.Union);
        }

        private IEnumerable<Polygon<TPrimitive, TVector>> BooleanOp(Polygon<TPrimitive, TVector> other, ClipType op)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(op, ToClipper(), other.ToClipper(), tree, FillRule.EvenOdd);
            return Settings.FromClipper(tree);
        }

        public IEnumerable<Polygon<TPrimitive, TVector>> Intersection(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return Enumerable.Empty<Polygon<TPrimitive, TVector>>();
            }
            return BooleanOp(other, ClipType.Intersection);
        }

        public PointInPolygonResult TestPointInPolygon(TVector vector)
        {
            if (!Bounds.Contains(vector))
            {
                return PointInPolygonResult.IsOutside;
            }
            var result = Shell.TestPointInPolygon(vector);
            if (result != PointInPolygonResult.IsInside)
            {
                return result;
            }
            foreach (var hole in Holes)
            {
                result = hole.TestPointInPolygon(vector);
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
