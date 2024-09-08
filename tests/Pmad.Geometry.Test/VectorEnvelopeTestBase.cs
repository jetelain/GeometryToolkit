using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test
{
    public abstract class VectorEnvelopeTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract TPrimitive Scalar(int v);


        private VectorEnvelope<TVector> Create(int x1, int y1, int x2, int y2)
        {
            return new VectorEnvelope<TVector>(Vector(x1, y1), Vector(x2, y2));
        }

        [Fact]
        public void ContainsEnvelope()
        {
            Assert.True(Create(0, 0, 100, 100).Contains(Create(0, 0, 100, 100)));
            Assert.True(Create(0, 0, 100, 100).Contains(Create(10, 10, 90, 90)));
            Assert.True(Create(0, 0, 100, 100).Contains(Create(0, 0, 90, 100)));
            Assert.True(Create(0, 0, 100, 100).Contains(Create(0, 0, 100, 90)));
            Assert.True(Create(0, 0, 100, 100).Contains(Create(10, 0, 100, 100)));
            Assert.True(Create(0, 0, 100, 100).Contains(Create(0, 10, 100, 100)));

            Assert.False(Create(0, 0, 100, 100).Contains(Create(10, 10, 150, 150)));
            Assert.False(Create(0, 0, 100, 100).Contains(Create(10, 10, 90, 150)));
            Assert.False(Create(0, 0, 100, 100).Contains(Create(10, 10, 150, 90)));

            Assert.False(Create(0, 0, 100, 100).Contains(Create(-10, 0, 90, 90)));
            Assert.False(Create(0, 0, 100, 100).Contains(Create(0, -10, 90, 90)));
            Assert.False(Create(0, 0, 100, 100).Contains(Create(-10, -10, 90, 90)));

            Assert.False(Create(0, 0, 100, 100).Contains(Create(1000, 1000, 1100, 1100)));
        }

        [Fact]
        public void IntersectsEnvelope()
        {
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(0, 0, 100, 100)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(10, 10, 90, 90)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(0, 0, 90, 100)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(0, 0, 100, 90)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(10, 0, 100, 100)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(0, 10, 100, 100)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(10, 10, 150, 150)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(10, 10, 90, 150)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(10, 10, 150, 90)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(-10, 0, 90, 90)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(0, -10, 90, 90)));
            Assert.True(Create(0, 0, 100, 100).Intersects(Create(-10, -10, 90, 90)));

            Assert.False(Create(0, 0, 100, 100).Intersects(Create(1000, 1000, 1100, 1100)));
            Assert.False(Create(0, 0, 100, 100).Intersects(Create(-1000, -1000, -1100, -1100)));
            Assert.False(Create(0, 0, 100, 100).Intersects(Create(1000, 0, 1100, 100)));
            Assert.False(Create(0, 0, 100, 100).Intersects(Create(0, 1000, 100, 1100)));
        }

        [Fact]
        public void None()
        {
            Assert.Equal(Create(0, 0, 0, 0), VectorEnvelope<TVector>.None);
        }

        [Fact]
        public void FromListReadOnlyArray()
        {
            Assert.Equal(VectorEnvelope<TVector>.None, VectorEnvelope<TVector>.FromList(new ReadOnlyArray<TVector>()));
            Assert.Equal(Create(10, 20, 10, 20), VectorEnvelope<TVector>.FromList(new ReadOnlyArray<TVector>(Vector(10, 20))));
            Assert.Equal(Create(10, 20, 30, 40), VectorEnvelope<TVector>.FromList(new ReadOnlyArray<TVector>(Vector(30, 40), Vector(10, 20))));
            Assert.Equal(Create(10, 20, 50, 60), VectorEnvelope<TVector>.FromList(new ReadOnlyArray<TVector>(Vector(30, 40), Vector(50, 60), Vector(10, 20))));
        }

        [Fact]
        public void FromPoints()
        {
            Assert.Equal(Create(10, 20, 10, 20), VectorEnvelope<TVector>.FromPoints(Vector(10, 20), Vector(10, 20)));
            Assert.Equal(Create(10, 20, 30, 40), VectorEnvelope<TVector>.FromPoints(Vector(30, 40), Vector(10, 20)));
            Assert.Equal(Create(10, 20, 50, 60), VectorEnvelope<TVector>.FromPoints(Vector(10, 20), Vector(50, 60)));
        }

        [Fact]
        public void IEquatableEquals()
        {
            Assert.Equal(Create(10, 20, 30, 40), Create(10, 20, 30, 40));
            Assert.NotEqual(Create(15, 20, 30, 40), Create(10, 20, 30, 40));
            Assert.NotEqual(Create(10, 25, 30, 40), Create(10, 20, 30, 40));
            Assert.NotEqual(Create(10, 20, 35, 40), Create(10, 20, 30, 40));
            Assert.NotEqual(Create(10, 20, 30, 45), Create(10, 20, 30, 40));
        }

        [Fact]
        public void EqualsObject()
        {
            Assert.True(Create(10, 20, 30, 40).Equals((object)Create(10, 20, 30, 40)));
            Assert.False(Create(15, 20, 30, 40).Equals((object)Create(10, 20, 30, 40)));
            Assert.False(Create(10, 25, 30, 40).Equals((object)Create(10, 20, 30, 40)));
            Assert.False(Create(10, 20, 35, 40).Equals((object)Create(10, 20, 30, 40)));
            Assert.False(Create(10, 20, 30, 45).Equals((object)Create(10, 20, 30, 40)));
            Assert.False(Create(10, 20, 30, 45).Equals((object)"Hello world!"));
        }

        [Fact]
        public void GetHashcode()
        {
            Assert.Equal(Create(10, 20, 30, 40).GetHashCode(), Create(10, 20, 30, 40).GetHashCode());
            Assert.NotEqual(Create(10, 10, 10, 10).GetHashCode(), Create(10, 20, 30, 40).GetHashCode());
        }
    }
}
