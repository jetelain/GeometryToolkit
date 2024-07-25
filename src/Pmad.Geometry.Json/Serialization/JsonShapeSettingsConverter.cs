using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonShapeSettingsConverter<TPrimitive, TVector> : JsonConverter<ShapeSettings<TPrimitive, TVector>>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public static ShapeSettings<TPrimitive, TVector> GetShapeSettings(JsonSerializerOptions options)
        {
            return options.Converters.OfType<JsonShapeSettingsConverter<TPrimitive, TVector>>().FirstOrDefault()?.Value ?? ShapeSettings<TPrimitive, TVector>.Default;
        }

        public JsonShapeSettingsConverter()
            : this(ShapeSettings<TPrimitive, TVector>.Default)
        {
        }

        public JsonShapeSettingsConverter(ShapeSettings<TPrimitive, TVector> value) 
        { 
            Value = value;
        }

        public ShapeSettings<TPrimitive, TVector> Value { get; }

        public override ShapeSettings<TPrimitive, TVector>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Skip();
            return Value;
        }

        public override void Write(Utf8JsonWriter writer, ShapeSettings<TPrimitive, TVector> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
