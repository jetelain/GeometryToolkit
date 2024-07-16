using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class PathTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int Integer(TPrimitive v);

        [Fact]
        public void Length()
        {
            var path = new Path<TPrimitive,TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10));
            Assert.Equal(20, path.LengthD);
            Assert.Equal(20, path.LengthF);

            path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(10, 10));
            Assert.Equal(14.14, Math.Round(path.LengthD, 2));
            Assert.Equal(14.14, Math.Round(path.LengthF, 2));
        }

        [Fact]
        public void Distance()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 10));
            Assert.Equal(5, path.Distance(Vector(5, 5)));
            Assert.Equal(5, path.Distance(Vector(-5, 5)));
            Assert.Equal(5, path.Distance(Vector(0, 15)));
            Assert.Equal(5, path.Distance(Vector(0, -5)));
        }

        [Fact]
        public void NearestPoint()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 10));
            Assert.Equal(Vector(0, 5), path.NearestPointBoundary(Vector(5, 5)));
            Assert.Equal(Vector(0, 5), path.NearestPointBoundary(Vector(-5, 5)));
            Assert.Equal(Vector(0, 10), path.NearestPointBoundary(Vector(0, 15)));
            Assert.Equal(Vector(0, 0), path.NearestPointBoundary(Vector(0, -5)));
        }

        [Fact]
        public void ClippedBy()
        {
            var path = new Path<TPrimitive, TVector>(Vector(50, 00), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 200));
            var clip = path.ClippedBy(new (Vector(25, 25), Vector(75, 175))).ToList();
            var clipPath = Assert.Single(clip);
            Assert.Equal(new [] { Vector(50, 25), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 175) }, clipPath.Points);

            clip = path.ClippedBy(new(Vector(25, 0), Vector(75, 200))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(path.Points, clipPath.Points);

            clip = path.ClippedBy(new(Vector(100, -100), Vector(100, 300))).ToList();
            Assert.Empty(clip);
        }
    }
}
