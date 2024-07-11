﻿using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public partial struct Vector2D : IEquatable<Vector2D>, IVectorFP<double,Vector2D>
    {
        public static Vector2D Lerp(Vector2D value1, Vector2D value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }

        public readonly double Length() => Math.Sqrt(LengthSquared());

        public readonly double Atan2()
        {
            return Math.Atan2(Y, X);
        }

        public readonly Vector2D ToDouble() => this;

        public readonly double LengthD() => Length();

        public readonly float LengthF() => (float)Length();

        public readonly double LengthSquaredD() => LengthSquared();

        public readonly float LengthSquaredF() => (float)LengthSquared();

        public readonly double LengthSquared() => Vector128.Dot(vector, vector);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2D v1, Vector2D v2)
        {
            var temp = v1 * v2.SwapXY();
            return temp.X - temp.Y;
            //return v2.Y * v1.X - v2.X * v1.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2D v1, Vector2D v2)
        {
            return v2.Y * v1.X - v2.X * v1.Y;
        }

        public static Vector2D Normalize(Vector2D value)
        {
            return value / value.Length();
        }

        public static double Dot(Vector2D v1, Vector2D v2)
        {
            return Vector128.Dot(v1.vector, v2.vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly Vector2D IVectorFP<double, Vector2D>.Normalize()
        {
            return Normalize(this);
        }
    }
}
