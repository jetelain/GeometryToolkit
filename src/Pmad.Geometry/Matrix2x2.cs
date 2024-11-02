using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry
{
    public struct Matrix2x2<TPrimitive, TVector> : IMatrix2x2<TPrimitive, TVector, Matrix2x2<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        private static readonly Matrix2x2<TPrimitive, TVector> _identity = Create(TPrimitive.One, TPrimitive.Zero, TPrimitive.Zero, TPrimitive.One);

        public readonly TVector X;
        public readonly TVector Y;

        public TPrimitive M11 => X.X;

        public TPrimitive M12 => X.Y;

        public TPrimitive M21 => Y.X;

        public TPrimitive M22 => Y.Y;

        public Matrix2x2(TVector x, TVector y)
        {
            X = x; 
            Y = y;
        }

        public static Matrix2x2<TPrimitive, TVector> Identity => _identity;

        public static Matrix2x2<TPrimitive, TVector> Create(TPrimitive m11, TPrimitive m12, TPrimitive m21, TPrimitive m22)
        {
            return new Matrix2x2<TPrimitive, TVector>(TVector.Create(m11, m12), TVector.Create(m21, m22));
        }

        public static Matrix2x2<TPrimitive, TVector> CreateRotation(TPrimitive radians)
        {
            (var sin, var cos) = MatrixHelper.SinCos<TPrimitive>(radians);
            return new Matrix2x2<TPrimitive, TVector>(
                TVector.Create(cos, sin), 
                TVector.Create(-sin, cos));
        }

        public static Matrix2x2<TPrimitive, TVector> CreateRotationD(double radians)
        {
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2<TPrimitive, TVector>(
                TVector.Create(cos, sin), 
                TVector.Create(-sin, cos));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector Transform(TVector value)
        {
            return (X * value.X) + (Y * value.Y);
        }

        public bool Equals(Matrix2x2<TPrimitive, TVector> other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix2x2<TPrimitive, TVector> other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public void Transform(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            for (int i = 0; i < source.Length; ++i)
            {
                destination[i] = Transform(source[i]);
            }
        }

         void ITransform<TVector>.TransformClassic(ReadOnlySpan<TVector> source, Span<TVector> destination)
        {
            Transform(source, destination);
        }
    }
}
