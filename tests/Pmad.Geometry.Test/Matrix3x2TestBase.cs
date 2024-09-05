using System.Numerics;

namespace Pmad.Geometry.Test
{
    public abstract class Matrix3x2TestBase<TPrimitive, TVector, TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix3x2<TPrimitive, TVector, TMatrix>
    {
        protected abstract TMatrix Create(double m11, double m12, double m21, double m22, double m31, double m32);

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
            Assert.Equal(Double(expected.M31), Double(actual.M31), 0.0001);
            Assert.Equal(Double(expected.M32), Double(actual.M32), 0.0001);
        }

        [Fact]
        public void CreateRotation()
        {
            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateRotation(TPrimitive.Zero, Vector(0, 0)));
            Equal(Create(-1, 0, 0, -1, 0, 0), TMatrix.CreateRotation(TPrimitive.Pi, Vector(0, 0)));
            Equal(Create(0, 1, -1, 0, 0, 0), TMatrix.CreateRotation(TPrimitive.Pi / TPrimitive.CreateChecked(2), Vector(0, 0)));

            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateRotation(TPrimitive.Zero, Vector(10, 10)));
            Equal(Create(-1, 0, 0, -1, 20, 0), TMatrix.CreateRotation(TPrimitive.Pi, Vector(10, 0)));
            Equal(Create(-1, 0, 0, -1, 0, 20), TMatrix.CreateRotation(TPrimitive.Pi, Vector(0, 10)));
            Equal(Create(0, 1, -1, 0, 20, 0), TMatrix.CreateRotation(TPrimitive.Pi / TPrimitive.CreateChecked(2), Vector(10, 10)));
        }

        [Fact]
        public void CreateRotationD()
        {
            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateRotationD(0, Vector(0, 0)));
            Equal(Create(-1, 0, 0, -1, 0, 0), TMatrix.CreateRotationD(Math.PI, Vector(0, 0)));
            Equal(Create(0, 1, -1, 0, 0, 0), TMatrix.CreateRotationD(Math.PI / 2, Vector(0, 0)));

            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateRotationD(0, Vector(10, 10)));
            Equal(Create(-1, 0, 0, -1, 20, 0), TMatrix.CreateRotationD(Math.PI, Vector(10, 0)));
            Equal(Create(-1, 0, 0, -1, 0, 20), TMatrix.CreateRotationD(Math.PI, Vector(0, 10)));
            Equal(Create(0, 1, -1, 0, 20, 0), TMatrix.CreateRotationD(Math.PI / 2, Vector(10, 10)));
        }

        [Fact]
        public void CreateRotation_Transform()
        {
            Equal(Vector(20, 30), TMatrix.CreateRotationD(0, Vector(0, 0)).Transform(Vector(20, 30)));
            Equal(Vector(-20, -30), TMatrix.CreateRotationD(Math.PI, Vector(0, 0)).Transform(Vector(20, 30)));
            Equal(Vector(-30, 20), TMatrix.CreateRotationD(Math.PI / 2, Vector(0, 0)).Transform(Vector(20, 30)));

            Equal(Vector(-10, 20), TMatrix.CreateRotationD(Math.PI / 2, Vector(10, 10)).Transform(Vector(20, 30)));
        }

        [Fact]
        public void CreateTranslation_Vector()
        {
            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateTranslation(Vector(0, 0)));
            Equal(Create(1, 0, 0, 1, 10, 20), TMatrix.CreateTranslation(Vector(10, 20)));
        }

        [Fact]
        public void CreateTranslation_Primitive()
        {
            Equal(Create(1, 0, 0, 1, 0, 0), TMatrix.CreateTranslation(TPrimitive.CreateChecked(0), TPrimitive.CreateChecked(0)));
            Equal(Create(1, 0, 0, 1, 10, 20), TMatrix.CreateTranslation(TPrimitive.CreateChecked(10), TPrimitive.CreateChecked(20)));
        }
    }
}
