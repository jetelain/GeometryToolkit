using System.Numerics;

namespace Pmad.Geometry
{
    public interface IMatrix3x2<TPrimitive, TVector, TMatrix> : IMatrix<TVector>, IEquatable<TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix3x2<TPrimitive, TVector, TMatrix>
    {
        TPrimitive M11 { get; }

        TPrimitive M12 { get; }

        TPrimitive M21 { get; }

        TPrimitive M22 { get; }

        TPrimitive M31 { get; }

        TPrimitive M32 { get; }

        abstract static TMatrix CreateRotation(TPrimitive radians, TVector centerPoint);

        abstract static TMatrix CreateRotationD(double radians, TVector centerPoint);

        abstract static TMatrix CreateTranslation(TPrimitive x, TPrimitive y);

        abstract static TMatrix CreateTranslation(TVector translation);
    }
}
