using System.Text.Json;
using Pmad.Geometry.Json.Serialization;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonVectorConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonVectorConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(new Vector2D(124,567), options);
            Assert.Equal("[124,567]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<Vector2D>("[124,567]", options);
            Assert.Equal(new Vector2D(124,567), result);

            result = JsonSerializer.Deserialize<Vector2D>("[124,567,897]", options);
            Assert.Equal(new Vector2D(124, 567), result);
        }

        [Fact]
        public void Deserialize_IgnoreExtra()
        {
            var result = JsonSerializer.Deserialize<Vector2D>("[124,567,null,null]", options);
            Assert.Equal(new Vector2D(124, 567), result);

            result = JsonSerializer.Deserialize<Vector2D>("[124,567,[879,578],null]", options);
            Assert.Equal(new Vector2D(124, 567), result);

            result = JsonSerializer.Deserialize<Vector2D>("[124,567,null,[879,578]]", options);
            Assert.Equal(new Vector2D(124, 567), result);
        }

    }
}