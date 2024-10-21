using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonPolygonSetConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonPolygonSetConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(10, 10), new(20, 20)).ToPolygonSet(), options);
            Assert.Equal(@"[[[20,10],[20,20],[10,20],[10,10]]]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<PolygonSet<double, Vector2D>>(@"[[[20,10],[20,20],[10,20],[10,10]]]", options);
            Assert.NotNull(result);
            Assert.Equal("POLYGONSET ((20 10, 20 20, 10 20, 10 10))", result.ToString());

            result = JsonSerializer.Deserialize<PolygonSet<double, Vector2D>>(@"[[[20,10],[20,20],[10,20],[10,10]],[[14,16],[15,15],[14,14]]]", options);
            Assert.NotNull(result);
            Assert.Equal("POLYGONSET ((20 10, 20 20, 10 20, 10 10), (14 16, 15 15, 14 14))", result.ToString());
        }



    }
}