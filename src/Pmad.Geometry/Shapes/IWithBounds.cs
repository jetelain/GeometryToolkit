namespace Pmad.Geometry.Shapes
{
    public interface IWithBounds<TVector>
        where TVector : struct, IVector<TVector>
    {
        VectorEnvelope<TVector> Bounds { get; }
    }
}
