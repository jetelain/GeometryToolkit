using System.Numerics;
using System.Text.Json.Serialization;
using Pmad.Geometry.Json.Serialization;

namespace Pmad.Geometry.Json
{
    public class GeoJsonUnknown<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<GeoJsonType>))]
        public GeoJsonType? Type { get; set; }

        [JsonPropertyName("coordinates")]
        [JsonGeometryConverter]
        public Coordinates<TPrimitive, TVector>? Coordinates { get; set; }

        [JsonPropertyName("geometry")]
        public GeoJsonGeometry<TPrimitive, TVector>? Geometry { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, object>? Properties { get; set; }

        [JsonPropertyName("features")]
        public List<GeoJsonFeature<TPrimitive, TVector>>? Features { get; set; }

        public GeoJsonGeometry<TPrimitive, TVector> ToGeometry()
        {
            if (Type == null || Type.Value >= GeoJsonType.Feature || Coordinates == null)
            {
                throw new Exception();
            }
            return new GeoJsonGeometry<TPrimitive, TVector>((GeoJsonGeometryType)Type.Value, Coordinates.Value);
        }

        public GeoJsonFeature<TPrimitive, TVector> ToFeature()
        {
            if (Type == null || Type.Value != GeoJsonType.Feature)
            {
                throw new Exception();
            }
            return new GeoJsonFeature<TPrimitive, TVector>(GeoJsonType.Feature, Geometry, Properties);
        }

        public GeoJsonFeatureCollection<TPrimitive, TVector> ToFeatureCollection()
        {
            if (Type == null || Type.Value != GeoJsonType.FeatureCollection || Features == null)
            {
                throw new Exception();
            }
            return new GeoJsonFeatureCollection<TPrimitive, TVector>(GeoJsonType.FeatureCollection, Features);
        }
    }
}
