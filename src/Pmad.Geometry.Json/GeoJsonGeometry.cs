using System.Numerics;
using System.Text.Json.Serialization;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json
{
    public class GeoJsonGeometry<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [JsonConstructor]
        public GeoJsonGeometry(GeoJsonGeometryType type, Coordinates<TPrimitive, TVector> coordinates) 
        {
            Type = type;
            Coordinates = coordinates;
        }

        public GeoJsonGeometry(TVector coordinates)
        {
            Type = GeoJsonGeometryType.Point;
            Coordinates = new(coordinates);
        }

        public GeoJsonGeometry(Path<TPrimitive, TVector> coordinates)
        {
            Type = GeoJsonGeometryType.LineString;
            Coordinates = new(coordinates);
        }

        public GeoJsonGeometry(Polygon<TPrimitive, TVector> coordinates)
        {
            Type = GeoJsonGeometryType.Polygon;
            Coordinates = new (coordinates);
        }

        public GeoJsonGeometry(IReadOnlyCollection<TVector> coordinates)
        {
            Type = GeoJsonGeometryType.MultiPoint;
            Coordinates = new(coordinates);
        }

        public GeoJsonGeometry(IReadOnlyCollection<Path<TPrimitive, TVector>> coordinates)
        {
            Type = GeoJsonGeometryType.MultiLineString;
            Coordinates = new(coordinates);
        }

        public GeoJsonGeometry(MultiPolygon<TPrimitive, TVector> coordinates)
        {
            Type = GeoJsonGeometryType.MultiPolygon;
            Coordinates = new(coordinates);
        }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter<GeoJsonGeometryType>))]
        public GeoJsonGeometryType Type { get; }

        [JsonPropertyName("coordinates")]
        [JsonGeometryConverter]
        public Coordinates<TPrimitive, TVector> Coordinates { get; }

        public  GeoJsonFeature<TPrimitive, TVector> ToFeature(Dictionary<string, object>? properties = null)
        {
            return new GeoJsonFeature<TPrimitive, TVector>(this, properties);
        }
    }
}
