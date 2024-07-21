
namespace Pmad.Geometry.Test.Shapes.PathSegments
{
	public partial class PathSegment2ITest : PathSegmentTestBase<int,Vector2I>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);
	}
	public partial class PathSegment2FTest : PathSegmentTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class PathSegment2LTest : PathSegmentTestBase<long,Vector2L>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);
	}
	public partial class PathSegment2DTest : PathSegmentTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
	}
	public partial class PathSegment2ISTest : PathSegmentTestBase<int,Vector2IS>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2IS Vector(int x, int y) => new ((int)x, (int)y);
	}
	public partial class PathSegment2FSTest : PathSegmentTestBase<float,Vector2FS>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FS Vector(int x, int y) => new ((float)x, (float)y);
	}
	public partial class PathSegment2LSTest : PathSegmentTestBase<long,Vector2LS>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2LS Vector(int x, int y) => new ((long)x, (long)y);
	}
	public partial class PathSegment2DSTest : PathSegmentTestBase<double,Vector2DS>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2DS Vector(int x, int y) => new ((double)x, (double)y);
	}
}
