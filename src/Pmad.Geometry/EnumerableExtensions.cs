namespace Pmad.Geometry
{
    public static class EnumerableExtensions
    {
        public static TVector Sum<TVector>(this IEnumerable<TVector> list) 
            where TVector : struct, IVector<TVector>
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    value = value.Add(enumerator.Current);
                }
                return value;
            }
            return default;
        }

        public static TVector Max<TVector>(this IEnumerable<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    value = value.Max(enumerator.Current);
                }
                return value;
            }
            return default; // TODO: Throws
        }

        public static TVector Min<TVector>(this IEnumerable<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var value = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    value = value.Min(enumerator.Current);
                }
                return value;
            }
            return default; // TODO: Throws
        }
    }
}
