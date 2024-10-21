using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonPolygonConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonPolygonConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(10, 10), new(20, 20)), options);
            Assert.Equal(@"[[[10,10],[10,20],[20,20],[20,10],[10,10]]]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<Polygon<double, Vector2D>>(@"[[[10,10],[10,20],[20,20],[20,10],[10,10]]]", options);
            Assert.NotNull(result);
            Assert.Equal("POLYGON ((10 10, 10 20, 20 20, 20 10, 10 10))", result.ToString());

            result = JsonSerializer.Deserialize<Polygon<double, Vector2D>>(@"[[[10,10],[10,20],[20,20],[20,10],[10,10]],[[4,4],[4,6],[5,5],[4,4]]]", options);
            Assert.NotNull(result);
            Assert.Equal("POLYGON ((10 10, 10 20, 20 20, 20 10, 10 10), (4 4, 4 6, 5 5, 4 4))", result.ToString());
        }



    }
}