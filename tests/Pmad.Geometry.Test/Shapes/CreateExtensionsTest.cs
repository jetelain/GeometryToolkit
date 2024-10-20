using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public class CreateExtensionsTest
    {
        [Fact]
        public void CreateCirclePolygon()
        {
            Assert.Equal("POLYGON ((20 10, 10 20, 0 10, 10 0, 20 10))", DefaultShapes.Vector2I.CreateCirclePolygon(new Vector2I(10, 10), 10, 4).ToString());
            Assert.Equal("POLYGON ((20 10, 17 17, 10 20, 3 17, 0 10, 3 3, 10 0, 17 3, 20 10))", DefaultShapes.Vector2I.CreateCirclePolygon(new Vector2I(10, 10), 10, 8).ToString());
        }
    }
}
