using System.Numerics;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Test.Algorithms
{
    public abstract class PathFollowerTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int Integer(TPrimitive v);

        [Fact]
        public void FollowPath_Move()
        {
            var follow = new PathFollower<TPrimitive,TVector>([
                Vector(0, 0),
                Vector(0, 4),
                Vector(0, 8),
                Vector(0, 12)]);

            Assert.Equal(Vector(0, 0), follow.Current);
            Assert.Equal(1, follow.Index);
            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 3), follow.Current);
            Assert.Equal(1, follow.Index);
            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 6), follow.Current);
            Assert.Equal(2, follow.Index);
            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 9), follow.Current);
            Assert.Equal(3, follow.Index);
            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 12), follow.Current);
            Assert.Equal(3, follow.Index);
            Assert.False(follow.Move(3f));

            follow = new PathFollower<TPrimitive, TVector>([
                Vector(0, 0),
                Vector(4, 0),
                Vector(8, 0),
                Vector(12, 0)]);

            Assert.Equal(Vector(0, 0), follow.Current);
            Assert.Equal(1, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(2, 0), follow.Current);
            Assert.Equal(1, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(4, 0), follow.Current);
            Assert.Equal(1, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(6, 0), follow.Current);
            Assert.Equal(2, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(8, 0), follow.Current);
            Assert.Equal(2, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(10, 0), follow.Current);
            Assert.Equal(3, follow.Index);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(12, 0), follow.Current);
            Assert.Equal(3, follow.Index);
            Assert.False(follow.Move(2f));

            follow = new PathFollower<TPrimitive, TVector>([
                Vector(0, 0),
                Vector(4, 0),
                Vector(4, 4),
                Vector(0, 4)]);

            Assert.Equal(Vector(0, 0), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(2, 0), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(4, 0), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(4, 2), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(4, 4), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(2, 4), follow.Current);
            Assert.True(follow.Move(2f));
            Assert.Equal(Vector(0, 4), follow.Current);
            Assert.False(follow.Move(2f));
        }

        [Fact]
        public void FollowPath_KeepRightAngles()
        {
            var follow = new PathFollower<TPrimitive, TVector>([
                Vector(0, 0),
                Vector(0, 4),
                Vector(4, 4),
                Vector(4, 0)], true);

            Assert.Equal(TVector.Zero, follow.Previous);
            Assert.Equal(Vector(0, 0), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 0), follow.Previous);
            Assert.Equal(Vector(0, 3), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 3), follow.Previous);
            Assert.Equal(Vector(0, 4), follow.Current);
            Assert.True(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(0, 4), follow.Previous);
            Assert.Equal(Vector(3, 4), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(2, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(3, 4), follow.Previous);
            Assert.Equal(Vector(4, 4), follow.Current);
            Assert.True(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(2, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(4, 4), follow.Previous);
            Assert.Equal(Vector(4, 1), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(3, follow.Index);

            Assert.True(follow.Move(3f));
            Assert.Equal(Vector(4, 1), follow.Previous);
            Assert.Equal(Vector(4, 0), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.True(follow.IsLast);
            Assert.Equal(3, follow.Index);

            Assert.False(follow.Move(3f));
        }


        [Fact]
        public void FollowPath_KeepRightAngles_ExactMatch()
        {
            var follow = new PathFollower<TPrimitive, TVector>([
                Vector(0, 0),
                Vector(0, 10),
                Vector(10, 10)], true);

            Assert.Equal(TVector.Zero, follow.Previous);
            Assert.Equal(Vector(0, 0), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(5f));
            Assert.Equal(Vector(0, 0), follow.Previous);
            Assert.Equal(Vector(0, 5), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(5f));
            Assert.Equal(Vector(0, 5), follow.Previous);
            Assert.Equal(Vector(0, 10), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(1, follow.Index);

            Assert.True(follow.Move(5f));
            Assert.Equal(Vector(0, 10), follow.Previous);
            Assert.Equal(Vector(5, 10), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(2, follow.Index);
            Assert.True(follow.Move(5f));

            Assert.Equal(Vector(5, 10), follow.Previous);
            Assert.Equal(Vector(10, 10), follow.Current);
            Assert.False(follow.IsAfterRightAngle);
            Assert.False(follow.IsLast);
            Assert.Equal(2, follow.Index);
        }
    }
}
