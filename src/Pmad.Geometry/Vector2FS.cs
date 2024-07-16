using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    public partial struct Vector2FS : IEquatable<Vector2FS>, IVectorFP<float, Vector2FS>
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2FS(Vector2 vector)
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }

        public static Vector2FS Lerp(Vector2FS value1, Vector2FS value2, float amount)
        {
            return (value1 * (1.0f - amount)) + (value2 * amount);
        }

        public readonly float Length() => MathF.Sqrt(LengthSquared());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2 ToVector2() => new (X, Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Atan2()
        {
            return MathF.Atan2(Y, X);
        }

        public readonly double LengthD() => Length();

        public readonly float LengthF() => Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => LengthSquared();

        public readonly float LengthSquared() => (X * X) + (Y * Y);

        public static Vector2FS Normalize(Vector2FS value)
        {
            return value / value.Length();
        }

        public static float Dot(Vector2FS value1, Vector2FS value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        public static double DotD(Vector2FS value1, Vector2FS value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2FS IVectorFP<float, Vector2FS>.Normalize()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Area()
        {
            return X * Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2FS Floor()
        {
            return new(MathF.Floor(X), MathF.Floor(Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2FS Ceiling()
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProductF(Vector2FS v1, Vector2FS v2) => CrossProduct(v1, v2);
    }
}
