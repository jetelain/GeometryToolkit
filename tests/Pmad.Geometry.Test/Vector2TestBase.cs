namespace Pmad.Geometry.Test
{
    public abstract class Vector2TestBase<TPrimitive, TVector> 
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private Func<int, int, TVector> factory;

        public Vector2TestBase(Func<int, int, TVector> factory)
        {
            this.factory = factory;
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
    }
}
