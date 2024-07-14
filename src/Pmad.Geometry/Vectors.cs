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
    }
}
