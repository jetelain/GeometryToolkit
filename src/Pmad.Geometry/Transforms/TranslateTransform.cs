using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry.Transforms
{
    internal struct TranslateTransform<TPrimitive, TVector> : ITransform<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        internal readonly TVector _vector;

        public TranslateTransform(TVector vector)
        {
            _vector = vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector Transform(TVector vector)
        {
            return vector + _vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            for (int i = 0; i < source.Length; ++i)
            {
                destination[i] = Transform(source[i]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ITransform<TVector>.TransformClassic(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            Transform(source, destination);
        }
    }
}
