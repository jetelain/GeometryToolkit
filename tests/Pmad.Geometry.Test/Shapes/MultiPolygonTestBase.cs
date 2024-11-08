using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class MultiPolygonTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected virtual TVector Vector(int x, int y) => TVector.Create(x, y);
        protected virtual int Integer(TPrimitive v) => int.CreateTruncating(v);
        protected virtual TVector Truncate(TVector v) => v;

        private Polygon<TPrimitive, TVector> Square100x100()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(100, 100), Vector(0, 100), Vector(0, 0), Vector(100, 0), Vector(100, 100)));
        }
        private Polygon<TPrimitive, TVector> Square100x100Far()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(Vector(1100, 1100), Vector(1000, 1100), Vector(1000, 1000), Vector(1100, 1000), Vector(1100, 1100)));
        }


        [Fact]
        public void Empty()
        {
            Assert.Empty(MultiPolygon<TPrimitive, TVector>.Empty);
        }

        [Fact]
        public void AreaD()
        {
            Assert.Equal(0, MultiPolygon<TPrimitive, TVector>.Empty.AreaD);
            Assert.Equal(10000, new MultiPolygon<TPrimitive, TVector>(Square100x100()).AreaD);
            Assert.Equal(20000, new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far()).AreaD);
        }

        [Fact]
        public void Bounds()
        {
            Assert.Equal(VectorEnvelope<TVector>.None, MultiPolygon<TPrimitive, TVector>.Empty.Bounds);
            Assert.Equal(new VectorEnvelope<TVector>(Vector(0, 0), Vector(100, 100)), new MultiPolygon<TPrimitive, TVector>(Square100x100()).Bounds);
            Assert.Equal(new VectorEnvelope<TVector>(Vector(0, 0), Vector(1100, 1100)), new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far()).Bounds);
        }

        [Fact]
        public void Count()
        {
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
            Assert.Equal(0, MultiPolygon<TPrimitive, TVector>.Empty.Count);
            Assert.Equal(1, new MultiPolygon<TPrimitive, TVector>(Square100x100()).Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
            Assert.Equal(2, new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far()).Count);
        }

        [Fact]
        public void IsInside()
        {
            var multi = new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far());
            Assert.True(multi.IsInside(Vector(50, 50)));
            Assert.True(multi.IsInside(Vector(1050, 1050)));

            Assert.False(multi.IsInside(Vector(500, 500)));
            Assert.False(multi.IsInside(Vector(0, 0)));
            Assert.False(multi.IsInside(Vector(100, 100)));
        }

        [Fact]
        public void Contains()
        {
            var multi = new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far());
            Assert.True(multi.Contains(Vector(50, 50)));
            Assert.True(multi.Contains(Vector(1050, 1050)));
            Assert.True(multi.Contains(Vector(0, 0)));
            Assert.True(multi.Contains(Vector(100, 100)));

            Assert.False(multi.Contains(Vector(500, 500)));
        }

        [Fact]
        public void MultiPolygonToString()
        {
            Assert.Equal("MULTIPOLYGON EMPTY", MultiPolygon<TPrimitive, TVector>.Empty.ToString());
            Assert.Equal("MULTIPOLYGON (((100 100, 0 100, 0 0, 100 0, 100 100)), ((1100 1100, 1000 1100, 1000 1000, 1100 1000, 1100 1100)))", new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far()).ToString());
        }

        [Fact]
        public void Indexer()
        {
            var poly0 = Square100x100();
            var poly1 = Square100x100Far();
            var multi = new MultiPolygon<TPrimitive, TVector>(poly0, poly1);
            
            Assert.Equal(poly0, multi[0]);
            Assert.Equal(poly1, multi[1]);

            Assert.Equal([poly0, poly1], multi);
        }

        [Fact]
        public void Transforms()
        {
            Assert.Equal("MULTIPOLYGON (((1000 1000, 0 1000, 0 0, 1000 0, 1000 1000)), ((11000 11000, 10000 11000, 10000 10000, 11000 10000, 11000 11000)))", new MultiPolygon<TPrimitive, TVector>(Square100x100(), Square100x100Far()).Transforms().Scale(10).ToString());
        }
    }
}
