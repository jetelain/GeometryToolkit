using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public partial struct Vector2DS : IEquatable<Vector2DS>, IVectorFP<double, Vector2DS>
    {
        public static Vector2DS Lerp(Vector2DS value1, Vector2DS value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }

        public readonly double Length() => Math.Sqrt(LengthSquared());
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double Atan2()
        {
            return Math.Atan2(Y, X);
        }

        public readonly double LengthD() => Length();

        public readonly float LengthF() => (float)Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => (float)LengthSquared();

        public readonly double LengthSquared() => (X * X) + (Y * Y);

        public static Vector2DS Normalize(Vector2DS value)
        {
            return value / value.Length();
        }

        public static double Dot(Vector2DS value1, Vector2DS value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }
        public static double DotD(Vector2DS value1, Vector2DS value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly double Area()
        {
            return X * Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2DS Floor()
        {
            return new(Math.Floor(X), Math.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2DS Ceiling()
        {
            return new(Math.Ceiling(X), Math.Ceiling(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I FloorI()
        {
            return new((int)Math.Floor(X), (int)Math.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2I CeilingI()
        {
            return new((int)Math.Ceiling(X), (int)Math.Ceiling(Y));
        }
    }
}
