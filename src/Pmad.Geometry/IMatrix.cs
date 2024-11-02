using Pmad.Geometry.Transforms;

namespace Pmad.Geometry
{
    public interface IMatrix<TVector> : ITransform<TVector>
        where TVector : struct, IVector<TVector>
    {

    }
}
