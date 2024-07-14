using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public struct Vector2FN : IEquatable<Vector2FN>, IVectorFP<float, Vector2FN>, IVector2<float, Vector2FN>
    {
        public static Vector2FN Zero => default;

        public static Vector2FN One => new(Vector2.One);

        public static Vector2FN UnitX => new(1, 0);

        public static Vector2FN UnitY => new(0, 1);

        public static Vector2FN MaxValue => new(float.MaxValue);

        public static Vector2FN MinValue => new(float.MinValue);

        private Vector2 vector;

        public static Vector2FN Create(float x, float y) => new(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FN(Vector2 vector)
        {
            this.vector = vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FN(float x, float y)
        {
            vector = new(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FN(float value)
        {
            vector = new(value);
        }

        public static Vector2FN Lerp(Vector2FN value1, Vector2FN value2, float amount)
        {
            return new(Vector2.Lerp(value1.vector, value2.vector, amount));
        }

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

        public static Vector2FN Normalize(Vector2FN value)
        {
            return new (Vector2.Normalize(value.vector));
        }

        public static float Dot(Vector2FN value1, Vector2FN value2)
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
        public static bool operator !=(Vector2FN left, Vector2FN right)
            => left.vector != right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2FN left, Vector2FN right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator *(Vector2FN left, Vector2FN right)
            => new(left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator *(Vector2FN left, float right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator *(float left, Vector2FN right)
            => new(left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator /(Vector2FN left, Vector2FN right)
            => new(left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator /(Vector2FN left, float right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator /(Vector2FN left, int right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator *(Vector2FN left, int right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator *(Vector2FN left, double right)
            => new(left.vector * (float)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator +(Vector2FN left, Vector2FN right)
            => new(left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator -(Vector2FN left, Vector2FN right)
            => new(left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN operator -(Vector2FN value)
            => new(-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2FN SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return vector.GetHashCode();
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2FN other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2FN other)
        {
            return vector == other.vector;
        }

        public readonly Vector2D ToDouble() => new((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN Max(Vector2FN value1, Vector2FN value2)
        {
            return new(Vector2.Max(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN Min(Vector2FN value1, Vector2FN value2)
        {
            return new(Vector2.Min(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FN Clamp(Vector2FN value, Vector2FN min, Vector2FN max)
        {
            return new(Vector2.Clamp(value.vector, min.vector, max.vector));
        }

        public readonly bool IsInRange(Vector2FN min, Vector2FN max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2FN other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2FN other)
        {
            return X <= other.X && Y <= other.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Add(Vector2FN value)
        {
            return this + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Substract(Vector2FN value)
        {
            return this - value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Multiply(Vector2FN value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Multiply(double value)
        {
            return this * (float)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Multiply(int value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Divide(Vector2FN value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Divide(int value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Min(Vector2FN other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Max(Vector2FN other)
        {
            return Max(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Negate()
        {
            return -this;
        }

        public readonly Vector2FN Rotate90()
        {
            return SwapXY() * new Vector2FN(-1, 1);
        }

        public readonly Vector2FN RotateM90()
        {
            return SwapXY() * new Vector2FN(1, -1);
        }

        public static float CrossProduct(Vector2FN v1, Vector2FN v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        public static float CrossProduct(Vector2FN pt1, Vector2FN pt2, Vector2FN pt3)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVectorFP<float, Vector2FN>.Normalize()
        {
            return Normalize(this);
        }

        public readonly double Atan2D()
        {
            return Math.Atan2(Y, X);
        }

        Vector2FN IVector2<float, Vector2FN>.Multiply(float value)
        {
            return this * value;
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
        public readonly Vector2FN Floor()
        {
            return new(MathF.Floor(X), MathF.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2FN Ceiling()
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
    }
}
