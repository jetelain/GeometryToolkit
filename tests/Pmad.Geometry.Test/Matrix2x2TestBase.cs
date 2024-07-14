using System.Numerics;

namespace Pmad.Geometry.Test
{
    public abstract class Matrix2x2TestBase<TPrimitive, TVector, TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix2x2<TPrimitive, TVector, TMatrix>
    {
        protected abstract TMatrix Rotation(double radians);

        protected abstract TMatrix Create(double m11, double m12, double m21, double m22);

        protected abstract TVector Vector(double x, double y);

        protected abstract double Double(TPrimitive v);

        private void Equal(TVector expected, TVector actual)
        {
            Assert.Equal(Double(expected.X), Double(actual.X), 0.0001);
            Assert.Equal(Double(expected.Y), Double(actual.Y), 0.0001);
        }

        private void Equal(TMatrix expected, TMatrix actual)
        {
            Assert.Equal(Double(expected.M11), Double(actual.M11), 0.0001);
            Assert.Equal(Double(expected.M12), Double(actual.M12), 0.0001);
            Assert.Equal(Double(expected.M21), Double(actual.M21), 0.0001);
            Assert.Equal(Double(expected.M22), Double(actual.M22), 0.0001);
        }

        [Fact]
        public void CreateRotation()
        {
            Equal(Create(1, 0, 0, 1), Rotation(0));
            Equal(Create(-1, 0, 0, -1), Rotation(Math.PI));
            Equal(Create(0, 1, -1, 0), Rotation(Math.PI / 2));
        }

        [Fact]
        public void CreateRotation_Transform()
        {
            Equal(Vector(20, 30), Rotation(0).Transform(Vector(20, 30)));
            Equal(Vector(-20, -30), Rotation(Math.PI).Transform(Vector(20, 30)));
            Equal(Vector(-30, 20), Rotation(Math.PI / 2).Transform(Vector(20, 30)));
        }
    }
}
