using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Shapes.Paths
{
	public partial class Path2ITest : PathTestBase<int,Vector2I>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);


	}
	public partial class Path2FTest : PathTestBase<float,Vector2F>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);

		protected override IReadOnlyList<Vector2F> Truncate(ReadOnlyArray<Vector2F> array)
        {
            return array.Select(p => new Vector2F((int)p.X, (int)p.Y)).ToList();
        }

	}
	public partial class Path2LTest : PathTestBase<long,Vector2L>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);


	}
	public partial class Path2DTest : PathTestBase<double,Vector2D>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);

		protected override IReadOnlyList<Vector2D> Truncate(ReadOnlyArray<Vector2D> array)
        {
            return array.Select(p => new Vector2D((int)p.X, (int)p.Y)).ToList();
        }

	}
}
