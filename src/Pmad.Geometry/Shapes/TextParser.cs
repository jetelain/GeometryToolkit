using System.Buffers;
using System.Globalization;
using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    static class TextParser<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private static readonly SearchValues<char> EndOfNumber = SearchValues.Create(" ,)\r\n\t");
        private static readonly SearchValues<char> EndOfValue = SearchValues.Create(",)");

        private delegate T Reader<T>(ref ReadOnlySpan<char> buffer);

        private static ReadOnlyArray<T> ReadList<T>(ref ReadOnlySpan<char> buffer, Reader<T> reader )
        {
            SkipWhiteSpace(ref buffer);

            if (buffer.StartsWith("EMPTY"))
            {
                buffer = buffer.Slice(5);
                return ReadOnlyArray<T>.Empty();
            }

            Consume(ref buffer, '(');

            SkipWhiteSpace(ref buffer);

            if (buffer.Length == 0)
            {
                throw new FormatException();
            }

            if (buffer[0] == ')')
            {
                buffer = buffer.Slice(1);
                return ReadOnlyArray<T>.Empty();
            }

            var list = new ReadOnlyArrayBuilder<T>();

            do
            {
                list.Add(reader(ref buffer));
            }
            while (Consume(ref buffer, EndOfValue) != ')');
            

            return list.ToReadOnlyArray();
        }

        internal static ReadOnlyArray<TVector> ReadVectorList(ref ReadOnlySpan<char> buffer)
        {
            return ReadList(ref buffer, ReadVector);
        }

        internal static ReadOnlyArray<ReadOnlyArray<TVector>> ReadVectorListList(ref ReadOnlySpan<char> buffer)
        {
            return ReadList(ref buffer, ReadVectorList);
        }

        internal static ReadOnlyArray<ReadOnlyArray<ReadOnlyArray<TVector>>> ReadVectorListListList(ref ReadOnlySpan<char> buffer)
        {
            return ReadList(ref buffer, ReadVectorListList);
        }

        private static void Consume(ref ReadOnlySpan<char> buffer, char char0)
        {
            SkipWhiteSpace(ref buffer);
            if (buffer.Length == 0 || buffer[0] != char0)
            {
                throw new FormatException();
            }
            buffer = buffer.Slice(1);
        }

        private static char Consume(ref ReadOnlySpan<char> buffer, SearchValues<char> anyOfChar)
        {
            SkipWhiteSpace(ref buffer);
            if (buffer.Length == 0 || !anyOfChar.Contains(buffer[0]))
            {
                throw new FormatException();
            }
            var result = buffer[0];
            buffer = buffer.Slice(1);
            return result;
        }

        private static TVector ReadVector(ref ReadOnlySpan<char> buffer)
        {
            var x = ReadNumber(ref buffer);
            var y = ReadNumber(ref buffer);
            return TVector.Create(x, y);
        }

        private static TPrimitive ReadNumber(ref ReadOnlySpan<char> buffer)
        {
            SkipWhiteSpace(ref buffer);

            var endIndex = buffer.IndexOfAny(EndOfNumber);
            if (endIndex == -1)
            {
                throw new FormatException();
            }

            var number = TPrimitive.Parse(buffer.Slice(0, endIndex), CultureInfo.InvariantCulture);
            buffer = buffer.Slice(endIndex);
            return number;
        }

        private static void SkipWhiteSpace(ref ReadOnlySpan<char> buffer)
        {
            while (buffer.Length > 0 && char.IsWhiteSpace(buffer[0]))
            {
                buffer = buffer.Slice(1);
            }
        }
    }
}
