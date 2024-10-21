using System.Text.Json;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test
{
    public class GeoJsonGeometryTest
    {
        [Fact]
        public void Serialize_LineString()
        {
            var result = JsonSerializer.Serialize(new Path<double, Vector2D>(new(10, 20), new(30, 40), new(60, 40)).ToGeoJson());
            Assert.Equal(@"{""type"":""LineString"",""coordinates"":[[10,20],[30,40],[60,40]]}", result);
        }

        [Fact]
        public void Serialize_MultiLineString()
        {
            var result = JsonSerializer.Serialize(new MultiPath<double, Vector2D>(new Path<double, Vector2D>(new(10, 20), new(30, 40), new(60, 40)), new Path<double, Vector2D>(new(210, 220), new(230, 240), new(260, 240)) ).ToGeoJson());
            Assert.Equal(@"{""type"":""MultiLineString"",""coordinates"":[[[10,20],[30,40],[60,40]],[[210,220],[230,240],[260,240]]]}", result);
        }

        [Fact]
        public void Serialize_Polygon()
        {
            var result = JsonSerializer.Serialize(ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(10, 10), new(20, 20)).ToGeoJson());
            Assert.Equal(@"{""type"":""Polygon"",""coordinates"":[[[10,10],[10,20],[20,20],[20,10],[10,10]]]}", result);
        }

        [Fact]
        public void Serialize_MultiPolygon()
        {
            var result = JsonSerializer.Serialize(
                new MultiPolygon<double, Vector2D>(
                    ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(10, 10), new(20, 20)),
                    ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(30, 30), new(40, 40))).ToGeoJson());

            Assert.Equal(@"{""type"":""MultiPolygon"",""coordinates"":[[[[10,10],[10,20],[20,20],[20,10],[10,10]]],[[[30,30],[30,40],[40,40],[40,30],[30,30]]]]}", result);
        }

        [Fact]
        public void Deserialize_LineString()
        {
            var result = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(@"{""type"":""LineString"",""coordinates"":[[10,20],[30,40],[60,40]]}");
            Assert.NotNull(result);
            Assert.Equal("LINESTRING (10 20, 30 40, 60 40)", result.Coordinates.AsLineString()?.ToString());
        }

        [Fact]
        public void Deserialize_Polygon()
        {
            var result = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(@"{""type"":""Polygon"",""coordinates"":[[[10,10],[10,20],[20,20],[20,10],[10,10]],[[4,4],[4,6],[5,5],[4,4]]]}");
            Assert.NotNull(result);
            Assert.Equal("POLYGON ((10 10, 10 20, 20 20, 20 10, 10 10), (4 4, 4 6, 5 5, 4 4))", result.Coordinates.AsPolygon()?.ToString());
        }

        [Fact]
        public void Deserialize_MultiPolygon()
        {
            var result = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(@"{""type"":""MultiPolygon"",""coordinates"":[[[[10,10],[10,20],[20,20],[20,10],[10,10]]],[[[30,30],[30,40],[40,40],[40,30],[30,30]]]]}");
            Assert.NotNull(result);
            Assert.Equal("MULTIPOLYGON (((10 10, 10 20, 20 20, 20 10, 10 10)), ((30 30, 30 40, 40 40, 40 30, 30 30)))", result.Coordinates.AsMultiPolygon()?.ToString());
        }

        [Fact]
        public void Deserialize_MultiLineString()
        {
            var result = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(@"{""type"":""MultiLineString"",""coordinates"":[[[10,20],[30,40],[60,40]],[[210,220],[230,240],[260,240]]]}");
            Assert.NotNull(result);
            var lines = result.Coordinates.AsMultiLineString();
            Assert.NotNull(lines);
            Assert.Equal("MULTILINESTRING ((10 20, 30 40, 60 40), (210 220, 230 240, 260 240))", lines.ToString());
            Assert.Equal(2, lines.Count);
            Assert.Equal("LINESTRING (10 20, 30 40, 60 40)", lines[0].ToString());
            Assert.Equal("LINESTRING (210 220, 230 240, 260 240)", lines[1].ToString());
        }

    }
}
