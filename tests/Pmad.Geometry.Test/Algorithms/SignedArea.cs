
namespace Pmad.Geometry.Test.Algorithms.SignedAreas
{
	public partial class SignedArea2ITest : SignedAreaTestBase<int,Vector2I>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);
	}
	public partial class SignedArea2FTest : SignedAreaTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class SignedArea2LTest : SignedAreaTestBase<long,Vector2L>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);
	}
	public partial class SignedArea2DTest : SignedAreaTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
	}
}
