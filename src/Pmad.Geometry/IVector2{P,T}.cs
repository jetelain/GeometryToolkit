using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    /// <summary>
    /// 2 dimensions vector
    /// </summary>
    /// <typeparam name="TPrimitive">Primitive number type</typeparam>
    /// <typeparam name="TVector">Vector type</typeparam>
    public interface IVector2<TPrimitive,TVector> : IVector<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector: struct, IVector2<TPrimitive,TVector>
    {
        /// <summary>
        /// Horizontal component of this vector
        /// </summary>
        TPrimitive X { get; set; }

        /// <summary>
        /// Vertical component of this vector
        /// </summary>
        TPrimitive Y { get; set; }

        /// <summary>
        /// Convert to <see cref="Vector2F"/>
        /// </summary>
        /// <returns></returns>
        Vector2F ToFloat();

        /// <summary>
        /// Convert to <see cref="Vector2D"/>
        /// </summary>
        /// <returns></returns>
        Vector2D ToDouble();

        /// <summary>Returns this vector rotated 90° counter-clockwise: (-Y, X).</summary>
        TVector Rotate90();

        /// <summary>Returns this vector rotated 90° clockwise: (Y, -X).</summary>
        TVector RotateM90();

        /// <summary>Returns the angle of this vector in radians using <see cref="Math.Atan2"/>: atan2(Y, X).</summary>
        double Atan2D();

        /// <summary>Returns the signed area of the rectangle formed by the components: X * Y.</summary>
        double AreaD();

        abstract static TVector operator *(TVector left, TPrimitive right);

        abstract static TVector operator *(TPrimitive left, TVector right);

        abstract static TVector operator /(TVector left, TPrimitive right);

        /// <summary>Unit vector along the X axis (1, 0).</summary>
        abstract static TVector UnitX { get; }

        /// <summary>Unit vector along the Y axis (0, 1).</summary>
        abstract static TVector UnitY { get; }

        /// <summary>Creates a vector from the given <typeparamref name="TPrimitive"/> components.</summary>
        abstract static TVector Create (TPrimitive x, TPrimitive y);

        /// <summary>Creates a vector from the given <see langword="double"/> components.</summary>
        abstract static TVector Create(double x, double y);

        /// <summary>Creates a vector from the given <see langword="long"/> components.</summary>
        abstract static TVector Create(long x, long y);
    }
}
