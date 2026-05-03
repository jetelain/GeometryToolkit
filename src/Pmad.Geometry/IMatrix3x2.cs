using System.Numerics;

namespace Pmad.Geometry
{
    /// <summary>
    /// 3×2 affine matrix for 2D transformations including translation.
    /// Combines a 2×2 linear part and a translation vector.
    /// </summary>
    /// <typeparam name="TPrimitive">Floating-point scalar type.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    /// <typeparam name="TMatrix">Concrete matrix type implementing this interface.</typeparam>
    public interface IMatrix3x2<TPrimitive, TVector, TMatrix> : IMatrix<TVector>, IEquatable<TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix3x2<TPrimitive, TVector, TMatrix>
    {
        /// <summary>Element at row 1, column 1 (linear part).</summary>
        TPrimitive M11 { get; }

        /// <summary>Element at row 1, column 2 (linear part).</summary>
        TPrimitive M12 { get; }

        /// <summary>Element at row 2, column 1 (linear part).</summary>
        TPrimitive M21 { get; }

        /// <summary>Element at row 2, column 2 (linear part).</summary>
        TPrimitive M22 { get; }

        /// <summary>Translation component along the X axis.</summary>
        TPrimitive M31 { get; }

        /// <summary>Translation component along the Y axis.</summary>
        TPrimitive M32 { get; }

        /// <summary>Creates a rotation matrix around <paramref name="centerPoint"/> for the given angle in radians.</summary>
        abstract static TMatrix CreateRotation(TPrimitive radians, TVector centerPoint);

        /// <summary>Creates a rotation matrix around <paramref name="centerPoint"/> for the given angle in radians specified as a <see langword="double"/>.</summary>
        abstract static TMatrix CreateRotationD(double radians, TVector centerPoint);

        /// <summary>Creates a translation matrix for the given components.</summary>
        abstract static TMatrix CreateTranslation(TPrimitive x, TPrimitive y);

        /// <summary>Creates a translation matrix for the given vector.</summary>
        abstract static TMatrix CreateTranslation(TVector translation);
    }
}
