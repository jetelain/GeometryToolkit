using System.Numerics;
using System.Text.Json.Serialization;

namespace Pmad.Geometry.Json
{
    public class GeoJsonFeatureCollection<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {

        [JsonConstructor]
        public GeoJsonFeatureCollection(GeoJsonType type, List<GeoJsonFeature<TPrimitive, TVector>> features)
        {
            Features = features;
        }

        public GeoJsonFeatureCollection(List<GeoJsonFeature<TPrimitive, TVector>> features)
        {
            Features = features;
        }

        public GeoJsonFeatureCollection(params GeoJsonFeature<TPrimitive, TVector>[] features)
        {
            Features = features.ToList();
        }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<GeoJsonType>))]
        public GeoJsonType Type => GeoJsonType.FeatureCollection;

        [JsonPropertyName("features")]
        public List<GeoJsonFeature<TPrimitive, TVector>> Features { get; }
    }
}
