using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
	public partial struct Vector2I : IEquatable<Vector2I>, IVector2<int,Vector2I>
	{ 
        private static readonly Vector128<int> SwapXYShuffle = Vector128.Create(1, 0, 3, 2);
	    [FieldOffset(0)]
        private Vector128<int> vector;

        [FieldOffset(0)]
        public int X;

        [FieldOffset(4)]
        public int Y;

        public static Vector2I Zero => default;
        
        public static Vector2I One => new (Vector128<int>.One);

        public static Vector2I UnitX => new (1, 0);

        public static Vector2I UnitY => new (0, 1);

        public static Vector2I MaxValue => new (int.MaxValue);

        public static Vector2I MinValue => new (int.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Create(int x, int y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Create(double x, double y) => new ((int)x, (int)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I(int x, int y)
        {
            vector = Vector128.Create(x, y, 0, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I(int value)
        {
            vector = Vector128.Create(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2I(Vector128<int> vector)
        {
            this.vector = vector;
        }

        int IVector2<int, Vector2I>.X { get => X; set => X = value; }

        int IVector2<int, Vector2I>.Y { get => Y; set => Y = value; }

        public Vector128<int> Vector
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2I left, Vector2I right)
            => left.vector != right.vector;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2I left, Vector2I right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, Vector2I right)
            => new (left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, int right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(int left, Vector2I right)
            => new (left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator /(Vector2I left, Vector2I right)
            => new (left.vector / right.vector.WithElement(2, 1).WithElement(3, 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator /(Vector2I left, int right)
            => new (left.vector / right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator *(Vector2I left, double right)
            => new((int)(left.X * right), (int)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator +(Vector2I left, Vector2I right)
            => new (left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator -(Vector2I left, Vector2I right)
            => new (left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I operator -(Vector2I value)
            => new (-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I SwapXYInline()
        { 
            return new(Vector128.Shuffle(vector,Vector128.Create(1, 0, 3, 2)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I SwapXYStatic()
        { 
            return new(Vector128.Shuffle(vector,SwapXYShuffle));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I SwapXY()
        { 
            return new(Y, X);
        }

        public readonly override int GetHashCode()
        {
            return vector.GetHashCode();
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
            return vector == other.vector;
        }

        

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Max(Vector2I value1, Vector2I value2)
        {
            return new(Vector128.Max(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2I Min(Vector2I value1, Vector2I value2)
        {
            return new(Vector128.Min(value1.vector, value2.vector));
        }
        
        public static Vector2I Clamp(Vector2I value, Vector2I min, Vector2I max)
        {
            return new(Vector128.Min(Vector128.Max(value.vector, min.vector), max.vector));
        }

        public readonly bool IsInRange(Vector2I min, Vector2I max)
        {
            // min <= vector && vector <= max
            return Vector128.LessThanOrEqualAll(min.vector, vector) && Vector128.LessThanOrEqualAll(vector, max.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsGreaterThanOrEqualAll(Vector2I other)
        {
            return Vector128.GreaterThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsLessThanOrEqualAll(Vector2I other)
        {
            return Vector128.LessThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Add(Vector2I value)
        {
            return this + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Substract(Vector2I value)
        {
            return this - value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Multiply(Vector2I value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Multiply(double value)
        {
            return new ((int)(X * value), (int)(Y * value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Multiply(int value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Divide(Vector2I value)
        {
            return this / value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Divide(int value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Min(Vector2I other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Max(Vector2I other)
        {
            return Max(this, other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector<Vector2I>.Negate()
        {
            return -this;
        }

        public readonly Vector2I Rotate90()
        {
            return SwapXY() * new Vector2I(-1, 1);
        }
        
        public readonly Vector2I RotateM90()
        {
            return SwapXY() * new Vector2I(1, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2I v1, Vector2I v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2I pt1, Vector2I pt2, Vector2I pt3)
        {            
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2I pt1, Vector2I pt2, Vector2I pt3)
        {            
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2I IVector2<int,Vector2I>.Multiply(int value)
        {
            return this * value;
        }

	}
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
	public partial struct Vector2F : IEquatable<Vector2F>, IVector2<float,Vector2F>
	{ 
        private static readonly Vector128<int> SwapXYShuffle = Vector128.Create(1, 0, 3, 2);
	    [FieldOffset(0)]
        private Vector128<float> vector;

        [FieldOffset(0)]
        public float X;

        [FieldOffset(4)]
        public float Y;

        public static Vector2F Zero => default;
        
        public static Vector2F One => new (Vector128<float>.One);

        public static Vector2F UnitX => new (1, 0);

        public static Vector2F UnitY => new (0, 1);

        public static Vector2F MaxValue => new (float.MaxValue);

        public static Vector2F MinValue => new (float.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Create(float x, float y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Create(double x, double y) => new ((float)x, (float)y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(float x, float y)
        {
            vector = Vector128.Create(x, y, 0, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(float value)
        {
            vector = Vector128.Create(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(Vector128<float> vector)
        {
            this.vector = vector;
        }

        float IVector2<float, Vector2F>.X { get => X; set => X = value; }

        float IVector2<float, Vector2F>.Y { get => Y; set => Y = value; }

        public Vector128<float> Vector
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get => vector;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => vector = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2F left, Vector2F right)
            => left.vector != right.vector;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2F left, Vector2F right)
            => left.vector == right.vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, Vector2F right)
            => new (left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, float right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(float left, Vector2F right)
            => new (left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, Vector2F right)
            => new (left.vector / right.vector.WithElement(2, 1).WithElement(3, 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, float right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator /(Vector2F left, int right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, int right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator *(Vector2F left, double right)
            => new (left.vector * (float)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator +(Vector2F left, Vector2F right)
            => new (left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator -(Vector2F left, Vector2F right)
            => new (left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F operator -(Vector2F value)
            => new (-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2F SwapXYInline()
        { 
            return new(Vector128.Shuffle(vector,Vector128.Create(1, 0, 3, 2)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2F SwapXYStatic()
        { 
            return new(Vector128.Shuffle(vector,SwapXYShuffle));
        }

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

        

        public readonly Vector2D ToDouble() => new ((double)X, (double)Y);

        public readonly override string ToString()
        {
            return FormattableString.Invariant($"({X};{Y})");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Max(Vector2F value1, Vector2F value2)
        {
            return new(Vector128.Max(value1.vector, value2.vector));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Min(Vector2F value1, Vector2F value2)
        {
            return new(Vector128.Min(value1.vector, value2.vector));
        }
        
        public static Vector2F Clamp(Vector2F value, Vector2F min, Vector2F max)
        {
            return new(Vector128.Min(Vector128.Max(value.vector, min.vector), max.vector));
        }

        public readonly bool IsInRange(Vector2F min, Vector2F max)
        {
            // min <= vector && vector <= max
            return Vector128.LessThanOrEqualAll(min.vector, vector) && Vector128.LessThanOrEqualAll(vector, max.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsGreaterThanOrEqualAll(Vector2F other)
        {
            return Vector128.GreaterThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool IsLessThanOrEqualAll(Vector2F other)
        {
            return Vector128.LessThanOrEqualAll(vector, other.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Add(Vector2F value)
        {
            return this + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Substract(Vector2F value)
        {
            return this - value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Multiply(Vector2F value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Multiply(double value)
        {
            return this * (float)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Multiply(int value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Divide(Vector2F value)
        {
            return this / value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Divide(int value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Min(Vector2F other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Max(Vector2F other)
        {
            return Max(this, other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector<Vector2F>.Negate()
        {
            return -this;
        }

        public readonly Vector2F Rotate90()
        {
            return SwapXY() * new Vector2F(-1, 1);
        }
        
        public readonly Vector2F RotateM90()
        {
            return SwapXY() * new Vector2F(1, -1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductD(Vector2F v1, Vector2F v2) => CrossProduct(v1, v2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProduct(Vector2F pt1, Vector2F pt2, Vector2F pt3)
        {            
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProductScalar(Vector2F pt1, Vector2F pt2, Vector2F pt3)
        {            
            return ((float) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (float) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVector2<float,Vector2F>.Multiply(float value)
        {
            return this * value;
        }

	}
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
	public partial struct Vector2L : IEquatable<Vector2L>, IVector2<long,Vector2L>
	{ 
        private static readonly Vector128<long> SwapXYShuffle = Vector128.Create(1L, 0L);
	    [FieldOffset(0)]
        private Vector128<long> vector;

        [FieldOffset(0)]
        public long X;

        [FieldOffset(8)]
        public long Y;

        public static Vector2L Zero => default;
        
        public static Vector2L One => new (Vector128<long>.One);

        public static Vector2L UnitX => new (1, 0);

        public static Vector2L UnitY => new (0, 1);

        public static Vector2L MaxValue => new (long.MaxValue);

        public static Vector2L MinValue => new (long.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Create(long x, long y) => new (x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L Create(double x, double y) => new ((long)x, (long)y);

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
            => new (left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, long right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(long left, Vector2L right)
            => new (left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, Vector2L right)
            => new (left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, long right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator /(Vector2L left, int right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, int right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator *(Vector2L left, double right)
            => new((long)(left.X * right), (long)(left.Y * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator +(Vector2L left, Vector2L right)
            => new (left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator -(Vector2L left, Vector2L right)
            => new (left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2L operator -(Vector2L value)
            => new (-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2L SwapXYInline()
        { 
            return new(Vector128.Shuffle(vector,Vector128.Create(1L, 0L)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2L SwapXYStatic()
        { 
            return new(Vector128.Shuffle(vector,SwapXYShuffle));
        }

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

        
        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Add(Vector2L value)
        {
            return this + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Substract(Vector2L value)
        {
            return this - value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Multiply(Vector2L value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Multiply(double value)
        {
            return new ((long)(X * value), (long)(Y * value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Multiply(int value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Divide(Vector2L value)
        {
            return this / value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Divide(int value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Min(Vector2L other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Max(Vector2L other)
        {
            return Max(this, other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector<Vector2L>.Negate()
        {
            return -this;
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
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2L pt1, Vector2L pt2, Vector2L pt3)
        {            
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2L IVector2<long,Vector2L>.Multiply(long value)
        {
            return this * value;
        }

	}
    [DebuggerDisplay("({X};{Y})")]
    [StructLayout(LayoutKind.Explicit)]
	public partial struct Vector2D : IEquatable<Vector2D>, IVector2<double,Vector2D>
	{ 
        private static readonly Vector128<long> SwapXYShuffle = Vector128.Create(1L, 0L);
	    [FieldOffset(0)]
        private Vector128<double> vector;

        [FieldOffset(0)]
        public double X;

        [FieldOffset(8)]
        public double Y;

        public static Vector2D Zero => default;
        
        public static Vector2D One => new (Vector128<double>.One);

        public static Vector2D UnitX => new (1, 0);

        public static Vector2D UnitY => new (0, 1);

        public static Vector2D MaxValue => new (double.MaxValue);

        public static Vector2D MinValue => new (double.MinValue);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D Create(double x, double y) => new (x, y);


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
            => new (left.vector * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D left, double right)
            => new (left.vector * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(double left, Vector2D right)
            => new (left * right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, Vector2D right)
            => new (left.vector / right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, double right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator /(Vector2D left, int right)
            => new (left.vector / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator *(Vector2D left, int right)
            => new (left.vector * right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator +(Vector2D left, Vector2D right)
            => new (left.vector + right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D left, Vector2D right)
            => new (left.vector - right.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2D operator -(Vector2D value)
            => new (-value.vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2D SwapXYInline()
        { 
            return new(Vector128.Shuffle(vector,Vector128.Create(1L, 0L)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2D SwapXYStatic()
        { 
            return new(Vector128.Shuffle(vector,SwapXYShuffle));
        }

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

        
        public readonly Vector2F ToFloat() => new ((float)X, (float)Y);


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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Add(Vector2D value)
        {
            return this + value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Substract(Vector2D value)
        {
            return this - value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Multiply(Vector2D value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Multiply(double value)
        {
            return this * (double)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Multiply(int value)
        {
            return this * value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Divide(Vector2D value)
        {
            return this / value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Divide(int value)
        {
            return this / value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Min(Vector2D other)
        {
            return Min(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Max(Vector2D other)
        {
            return Max(this, other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector<Vector2D>.Negate()
        {
            return -this;
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
            return CrossProduct(pt2-pt1, pt3-pt2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2D pt1, Vector2D pt2, Vector2D pt3)
        {            
            return ((double) (pt2.X - pt1.X) * (pt3.Y - pt2.Y) -
                    (double) (pt2.Y - pt1.Y) * (pt3.X - pt2.X));
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVector2<double,Vector2D>.Multiply(double value)
        {
            return this * value;
        }

	}
}
