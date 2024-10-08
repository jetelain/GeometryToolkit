using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Clipper2Lib;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonPolygonSetConverter<TPrimitive, TVector> : JsonConverter<PolygonSet<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override PolygonSet<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadCoordinatesData(ref reader);
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            return data.AsPolygonSet(settings) ?? new PolygonSet<TPrimitive, TVector>(new Paths64(), settings);
        }

        public override void Write(Utf8JsonWriter writer, PolygonSet<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePolygonSet(writer, value);
        }
    }
}
