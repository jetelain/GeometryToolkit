using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public class TextParserTest
    {

        [Fact]
        public void ReadVectorList()
        {
            var test = (ReadOnlySpan<char>)"(12 34, 56 78)";

            var result = TextParser<int,Vector2I>.ReadVectorList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([new Vector2I(12, 34), new Vector2I(56, 78)], result);


            test = (ReadOnlySpan<char>)"(12 34)";

            result = TextParser<int, Vector2I>.ReadVectorList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([new Vector2I(12, 34)], result);

            test = (ReadOnlySpan<char>)"()";

            result = TextParser<int, Vector2I>.ReadVectorList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([], result); 
            
            test = (ReadOnlySpan<char>)"EMPTY";

            result = TextParser<int, Vector2I>.ReadVectorList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([], result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("(")]
        [InlineData("(12")]
        [InlineData("(12)")]
        [InlineData("(12 34")]
        [InlineData("(12 34 ")]
        [InlineData("(12 34, ")]
        public void ReadVectorList_Invalid(string value)
        {
            Assert.Throws<FormatException>(() =>
            {
                var test = (ReadOnlySpan<char>)value;
                TextParser<int, Vector2I>.ReadVectorList(ref test);
            });
        }

        [Fact]
        public void ReadVectorListList()
        {
            var test = (ReadOnlySpan<char>)"((12 34, 56 78), (98 76))";

            var result = TextParser<int, Vector2I>.ReadVectorListList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([new (new Vector2I(12, 34), new Vector2I(56, 78)), new(new Vector2I(98, 76))], result);

            test = (ReadOnlySpan<char>)"((12 34))";

            result = TextParser<int, Vector2I>.ReadVectorListList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([new(new Vector2I(12, 34))], result);

            test = (ReadOnlySpan<char>)"()";

            result = TextParser<int, Vector2I>.ReadVectorListList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([], result);

            test = (ReadOnlySpan<char>)"EMPTY";

            result = TextParser<int, Vector2I>.ReadVectorListList(ref test);

            Assert.Equal(0, test.Length);
            Assert.Equal([], result);
        }

        [Theory]
        [InlineData("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParsePolygon(string wkt)
        {
            Assert.Equal(wkt, TextParser<int, Vector2I>.ParsePolygon(ShapeSettings<int,Vector2I>.Default, wkt).ToString());
        }

        [Theory]
        [InlineData("POLYGONSET ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParsePolygonSet(string wkt)
        {
            Assert.Equal(wkt, TextParser<int, Vector2I>.ParsePolygonSet(ShapeSettings<int, Vector2I>.Default, wkt).ToString());
        }

        [Theory]
        [InlineData("MULTIPOLYGON (((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75)))")]
        public void ParseMultiPolygon(string wkt)
        {
            Assert.Equal(wkt, TextParser<int, Vector2I>.ParseMultiPolygon(ShapeSettings<int, Vector2I>.Default, wkt).ToString());
        }

        [Theory]
        [InlineData("MULTILINESTRING ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))")]
        public void ParseMultiPath(string wkt)
        {
            Assert.Equal(wkt, TextParser<int, Vector2I>.ParseMultiPath(ShapeSettings<int, Vector2I>.Default, wkt).ToString());
        }

        [Theory]
        [InlineData("LINESTRING (100 100, 0 100, 0 0, 100 0, 100 100)")]
        public void ParsePath(string wkt)
        {
            Assert.Equal(wkt, TextParser<int, Vector2I>.ParsePath(ShapeSettings<int, Vector2I>.Default, wkt).ToString());
        }
    }
}
