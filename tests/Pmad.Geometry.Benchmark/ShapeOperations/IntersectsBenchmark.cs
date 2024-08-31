using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class IntersectsBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100); 
        private static readonly PolygonSampleSet B = PolygonSampleSet.CreateCircle(0, 50, 100);
        private static readonly PolygonSampleSet C = PolygonSampleSet.CreateCircle(0, 150, 100);

        [Benchmark] public object Intersects_NTS() => A.PolygonNTS.Intersects(B.PolygonNTS) && A.PolygonNTS.Intersects(C.PolygonNTS);
        [Benchmark] public object Intersects_GRM() => A.PolygonGRM.Intersects(B.PolygonGRM) && A.PolygonGRM.Intersects(C.PolygonGRM);
        [Benchmark] public object Intersects_2D() => A.Polygon2D.Intersects(B.Polygon2D) && A.Polygon2D.Intersects(C.Polygon2D);
        [Benchmark] public object Intersects_2F() => A.Polygon2F.Intersects(B.Polygon2F) && A.Polygon2F.Intersects(C.Polygon2F);
        [Benchmark] public object Intersects_2I() => A.Polygon2I.Intersects(B.Polygon2I) && A.Polygon2I.Intersects(C.Polygon2I);
        [Benchmark] public object Intersects_2L() => A.Polygon2L.Intersects(B.Polygon2L) && A.Polygon2L.Intersects(C.Polygon2L);

    }
}
