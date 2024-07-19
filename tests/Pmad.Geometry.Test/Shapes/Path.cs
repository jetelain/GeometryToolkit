using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Shapes
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
	public partial class Path2ISTest : PathTestBase<int,Vector2IS>
	{
        protected override int Integer(int v) => (int)v;

        protected override Vector2IS Vector(int x, int y) => new ((int)x, (int)y);


	}
	public partial class Path2FSTest : PathTestBase<float,Vector2FS>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FS Vector(int x, int y) => new ((float)x, (float)y);

		protected override IReadOnlyList<Vector2FS> Truncate(ReadOnlyArray<Vector2FS> array)
        {
            return array.Select(p => new Vector2FS((int)p.X, (int)p.Y)).ToList();
        }

	}
	public partial class Path2LSTest : PathTestBase<long,Vector2LS>
	{
        protected override int Integer(long v) => (int)v;

        protected override Vector2LS Vector(int x, int y) => new ((long)x, (long)y);


	}
	public partial class Path2DSTest : PathTestBase<double,Vector2DS>
	{
        protected override int Integer(double v) => (int)v;

        protected override Vector2DS Vector(int x, int y) => new ((double)x, (double)y);

		protected override IReadOnlyList<Vector2DS> Truncate(ReadOnlyArray<Vector2DS> array)
        {
            return array.Select(p => new Vector2DS((int)p.X, (int)p.Y)).ToList();
        }

	}
	public partial class Path2FNTest : PathTestBase<float,Vector2FN>
	{
        protected override int Integer(float v) => (int)v;

        protected override Vector2FN Vector(int x, int y) => new ((float)x, (float)y);

		protected override IReadOnlyList<Vector2FN> Truncate(ReadOnlyArray<Vector2FN> array)
        {
            return array.Select(p => new Vector2FN((int)p.X, (int)p.Y)).ToList();
        }

	}
}
