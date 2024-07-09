namespace Pmad.Geometry
{
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
            return new(p1.Min(p2), p1.Max(p2));
        }

        public static VectorEnvelope<TVector> FromList(IEnumerable<TVector> list)
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var min = enumerator.Current;
                var max = min;
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    min = current.Min(min);
                    max = current.Max(max);
                }
                return new (min, max);
            }
            return None;
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
