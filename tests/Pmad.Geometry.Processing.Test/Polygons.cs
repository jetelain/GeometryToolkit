
namespace Pmad.Geometry.Processing.Test
{
	public partial class Polygons2ITest : PolygonsTestBase<int,Vector2I>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);
		
	}
	public partial class Polygons2FTest : PolygonsTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
		
		protected override Vector2F Truncate(Vector2F p)
        {
            return new Vector2F((int)p.X, (int)p.Y);
        }
	}
	public partial class Polygons2LTest : PolygonsTestBase<long,Vector2L>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);
		
	}
	public partial class Polygons2DTest : PolygonsTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
		
		protected override Vector2D Truncate(Vector2D p)
        {
            return new Vector2D((int)p.X, (int)p.Y);
        }
	}
}
