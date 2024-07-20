using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public static partial class Vectors
    {
        public static bool HasLineIntersection<TVector>(TVector A1, TVector A2, TVector B1, TVector B2, out TVector intersection)
            where TVector : struct, IVector<TVector>
        {
            var tmp = TVector.CrossProductD(B2 - B1, A2 - A1);
            if (tmp == 0)
            {
                intersection = default;
                return false;
            }
            var mu = TVector.CrossProductD(A1 - B1, A2 - A1) / tmp;
            intersection = ((B2 - B1) * mu) + B1;
            return true;
        }

        public static bool HasSegmentIntersection<TVector>(TVector A1, TVector A2, TVector B1, TVector B2, out TVector intersection)
            where TVector : struct, IVector<TVector>
        {
            var tmp = TVector.CrossProductD(B2 - B1, A2 - A1);
            if (tmp == 0)
            {
                intersection = default;
                return false;
            }
            var mu1 = TVector.CrossProductD(A1 - B1, A2 - A1) / tmp;
            if (mu1 < 0 || mu1 > 1)
            {
                intersection = default;
                return false;
            }
            var mu2 = TVector.CrossProductD(B1 - A1, B2 - B1) / TVector.CrossProductD(A2 - A1, B2 - B1);
            if (mu2 < 0 || mu2 > 1)
            {
                intersection = default;
                return false;
            }
            intersection = ((B2 - B1) * mu1) + B1;
            return true;
        }

        public static TVector NearestPointSegment<TVector>(TVector a1, TVector a2, TVector p)
            where TVector : struct, IVector<TVector>
        {
            var d = a2 - a1;
            var lengthSquared = d.LengthSquaredD();
            if (lengthSquared == 0)
            {
                return a1;
            }
            var t = Math.Clamp(TVector.DotD(p - a1, d) / lengthSquared, 0, 1);
            return a1 + (d * t);
        }

        /// <summary>
        /// Compute value of angle between two vectors (2D)
        /// </summary>
        /// <typeparam name="TVector"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Value between -π and π</returns>
        public static double AngleRadians<TVector>(TVector a, TVector b)
            where TVector : struct, IVector<TVector>
        {
            return Math.Atan2(TVector.CrossProductD(a, b), TVector.DotD(a, b));
        }

        /// <summary>
        /// Compute absolute value of angle between two vectors (2D)
        /// </summary>
        /// <typeparam name="TVector"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Value between 0 and π</returns>
        public static double AngleRadiansAbs<TVector>(TVector a, TVector b)
            where TVector : struct, IVector<TVector>
        {
            return Math.Acos(TVector.DotD(a, b) / (a.LengthD() * b.LengthD()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TVector Lerp<TVector>(TVector value1, TVector value2, double amount)
            where TVector : struct, IVector<TVector>
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }
    }
}
