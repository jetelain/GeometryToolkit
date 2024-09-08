using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct Vector2I : IEquatable<Vector2I>, IVector2<int,Vector2I>
    {
        public static Vector2I Zero => default;

        public static Vector2I One => new(1);

        public static Vector2I UnitX => new(1, 0);

        public static Vector2I UnitY => new(0, 1);

        public static Vector2I MaxValue => new(int.MaxValue);

        public static Vector2I MinValue => new(int.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Create(int x, int y) => new(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Create(double x, double y) => new((int)x, (int)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Create(long x, long y) => new((int)x, (int)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I(int value)
        {
            X = value;
            Y = value;
        }

        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        int IVector2<int, Vector2I>.X { get => X; set => X = value; }

        int IVector2<int, Vector2I>.Y { get => Y; set => Y = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I left, Vector2I right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I left, Vector2I right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, Vector2I right)
            => new(left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, int right)
            => new(left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(int left, Vector2I right)
            => new(left * right.X, left * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator /(Vector2I left, Vector2I right)
            => new(left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator /(Vector2I left, int right)
            => new(left.X / right, left.Y / right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, double right)
            => new((int)(left.X * right), (int)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator +(Vector2I left, Vector2I right)
            => new(left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator -(Vector2I left, Vector2I right)
            => new(left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator -(Vector2I value)
            => new(-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2I other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2I other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly Vector2F ToFloat() => new((float)X, (float)Y);

        public readonly Vector2D ToDouble() => new((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        public static Vector2I Max(Vector2I value1, Vector2I value2)
        {
            return new(Math.Max(value1.X, value2.X), Math.Max(value1.Y, value2.Y));
        }

        public static Vector2I Min(Vector2I value1, Vector2I value2)
        {
            return new(Math.Min(value1.X, value2.X), Math.Min(value1.Y, value2.Y));
        }

        public static Vector2I Clamp(Vector2I value, Vector2I min, Vector2I max)
        {
            return new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));
        }

        public readonly bool IsInRange(Vector2I min, Vector2I max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2I other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2I other)
        {
            return X <= other.X && Y <= other.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2I v1, Vector2I v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
            // ALT : return Vector2F.CrossProduct(v1.ToFloat(), v2.ToFloat());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2I v1, Vector2I v2)
            => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2I pt1, Vector2I pt2, Vector2I pt3)
        {
            return CrossProduct(pt2 - pt1, pt3 - pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2I pt1, Vector2I pt2, Vector2I pt3)
        {
            return ((double)(pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double)(pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public readonly Vector2I Rotate90()
        {
            return new(-Y, X);
        }

        public readonly Vector2I RotateM90()
        {
            return new(Y, -X);
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

        public static Vector2I Min(ReadOnlySpan<Vector2I> values)
        {
            return Vector128Helper<int, Vector2I>.Min4Bytes(values);
        }

        public static Vector2I Max(ReadOnlySpan<Vector2I> values)
        {
            return Vector128Helper<int, Vector2I>.Max4Bytes(values);
        }

        public static Vector2I Sum(ReadOnlySpan<Vector2I> values)
        {
            return Vector128Helper<int, Vector2I>.Sum4Bytes(values);
        }


        public readonly double LengthD() => ToDouble().Length();

        public readonly float LengthF() => ToFloat().Length();

        public readonly double LengthSquaredD() => ToDouble().LengthSquared();

        public readonly float LengthSquaredF() => ToFloat().LengthSquared();

        public static double DotD(Vector2I value1, Vector2I value2)
        {
            return Vector2F.Dot(value1.ToFloat(), value2.ToFloat());
        }

        public static Vector2I Lerp(Vector2I value1, Vector2I value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }

    }
}
