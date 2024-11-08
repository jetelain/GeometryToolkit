using System.Numerics;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry.Shapes
{
    public struct ShapeTransforms<TPrimitive, TVector, TShape>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TShape : IShapeWithTransform<TPrimitive, TVector, TShape>
    {
        private readonly TShape _shape;

        internal ShapeTransforms(TShape shape)
        {
            _shape = shape;
        }

        public TShape Scale(int scale)
        {
            if (_shape is PolygonSet<TPrimitive, TVector> ps)
            {
                return (TShape)(object)ps.TransformClipper(new MultiplyTransform<long, Vector2L>(scale));
            }
            return _shape.Transform(new MultiplyTransform<TPrimitive,TVector>(TPrimitive.CreateChecked(scale)));
        }

        public TShape ReverseScale(int scale)
        {
            if (_shape is PolygonSet<TPrimitive, TVector> ps)
            {
                return (TShape)(object)ps.TransformClipper(new DivideTransform<long, Vector2L>(scale));
            }
            return _shape.Transform(new DivideTransform<TPrimitive, TVector>(TPrimitive.CreateChecked(scale)));
        }

        public TShape Scale(TPrimitive scale)
        {
            return _shape.Transform(new MultiplyTransform<TPrimitive, TVector>(scale));
        }

        public TShape ReverseScale(TPrimitive scale)
        {
            return _shape.Transform(new DivideTransform<TPrimitive, TVector>(scale));
        }
    }
}
