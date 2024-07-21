using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    internal static class Vector128Helper<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {

        public static TVector Min8Bytes(ReadOnlySpan<TVector> values)
        {
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Min();
            return TVector.Create(v128[0], v128[1]);
        }

        public static TVector Max8Bytes(ReadOnlySpan<TVector> values)
        {
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Max();
            return TVector.Create(v128[0], v128[1]);
        }

        public static TVector Sum8Bytes(ReadOnlySpan<TVector> values)
        {
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Sum();
            return TVector.Create(v128[0], v128[1]);
        }

        public static TVector Min4Bytes(ReadOnlySpan<TVector> values)
        {
            if (values.Length == 1)
            {
                return values[0];
            }
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Min();
            var result = TVector.Create(TPrimitive.Min(v128[0], v128[2]), TPrimitive.Min(v128[1], v128[3]));
            if (values.Length % 2 == 1)
            {
                return TVector.Min(result, values[values.Length - 1]);
            }
            return result;
        }

        public static TVector Max4Bytes(ReadOnlySpan<TVector> values)
        {
            if (values.Length == 1)
            {
                return values[0];
            }
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Max();
            var result = TVector.Create(TPrimitive.Max(v128[0], v128[2]), TPrimitive.Max(v128[1], v128[3]));
            if (values.Length % 2 == 1)
            {
                return TVector.Max(result, values[values.Length - 1]);
            }
            return result;
        }

        public static TVector Sum4Bytes(ReadOnlySpan<TVector> values)
        {
            if (values.Length == 1)
            {
                return values[0];
            }
            var v128 = MemoryMarshal.Cast<TVector, Vector128<TPrimitive>>(values).Sum();
            var result = TVector.Create(v128[0] + v128[2], v128[1] + v128[3]); 
            if (values.Length % 2 == 1)
            {
                return result + values[values.Length - 1];
            }
            return result;
        }


    }
}
