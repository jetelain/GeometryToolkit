using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonMultiPathConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonMultiPathConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize( new MultiPath<double, Vector2D>(new (new(10, 20), new(30, 40), new(60, 40)), new (new(210, 220), new(230, 240), new(260, 240))), options);
            Assert.Equal(@"[[[10,20],[30,40],[60,40]],[[210,220],[230,240],[260,240]]]", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<MultiPath<double, Vector2D>>(@"[[[10,20],[30,40],[60,40]],[[210,220],[230,240],[260,240]]]", options);
            Assert.NotNull(result);
            Assert.Equal("MULTILINESTRING ((10 20, 30 40, 60 40), (210 220, 230 240, 260 240))", result.ToString());
        }



    }
}