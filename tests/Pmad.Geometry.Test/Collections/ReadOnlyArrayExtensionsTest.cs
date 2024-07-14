using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Collections
{
    public class ReadOnlyArrayExtensionsTest
    {
        [Fact]
        public void Cast()
        {
            var source = new ReadOnlyArray<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);
            var expected = new ReadOnlyArray<object>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);

            var casted = source.Cast<int, object>();

            Assert.Equal(expected, casted);
            Assert.Equal(expected, casted.ToList());
        }

        [Fact]
        public void CopyAs()
        {
            var source = new ReadOnlyArray<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);
            var expected = new ReadOnlyArray<uint>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);

            var copyAs = source.CopyAs<int, uint>();

            Assert.Equal(expected, copyAs);
            Assert.Equal(expected, copyAs.ToList());
        }

        [Fact]
        public void UnsafeAs()
        {
            var source = new ReadOnlyArray<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);
            var expected = new ReadOnlyArray<uint>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0);

            var unsafeAs = source.UnsafeAs<int, uint>();

            Assert.Equal(expected, unsafeAs);
            Assert.Equal(expected, unsafeAs.ToList());
        }
    }
}
