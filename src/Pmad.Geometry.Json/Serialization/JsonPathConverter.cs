using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonPathConverter<TPrimitive, TVector> : JsonConverter<Path<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override Path<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadCoordinatesData(ref reader);
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            return data.AsLineString(settings);
        }

        public override void Write(Utf8JsonWriter writer, Path<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            Utf8JsonWriterHelper<TPrimitive, TVector>.WriteLineString(writer, value.Points.AsSpan());
        }
    }
}
