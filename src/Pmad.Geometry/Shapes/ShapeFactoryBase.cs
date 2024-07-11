﻿using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public abstract class ShapeFactoryBase<TPrimitive, TVector, TPolygon, TFactory>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TPolygon : PolygonBase<TPrimitive, TVector, TPolygon, TFactory>
        where TFactory : ShapeFactoryBase<TPrimitive, TVector, TPolygon, TFactory>
    {

        public abstract Clipper2Lib.Point64 ToClipper(TVector vector);

        public abstract TVector FromClipper(Clipper2Lib.Point64 vector);

        public abstract double ScaleForClipper { get; }

        public abstract TPolygon CreatePolygon(IReadOnlyList<TVector> shell, IReadOnlyList<IReadOnlyList<TVector>> holes);

        public abstract TPolygon CreatePolygon(IReadOnlyList<TVector> shell);

        internal abstract IEnumerable<TPolygon> FromClipper(PolyPath64 polyTree64);

        public TPolygon CreateRectangle(VectorEnvelope<TVector> envelope)
        {
            return CreateRectangle(envelope.Min, envelope.Max);
        }

        public TPolygon CreateRectangle(TVector p1, TVector p2)
        {
            return CreatePolygon(new List<TVector>(5)
            {
                p1,
                Vectors.Create<TPrimitive,TVector>(p1.X, p2.X),
                p2,
                Vectors.Create<TPrimitive,TVector>(p2.X, p1.X),
                p1
            });
        }
    }
}
