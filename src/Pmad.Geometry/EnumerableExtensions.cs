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

        public static double GetLengthD<TVector>(this IEnumerable<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var p1 = enumerator.Current;
                double result = 0;
                while (enumerator.MoveNext())
                {
                    var p2 = enumerator.Current;
                    result += p2.Substract(p1).LengthD();
                    p1 = p2;
                }
                return result;
            }
            return 0;
        }

        public static float GetLengthF<TVector>(this IEnumerable<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var p1 = enumerator.Current;
                float result = 0;
                while (enumerator.MoveNext())
                {
                    var p2 = enumerator.Current;
                    result += p2.Substract(p1).LengthF();
                    p1 = p2;
                }
                return result;
            }
            return 0;
        }
    }
}
