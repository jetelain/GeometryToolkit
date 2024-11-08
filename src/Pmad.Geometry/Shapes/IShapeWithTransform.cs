using System.Numerics;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry.Shapes
{
    public interface IShapeWithTransform<TPrimitive, TVector, TShape>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TShape : IShapeWithTransform<TPrimitive, TVector, TShape>
    {
        TShape Transform<TTransform>(TTransform transform)
            where TTransform : ITransform<TVector>;
    }
}
