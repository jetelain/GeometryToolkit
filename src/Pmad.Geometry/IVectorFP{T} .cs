using System.Numerics;

namespace Pmad.Geometry
{
    /// <summary>
    /// Floating-point vector.
    /// </summary>
    /// <typeparam name="TPrimitive">Floating-point primitive type (<see langword="float"/> or <see langword="double"/>)</typeparam>
    /// <typeparam name="TVector">Vector type</typeparam>
    public interface IVectorFP<TPrimitive,TVector> : IVector<TVector>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector: struct, IVectorFP<TPrimitive,TVector>
    {
        /// <summary>
        /// Length of vector
        /// </summary>
        /// <returns>sqrt(X^2 + Y^2)</returns>
        TPrimitive Length();

        /// <summary>
        /// Squared length of vector
        /// </summary>
        /// <returns>X^2 + Y^2</returns>
        TPrimitive LengthSquared();

        /// <summary>Returns the angle of this vector in radians: atan2(Y, X).</summary>
        TPrimitive Atan2();

        /// <summary>Returns the signed area of the axis-aligned rectangle defined by the components: X * Y.</summary>
        TPrimitive Area();

        /// <summary>Returns a new vector with each component rounded down to the nearest integer.</summary>
        TVector Floor();

        /// <summary>Returns a new vector with each component rounded up to the nearest integer.</summary>
        TVector Ceiling();

        /// <summary>Returns a <see cref="Vector2I"/> with each component rounded down to the nearest integer.</summary>
        Vector2I FloorI();

        /// <summary>Returns a <see cref="Vector2I"/> with each component rounded up to the nearest integer.</summary>
        Vector2I CeilingI();

        /// <summary>Returns the dot product of <paramref name="left"/> and <paramref name="right"/> using the primitive type.</summary>
        static abstract TPrimitive Dot(TVector left, TVector right);

        /// <summary>Linearly interpolates between <paramref name="left"/> and <paramref name="right"/> by the primitive <paramref name="amount"/>.</summary>
        static abstract TVector Lerp(TVector left, TVector right, TPrimitive amount);

        /// <summary>Returns a unit vector in the direction of <paramref name="left"/>.</summary>
        static abstract TVector Normalize(TVector left);

        /// <summary>Returns the cross product of the two edges meeting at <paramref name="pt2"/>: (pt2-pt1) × (pt3-pt2).</summary>
        static abstract new TPrimitive CrossProduct(TVector pt1, TVector pt2, TVector pt3);

        /// <summary>Returns the 2D cross product of the two vectors: <paramref name="pt1"/>.X * <paramref name="pt2"/>.Y - <paramref name="pt1"/>.Y * <paramref name="pt2"/>.X.</summary>
        static abstract TPrimitive CrossProduct(TVector pt1, TVector pt2);
    }
}
