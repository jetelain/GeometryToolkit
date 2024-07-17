
namespace Pmad.Geometry.Test.Algorithms
{
	public partial class PathFollower2FTest : PathFollowerTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class PathFollower2DTest : PathFollowerTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
	}
	public partial class PathFollower2FSTest : PathFollowerTestBase<float,Vector2FS>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FS Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class PathFollower2DSTest : PathFollowerTestBase<double,Vector2DS>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2DS Vector(int x, int y) => new ((double)x, (double)y);
	}
	public partial class PathFollower2FNTest : PathFollowerTestBase<float,Vector2FN>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FN Vector(int x, int y) => new ((float)x, (float)y);
	}
}
