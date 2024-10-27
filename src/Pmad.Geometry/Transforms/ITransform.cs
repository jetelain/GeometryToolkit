namespace Pmad.Geometry.Transforms
{
    internal interface ITransform<TVector>
        where TVector : struct
    {
        TVector Transform(TVector vector);

        void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination);

        void TransformClassic(ReadOnlySpan<TVector> source, Span<TVector> destination);
    }
}
