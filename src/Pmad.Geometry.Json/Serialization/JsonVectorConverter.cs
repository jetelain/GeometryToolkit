using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pmad.Geometry.Json.Serialization
{
    public sealed class JsonVectorConverter<TPrimitive, TVector> : JsonConverter<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public override TVector Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Utf8JsonReaderHelper<TPrimitive, TVector>.ReadVector(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, TVector value, JsonSerializerOptions options)
        {
            Utf8JsonWriterHelper<TPrimitive, TVector>.WritePoint(writer, value);
        }
    }
}
