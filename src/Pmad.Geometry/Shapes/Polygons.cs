using System.Numerics;
using Pmad.ProgressTracking;

namespace Pmad.Geometry.Shapes
{
    public static class Polygons
    {
        public static IReadOnlyCollection<Polygon<P, V>> SubstractAllSplitted<P, V>(this IEnumerable<Polygon<P, V>> input, IReadOnlyCollection<Polygon<P, V>> others, IProgressScope progress, string stepName = "SubstractAll", double targetArea = 1_000_000)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return SubstractAllSplitted(input.ToList(), others, progress, stepName, targetArea);
        }

        public static IReadOnlyCollection<Polygon<P, V>> SubstractAllSplitted<P, V>(this IReadOnlyList<Polygon<P, V>> list, IReadOnlyCollection<Polygon<P, V>> others, IProgressScope progress, string stepName = "SubstractAll", double targetArea = 1_000_000)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            using var report = progress.CreateInteger(stepName, list.Count);
            return PolygonsHelper<P, V>.SubstractAllSplitted(list, others, targetArea, report);
        }

        public static IReadOnlyCollection<Polygon<P, V>> SubstractAllSplitted<P, V>(this IReadOnlyList<Polygon<P, V>> list, IReadOnlyCollection<Polygon<P, V>> others, double targetArea = 1_000_000, IProgressInteger? progress = null)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return PolygonsHelper<P, V>.SubstractAllSplitted(list, others, targetArea, progress);
        }

        public static List<Polygon<P, V>> UnionAll<P, V>(this IReadOnlyList<Polygon<P, V>> items, IProgressScope progress, string stepName = "UnionAll", PolygonsMergeMode merge = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            using var report = progress.CreateInteger(stepName, items.Count);
            return PolygonsHelper<P, V>.UnionAll(items, report, merge);
        }

        public static List<Polygon<P, V>> UnionAll<P, V>(this IReadOnlyList<Polygon<P, V>> items, IProgressInteger? progress = null, PolygonsMergeMode merge = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return PolygonsHelper<P, V>.UnionAll(items, progress, merge);
        }

        public static List<Polygon<P, V>> FilterOverlaps<P, V>(this IEnumerable<Polygon<P, V>> list, IProgressScope progressScope, string stepName = "FilterOverlaps")
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            var clone = list.ToList();
            using var progress = progressScope.CreateInteger(stepName, clone.Count);
            return PolygonsHelper<P, V>.FilterOverlaps(clone, progress);
        }

        public static List<Polygon<P, V>> FilterOverlaps<P, V>(this IEnumerable<Polygon<P, V>> list, IProgressInteger? progress = null)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return PolygonsHelper<P, V>.FilterOverlaps(list.ToList(), progress);
        }

        public static Task<List<Polygon<P, V>>> ParallelUnionAll<P, V>(this List<Polygon<P, V>> items, IProgressScope progressScope, string stepName = "ParallelUnionAll", int idealPartition = 100, PolygonsMergeMode mode = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            using var progress = progressScope.CreateInteger(stepName, items.Count);
            return PolygonsHelper<P, V>.ParallelUnionAll(PolygonsHelper<P, V>.GetBounds(items), items, idealPartition, mode, progress);
        }

        public static Task<List<Polygon<P, V>>> ParallelUnionAll<P, V>(this List<Polygon<P, V>> items, int idealPartition = 100, IProgressInteger? progress = null, PolygonsMergeMode mode = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return PolygonsHelper<P, V>.ParallelUnionAll(PolygonsHelper<P, V>.GetBounds(items), items, idealPartition, mode, progress);
        }
    }
}
