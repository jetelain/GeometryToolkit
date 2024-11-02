using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry.Transforms
{
    internal struct ScaleTransform<TPrimitive, TVector> : ITransform<TVector>, ITransformVect<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        internal readonly TPrimitive _primitive;

        public ScaleTransform(TPrimitive primitive)
        {
            _primitive = primitive;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector Transform(TVector vector)
        {
            return vector * _primitive;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector<TPrimitive> Transform(Vector<TPrimitive> vector)
        {
            return vector * _primitive;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            TransformVectHelper<TPrimitive, TVector, ScaleTransform<TPrimitive, TVector>>.Transform(this, source, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ITransform<TVector>.TransformClassic(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            for (int i = 0; i < source.Length; ++i)
            {
                destination[i] = Transform(source[i]);
            }
        }
    }
}
