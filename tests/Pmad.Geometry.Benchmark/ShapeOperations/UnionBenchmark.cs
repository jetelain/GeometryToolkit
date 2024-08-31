using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class UnionBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100); 
        private static readonly PolygonSampleSet B = PolygonSampleSet.CreateCircle(0, 50, 100);
        private static readonly PolygonSampleSet C = PolygonSampleSet.CreateCircle(0, 150, 100);

        [Benchmark] public object Union_NTS() => (A.PolygonNTS.Union(B.PolygonNTS), A.PolygonNTS.Union(C.PolygonNTS));
        [Benchmark] public object Union_GRM() => (A.PolygonGRM.Merge(B.PolygonGRM), A.PolygonGRM.Merge(C.PolygonGRM));
        [Benchmark] public object Union_2D() => (A.Polygon2D.Union(B.Polygon2D) , A.Polygon2D.Union(C.Polygon2D));
        [Benchmark] public object Union_2F() => (A.Polygon2F.Union(B.Polygon2F), A.Polygon2F.Union(C.Polygon2F));
        [Benchmark] public object Union_2I() => (A.Polygon2I.Union(B.Polygon2I), A.Polygon2I.Union(C.Polygon2I));
        [Benchmark] public object Union_2L() => (A.Polygon2L.Union(B.Polygon2L) , A.Polygon2L.Union(C.Polygon2L));

    }
}
