﻿using System.Numerics;

namespace Pmad.Geometry.Test
{
    public abstract class Vector2TestBase<TPrimitive, TVector> 
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        protected abstract TVector Vector(int x, int y);

        protected abstract TPrimitive Scalar(int v);

        [Fact]
        public void LengthD()
        {
            Assert.Equal(10, Vector(0, 10).LengthD());
            Assert.Equal(10, Vector(10, 0).LengthD());
            Assert.Equal(10, Vector(0, -10).LengthD());
            Assert.Equal(10, Vector(-10, 0).LengthD());
            Assert.Equal(14.1, Vector(10, 10).LengthD(), 1);
            Assert.Equal(14.1, Vector(-10, -10).LengthD(), 1);
        }

        [Fact]
        public void LengthF()
        {
            Assert.Equal(10, Vector(0, 10).LengthF());
            Assert.Equal(10, Vector(10, 0).LengthF());
            Assert.Equal(10, Vector(0, -10).LengthF());
            Assert.Equal(10, Vector(-10, 0).LengthF());
            Assert.Equal(14.1f, Vector(10, 10).LengthF(), 1);
            Assert.Equal(14.1f, Vector(-10, -10).LengthF(), 1);
        }

        [Fact]
        public void LengthSquaredD()
        {
            Assert.Equal(100, Vector(0, 10).LengthSquaredD());
            Assert.Equal(100, Vector(0, -10).LengthSquaredD());
            Assert.Equal(100, Vector(10, 0).LengthSquaredD());
            Assert.Equal(100, Vector(-10, 0).LengthSquaredD());
            Assert.Equal(200, Vector(10, 10).LengthSquaredD());
            Assert.Equal(200, Vector(-10, -10).LengthSquaredD());
        }

        [Fact]
        public void LengthSquaredF()
        {
            Assert.Equal(100, Vector(0, 10).LengthSquaredF());
            Assert.Equal(100, Vector(0, -10).LengthSquaredF());
            Assert.Equal(100, Vector(10, 0).LengthSquaredF());
            Assert.Equal(100, Vector(-10, 0).LengthSquaredF());
            Assert.Equal(200, Vector(10, 10).LengthSquaredF());
            Assert.Equal(200, Vector(-10, -10).LengthSquaredF());
        }

        [Fact]
        public void IsGreaterThanOrEqualAll()
        {
            Assert.True(Vector(0, 10).IsGreaterThanOrEqualAll(Vector(0, 10)));
            Assert.True(Vector(0, 15).IsGreaterThanOrEqualAll(Vector(0, 10)));
            Assert.True(Vector(5, 10).IsGreaterThanOrEqualAll(Vector(0, 10)));

            Assert.False(Vector(0, 10).IsGreaterThanOrEqualAll(Vector(5, 15)));
            Assert.False(Vector(0, 15).IsGreaterThanOrEqualAll(Vector(5, 15)));
            Assert.False(Vector(5, 10).IsGreaterThanOrEqualAll(Vector(5, 15)));
        }

        [Fact]
        public void IsLessThanOrEqualAll()
        {
            Assert.False(Vector(5, 15).IsLessThanOrEqualAll(Vector(0, 10)));
            Assert.False(Vector(0, 15).IsLessThanOrEqualAll(Vector(0, 10)));
            Assert.False(Vector(5, 10).IsLessThanOrEqualAll(Vector(0, 10)));

            Assert.True(Vector(0, 10).IsLessThanOrEqualAll(Vector(5, 15)));
            Assert.True(Vector(0, 15).IsLessThanOrEqualAll(Vector(5, 15)));
            Assert.True(Vector(5, 10).IsLessThanOrEqualAll(Vector(5, 15)));
        }

        [Fact]
        public void SwapXY()
        {
            Assert.Equal(Vector(15, 5), Vector(5, 15).SwapXY());
        }

        [Fact]
        public void XProperty()
        {
            var value = Vector(123, 456);
            Assert.Equal(Scalar(123), value.X);

            value.X = Scalar(789);
            Assert.Equal(Scalar(789), value.X);
            Assert.Equal(Vector(789, 456), value);
        }

        [Fact]
        public void YProperty()
        {
            var value = Vector(123, 456);
            Assert.Equal(Scalar(456), value.Y);

            value.Y = Scalar(789);
            Assert.Equal(Scalar(789), value.Y);
            Assert.Equal(Vector(123, 789), value);
        }

        [Fact]
        public void MultiplyByInteger()
        {
            Assert.Equal(Vector(50, 150), Vector(5, 15).Multiply(10));
        }

        [Fact]
        public void MultiplyByDouble()
        {
            Assert.Equal(Vector(50, 150), Vector(5, 15).Multiply(10d));
            Assert.Equal(Vector(5, 10), Vector(10, 20).Multiply(0.5));
        }

        [Fact]
        public void DivideByInteger()
        {
            Assert.Equal(Vector(10, 20), Vector(20, 40).Divide(2));
        }

        [Fact]
        public void IVectorNegate()
        {
            Assert.Equal(Vector(-20, -40), Vector(20, 40).Negate());
        }

        [Fact]
        public void IVectorMin()
        {
            Assert.Equal(Vector(20, 20), Vector(20, 40).Min(Vector(60, 20)));
            Assert.Equal(Vector(20, 40), Vector(20, 40).Min(Vector(60, 60)));
            Assert.Equal(Vector(10, 40), Vector(20, 40).Min(Vector(10, 60)));
            Assert.Equal(Vector(10, 05), Vector(20, 40).Min(Vector(10, 05)));
        }

