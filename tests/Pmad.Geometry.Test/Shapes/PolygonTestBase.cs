using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class PolygonTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);
        protected abstract int Integer(TPrimitive v);

        private Polygon<TPrimitive,TVector> Square100x100()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(100, 100), Vector(0, 100), Vector(0, 0), Vector(100, 0), Vector(100, 100) ));
        }

        private Polygon<TPrimitive,TVector> TriangleA()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(0, 0), Vector(0, 100), Vector(100, 0), Vector(0, 0)));
        }
        private Polygon<TPrimitive,TVector> TriangleB()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(101, 101), Vector(0, 101), Vector(101, 0), Vector(101, 101)));
        }

        private Polygon<TPrimitive,TVector> Square100x100Far()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(1100, 1100), Vector(1000, 1100), Vector(1000, 1000), Vector(1100, 1000), Vector(1100, 1100)));
        }

        private Polygon<TPrimitive,TVector> Square100x100WithHole()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(
                Vector(100,100),
                Vector(0,100),
                Vector(0,0),
                Vector(100,0),
                Vector(100,100)
            ), new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(
                Vector(75,75),
                Vector(75,25),
                Vector(25,25),
                Vector(25,75),
                Vector(75,75)
            )));
        }

        private Polygon<TPrimitive,TVector> Square50x50()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(75, 75), Vector(75, 25), Vector(25, 25), Vector(25, 75), Vector(75, 75) ));
        }

        private Polygon<TPrimitive,TVector> Square10x10()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(55, 55), Vector(55, 45), Vector(45, 45), Vector(45, 55), Vector(55, 55) ));
        }

        private Polygon<TPrimitive,TVector> Square50x50WithHole()
        {
            return new Polygon<TPrimitive,TVector>(new ReadOnlyArray<TVector>(Vector(75, 75), Vector(75, 25), Vector(25, 25), Vector(25, 75), Vector(75, 75) ),
                new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(Vector(55, 55), Vector(55, 45), Vector(45, 45), Vector(45, 55), Vector(55, 55) )));
        }

        private List<Polygon<TPrimitive,TVector>> SquareBands100x100WithHole()
        {
            return new List<Polygon<TPrimitive,TVector>> {
                new (new( Vector(0, 0), Vector(100, 0), Vector(100, 25), Vector(0, 25), Vector(0, 0) )),
                new (new( Vector(0, 75), Vector(100, 75), Vector(100, 100), Vector(0, 100), Vector(0, 75) )),
                new (new( Vector(0, 0), Vector(0, 100), Vector(25,100), Vector(25, 0), Vector(0, 0) )),
                new (new( Vector(75, 0), Vector(75, 100), Vector(100, 100), Vector(100, 0), Vector(75, 0) )),
            };
        }


        [Fact]
        public void NearestPoint()
        {
            var polygon = Square100x100();

            // Outside
            Assert.Equal(Vector(100, 50), polygon.NearestPointBoundary(Vector(105, 50)));
            Assert.Equal(Vector(0, 50), polygon.NearestPointBoundary(Vector(-5, 50)));

            // Inside
            Assert.Equal(Vector(100, 50), polygon.NearestPointBoundary(Vector(95, 50)));
            Assert.Equal(Vector(0, 50), polygon.NearestPointBoundary(Vector(5, 50)));

            polygon = Square100x100WithHole();

            // Outside
            Assert.Equal(Vector(100, 50), polygon.NearestPointBoundary(Vector(105, 50)));
            Assert.Equal(Vector(0, 50), polygon.NearestPointBoundary(Vector(-5, 50)));

            // Inside
            Assert.Equal(Vector(100, 50), polygon.NearestPointBoundary(Vector(95, 50)));
            Assert.Equal(Vector(0, 50), polygon.NearestPointBoundary(Vector(5, 50)));

            // In hole
            Assert.Equal(Vector(25, 50), polygon.NearestPointBoundary(Vector(30, 50)));
            Assert.Equal(Vector(75, 50), polygon.NearestPointBoundary(Vector(70, 50)));
        }

        [Fact]
        public void Distance()
        {
            var polygon = Square100x100();

            // Outside
            Assert.Equal(5, polygon.Distance(Vector(105, 50)));
            Assert.Equal(5, polygon.Distance(Vector(-5, 50)));

            // Inside
            Assert.Equal(0, polygon.Distance(Vector(95, 50)));
            Assert.Equal(0, polygon.Distance(Vector(5, 50)));

            polygon = Square100x100WithHole();

            // Outside
            Assert.Equal(5, polygon.Distance(Vector(105, 50)));
            Assert.Equal(5, polygon.Distance(Vector(-5, 50)));

            // Inside
            Assert.Equal(0, polygon.Distance(Vector(95, 50)));
            Assert.Equal(0, polygon.Distance(Vector(5, 50)));

            // In hole
            Assert.Equal(5, polygon.Distance(Vector(30, 50)));
            Assert.Equal(5, polygon.Distance(Vector(70, 50)));
        }


    }
}
