
namespace Pmad.Geometry.Test
{
	public partial class VectorEnvelope2ITest : VectorEnvelopeTestBase<int,Vector2I>
	{
        protected override int Scalar(int v) => v;

        protected override Vector2I Vector(int x, int y) => new (x, y);
	}
	public partial class VectorEnvelope2FTest : VectorEnvelopeTestBase<float,Vector2F>
	{
        protected override float Scalar(int v) => v;

        protected override Vector2F Vector(int x, int y) => new (x, y);
	}
	public partial class VectorEnvelope2LTest : VectorEnvelopeTestBase<long,Vector2L>
	{
        protected override long Scalar(int v) => v;

        protected override Vector2L Vector(int x, int y) => new (x, y);
	}
	public partial class VectorEnvelope2DTest : VectorEnvelopeTestBase<double,Vector2D>
	{
        protected override double Scalar(int v) => v;

        protected override Vector2D Vector(int x, int y) => new (x, y);
	}
}
