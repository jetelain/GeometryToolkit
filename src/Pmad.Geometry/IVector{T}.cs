namespace Pmad.Geometry
{
    /// <summary>
    /// Number vector
    /// </summary>
    /// <typeparam name="T">Type of vector</typeparam>
    public interface IVector<T> : IEquatable<T>
        where T : struct, IVector<T>
    {
        /// <summary>
        /// Compute the addition of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this + value</returns>
        T Add(T value);

        /// <summary>
        /// Compute the substraction of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this - value</returns>
        T Substract(T value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        T Multiply(T value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        T Multiply(int value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        T Multiply(double value);

        /// <summary>
        /// Compute the division of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this / value</returns>
        T Divide(T value);

        /// <summary>
        /// Compute the division of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this / value</returns>
        T Divide(int value);

        /// <summary>
        /// Length of vector as a <see langword="double"/>.
        /// </summary>
        /// <returns>sqrt(X^2 + Y^2)</returns>
        double LengthD();

        /// <summary>
        /// Length of vector as a <see langword="float"/>.
        /// </summary>
        /// <returns>sqrt(X^2 + Y^2)</returns>
        float LengthF();

        /// <summary>
        /// Squared length of vector as a <see langword="double"/>.
        /// </summary>
        /// <returns>X^2 + Y^2</returns>
        double LengthSquaredD();

        /// <summary>
        /// Squared length of vector as a <see langword="float"/>.
        /// </summary>
        /// <returns>X^2 + Y^2</returns>
        float LengthSquaredF();

        /// <summary>
        /// Test if components of this vector are greater or equal to same components of the other vector
        /// </summary>
        /// <returns><see langword="true"/> if X &gt;= other.X and Y &gt;= other.Y ...</returns>
        bool IsGreaterThanOrEqualAll(T other);

        /// <summary>
        /// Test if components of this vector are less or equal to same components of the other vector
        /// </summary>
        /// <returns><see langword="true"/> if X &lt;= other.X and Y &lt;= other.Y ...</returns>

        bool IsLessThanOrEqualAll(T other);

        /// <summary>
        /// Test if components of this vector are in the range of other vectors
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns><see langword="true"/> if min.X &lt; X &lt;= max.X and  min.Y &lt; Y &lt;= max.Y ...</returns>
        bool IsInRange(T min, T max);

        T Min(T other);

        T Max(T other);

        T SwapXY();

        T Negate();
    }
}
