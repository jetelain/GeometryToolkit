using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class RotatedRectangleTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        protected abstract TVector Vector(double x, double y);

        protected abstract double Double(TPrimitive v);

        private void Equal(TVector expected, TVector actual)
        {
            Assert.Equal(Double(expected.X), Double(actual.X), 0.0001);
            Assert.Equal(Double(expected.Y), Double(actual.Y), 0.0001);
        }

        [Fact]
        public void GetLargestBetween()
        {
            var box = RotatedRectangle<TPrimitive, TVector>.GetLargestBetween(new ReadOnlyArray<TVector>(
                Vector(0,0),
                Vector(20,0),
                Vector(20,8),
                Vector(18,10),
                Vector(0,10)
            ));
            Assert.NotNull(box);
            Assert.Equal(0, box.Radians);
            Assert.Equal(0, box.Degrees);
            Assert.Equal(Vector(18, 10), box.Size);
            Assert.Equal(Vector(9,5), box.Center);
        }

        [Fact]
        public void GetSmallestContaining()
        {
            var box = RotatedRectangle<TPrimitive, TVector>.GetSmallestContaining(new ReadOnlyArray<TVector>(
                Vector(0,0),
                Vector(20,0),
                Vector(20,8),
                Vector(18,10),
                Vector(0,10)
            ));
            Assert.NotNull(box);
            Assert.Equal(Math.PI/2, box.Radians);
            Assert.Equal(90, box.Degrees);
            Equal(Vector(10, 20), box.Size);
            Equal(Vector(10, 5), box.Center);

            box = RotatedRectangle<TPrimitive, TVector>.GetSmallestContaining(new ReadOnlyArray<TVector>(
                Vector(0,10),
                Vector(10,0),
                Vector(20,10),
                Vector(10,20)
            ));
            Assert.NotNull(box);
            Assert.Equal(Math.PI/4, box.Radians);
            Assert.Equal(45, box.Degrees);
            Equal(Vector(14.14213, 14.14213), box.Size);
            Equal(Vector(10,10), box.Center);
        }
    }
}
