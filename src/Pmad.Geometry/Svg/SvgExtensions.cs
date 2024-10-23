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
            svg.AppendPolygon(polygon);
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this MultiPolygon<TPrimitive, TVector> polygons)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            if (polygons.Count == 0)
            {
                return string.Empty;
            }
            var first = polygons[0];
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(first.Settings);
            svg.AppendPolygon(first);
            foreach (var other in polygons.Skip(1))
            {
                svg.Append(' ');
                svg.AppendPolygon(other);
            }
            return svg.ToString();
        }
    }
}
