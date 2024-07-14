using System.Numerics;
using System.Runtime.CompilerServices;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Algorithms
{
    public static class SignedArea<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetSignedAreaD(ReadOnlyArray<TVector> points)
        {
            return GetSignedAreaD(points.AsSpan());
        }

        public static double GetSignedAreaD(ReadOnlySpan<TVector> points)
        {
            if (points.Length < 3)
            {
                return 0;
            }
            var v1 = points[points.Length - 1];
            double area = 0;
            for (var i = 0; i < points.Length; i++)
            {
                var v2 = points[i];
                area += TVector.CrossProductD(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetSignedAreaF(ReadOnlyArray<TVector> points)
        {
            return GetSignedAreaF(points.AsSpan());
        }

        public static float GetSignedAreaF(ReadOnlySpan<TVector> points)
        {
            if (points.Length < 3)
            {
                return 0;
            }
            var v1 = points[points.Length - 1];
            float area = 0;
            for (var i = 0; i < points.Length; i++)
            {
                var v2 = points[i];
                area += TVector.CrossProductF(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
    }
}
