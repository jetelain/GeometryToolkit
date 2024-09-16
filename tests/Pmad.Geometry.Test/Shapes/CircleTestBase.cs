using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class CircleTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {

        [Fact]
        public void FromTwoPoints()
        {
            var pointA = TVector.Create(0, 0);
            var pointB = TVector.Create(100, 100);

            var circle = Circle<TPrimitive, TVector>.FromTwoPoints(ShapeSettings<TPrimitive, TVector>.Default, pointA, pointB);

            Assert.Equal(70.71, circle.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle.Center);
        }


        [Fact]
        public void FromThreePoints()
        {
            var pointA = TVector.Create(0, 0);
            var pointB = TVector.Create(100, 100);
            var pointC = TVector.Create(0, 100);

            var circle = Circle<TPrimitive, TVector>.FromThreePoints(ShapeSettings<TPrimitive, TVector>.Default, pointA, pointB, pointC);

            Assert.Equal(70.71, circle.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle.Center);
        }

        [Fact]
        public void FromThreePoints_Aligned()
        {
            var pointA = TVector.Create(0, 0);
            var pointB = TVector.Create(100, 100);
            var pointC = TVector.Create(200, 200);

            var circle = Circle<TPrimitive, TVector>.FromThreePoints(ShapeSettings<TPrimitive, TVector>.Default, pointA, pointB, pointC);

            Assert.Equal(141.42, circle.Radius, 0.01);
            Assert.Equal(TVector.Create(100, 100), circle.Center);
        }

        [Fact]
        public void GetSmallestContaining_Trivial()
        {
            var pointA = TVector.Create(0, 0);
            var pointB = TVector.Create(100, 100);
            var pointC = TVector.Create(0, 100);

            var circle0 = Circle<TPrimitive, TVector>.GetSmallestContaining([]);
            var circle1 = Circle<TPrimitive, TVector>.GetSmallestContaining([pointB]);
            var circle2 = Circle<TPrimitive, TVector>.GetSmallestContaining([pointA, pointB]);
            var circle3 = Circle<TPrimitive, TVector>.GetSmallestContaining([pointA, pointB, pointC]);

            Assert.Equal(0, circle0.Radius);
            Assert.Equal(TVector.Zero, circle0.Center);

            Assert.Equal(0, circle1.Radius);
            Assert.Equal(pointB, circle1.Center);

            Assert.Equal(70.71, circle2.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle2.Center);

            Assert.Equal(70.71, circle3.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle3.Center);
        }

        [Fact]
        public void GetSmallestContaining_Basic()
        {
            var circle = Circle<TPrimitive, TVector>.GetSmallestContaining([
                TVector.Create(0, 0), 
                TVector.Create(100, 100), 
                TVector.Create(0, 100), 
                TVector.Create(100, 0)]);

            Assert.Equal(70.71, circle.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle.Center);
        }

        [Fact]
        public void GetSmallestContaining()
        {
            var circle = Circle<TPrimitive, TVector>.GetSmallestContaining([
                TVector.Create(0, 0), 
                TVector.Create(100, 100), 
                TVector.Create(0, 100), 
                TVector.Create(100, 0),
                TVector.Create(110, 110),
                TVector.Create(-10, 110),
                TVector.Create(-10, -10),
                TVector.Create(100, 110),
                TVector.Create(0, -10)]);

            Assert.Equal(84.85, circle.Radius, 0.01);
            Assert.Equal(TVector.Create(50, 50), circle.Center);
        }
    }
}
