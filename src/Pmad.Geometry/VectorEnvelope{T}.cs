using System.Diagnostics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry
{
    [DebuggerDisplay("{Min}->{Max}")]
    public struct VectorEnvelope<TVector> 
        where TVector : struct, IVector<TVector>
    {
        private readonly TVector min;
        private readonly TVector max;

        public static readonly VectorEnvelope<TVector> None = new (default, default);

        public VectorEnvelope(TVector min, TVector max)
        {
            this.min = min;
            this.max = max;
        }

        public static VectorEnvelope<TVector> FromPoints(TVector p1, TVector p2)
        {
            return new(TVector.Min(p1,p2), TVector.Max(p1,p2));
        }

        public static VectorEnvelope<TVector> FromList(ReadOnlyArray<TVector> list)
        {
            return FromList(list.AsSpan());
        }

        public static VectorEnvelope<TVector> FromList(ReadOnlySpan<TVector> list)
        {
            if (list.Length == 0)
            {
                return None;
            }
            var min = list[0];
            var max = min;
            for (var i = 1; i < list.Length; i++)
            {
                var current = list[i];
                min = TVector.Min(current, min);
                max = TVector.Max(current, max);
            }
            return new (min, max);
        }

        public TVector Min => min;

        public TVector Max => max;

        public bool Intersects(VectorEnvelope<TVector> other)
        {
            return other.min.IsLessThanOrEqualAll(max) &&
                   other.max.IsGreaterThanOrEqualAll(min);
        }

        public bool Contains(VectorEnvelope<TVector> other)
        {
            return
                other.min.IsGreaterThanOrEqualAll(min) &&
                other.max.IsLessThanOrEqualAll(max);
        }

        public bool Contains(TVector point)
        {
            return point.IsInRange(min, max);
        }
    }
}
