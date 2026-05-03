using System.Numerics;

namespace Pmad.Geometry.Shapes
{
    /// <summary>Common interface for all 2D shapes.</summary>
    /// <typeparam name="TPrimitive">Numeric primitive type of the vector components.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public interface IShape<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        /// <summary>Area of the shape in double precision.</summary>
        double AreaD { get; }

        /// <summary>Returns <see langword="true"/> if <paramref name="point"/> is strictly inside the shape (not on the boundary).</summary>
        bool IsInside(TVector point);

        /// <summary>Returns <see langword="true"/> if <paramref name="point"/> is inside or exactly on the boundary of the shape.</summary>
        bool IsInsideOrOnBoundary(TVector point);

        /// <summary>Returns <see langword="true"/> if <paramref name="point"/> is inside or on the boundary of the shape. Equivalent to <see cref="IsInsideOrOnBoundary"/>.</summary>
        bool Contains(TVector point);

        /// <summary>
        /// Returns the distance from <paramref name="point"/> to the nearest boundary of the shape.
        /// Returns 0 if the point is inside or on the boundary.
        /// </summary>
        double Distance(TVector point);

        /// <summary>Returns the nearest point on the boundary of the shape to <paramref name="point"/>.</summary>
        TVector NearestPointBoundary(TVector point);

        /// <summary>Returns the nearest point on the boundary of the shape and the distance from <paramref name="point"/> to it.</summary>
        (TVector Point, double Distance) NearestPointDistanceBoundary(TVector point);
    }
}
