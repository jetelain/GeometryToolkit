using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class PathTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int Integer(TPrimitive v);

        protected virtual IReadOnlyList<TVector> Truncate(ReadOnlyArray<TVector> array) => array;

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
            Assert.Equal(new [] { Vector(50, 25), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 175) }, Assert.Single(clip).Points);

            clip = path.ClippedBy(new(Vector(25, 0), Vector(75, 200))).ToList();
            Assert.Equal(path.Points, Assert.Single(clip).Points);

            clip = path.ClippedBy(new(Vector(100, -100), Vector(100, 300))).ToList();
            Assert.Empty(clip);

            path = new Path<TPrimitive, TVector>(
                Vector(171092, -145028), Vector(165912, -127012), Vector(161637, -113047),  Vector(155082, -94807), Vector(148736, -78253), 
                Vector(133950,  -43828), Vector(132587,  -40079), Vector(131705,  -37929),  Vector(131410, -36709), Vector(130544, -34267), 
                Vector(127949,  -25890), Vector(116996,   10666), Vector(107961,   41112));
            clip = path.ClippedBy(new(Vector(0, 0), Vector(260000, 260000))).ToList();
            Assert.Equal(new [] { Vector(120191, 0), Vector(116996, 10666), Vector(107961, 41112) }, Truncate(Assert.Single(clip).Points));
        }

        [Fact]
        public void ClippedBy_Reversed()
        {
            var path = new Path<TPrimitive, TVector>(Vector(50, 00), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 200)).ToReverse();
            var clip = path.ClippedBy(new(Vector(25, 25), Vector(75, 175))).ToList();
            Assert.Equal(new[] { Vector(50, 175), Vector(50, 150), Vector(50, 100), Vector(50, 50), Vector(50, 25) }, Assert.Single(clip).Points);

            clip = path.ClippedBy(new(Vector(25, 0), Vector(75, 200))).ToList();
            Assert.Equal(path.Points, Assert.Single(clip).Points);

            clip = path.ClippedBy(new(Vector(100, -100), Vector(100, 300))).ToList();
            Assert.Empty(clip);

            path = new Path<TPrimitive, TVector>(
                Vector(171092, -145028), Vector(165912, -127012), Vector(161637, -113047), Vector(155082, -94807), Vector(148736, -78253),
                Vector(133950, -43828), Vector(132587, -40079), Vector(131705, -37929), Vector(131410, -36709), Vector(130544, -34267),
                Vector(127949, -25890), Vector(116996, 10666), Vector(107961, 41112)).ToReverse();
            clip = path.ClippedBy(new(Vector(0, 0), Vector(260000, 260000))).ToList();
            Assert.Equal(new[] { Vector(107961, 41112), Vector(116996, 10666), Vector(120191, 0) }, Truncate(Assert.Single(clip).Points));
        }

        [Fact]
        public void ClippedBy_ClosedPath()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 50), Vector(50, 50), Vector(50, 0), Vector(0, 0));

            var clip = path.ClippedBy(new(Vector(-10, -10), Vector(60, 25))).ToList();
            Assert.Equal(2, clip.Count);
            Assert.Equal(new[] { Vector(0, 0), Vector(0, 25) }, clip[0].Points);
            Assert.Equal(new[] { Vector(50, 25), Vector(50, 0), Vector(0, 0) }, clip[1].Points);
            // Note: It would be also acceptable to have a single path with new [] { new(50, 25), new(50, 0), new(0, 0), new(0, 25)}

            clip = path.ClippedBy(new(Vector(-10, 25), Vector(60, 60))).ToList();
            var clipPath = Assert.Single(clip);
            Assert.Equal(new[] { Vector(0, 25), Vector(0, 50), Vector(50, 50), Vector(50, 25) }, clipPath.Points);

            clip = path.ClippedBy(new(Vector(-10, -10), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new[] { Vector(0, 0), Vector(0, 50), Vector(50, 50), Vector(50, 0), Vector(0, 0) }, clipPath.Points);

            // Same reversed

            path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(50, 0), Vector(50, 50), Vector(0, 50), Vector(0, 0));

            clip = path.ClippedBy(new(Vector(-10, -10), Vector(60, 25))).ToList();
            Assert.Equal(2, clip.Count);
            Assert.Equal(new[] { Vector(0, 0), Vector(50, 0), Vector(50, 25) }, clip[0].Points);
            Assert.Equal(new[] { Vector(0, 25), Vector(0, 0) }, clip[1].Points);
            // Note: It would be also acceptable to have a single path with new [] { new(0, 25), new(0, 0), new(50, 0), new(50, 25)}

            clip = path.ClippedBy(new(Vector(-10, 25), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new[] { Vector(50, 25), Vector(50, 50), Vector(0, 50), Vector(0, 25) }, clipPath.Points);

            clip = path.ClippedBy(new(Vector(-10, -10), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new[] { Vector(0, 0), Vector(50, 0), Vector(50, 50), Vector(0, 50), Vector(0, 0) }, clipPath.Points);

        }


        [Fact]
        public void ClippedByKeepOrientation()
        {
            var path = new Path<TPrimitive, TVector>(Vector(50, 00), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 200));
            var clip = path.ClippedByKeepOrientation(new(Vector(25, 25), Vector(75, 175))).ToList();
            Assert.Equal(new[] { Vector(50, 25), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 175) }, Assert.Single(clip).Points);

            clip = path.ClippedByKeepOrientation(new(Vector(25, 0), Vector(75, 200))).ToList();
            Assert.Equal(path.Points, Assert.Single(clip).Points);

            clip = path.ClippedByKeepOrientation(new(Vector(100, -100), Vector(100, 300))).ToList();
            Assert.Empty(clip);

            path = new Path<TPrimitive, TVector>(
                Vector(171092, -145028), Vector(165912, -127012), Vector(161637, -113047), Vector(155082, -94807), Vector(148736, -78253),
                Vector(133950, -43828), Vector(132587, -40079), Vector(131705, -37929), Vector(131410, -36709), Vector(130544, -34267),
                Vector(127949, -25890), Vector(116996, 10666), Vector(107961, 41112));
            clip = path.ClippedByKeepOrientation(new(Vector(0, 0), Vector(260000, 260000))).ToList();
            Assert.Equal(new[] { Vector(120191, 0), Vector(116996, 10666), Vector(107961, 41112) }, Truncate(Assert.Single(clip).Points));
        }

        [Fact]
        public void ClippedByKeepOrientation_Reversed()
        {
            var path = new Path<TPrimitive, TVector>(Vector(50, 00), Vector(50, 50), Vector(50, 100), Vector(50, 150), Vector(50, 200)).ToReverse();
            var clip = path.ClippedByKeepOrientation(new(Vector(25, 25), Vector(75, 175))).ToList();
            Assert.Equal(new[] { Vector(50, 175), Vector(50, 150), Vector(50, 100), Vector(50, 50), Vector(50, 25) }, Assert.Single(clip).Points);

            clip = path.ClippedByKeepOrientation(new(Vector(25, 0), Vector(75, 200))).ToList();
            Assert.Equal(path.Points, Assert.Single(clip).Points);

            clip = path.ClippedByKeepOrientation(new(Vector(100, -100), Vector(100, 300))).ToList();
            Assert.Empty(clip);

            path = new Path<TPrimitive, TVector>(
                Vector(171092, -145028), Vector(165912, -127012), Vector(161637, -113047), Vector(155082, -94807), Vector(148736, -78253),
                Vector(133950, -43828), Vector(132587, -40079), Vector(131705, -37929), Vector(131410, -36709), Vector(130544, -34267),
                Vector(127949, -25890), Vector(116996, 10666), Vector(107961, 41112)).ToReverse();
            clip = path.ClippedByKeepOrientation(new(Vector(0, 0), Vector(260000, 260000))).ToList();
            Assert.Equal(new[] { Vector(107961, 41112), Vector(116996, 10666), Vector(120191, 0) }, Truncate(Assert.Single(clip).Points));
        }


        [Fact]
        public void ClippedByKeepOrientation_ClosedPath()
        {
            var path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(0, 50), Vector(50, 50), Vector(50, 0), Vector(0, 0));

            var clip = path.ClippedByKeepOrientation(new (Vector(-10, -10), Vector(60, 25))).ToList();
            Assert.Equal(2, clip.Count);
            Assert.Equal(new [] { Vector(0, 0), Vector(0, 25) }, clip[0].Points);
            Assert.Equal(new [] { Vector(50, 25), Vector(50, 0), Vector(0, 0) }, clip[1].Points);
            // Note: It would be also acceptable to have a single path with new [] { new(50, 25), new(50, 0), new(0, 0), new(0, 25)}

            clip = path.ClippedByKeepOrientation(new(Vector(-10, 25), Vector(60, 60))).ToList();
            var clipPath = Assert.Single(clip);
            Assert.Equal(new [] { Vector(0, 25), Vector(0, 50), Vector(50, 50), Vector(50, 25) }, clipPath.Points);

            clip = path.ClippedByKeepOrientation(new(Vector(-10, -10), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new [] { Vector(0, 0), Vector(0, 50), Vector(50, 50), Vector(50, 0), Vector(0, 0) }, clipPath.Points);

            // Same reversed

            path = new Path<TPrimitive, TVector>(Vector(0, 0), Vector(50, 0), Vector(50, 50), Vector(0, 50), Vector(0, 0));

            clip = path.ClippedByKeepOrientation(new(Vector(-10, -10), Vector(60, 25))).ToList();
            Assert.Equal(2, clip.Count);
            Assert.Equal(new[] { Vector(0, 0), Vector(50, 0), Vector(50, 25) }, clip[0].Points);
            Assert.Equal(new [] { Vector(0, 25), Vector(0, 0) }, clip[1].Points);
            // Note: It would be also acceptable to have a single path with new [] { new(0, 25), new(0, 0), new(50, 0), new(50, 25)}

            clip = path.ClippedByKeepOrientation(new(Vector(-10, 25), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new [] { Vector(50, 25), Vector(50, 50), Vector(0, 50), Vector(0, 25) }, clipPath.Points);

            clip = path.ClippedByKeepOrientation(new(Vector(-10, -10), Vector(60, 60))).ToList();
            clipPath = Assert.Single(clip);
            Assert.Equal(new [] { Vector(0, 0), Vector(50, 0), Vector(50, 50), Vector(0, 50), Vector(0, 0) }, clipPath.Points);

        }
    }
}
