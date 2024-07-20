namespace Pmad.Geometry
{
    public partial struct Vector2LS : IEquatable<Vector2LS>
    {
        public readonly double LengthD() => ToDoubleS().Length();

        public readonly float LengthF() => ToFloatS().Length();

        public readonly double LengthSquaredD() => ToDoubleS().LengthSquared();

        public readonly float LengthSquaredF() => ToFloatS().LengthSquared();

        public static double DotD(Vector2LS value1, Vector2LS value2)
        {
            return Vector2DS.Dot(value1.ToDoubleS(), value2.ToDoubleS());
        }
        public static Vector2LS Lerp(Vector2LS value1, Vector2LS value2, double amount)
        {
            return (value1 * (1.0d - amount)) + (value2 * amount);
        }
    }
}
