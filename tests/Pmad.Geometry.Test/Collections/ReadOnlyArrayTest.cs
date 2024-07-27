using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Collections
{
    public class ReadOnlyArrayTest
    {
        [Fact]
        public void Slice()
        {
            var array = new ReadOnlyArray<int>([1, 2, 3, 4, 5, 6]);
            Assert.Equal([1, 2, 3, 4, 5, 6], array);

            Assert.Equal([3, 4, 5, 6], array.Slice(2).ToArray());
            Assert.Equal([3, 4], array.Slice(2, 2).ToArray());
            Assert.Equal([3, 4, 5, 6], array.Slice(2, 4).ToArray());
            Assert.Equal([], array.Slice(6).ToArray());

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(7));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(8));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(4, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(4, 4));

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(2, -1));
        }
    }
}
