namespace Pmad.Geometry
{
    public static partial class Vectors
    {
        public static bool HasLineIntersection<TVector>(TVector A1, TVector A2, TVector B1, TVector B2, out TVector intersection)
            where TVector : struct, IVector<TVector>
        {
            var tmp = CrossProductD(B2.Substract(B1), A2.Substract(A1));
            if (tmp == 0)
            {
                intersection = default;
                return false;
            }
            var mu = CrossProductD(A1.Substract(B1), A2.Substract(A1)) / tmp;
            intersection = B1.Add(B2.Substract(B1).Multiply(mu));
            return true;
        }

        public static bool HasSegmentIntersection<TVector>(TVector A1, TVector A2, TVector B1, TVector B2, out TVector intersection)
            where TVector : struct, IVector<TVector>
        {
            var tmp = CrossProductD(B2.Substract(B1), A2.Substract(A1));
            if (tmp == 0)
            {
                intersection = default;
                return false;
            }
            var mu1 = CrossProductD(A1.Substract(B1), A2.Substract(A1)) / tmp;
            if (mu1 < 0 || mu1 > 1)
            {
                intersection = default;
                return false;
            }
            var mu2 = CrossProductD(B1.Substract(A1), B2.Substract(B1)) / CrossProductD(A2.Substract(A1), B2.Substract(B1));
            if (mu2 < 0 || mu2 > 1)
            {
                intersection = default;
                return false;
            }
            intersection = B1.Add(B2.Substract(B1).Multiply(mu1));
            return true;
        }
    }
}
