namespace Pmad.Geometry
{
    /// <summary>
    /// Number vector
    /// </summary>
    /// <typeparam name="TVector">Type of vector</typeparam>
    public interface IVector<TVector> : IEquatable<TVector>
        where TVector : struct, IVector<TVector>
    {
        /// <summary>
        /// Compute the addition of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this + value</returns>
        TVector Add(TVector value);

        /// <summary>
        /// Compute the substraction of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this - value</returns>
        TVector Substract(TVector value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        TVector Multiply(TVector value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        TVector Multiply(int value);

        /// <summary>
        /// Compute the multiplication of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this * value</returns>
        TVector Multiply(double value);

        /// <summary>
        /// Compute the division of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this / value</returns>
        TVector Divide(TVector value);

        /// <summary>
        /// Compute the division of this and an other vector
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this / value</returns>
        TVector Divide(int value);

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
        bool IsGreaterThanOrEqualAll(TVector other);

        /// <summary>
        /// Test if components of this vector are less or equal to same components of the other vector
        /// </summary>
        /// <returns><see langword="true"/> if X &lt;= other.X and Y &lt;= other.Y ...</returns>

        bool IsLessThanOrEqualAll(TVector other);

        /// <summary>
        /// Test if components of this vector are in the range of other vectors
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns><see langword="true"/> if min.X &lt; X &lt;= max.X and  min.Y &lt; Y &lt;= max.Y ...</returns>
        bool IsInRange(TVector min, TVector max);

        TVector Min(TVector other);

        TVector Max(TVector other);

        TVector SwapXY();

        TVector Negate();


        abstract static TVector Min(TVector left, TVector right);

        abstract static TVector Max(TVector left, TVector right);

        abstract static TVector Clamp(TVector value, TVector min, TVector max);

        abstract static TVector operator+(TVector left, TVector right);

        abstract static TVector operator-(TVector left, TVector right);

        abstract static TVector operator-(TVector value);

        abstract static TVector operator*(TVector left, TVector right);

        abstract static TVector operator/(TVector left, TVector right);

        abstract static TVector operator/(TVector left, int right);

        abstract static TVector operator*(TVector left, double right);

        abstract static TVector operator*(TVector left, int right);

        abstract static TVector MaxValue { get; }

        abstract static TVector MinValue { get; }

        abstract static TVector Zero { get; }

        abstract static TVector One { get; }

        static abstract bool operator ==(TVector left, TVector right);

        static abstract bool operator !=(TVector left, TVector right);
    }
}
