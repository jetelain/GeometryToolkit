using System.Numerics;

namespace Pmad.Geometry.Shapes
{
    /// <summary>Extension methods on <see cref="ShapeSettings{TPrimitive,TVector}"/> for parsing WKT (Well-Known Text) representations.</summary>
    public static class TextParserExtensions
    {
        /// <summary>Parses a WKT <c>LINESTRING</c> representation into a <see cref="Path{TPrimitive,TVector}"/>.</summary>
        public static Path<TPrimitive, TVector> ParsePath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePath(settings, text);
        }

        /// <summary>Parses a WKT <c>MULTILINESTRING</c> representation into a <see cref="MultiPath{TPrimitive,TVector}"/>.</summary>
        public static MultiPath<TPrimitive, TVector> ParseMultiPath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParseMultiPath(settings, text);
        }

        /// <summary>Parses a WKT <c>POLYGON</c> representation into a <see cref="Polygon{TPrimitive,TVector}"/>.</summary>
        public static Polygon<TPrimitive, TVector> ParsePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePolygon(settings, text);
        }

        /// <summary>Parses a WKT <c>MULTIPOLYGON</c> representation into a <see cref="MultiPolygon{TPrimitive,TVector}"/>.</summary>
        public static MultiPolygon<TPrimitive, TVector> ParseMultiPolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParseMultiPolygon(settings, text);
        }

        /// <summary>Parses a WKT geometry into a <see cref="PolygonSet{TPrimitive,TVector}"/>.</summary>
        public static PolygonSet<TPrimitive, TVector> ParsePolygonSet<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePolygonSet(settings, text);
        }
    }
}
