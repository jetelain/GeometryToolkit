
namespace Pmad.Geometry.Test.Shapes.Settings
{
	public partial class ShapeSettings2ITest : ShapeSettingsTestBase<int,Vector2I>
	{
        protected override Vector2I Vector(int x, int y) => new ((int)x, (int)y);
		protected override int ExpectedScale => 1;
	}
	public partial class ShapeSettings2FTest : ShapeSettingsTestBase<float,Vector2F>
	{
        protected override Vector2F Vector(int x, int y) => new ((float)x, (float)y);
		protected override int ExpectedScale => 1000;
	}
	public partial class ShapeSettings2LTest : ShapeSettingsTestBase<long,Vector2L>
	{
        protected override Vector2L Vector(int x, int y) => new ((long)x, (long)y);
		protected override int ExpectedScale => 1;
	}
	public partial class ShapeSettings2DTest : ShapeSettingsTestBase<double,Vector2D>
	{
        protected override Vector2D Vector(int x, int y) => new ((double)x, (double)y);
		protected override int ExpectedScale => 1000;
	}
	public partial class ShapeSettings2ISTest : ShapeSettingsTestBase<int,Vector2IS>
	{
        protected override Vector2IS Vector(int x, int y) => new ((int)x, (int)y);
		protected override int ExpectedScale => 1;
	}
	public partial class ShapeSettings2FSTest : ShapeSettingsTestBase<float,Vector2FS>
	{
        protected override Vector2FS Vector(int x, int y) => new ((float)x, (float)y);
		protected override int ExpectedScale => 1000;
	}
	public partial class ShapeSettings2LSTest : ShapeSettingsTestBase<long,Vector2LS>
	{
        protected override Vector2LS Vector(int x, int y) => new ((long)x, (long)y);
		protected override int ExpectedScale => 1;
	}
	public partial class ShapeSettings2DSTest : ShapeSettingsTestBase<double,Vector2DS>
	{
        protected override Vector2DS Vector(int x, int y) => new ((double)x, (double)y);
		protected override int ExpectedScale => 1000;
	}
}
