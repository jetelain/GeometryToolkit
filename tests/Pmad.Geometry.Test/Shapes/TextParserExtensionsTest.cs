using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public class TextParserExtensionsTest
    {
        [Theory]
        [InlineData("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParsePolygon(string wkt)
        {
            Assert.Equal(wkt, DefaultShapes.Vector2I.ParsePolygon(wkt).ToString());
        }

        [Theory]
        [InlineData("POLYGONSET ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParsePolygonSet(string wkt)
        {
            Assert.Equal(wkt, DefaultShapes.Vector2I.ParsePolygonSet(wkt).ToString());
        }

        [Theory]
        [InlineData("MULTIPOLYGON (((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75)))")]
        public void ParseMultiPolygon(string wkt)
        {
            Assert.Equal(wkt, DefaultShapes.Vector2I.ParseMultiPolygon(wkt).ToString());
        }

        [Theory]
        [InlineData("MULTILINESTRING ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParseMultiPath(string wkt)
        {
            Assert.Equal(wkt, DefaultShapes.Vector2I.ParseMultiPath(wkt).ToString());
        }

        [Theory]
        [InlineData("LINESTRING (100 100, 0 100, 0 0, 100 0, 100 100)")]
        public void ParsePath(string wkt)
        {
            Assert.Equal(wkt, DefaultShapes.Vector2I.ParsePath(wkt).ToString());
        }
    }
}
