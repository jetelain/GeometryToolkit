using System.Numerics;

namespace Pmad.Geometry
{
    /// <summary>
    /// Floating Point Vector
    /// </summary>
    /// <typeparam name="TPrimitive">Floating point primative type (double or float)</typeparam>
    /// <typeparam name="TVector">Vector type</typeparam>
    public interface IVectorFP<TPrimitive,TVector> : IVector<TVector>
        where TPrimitive : unmanaged
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


        TVector Normalize();

        TPrimitive Area();
    }
}
