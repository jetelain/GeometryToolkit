using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector2D : IEquatable<Vector2D>, IVector2<double, Vector2D>, IVectorFP<double, Vector2D>
    {
        [FieldOffset(0)]
        private Vector128<double> vector;

        [FieldOffset(0)]
        public double X;

        [FieldOffset(8)]
        public double Y;

        public static Vector2D Zero => default;

        public static Vector2D One => new(1);

        public static Vector2D UnitX => new(1, 0);

        public static Vector2D UnitY => new(0, 1);

        public static Vector2D MaxValue => new(double.MaxValue);

        public static Vector2D MinValue => new(double.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D Create(double x, double y) => new(x, y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D Create(long x, long y) => new((double)x, (double)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(double x, double y)
        {
            vector = Vector128.Create(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(double value)
        {
            vector = Vector128.Create(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2D(Vector128<double> vector)
        {
            this.vector = vector;
        }

        double IVector2<double, Vector2D>.X { get => X; set => X = value; }

        double IVector2<double, Vector2D>.Y { get => Y; set => Y = value; }

        public Vector128<double> Vector
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2D left, Vector2D right)
            => left.vector != right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2D left, Vector2D right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D left, Vector2D right)
            => new(left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D left, double right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(double left, Vector2D right)
            => new(left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, Vector2D right)
            => new(left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, double right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, int right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D left, int right)
            => new(left.vector * right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Vector2D left, Vector2D right)
            => new(left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D left, Vector2D right)
            => new(left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D value)
            => new(-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2D SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return vector.GetHashCode();
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2D other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2D other)
        {
            return vector == other.vector;
        }


        public readonly Vector2F ToFloat() => new((float)X, (float)Y);


        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D Max(Vector2D value1, Vector2D value2)
        {
            return new(Vector128.Max(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D Min(Vector2D value1, Vector2D value2)
        {
            return new(Vector128.Min(value1.vector, value2.vector));
        }

        public static Vector2D Clamp(Vector2D value, Vector2D min, Vector2D max)
        {
            return new(Vector128.Min(Vector128.Max(value.vector, min.vector), max.vector));
        }

        public readonly bool IsInRange(Vector2D min, Vector2D max)
        {
            // min <= vector && vector <= max
            return Vector128.LessThanOrEqualAll(min.vector, vector) && Vector128.LessThanOrEqualAll(vector, max.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsGreaterThanOrEqualAll(Vector2D other)
        {
            return Vector128.GreaterThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsLessThanOrEqualAll(Vector2D other)
        {
            return Vector128.LessThanOrEqualAll(vector, other.vector);
        }

        public readonly Vector2D Rotate90()
        {
            return SwapXY() * new Vector2D(-1, 1);
        }

        public readonly Vector2D RotateM90()
        {
            return SwapXY() * new Vector2D(1, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2D v1, Vector2D v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2D pt1, Vector2D pt2, Vector2D pt3)
        {
            return CrossProduct(pt2 - pt1, pt3 - pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2D pt1, Vector2D pt2, Vector2D pt3)
        {
            return ((double)(pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double)(pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double Atan2D()
        {
            return Math.Atan2(Y, X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double AreaD()
        {
            return X * Y;
        }

        public static Vector2D Min(ReadOnlySpan<Vector2D> values) => new(MemoryMarshal.Cast<Vector2D, Vector128<double>>(values).Min());

        public static Vector2D Max(ReadOnlySpan<Vector2D> values) => new(MemoryMarshal.Cast<Vector2D, Vector128<double>>(values).Max());

        public static Vector2D Sum(ReadOnlySpan<Vector2D> values) => new(MemoryMarshal.Cast<Vector2D, Vector128<double>>(values).Sum());

    
        public static Vector2D Lerp(Vector2D value1, Vector2D value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }

        public readonly double Length() => Math.Sqrt(LengthSquared());
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double Atan2()
        {
            return Math.Atan2(Y, X);
        }

        public readonly Vector2D ToDouble() => this;

        public readonly double LengthD() => Length();

        public readonly float LengthF() => (float)Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => (float)LengthSquared();

        public readonly double LengthSquared() => Vector128.Dot(vector, vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2D v1, Vector2D v2)
        {
            var temp = v1 * v2.SwapXY();
            return temp.X - temp.Y;
            //return v2.Y * v1.X - v2.X * v1.Y;
        }

        public static Vector2D Normalize(Vector2D value)
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Dot(Vector2D v1, Vector2D v2)
        {
            return Vector128.Dot(v1.vector, v2.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotD(Vector2D v1, Vector2D v2)
        {
            return Vector128.Dot(v1.vector, v2.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double Area()
        {
            return X * Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2D Floor()
        {
            return new (Vector128.Floor(vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2D Ceiling()
        {
            return new(Vector128.Ceiling(vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I FloorI()
        {
            var temp = Floor();
            return new((int)temp.X, (int)temp.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I CeilingI()
        {
            var temp = Ceiling();
            return new((int)temp.X, (int)temp.Y);
        }
    }
}
