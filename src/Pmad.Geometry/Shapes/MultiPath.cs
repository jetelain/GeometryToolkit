using System.Collections;
using System.Numerics;
using System.Text;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// Ordered list of <see cref="Path{TPrimitive,TVector}"/> instances (equivalent to a GeoJSON MultiLineString).
    /// </summary>
    /// <typeparam name="TPrimitive">Numeric primitive type of the vector components.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public sealed class MultiPath<TPrimitive, TVector> : IWithBounds<TVector>, IReadOnlyList<Path<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly List<Path<TPrimitive, TVector>> paths;

        public static readonly MultiPath<TPrimitive, TVector> Empty = new MultiPath<TPrimitive, TVector>();

        public MultiPath(List<Path<TPrimitive, TVector>> paths)
        {
            this.paths = paths;
        }

        public MultiPath(params Path<TPrimitive, TVector>[] paths)
            : this(paths.ToList())
        {

        }

        public Path<TPrimitive, TVector> this[int index] => paths[index];

        /// <summary>Axis-aligned bounding box that encompasses all paths.</summary>
        public VectorEnvelope<TVector> Bounds => GetBounds(paths);

        /// <summary>Number of paths in the collection.</summary>
        public int Count => paths.Count;

        public IEnumerator<Path<TPrimitive, TVector>> GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        /// <summary>Returns a new <see cref="MultiPath{TPrimitive,TVector}"/> containing only the portions of paths inside <paramref name="rect"/>.</summary>
        public MultiPath<TPrimitive, TVector> Crop(VectorEnvelope<TVector> rect)
        {
            if (paths.Count == 0)
            {
                return this;
            }
            return new MultiPath<TPrimitive, TVector>(paths.SelectMany(p => p.Crop(rect)).ToList());
        }

        /// <summary>Returns a new <see cref="MultiPath{TPrimitive,TVector}"/> cropped to <paramref name="rect"/>, preserving the original orientation of each sub-path.</summary>
        public MultiPath<TPrimitive, TVector> CropKeepOrientation(VectorEnvelope<TVector> rect)
        {
            if (paths.Count == 0)
            {
                return this;
            }
            return new MultiPath<TPrimitive, TVector>(paths.SelectMany(p => p.CropKeepOrientation(rect)).ToList());
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "MULTILINESTRING EMPTY";
            }
            var sb = new StringBuilder();
            sb.Append("MULTILINESTRING (");
            var first = true;
            foreach (var path in paths)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(", ");
                }
                ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, path.Points.AsSpan());
            }
            sb.Append(")");
            return sb.ToString();
        }

        public MultiPath<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            return new MultiPath<TPrimitive, TVector>(paths.Select(p => p.WithSettings(settings)).ToList());
        }

        internal static VectorEnvelope<TVector> GetBounds(List<Path<TPrimitive, TVector>> list)
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
    }
}
