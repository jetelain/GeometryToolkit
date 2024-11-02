using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Transforms
{
    public static class TransformExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<TVector> Transform<TVector>(this ITransform<TVector> transform, ReadOnlyArray<TVector> source)
            where TVector : struct
        {
            var target = new TVector[source.Count];
            transform.Transform(source.AsSpan(), target);
            return new ReadOnlyArray<TVector>(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ReadOnlyArray<TVector> TransformClassic<TVector>(this ITransform<TVector> transform, ReadOnlyArray<TVector> source)
            where TVector : struct
        {
            var target = new TVector[source.Count];
            transform.TransformClassic(source.AsSpan(), target);
            return new ReadOnlyArray<TVector>(target);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Path64 TransformClipper(this ITransform<Vector2L> transform, Path64 source)
        {
            // Point64 and Vector2L have exactly the same memory layout
            var target = new Path64(source.Count);
            CollectionsMarshal.SetCount(target, source.Count);
            transform.Transform(
                MemoryMarshal.Cast<Point64, Vector2L>((ReadOnlySpan<Point64>)CollectionsMarshal.AsSpan(source)),
                MemoryMarshal.Cast<Point64, Vector2L>(CollectionsMarshal.AsSpan(target)));
            return target;
        }
    }
}
