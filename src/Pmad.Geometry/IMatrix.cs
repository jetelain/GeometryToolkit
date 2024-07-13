namespace Pmad.Geometry
{
    public interface IMatrix<TVector> where TVector : struct, IVector<TVector>
    {
        TVector Transform(TVector vector);
    }
}
