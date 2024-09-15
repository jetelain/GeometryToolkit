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

        [Fact]
        public void Empty()
        {
            Assert.Empty(MultiPath<TPrimitive, TVector>.Empty);
        }

    }
}
