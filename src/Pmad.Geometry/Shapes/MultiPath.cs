using System.Collections;
using System.Numerics;
using System.Text;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// List of paths/linestrings.
    /// </summary>
    /// <typeparam name="TPrimitive"></typeparam>
    /// <typeparam name="TVector"></typeparam>
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

        public VectorEnvelope<TVector> Bounds => GetBounds(paths);

        public int Count => paths.Count;

        public IEnumerator<Path<TPrimitive, TVector>> GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        public MultiPath<TPrimitive, TVector> Crop(VectorEnvelope<TVector> rect)
        {
            if (paths.Count == 0)
            {
                return this;
            }
            return new MultiPath<TPrimitive, TVector>(paths.SelectMany(p => p.Crop(rect)).ToList());
        }

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
