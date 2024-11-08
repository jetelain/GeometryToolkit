using System.Numerics;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// Generates a new shape from an existing with transformations
    /// </summary>
    /// <typeparam name="TPrimitive"></typeparam>
    /// <typeparam name="TVector"></typeparam>
    /// <typeparam name="TShape"></typeparam>
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

        /// <summary>
        /// Scale shape by specified factor, Multiply all coordinates by the factor
        /// </summary>
        /// <param name="scale">Factor</param>
        /// <returns>A new shape</returns>
        public TShape Scale(int scale)
        {
            if (_shape is PolygonSet<TPrimitive, TVector> ps)
            {
                // Internal representation is long, so we can directly multiply by integer factor without convertion
                return (TShape)(object)ps.TransformClipper(new MultiplyTransform<long, Vector2L>(scale));
            }
            return _shape.Transform(new MultiplyTransform<TPrimitive,TVector>(TPrimitive.CreateChecked(scale)));
        }

        /// <summary>
        /// Scale back shape by specified factor, Divide all coordinates by the factor
        /// </summary>
        /// <param name="scale">Factor</param>
        /// <returns>A new shape</returns>
        public TShape ReverseScale(int scale)
        {
            if (_shape is PolygonSet<TPrimitive, TVector> ps)
            {
                // Internal representation is long, so we can directly divide by integer factor without convertion
                return (TShape)(object)ps.TransformClipper(new DivideTransform<long, Vector2L>(scale));
            }
            return _shape.Transform(new DivideTransform<TPrimitive, TVector>(TPrimitive.CreateChecked(scale)));
        }

        /// <summary>
        /// Scale shape by specified factor, Multiply all coordinates by the factor
        /// </summary>
        /// <param name="scale">Factor</param>
        /// <returns>A new shape</returns>
        public TShape Scale(TPrimitive scale)
        {
            return _shape.Transform(new MultiplyTransform<TPrimitive, TVector>(scale));
        }

        /// <summary>
        /// Scale back shape by specified factor, Divide all coordinates by the factor
        /// </summary>
        /// <param name="scale">Factor</param>
        /// <returns>A new shape</returns>
        public TShape ReverseScale(TPrimitive scale)
        {
            return _shape.Transform(new DivideTransform<TPrimitive, TVector>(scale));
        }
    }
}
