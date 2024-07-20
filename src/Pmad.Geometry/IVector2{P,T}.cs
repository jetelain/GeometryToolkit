using System.Numerics;
using System.Runtime.CompilerServices;

namespace Pmad.Geometry
{
    /// <summary>
    /// 2 dimensions vector
    /// </summary>
    /// <typeparam name="TPrimitive">Primtive number type</typeparam>
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

        TVector Rotate90();

        TVector RotateM90();

        double Atan2D();

        double AreaD();

        abstract static TVector operator *(TVector left, TPrimitive right);

        abstract static TVector operator *(TPrimitive left, TVector right);

        abstract static TVector operator /(TVector left, TPrimitive right);

        static TVector UnitX { get; }

        static TVector UnitY { get; }

        abstract static TVector Create (TPrimitive x, TPrimitive y);

        abstract static TVector Create(double x, double y);

        abstract static TVector Create(long x, long y);

        static abstract TVector Lerp(TVector left, TVector right, double amount);
    }
}
