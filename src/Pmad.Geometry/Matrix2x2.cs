using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public struct Matrix2x2<TPrimitive, TVector> : IMatrix2x2<TPrimitive, TVector, Matrix2x2<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
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

        public static Matrix2x2<TPrimitive, TVector> CreateRotation(TPrimitive radians)
        {
            return CreateRotation(double.CreateChecked(radians));
        }

        public static Matrix2x2<TPrimitive, TVector> CreateRotation(double radians)
        {
            //var cos = Math.Cos(radians);
            //var sin = Math.Sin(radians); 
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2<TPrimitive, TVector>(Vectors.Create<TPrimitive,TVector>(cos, sin), Vectors.Create<TPrimitive, TVector>(-sin, cos));
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
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }
    }
}
