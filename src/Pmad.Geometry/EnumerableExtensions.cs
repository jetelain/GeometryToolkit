using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
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

        public static TVector SumClassic<TVector>(this ReadOnlySpan<TVector> list)
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

        public static Vector128<TPrimitive> Sum<TPrimitive>(this ReadOnlySpan<Vector128<TPrimitive>> list)
            where TPrimitive : unmanaged, INumber<TPrimitive>
        {
            if (list.Length == 0)
            {
                return default;
            }
            Vector128<TPrimitive> result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = Vector128.Add(result, list[i]);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Sum<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return TVector.Sum(list.AsSpan());
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

        public static TVector MaxClassic<TVector>(this ReadOnlySpan<TVector> list)
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
            return TVector.Max(list.AsSpan());
        }

        public static Vector128<TPrimitive> Max<TPrimitive>(this ReadOnlySpan<Vector128<TPrimitive>> list)
            where TPrimitive : unmanaged, INumber<TPrimitive>
        {
            if (list.Length == 0)
            {
                return default;
            }
            Vector128<TPrimitive> result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = Vector128.Max(result, list[i]);
            }
            return result;
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

        public static TVector MinClassic<TVector>(this ReadOnlySpan<TVector> list)
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
        public static Vector128<TPrimitive> Min<TPrimitive>(this ReadOnlySpan<Vector128<TPrimitive>> list)
            where TPrimitive : unmanaged, INumber<TPrimitive>
        {
            if (list.Length == 0)
            {
                return default;
            }
            Vector128<TPrimitive> result = list[0];
            for (var i = 1; i < list.Length; i++)
            {
                result = Vector128.Min(result, list[i]);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Min<TVector>(this ReadOnlyArray<TVector> list)
            where TVector : struct, IVector<TVector>
        {
            return TVector.Min(list.AsSpan());
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TVector Point, double Distance) NearestPointPath<TVector>(this ReadOnlyArray<TVector> list, TVector p)
            where TVector : struct, IVector<TVector>
        {
            return NearestPointPath(list.AsSpan(), p);
        }

        public static (TVector Point, double Distance) NearestPointPath<TVector>(this ReadOnlySpan<TVector> list, TVector p)
            where TVector : struct, IVector<TVector>
        {
            if (list.Length == 0)
            {
                return (TVector.Zero, double.NaN);
            }
            if (list.Length == 1)
            {
                return (list[0], (list[0] - p).LengthD());
            }
            var p1 = list[1];
            var result = Vectors.NearestPointSegment(list[0], p1, p);
            var resultDistanceSquared = (result - p).LengthSquaredD();
            for (var i = 2; i < list.Length; i++)
            {
                var p2 = list[i];
                var candidate = Vectors.NearestPointSegment(p1, p2, p);
                var candidateDistanceSquared = (candidate - p).LengthSquaredD();
                if (candidateDistanceSquared < resultDistanceSquared)
                {
                    resultDistanceSquared = candidateDistanceSquared;
                    result = candidate;
                }
                p1 = p2;
            }
            return (result, Math.Sqrt(resultDistanceSquared));
        }

        public static ReadOnlyArray<TVector> SimplifyClassic<TVector>(this ReadOnlyArray<TVector> input, double epsilonSquared = 0.25)
            where TVector : struct, IVector<TVector>
        {
            if (input.Count < 3)
            {
                return input;
            }
            return SimplifyClassic(input.AsSpan(), epsilonSquared);
        }

        public static ReadOnlyArray<TVector> SimplifyClassic<TVector>(this ReadOnlySpan<TVector> input, double epsilonSquared = 0.25)
            where TVector : struct, IVector<TVector>
        {
            if (input.Length < 3)
            {
                return input.ToReadOnlyArray();
            }
            var previousPoint = input[0];
            var result = new ReadOnlyArrayBuilder<TVector>() { previousPoint };
            for (int i = 1; i < input.Length - 1; i++)
            {
                var thisPoint = input[i];
                var nextPoint = input[i + 1];
                if (Vectors.PerpendicularDistanceFromLineSquaredClassic(thisPoint, previousPoint, nextPoint) > epsilonSquared)
                {
                    result.Add(thisPoint);
                    previousPoint = thisPoint;
                }
            }
            result.Add(input[input.Length - 1]);
            return result.Build();
        }


        public static ReadOnlyArray<TVector> Simplify<TVector>(this ReadOnlyArray<TVector> input, double epsilonSquared = 0.25)
            where TVector : struct, IVector<TVector>
        {
            if (input.Count < 3)
            {
                return input;
            }
            return Simplify(input.AsSpan(), epsilonSquared);
        }

        public static ReadOnlyArray<TVector> Simplify<TVector>(this ReadOnlySpan<TVector> input, double epsilonSquared = 0.25)
            where TVector : struct, IVector<TVector>
        {
            if (input.Length < 3)
            {
                return input.ToReadOnlyArray();
            }
            var previousPoint = input[0];
            var result = new ReadOnlyArrayBuilder<TVector>() { previousPoint };
            for (int i = 1; i < input.Length - 1; i++)
            {
                var thisPoint = input[i];
                var nextPoint = input[i + 1];
                if (Vectors.PerpendicularDistanceFromLineSquared(thisPoint, previousPoint, nextPoint) > epsilonSquared)
                {
                    result.Add(thisPoint);
                    previousPoint = thisPoint;
                }
            }
            result.Add(input[input.Length - 1]);
            return result.Build();
        }
    }
}
