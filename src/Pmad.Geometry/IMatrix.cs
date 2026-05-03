namespace Pmad.Geometry
{
    /// <summary>Represents a matrix that can transform a vector.</summary>
    /// <typeparam name="TVector">Vector type to transform.</typeparam>
    public interface IMatrix<TVector> where TVector : struct, IVector<TVector>
    {
        /// <summary>Applies the matrix transformation to <paramref name="vector"/> and returns the result.</summary>
        TVector Transform(TVector vector);
    }
}
