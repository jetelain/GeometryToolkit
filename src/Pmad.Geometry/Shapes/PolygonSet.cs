using System.Numerics;
using Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// "High performance" representation of one or more polygons, suited for arithmetic operations. 
    /// It's a thin layer above Clipper2 primitives for fool-proof usage.
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

        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        internal Paths64 ToClipper() => paths;

        public int Count => paths.Count;

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

        public PolygonSet<TPrimitive, TVector> SubstractToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Difference);
        }
        public PolygonSet<TPrimitive, TVector> SubstractToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Difference);
        }
        public PolygonSet<TPrimitive, TVector> SubstractToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Difference);
        }

        public PolygonSet<TPrimitive, TVector> UnionToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Union);
        }
        public PolygonSet<TPrimitive, TVector> UnionToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Union);
        }
        public PolygonSet<TPrimitive, TVector> UnionToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Union);
        }

        public PolygonSet<TPrimitive, TVector> IntersectionToMultiPolygon(PolygonSet<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Intersection);
        }
        public PolygonSet<TPrimitive, TVector> IntersectionToMultiPolygon(Polygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(), ClipType.Intersection);
        }
        public PolygonSet<TPrimitive, TVector> IntersectionToMultiPolygon(MultiPolygon<TPrimitive, TVector> other)
        {
            return BooleanOpToSet(other.ToClipper(Settings), ClipType.Intersection);
        }

        private MultiPolygon<TPrimitive, TVector> SubstractToMultiPolygon(Paths64 other, ClipType op)
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
            var tree = new PolyTree64();
            Clipper.BooleanOp(ClipType.Union, paths, null, tree, FillRule.EvenOdd); // TODO: Try ClipType.None 
            return Settings.ToMultiPolygon(tree);
        }

        public PolygonSet<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            return new PolygonSet<TPrimitive, TVector>(paths, settings);
        }
    }
}
