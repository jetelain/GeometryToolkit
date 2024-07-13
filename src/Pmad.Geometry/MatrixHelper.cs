namespace Pmad.Geometry
{
    internal static class MatrixHelper
    {
        public static (double Sin, double Cos) SinCos(double radians)
        {
            if (radians > -1.7453294E-05 && radians < 1.7453294E-05)
            {
                return (0,1);
            }
            if (radians > 1.570779 && radians < 1.5708138)
            {
                return (1, 0);
            }
            if (radians < -3.1415753 || radians > 3.1415753)
            {
                return (0, -1);
            }
            if (radians > -1.5708138 && radians < -1.570779)
            {
                return (-1, 0);
            }
            return Math.SinCos(radians);
        }

        public static (float Sin, float Cos) SinCos(float radians)
        {
            if (radians > -1.7453294E-05f && radians < 1.7453294E-05f)
            {
                return (0, 1);
            }
            if (radians > 1.570779f && radians < 1.5708138f)
            {
                return (1, 0);
            }
            if (radians < -3.1415753f || radians > 3.1415753f)
            {
                return (0, -1);
            }
            if (radians > -1.5708138f && radians < -1.570779f)
            {
                return (-1, 0);
            }
            return MathF.SinCos(radians);
        }
    }
}
