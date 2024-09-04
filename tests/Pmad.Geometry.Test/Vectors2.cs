
namespace Pmad.Geometry.Test
{
	public partial class Vector2ITest : Vector2TestBase<int,Vector2I>
	{
        protected override int Scalar(int v) => v;

        protected override Vector2I Vector(int x, int y) => new (x, y);

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2I(123, 456), new Vector2I(100, 56) + new Vector2I(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2I(100, 56), new Vector2I(123, 456) - new Vector2I(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2I(2000, 8000), new Vector2I(200, 400) * new Vector2I(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2I(2000, 4000), new Vector2I(200, 400) * 10);
            Assert.Equal(new Vector2I(2000, 4000), 10 * new Vector2I(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2I(10, 40), new Vector2I(200, 400) / new Vector2I(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2I(20, 40), new Vector2I(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2I(-200, -400), -new Vector2I(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2I(123, 456) == new Vector2I(123, 456));
            Assert.False(new Vector2I(789, 456) == new Vector2I(123, 456));
            Assert.False(new Vector2I(123, 789) == new Vector2I(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2I(123, 456) != new Vector2I(123, 456));
            Assert.True(new Vector2I(789, 456) != new Vector2I(123, 456));
            Assert.True(new Vector2I(123, 789) != new Vector2I(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2I(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2I(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2I(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2I(123, 789), value);
        }

	}
	public partial class Vector2FTest : Vector2FPTestBase<float,Vector2F>
	{
        protected override float Scalar(int v) => v;

        protected override Vector2F Vector(int x, int y) => new (x, y);

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2F(123, 456), new Vector2F(100, 56) + new Vector2F(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2F(100, 56), new Vector2F(123, 456) - new Vector2F(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2F(2000, 8000), new Vector2F(200, 400) * new Vector2F(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2F(2000, 4000), new Vector2F(200, 400) * 10);
            Assert.Equal(new Vector2F(2000, 4000), 10 * new Vector2F(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2F(10, 40), new Vector2F(200, 400) / new Vector2F(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2F(20, 40), new Vector2F(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2F(-200, -400), -new Vector2F(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2F(123, 456) == new Vector2F(123, 456));
            Assert.False(new Vector2F(789, 456) == new Vector2F(123, 456));
            Assert.False(new Vector2F(123, 789) == new Vector2F(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2F(123, 456) != new Vector2F(123, 456));
            Assert.True(new Vector2F(789, 456) != new Vector2F(123, 456));
            Assert.True(new Vector2F(123, 789) != new Vector2F(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2F(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2F(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2F(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2F(123, 789), value);
        }

	}
	public partial class Vector2LTest : Vector2TestBase<long,Vector2L>
	{
        protected override long Scalar(int v) => v;

        protected override Vector2L Vector(int x, int y) => new (x, y);

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2L(123, 456), new Vector2L(100, 56) + new Vector2L(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2L(100, 56), new Vector2L(123, 456) - new Vector2L(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2L(2000, 8000), new Vector2L(200, 400) * new Vector2L(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2L(2000, 4000), new Vector2L(200, 400) * 10);
            Assert.Equal(new Vector2L(2000, 4000), 10 * new Vector2L(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2L(10, 40), new Vector2L(200, 400) / new Vector2L(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2L(20, 40), new Vector2L(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2L(-200, -400), -new Vector2L(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2L(123, 456) == new Vector2L(123, 456));
            Assert.False(new Vector2L(789, 456) == new Vector2L(123, 456));
            Assert.False(new Vector2L(123, 789) == new Vector2L(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2L(123, 456) != new Vector2L(123, 456));
            Assert.True(new Vector2L(789, 456) != new Vector2L(123, 456));
            Assert.True(new Vector2L(123, 789) != new Vector2L(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2L(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2L(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2L(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2L(123, 789), value);
        }

	}
	public partial class Vector2DTest : Vector2FPTestBase<double,Vector2D>
	{
        protected override double Scalar(int v) => v;

        protected override Vector2D Vector(int x, int y) => new (x, y);

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2D(123, 456), new Vector2D(100, 56) + new Vector2D(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2D(100, 56), new Vector2D(123, 456) - new Vector2D(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2D(2000, 8000), new Vector2D(200, 400) * new Vector2D(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2D(2000, 4000), new Vector2D(200, 400) * 10);
            Assert.Equal(new Vector2D(2000, 4000), 10 * new Vector2D(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2D(10, 40), new Vector2D(200, 400) / new Vector2D(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2D(20, 40), new Vector2D(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2D(-200, -400), -new Vector2D(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2D(123, 456) == new Vector2D(123, 456));
            Assert.False(new Vector2D(789, 456) == new Vector2D(123, 456));
            Assert.False(new Vector2D(123, 789) == new Vector2D(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2D(123, 456) != new Vector2D(123, 456));
            Assert.True(new Vector2D(789, 456) != new Vector2D(123, 456));
            Assert.True(new Vector2D(123, 789) != new Vector2D(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2D(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2D(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2D(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2D(123, 789), value);
        }

	}
}
