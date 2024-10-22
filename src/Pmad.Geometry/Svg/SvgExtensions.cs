using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Svg
{
    public static class SvgExtensions
    {
        public static string ToSvgPath<TPrimitive, TVector>(this Polygon<TPrimitive, TVector> polygon)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(polygon.Settings);
            svg.AppendSvgClosedPath(polygon.Shell.AsSpan());
            foreach (var hole in polygon.Holes)
            {
                svg.Append(' ');
                svg.AppendSvgClosedPath(hole.AsSpan());
            }
            return svg.ToString();
        }
    }
}
