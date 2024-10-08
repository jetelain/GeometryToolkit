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
    }
}
