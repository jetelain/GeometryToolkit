using System.Numerics;
using System.Text.Json.Serialization;

namespace Pmad.Geometry.Json
{
    public class GeoJsonFeature<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [JsonConstructor]
        public GeoJsonFeature(GeoJsonType type, GeoJsonGeometry<TPrimitive, TVector>? geometry, Dictionary<string, object>? properties)
        {
            Geometry = geometry;
            Properties = properties;
        }

        public GeoJsonFeature(GeoJsonGeometry<TPrimitive, TVector>? geometry, Dictionary<string, object>? properties = null)
        {
            Geometry = geometry;
            Properties = properties;
        }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<GeoJsonType>))]
        public GeoJsonType Type => GeoJsonType.Feature;

        [JsonPropertyName("geometry")]
        public GeoJsonGeometry<TPrimitive, TVector>? Geometry { get; }

        [JsonPropertyName("properties")]
        public Dictionary<string, object>? Properties { get; }
    }
}
