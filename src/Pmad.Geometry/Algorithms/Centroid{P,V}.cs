using System.Numerics;
using System.Runtime.CompilerServices;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Algorithms
{
    public static class Centroid<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector GetCentroid(ReadOnlyArray<TVector> points)
        {
            return GetCentroid(points.AsSpan());
        }

        public static TVector GetCentroid(ReadOnlySpan<TVector> points)
        {
            if (points.Length < 3)
            {
                if (points.Length == 1)
                {
                    return points[0];
                }
                if (points.Length == 2)
                {
                    return (points[0] + points[1]) / 2;
                }
                return TVector.Zero;
            }
            var v1 = points[points.Length - 1];
            var polygonArea = 0.0;
            var x = 0.0;
            var y = 0.0;
            for (var i = 0; i < points.Length; i++)
            {
                var v2 = points[i];
                var triangleArea = TVector.CrossProductD(v1, v2);
                polygonArea += triangleArea;
                var s = (v1 + v2);
                x += double.CreateTruncating(s.X) * triangleArea;
                y += double.CreateTruncating(s.Y) * triangleArea;
                v1 = v2;
            }
            if (polygonArea == 0)
            {
                return points[0];
            }
            return TVector.Create(
                x / (3 * polygonArea),
                y / (3 * polygonArea));
        }
    }
}
