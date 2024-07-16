
namespace Pmad.Geometry.Test.Shapes
{
	public partial class Polygon2ITest : PolygonTestBase<int,Vector2I>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);
	}
	public partial class Polygon2FTest : PolygonTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class Polygon2LTest : PolygonTestBase<long,Vector2L>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);
	}
	public partial class Polygon2DTest : PolygonTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
	}
	public partial class Polygon2ISTest : PolygonTestBase<int,Vector2IS>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2IS Vector(int x, int y) => new ((int)x, (int)y);
	}
	public partial class Polygon2FSTest : PolygonTestBase<float,Vector2FS>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FS Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class Polygon2LSTest : PolygonTestBase<long,Vector2LS>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2LS Vector(int x, int y) => new ((long)x, (long)y);
	}
	public partial class Polygon2DSTest : PolygonTestBase<double,Vector2DS>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2DS Vector(int x, int y) => new ((double)x, (double)y);
	}
	public partial class Polygon2FNTest : PolygonTestBase<float,Vector2FN>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FN Vector(int x, int y) => new ((float)x, (float)y);
	}
}
