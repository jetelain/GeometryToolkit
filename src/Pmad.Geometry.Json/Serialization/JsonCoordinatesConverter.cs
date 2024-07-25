using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonCoordinatesConverter<TPrimitive, TVector> : JsonConverter<Coordinates<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override Coordinates<TPrimitive, TVector> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Utf8JsonReaderHelper<TPrimitive, TVector>.ReadCoordinatesData(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, Coordinates<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            switch (value.Value)
            {
                case TVector point:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WritePoint(writer, point);
                    break;
                case Polygon<TPrimitive, TVector> polygon:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WritePolygon(writer, polygon);
                    break;
                case Path<TPrimitive, TVector> path:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WriteLineString(writer, path.Points.AsSpan());
                    break;

                case MultiPolygon<TPrimitive, TVector> polygons:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WriteMultiPolygon(writer, polygons);
                    break;
                case IReadOnlyCollection<TVector> points:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WriteMultiPoint(writer, points);
                    break;
                case IReadOnlyCollection<Path<TPrimitive, TVector>> paths:
                    Utf8JsonWriterHelper<TPrimitive, TVector>.WriteMultiLineString(writer, paths);
                    break;

            }
        }
    }
}
