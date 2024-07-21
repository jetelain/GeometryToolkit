using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
    public struct Vector2L : IEquatable<Vector2L>, IVector2<long, Vector2L>
    {
        [FieldOffset(0)]
        private Vector128<long> vector;

        [FieldOffset(0)]
        public long X;

        [FieldOffset(8)]
        public long Y;

        public static Vector2L Zero => default;

        public static Vector2L One => new(1);

        public static Vector2L UnitX => new(1, 0);

        public static Vector2L UnitY => new(0, 1);

        public static Vector2L MaxValue => new(long.MaxValue);

        public static Vector2L MinValue => new(long.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Create(long x, long y) => new(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Create(double x, double y) => new((long)x, (long)y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2L(long x, long y)
        {
            vector = Vector128.Create(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2L(long value)
        {
            vector = Vector128.Create(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2L(Vector128<long> vector)
        {
            this.vector = vector;
        }

        long IVector2<long, Vector2L>.X { get => X; set => X = value; }

        long IVector2<long, Vector2L>.Y { get => Y; set => Y = value; }

        public Vector128<long> Vector
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2L left, Vector2L right)
            => left.vector != right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2L left, Vector2L right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, Vector2L right)
            => new(left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, long right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(long left, Vector2L right)
            => new(left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, Vector2L right)
            => new(left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, long right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, int right)
            => new(left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, int right)
            => new(left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, double right)
            => new((long)(left.X * right), (long)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator +(Vector2L left, Vector2L right)
            => new(left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator -(Vector2L left, Vector2L right)
            => new(left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator -(Vector2L value)
            => new(-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2L SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return vector.GetHashCode();
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2L other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2L other)
        {
            return vector == other.vector;
        }


        public readonly Vector2F ToFloat() => new((float)X, (float)Y);


        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Max(Vector2L value1, Vector2L value2)
        {
            return new(Vector128.Max(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Min(Vector2L value1, Vector2L value2)
        {
            return new(Vector128.Min(value1.vector, value2.vector));
        }

        public static Vector2L Clamp(Vector2L value, Vector2L min, Vector2L max)
        {
            return new(Vector128.Min(Vector128.Max(value.vector, min.vector), max.vector));
        }

        public readonly bool IsInRange(Vector2L min, Vector2L max)
        {
            // min <= vector && vector <= max
            return Vector128.LessThanOrEqualAll(min.vector, vector) && Vector128.LessThanOrEqualAll(vector, max.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsGreaterThanOrEqualAll(Vector2L other)
        {
            return Vector128.GreaterThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsLessThanOrEqualAll(Vector2L other)
        {
            return Vector128.LessThanOrEqualAll(vector, other.vector);
        }

        public readonly Vector2L Rotate90()
        {
            return SwapXY() * new Vector2L(-1, 1);
        }

        public readonly Vector2L RotateM90()
        {
            return SwapXY() * new Vector2L(1, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2L v1, Vector2L v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2L pt1, Vector2L pt2, Vector2L pt3)
        {
            return CrossProduct(pt2 - pt1, pt3 - pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2L pt1, Vector2L pt2, Vector2L pt3)
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

        public static Vector2L Min(ReadOnlySpan<Vector2L> values) => new(MemoryMarshal.Cast<Vector2L, Vector128<long>>(values).Min());

        public static Vector2L Max(ReadOnlySpan<Vector2L> values) => new(MemoryMarshal.Cast<Vector2L, Vector128<long>>(values).Max());

        public static Vector2L Sum(ReadOnlySpan<Vector2L> values) => new(MemoryMarshal.Cast<Vector2L, Vector128<long>>(values).Sum());

    
        public readonly Vector2D ToDouble() => new (Vector128.ConvertToDouble(vector));

        public readonly double LengthD() => ToDouble().Length();

        public readonly float LengthF() => ToFloat().Length();

        public readonly double LengthSquaredD() => ToDouble().LengthSquared();

        public readonly float LengthSquaredF() => ToFloat().LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2L v1, Vector2L v2)
        {
            return Vector2D.CrossProduct(v1.ToDouble(), v2.ToDouble());
        }

        public static double DotD(Vector2L value1, Vector2L value2)
        {
            return Vector2D.Dot(value1.ToDouble(), value2.ToDouble());
        }

        public static Vector2L Lerp(Vector2L value1, Vector2L value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }
    }
}
