using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class PolygonSetTestBase<TPrimitive, TVector>
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
            Assert.Equal(10000, Square100x100().ToPolygonSet().AreaD);
            Assert.Equal(100, Square10x10().ToPolygonSet().AreaD);
            Assert.Equal(2500, Square50x50().ToPolygonSet().AreaD);
            Assert.Equal(5000, TriangleA().ToPolygonSet().AreaD);
            Assert.Equal(7500, Square100x100WithHole().ToPolygonSet().AreaD);
        }

        [Fact]
        public void Bounds()
        {
            Assert.Equal(
                new VectorEnvelope<TVector>(TVector.Create(45, 45), TVector.Create(55, 55)),
                Square10x10().ToPolygonSet().Bounds);

            Assert.Equal(
                new VectorEnvelope<TVector>(TVector.Create(45, 45), TVector.Create(55, 55)),
                Square10x10().ToPolygonSet().Union(Square10x10()).Bounds);

        }

        [Fact]
        public void SubstractToMultiPolygon_PolygonSet()
        {
            var result = Square100x100().ToPolygonSet().SubstractToMultiPolygon(Square50x50().ToPolygonSet());
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 25, 25 75, 75 75, 75 25, 25 25))", polygon.ToString());

            result = Square50x50().ToPolygonSet().SubstractToMultiPolygon(Square100x100().ToPolygonSet());
            Assert.Empty(result);

            result = Square100x100().ToPolygonSet().SubstractToMultiPolygon(Square100x100WithHole().ToPolygonSet());
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((75 25, 75 75, 25 75, 25 25, 75 25))", polygon.ToString());
        }

        [Fact]
        public void SubstractToMultiPolygon_Polygon()
        {
            var result = Square100x100().ToPolygonSet().SubstractToMultiPolygon(Square50x50());
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());

            result = Square50x50().ToPolygonSet().SubstractToMultiPolygon(Square100x100());
            Assert.Empty(result);

            result = Square100x100().ToPolygonSet().SubstractToMultiPolygon(Square100x100WithHole());
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((75 25, 75 75, 25 75, 25 25, 75 25))", polygon.ToString());
        }

        [Fact]
        public void UnionToMultiPolygon_PolygonSet()
        {
            var result = Square100x100().ToPolygonSet().UnionToMultiPolygon(Square50x50().ToPolygonSet());
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());
        }

        [Fact]
        public void UnionToMultiPolygon_Polygon()
        {
            var result = Square100x100().ToPolygonSet().UnionToMultiPolygon(Square50x50());
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());
        }






        [Fact]
        public void Substract_PolygonSet()
        {
            var result = Square100x100().ToPolygonSet().Substract(Square50x50().ToPolygonSet()).ToMultiPolygon();
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());

            result = Square50x50().ToPolygonSet().Substract(Square100x100().ToPolygonSet()).ToMultiPolygon();
            Assert.Empty(result);

            result = Square100x100().ToPolygonSet().Substract(Square100x100WithHole().ToPolygonSet()).ToMultiPolygon();
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((75 75, 25 75, 25 25, 75 25, 75 75))", polygon.ToString());
        }

        [Fact]
        public void Substract_Polygon()
        {
            var result = Square100x100().ToPolygonSet().Substract(Square50x50()).ToMultiPolygon();
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());

            result = Square50x50().ToPolygonSet().Substract(Square100x100()).ToMultiPolygon();
            Assert.Empty(result);

            result = Square100x100().ToPolygonSet().Substract(Square100x100WithHole()).ToMultiPolygon();
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((75 75, 25 75, 25 25, 75 25, 75 75))", polygon.ToString());
        }

        [Fact]
        public void Union_PolygonSet()
        {
            var result = Square100x100().ToPolygonSet().Union(Square50x50().ToPolygonSet()).ToMultiPolygon();
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());
        }

        [Fact]
        public void Union_Polygon()
        {
            var result = Square100x100().ToPolygonSet().Union(Square50x50()).ToMultiPolygon();
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());
        }

        [Fact]
        public void PolygonSetToString()
        {
            Assert.Equal("POLYGONSET ((100 100, 0 100, 0 0, 100 0))", Square100x100().ToPolygonSet().ToString());
            Assert.Equal("POLYGONSET ((100 100, 0 100, 0 0, 100 0), (25 75, 75 75, 75 25, 25 25))", Square100x100WithHole().ToPolygonSet().ToString());
            Assert.Equal("POLYGONSET EMPTY", new PolygonSet<TPrimitive,TVector>(new Clipper2Lib.Paths64(), ShapeSettings<TPrimitive,TVector>.Default).ToString());
        }

        [Fact]
        public void Transform()
        {
            Assert.Equal("POLYGONSET ((550 450, 550 550, 450 550, 450 450))", Square10x10().ToPolygonSet().Transforms().Scale(10).ToString());
            Assert.Equal("POLYGONSET ((1000 1000, 0 1000, 0 0, 1000 0), (250 750, 750 750, 750 250, 250 250))", Square100x100WithHole().ToPolygonSet().Transforms().Scale(10).ToString());
        }
    }
}
