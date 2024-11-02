using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry.Transforms
{
    internal struct ScaleAndTranslateTransform<TPrimitive, TVector> : ITransform<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly ScaleTransform<TPrimitive, TVector> _primitive;
        private readonly TranslateTransform<TPrimitive, TVector> _vector;

        public ScaleAndTranslateTransform(TPrimitive primitive, TVector vector)
        {
            _primitive = new(primitive);
            _vector = new(vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector Transform(TVector vector)
        {
            return vector * _primitive._primitive + _vector._vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            _primitive.Transform(source, destination);
            _vector.Transform(destination, destination);
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
