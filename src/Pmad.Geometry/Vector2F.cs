using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public partial struct Vector2F : IEquatable<Vector2F>, IVectorFP<float, Vector2F>
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2F(Vector2 vector)
        {
            this.vector = vector.AsVector128();
        }

        public static Vector2F Lerp(Vector2F value1, Vector2F value2, float amount)
        {
            return (value1 * (1.0f - amount)) + (value2 * amount);
        }

        public readonly float Length() => MathF.Sqrt(LengthSquared());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Vector2 ToVector2() => vector.AsVector2();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Atan2()
        {
            return MathF.Atan2(Y, X);
        }

        public readonly Vector2F ToFloat() => this;

        public readonly double LengthD() => Length();

        public readonly float LengthF() => Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => LengthSquared();

        public readonly float LengthSquared() => Vector128.Dot(vector, vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProduct(Vector2F v1, Vector2F v2)
        {
            var temp = v1 * v2.SwapXY();
            return temp.X - temp.Y;
            //return (double)v2.Y * v1.X - (double)v2.X * v1.Y;
        }

        public static Vector2F Normalize(Vector2F value)
        {
            return value / value.Length();
        }

        public static float Dot(Vector2F v1, Vector2F v2)
        {
            return Vector128.Dot(v1.vector, v2.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2F IVectorFP<float,Vector2F>.Normalize()
        {
            return Normalize(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Area()
        {
            return X * Y;
        }
    }
}
