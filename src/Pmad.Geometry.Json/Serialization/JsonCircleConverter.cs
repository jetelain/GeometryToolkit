using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonCircleConverter<TPrimitive, TVector> : JsonConverter<Circle<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive,TVector>
    {
        public override Circle<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            TVector center = default;
            double radius = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return new Circle<TPrimitive, TVector>(settings, center, radius);
                }
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "center":
                            center = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadVector(ref reader);
                            break;
                        case "radius":
                            radius = reader.GetDouble();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Circle<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("center");
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePoint(writer, value.Center);
            writer.WriteNumber("radius", value.Radius);
            writer.WriteEndObject();
        }
    }
}
