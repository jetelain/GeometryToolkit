using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonRotatedRectangleConverter<TPrimitive, TVector> : JsonConverter<RotatedRectangle<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive,TVector>
    {
        public override RotatedRectangle<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            var settings = JsonShapeSettingsConverter<TPrimitive, TVector>.GetShapeSettings(options);
            TVector center = default;
            TVector size = default;
            double radians = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return new RotatedRectangle<TPrimitive, TVector>(settings, center, size, radians);
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
                        case "size":
                            size = Utf8JsonReaderHelper<TPrimitive, TVector>.ReadVector(ref reader);
                            break;
                        case "radians":
                            radians = reader.GetDouble();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, RotatedRectangle<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("center");
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePoint(writer, value.Center);
            writer.WritePropertyName("size");
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePoint(writer, value.Size);
            writer.WriteNumber("radians", value.Radians);
            writer.WriteEndObject();
        }
    }
}
