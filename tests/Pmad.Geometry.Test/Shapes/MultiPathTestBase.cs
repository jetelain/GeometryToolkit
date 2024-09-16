using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class MultiPathTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected virtual TVector Vector(int x, int y) => TVector.Create(x, y);
        protected virtual int Integer(TPrimitive v) => int.CreateTruncating(v);
        protected virtual IReadOnlyList<TVector> Truncate(ReadOnlyArray<TVector> array) => array;

        private Path<TPrimitive, TVector> GetPath1()
        {
            return new Path<TPrimitive, TVector>(Vector(1000, 1000), Vector(1000, 1010), Vector(1010, 1010));
        }

        private Path<TPrimitive, TVector> GetPath0()
        {
            return new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10));
        }

        [Fact]
        public void Empty()
        {
            Assert.Empty(MultiPath<TPrimitive, TVector>.Empty);
        }

        [Fact]
        public void Indexer()
        {
            var path0 = GetPath0();
            var path1 = GetPath1();

            var multi = new MultiPath<TPrimitive, TVector>(path0, path1);

            Assert.Equal(path0, multi[0]);
            Assert.Equal(path1, multi[1]);

            Assert.Equal([path0, path1], multi);
        }

        [Fact]
        public void Bounds()
        {
            var path0 = GetPath0();
            var path1 = GetPath1();

            Assert.Equal(VectorEnvelope<TVector>.None, MultiPath<TPrimitive, TVector>.Empty.Bounds);
            Assert.Equal(new VectorEnvelope<TVector>(Vector(0, 0), Vector(10, 10)), new MultiPath<TPrimitive, TVector>(path0).Bounds);
            Assert.Equal(new VectorEnvelope<TVector>(Vector(0, 0), Vector(1010, 1010)), new MultiPath<TPrimitive, TVector>(path0, path1).Bounds);
        }

        [Fact]
        public void MultiPathToString()
        {
            Assert.Equal("MULTILINESTRING EMPTY", MultiPath<TPrimitive, TVector>.Empty.ToString());
            Assert.Equal("MULTILINESTRING ((0 0, 0 10, 10 10), (1000 1000, 1000 1010, 1010 1010))", new MultiPath<TPrimitive, TVector>(GetPath0(), GetPath1()).ToString());
        }
    }
}
