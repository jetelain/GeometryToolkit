using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector2F : IEquatable<Vector2F>, IVectorFP<float, Vector2F>, IVector2<float, Vector2F>
    {
        public static Vector2F Zero => default;

        public static Vector2F One => new(Vector2.One);

        public static Vector2F UnitX => new(1, 0);

        public static Vector2F UnitY => new(0, 1);

        public static Vector2F MaxValue => new(float.MaxValue);

        public static Vector2F MinValue => new(float.MinValue);

        [FieldOffset(0)]
        private Vector2 vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Create(float x, float y) => new(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Create(double x, double y) => new((float)x, (float)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Create(long x, long y) => new((float)x, (float)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(Vector2 vector)
        {
            this.vector = vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(float x, float y)
        {
            vector = new(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(float value)
        {
            vector = new(value);
        }

        public static Vector2F Lerp(Vector2F value1, Vector2F value2, float amount)
        {
            return new(Vector2.Lerp(value1.vector, value2.vector, amount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Lerp(Vector2F value1, Vector2F value2, double amount) => Lerp(value1, value2, (float)amount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Length() => vector.Length();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2 ToVector2() => vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Atan2()
        {
            return MathF.Atan2(Y, X);
        }

        public readonly double LengthD() => Length();

        public readonly float LengthF() => Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float LengthSquared() => vector.LengthSquared();

        public static Vector2F Normalize(Vector2F value)
        {
            return new (Vector2.Normalize(value.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector2F value1, Vector2F value2)
        {
            return Vector2.Dot(value1.vector, value2.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotD(Vector2F value1, Vector2F value2)
        {
            return Vector2.Dot(value1.vector, value2.vector);
        }

        public float X
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector.X;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector.X = value;
        }

        public float Y
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector.Y;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector.Y = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2F left, Vector2F right)
            => left.vector != right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2F left, Vector2F right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, Vector2F right)
            => new(left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, float right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(float left, Vector2F right)
            => new(left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, Vector2F right)
            => new(left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, float right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, int right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, int right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, double right)
            => new(left.vector * (float)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator +(Vector2F left, Vector2F right)
            => new(left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator -(Vector2F left, Vector2F right)
            => new(left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator -(Vector2F value)
            => new(-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2F SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return vector.GetHashCode();
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2F other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2F other)
        {
            return vector == other.vector;
        }

        public readonly Vector2D ToDouble() => new((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Max(Vector2F value1, Vector2F value2)
        {
            return new(Vector128.Max(value1.vector.AsVector128(), value2.vector.AsVector128()).AsVector2());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Min(Vector2F value1, Vector2F value2)
        {
            return new(Vector2.Min(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Clamp(Vector2F value, Vector2F min, Vector2F max)
        {
            return new(Vector2.Clamp(value.vector, min.vector, max.vector));
        }

        public readonly bool IsInRange(Vector2F min, Vector2F max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2F other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2F other)
        {
            return X <= other.X && Y <= other.Y;
        }

        public readonly Vector2F Rotate90()
        {
            return SwapXY() * new Vector2F(-1, 1);
        }

        public readonly Vector2F RotateM90()
        {
            return SwapXY() * new Vector2F(1, -1);
        }

        public static float CrossProduct(Vector2F v1, Vector2F v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2F v1, Vector2F v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProductF(Vector2F v1, Vector2F v2) => CrossProduct(v1, v2);

        public static float CrossProduct(Vector2F pt1, Vector2F pt2, Vector2F pt3)
        {
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProductScalar(Vector2F pt1, Vector2F pt2, Vector2F pt3)
        {
            return ((float)(pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (float)(pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public Vector2F ToFloat()
        {
            return new Vector2F(vector);
        }

        public readonly double Atan2D()
        {
            return Math.Atan2(Y, X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Area()
        {
            return X * Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double AreaD()
        {
            return X * Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2F Floor()
        {
            return new(MathF.Floor(X), MathF.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2F Ceiling()
        {
            return new(MathF.Ceiling(X), MathF.Ceiling(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I FloorI()
        {
            return new((int)MathF.Floor(X), (int)MathF.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I CeilingI()
        {
            return new((int)MathF.Ceiling(X), (int)MathF.Ceiling(Y));
        }

        public static Vector2F Min(ReadOnlySpan<Vector2F> values)
        {
            return Vector128Helper<float, Vector2F>.Min4Bytes(values);
        }

        public static Vector2F Max(ReadOnlySpan<Vector2F> values)
        {
            return Vector128Helper<float, Vector2F>.Max4Bytes(values);
        }

        public static Vector2F Sum(ReadOnlySpan<Vector2F> values)
        {
            return Vector128Helper<float, Vector2F>.Sum4Bytes(values);
        }

    }
}
