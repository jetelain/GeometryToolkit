using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pmad.Geometry.Collections
{
    public static class ReadOnlyArrayExtensions
    {
        public static ReadOnlyArray<TTo> Cast<TFrom, TTo>(this ReadOnlyArray<TFrom> array)
        {
            var source = array.AsSpan();
            var target = new TTo[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = (TTo)(object)source[i]!;
            }
            return new ReadOnlyArray<TTo>(target);
        }

        public static ReadOnlyArray<TTo> CopyAs<TFrom, TTo>(this ReadOnlyArray<TFrom> array)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            var casted = MemoryMarshal.Cast<TFrom, TTo>(array.AsSpan());
            return new ReadOnlyArray<TTo>(casted.ToArray()); // Create a full-copy
        }

        public static ReadOnlyArray<TTo> UnsafeAs<TFrom, TTo>(this ReadOnlyArray<TFrom> array)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            if (Unsafe.SizeOf<TFrom>() != Unsafe.SizeOf<TTo>())
            {
                // Count would not match
                ThrowHelper.ThrowNotSupportedException();
            }
            if (RuntimeHelpers.IsReferenceOrContainsReferences<TFrom>())
            {
                ThrowHelper.ThrowNotSupportedException();
            }
            if (RuntimeHelpers.IsReferenceOrContainsReferences<TTo>())
            {
                ThrowHelper.ThrowNotSupportedException();
            }
            return Unsafe.BitCast<ReadOnlyArray<TFrom>, ReadOnlyArray<TTo>>(array);
        }

        public static ReadOnlySpan<TTo> AsSpan<TFrom, TTo>(this ReadOnlyArray<TFrom> array)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            return MemoryMarshal.Cast<TFrom, TTo>(array.AsSpan()); // Re-interpreted pointer
        }
    }
}
