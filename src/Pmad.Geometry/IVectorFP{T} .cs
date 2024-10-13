using System.Numerics;

namespace Pmad.Geometry
{
    /// <summary>
    /// Floating Point Vector
    /// </summary>
    /// <typeparam name="TPrimitive">Floating point primative type (double or float)</typeparam>
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

        TPrimitive Atan2();

        TPrimitive Area();

        TVector Floor();

        TVector Ceiling();

        Vector2I FloorI();

        Vector2I CeilingI();

        static abstract TPrimitive Dot(TVector left, TVector right);

        static abstract TVector Lerp(TVector left, TVector right, TPrimitive amount);

        static abstract TVector Normalize(TVector left);

        static abstract new TPrimitive CrossProduct(TVector pt1, TVector pt2, TVector pt3);

        static abstract TPrimitive CrossProduct(TVector pt1, TVector pt2);
    }
}
