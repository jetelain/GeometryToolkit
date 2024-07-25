using System.Text.Json;
using Pmad.Geometry.Json.Serialization;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json.Test.Serialization
{
    public class JsonRotatedRectangleConverterTest
    {
        JsonSerializerOptions options = new JsonSerializerOptions { Converters = { new JsonRotatedRectangleConverter<double, Vector2D>() } };

        [Fact]
        public void Serialize()
        {
            var result = JsonSerializer.Serialize(new RotatedRectangle<double, Vector2D>(new(124,567),new(852,147), Math.PI/2), options);
            Assert.Equal(@"{""center"":[124,567],""size"":[852,147],""radians"":1.5707963267948966}", result);
        }

        [Fact]
        public void Deserialize()
        {
            var result = JsonSerializer.Deserialize<RotatedRectangle<double, Vector2D>>(@"{""center"":[124,567],""size"":[852,147],""radians"":1.5707963267948966}", options);
            Assert.Equal("ROTATEDRECT ((124 567), (852 147), 90 DEG)", result!.ToString());

            result = JsonSerializer.Deserialize<RotatedRectangle<double, Vector2D>>(@"{""radians"":1.5707963267948966,""radius"":963,""dummy1"":{},""center"":[124,567],""dummy2"":1235,""size"":[852,147],""dummy3"":{}}", options);
            Assert.Equal("ROTATEDRECT ((124 567), (852 147), 90 DEG)", result!.ToString());
        }

    }
}