using System.Numerics;
using System.Text;
using Clipper2Lib;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public sealed class Polygon<TPrimitive, TVector> : IWithBounds<TVector>, IShape<TPrimitive, TVector>, IEquatable<Polygon<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private static readonly ReadOnlyArray<ReadOnlyArray<TVector>> NoHoles = new ReadOnlyArray<ReadOnlyArray<TVector>>([]);
        
        public Polygon(ReadOnlyArray<TVector> shell)
            : this(ShapeSettings<TPrimitive, TVector>.Default, shell, NoHoles)
        {

        }
        
        public Polygon(ReadOnlyArray<TVector> shell, ReadOnlyArray<ReadOnlyArray<TVector>> holes)
            : this(ShapeSettings<TPrimitive,TVector>.Default, shell, holes)
        {

        }
        
        public Polygon(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell)
             : this(settings, shell, NoHoles)
        {

        }

        public Polygon(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell, ReadOnlyArray<ReadOnlyArray<TVector>> holes)
        {
            this.Settings = settings;
            this.Shell = shell;
            this.Holes = holes;
            Bounds = VectorEnvelope<TVector>.FromList(shell);
        }

        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        public ReadOnlyArray<TVector> Shell { get; }

        public ReadOnlyArray<ReadOnlyArray<TVector>> Holes { get; }

        public VectorEnvelope<TVector> Bounds { get; }

        public double AreaD => Math.Abs(SignedArea<TPrimitive,TVector>.GetSignedAreaD(Shell)) - Holes.Sum(hole => Math.Abs(SignedArea<TPrimitive, TVector>.GetSignedAreaD(hole)));

        public float AreaF => Math.Abs(SignedArea<TPrimitive,TVector>.GetSignedAreaF(Shell)) - Holes.Sum(hole => Math.Abs(SignedArea<TPrimitive, TVector>.GetSignedAreaF(hole)));

        public TVector Centroid => Centroid<TPrimitive, TVector>.GetCentroid(Shell);

        internal Paths64 ToClipper()
        {
            var paths = new Paths64(1 + Holes.Count);
            paths.Add(Settings.ToClipper(Shell));
            paths.AddRange(Holes.Select(Settings.ToClipper));
            return paths;
        }

        private Paths64 Offset(ReadOnlyArray<TVector> path, double detla)
        {
            var clipper = new ClipperOffset();
            clipper.AddPath(Settings.ToClipper(path), JoinType.Square, EndType.Polygon);
            var solution = new Paths64(); ;
            clipper.Execute(detla, solution);
            return solution;
        }

        // Offsetting
        public MultiPolygon<TPrimitive, TVector> Offset(double offset)
        {
            if (offset == 0)
            {
                return new(this);
            }
            var scaledOffset = offset * Settings.ScaleForClipper;
            var shell = Offset(Shell, scaledOffset);
            if (Holes.Count == 0)
            {
                return new(shell.Select(s => new Polygon<TPrimitive, TVector>(Settings, Settings.FromClipperToRing(s))).ToList());
            }
            var holes = new Paths64(Holes.SelectMany(h => Offset(h, -scaledOffset)));
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, shell, holes, tree, FillRule.NonZero);
            return Settings.ToMultiPolygon(tree);
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

        public MultiPolygon<TPrimitive, TVector> Crown(double offset) => Crown(offset, offset);
        
        public MultiPolygon<TPrimitive, TVector> OuterCrown(double offset) => Crown(0, offset);

        public MultiPolygon<TPrimitive, TVector> InnerCrown(double offset) => Crown(offset, 0);

        public MultiPolygon<TPrimitive, TVector> Crown(double innnerOffset, double outerOffset)
        {
            if (innnerOffset == 0 && outerOffset == 0)
            {
                return MultiPolygon<TPrimitive, TVector>.Empty;
            }
            var subject = OffsetAsPaths(outerOffset);
            var clip = OffsetAsPaths(-innnerOffset);
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, subject, clip, tree, FillRule.EvenOdd);
            return Settings.ToMultiPolygon(tree);
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

        public MultiPolygon<TPrimitive, TVector> SubstractAllNoOverlap(MultiPolygon<TPrimitive, TVector> others)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Difference, ToClipper(), others.ToClipper(Settings), tree, FillRule.EvenOdd);
            return Settings.ToMultiPolygon(tree);
        }

        public MultiPolygon<TPrimitive, TVector> Substract(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return new(this);
            }
            return BooleanOp(other, ClipType.Difference);
        }

        public MultiPolygon<TPrimitive, TVector> Union(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return new(this, other);
            }
            return BooleanOp(other, ClipType.Union);
        }

        private MultiPolygon<TPrimitive, TVector> BooleanOp(Polygon<TPrimitive, TVector> other, ClipType op)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(op, ToClipper(), other.ToClipper(), tree, FillRule.EvenOdd);
            return Settings.ToMultiPolygon(tree);
        }

        private PolygonSet<TPrimitive, TVector> BooleanOpToSet(Polygon<TPrimitive, TVector> other, ClipType op)
        {
            return new PolygonSet<TPrimitive, TVector>(Clipper.BooleanOp(op, ToClipper(), other.ToClipper(), FillRule.EvenOdd), Settings);
        }

        public MultiPolygon<TPrimitive, TVector> Intersection(Polygon<TPrimitive, TVector> other)
        {
            if (!Bounds.Intersects(other.Bounds))
            {
                return MultiPolygon<TPrimitive, TVector>.Empty;
            }
            return BooleanOp(other, ClipType.Intersection);
        }

        public MultiPolygon<TPrimitive, TVector> Crop(VectorEnvelope<TVector> rect)
        {
            return Intersection(Settings.CreateRectangle(rect));
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

        public bool Contains(TVector point) => IsInsideOrOnBoundary(point);

        public double Distance(TVector point)
        {
            var test = TestPointInPolygon(point);
            if (test != PointInPolygonResult.IsOutside)
            {
                return 0;
            }
            return NearestPointDistanceBoundary(point).Distance;
        }

        public (TVector Point,double Distance) NearestPointDistanceBoundary(TVector point)
        {
            var (result, resultDistance) = Shell.NearestPointPath(point);
            foreach (var hole in Holes)
            {
                var (candidate, candidateDistance) = hole.NearestPointPath(point);
                if (resultDistance > candidateDistance)
                {
                    result = candidate;
                    resultDistance = candidateDistance;
                }
            }
            return (result, resultDistance);
        }

        public double DistanceFromBoundary(TVector point)
        {
            return NearestPointDistanceBoundary(point).Distance;
        }

        public TVector NearestPointBoundary(TVector point)
        {
            return NearestPointDistanceBoundary(point).Point;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("POLYGON (");
            ToStringAppend(sb);
            sb.Append(")");
            return sb.ToString();
        }

        internal void ToStringAppend(StringBuilder sb)
        {
            ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, Shell.AsSpan());
            foreach (var hole in Holes)
            {
                sb.Append(", ");
                ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, hole.AsSpan());
            }
        }

        public bool ContainsOrSimilar(Polygon<TPrimitive, TVector> other)
        {
            if (Bounds.Contains(other.Bounds))
            {
                return Shell.SequenceEqual(other.Shell) ||  Math.Abs(IntersectionArea(other) - other.AreaD) < Settings.NegligibleArea;
            }
            return false;
        }

        public Polygon<TPrimitive, TVector> Simplify()
        {
            return SimplifyImpl(Settings.NegligibleDistanceSquared);
        }

        public Polygon<TPrimitive, TVector> Simplify(double epsilon)
        {
            return SimplifyImpl(epsilon * epsilon);
        }

        private Polygon<TPrimitive, TVector> SimplifyImpl(double epsilonSquared)
        {
            return new Polygon<TPrimitive, TVector>(Settings, Shell.Simplify(epsilonSquared), Holes.Select(h => h.Simplify(epsilonSquared)).ToReadOnlyArray());
        }

        public bool Intersects(Polygon<TPrimitive, TVector> other)
        {
            return IntersectionArea(other) > Settings.NegligibleArea;
        }

        public double IntersectionArea(Polygon<TPrimitive, TVector> other)
        {
            return Intersection(other).Sum(o => o.AreaD);
        }

        public Polygon<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (settings == Settings)
            {
                return this; 
            }
            return new Polygon<TPrimitive, TVector>(settings, Shell, Holes);
        }

        public bool SameAs(Polygon<TPrimitive, TVector> other)
        {
            if (other == this)
            {
                return true;
            }
            if (Holes.Count == other.Holes.Count &&
                LoopEqual(Shell,other.Shell))
            {
                var otherHoles = other.Holes.ToList();
                foreach (var hole in Holes)
                {
                    var matching = otherHoles.FindIndex(otherHole => LoopEqual(otherHole, hole));
                    if (matching == -1)
                    {
                        return false;
                    }
                    otherHoles.RemoveAt(matching);
                }
                return true;
            }
            return false;
        }

        internal static bool LoopEqual(ReadOnlyArray<TVector> span1, ReadOnlyArray<TVector> span2)
        {
            return span1.Count == span2.Count && LoopEqual(span1.Slice(1), span2.Slice(1));
        }

        private static bool LoopEqual(ReadOnlySpan<TVector> span1, ReadOnlySpan<TVector> span2)
        {
            var index = span2.IndexOf(span1[0]);
            if (index == -1)
            {
                return false;
            }
            var slice2 = span2.Slice(index);
            var slice1 = span1.Slice(0, slice2.Length);
            if (!slice2.SequenceEqual(slice1))
            {
                return false;
            }
            if (span1.Slice(slice2.Length).SequenceEqual(span2.Slice(0, index)))
            {
                return true;
            }
            return false;
        }

        public bool Equals(Polygon<TPrimitive, TVector>? other)
        {
            if (other == null)
            {
                return false; 
            }
            if (other == this)
            {
                return true;
            }
            if (Holes.Count == other.Holes.Count && Shell.SequenceEqual(other.Shell))
            {
                for (int i = 0; i < Holes.Count; ++i)
                {
                    if (!Holes[i].SequenceEqual(other.Holes[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            if (Shell.Count == 0)
            {
                return 0; 
            }
            return HashCode.Combine(Holes.Count, Shell.Count, Shell[0]);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Polygon<TPrimitive, TVector> other)
            {
                return Equals(other); 
            }
            return false;
        }

        public PolygonSet<TPrimitive, TVector> ToPolygonSet()
        {
            return new PolygonSet<TPrimitive, TVector>(Clipper.BooleanOp(ClipType.Union, ToClipper(), new Paths64(), FillRule.EvenOdd), Settings, Bounds); // TODO: Test ClipType.None
        }
    }
}
