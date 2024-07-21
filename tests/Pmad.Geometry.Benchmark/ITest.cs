namespace Pmad.Geometry.Benchmark
{
    public interface ITest
    {
        void AngleRadians();
        void CrossProduct3();
        void CrossProductD();
        void DotD();
        double GetLengthD();
        double GetSignedArea();
        void Lerp();
        object Max();
        object Min();
        void NearestPointPath();
        void NearestPointSegment();
        void PointInPolygon();
        object Simplify();
        object Sum();
        object VectorEnvelope();
    }
}