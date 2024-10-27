using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pmad.Geometry.Transforms
{
    internal static class TransformVectHelper<TPrimitive, TVector, TTransform>
        where TPrimitive : unmanaged//, INumber<TPrimitive>
        where TVector : struct//, IVector2<TPrimitive, TVector>
        where TTransform : struct, ITransformVect<TPrimitive, TVector>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Transform(TTransform transform, ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            if (Vector.IsHardwareAccelerated && Vector<TPrimitive>.Count > 2)
            {
                TransformVector(transform, source, destination);
                return;
            }
            TransformClassic(transform, source, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void TransformVector(TTransform transform, ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            var sourceVect = MemoryMarshal.Cast<TVector, Vector<TPrimitive>>(source);
            var destinationVect = MemoryMarshal.Cast<TVector, Vector<TPrimitive>>(destination);
            for (int i = 0; i < sourceVect.Length; ++i)
            {
                destinationVect[i] = transform.Transform(sourceVect[i]);
            }

            var remain = source.Length % (Vector<TPrimitive>.Count / 2);
            if (remain != 0)
            {
                TransformClassic(transform, source.Slice(source.Length - remain), destination.Slice(source.Length - remain));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void TransformClassic(TTransform transform, ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            for (int i = 0; i < source.Length; ++i)
            {
                destination[i] = transform.Transform(source[i]);
            }
        }
    }
}
