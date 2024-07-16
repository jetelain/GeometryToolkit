using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class PathSegmentTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int Integer(TPrimitive v);

        [Fact]
        public void FromPath_BasicSquare()
        {
            var path = new Path<TPrimitive,TVector>(Vector(0, 0), Vector(10, 0), Vector(10, 10), Vector(0, 10), Vector(0, 0));
            Assert.True(path.IsClosed);
            Assert.True(path.IsCounterClockWise);
            var segments = PathSegment<TPrimitive, TVector>.FromPath(path);
            Assert.Equal(4, segments.Count);

            var segment = segments[0];
            Assert.Equal(new [] { Vector(0, 0), Vector(10, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[1];
            Assert.Equal(new [] { Vector(10, 0), Vector(10, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[2];
            Assert.Equal(new [] { Vector(10, 10), Vector(0, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[3];
            Assert.Equal(new [] { Vector(0, 10), Vector(0, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);
        }

        [Fact]
        public void FromPath_BasicSquare_Clockwise()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10), Vector(10, 0), Vector(0, 0));
            Assert.True(path.IsClosed);
            Assert.False(path.IsCounterClockWise);
            var segments = PathSegment<TPrimitive, TVector>.FromPath(path);
            Assert.Equal(4, segments.Count);

            var segment = segments[0];
            Assert.Equal(new [] { Vector(0, 0), Vector(0, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(-90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[1];
            Assert.Equal(new [] { Vector(0, 10), Vector(10, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(-90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[2];
            Assert.Equal(new [] { Vector(10, 10), Vector(10, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(-90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[3];
            Assert.Equal(new [] { Vector(10, 0), Vector(0, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(-90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);
        }


        [Fact]
        public void FromPath_BasicLine()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 10), Vector(0, 20), Vector(0, 30), Vector(0, 40));
            Assert.False(path.IsClosed);
            Assert.Equal(40, path.LengthD);
            var segment = Assert.Single(PathSegment<TPrimitive, TVector>.FromPath(path));

            Assert.Equal(new [] { Vector(0, 0), Vector(0, 10), Vector(0, 20), Vector(0, 30), Vector(0, 40) }, segment.Points);
            Assert.Equal(40, segment.LengthD);
            Assert.False(segment.HasNext);
            Assert.False(segment.IsClosed);

            path = new (Vector(0, 0), Vector(0, 10));
            Assert.False(path.IsClosed);
            Assert.Equal(10, path.LengthD);
            segment = Assert.Single(PathSegment<TPrimitive, TVector>.FromPath(path));

            Assert.Equal(new [] { Vector(0, 0), Vector(0, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.False(segment.HasNext);
            Assert.False(segment.IsClosed);
        }

        [Fact]
        public void FromPath_OpenSquare()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(5, 0), Vector(10, 0), Vector(10, 10), Vector(5, 10), Vector(0, 10));
            Assert.False(path.IsClosed);
            var segments = PathSegment<TPrimitive, TVector>.FromPath(path);
            Assert.Equal(3, segments.Count);

            var segment = segments[0];
            Assert.Equal(new [] { Vector(0, 0), Vector(5, 0), Vector(10, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[1];
            Assert.Equal(new [] { Vector(10, 0), Vector(10, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[2];
            Assert.Equal(new [] { Vector(10, 10), Vector(5, 10), Vector(0, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.False(segment.HasNext);
            Assert.False(segment.IsClosed);
        }

        [Fact]
        public void FromPath_ShiftSquare()
        {
            var path = new Path<TPrimitive, TVector>(Vector(5, 0), Vector(10, 0), Vector(10, 10), Vector(0, 10), Vector(0, 5), Vector(0, 0), Vector(5, 0));
            Assert.True(path.IsClosed);
            var segments = PathSegment<TPrimitive, TVector>.FromPath(path);
            Assert.Equal(4, segments.Count);

            var segment = segments[0];
            Assert.Equal(new [] { Vector(0, 0), Vector(5, 0), Vector(10, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[1];
            Assert.Equal(new [] { Vector(10, 0), Vector(10, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[2];
            Assert.Equal(new [] { Vector(10, 10), Vector(0, 10) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);

            segment = segments[3];
            Assert.Equal(new [] { Vector(0, 10), Vector(0, 5), Vector(0, 0) }, segment.Points);
            Assert.Equal(10, segment.LengthD);
            Assert.True(segment.HasNext);
            Assert.Equal(90, segment.DegreesWithNext);
            Assert.False(segment.IsClosed);
        }
    }
}
