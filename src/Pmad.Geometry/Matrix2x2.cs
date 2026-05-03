using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    /// <summary>
    /// 2×2 matrix for linear 2D transformations (rotation, scale) without translation.
    /// </summary>
    /// <typeparam name="TPrimitive">Floating-point scalar type.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public struct Matrix2x2<TPrimitive, TVector> : IMatrix2x2<TPrimitive, TVector, Matrix2x2<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        private static readonly Matrix2x2<TPrimitive, TVector> _identity = Create(TPrimitive.One, TPrimitive.Zero, TPrimitive.Zero, TPrimitive.One);

        /// <summary>First row of the matrix (M11, M12).</summary>
        public readonly TVector X;
        /// <summary>Second row of the matrix (M21, M22).</summary>
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

        /// <summary>The identity matrix.</summary>
        public static Matrix2x2<TPrimitive, TVector> Identity => _identity;

        /// <summary>Creates a matrix from the four scalar elements.</summary>
        public static Matrix2x2<TPrimitive, TVector> Create(TPrimitive m11, TPrimitive m12, TPrimitive m21, TPrimitive m22)
        {
            return new Matrix2x2<TPrimitive, TVector>(TVector.Create(m11, m12), TVector.Create(m21, m22));
        }

        /// <summary>Creates a rotation matrix for the given angle in radians (primitive type).</summary>
        public static Matrix2x2<TPrimitive, TVector> CreateRotation(TPrimitive radians)
        {
            (var sin, var cos) = MatrixHelper.SinCos<TPrimitive>(radians);
            return new Matrix2x2<TPrimitive, TVector>(
                TVector.Create(cos, sin), 
                TVector.Create(-sin, cos));
        }

        /// <summary>Creates a rotation matrix for the given angle in radians (<see langword="double"/>).</summary>
        public static Matrix2x2<TPrimitive, TVector> CreateRotationD(double radians)
        {
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2<TPrimitive, TVector>(
                TVector.Create(cos, sin), 
                TVector.Create(-sin, cos));
        }

        /// <summary>Applies this linear transformation to <paramref name="value"/> and returns the result.</summary>
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
    }
}
