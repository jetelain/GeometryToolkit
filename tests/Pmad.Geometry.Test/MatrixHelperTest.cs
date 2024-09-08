namespace Pmad.Geometry.Test
{
    public class MatrixHelperTest
    {
        private const double RotationHalfEpsilonD = 0.0005d * Math.PI / 180d;
        private const float  RotationHalfEpsilonF = 0.0005f * MathF.PI / 180f;

        [Fact]
        public void SinCosDouble()
        {
            Assert.Equal((0, 1), MatrixHelper.SinCos(0.0));
            Assert.Equal((0, 1), MatrixHelper.SinCos(-RotationHalfEpsilonD));
            Assert.Equal((0, 1), MatrixHelper.SinCos(+RotationHalfEpsilonD));

            Assert.Equal((1, 0), MatrixHelper.SinCos(Math.PI / 2));
            Assert.Equal((1, 0), MatrixHelper.SinCos(Math.PI / 2 + RotationHalfEpsilonD));
            Assert.Equal((1, 0), MatrixHelper.SinCos(Math.PI / 2 - RotationHalfEpsilonD));
            Assert.Equal((1, 0), MatrixHelper.SinCos(-Math.PI * 3 / 2));
            Assert.Equal((1, 0), MatrixHelper.SinCos(Math.PI * 5 / 2));

            Assert.Equal((0, -1), MatrixHelper.SinCos(Math.PI));
            Assert.Equal((0, -1), MatrixHelper.SinCos(Math.PI + RotationHalfEpsilonD));
            Assert.Equal((0, -1), MatrixHelper.SinCos(Math.PI - RotationHalfEpsilonD));

            Assert.Equal((-1, 0), MatrixHelper.SinCos(-Math.PI / 2));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-Math.PI / 2 + RotationHalfEpsilonD));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-Math.PI / 2 - RotationHalfEpsilonD));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(Math.PI * 3 / 2));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-Math.PI * 5 / 2));

            Assert.Equal((0, -1), MatrixHelper.SinCos(-Math.PI));
            Assert.Equal((0, -1), MatrixHelper.SinCos(-Math.PI + RotationHalfEpsilonD));
            Assert.Equal((0, -1), MatrixHelper.SinCos(-Math.PI - RotationHalfEpsilonD));

            (var sin, var cos) = MatrixHelper.SinCos(1d);
            Assert.Equal(0.8414, sin, 0.0001);
            Assert.Equal(0.5403, cos, 0.0001);
        }

        [Fact]
        public void SinCosFloat()
        {
            Assert.Equal((0, 1), MatrixHelper.SinCos(0f));
            Assert.Equal((0, 1), MatrixHelper.SinCos(-RotationHalfEpsilonF));
            Assert.Equal((0, 1), MatrixHelper.SinCos(+RotationHalfEpsilonF));

            Assert.Equal((1, 0), MatrixHelper.SinCos(MathF.PI / 2));
            Assert.Equal((1, 0), MatrixHelper.SinCos(MathF.PI / 2 + RotationHalfEpsilonF));
            Assert.Equal((1, 0), MatrixHelper.SinCos(MathF.PI / 2 - RotationHalfEpsilonF));
            Assert.Equal((1, 0), MatrixHelper.SinCos(-MathF.PI * 3 / 2));
            Assert.Equal((1, 0), MatrixHelper.SinCos(MathF.PI * 5 / 2));

            Assert.Equal((0, -1), MatrixHelper.SinCos(MathF.PI));
            Assert.Equal((0, -1), MatrixHelper.SinCos(MathF.PI + RotationHalfEpsilonF));
            Assert.Equal((0, -1), MatrixHelper.SinCos(MathF.PI - RotationHalfEpsilonF));

            Assert.Equal((-1, 0), MatrixHelper.SinCos(-MathF.PI / 2));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-MathF.PI / 2 + RotationHalfEpsilonF));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-MathF.PI / 2 - RotationHalfEpsilonF));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(MathF.PI * 3 / 2));
            Assert.Equal((-1, 0), MatrixHelper.SinCos(-MathF.PI * 5 / 2));

            Assert.Equal((0, -1), MatrixHelper.SinCos(-MathF.PI));
            Assert.Equal((0, -1), MatrixHelper.SinCos(-MathF.PI + RotationHalfEpsilonF));
            Assert.Equal((0, -1), MatrixHelper.SinCos(-MathF.PI - RotationHalfEpsilonF));

            (var sin, var cos) = MatrixHelper.SinCos(1f);
            Assert.Equal(0.8414, sin, 0.0001);
            Assert.Equal(0.5403, cos, 0.0001);
        }
    }
}
