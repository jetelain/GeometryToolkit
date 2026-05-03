using System.Numerics;

namespace Pmad.Geometry
{
    /// <summary>
    /// 2×2 matrix for linear transformations (rotation, scale) without translation.
    /// </summary>
    /// <typeparam name="TPrimitive">Floating-point scalar type.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    /// <typeparam name="TMatrix">Concrete matrix type implementing this interface.</typeparam>
    public interface IMatrix2x2<TPrimitive, TVector, TMatrix> : IMatrix<TVector>, IEquatable<TMatrix>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TMatrix : struct, IMatrix2x2<TPrimitive, TVector, TMatrix>
    {
        /// <summary>Element at row 1, column 1.</summary>
        TPrimitive M11 { get; }

        /// <summary>Element at row 1, column 2.</summary>
        TPrimitive M12 { get; }

        /// <summary>Element at row 2, column 1.</summary>
        TPrimitive M21 { get; }

        /// <summary>Element at row 2, column 2.</summary>
        TPrimitive M22 { get; }

        /// <summary>Creates a rotation matrix for the given angle in radians.</summary>
        abstract static TMatrix CreateRotation(TPrimitive radians);

        /// <summary>Creates a rotation matrix for the given angle in radians specified as a <see langword="double"/>.</summary>
        abstract static TMatrix CreateRotationD(double radians);

        /// <summary>The identity matrix.</summary>
        abstract static TMatrix Identity { get; }
    }
}
