using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonPathConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonPathConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(new Path<double, Vector2D>(new(10, 20), new(30, 40), new(60, 40)), options);
            Assert.Equal(@"[[10,20],[30,40],[60,40]]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<Path<double, Vector2D>>(@"[[10,20],[30,40],[60,40]]", options);
            Assert.NotNull(result);
            Assert.Equal("LINESTRING (10 20, 30 40, 60 40)", result.ToString());
        }



    }
}