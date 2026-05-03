using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>Extension methods on <see cref="ShapeSettings{TPrimitive,TVector}"/> for creating common shapes.</summary>
    public static class CreateExtensions
    {
        /// <summary>Creates a rectangle polygon from the given envelope.</summary>
        public static Polygon<TPrimitive, TVector> CreateRectanglePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, VectorEnvelope<TVector> envelope)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return CreateRectanglePolygon(settings, envelope.Min, envelope.Max);
        }

        /// <summary>Creates a rectangle polygon with corners at <paramref name="p1"/> and <paramref name="p2"/>.</summary>
        public static Polygon<TPrimitive, TVector> CreateRectanglePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, TVector p1, TVector p2)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Polygon<TPrimitive, TVector>(settings, new ReadOnlyArray<TVector>(
                p1,
                TVector.Create(p1.X, p2.Y),
                p2,
                TVector.Create(p2.X, p1.Y),
                p1
            ));
        }

        /// <summary>Creates a polygon with the given shell and holes.</summary>
        public static Polygon<TPrimitive, TVector> CreatePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell, ReadOnlyArray<ReadOnlyArray<TVector>> holes)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Polygon<TPrimitive, TVector>(settings, shell, holes);
        }

        /// <summary>Creates a polygon with the given shell and no holes.</summary>
        public static Polygon<TPrimitive, TVector> CreatePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Polygon<TPrimitive, TVector>(settings, shell);
        }

        /// <summary>Creates a path from the given ordered list of points.</summary>
        public static Path<TPrimitive, TVector> CreatePath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Path<TPrimitive, TVector>(settings, points);
        }

        /// <summary>
        /// Creates a polygon approximation of a circle.
        /// </summary>
        /// <param name="settings">Coordinate space settings.</param>
        /// <param name="center">Centre of the circle.</param>
        /// <param name="radius">Radius in vector units.</param>
        /// <param name="count">Number of sides of the polygon (default 12).</param>
        public static Polygon<TPrimitive, TVector> CreateCirclePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, TVector center, double radius, int count = 12)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            var points = new TVector[count + 1];
            for (int i = 0; i < count; i++)
            {
                (var sin, var cos) = Math.SinCos(i * Math.PI * 2 / count);
                points[i] = TVector.Create(cos * radius, sin * radius) + center;
            }
            points[count] = points[0];
            return new Polygon<TPrimitive, TVector>(settings, new ReadOnlyArray<TVector>(points));
        }
    }
}
