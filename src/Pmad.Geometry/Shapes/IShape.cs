using System.Numerics;

namespace Pmad.Geometry.Shapes
{
    public interface IShape<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        double AreaD { get; }

        bool IsInside(TVector point);

        bool IsInsideOrOnBoundary(TVector point);

        bool Contains(TVector point);

        double Distance(TVector point);

        TVector NearestPointBoundary(TVector point);

        (TVector Point, double Distance) NearestPointDistanceBoundary(TVector point);
    }
}
