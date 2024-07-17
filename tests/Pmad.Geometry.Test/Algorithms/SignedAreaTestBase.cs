using System.Numerics;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Test.Algorithms
{
    public abstract class SignedAreaTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract int Integer(TPrimitive v);


        [Fact]
        public void SignedAreaD()
        {
            var shell = new ReadOnlyArray<TVector>(Vector(0,0), Vector(0,10), Vector(10,10), Vector(10, 0), Vector(0,0));

            Assert.Equal(-100, SignedArea<TPrimitive,TVector>.GetSignedAreaClassicD(shell));
            Assert.Equal(-100, SignedArea<TPrimitive, TVector>.GetSignedAreaD(shell));

            shell = shell.ToReverse();

            Assert.Equal(100, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicD(shell));
            Assert.Equal(100, SignedArea<TPrimitive, TVector>.GetSignedAreaD(shell));

            shell = new ReadOnlyArray<TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10), Vector(0, 0));

            Assert.Equal(-50, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicD(shell));
            Assert.Equal(-50, SignedArea<TPrimitive, TVector>.GetSignedAreaD(shell));

            shell = shell.ToReverse();

            Assert.Equal(50, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicD(shell));
            Assert.Equal(50, SignedArea<TPrimitive, TVector>.GetSignedAreaD(shell));
        }


        [Fact]
        public void SignedAreaF()
        {
            var shell = new ReadOnlyArray<TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10), Vector(10, 0), Vector(0, 0));

            Assert.Equal(-100, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicF(shell));
            Assert.Equal(-100, SignedArea<TPrimitive, TVector>.GetSignedAreaF(shell));

            shell = shell.ToReverse();

            Assert.Equal(100, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicF(shell));
            Assert.Equal(100, SignedArea<TPrimitive, TVector>.GetSignedAreaF(shell));

            shell = new ReadOnlyArray<TVector>(Vector(0, 0), Vector(0, 10), Vector(10, 10), Vector(0, 0));

            Assert.Equal(-50, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicF(shell));
            Assert.Equal(-50, SignedArea<TPrimitive, TVector>.GetSignedAreaF(shell));

            shell = shell.ToReverse();

            Assert.Equal(50, SignedArea<TPrimitive, TVector>.GetSignedAreaClassicF(shell));
            Assert.Equal(50, SignedArea<TPrimitive, TVector>.GetSignedAreaF(shell));

        }
    }
}
