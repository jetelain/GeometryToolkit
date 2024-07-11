using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

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

        public static Vector2FN Max(Vector2FN value1, Vector2FN value2)
        {
            return new(Math.Max(value1.X, value2.X), Math.Max(value1.Y, value2.Y));
        }

        public static Vector2FN Min(Vector2FN value1, Vector2FN value2)
        {
            return new(Math.Min(value1.X, value2.X), Math.Min(value1.Y, value2.Y));
        }

        public static Vector2FN Clamp(Vector2FN value, Vector2FN min, Vector2FN max)
        {
            return new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));
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
        readonly Vector2FN IVector<Vector2FN>.Min(Vector2FN other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FN IVector<Vector2FN>.Max(Vector2FN other)
        {
            return Max(this, other);
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

        public static double CrossProduct(Vector2FN pt1, Vector2FN pt2, Vector2FN pt3)
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
    }
}
