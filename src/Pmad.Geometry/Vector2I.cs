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
    }
}
