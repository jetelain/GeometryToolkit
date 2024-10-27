using System.Runtime.CompilerServices;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Transforms
{
    internal static class TransformExtensions
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
        public static ReadOnlyArray<TVector> TransformClassic<TVector>(this ITransform<TVector> transform, ReadOnlyArray<TVector> source)
            where TVector : struct
        {
            var target = new TVector[source.Count];
            transform.TransformClassic(source.AsSpan(), target);
            return new ReadOnlyArray<TVector>(target);
        }
    }
}
