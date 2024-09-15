
namespace Pmad.Geometry.Test.Shapes.MultiPolygons
{
	public partial class MultiPolygon2ITest : MultiPolygonTestBase<int,Vector2I>
	{
	}
	public partial class MultiPolygon2FTest : MultiPolygonTestBase<float,Vector2F>
	{
		protected override Vector2F Truncate(Vector2F p)
        {
            return new Vector2F((int)p.X, (int)p.Y);
        }
	}
	public partial class MultiPolygon2LTest : MultiPolygonTestBase<long,Vector2L>
	{
	}
	public partial class MultiPolygon2DTest : MultiPolygonTestBase<double,Vector2D>
	{
		protected override Vector2D Truncate(Vector2D p)
        {
            return new Vector2D((int)p.X, (int)p.Y);
        }
	}
}