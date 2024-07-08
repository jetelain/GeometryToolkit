namespace Pmad.Geometry.Algorithms
{
    public interface IVectorFPAlgorithms<TPrimitive, TVector> : IVectorAlgorithms<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        IPathFollower<TPrimitive, TVector> CreateFollower(IEnumerable<TVector> points);
    }

}
