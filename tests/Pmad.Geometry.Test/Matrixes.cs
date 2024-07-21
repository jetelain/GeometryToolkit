
namespace Pmad.Geometry.Test
{
	public sealed partial class Matrix2x2FTest : Matrix2x2TestBase<float,Vector2F,Matrix2x2F>
	{
		protected override Matrix2x2F Rotation(double radians) => Matrix2x2F.CreateRotation((float)radians);

		protected override Matrix2x2F Create(double m11, double m12, double m21, double m22) => new (new((float)m11,(float)m12),new((float)m21,(float)m22));

        protected override double Double(float v) => (double)v;

        protected override Vector2F Vector(double x, double y) => new ((float)x, (float)y);
	}

	public sealed partial class Matrix2x2FGenTest : Matrix2x2TestBase<float,Vector2F,Matrix2x2<float,Vector2F>>
	{
		protected override Matrix2x2<float,Vector2F> Rotation(double radians) => Matrix2x2<float,Vector2F>.CreateRotation((float)radians);

		protected override Matrix2x2<float,Vector2F> Create(double m11, double m12, double m21, double m22) => new (new((float)m11,(float)m12),new((float)m21,(float)m22));

		protected override double Double(float v) => (double)v;

        protected override Vector2F Vector(double x, double y) => new ((float)x, (float)y);
	}
	public sealed partial class Matrix2x2DTest : Matrix2x2TestBase<double,Vector2D,Matrix2x2D>
	{
		protected override Matrix2x2D Rotation(double radians) => Matrix2x2D.CreateRotation((double)radians);

		protected override Matrix2x2D Create(double m11, double m12, double m21, double m22) => new (new((double)m11,(double)m12),new((double)m21,(double)m22));

        protected override double Double(double v) => (double)v;

        protected override Vector2D Vector(double x, double y) => new ((double)x, (double)y);
	}

	public sealed partial class Matrix2x2DGenTest : Matrix2x2TestBase<double,Vector2D,Matrix2x2<double,Vector2D>>
	{
		protected override Matrix2x2<double,Vector2D> Rotation(double radians) => Matrix2x2<double,Vector2D>.CreateRotation((double)radians);

		protected override Matrix2x2<double,Vector2D> Create(double m11, double m12, double m21, double m22) => new (new((double)m11,(double)m12),new((double)m21,(double)m22));

		protected override double Double(double v) => (double)v;

        protected override Vector2D Vector(double x, double y) => new ((double)x, (double)y);
	}
	public sealed partial class Matrix2x2FSTest : Matrix2x2TestBase<float,Vector2FS,Matrix2x2FS>
	{
		protected override Matrix2x2FS Rotation(double radians) => Matrix2x2FS.CreateRotation((float)radians);

		protected override Matrix2x2FS Create(double m11, double m12, double m21, double m22) => new (new((float)m11,(float)m12),new((float)m21,(float)m22));

        protected override double Double(float v) => (double)v;

        protected override Vector2FS Vector(double x, double y) => new ((float)x, (float)y);
	}

	public sealed partial class Matrix2x2FSGenTest : Matrix2x2TestBase<float,Vector2FS,Matrix2x2<float,Vector2FS>>
	{
		protected override Matrix2x2<float,Vector2FS> Rotation(double radians) => Matrix2x2<float,Vector2FS>.CreateRotation((float)radians);

		protected override Matrix2x2<float,Vector2FS> Create(double m11, double m12, double m21, double m22) => new (new((float)m11,(float)m12),new((float)m21,(float)m22));

		protected override double Double(float v) => (double)v;

        protected override Vector2FS Vector(double x, double y) => new ((float)x, (float)y);
	}
	public sealed partial class Matrix2x2DSTest : Matrix2x2TestBase<double,Vector2DS,Matrix2x2DS>
	{
		protected override Matrix2x2DS Rotation(double radians) => Matrix2x2DS.CreateRotation((double)radians);

		protected override Matrix2x2DS Create(double m11, double m12, double m21, double m22) => new (new((double)m11,(double)m12),new((double)m21,(double)m22));

        protected override double Double(double v) => (double)v;

        protected override Vector2DS Vector(double x, double y) => new ((double)x, (double)y);
	}

	public sealed partial class Matrix2x2DSGenTest : Matrix2x2TestBase<double,Vector2DS,Matrix2x2<double,Vector2DS>>
	{
		protected override Matrix2x2<double,Vector2DS> Rotation(double radians) => Matrix2x2<double,Vector2DS>.CreateRotation((double)radians);

		protected override Matrix2x2<double,Vector2DS> Create(double m11, double m12, double m21, double m22) => new (new((double)m11,(double)m12),new((double)m21,(double)m22));

		protected override double Double(double v) => (double)v;

        protected override Vector2DS Vector(double x, double y) => new ((double)x, (double)y);
	}
}
