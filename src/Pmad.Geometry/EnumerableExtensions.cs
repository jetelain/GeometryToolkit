using System.Runtime.CompilerServices;
using Pmad.Geometry.Collections;

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
                    value = value + enumerator.Current;
                }
                return value;
            }
            return default;
        }

        public static TVector Sum<TVector>(this ReadOnlySpan<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length == 0)
            {
                return default;
            }
            TVector result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = result + list[i];
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Sum<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return Sum(list.AsSpan());
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
                    value = TVector.Max(value, enumerator.Current);
                }
                return value;
            }
            ThrowHelper.ThrowNoElementsException();
            return default;
        }

        public static TVector Max<TVector>(this ReadOnlySpan<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length == 0)
            {
                return default;
            }
            TVector result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = TVector.Max(result, list[i]);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Max<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return Max(list.AsSpan());
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
                    value = TVector.Min(value, enumerator.Current);
                }
                return value;
            }
            ThrowHelper.ThrowNoElementsException();
            return default;
        }

        public static TVector Min<TVector>(this ReadOnlySpan<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length == 0)
            {
                return default;
            }
            TVector result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = TVector.Min(result, list[i]);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Min<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return Min(list.AsSpan());
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
                    result += (p2 - p1).LengthD();
                    p1 = p2;
                }
                return result;
            }
            return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLengthD<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return GetLengthD(list.AsSpan());
        }

        public static double GetLengthD<TVector>(this ReadOnlySpan<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length < 2)
            {
                return 0;
            }
            double result = 0;
            var p1 = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                var p2 = list[i];
                result += (p2 - p1).LengthD();
                p1 = p2;
            }
            return result;
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
                    result += (p2 - p1).LengthF();
                    p1 = p2;
                }
                return result;
            }
            return 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetLengthF<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return GetLengthF(list.AsSpan());
        }

        public static float GetLengthF<TVector>(this ReadOnlySpan<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length < 2)
            {
                return 0;
            }
            float result = 0;
            var p1 = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                var p2 = list[i];
                result += (p2 - p1).LengthF();
                p1 = p2;
            }
            return result;
        }
    }
}
