using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Pmad.Geometry
{
    public partial struct Vector2L : IEquatable<Vector2L>
    {
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProductScalar(Vector2L v1, Vector2L v2)
        {
            return Vector2D.CrossProductScalar(v1.ToDouble(), v2.ToDouble());
        }

        public static double DotD(Vector2L value1, Vector2L value2)
        {
            return Vector2D.Dot(value1.ToDouble(), value2.ToDouble());
        }
    }
}
