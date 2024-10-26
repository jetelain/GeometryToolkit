using System.Numerics;
using System.Runtime.CompilerServices;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry
{
    internal static class TransformExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<TVector> Transform<TPrimitive, TVector>(this ITransform<TPrimitive, TVector> transform, ReadOnlyArray<TVector> source)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            var target = new TVector[source.Count];
            transform.Transform(source.AsSpan(), target);
            return new ReadOnlyArray<TVector>(target);
        }


    }
}
