using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public partial struct Vector2I : IEquatable<Vector2I>
    {
        public readonly Vector2F ToFloat() => new(Vector128.ConvertToSingle(vector));

        public readonly double LengthD() => ToDouble().Length();

        public readonly float LengthF() => ToFloat().Length();

        public readonly double LengthSquaredD() => ToDouble().LengthSquared();

        public readonly float LengthSquaredF() => ToFloat().LengthSquared();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(Vector2I v1, Vector2I v2)
        {
            return Vector2F.CrossProduct(v1.ToFloat(), v2.ToFloat());
        }

        public static double DotD(Vector2I value1, Vector2I value2)
        {
            return Vector2F.Dot(value1.ToFloat(), value2.ToFloat());
        }

        public static Vector2I Lerp(Vector2I value1, Vector2I value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }

    }
}
