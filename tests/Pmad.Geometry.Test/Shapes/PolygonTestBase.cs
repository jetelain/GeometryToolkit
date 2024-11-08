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
        protected virtual TVector Truncate(TVector v) => v;

        private Polygon<TPrimitive, TVector> Square100x100()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(100, 100), Vector(0, 100), Vector(0, 0), Vector(100, 0), Vector(100, 100)));
        }

        private Polygon<TPrimitive, TVector> TriangleA()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(0, 0), Vector(0, 100), Vector(100, 0), Vector(0, 0)));
        }
        private Polygon<TPrimitive, TVector> TriangleB()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(101, 101), Vector(0, 101), Vector(101, 0), Vector(101, 101)));
        }

        private Polygon<TPrimitive, TVector> Square100x100Far()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(1100, 1100), Vector(1000, 1100), Vector(1000, 1000), Vector(1100, 1000), Vector(1100, 1100)));
        }

        private Polygon<TPrimitive, TVector> Square100x100WithHole()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(
                Vector(100, 100),
                Vector(0, 100),
                Vector(0, 0),
                Vector(100, 0),
                Vector(100, 100)
            ), new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(
                Vector(75, 75),
                Vector(75, 25),
                Vector(25, 25),
                Vector(25, 75),
                Vector(75, 75)
            )));
        }
        private Polygon<TPrimitive, TVector> Square100x100AltWithHole()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(
                Vector(0, 100),
                Vector(0, 0),
                Vector(100, 0),
                Vector(100, 100),
                Vector(0, 100)
            ), new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(
                Vector(75, 75),
                Vector(75, 25),
                Vector(25, 25),
                Vector(25, 75),
                Vector(75, 75)
            )));
        }

        private Polygon<TPrimitive, TVector> Square100x100WithHoleAlt()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(
                Vector(100, 100),
                Vector(0, 100),
                Vector(0, 0),
                Vector(100, 0),
                Vector(100, 100)
            ), new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(
                Vector(75, 25),
                Vector(25, 25),
                Vector(25, 75),
                Vector(75, 75),
                Vector(75, 25)
            )));
        }

        private Polygon<TPrimitive, TVector> Square100x100WithSmallHole()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(
                Vector(100, 100),
                Vector(0, 100),
                Vector(0, 0),
                Vector(100, 0),
                Vector(100, 100)
            ), new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(
                Vector(55, 55), Vector(55, 45), Vector(45, 45), Vector(45, 55), Vector(55, 55)
            )));
        }

        private Polygon<TPrimitive, TVector> Square50x50()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(75, 75), Vector(75, 25), Vector(25, 25), Vector(25, 75), Vector(75, 75)));
        }

        private Polygon<TPrimitive, TVector> Square10x10()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(55, 55), Vector(55, 45), Vector(45, 45), Vector(45, 55), Vector(55, 55)));
        }

        private Polygon<TPrimitive, TVector> Square50x50WithHole()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(75, 75), Vector(75, 25), Vector(25, 25), Vector(25, 75), Vector(75, 75)),
                new ReadOnlyArray<ReadOnlyArray<TVector>>(new ReadOnlyArray<TVector>(Vector(55, 55), Vector(55, 45), Vector(45, 45), Vector(45, 55), Vector(55, 55))));
        }

        private List<Polygon<TPrimitive, TVector>> SquareBands100x100WithHole()
        {
            return new List<Polygon<TPrimitive, TVector>> {
                new (new( Vector(0, 0), Vector(100, 0), Vector(100, 25), Vector(0, 25), Vector(0, 0) )),
                new (new( Vector(0, 75), Vector(100, 75), Vector(100, 100), Vector(0, 100), Vector(0, 75) )),
                new (new( Vector(0, 0), Vector(0, 100), Vector(25,100), Vector(25, 0), Vector(0, 0) )),
                new (new( Vector(75, 0), Vector(75, 100), Vector(100, 100), Vector(100, 0), Vector(75, 0) )),
            };
        }

        [Fact]
        public void AreaD()
        {
            Assert.Equal(10000, Square100x100().AreaD);
            Assert.Equal(100, Square10x10().AreaD);
            Assert.Equal(2500, Square50x50().AreaD);
            Assert.Equal(5000, TriangleA().AreaD);
        }

        [Fact]
        public void Centroid()
        {
            Assert.Equal(Vector(50, 50), Square100x100().Centroid);
            Assert.Equal(Vector(50, 50), Square10x10().Centroid);
            Assert.Equal(Vector(50, 50), Square50x50().Centroid);
            Assert.Equal(Vector(33, 33), Truncate(TriangleA().Centroid));
        }

        [Fact]
        public void AreaF()
        {
            Assert.Equal(10000, Square100x100().AreaF);
            Assert.Equal(100, Square10x10().AreaF);
            Assert.Equal(2500, Square50x50().AreaF);
        }

        [Fact]
        public void InnerCrown_NoHole()
        {
            var poly = Square100x100();

            var innerPoly = Assert.Single(poly.InnerCrown(10));
            Assert.Equal(Vector(0, 0), innerPoly.Bounds.Min);
            Assert.Equal(Vector(100, 100), innerPoly.Bounds.Max);
            Assert.Equal(new List<TVector>() {
                Vector(100,100),
                Vector(0,100),
                Vector(0,0),
                Vector(100,0),
                Vector(100,100)
            }, innerPoly.Shell);
            Assert.Equal(new List<TVector>() {
                Vector(10,10),
                Vector(10,90),
                Vector(90,90),
                Vector(90,10),
                Vector(10,10)
            }, Assert.Single(innerPoly.Holes));
        }

        [Fact]
        public void InnerCrown_Hole()
        {
            var poly = Square100x100WithHole();

            var innerPolyList = poly.InnerCrown(5).ToList();

            Assert.Equal(2, innerPolyList.Count);

            var innerPoly = innerPolyList[0];
            Assert.Equal(Vector(0, 0), innerPoly.Bounds.Min);
            Assert.Equal(Vector(100, 100), innerPoly.Bounds.Max);
            Assert.Equal(new List<TVector>() {
                Vector(100,100),
                Vector(0,100),
                Vector(0,0),
                Vector(100,0),
                Vector(100,100)
            }, innerPoly.Shell);
            Assert.Equal(new List<TVector>() {
                Vector(5,5),
                Vector(5,95),
                Vector(95,95),
                Vector(95,5),
                Vector(5,5)
            }, Assert.Single(innerPoly.Holes));

            innerPoly = innerPolyList[1];
            Assert.Equal(Vector(20, 20), innerPoly.Bounds.Min);
            Assert.Equal(Vector(80, 80), innerPoly.Bounds.Max);
            Assert.Equal(9, innerPoly.Shell.Count);
            Assert.Equal(new List<TVector>() {
                Vector(25,75),
                Vector(75,75),
                Vector(75,25),
                Vector(25,25),
                Vector(25,75)
            }, Assert.Single(innerPoly.Holes));
        }


        [Fact]
        public void Offset_NoHole()
        {
            var poly = Square100x100();

            var offsetPoly = Assert.Single(poly.Offset(10));
            Assert.Equal(Vector(-10, -10), offsetPoly.Bounds.Min);
            Assert.Equal(Vector(110, 110), offsetPoly.Bounds.Max);
            Assert.Equal(9, offsetPoly.Shell.Count);
            Assert.Empty(offsetPoly.Holes);
        }

        [Fact]
        public void Offset_Hole()
        {
            var poly = Square100x100WithHole();

            var offsetPoly = Assert.Single(poly.Offset(10));
            Assert.Equal(Vector(-10, -10), offsetPoly.Bounds.Min);
            Assert.Equal(Vector(110, 110), offsetPoly.Bounds.Max);
            Assert.Equal(9, offsetPoly.Shell.Count);
            Assert.Equal(new List<TVector>() {
                Vector(35,65),
                Vector(65,65),
                Vector(65,35),
                Vector(35,35),
                Vector(35,65)
            }, Assert.Single(offsetPoly.Holes));

            offsetPoly = Assert.Single(poly.Offset(-10));
            Assert.Equal(Vector(10, 10), offsetPoly.Bounds.Min);
            Assert.Equal(Vector(90, 90), offsetPoly.Bounds.Max);
            Assert.Equal(new List<TVector>() {
                Vector(90,90),
                Vector(10,90),
                Vector(10,10),
                Vector(90,10),
                Vector(90,90)
            }, offsetPoly.Shell);
            Assert.Equal(9, Assert.Single(offsetPoly.Holes).Count);
        }

        [Fact]
        public void OuterCrown_NoHole()
        {
            var poly = Square100x100();

            var outerPoly = Assert.Single(poly.OuterCrown(10));
            Assert.Equal(Vector(-10, -10), outerPoly.Bounds.Min);
            Assert.Equal(Vector(110, 110), outerPoly.Bounds.Max);
            Assert.Equal(9, outerPoly.Shell.Count);
            Assert.Equal(new List<TVector>() {
                Vector(0,0),
                Vector(0,100),
                Vector(100,100),
                Vector(100,0),
                Vector(0,0)
            }, Assert.Single(outerPoly.Holes));
        }

        [Fact]
        public void Crown_NoHole()
        {
            var poly = Square100x100();

            var crown = Assert.Single(poly.Crown(10, 10));
            Assert.Equal(Vector(-10, -10), crown.Bounds.Min);
            Assert.Equal(Vector(110, 110), crown.Bounds.Max);
            Assert.Equal(9, crown.Shell.Count);
            Assert.Equal(new List<TVector>() {
                Vector(10,10),
                Vector(10,90),
                Vector(90,90),
                Vector(90,10),
                Vector(10,10)
            }, Assert.Single(crown.Holes));
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

        [Fact]
        public void SubstractNoOverlap()
        {
            var result = Square100x100().SubstractAllNoOverlap(new(Square50x50()));
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());

            result = Square50x50().SubstractAllNoOverlap(new(Square100x100()));
            Assert.Empty(result);
        }

        [Fact]
        public void SubstractAll()
        {
            var result = Square100x100().SubstractAll(new[] { Square50x50() });
            var polygon = Assert.Single(result);
            Assert.Equal(Vector(0, 0), polygon.Bounds.Min);
            Assert.Equal(Vector(100, 100), polygon.Bounds.Max);
            Assert.Single(polygon.Holes);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());

            result = Square100x100().SubstractAll(SquareBands100x100WithHole());
            polygon = Assert.Single(result);
            Assert.Equal(Vector(25, 25), polygon.Bounds.Min);
            Assert.Equal(Vector(75, 75), polygon.Bounds.Max);
            Assert.Equal("POLYGON ((75 75, 25 75, 25 25, 75 25, 75 75))", polygon.ToString());

            result = Square50x50().SubstractAll(new[] { Square100x100() });
            Assert.Empty(result);

            result = Square100x100().SubstractAll(new[] { Square100x100WithHole() });
            polygon = Assert.Single(result);
            Assert.Equal(Vector(25, 25), polygon.Bounds.Min);
            Assert.Equal(Vector(75, 75), polygon.Bounds.Max);
            Assert.Equal("POLYGON ((75 25, 75 75, 25 75, 25 25, 75 25))", polygon.ToString());
        }

        [Fact]
        public void Union()
        {
            var result = Square100x100().Union(Square50x50());
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());
        }


        [Fact]
        public void ContainsVector()
        {
            var square = Square100x100();

            Assert.False(square.Contains(Vector(50, 150)));
            Assert.True(square.Contains(Vector(50, 100)));
            Assert.True(square.Contains(Vector(50, 50)));
            Assert.True(square.Contains(Vector(50, 0)));
            Assert.False(square.Contains(Vector(50, -50)));

            Assert.False(square.Contains(Vector(150, 50)));
            Assert.True(square.Contains(Vector(100, 50)));
            Assert.True(square.Contains(Vector(50, 50)));
            Assert.True(square.Contains(Vector(0, 50)));
            Assert.False(square.Contains(Vector(-50, 50)));

            var triangle = TriangleA();
            Assert.False(triangle.Contains(Vector(-25, -25)));
            Assert.True(triangle.Contains(Vector(0, 0)));
            Assert.True(triangle.Contains(Vector(25, 25)));
            Assert.True(triangle.Contains(Vector(50, 50)));
            Assert.False(triangle.Contains(Vector(75, 75)));
            Assert.False(triangle.Contains(Vector(100, 100)));
        }

        [Fact]
        public void LoopEqual()
        {
            Assert.True(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1)),
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1))));

            Assert.True(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1), Vector(2, 2)),
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1))));

            Assert.True(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(4, 4), Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4)),
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1))));

            Assert.False(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1)),
                new(Vector(1, 1), Vector(2, 2), Vector(4, 4), Vector(3, 3), Vector(1, 1))));

            Assert.False(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1), Vector(2, 2)),
                new(Vector(1, 1), Vector(2, 2), Vector(4, 4), Vector(3, 3), Vector(1, 1))));

            Assert.False(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(4, 4), Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4)),
                new(Vector(1, 1), Vector(2, 2), Vector(4, 4), Vector(3, 3), Vector(1, 1))));

            Assert.False(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1), Vector(2, 2)),
                new(Vector(5, 5), Vector(6, 6), Vector(7, 7), Vector(8, 8), Vector(5, 5))));

            Assert.False(Polygon<TPrimitive, TVector>.LoopEqual(
                new(Vector(1, 1), Vector(2, 2), Vector(3, 3), Vector(4, 4), Vector(1, 1)),
                new(Vector(1, 1), Vector(2, 2), Vector(4, 4), Vector(1, 1))));
        }

        [Fact]
        public void EqualsPolygon()
        {
            Assert.Equal(Square100x100(), Square100x100());
            Assert.Equal(Square100x100WithHole(), Square100x100WithHole());

            Assert.NotEqual(Square100x100(), Square100x100WithHole());
            Assert.NotEqual(Square100x100WithHole(), Square100x100());
            Assert.NotEqual(Square100x100WithHole(), Square100x100WithHoleAlt());
            Assert.NotEqual(Square100x100WithHole(), Square100x100AltWithHole());

            Assert.NotEqual(Square100x100(), Square100x100Far());
            Assert.NotEqual(Square100x100Far(), Square100x100());
        }

        [Fact]
        public void EqualsPolygon_Ref()
        {
            var a = Square100x100();
            Assert.Equal(a, a);
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void SameAs()
        {
            Assert.True(Square100x100().SameAs(Square100x100()));
            Assert.True(Square100x100WithHole().SameAs(Square100x100WithHole()));
            Assert.True(Square100x100WithHole().SameAs(Square100x100WithHoleAlt()));
            Assert.True(Square100x100WithHole().SameAs(Square100x100AltWithHole()));

            Assert.False(Square100x100().SameAs(Square100x100WithHole()));
            Assert.False(Square100x100WithHole().SameAs(Square100x100()));
            Assert.False(Square100x100WithHole().SameAs(Square100x100WithSmallHole()));
            Assert.False(Square100x100().SameAs(Square100x100Far()));
            Assert.False(Square100x100Far().SameAs(Square100x100()));
        }

        [Fact]
        public void SameAs_Ref()
        {
            var a = Square100x100();
            Assert.True(a.SameAs(a));
        }

        [Fact]
        public void GetHashcode()
        {
            Assert.Equal(Square100x100().GetHashCode(), Square100x100().GetHashCode());
            Assert.Equal(0, new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>()).GetHashCode());
        }

        [Fact]
        public void EqualsObject()
        {
            Assert.True(Square100x100().Equals((object)Square100x100()));
            Assert.False(Square100x100().Equals((object)1234));
        }


        [Fact]
        public void Transform()
        {
            Assert.Equal("POLYGON ((550 550, 550 450, 450 450, 450 550, 550 550))", Square10x10().Transforms().Scale(10).ToString());
            Assert.Equal("POLYGON ((1000 1000, 0 1000, 0 0, 1000 0, 1000 1000), (750 750, 750 250, 250 250, 250 750, 750 750))", Square100x100WithHole().Transforms().Scale(10).ToString());
        }
    }
}
