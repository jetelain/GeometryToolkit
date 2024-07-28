using System.Numerics;

namespace Pmad.Geometry.Test
{
    public abstract class Vector2FPTestBase<TPrimitive, TVector> : Vector2TestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        [Fact]
        public void Length()
        {
            Assert.Equal(Scalar(10), Vector(0, 10).Length());
            Assert.Equal(Scalar(10), Vector(10, 0).Length());
            Assert.Equal(Scalar(10), Vector(0, -10).Length());
            Assert.Equal(Scalar(10), Vector(-10, 0).Length());
            Assert.Equal(14.1, double.CreateTruncating(Vector(10, 10).Length()), 1);
            Assert.Equal(14.1, double.CreateTruncating(Vector(-10, -10).Length()), 1);
        }

        [Fact]
        public void LengthSquared()
        {
            Assert.Equal(Scalar(100), Vector(0, 10).LengthSquared());
            Assert.Equal(Scalar(100), Vector(0, -10).LengthSquared());
            Assert.Equal(Scalar(100), Vector(10, 0).LengthSquared());
            Assert.Equal(Scalar(100), Vector(-10, 0).LengthSquared());
            Assert.Equal(Scalar(200), Vector(10, 10).LengthSquared());
            Assert.Equal(Scalar(200), Vector(-10, -10).LengthSquared());
        }

        [Fact]
        public void Atan2()
        {
            Assert.Equal(Math.PI / 2, double.CreateTruncating(Vector(0, 100).Atan2()), 5);
            Assert.Equal(-Math.PI / 2, double.CreateTruncating(Vector(0, -100).Atan2D()), 5);

            Assert.Equal(0, double.CreateTruncating(Vector(100, 0).Atan2()), 5);
            Assert.Equal(Math.PI, double.CreateTruncating(Vector(-100, 0).Atan2()), 5);

            Assert.Equal(Math.PI / 4, double.CreateTruncating(Vector(100, 100).Atan2()), 5);
            Assert.Equal(-Math.PI * 3 / 4, double.CreateTruncating(Vector(-100, -100).Atan2()), 5);
        }

        [Fact]
        public void Area()
        {
            Assert.Equal(Scalar(0), Vector(0, 0).Area());
            Assert.Equal(Scalar(0), Vector(10, 0).Area());
            Assert.Equal(Scalar(0), Vector(0, 10).Area());
            Assert.Equal(Scalar(100), Vector(10, 10).Area());
            Assert.Equal(Scalar(200), Vector(10, 20).Area());
        }

    }
}
