﻿using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public struct Matrix3x2<TPrimitive, TVector> : IMatrix3x2<TPrimitive, TVector, Matrix3x2<TPrimitive, TVector>>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        public readonly Matrix2x2<TPrimitive, TVector> XY;

        public readonly TVector Z;

        public TPrimitive M11 => XY.M11;

        public TPrimitive M12 => XY.M12;

        public TPrimitive M21 => XY.M21;

        public TPrimitive M22 => XY.M22;

        public TPrimitive M31 => Z.X;

        public TPrimitive M32 => Z.Y;

        public Matrix3x2(Matrix2x2<TPrimitive, TVector> xy, TVector z)
        {
            XY = xy; 
            Z = z;
        }

        public static Matrix3x2<TPrimitive, TVector> Create(TPrimitive m11, TPrimitive m12, TPrimitive m21, TPrimitive m22, TPrimitive m31, TPrimitive m32)
        {
            return new Matrix3x2<TPrimitive, TVector>(new (TVector.Create(m11, m12), TVector.Create(m21, m22)), TVector.Create(m31, m32));
        }

        public static Matrix3x2<TPrimitive, TVector> CreateRotation(TPrimitive radians, TVector centerPoint)
        {
            (var sin, var cos) = MatrixHelper.SinCos<TPrimitive>(radians);
            var z = new Matrix2x2<TPrimitive, TVector>(TVector.Create(TPrimitive.One - cos, -sin), TVector.Create(sin, TPrimitive.One - cos))
                .Transform(centerPoint);
            return new(new(TVector.Create(cos, sin), TVector.Create(-sin, cos)), z);
        }

        public static Matrix3x2<TPrimitive, TVector> CreateRotationD(double radians, TVector centerPoint)
        {
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            var z = new Matrix2x2<TPrimitive, TVector>(TVector.Create(1 - cos, -sin), TVector.Create(sin, 1 - cos))
                .Transform(centerPoint);
            return new (new (TVector.Create(cos, sin), TVector.Create(-sin, cos)), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector Transform(TVector value)
        {
            return XY.Transform(value) + Z;
        }

        public bool Equals(Matrix3x2<TPrimitive, TVector> other)
        {
            return other.XY.Equals(XY) && other.Z.Equals(Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix3x2<TPrimitive, TVector> other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XY, Z);
        }

        public static Matrix3x2<TPrimitive, TVector> CreateTranslation(TPrimitive x, TPrimitive y)
        {
            return CreateTranslation(TVector.Create(x, y));
        }

        public static Matrix3x2<TPrimitive, TVector> CreateTranslation(TVector translation)
        {
            return new Matrix3x2<TPrimitive, TVector>(Matrix2x2<TPrimitive, TVector>.Identity, translation);
        }
    }
}
