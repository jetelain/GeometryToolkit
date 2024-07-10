
namespace Pmad.Geometry.Test
{
	public partial class Vector2ITest : Vector2TestBase<int,Vector2I>
	{
        public Vector2ITest() : base((x,y) => new Vector2I(x, y), x => x) { }

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
	public partial class Vector2FTest : Vector2TestBase<float,Vector2F>
	{
        public Vector2FTest() : base((x,y) => new Vector2F(x, y), x => x) { }

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
        public Vector2LTest() : base((x,y) => new Vector2L(x, y), x => x) { }

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
	public partial class Vector2DTest : Vector2TestBase<double,Vector2D>
	{
        public Vector2DTest() : base((x,y) => new Vector2D(x, y), x => x) { }

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
	public partial class Vector2ISTest : Vector2TestBase<int,Vector2IS>
	{
        public Vector2ISTest() : base((x,y) => new Vector2IS(x, y), x => x) { }

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2IS(123, 456), new Vector2IS(100, 56) + new Vector2IS(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2IS(100, 56), new Vector2IS(123, 456) - new Vector2IS(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2IS(2000, 8000), new Vector2IS(200, 400) * new Vector2IS(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2IS(2000, 4000), new Vector2IS(200, 400) * 10);
            Assert.Equal(new Vector2IS(2000, 4000), 10 * new Vector2IS(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2IS(10, 40), new Vector2IS(200, 400) / new Vector2IS(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2IS(20, 40), new Vector2IS(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2IS(-200, -400), -new Vector2IS(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2IS(123, 456) == new Vector2IS(123, 456));
            Assert.False(new Vector2IS(789, 456) == new Vector2IS(123, 456));
            Assert.False(new Vector2IS(123, 789) == new Vector2IS(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2IS(123, 456) != new Vector2IS(123, 456));
            Assert.True(new Vector2IS(789, 456) != new Vector2IS(123, 456));
            Assert.True(new Vector2IS(123, 789) != new Vector2IS(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2IS(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2IS(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2IS(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2IS(123, 789), value);
        }

	}
	public partial class Vector2FSTest : Vector2TestBase<float,Vector2FS>
	{
        public Vector2FSTest() : base((x,y) => new Vector2FS(x, y), x => x) { }

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2FS(123, 456), new Vector2FS(100, 56) + new Vector2FS(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2FS(100, 56), new Vector2FS(123, 456) - new Vector2FS(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2FS(2000, 8000), new Vector2FS(200, 400) * new Vector2FS(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2FS(2000, 4000), new Vector2FS(200, 400) * 10);
            Assert.Equal(new Vector2FS(2000, 4000), 10 * new Vector2FS(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2FS(10, 40), new Vector2FS(200, 400) / new Vector2FS(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2FS(20, 40), new Vector2FS(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2FS(-200, -400), -new Vector2FS(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2FS(123, 456) == new Vector2FS(123, 456));
            Assert.False(new Vector2FS(789, 456) == new Vector2FS(123, 456));
            Assert.False(new Vector2FS(123, 789) == new Vector2FS(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2FS(123, 456) != new Vector2FS(123, 456));
            Assert.True(new Vector2FS(789, 456) != new Vector2FS(123, 456));
            Assert.True(new Vector2FS(123, 789) != new Vector2FS(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2FS(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2FS(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2FS(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2FS(123, 789), value);
        }

	}
	public partial class Vector2LSTest : Vector2TestBase<long,Vector2LS>
	{
        public Vector2LSTest() : base((x,y) => new Vector2LS(x, y), x => x) { }

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2LS(123, 456), new Vector2LS(100, 56) + new Vector2LS(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2LS(100, 56), new Vector2LS(123, 456) - new Vector2LS(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2LS(2000, 8000), new Vector2LS(200, 400) * new Vector2LS(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2LS(2000, 4000), new Vector2LS(200, 400) * 10);
            Assert.Equal(new Vector2LS(2000, 4000), 10 * new Vector2LS(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2LS(10, 40), new Vector2LS(200, 400) / new Vector2LS(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2LS(20, 40), new Vector2LS(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2LS(-200, -400), -new Vector2LS(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2LS(123, 456) == new Vector2LS(123, 456));
            Assert.False(new Vector2LS(789, 456) == new Vector2LS(123, 456));
            Assert.False(new Vector2LS(123, 789) == new Vector2LS(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2LS(123, 456) != new Vector2LS(123, 456));
            Assert.True(new Vector2LS(789, 456) != new Vector2LS(123, 456));
            Assert.True(new Vector2LS(123, 789) != new Vector2LS(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2LS(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2LS(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2LS(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2LS(123, 789), value);
        }

	}
	public partial class Vector2DSTest : Vector2TestBase<double,Vector2DS>
	{
        public Vector2DSTest() : base((x,y) => new Vector2DS(x, y), x => x) { }

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2DS(123, 456), new Vector2DS(100, 56) + new Vector2DS(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2DS(100, 56), new Vector2DS(123, 456) - new Vector2DS(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2DS(2000, 8000), new Vector2DS(200, 400) * new Vector2DS(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2DS(2000, 4000), new Vector2DS(200, 400) * 10);
            Assert.Equal(new Vector2DS(2000, 4000), 10 * new Vector2DS(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2DS(10, 40), new Vector2DS(200, 400) / new Vector2DS(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2DS(20, 40), new Vector2DS(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2DS(-200, -400), -new Vector2DS(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2DS(123, 456) == new Vector2DS(123, 456));
            Assert.False(new Vector2DS(789, 456) == new Vector2DS(123, 456));
            Assert.False(new Vector2DS(123, 789) == new Vector2DS(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2DS(123, 456) != new Vector2DS(123, 456));
            Assert.True(new Vector2DS(789, 456) != new Vector2DS(123, 456));
            Assert.True(new Vector2DS(123, 789) != new Vector2DS(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2DS(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2DS(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2DS(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2DS(123, 789), value);
        }

	}
	public partial class Vector2FNTest : Vector2TestBase<float,Vector2FN>
	{
        public Vector2FNTest() : base((x,y) => new Vector2FN(x, y), x => x) { }

	    [Fact]
        public void Add()
        {
            Assert.Equal(new Vector2FN(123, 456), new Vector2FN(100, 56) + new Vector2FN(23, 400));
        }

        [Fact]
        public void Substract()
        {
            Assert.Equal(new Vector2FN(100, 56), new Vector2FN(123, 456) - new Vector2FN(23, 400));
        }

        [Fact]
        public void Multiply()
        {
            Assert.Equal(new Vector2FN(2000, 8000), new Vector2FN(200, 400) * new Vector2FN(10, 20));
        }

        [Fact]
        public void MultiplyScalar()
        {
            Assert.Equal(new Vector2FN(2000, 4000), new Vector2FN(200, 400) * 10);
            Assert.Equal(new Vector2FN(2000, 4000), 10 * new Vector2FN(200, 400));
        }

        [Fact]
        public void Divide()
        {
            Assert.Equal(new Vector2FN(10, 40), new Vector2FN(200, 400) / new Vector2FN(20, 10));
        }
        
        [Fact]
        public void DivideScalar()
        {
            Assert.Equal(new Vector2FN(20, 40), new Vector2FN(200, 400) / 10);
        }
        
        [Fact]
        public void Negate()
        {
            Assert.Equal(new Vector2FN(-200, -400), -new Vector2FN(200, 400));
        }
        
        [Fact]
        public void EqualOperator()
        {
            Assert.True(new Vector2FN(123, 456) == new Vector2FN(123, 456));
            Assert.False(new Vector2FN(789, 456) == new Vector2FN(123, 456));
            Assert.False(new Vector2FN(123, 789) == new Vector2FN(123, 456));
        }
        
        [Fact]
        public void NotEqualOperator()
        {
            Assert.False(new Vector2FN(123, 456) != new Vector2FN(123, 456));
            Assert.True(new Vector2FN(789, 456) != new Vector2FN(123, 456));
            Assert.True(new Vector2FN(123, 789) != new Vector2FN(123, 456));
        }

        [Fact]
        public void X()
        {
            var value = new Vector2FN(123, 456);
            Assert.Equal(123, value.X);
            
            value.X = 789;
            Assert.Equal(789, value.X);
            Assert.Equal(new Vector2FN(789, 456), value);
        }

        [Fact]
        public void Y()
        {
            var value = new Vector2FN(123, 456);
            Assert.Equal(456, value.Y);
            
            value.Y = 789;
            Assert.Equal(789, value.Y);
            Assert.Equal(new Vector2FN(123, 789), value);
        }

	}
}
