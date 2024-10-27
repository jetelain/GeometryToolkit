using System.Numerics;

namespace Pmad.Geometry.Transforms
{
    internal interface ITransformVect<TPrimitive, TVector>
        where TPrimitive : unmanaged
        where TVector : struct
    {
        TVector Transform(TVector vector);

        Vector<TPrimitive> Transform(Vector<TPrimitive> vector);
    }
}
