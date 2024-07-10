namespace Pmad.Geometry.Test
{
    public abstract class Vector2TestBase<TPrimitive, TVector> 
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly Func<int, int, TVector> factory;
        private readonly Func<int, TPrimitive> scalar;

        public Vector2TestBase(Func<int, int, TVector> factory, Func<int, TPrimitive> scalar)
        {
            this.factory = factory;
            this.scalar = scalar;
        }

        [Fact]
        public void LengthD()
        {
            Assert.Equal(10, factory(0, 10).LengthD());
            Assert.Equal(10, factory(10, 0).LengthD());
            Assert.Equal(10, factory(0, -10).LengthD());
            Assert.Equal(10, factory(-10, 0).LengthD());
            Assert.Equal(14.1, factory(10, 10).LengthD(), 1);
            Assert.Equal(14.1, factory(-10, -10).LengthD(), 1);
        }

        [Fact]
        public void LengthF()
        {
            Assert.Equal(10, factory(0, 10).LengthF());
            Assert.Equal(10, factory(10, 0).LengthF());
            Assert.Equal(10, factory(0, -10).LengthF());
            Assert.Equal(10, factory(-10, 0).LengthF());
            Assert.Equal(14.1f, factory(10, 10).LengthF(), 1);
            Assert.Equal(14.1f, factory(-10, -10).LengthF(), 1);
        }

        [Fact]
        public void LengthSquaredD()
        {
            Assert.Equal(100, factory(0, 10).LengthSquaredD());
            Assert.Equal(100, factory(0, -10).LengthSquaredD());
            Assert.Equal(100, factory(10, 0).LengthSquaredD());
            Assert.Equal(100, factory(-10, 0).LengthSquaredD());
            Assert.Equal(200, factory(10, 10).LengthSquaredD());
            Assert.Equal(200, factory(-10, -10).LengthSquaredD());
        }

        [Fact]
        public void LengthSquaredF()
        {
            Assert.Equal(100, factory(0, 10).LengthSquaredF());
            Assert.Equal(100, factory(0, -10).LengthSquaredF());
            Assert.Equal(100, factory(10, 0).LengthSquaredF());
            Assert.Equal(100, factory(-10, 0).LengthSquaredF());
            Assert.Equal(200, factory(10, 10).LengthSquaredF());
            Assert.Equal(200, factory(-10, -10).LengthSquaredF());
        }

        [Fact]
        public void IsGreaterThanOrEqualAll()
        {
            Assert.True(factory(0, 10).IsGreaterThanOrEqualAll(factory(0, 10)));
            Assert.True(factory(0, 15).IsGreaterThanOrEqualAll(factory(0, 10)));
            Assert.True(factory(5, 10).IsGreaterThanOrEqualAll(factory(0, 10)));

            Assert.False(factory(0, 10).IsGreaterThanOrEqualAll(factory(5, 15)));
            Assert.False(factory(0, 15).IsGreaterThanOrEqualAll(factory(5, 15)));
            Assert.False(factory(5, 10).IsGreaterThanOrEqualAll(factory(5, 15)));
        }

        [Fact]
        public void IsLessThanOrEqualAll()
        {
            Assert.False(factory(5, 15).IsLessThanOrEqualAll(factory(0, 10)));
            Assert.False(factory(0, 15).IsLessThanOrEqualAll(factory(0, 10)));
            Assert.False(factory(5, 10).IsLessThanOrEqualAll(factory(0, 10)));

            Assert.True(factory(0, 10).IsLessThanOrEqualAll(factory(5, 15)));
            Assert.True(factory(0, 15).IsLessThanOrEqualAll(factory(5, 15)));
            Assert.True(factory(5, 10).IsLessThanOrEqualAll(factory(5, 15)));
        }

        [Fact]
        public void SwapXY()
        {
            Assert.Equal(factory(15, 5), factory(5, 15).SwapXY());
        }

        [Fact]
        public void XProperty()
        {
            var value = factory(123, 456);
            Assert.Equal(scalar(123), value.X);

            value.X = scalar(789);
            Assert.Equal(scalar(789), value.X);
            Assert.Equal(factory(789, 456), value);
        }

        [Fact]
        public void YProperty()
        {
            var value = factory(123, 456);
            Assert.Equal(scalar(456), value.Y);

            value.Y = scalar(789);
            Assert.Equal(scalar(789), value.Y);
            Assert.Equal(factory(123, 789), value);
        }
    }
}
