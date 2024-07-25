using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonPolygonConverter<TPrimitive, TVector> : JsonConverter<Polygon<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override Polygon<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadCoordinatesData(ref reader);
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            return data.AsPolygon(settings);
        }

        public override void Write(Utf8JsonWriter writer, Polygon<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePolygon(writer, value);
        }
    }
}
