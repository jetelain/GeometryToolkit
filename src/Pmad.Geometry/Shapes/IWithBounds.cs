namespace Pmad.Geometry.Shapes
{
    /// <summary>A shape that exposes an axis-aligned bounding envelope.</summary>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public interface IWithBounds<TVector>
        where TVector : struct, IVector<TVector>
    {
        /// <summary>The axis-aligned bounding box of this shape.</summary>
        VectorEnvelope<TVector> Bounds { get; }
    }
}
