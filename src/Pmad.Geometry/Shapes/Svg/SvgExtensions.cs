using System.Numerics;

namespace Pmad.Geometry.Shapes.Svg
{
    public static class SvgExtensions
    {
        public static SvgPathBuilder<TPrimitive, TVector> CreateSvgPathBuilder<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new SvgPathBuilder<TPrimitive, TVector>(settings);
        }

        public static string ToSvgPath<TPrimitive, TVector>(this Polygon<TPrimitive, TVector> polygon)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(polygon.Settings);
            svg.AppendPolygon(polygon);
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this MultiPolygon<TPrimitive, TVector> multiPolygon)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            if (multiPolygon.Count == 0)
            {
                return string.Empty;
            }
            var first = multiPolygon[0];
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(first.Settings);
            svg.AppendPolygon(first);
            foreach (var other in multiPolygon.Skip(1))
            {
                svg.Append(' ');
                svg.AppendPolygon(other);
            }
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this PolygonSet<TPrimitive, TVector> polygonSet)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            if (polygonSet.Count == 0)
            {
                return string.Empty;
            }
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(polygonSet.Settings);
            var paths = polygonSet.ToClipper();
            svg.AppendClosedPath(polygonSet.Settings.FromClipper(paths[0]).AsSpan());
            for (int i = 1; i < paths.Count; ++i)
            {
                svg.Append(' ');
                svg.AppendClosedPath(polygonSet.Settings.FromClipper(paths[i]).AsSpan());
            }
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this Path<TPrimitive, TVector> path)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(path.Settings);
            svg.AppendPath(path);
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this MultiPath<TPrimitive, TVector> multiPath)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            if (multiPath.Count == 0)
            {
                return string.Empty;
            }
            var first = multiPath[0];
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(first.Settings);
            svg.AppendPath(first);
            for (int i = 1; i < multiPath.Count; ++i)
            {
                svg.Append(' ');
                svg.AppendPath(multiPath[i]);
            }
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this RotatedRectangle<TPrimitive, TVector> rectangle)
            where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        {
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(rectangle.Settings);
            svg.AppendClosedPath(rectangle.ToPolygon().Shell.AsSpan());
            return svg.ToString();
        }

        public static string ToSvgPath<TPrimitive, TVector>(this Circle<TPrimitive, TVector> circle)
            where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        {
            using var svg = new SvgPathBuilder<TPrimitive, TVector>(circle.Settings);
            svg.AppendCircle(circle.Center, circle.Radius);
            return svg.ToString();
        }
    }
}
