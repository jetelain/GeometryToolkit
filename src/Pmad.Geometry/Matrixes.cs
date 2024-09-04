using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public struct Matrix2x2F : IMatrix2x2<float, Vector2F, Matrix2x2F>
    {
        public readonly Vector2F X;
        public readonly Vector2F Y;

        public float M11 => X.X;

        public float M12 => X.Y;

        public float M21 => Y.X;

        public float M22 => Y.Y;

        public Matrix2x2F(Vector2F x, Vector2F y)
        {
            X = x; 
            Y = y;
        }

        public static Matrix2x2F CreateRotation(float radians)
        {
            //var cos = MathF.Cos(radians);
            //var sin = MathF.Sin(radians); 
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2F(new(cos, sin), new(-sin, cos));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F Transform(Vector2F value)
        {
            return (X * value.X) + (Y * value.Y);
        }

        public bool Equals(Matrix2x2F other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix2x2F other)
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

    public struct Matrix3x2F : IMatrix3x2<float, Vector2F, Matrix3x2F>
    {
        public readonly Matrix2x2F XY;

        public readonly Vector2F Z;

        public float M11 => XY.M11;

        public float M12 => XY.M12;

        public float M21 => XY.M21;

        public float M22 => XY.M22;

        public float M31 => Z.X;

        public float M32 => Z.Y;

        public Matrix3x2F(Matrix2x2F xy, Vector2F z)
        {
            XY = xy; 
            Z = z;
        }

        public static Matrix3x2F CreateRotation(float radians, Vector2F centerPoint)
        {
            //var cos = MathF.Cos(radians);
            //var sin = MathF.Sin(radians);
            (var sin, var cos) = MatrixHelper.SinCos(radians);

            var z = new Matrix2x2F(new (1 - cos, sin),new(-sin, 1 - cos))
                .Transform(centerPoint);

            return new (new (new (cos, sin), new(-sin, cos)), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F Transform(Vector2F value)
        {
            return XY.Transform(value) + Z;
        }

        public bool Equals(Matrix3x2F other)
        {
            return other.XY.Equals(XY) && other.Z.Equals(Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix3x2F other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XY.GetHashCode(), Z.GetHashCode());
        }
    }


    public struct Matrix2x2D : IMatrix2x2<double, Vector2D, Matrix2x2D>
    {
        public readonly Vector2D X;
        public readonly Vector2D Y;

        public double M11 => X.X;

        public double M12 => X.Y;

        public double M21 => Y.X;

        public double M22 => Y.Y;

        public Matrix2x2D(Vector2D x, Vector2D y)
        {
            X = x; 
            Y = y;
        }

        public static Matrix2x2D CreateRotation(double radians)
        {
            //var cos = Math.Cos(radians);
            //var sin = Math.Sin(radians); 
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2D(new(cos, sin), new(-sin, cos));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D Transform(Vector2D value)
        {
            return (X * value.X) + (Y * value.Y);
        }

        public bool Equals(Matrix2x2D other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix2x2D other)
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

    public struct Matrix3x2D : IMatrix3x2<double, Vector2D, Matrix3x2D>
    {
        public readonly Matrix2x2D XY;

        public readonly Vector2D Z;

        public double M11 => XY.M11;

        public double M12 => XY.M12;

        public double M21 => XY.M21;

        public double M22 => XY.M22;

        public double M31 => Z.X;

        public double M32 => Z.Y;

        public Matrix3x2D(Matrix2x2D xy, Vector2D z)
        {
            XY = xy; 
            Z = z;
        }

        public static Matrix3x2D CreateRotation(double radians, Vector2D centerPoint)
        {
            //var cos = Math.Cos(radians);
            //var sin = Math.Sin(radians);
            (var sin, var cos) = MatrixHelper.SinCos(radians);

            var z = new Matrix2x2D(new (1 - cos, sin),new(-sin, 1 - cos))
                .Transform(centerPoint);

            return new (new (new (cos, sin), new(-sin, cos)), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D Transform(Vector2D value)
        {
            return XY.Transform(value) + Z;
        }

        public bool Equals(Matrix3x2D other)
        {
            return other.XY.Equals(XY) && other.Z.Equals(Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix3x2D other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XY.GetHashCode(), Z.GetHashCode());
        }
    }


    internal struct Matrix2x2FS : IMatrix2x2<float, Vector2FS, Matrix2x2FS>
    {
        public readonly Vector2FS X;
        public readonly Vector2FS Y;

        public float M11 => X.X;

        public float M12 => X.Y;

        public float M21 => Y.X;

        public float M22 => Y.Y;

        public Matrix2x2FS(Vector2FS x, Vector2FS y)
        {
            X = x; 
            Y = y;
        }

        public static Matrix2x2FS CreateRotation(float radians)
        {
            //var cos = MathF.Cos(radians);
            //var sin = MathF.Sin(radians); 
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2FS(new(cos, sin), new(-sin, cos));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FS Transform(Vector2FS value)
        {
            return (X * value.X) + (Y * value.Y);
        }

        public bool Equals(Matrix2x2FS other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix2x2FS other)
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

    internal struct Matrix3x2FS : IMatrix3x2<float, Vector2FS, Matrix3x2FS>
    {
        public readonly Matrix2x2FS XY;

        public readonly Vector2FS Z;

        public float M11 => XY.M11;

        public float M12 => XY.M12;

        public float M21 => XY.M21;

        public float M22 => XY.M22;

        public float M31 => Z.X;

        public float M32 => Z.Y;

        public Matrix3x2FS(Matrix2x2FS xy, Vector2FS z)
        {
            XY = xy; 
            Z = z;
        }

        public static Matrix3x2FS CreateRotation(float radians, Vector2FS centerPoint)
        {
            //var cos = MathF.Cos(radians);
            //var sin = MathF.Sin(radians);
            (var sin, var cos) = MatrixHelper.SinCos(radians);

            var z = new Matrix2x2FS(new (1 - cos, sin),new(-sin, 1 - cos))
                .Transform(centerPoint);

            return new (new (new (cos, sin), new(-sin, cos)), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FS Transform(Vector2FS value)
        {
            return XY.Transform(value) + Z;
        }

        public bool Equals(Matrix3x2FS other)
        {
            return other.XY.Equals(XY) && other.Z.Equals(Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix3x2FS other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XY.GetHashCode(), Z.GetHashCode());
        }
    }


    internal struct Matrix2x2DS : IMatrix2x2<double, Vector2DS, Matrix2x2DS>
    {
        public readonly Vector2DS X;
        public readonly Vector2DS Y;

        public double M11 => X.X;

        public double M12 => X.Y;

        public double M21 => Y.X;

        public double M22 => Y.Y;

        public Matrix2x2DS(Vector2DS x, Vector2DS y)
        {
            X = x; 
            Y = y;
        }

        public static Matrix2x2DS CreateRotation(double radians)
        {
            //var cos = Math.Cos(radians);
            //var sin = Math.Sin(radians); 
            (var sin, var cos) = MatrixHelper.SinCos(radians);
            return new Matrix2x2DS(new(cos, sin), new(-sin, cos));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2DS Transform(Vector2DS value)
        {
            return (X * value.X) + (Y * value.Y);
        }

        public bool Equals(Matrix2x2DS other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix2x2DS other)
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

    internal struct Matrix3x2DS : IMatrix3x2<double, Vector2DS, Matrix3x2DS>
    {
        public readonly Matrix2x2DS XY;

        public readonly Vector2DS Z;

        public double M11 => XY.M11;

        public double M12 => XY.M12;

        public double M21 => XY.M21;

        public double M22 => XY.M22;

        public double M31 => Z.X;

        public double M32 => Z.Y;

        public Matrix3x2DS(Matrix2x2DS xy, Vector2DS z)
        {
            XY = xy; 
            Z = z;
        }

        public static Matrix3x2DS CreateRotation(double radians, Vector2DS centerPoint)
        {
            //var cos = Math.Cos(radians);
            //var sin = Math.Sin(radians);
            (var sin, var cos) = MatrixHelper.SinCos(radians);

            var z = new Matrix2x2DS(new (1 - cos, sin),new(-sin, 1 - cos))
                .Transform(centerPoint);

            return new (new (new (cos, sin), new(-sin, cos)), z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2DS Transform(Vector2DS value)
        {
            return XY.Transform(value) + Z;
        }

        public bool Equals(Matrix3x2DS other)
        {
            return other.XY.Equals(XY) && other.Z.Equals(Z);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Matrix3x2DS other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XY.GetHashCode(), Z.GetHashCode());
        }
    }


}
