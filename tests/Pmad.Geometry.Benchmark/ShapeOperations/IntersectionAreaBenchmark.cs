using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class IntersectionAreaBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100); 
        private static readonly PolygonSampleSet B = PolygonSampleSet.CreateCircle(0, 50, 100);
        private static readonly PolygonSampleSet C = PolygonSampleSet.CreateCircle(0, 150, 100);

        [Benchmark] public object IntersectionArea_NTS() => A.PolygonNTS.Intersection(B.PolygonNTS).Area + A.PolygonNTS.Intersection(C.PolygonNTS).Area;
        [Benchmark] public object IntersectionArea_GRM() => A.PolygonGRM.IntersectionArea(B.PolygonGRM) + A.PolygonGRM.IntersectionArea(C.PolygonGRM);
        [Benchmark] public object IntersectionArea_2D() => A.Polygon2D.IntersectionArea(B.Polygon2D) + A.Polygon2D.IntersectionArea(C.Polygon2D);
        [Benchmark] public object IntersectionArea_2F() => A.Polygon2F.IntersectionArea(B.Polygon2F) + A.Polygon2F.IntersectionArea(C.Polygon2F);
        [Benchmark] public object IntersectionArea_2I() => A.Polygon2I.IntersectionArea(B.Polygon2I) + A.Polygon2I.IntersectionArea(C.Polygon2I);
        [Benchmark] public object IntersectionArea_2L() => A.Polygon2L.IntersectionArea(B.Polygon2L) + A.Polygon2L.IntersectionArea(C.Polygon2L);

    }
}
