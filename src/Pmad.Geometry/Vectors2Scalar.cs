﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [DebuggerDisplay("({X};{Y})")]
	internal partial struct Vector2IS : IEquatable<Vector2IS>, IVector2<int,Vector2IS>
	{
        public static Vector2IS Zero => default;
        
        public static Vector2IS One => new (1);

        public static Vector2IS UnitX => new (1, 0);

        public static Vector2IS UnitY => new (0, 1);

        public static Vector2IS MaxValue => new (int.MaxValue);

        public static Vector2IS MinValue => new (int.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS Create(int x, int y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS Create(double x, double y) => new ((int)x, (int)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS Create(long x, long y) => new ((int)x, (int)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2IS(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2IS(int value)
        {
            X = value;
            Y = value;
        }

        public int X;

        public int Y;
        
        int IVector2<int, Vector2IS>.X { get => X; set => X = value; }
        
        int IVector2<int, Vector2IS>.Y { get => Y; set => Y = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2IS left, Vector2IS right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2IS left, Vector2IS right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator *(Vector2IS left, Vector2IS right)
            => new (left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator *(Vector2IS left, int right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator *(int left, Vector2IS right)
            => new (left * right.X, left * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator /(Vector2IS left, Vector2IS right)
            => new (left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator /(Vector2IS left, int right)
            => new (left.X / right, left.Y / right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator *(Vector2IS left, double right)
            => new((int)(left.X * right), (int)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator +(Vector2IS left, Vector2IS right)
            => new (left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator -(Vector2IS left, Vector2IS right)
            => new (left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2IS operator -(Vector2IS value)
            => new (-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2IS SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2IS other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2IS other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        public static Vector2IS Max(Vector2IS value1, Vector2IS value2)
        {
            return new(Math.Max(value1.X, value2.X),Math.Max(value1.Y, value2.Y));
        }

        public static Vector2IS Min(Vector2IS value1, Vector2IS value2)
        {
            return new(Math.Min(value1.X, value2.X),Math.Min(value1.Y, value2.Y));
        }
        
        public static Vector2IS Clamp(Vector2IS value, Vector2IS min, Vector2IS max)
        {
            return new(Math.Clamp(value.X, min.X, max.X),Math.Clamp(value.Y, min.Y, max.Y));
        }

        public readonly bool IsInRange(Vector2IS min, Vector2IS max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2IS other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2IS other)
        {
            return X <= other.X && Y <= other.Y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2IS v1, Vector2IS v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2IS v1, Vector2IS v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2IS pt1, Vector2IS pt2, Vector2IS pt3)
        {
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2IS pt1, Vector2IS pt2, Vector2IS pt3)
        {
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public readonly Vector2FS ToFloatS() => new ((float)X, (float)Y);

        public readonly Vector2DS ToDoubleS() => new ((double)X, (double)Y);

        public readonly Vector2IS Rotate90()
        {
            return new (-Y, X);
        }
        
        public readonly Vector2IS RotateM90()
        {
            return new (Y, -X);
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

        public static Vector2IS Min(ReadOnlySpan<Vector2IS> values)
        {
            //return Vector128Helper<int, Vector2IS>.Min4Bytes(values);
            return values.MinClassic();
        }

        public static Vector2IS Max(ReadOnlySpan<Vector2IS> values)
        {
            //return Vector128Helper<int, Vector2IS>.Max4Bytes(values);
            return values.MaxClassic();
        }

        public static Vector2IS Sum(ReadOnlySpan<Vector2IS> values)
        {
            //return Vector128Helper<int, Vector2IS>.Sum4Bytes(values);
            return values.SumClassic();
        }


	}
    [DebuggerDisplay("({X};{Y})")]
	internal partial struct Vector2FS : IEquatable<Vector2FS>, IVector2<float,Vector2FS>
	{
        public static Vector2FS Zero => default;
        
        public static Vector2FS One => new (1);

        public static Vector2FS UnitX => new (1, 0);

        public static Vector2FS UnitY => new (0, 1);

        public static Vector2FS MaxValue => new (float.MaxValue);

        public static Vector2FS MinValue => new (float.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS Create(float x, float y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS Create(double x, double y) => new ((float)x, (float)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS Create(long x, long y) => new ((float)x, (float)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FS(float x, float y)
        {
            X = x;
            Y = y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FS(float value)
        {
            X = value;
            Y = value;
        }

        public float X;

        public float Y;
        
        float IVector2<float, Vector2FS>.X { get => X; set => X = value; }
        
        float IVector2<float, Vector2FS>.Y { get => Y; set => Y = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2FS left, Vector2FS right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2FS left, Vector2FS right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator *(Vector2FS left, Vector2FS right)
            => new (left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator *(Vector2FS left, float right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator *(float left, Vector2FS right)
            => new (left * right.X, left * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator /(Vector2FS left, Vector2FS right)
            => new (left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator /(Vector2FS left, float right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator /(Vector2FS left, int right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator *(Vector2FS left, int right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator *(Vector2FS left, double right)
            => new((float)(left.X * right), (float)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator +(Vector2FS left, Vector2FS right)
            => new (left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator -(Vector2FS left, Vector2FS right)
            => new (left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2FS operator -(Vector2FS value)
            => new (-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2FS SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2FS other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2FS other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        public static Vector2FS Max(Vector2FS value1, Vector2FS value2)
        {
            return new(Math.Max(value1.X, value2.X),Math.Max(value1.Y, value2.Y));
        }

        public static Vector2FS Min(Vector2FS value1, Vector2FS value2)
        {
            return new(Math.Min(value1.X, value2.X),Math.Min(value1.Y, value2.Y));
        }
        
        public static Vector2FS Clamp(Vector2FS value, Vector2FS min, Vector2FS max)
        {
            return new(Math.Clamp(value.X, min.X, max.X),Math.Clamp(value.Y, min.Y, max.Y));
        }

        public readonly bool IsInRange(Vector2FS min, Vector2FS max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2FS other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2FS other)
        {
            return X <= other.X && Y <= other.Y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProduct(Vector2FS v1, Vector2FS v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2FS v1, Vector2FS v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProduct(Vector2FS pt1, Vector2FS pt2, Vector2FS pt3)
        {
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProductScalar(Vector2FS pt1, Vector2FS pt2, Vector2FS pt3)
        {
            return ((float) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (float) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public readonly Vector2FS ToFloatS() => this;

        public readonly Vector2DS ToDoubleS() => new ((double)X, (double)Y);

        public readonly Vector2FS Rotate90()
        {
            return new (-Y, X);
        }
        
        public readonly Vector2FS RotateM90()
        {
            return new (Y, -X);
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

        public static Vector2FS Min(ReadOnlySpan<Vector2FS> values)
        {
            //return Vector128Helper<float, Vector2FS>.Min4Bytes(values);
            return values.MinClassic();
        }

        public static Vector2FS Max(ReadOnlySpan<Vector2FS> values)
        {
            //return Vector128Helper<float, Vector2FS>.Max4Bytes(values);
            return values.MaxClassic();
        }

        public static Vector2FS Sum(ReadOnlySpan<Vector2FS> values)
        {
            //return Vector128Helper<float, Vector2FS>.Sum4Bytes(values);
            return values.SumClassic();
        }


	}
    [DebuggerDisplay("({X};{Y})")]
	internal partial struct Vector2LS : IEquatable<Vector2LS>, IVector2<long,Vector2LS>
	{
        public static Vector2LS Zero => default;
        
        public static Vector2LS One => new (1);

        public static Vector2LS UnitX => new (1, 0);

        public static Vector2LS UnitY => new (0, 1);

        public static Vector2LS MaxValue => new (long.MaxValue);

        public static Vector2LS MinValue => new (long.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS Create(long x, long y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS Create(double x, double y) => new ((long)x, (long)y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2LS(long x, long y)
        {
            X = x;
            Y = y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2LS(long value)
        {
            X = value;
            Y = value;
        }

        public long X;

        public long Y;
        
        long IVector2<long, Vector2LS>.X { get => X; set => X = value; }
        
        long IVector2<long, Vector2LS>.Y { get => Y; set => Y = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2LS left, Vector2LS right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2LS left, Vector2LS right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator *(Vector2LS left, Vector2LS right)
            => new (left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator *(Vector2LS left, long right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator *(long left, Vector2LS right)
            => new (left * right.X, left * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator /(Vector2LS left, Vector2LS right)
            => new (left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator /(Vector2LS left, long right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator /(Vector2LS left, int right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator *(Vector2LS left, int right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator *(Vector2LS left, double right)
            => new((long)(left.X * right), (long)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator +(Vector2LS left, Vector2LS right)
            => new (left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator -(Vector2LS left, Vector2LS right)
            => new (left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2LS operator -(Vector2LS value)
            => new (-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2LS SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2LS other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2LS other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        public static Vector2LS Max(Vector2LS value1, Vector2LS value2)
        {
            return new(Math.Max(value1.X, value2.X),Math.Max(value1.Y, value2.Y));
        }

        public static Vector2LS Min(Vector2LS value1, Vector2LS value2)
        {
            return new(Math.Min(value1.X, value2.X),Math.Min(value1.Y, value2.Y));
        }
        
        public static Vector2LS Clamp(Vector2LS value, Vector2LS min, Vector2LS max)
        {
            return new(Math.Clamp(value.X, min.X, max.X),Math.Clamp(value.Y, min.Y, max.Y));
        }

        public readonly bool IsInRange(Vector2LS min, Vector2LS max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2LS other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2LS other)
        {
            return X <= other.X && Y <= other.Y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2LS v1, Vector2LS v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2LS v1, Vector2LS v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2LS pt1, Vector2LS pt2, Vector2LS pt3)
        {
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2LS pt1, Vector2LS pt2, Vector2LS pt3)
        {
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public readonly Vector2FS ToFloatS() => new ((float)X, (float)Y);

        public readonly Vector2DS ToDoubleS() => new ((double)X, (double)Y);

        public readonly Vector2LS Rotate90()
        {
            return new (-Y, X);
        }
        
        public readonly Vector2LS RotateM90()
        {
            return new (Y, -X);
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

        public static Vector2LS Min(ReadOnlySpan<Vector2LS> values)
        {
            //return Vector128Helper<long, Vector2LS>.Min8Bytes(values);
            return values.MinClassic();
        }

        public static Vector2LS Max(ReadOnlySpan<Vector2LS> values)
        {
            //return Vector128Helper<long, Vector2LS>.Max8Bytes(values);
            return values.MaxClassic();
        }

        public static Vector2LS Sum(ReadOnlySpan<Vector2LS> values)
        {
            //return Vector128Helper<long, Vector2LS>.Sum8Bytes(values);
            return values.SumClassic();
        }


	}
    [DebuggerDisplay("({X};{Y})")]
	internal partial struct Vector2DS : IEquatable<Vector2DS>, IVector2<double,Vector2DS>
	{
        public static Vector2DS Zero => default;
        
        public static Vector2DS One => new (1);

        public static Vector2DS UnitX => new (1, 0);

        public static Vector2DS UnitY => new (0, 1);

        public static Vector2DS MaxValue => new (double.MaxValue);

        public static Vector2DS MinValue => new (double.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS Create(double x, double y) => new (x, y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS Create(long x, long y) => new ((double)x, (double)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2DS(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2DS(double value)
        {
            X = value;
            Y = value;
        }

        public double X;

        public double Y;
        
        double IVector2<double, Vector2DS>.X { get => X; set => X = value; }
        
        double IVector2<double, Vector2DS>.Y { get => Y; set => Y = value; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2DS left, Vector2DS right)
            => left.X != right.X || left.Y != right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2DS left, Vector2DS right)
            => left.X == right.X && left.Y == right.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator *(Vector2DS left, Vector2DS right)
            => new (left.X * right.X, left.Y * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator *(Vector2DS left, double right)
            => new (left.X * right, left.Y * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator *(double left, Vector2DS right)
            => new (left * right.X, left * right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator /(Vector2DS left, Vector2DS right)
            => new (left.X / right.X, left.Y / right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator /(Vector2DS left, double right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator /(Vector2DS left, int right)
            => new (left.X / right, left.Y / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator *(Vector2DS left, int right)
            => new (left.X * right, left.Y * right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator +(Vector2DS left, Vector2DS right)
            => new (left.X + right.X, left.Y + right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator -(Vector2DS left, Vector2DS right)
            => new (left.X - right.X, left.Y - right.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2DS operator -(Vector2DS value)
            => new (-value.X, -value.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2DS SwapXY()
        {
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }

        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2DS other)
            {
                return Equals(other);
            }
            return false;
        }

        public readonly bool Equals(Vector2DS other)
        {
            return X == other.X && Y == other.Y;
        }

        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        public static Vector2DS Max(Vector2DS value1, Vector2DS value2)
        {
            return new(Math.Max(value1.X, value2.X),Math.Max(value1.Y, value2.Y));
        }

        public static Vector2DS Min(Vector2DS value1, Vector2DS value2)
        {
            return new(Math.Min(value1.X, value2.X),Math.Min(value1.Y, value2.Y));
        }
        
        public static Vector2DS Clamp(Vector2DS value, Vector2DS min, Vector2DS max)
        {
            return new(Math.Clamp(value.X, min.X, max.X),Math.Clamp(value.Y, min.Y, max.Y));
        }

        public readonly bool IsInRange(Vector2DS min, Vector2DS max)
        {
            // min <= vector && vector <= max
            return IsGreaterThanOrEqualAll(min) && IsLessThanOrEqualAll(max);
        }

        public readonly bool IsGreaterThanOrEqualAll(Vector2DS other)
        {
            return X >= other.X && Y >= other.Y;
        }

        public readonly bool IsLessThanOrEqualAll(Vector2DS other)
        {
            return X <= other.X && Y <= other.Y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2DS v1, Vector2DS v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2DS v1, Vector2DS v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2DS pt1, Vector2DS pt2, Vector2DS pt3)
        {
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2DS pt1, Vector2DS pt2, Vector2DS pt3)
        {
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
        }

        public readonly Vector2FS ToFloatS() => new ((float)X, (float)Y);

        public readonly Vector2DS ToDoubleS() => this;

        public readonly Vector2DS Rotate90()
        {
            return new (-Y, X);
        }
        
        public readonly Vector2DS RotateM90()
        {
            return new (Y, -X);
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

        public static Vector2DS Min(ReadOnlySpan<Vector2DS> values)
        {
            //return Vector128Helper<double, Vector2DS>.Min8Bytes(values);
            return values.MinClassic();
        }

        public static Vector2DS Max(ReadOnlySpan<Vector2DS> values)
        {
            //return Vector128Helper<double, Vector2DS>.Max8Bytes(values);
            return values.MaxClassic();
        }

        public static Vector2DS Sum(ReadOnlySpan<Vector2DS> values)
        {
            //return Vector128Helper<double, Vector2DS>.Sum8Bytes(values);
            return values.SumClassic();
        }


	}
}
