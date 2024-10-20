using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonMultiPolygonConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonMultiPolygonConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(
                new MultiPolygon<double, Vector2D>(
                    ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(10, 10), new(20, 20)),
                    ShapeSettings<double, Vector2D>.Default.CreateRectanglePolygon(new(30, 30), new(40, 40))), options);

            Assert.Equal(@"[[[[10,10],[10,20],[20,20],[20,10],[10,10]]],[[[30,30],[30,40],[40,40],[40,30],[30,30]]]]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<MultiPolygon<double, Vector2D>>(@"[[[[10,10],[10,20],[20,20],[20,10],[10,10]]],[[[30,30],[30,40],[40,40],[40,30],[30,30]]]]", options);
            Assert.NotNull(result);
            Assert.Equal("MULTIPOLYGON (((10 10, 10 20, 20 20, 20 10, 10 10)), ((30 30, 30 40, 40 40, 40 30, 30 30)))", result.ToString());


        }



    }
}