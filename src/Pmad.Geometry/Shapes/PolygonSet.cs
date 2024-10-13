using System.Numerics;
using System.Text;
using Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// "High performance" representation of one or more polygons, suited to chain arithmetic operations. 
    /// 
    /// It's a thin layer above Clipper2 primitives for fool-proof usage.
    /// 
    /// A "Polygon Set" is defined only by paths, the role of each path is unknown (shell or hole). 
    /// </summary>
    /// <typeparam name="TPrimitive"></typeparam>
    /// <typeparam name="TVector"></typeparam>
    public class PolygonSet<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly Paths64 paths;
        private VectorEnvelope<TVector> bounds;
        private bool hasBounds = false; // do not use nullable, as assignement might make HasValue true before Value is assigned (lock free)

        internal PolygonSet(Paths64 paths, ShapeSettings<TPrimitive, TVector> settings)
        {
            this.paths = paths;
            Settings = settings;
        }

        internal PolygonSet(Paths64 paths, ShapeSettings<TPrimitive, TVector> settings, VectorEnvelope<TVector> bounds)
            : this(paths, settings)
        {
            this.bounds = bounds;
            this.hasBounds = true;
        }

        public static PolygonSet<TPrimitive, TVector> Create(ShapeSettings<TPrimitive, TVector> settings, IEnumerable<ReadOnlyArray<TVector>> paths)
        {
            return new PolygonSet<TPrimitive, TVector>(new Paths64(paths.Select(settings.ToClipper)), settings);
        }

        public static PolygonSet<TPrimitive, TVector> Create(IEnumerable<ReadOnlyArray<TVector>> paths)
        {
            return Create(ShapeSettings<TPrimitive, TVector>.Default, paths);
        }

        public VectorEnvelope<TVector> Bounds 
        { 
            get
            {
                if (!hasBounds)
                {
                    var rect = Clipper.GetBounds(paths);

                    bounds = new VectorEnvelope<TVector>(
                        Settings.FromClipper(new Point64(rect.left, rect.top)),
                        Settings.FromClipper(new Point64(rect.right, rect.bottom)));

                    hasBounds = true;
                }
                return bounds;
            }
        }

        public double AreaD => Clipper.Area(paths) / Settings.ScaleForClipper / Settings.ScaleForClipper;

        internal ShapeSettings<TPrimitive, TVector> Settings { get; }

        internal Paths64 ToClipper() => paths;

        public int Count => paths.Count;

        internal IEnumerable<Path64> Paths => paths;

        public PolygonSet<TPrimitive, TVector> Substract(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Difference);
        }
        public PolygonSet<TPrimitive, TVector> Substract(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Difference);
        }
        public PolygonSet<TPrimitive, TVector> Substract(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Difference);
        }

        public PolygonSet<TPrimitive, TVector> Union(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Union);
        }
        public PolygonSet<TPrimitive, TVector> Union(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Union);
        }
        public PolygonSet<TPrimitive, TVector> Union(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Union);
        }

        public PolygonSet<TPrimitive, TVector> Intersection(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Intersection);
        }
        public PolygonSet<TPrimitive, TVector> Intersection(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Intersection);
        }
        public PolygonSet<TPrimitive, TVector> Intersection(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Intersection);
        }

        public PolygonSet<TPrimitive, TVector> Crop(VectorEnvelope<TVector> rect)
        {
            return new PolygonSet<TPrimitive, TVector>(Clipper.RectClip(Settings.ToClipper(rect), ToClipper()), Settings);
        }

        public MultiPolygon<TPrimitive, TVector> SubstractToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Difference);
        }
        public MultiPolygon<TPrimitive, TVector> SubstractToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Difference);
        }
        public MultiPolygon<TPrimitive, TVector> SubstractToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(Settings), ClipType.Difference);
        }

        public MultiPolygon<TPrimitive, TVector> UnionToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Union);
        }
        public MultiPolygon<TPrimitive, TVector> UnionToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Union);
        }
        public MultiPolygon<TPrimitive, TVector> UnionToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(Settings), ClipType.Union);
        }

        public MultiPolygon<TPrimitive, TVector> IntersectionToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Intersection);
        }
        public MultiPolygon<TPrimitive, TVector> IntersectionToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(), ClipType.Intersection);
        }
        public MultiPolygon<TPrimitive, TVector> IntersectionToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToMultiPolygon(other.ToClipper(Settings), ClipType.Intersection);
        }

        private MultiPolygon<TPrimitive, TVector> BooleanOpToMultiPolygon(Paths64 other, ClipType op)
        {
            var tree = new PolyTree64();
            Clipper.BooleanOp(op, ToClipper(), other, tree, FillRule.EvenOdd);
            return Settings.ToMultiPolygon(tree);
        }

        private PolygonSet<TPrimitive, TVector> BooleanOpToSet(Paths64 other, ClipType op)
        {
            return new PolygonSet<TPrimitive, TVector>(Clipper.BooleanOp(op, ToClipper(), other, FillRule.EvenOdd), Settings);
        }

        public List<ReadOnlyArray<TVector>> ToRings()
        {
            var rings = new List<ReadOnlyArray<TVector>>(paths.Count);
            foreach (var path in paths)
            {
                rings.Add(Settings.FromClipperToRing(path));
            }
            return rings;
        }

        public MultiPolygon<TPrimitive, TVector> ToMultiPolygon()
        {
            if (paths.Count == 0)
            {
                return MultiPolygon<TPrimitive, TVector>.Empty;
            }
            return new MultiPolygon<TPrimitive, TVector>(ToPolygonList());
        }

        public List<Polygon<TPrimitive, TVector>> ToPolygonList()
        {
            if (paths.Count == 0)
            {
                return new List<Polygon<TPrimitive, TVector>>();
            }
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Union, paths, null, tree, FillRule.EvenOdd);
            return Settings.ToPolygonList(tree);
        }

        public PolygonSet<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            return new PolygonSet<TPrimitive, TVector>(paths, settings);
        }

        public override string ToString()
        {
            if (paths.Count == 0)
            {
                return "POLYGONSET EMPTY";
            }
            var sb = new StringBuilder();
            sb.Append("POLYGONSET (");
            var p = paths[0];
            ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, Settings.FromClipper(p).AsSpan());
            for (var i = 1; i < paths.Count; i++)
            {
                sb.Append(", ");
                p = paths[i];
                ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, Settings.FromClipper(p).AsSpan());
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
