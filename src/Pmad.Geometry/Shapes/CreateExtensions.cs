using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public static class CreateExtensions
    {
        public static Polygon<TPrimitive, TVector> CreateRectanglePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, VectorEnvelope<TVector> envelope)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return CreateRectanglePolygon(settings, envelope.Min, envelope.Max);
        }

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

        public static Polygon<TPrimitive, TVector> CreatePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell, ReadOnlyArray<ReadOnlyArray<TVector>> holes)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Polygon<TPrimitive, TVector>(settings, shell, holes);
        }

        public static Polygon<TPrimitive, TVector> CreatePolygon<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> shell)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Polygon<TPrimitive, TVector>(settings, shell);
        }

        public static Path<TPrimitive, TVector> CreatePath<TPrimitive, TVector>(this ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
            where TPrimitive : unmanaged, INumber<TPrimitive>
            where TVector : struct, IVector2<TPrimitive, TVector>
        {
            return new Path<TPrimitive, TVector>(settings, points);
        }

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
