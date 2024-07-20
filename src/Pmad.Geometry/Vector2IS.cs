namespace Pmad.Geometry
{
    public partial struct Vector2IS : IEquatable<Vector2IS>
    {
        public readonly double LengthD() => ToDoubleS().Length();

        public readonly float LengthF() => ToFloatS().Length();

        public readonly double LengthSquaredD() => ToDoubleS().LengthSquared();

        public readonly float LengthSquaredF() => ToFloatS().LengthSquared();

        public static double DotD(Vector2IS value1, Vector2IS value2)
        {
            return Vector2FS.Dot(value1.ToFloatS(), value2.ToFloatS());
        }

        public static Vector2IS Lerp(Vector2IS value1, Vector2IS value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }
    }
}
