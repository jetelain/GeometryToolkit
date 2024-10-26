using System.Numerics;

namespace Pmad.Geometry
{
    internal interface ITransform<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        TVector Transform(TVector vector);

        Vector<TPrimitive> Transform(Vector<TPrimitive> vector);

        void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination);
    }
}
