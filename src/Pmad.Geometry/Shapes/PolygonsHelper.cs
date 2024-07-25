using System.Collections.Concurrent;
using System.Numerics;
using Clipper2Lib;
using Pmad.ProgressTracking;

namespace Pmad.Geometry.Shapes
{
    internal static class PolygonsHelper<P, V> 
        where P : unmanaged, INumber<P>
        where V : struct, IVector2<P, V>
    {
        internal static IReadOnlyCollection<Polygon<P, V>> SubstractAllSplitted(IReadOnlyList<Polygon<P, V>> list, IReadOnlyCollection<Polygon<P, V>> others, double targetArea = 1_000_000, IProgressInteger? report = null)
        {
            var result = new ConcurrentQueue<Polygon<P, V>>();
            Parallel.ForEach(list, polygon =>
            {
                foreach (var resultPolygon in SubstractAllSplitted(polygon, others, targetArea))
                {
                    result.Enqueue(resultPolygon);
                }
                report?.ReportOneDone();
            });
            return result;
        }

        internal static IEnumerable<Polygon<P, V>> SubstractAllSplitted(Polygon<P, V> subject, IEnumerable<Polygon<P, V>> others, double targetArea = 1_000_000)
        {
            var bounds = subject.Bounds;
            if ((bounds.Max- bounds.Min).AreaD() < targetArea)
            {
                return subject.SubstractAll(others);
            }
            var quad = SplitQuad(bounds).SelectMany(s => subject.ClippedBy(s));
            var result = new ConcurrentQueue<Polygon<P, V>>();
            Parallel.ForEach(quad, polygon =>
            {
                foreach (var resultPolygon in SubstractAllSplitted(polygon, others))
                {
                    result.Enqueue(resultPolygon);
                }
            });
            return result;
        }

        internal static List<Polygon<P, V>> FilterOverlaps(List<Polygon<P, V>> input, IProgressInteger? report = null)
        {
            foreach (var item in input.ToList())
            {
                if (input.Contains(item))
                {
                    var contains = input.Where(f => f != item && item.ContainsOrSimilar(f)).ToList();
                    if (contains.Count > 0)
                    {
                        foreach (var toremove in contains)
                        {
                            input.Remove(toremove);
                        }
                    }
                }
                report?.ReportOneDone();
            }
            return input;
        }

        public static List<Polygon<P, V>> UnionAll(IReadOnlyList<Polygon<P, V>> items, IProgressInteger? progress = null, PolygonsMergeMode merge = PolygonsMergeMode.LargeConnected)
        {
            if (items.Count < 2)
            {
                return items.ToList();
            }
            var settings = items[0].Settings;
            var source = items.Where(p => p.AreaD > settings.NegligibleArea).ToList();
            if (source.Count < 2)
            {
                return source;
            }
            switch (merge)
            {
                case PolygonsMergeMode.SmallIsolated:
                    return UnionAllSmallIsolated(source, settings, progress);

                case PolygonsMergeMode.LargeConnected:
                    return UnionAllLargeConnected(source, settings, progress);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        private static List<Polygon<P, V>> UnionAllLargeConnected(List<Polygon<P, V>> source, ShapeSettings<P, V> settings, IProgressInteger? progress)
        {
            var merged = new List<Polygon<P, V>>(source.Take(1));
            var box = source[0].Bounds;
            foreach (var polygon in source.Skip(1))
            {
                if (polygon.Bounds.Intersects(box))
                {
                    var tree = new PolyTree64();
                    Clipper.BooleanOp(ClipType.Union, new Paths64(merged.SelectMany(p => p.ToClipper())), polygon.ToClipper(), tree, FillRule.EvenOdd);
                    merged = settings.ToPolygonList(tree);
                }
                else
                {
                    merged.Add(polygon);
                }
                box = GetBounds(merged);
                progress?.ReportOneDone();
            }
            return merged;
        }

        private static List<Polygon<P, V>> UnionAllSmallIsolated(List<Polygon<P, V>> source, ShapeSettings<P, V> settings, IProgressInteger? progress)
        {
            var merged = new List<Polygon<P, V>>(source.Take(1));
            foreach (var polygon in source.Skip(1))
            {
                var polygonEnvelope = polygon.Bounds;
                var mergedIntersects = merged.Where(p => p.Bounds.Intersects(polygonEnvelope)).ToList();
                if (mergedIntersects.Count > 0)
                {
                    var tree = new PolyTree64();
                    Clipper.BooleanOp(ClipType.Union, new Paths64(mergedIntersects.SelectMany(p => p.ToClipper())), polygon.ToClipper(), tree, FillRule.EvenOdd);
                    merged = settings.ToPolygonList(tree).Concat(merged.Except(mergedIntersects)).ToList();
                }
                else
                {
                    merged.Add(polygon);
                }
                progress?.ReportOneDone();
            }
            return merged;
        }

        internal static VectorEnvelope<V> GetBounds(List<Polygon<P, V>> list)
        {
            if (list.Count == 0)
            {
                return VectorEnvelope<V>.None;
            }
            var min = list[0].Bounds.Min;
            var max = list[0].Bounds.Max;
            for (var i = 1; i < list.Count; i++)
            {
                var current = list[i];
                min = V.Min(current.Bounds.Min, min);
                max = V.Max(current.Bounds.Max, max);
            }
            return new(min, max);
        }

        internal static async Task<List<Polygon<P, V>>> ParallelUnionAll(VectorEnvelope<V> scope, IReadOnlyList<Polygon<P, V>> items, int idealPartition, PolygonsMergeMode mode, IProgressInteger? progress = null)
        {
            if (items.Count < idealPartition)
            {
                return UnionAll(items, progress, mode);
            }
            var quadrans = SplitQuad(scope);
            var partitions = new[] { new List<Polygon<P, V>>(), new List<Polygon<P, V>>(), new List<Polygon<P, V>>(), new List<Polygon<P, V>>() };
            var others = new List<Polygon<P, V>>();
            foreach (var item in items)
            {
                if (quadrans[0].Contains(item.Bounds))
                {
                    partitions[0].Add(item);
                }
                else if (quadrans[1].Contains(item.Bounds))
                {
                    partitions[1].Add(item);
                }
                else if (quadrans[2].Contains(item.Bounds))
                {
                    partitions[2].Add(item);
                }
                else if (quadrans[3].Contains(item.Bounds))
                {
                    partitions[3].Add(item);
                }
                else
                {
                    others.Add(item);
                }
            }
            var tasks = new[]{
                Task.Run(() => ParallelUnionAll(quadrans[0], partitions[0], idealPartition, mode)),
                Task.Run(() => ParallelUnionAll(quadrans[1], partitions[1], idealPartition, mode)),
                Task.Run(() => ParallelUnionAll(quadrans[2], partitions[2], idealPartition, mode)),
                Task.Run(() => ParallelUnionAll(quadrans[3], partitions[3], idealPartition, mode)) 
            };

            await Task.WhenAll(tasks).ConfigureAwait(false);

            var result = new List<Polygon<P, V>>();
            var overlapOthers = new List<Polygon<P, V>>();
            foreach (var item in tasks.SelectMany(t => t.Result))
            {
                if (others.Any(e => item.Bounds.Intersects(e.Bounds)))
                {
                    overlapOthers.Add(item);
                }
                else
                {
                    result.Add(item);
                    progress?.ReportOneDone();
                }
            }
            result.AddRange(UnionAll(others.Concat(overlapOthers).ToList(), progress, mode));
            return result;
        }

        private static VectorEnvelope<V>[] SplitQuad(VectorEnvelope<V> scope)
        {
            var mid = (scope.Max + scope.Min) / 2;
            return [ 
                    new VectorEnvelope<V>(scope.Min, mid),
                    new VectorEnvelope<V>(V.Create(scope.Min.X, mid.Y), V.Create(mid.X, scope.Max.Y)),
                    new VectorEnvelope<V>(V.Create(mid.X, scope.Min.Y), V.Create(scope.Max.X, mid.Y)),
                    new VectorEnvelope<V>(mid, scope.Max)
                ];
        }

    }
}
