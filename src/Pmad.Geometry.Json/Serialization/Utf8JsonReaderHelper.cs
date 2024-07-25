using System.Numerics;
using System.Text.Json;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Json.Serialization
{
    internal static class Utf8JsonReaderHelper<TPrimitive, TVector>
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public static Coordinates<TPrimitive, TVector> ReadCoordinatesData(ref Utf8JsonReader reader)
        {
            return new Coordinates<TPrimitive, TVector>(ReadCoordinatesBlock(ref reader));
        }

        public static object? ReadCoordinatesBlock(ref Utf8JsonReader reader)
        {
            ReadArrayStart(ref reader);
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                IArrayBuilder? list = null;
                while (reader.TokenType != JsonTokenType.EndArray)
                {
                    var child = ReadCoordinatesBlock(ref reader);
                    if (child != null)
                    {
                        if (list == null)
                        {
                            list = CreateList(child);
                        }
                        else
                        {
                            list.Add(child);
                        }
                    }
                    reader.Read();
                }
                EnsureEndArray(ref reader);
                return list?.Build();
            }
            if (reader.TokenType == JsonTokenType.Number)
            {
                return ReadVectorContent(ref reader);
            }
            throw new JsonException();
        }

        private static IArrayBuilder CreateList(object child)
        {
            if (child is TVector vector)
            {
                return new JsonArrayBuilder<TVector>(vector);
            }
            if (child is ReadOnlyArray<TVector> vector1)
            {
                return new JsonArrayBuilder<ReadOnlyArray<TVector>>(vector1);
            }
            if (child is ReadOnlyArray<ReadOnlyArray<TVector>> vector2)
            {
                return new JsonArrayBuilder<ReadOnlyArray<ReadOnlyArray<TVector>>>(vector2);
            }
            throw new JsonException();
        }

        private static void EnsureEndArray(ref Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException();
        }

        private static void ReadArrayStart(ref Utf8JsonReader reader)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            reader.Read(); // Consume StartArray
        }

        public static TVector ReadVector(ref Utf8JsonReader reader)
        {
            ReadArrayStart(ref reader);

            return ReadVectorContent(ref reader);
        }

        private static TVector ReadVectorContent(ref Utf8JsonReader reader)
        {
            var x = GetScalar(ref reader);

            reader.Read();

            var y = GetScalar(ref reader);

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray) 
            {
                reader.Skip();
            }

            EnsureEndArray(ref reader);

            return TVector.Create(x, y);
        }

        public static TPrimitive GetScalar(ref Utf8JsonReader reader)
        {
            if (typeof(TPrimitive) == typeof(double))
            {
                return (TPrimitive)(object)reader.GetDouble();
            }
            if (typeof(TPrimitive) == typeof(long))
            {
                return (TPrimitive)(object)reader.GetInt64();
            }
            if (typeof(TPrimitive) == typeof(float))
            {
                return (TPrimitive)(object)reader.GetSingle();
            }
            if (typeof(TPrimitive) == typeof(int))
            {
                return (TPrimitive)(object)reader.GetInt32();
            }
            return TPrimitive.CreateTruncating(reader.GetDouble());
        }
    }
}
