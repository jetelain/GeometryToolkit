namespace Pmad.Geometry
{
    /// <summary>
    /// 2 dimensions vector
    /// </summary>
    /// <typeparam name="TPrimitive">Primtive number type</typeparam>
    /// <typeparam name="TVector">Vector type</typeparam>
    public interface IVector2<TPrimitive,TVector> : IVector<TVector>
        where TPrimitive : unmanaged
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
    }
}
