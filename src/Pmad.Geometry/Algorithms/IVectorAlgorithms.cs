using Clipper2Lib;

namespace Pmad.Geometry.Algorithms
{
    public interface IVectorAlgorithms<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        PointInPolygonResult TestPointInPolygon(IReadOnlyList<TVector> points, TVector point); 
        
        double GetSignedAreaD(IReadOnlyList<TVector> points);

        float GetSignedAreaF(IReadOnlyList<TVector> points);

        TVector Create(TPrimitive x, TPrimitive y);

        TVector Create(int x, int y);

        TVector Create(double x, double y);
    }

}
