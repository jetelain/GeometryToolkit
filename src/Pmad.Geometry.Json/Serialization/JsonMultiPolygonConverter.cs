using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonMultiPolygonConverter<TPrimitive, TVector> : JsonConverter<MultiPolygon<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override MultiPolygon<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadCoordinatesData(ref reader);
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            return data.AsMultiPolygon(settings) ?? MultiPolygon<TPrimitive, TVector>.Empty;
        }

        public override void Write(Utf8JsonWriter writer, MultiPolygon<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            Utf8JsonWriterHelper<TPrimitive, TVector>.WriteMultiPolygon(writer, value);
        }
    }
}
