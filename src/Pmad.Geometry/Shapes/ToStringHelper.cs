using System.Globalization;
using System.Numerics;
using System.Text;

namespace Pmad.Geometry.Shapes
{
    static class ToStringHelper<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {

        internal static void ToStringAppend(StringBuilder sb, ReadOnlySpan<TVector> shell)
        {
            sb.Append("(");
            if (shell.Length > 0)
            {
                var p = shell[0];
                sb.Append(CultureInfo.InvariantCulture, $"{p.X} {p.Y}");
                for (var i = 1; i < shell.Length; i++)
                {
                    p = shell[i];
                    sb.Append(CultureInfo.InvariantCulture, $", {p.X} {p.Y}");
                }
            }
            sb.Append(")");
        }

    }
}
