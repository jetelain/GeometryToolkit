﻿using System.Numerics;
using Pmad.Geometry.Shapes;
using Pmad.ProgressTracking;

namespace Pmad.Geometry.Processing
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

        public static MultiPolygon<P, V> UnionAll<P, V>(this IReadOnlyList<Polygon<P, V>> items, IProgressScope progress, string stepName = "UnionAll", PolygonsMergeMode merge = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            using var report = progress.CreateInteger(stepName, items.Count);
            return new (PolygonsHelper<P, V>.UnionAll(items, report, merge));
        }

        public static MultiPolygon<P, V> UnionAll<P, V>(this IReadOnlyList<Polygon<P, V>> items, IProgressInteger? progress = null, PolygonsMergeMode merge = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return new (PolygonsHelper<P, V>.UnionAll(items, progress, merge));
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

        public static async Task<MultiPolygon<P, V>> ParallelUnionAll<P, V>(this List<Polygon<P, V>> items, IProgressScope progressScope, string stepName = "ParallelUnionAll", int idealPartition = 100, PolygonsMergeMode mode = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            using var progress = progressScope.CreateInteger(stepName, items.Count);
            return new (await PolygonsHelper<P, V>.ParallelUnionAll(MultiPolygon<P, V>.GetBounds(items), items, idealPartition, mode, progress).ConfigureAwait(false));
        }

        public static async Task<MultiPolygon<P, V>> ParallelUnionAll<P, V>(this List<Polygon<P, V>> items, int idealPartition = 100, IProgressInteger? progress = null, PolygonsMergeMode mode = PolygonsMergeMode.LargeConnected)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            return new (await PolygonsHelper<P, V>.ParallelUnionAll(MultiPolygon<P, V>.GetBounds(items), items, idealPartition, mode, progress).ConfigureAwait(false));
        }

        public static async Task<PolygonSet<P, V>> ParallelUnionAllToSet<P, V>(this List<Polygon<P, V>> items, IProgressScope progressScope, string stepName = "ParallelUnionAll", int idealPartition = 100)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            var tree = new PartitionQuadTree<Polygon<P, V>, P, V>(MultiPolygon<P, V>.GetBounds(items), idealPartition);
            tree.AddRange(items);
            using var progress = progressScope.CreateInteger(stepName, tree.Count + tree.NodeCount);
            return await PolygonsHelper<P, V>.ParallelUnionAllToSet(tree, items[0].Settings, progress);
        }

        public static async Task<PolygonSet<P, V>> ParallelUnionAllToSet<P, V>(this List<Polygon<P, V>> items, int idealPartition = 100)
            where P : unmanaged, INumber<P>
            where V : struct, IVector2<P, V>
        {
            var tree = new PartitionQuadTree<Polygon<P, V>, P, V>(MultiPolygon<P, V>.GetBounds(items), idealPartition);
            tree.AddRange(items);
            return await PolygonsHelper<P, V>.ParallelUnionAllToSet(tree, items[0].Settings);
        }
    }
}
