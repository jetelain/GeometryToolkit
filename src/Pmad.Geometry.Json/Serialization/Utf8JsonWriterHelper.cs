using System.Numerics;
using System.Text.Json;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    internal static class Utf8JsonWriterHelper<TPrimitive, TVector>
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public static void WritePolygon(Utf8JsonWriter writer, Polygon<TPrimitive, TVector> p)
        {
            writer.WriteStartArray();
            WriteLineString(writer, p.Shell.AsSpan());
            foreach (var hole in p.Holes)
            {
                WriteLineString(writer, hole.AsSpan());
            }
            writer.WriteEndArray();
        }

        public static void WriteLineString(Utf8JsonWriter writer, ReadOnlySpan<TVector> array)
        {
            writer.WriteStartArray();
            foreach (var value in array)
            {
                WritePoint(writer, value);
            }
            writer.WriteEndArray();
        }

        public static void WriteMultiPoint(Utf8JsonWriter writer, IEnumerable<TVector> array)
        {
            writer.WriteStartArray();
            foreach (var value in array)
            {
                WritePoint(writer, value);
            }
            writer.WriteEndArray();
        }

        public static void WritePoint(Utf8JsonWriter writer, TVector value)
        {
            writer.WriteStartArray();
            WriteScalarValue(writer, value.X);
            WriteScalarValue(writer, value.Y);
            writer.WriteEndArray();
        }

        public static void WriteScalarValue(Utf8JsonWriter writer, TPrimitive value)
        {
            if (typeof(TPrimitive) == typeof(double))
            {
                writer.WriteNumberValue((double)(object)value);
            }
            else if (typeof(TPrimitive) == typeof(long))
            {
                writer.WriteNumberValue((long)(object)value);
            }
            else if (typeof(TPrimitive) == typeof(float))
            {
                writer.WriteNumberValue((float)(object)value);
            }
            else if (typeof(TPrimitive) == typeof(int))
            {
                writer.WriteNumberValue((int)(object)value);
            }
            else
            {
                writer.WriteNumberValue(double.CreateTruncating(value));
            }
        }

        internal static void WriteMultiPolygon(Utf8JsonWriter writer, MultiPolygon<TPrimitive, TVector> value)
        {
            writer.WriteStartArray();
            foreach (var polygon in value)
            {
                WritePolygon(writer, polygon);
            }
            writer.WriteEndArray();
        }

        internal static void WriteMultiLineString(Utf8JsonWriter writer, MultiPath<TPrimitive, TVector> paths)
        {
            writer.WriteStartArray();
            foreach (var path in paths)
            {
                WriteLineString(writer, path.Points.AsSpan());
            }
            writer.WriteEndArray();
        }

        internal static void WritePolygonSet(Utf8JsonWriter writer, PolygonSet<TPrimitive, TVector> paths)
        {
            var settings = paths.Settings;
            writer.WriteStartArray();
            foreach (var path in paths.Paths)
            {
                writer.WriteStartArray();
                foreach (var value in path)
                {
                    WritePoint(writer, settings.FromClipper(value));
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
}
