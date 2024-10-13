using System.Numerics;

namespace Pmad.Geometry.Shapes
{
    public static class TextParserExtensions
    {
        public static Path<TPrimitive, TVector> ParsePath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePath(settings, text);
        }

        public static MultiPath<TPrimitive, TVector> ParseMultiPath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParseMultiPath(settings, text);
        }

        public static Polygon<TPrimitive, TVector> ParsePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePolygon(settings, text);
        }

        public static MultiPolygon<TPrimitive, TVector> ParseMultiPolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParseMultiPolygon(settings, text);
        }

        public static PolygonSet<TPrimitive, TVector> ParsePolygonSet<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, string text)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return TextParser<TPrimitive, TVector>.ParsePolygonSet(settings, text);
        }
    }
}
