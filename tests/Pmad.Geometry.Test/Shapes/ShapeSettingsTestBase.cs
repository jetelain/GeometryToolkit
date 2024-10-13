using System.Numerics;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class ShapeSettingsTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int ExpectedScale { get; }

        [Fact]
        public void Default()
        {
            var settings = ShapeSettings<TPrimitive, TVector>.Default;
            Assert.Equal(ExpectedScale, settings.ScaleForClipper);
            Assert.Equal(9, settings.NegligibleClipperArea);
            Assert.Equal(9, settings.NegligibleArea * ExpectedScale * ExpectedScale, 0.00001);
            Assert.Equal(3, settings.NegligibleDistance * ExpectedScale, 0.00001);
        }

        [Fact]
        public void FromClipperToRing()
        {
            var points = new Path64()
            {
                new Point64( 10 * ExpectedScale, 20 * ExpectedScale ),
                new Point64( 30 * ExpectedScale, 40 * ExpectedScale ),
                new Point64( 50 * ExpectedScale, 60 * ExpectedScale ),
                new Point64( 70 * ExpectedScale, 80 * ExpectedScale ),
            };

            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            Assert.Equal([
                Vector(10,20),
                Vector(30,40),
                Vector(50,60),
                Vector(70,80),
                Vector(10,20)], settings.FromClipperToRing(points));
        }

        [Fact]
        public void FromClipper_Vector()
        {
            var settings = ShapeSettings<TPrimitive, TVector>.Default;
            Assert.Equal(Vector(10, 20), settings.FromClipper(new Point64(10 * ExpectedScale, 20 * ExpectedScale)));
            Assert.Equal(Vector(30, 40), settings.FromClipper(new Point64(30 * ExpectedScale, 40 * ExpectedScale)));
        }

        [Fact]
        public void FromClipper_Array()
        {
            var points = new Path64()
            {
                new Point64( 10 * ExpectedScale, 20 * ExpectedScale ),
                new Point64( 30 * ExpectedScale, 40 * ExpectedScale ),
                new Point64( 50 * ExpectedScale, 60 * ExpectedScale ),
                new Point64( 70 * ExpectedScale, 80 * ExpectedScale ),
            };

            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            Assert.Equal([
                Vector(10,20),
                Vector(30,40),
                Vector(50,60),
                Vector(70,80)], settings.FromClipper(points));
        }

        [Fact]
        public void ToClipper_Array()
        {
            var points = new ReadOnlyArray<TVector>(
                Vector(10, 20),
                Vector(30, 40),
                Vector(50, 60),
                Vector(70, 80));

            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            Assert.Equal([
                new Point64( 10 * ExpectedScale, 20 * ExpectedScale ),
                new Point64( 30 * ExpectedScale, 40 * ExpectedScale ),
                new Point64( 50 * ExpectedScale, 60 * ExpectedScale ),
                new Point64( 70 * ExpectedScale, 80 * ExpectedScale )], settings.ToClipper(points));
        }

        [Fact]
        public void ToClipper_Vector()
        {
            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            Assert.Equal(new Point64(10 * ExpectedScale, 20 * ExpectedScale), settings.ToClipper(Vector(10, 20)));
            Assert.Equal(new Point64(30 * ExpectedScale, 40 * ExpectedScale), settings.ToClipper(Vector(30, 40)));
        }

        [Fact]
        public void ToClipper_Envelope()
        {
            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            var rect = settings.ToClipper(new VectorEnvelope<TVector>(Vector(10,20), Vector(30,50)));
            Assert.Equal(20 * ExpectedScale, rect.Width);
            Assert.Equal(30 * ExpectedScale, rect.Height);
            Assert.Equal(10 * ExpectedScale, rect.left);
            Assert.Equal(20 * ExpectedScale, rect.top);
            Assert.Equal(30 * ExpectedScale, rect.right);
            Assert.Equal(50 * ExpectedScale, rect.bottom);
        }

        [Fact]
        public void AlmostEquals()
        {
            var settings = ShapeSettings<TPrimitive, TVector>.Default;

            // Distance less than 3
            Assert.True(settings.AlmostEquals(settings.FromClipper(new Point64(5, 5)), settings.FromClipper(new Point64(5, 5))));
            Assert.True(settings.AlmostEquals(settings.FromClipper(new Point64(5, 7)), settings.FromClipper(new Point64(5, 5))));
            Assert.True(settings.AlmostEquals(settings.FromClipper(new Point64(7, 5)), settings.FromClipper(new Point64(5, 5))));

            // Distance 3 or above
            Assert.False(settings.AlmostEquals(settings.FromClipper(new Point64(8, 8)), settings.FromClipper(new Point64(5, 5))));
            Assert.False(settings.AlmostEquals(settings.FromClipper(new Point64(5, 8)), settings.FromClipper(new Point64(5, 5))));
            Assert.False(settings.AlmostEquals(settings.FromClipper(new Point64(8, 5)), settings.FromClipper(new Point64(5, 5))));
        }
    }
}
