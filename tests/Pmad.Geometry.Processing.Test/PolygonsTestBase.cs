using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Processing;

namespace Pmad.Geometry.Processing.Test
{
    public abstract class PolygonsTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);
        protected abstract int Integer(TPrimitive v);
        protected virtual TVector Truncate(TVector v) => v;

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
        public void UnionAllLargeConnected()
        {
            var result = new[] { Square100x100(), Square50x50() }.UnionAll(null, PolygonsMergeMode.LargeConnected);
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = new[] { Square100x100WithHole(), Square50x50(), Square10x10() }.UnionAll(null, PolygonsMergeMode.LargeConnected);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = SquareBands100x100WithHole().UnionAll(null, PolygonsMergeMode.LargeConnected);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 0, 100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0), (25 25, 25 75, 75 75, 75 25, 25 25))", polygon.ToString());
            Assert.Equal("POLYGON ((100 0, 100 100, 0 100, 0 0, 100 0), (25 25, 25 75, 75 75, 75 25, 25 25))", polygon.Simplify().ToString());

            result = SquareBands100x100WithHole().Concat(new[] { Square10x10() }).ToList().UnionAll(null, PolygonsMergeMode.LargeConnected);
            Assert.Equal(2, result.Count);
            polygon = result[0];
            Assert.Equal("POLYGON ((100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.Simplify().ToString());

            polygon = result[1];
            Assert.Equal("POLYGON ((55 45, 55 55, 45 55, 45 45, 55 45))", polygon.ToString());
        }

        [Fact]
        public void UnionAllSmallIsolated()
        {
            var result = new[] { Square100x100(), Square50x50() }.UnionAll(null, PolygonsMergeMode.SmallIsolated);
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = new[] { Square100x100WithHole(), Square50x50(), Square10x10() }.UnionAll(null, PolygonsMergeMode.SmallIsolated);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = SquareBands100x100WithHole().UnionAll(null, PolygonsMergeMode.SmallIsolated);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 0, 100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0), (25 25, 25 75, 75 75, 75 25, 25 25))", polygon.ToString());
            Assert.Equal("POLYGON ((100 0, 100 100, 0 100, 0 0, 100 0), (25 25, 25 75, 75 75, 75 25, 25 25))", polygon.Simplify().ToString());

            result = SquareBands100x100WithHole().Concat(new[] { Square10x10() }).ToList().UnionAll(null, PolygonsMergeMode.SmallIsolated);
            Assert.Equal(2, result.Count);
            polygon = result[0];
            Assert.Equal("POLYGON ((100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.Simplify().ToString());

            polygon = result[1];
            Assert.Equal("POLYGON ((55 45, 55 55, 45 55, 45 45, 55 45))", polygon.ToString());
        }

        [Fact]
        public void UnionAllPolygonSet()
        {
            var result = new[] { Square100x100(), Square50x50() }.UnionAll(null, PolygonsMergeMode.PolygonSet);
            var polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = new[] { Square100x100WithHole(), Square50x50(), Square10x10() }.UnionAll(null, PolygonsMergeMode.PolygonSet);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100))", polygon.ToString());

            result = SquareBands100x100WithHole().UnionAll(null, PolygonsMergeMode.PolygonSet);
            polygon = Assert.Single(result);
            Assert.Equal("POLYGON ((100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.Simplify().ToString());

            result = SquareBands100x100WithHole().Concat(new[] { Square10x10() }).ToList().UnionAll(null, PolygonsMergeMode.PolygonSet);
            Assert.Equal(2, result.Count);
            polygon = result[0];
            Assert.Equal("POLYGON ((100 100, 75 100, 25 100, 0 100, 0 75, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.ToString());
            Assert.Equal("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))", polygon.Simplify().ToString());

            polygon = result[1];
            Assert.Equal("POLYGON ((55 55, 45 55, 45 45, 55 45, 55 55))", polygon.ToString());
        }

        [Fact]
        public void FilterOverlaps()
        {
            var sq100 = Square100x100();
            var sq50 = Square50x50();
            var sq10 = Square10x10();
            var far = Square100x100Far();

            var result = new[] { sq10, sq50, sq100 }.FilterOverlaps();
            Assert.Equal(sq100, Assert.Single(result));

            result = new[] { sq10, sq50, sq100, far }.FilterOverlaps();
            Assert.Equal(2, result.Count);
            Assert.Equal(sq100, result[0]);
            Assert.Equal(far, result[1]);
        }

        [Fact]
        public async Task ParallelUnionAllToSet()
        {
            var polygons = Create(25);

            var result = await polygons.ParallelUnionAllToSet(2);
            Assert.Equal(1, result.Count);
            var polygon = Assert.Single(result.ToPolygonList());
            Assert.Equal(new(TVector.Create(0, 0), TVector.Create(100, 100)), polygon.Bounds);
            Assert.Equal(10000, polygon.AreaD);
        }


        [Fact]
        public async Task ParallelUnionAllToSet_Progess()
        {
            var progress = new ProgessScopeMock();
            var polygons = Create(25);

            var result = await polygons.ParallelUnionAllToSet(progress, "Name", 2); 
            Assert.Equal(1, result.Count);
            var polygon = Assert.Single(result.ToPolygonList());
            Assert.Equal(new(TVector.Create(0, 0), TVector.Create(100, 100)), polygon.Bounds);
            Assert.Equal(10000, polygon.AreaD);
            Assert.Equal(21, progress.Total);
            Assert.Equal(21, progress.Done);
        }

        // 

        [Fact]
        public async Task ParallelUnionAllToSet_Deep()
        {
            var polygons = Create(5);

            var result = await polygons.ParallelUnionAllToSet(2);
            Assert.Equal(1, result.Count);
            var polygon = Assert.Single(result.ToPolygonList());
            Assert.Equal(new(TVector.Create(0, 0), TVector.Create(100, 100)), polygon.Bounds);
            Assert.Equal(10000, polygon.AreaD);
        }

        private static List<Polygon<TPrimitive, TVector>> Create(int w = 25)
        {
            var polygons = new List<Polygon<TPrimitive, TVector>>();
            var settings = ShapeSettings<TPrimitive, TVector>.Default;
            for (int x = 0; x < 100; x += w)
            {
                for (int y = 0; y < 100; y += w)
                {
                    polygons.Add(settings.CreateRectanglePolygon(TVector.Create(x, y), TVector.Create(x + w, y + w)));
                }
            }
            return polygons;
        }
    }
}
