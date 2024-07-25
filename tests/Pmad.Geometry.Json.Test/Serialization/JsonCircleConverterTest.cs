using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonCircleConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonCircleConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(new Circle<double, Vector2D>(new(124,567),963), options);
            Assert.Equal(@"{""center"":[124,567],""radius"":963}", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<Circle<double, Vector2D>>(@"{""center"":[124,567],""radius"":963}", options);
            Assert.Equal("CIRCLE ((124 567), 963)", result!.ToString());

            result = JsonSerializer.Deserialize<Circle<double, Vector2D>>(@"{""radius"":963,""dummy1"":{},""center"":[124,567],""dummy2"":1235,""dummy3"":{}}", options);
            Assert.Equal("CIRCLE ((124 567), 963)", result!.ToString());
        }

    }
}