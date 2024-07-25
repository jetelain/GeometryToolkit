using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json
{
    public static class GeoJsonExtensions
    {
        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this Polygon<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this Path<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this MultiPolygon<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this IReadOnlyCollection<Path<TPrimitive, TVector>> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }
    }
}
