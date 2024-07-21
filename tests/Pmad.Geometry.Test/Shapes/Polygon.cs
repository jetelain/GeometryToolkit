
namespace Pmad.Geometry.Test.Shapes.Polygons
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
		
		protected override Vector2F Truncate(Vector2F p)
        {
            return new Vector2F((int)p.X, (int)p.Y);
        }
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
		
		protected override Vector2D Truncate(Vector2D p)
        {
            return new Vector2D((int)p.X, (int)p.Y);
        }
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
		
		protected override Vector2FS Truncate(Vector2FS p)
        {
            return new Vector2FS((int)p.X, (int)p.Y);
        }
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
		
		protected override Vector2DS Truncate(Vector2DS p)
        {
            return new Vector2DS((int)p.X, (int)p.Y);
        }
	}
}
