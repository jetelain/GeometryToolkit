
namespace Pmad.Geometry.Test.Shapes.RotatedRectangles
{
	public partial class RotatedRectangle2FTest : RotatedRectangleTestBase<float,Vector2F>
	{
        protected override double Double(float v) => (double)v;

        protected override Vector2F Vector(double x, double y) => new ((float)x, (float)y);
	}
	public partial class RotatedRectangle2DTest : RotatedRectangleTestBase<double,Vector2D>
	{
        protected override double Double(double v) => (double)v;

        protected override Vector2D Vector(double x, double y) => new ((double)x, (double)y);
	}
}
