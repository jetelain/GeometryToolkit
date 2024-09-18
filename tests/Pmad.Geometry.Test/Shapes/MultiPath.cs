using Pmad.Geometry.Collections;


namespace Pmad.Geometry.Test.Shapes.MultiPaths
{
	public partial class MultiPath2ITest : MultiPathTestBase<int,Vector2I>
	{
	}
	public partial class MultiPath2FTest : MultiPathTestBase<float,Vector2F>
	{
		protected override IReadOnlyList<Vector2F> Truncate(ReadOnlyArray<Vector2F> array)
        {
            return array.Select(p => new Vector2F((int)p.X, (int)p.Y)).ToList();
        }
	}
	public partial class MultiPath2LTest : MultiPathTestBase<long,Vector2L>
	{
	}
	public partial class MultiPath2DTest : MultiPathTestBase<double,Vector2D>
	{
		protected override IReadOnlyList<Vector2D> Truncate(ReadOnlyArray<Vector2D> array)
        {
            return array.Select(p => new Vector2D((int)p.X, (int)p.Y)).ToList();
        }
	}
}