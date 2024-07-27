using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Collections
{
    public class ReadOnlyArrayBuilderTest
    {

        [Fact]
        public void Prepend()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.Prepend(1);

            Assert.Equal(1, Assert.Single(builder));

            builder.Prepend(2);

            Assert.Equal([2, 1], builder);

            builder.Prepend(3);

            Assert.Equal([3, 2, 1], builder);

            builder.Prepend(4);

            Assert.Equal([4, 3, 2, 1], builder);

            builder.Prepend(5);

            Assert.Equal([5, 4, 3, 2, 1], builder);

            builder.Prepend(6);

            Assert.Equal([6, 5, 4, 3, 2, 1], builder);

            var snapshot = builder.Build();
            builder.Prepend(7);

            Assert.Equal([7, 6, 5, 4, 3, 2, 1], builder);
            Assert.Equal([6, 5, 4, 3, 2, 1], snapshot);
        }


        [Fact]
        public void AddRange_Span()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.AddRange(new ReadOnlySpan<int>([1, 2])); // No resize
            Assert.Equal([1, 2], builder);

            builder.AddRange(new ReadOnlySpan<int>([3, 4, 5, 6])); // Need resize
            Assert.Equal([1, 2, 3, 4, 5, 6], builder);
        }

        [Fact]
        public void AddRange_ReadOnlyArray()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.AddRange(new ReadOnlyArray<int>([1, 2])); // No resize
            Assert.Equal([1, 2], builder);

            builder.AddRange(new ReadOnlyArray<int>([3, 4, 5, 6])); // Need resize
            Assert.Equal([1, 2, 3, 4, 5, 6], builder);
        }

        [Fact]
        public void AddRange_Collection()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.AddRange([1, 2]); // No resize
            Assert.Equal([1, 2], builder);

            builder.AddRange([3, 4, 5, 6]); // Need resize
            Assert.Equal([1, 2, 3, 4, 5, 6], builder);
        }

        [Fact]
        public void AddRange_Enumerable()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.AddRange(Enumerable.Range(1, 2)); // No resize
            Assert.Equal([1, 2], builder);

            builder.AddRange(Enumerable.Range(3, 4)); // Need resize
            Assert.Equal([1, 2, 3, 4, 5, 6], builder);
        }

        [Fact]
        public void Slice()
        {
            var builder = new ReadOnlyArrayBuilder<int>();
            builder.AddRange([1, 2, 3, 4, 5, 6]);
            Assert.Equal([1, 2, 3, 4, 5, 6], builder);

            Assert.Equal([3, 4, 5, 6], builder.Slice(2).ToArray());
            Assert.Equal([3, 4], builder.Slice(2, 2).ToArray());
            Assert.Equal([3, 4, 5, 6], builder.Slice(2, 4).ToArray());
            Assert.Equal([], builder.Slice(6).ToArray());

            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(7));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(8));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(4, 4));

            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.Slice(2, -1));
        }

    }
}
