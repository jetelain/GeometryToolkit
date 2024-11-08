using System.Collections;
using System.Numerics;
using System.Text;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry.Shapes
{
    public class MultiPolygon<TPrimitive, TVector> : 
            IWithBounds<TVector>, 
            IShape<TPrimitive, TVector>, 
            IReadOnlyList<Polygon<TPrimitive, TVector>>, 
            IShapeWithTransform<TPrimitive, TVector, MultiPolygon<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly List<Polygon<TPrimitive, TVector>> polygons;

        public static readonly MultiPolygon<TPrimitive, TVector> Empty = new MultiPolygon<TPrimitive, TVector>();

        public MultiPolygon(List<Polygon<TPrimitive, TVector>> polygons)
        {
            this.polygons = polygons;
        }

        public MultiPolygon(params Polygon<TPrimitive, TVector>[] polygons)
            : this(polygons.ToList())
        {

        }

        public Polygon<TPrimitive, TVector> this[int index] => polygons[index];

        public VectorEnvelope<TVector> Bounds => GetBounds(polygons);

        public double AreaD => polygons.Sum(p => p.AreaD);

        public int Count => polygons.Count;

        internal Paths64 ToClipper(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (polygons.Count == 0)
            {
                return new Paths64();
            }
            var paths = new Paths64(polygons.Count + polygons.Sum(p => p.Holes.Count));
            foreach (var p in polygons)
            {
                paths.Add(settings.ToClipper(p.Shell));
                paths.AddRange(p.Holes.Select(settings.ToClipper));
            }
            return paths;
        }

        public bool Contains(TVector point)
        {
            return IsInsideOrOnBoundary(point);
        }

        public double Distance(TVector point)
        {
            if (polygons.Count == 0)
            {
                return double.NaN;
            }
            return polygons.Min(p => p.Distance(point));
        }

        public IEnumerator<Polygon<TPrimitive, TVector>> GetEnumerator()
        {
            return polygons.GetEnumerator();
        }

        public bool IsInside(TVector point)
        {
            return polygons.Any(p => p.IsInside(point));
        }

        public bool IsInsideOrOnBoundary(TVector point)
        {
            return polygons.Any(p => p.IsInsideOrOnBoundary(point));
        }

        public TVector NearestPointBoundary(TVector point)
        {
            return NearestPointDistanceBoundary(point).Point;
        }

        public (TVector Point, double Distance) NearestPointDistanceBoundary(TVector point)
        {
            if (polygons.Count == 0)
            {
                return (default, double.NaN);
            }
            var (result, resultDistance) = polygons[0].NearestPointDistanceBoundary(point);
            foreach (var hole in polygons.Skip(1))
            {
                var (candidate, candidateDistance) = hole.NearestPointDistanceBoundary(point);
                if (resultDistance > candidateDistance)
                {
                    result = candidate;
                    resultDistance = candidateDistance;
                }
            }
            return (result, resultDistance);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return polygons.GetEnumerator();
        }

        public MultiPolygon<TPrimitive, TVector> Crop(VectorEnvelope<TVector> rect)
        {
            if (polygons.Count == 0)
            {
                return this;
            }
            return Intersection(new(polygons[0].Settings.CreateRectanglePolygon(rect)));
        }

        private MultiPolygon<TPrimitive, TVector> BooleanOp(MultiPolygon<TPrimitive, TVector> other, ClipType op)
        {
            var settings = polygons[0].Settings;
            var tree = new PolyTree64();
            Clipper.BooleanOp(op, ToClipper(settings), other.ToClipper(settings), tree, FillRule.EvenOdd);
            return settings.ToMultiPolygon(tree);
        }

        public MultiPolygon<TPrimitive, TVector> Substract(MultiPolygon<TPrimitive, TVector> other)
        {
            if (polygons.Count == 0)
            {
                return Empty;
            }
            if (!Bounds.Intersects(other.Bounds))
            {
                return this;
            }
            return BooleanOp(other, ClipType.Difference);
        }

        public MultiPolygon<TPrimitive, TVector> Intersection(MultiPolygon<TPrimitive, TVector> other)
        {
            if (polygons.Count == 0)
            {
                return Empty;
            }
            if (!Bounds.Intersects(other.Bounds))
            {
                return Empty;
            }
            return BooleanOp(other, ClipType.Intersection);
        }

        public MultiPolygon<TPrimitive, TVector> Union(MultiPolygon<TPrimitive, TVector> other)
        {
            if (polygons.Count == 0)
            {
                return other;
            }
            if (!Bounds.Intersects(other.Bounds))
            {
                return new (polygons.Concat(other.polygons).ToList());
            }
            return BooleanOp(other, ClipType.Union);
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "MULTIPOLYGON EMPTY";
            }
            var sb = new StringBuilder();
            sb.Append("MULTIPOLYGON (");
            var first = true;
            foreach (var polygon in polygons)
            {
                if (first)
                {
                    sb.Append("(");
                    first = false;
                }
                else
                {
                    sb.Append(", (");
                }
                polygon.ToStringAppend(sb);
                sb.Append(")");
            }
            sb.Append(")");
            return sb.ToString();
        }

        public MultiPolygon<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            return new MultiPolygon<TPrimitive, TVector>(polygons.Select(p => p.WithSettings(settings)).ToList());
        }

        internal static VectorEnvelope<TVector> GetBounds(List<Polygon<TPrimitive, TVector>> list)
        {
            if (list.Count == 0)
            {
                return VectorEnvelope<TVector>.None;
            }
            var min = list[0].Bounds.Min;
            var max = list[0].Bounds.Max;
            for (var i = 1; i < list.Count; i++)
            {
                var current = list[i];
                min = TVector.Min(current.Bounds.Min, min);
                max = TVector.Max(current.Bounds.Max, max);
            }
            return new(min, max);
        }

        public ShapeTransforms<TPrimitive, TVector, MultiPolygon<TPrimitive, TVector>> Transforms()
        {
            return new ShapeTransforms<TPrimitive, TVector, MultiPolygon<TPrimitive, TVector>>(this);
        }

        public MultiPolygon<TPrimitive, TVector> Transform<TTransform>(TTransform transform)
            where TTransform : ITransform<TVector>
        {
            var list = new List<Polygon<TPrimitive, TVector>>(polygons.Count);
            foreach (var p in polygons)
            {
                list.Add(p.Transform(transform));
            }
            return new MultiPolygon<TPrimitive, TVector>(list);
        }
    }
}
