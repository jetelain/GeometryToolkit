using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json
{
    /// <summary>Extension methods for converting Pmad.Geometry shapes to <see cref="GeoJsonGeometry{TPrimitive,TVector}"/>.</summary>
    public static class GeoJsonExtensions
    {
        /// <summary>Wraps a <see cref="Polygon{TPrimitive,TVector}"/> in a GeoJSON geometry object.</summary>
        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this Polygon<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        /// <summary>Wraps a <see cref="Path{TPrimitive,TVector}"/> in a GeoJSON geometry object.</summary>
        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this Path<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        /// <summary>Wraps a <see cref="MultiPolygon{TPrimitive,TVector}"/> in a GeoJSON geometry object.</summary>
        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this MultiPolygon<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }

        /// <summary>Wraps a <see cref="MultiPath{TPrimitive,TVector}"/> in a GeoJSON geometry object.</summary>
        public static GeoJsonGeometry<TPrimitive, TVector> ToGeoJson<TPrimitive, TVector>(this MultiPath<TPrimitive, TVector> geometry)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new GeoJsonGeometry<TPrimitive, TVector>(geometry);
        }
    }
}