        [Fact]
        public void IVectorMax()
        {
            Assert.Equal(Vector(60, 40), Vector(20, 40).Max(Vector(60, 20)));
            Assert.Equal(Vector(60, 60), Vector(20, 40).Max(Vector(60, 60)));
            Assert.Equal(Vector(20, 60), Vector(20, 40).Max(Vector(10, 60)));
            Assert.Equal(Vector(20, 40), Vector(20, 40).Max(Vector(5, 10)));
        }

        [Fact]
        public void MultiplyByPrimitive()
        {
            Assert.Equal(Vector(50, 150), Vector(5, 15).Multiply(Scalar(10)));
        }

        [Fact]
        public void Atan2D()
        {
            Assert.Equal(Math.PI / 2, Vector(0, 100).Atan2D());
            Assert.Equal(-Math.PI / 2, Vector(0, -100).Atan2D());

            Assert.Equal(0, Vector(100, 0).Atan2D());
            Assert.Equal(Math.PI, Vector(-100, 0).Atan2D());

            Assert.Equal(Math.PI / 4, Vector(100, 100).Atan2D());
            Assert.Equal(-Math.PI * 3 / 4, Vector(-100, -100).Atan2D());
        }

        [Fact]
        public void Rotate90()
        {
            Assert.Equal(Vector(0, 100), Vector(100, 0).Rotate90());
            Assert.Equal(Vector(-100, 0), Vector(0, 100).Rotate90());
            Assert.Equal(Vector(0, -100), Vector(-100, 0).Rotate90());
            Assert.Equal(Vector(100, 0), Vector(0, -100).Rotate90());

            Assert.Equal(Vector(-100, 100), Vector(100, 100).Rotate90());
            Assert.Equal(Vector(-10, 100), Vector(100, 10).Rotate90());
        }


        [Fact]
        public void RotateM90()
        {
            Assert.Equal(Vector(0, -100), Vector(100, 0).RotateM90());
            Assert.Equal(Vector(100, 0), Vector(0, 100).RotateM90());
            Assert.Equal(Vector(0, 100), Vector(-100, 0).RotateM90());
            Assert.Equal(Vector(-100, 0), Vector(0, -100).RotateM90());

            Assert.Equal(Vector(100, -100), Vector(100, 100).RotateM90());
            Assert.Equal(Vector(10, -100), Vector(100, 10).RotateM90());
        }

        [Fact]
        public void VectorsAdd()
        {
            Assert.Equal(Vector(123, 456), Vectors.Add(Vector(100, 56), Vector(23, 400)));
        }

        [Fact]
        public void VectorsSubstract()
        {
            Assert.Equal(Vector(100, 56), Vectors.Substract(Vector(123, 456), Vector(23, 400)));
        }

        [Fact]
        public void VectorsMultiply()
        {
            Assert.Equal(Vector(2000, 8000), Vectors.Multiply(Vector(200, 400), Vector(10, 20)));
        }

        [Fact]
        public void VectorsMultiplyScalar()
        {
            Assert.Equal(Vector(2000, 4000), Vectors.Multiply(Vector(200, 400), Scalar(10)));
        }

        [Fact]
        public void VectorsMultiplyInteger()
        {
            Assert.Equal(Vector(2000, 4000), Vectors.Multiply(Vector(200, 400), 10));
        }

        [Fact]
        public void VectorsDivide()
        {
            Assert.Equal(Vector(10, 40), Vectors.Divide(Vector(200, 400), Vector(20, 10)));
        }

        [Fact]
        public void VectorsDivideScalar()
        {
            Assert.Equal(Vector(20, 40), Vectors.Divide(Vector(200, 400), 10));
        }

        [Fact]
        public void VectorsHasLineIntersection()
        {
            TVector result;

            Assert.True(Vectors.HasLineIntersection(Vector(0, 0), Vector(100, 100), Vector(0, 100), Vector(100, 0), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.True(Vectors.HasLineIntersection(Vector(10, 10), Vector(0, 0), Vector(0, 100), Vector(100, 0), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.True(Vectors.HasLineIntersection(Vector(0, 0), Vector(10, 10), Vector(100, 0), Vector(0, 100), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.False(Vectors.HasLineIntersection(Vector(0, 0), Vector(10, 10), Vector(500, 0), Vector(600, 100), out _)); // Parallel
        }

        [Fact]
        public void VectorsHasSegmentIntersection()
        {
            TVector result;

            Assert.True(Vectors.HasSegmentIntersection(Vector(0, 0), Vector(100, 100), Vector(0, 100), Vector(100, 0), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.True(Vectors.HasSegmentIntersection(Vector(100, 100), Vector(0, 0), Vector(0, 100), Vector(100, 0), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.True(Vectors.HasSegmentIntersection(Vector(0, 0), Vector(100, 100), Vector(100, 0), Vector(0, 100), out result));
            Assert.Equal(Vector(50, 50), result);

            Assert.False(Vectors.HasSegmentIntersection(Vector(0, 0), Vector(10, 10), Vector(500, 0), Vector(600, 100), out _)); // Parallel

            Assert.False(Vectors.HasSegmentIntersection(Vector(10, 10), Vector(0, 0), Vector(0, 100), Vector(100, 0), out _));
            Assert.False(Vectors.HasSegmentIntersection(Vector(0, 0), Vector(10, 10), Vector(100, 0), Vector(0, 100), out _));
            Assert.False(Vectors.HasSegmentIntersection(Vector(0, 0), Vector(1, 1), Vector(500, 100), Vector(600, 0), out _));
        }
    }
}
