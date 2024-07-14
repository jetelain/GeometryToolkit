namespace Pmad.Geometry.Collections
{
    public static class EnumerableExtensions
    {
        public static ReadOnlyArray<T> ToReadOnlyArray<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyArray<T>(enumerable.ToArray());
        }

        public static ReadOnlyArray<T> ToReadOnlyArray<T>(this ReadOnlySpan<T> enumerable)
        {
            return new ReadOnlyArray<T>(enumerable.ToArray());
        }
    }
}
