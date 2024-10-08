﻿using System.Numerics;

namespace Pmad.Geometry
{
    public interface IMatrix2x2<TPrimitive, TVector, TMatrix> : IMatrix<TVector>, IEquatable<TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix2x2<TPrimitive, TVector, TMatrix>
    {
        TPrimitive M11 { get; }

        TPrimitive M12 { get; }

        TPrimitive M21 { get; }

        TPrimitive M22 { get; }

        abstract static TMatrix CreateRotation(TPrimitive radians);

        abstract static TMatrix CreateRotationD(double radians);

        abstract static TMatrix Identity { get; }
    }
}
