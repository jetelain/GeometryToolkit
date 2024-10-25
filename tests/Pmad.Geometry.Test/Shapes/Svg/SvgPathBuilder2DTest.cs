using Pmad.Geometry.Shapes;
using Pmad.Geometry.Shapes.Svg;

namespace Pmad.Geometry.Test.Shapes.Svg
{
    public partial class SvgPathBuilder2DTest
    {
        [Fact]
        public void AppendScalar_DefaultPrecision_SlowPath()
        {
            using var builder = new SvgPathBuilder<double, Vector2D>(ShapeSettings<double, Vector2D>.Default);

            builder.AppendScalar(12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.0);
            Assert.Equal("12345678901234600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", builder.ToString());
        }

        [Fact]
        public void AppendScalar_IntegerPrecision_SlowPath()
        {
            using var builder = new SvgPathBuilder<double, Vector2D>(new ShapeSettings<double, Vector2D>(1, 3));

            builder.AppendScalar(12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.0);
            Assert.Equal("12345678901234600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", builder.ToString());
        }
    }
}
