using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class IntersectionBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100); 
        private static readonly PolygonSampleSet B = PolygonSampleSet.CreateCircle(0, 50, 100);
        private static readonly PolygonSampleSet C = PolygonSampleSet.CreateCircle(0, 150, 100);

        [Benchmark] public object Intersection_NTS() => (A.PolygonNTS.Intersection(B.PolygonNTS) , A.PolygonNTS.Intersection(C.PolygonNTS));
        [Benchmark] public object Intersection_GRM() => (A.PolygonGRM.Intersection(B.PolygonGRM) , A.PolygonGRM.Intersection(C.PolygonGRM));
        [Benchmark] public object Intersection_2D() => (A.Polygon2D.Intersection(B.Polygon2D) , A.Polygon2D.Intersection(C.Polygon2D));
        [Benchmark] public object Intersection_2F() => (A.Polygon2F.Intersection(B.Polygon2F) , A.Polygon2F.Intersection(C.Polygon2F));
        [Benchmark] public object Intersection_2I() => (A.Polygon2I.Intersection(B.Polygon2I) , A.Polygon2I.Intersection(C.Polygon2I));
        [Benchmark] public object Intersection_2L() => (A.Polygon2L.Intersection(B.Polygon2L) , A.Polygon2L.Intersection(C.Polygon2L));

    }
}
