using BenchmarkDotNet.Attributes;
using Clipper2Lib;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class UnionBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100);
        private static readonly PolygonSampleSet B = PolygonSampleSet.CreateCircle(0, 50, 100);
        private static readonly PolygonSampleSet C = PolygonSampleSet.CreateCircle(0, 150, 100);

        //[Benchmark] public object Union_NTS() => (A.PolygonNTS.Union(B.PolygonNTS), A.PolygonNTS.Union(C.PolygonNTS));
        //[Benchmark] public object Union_GRM() => (A.PolygonGRM.Merge(B.PolygonGRM), A.PolygonGRM.Merge(C.PolygonGRM));
        [Benchmark] public void Clipper2_L() 
        { 
            Clipper.BooleanOp(ClipType.Union, [A.PointsP64], [B.PointsP64], new PolyTree64(), FillRule.EvenOdd);
            Clipper.BooleanOp(ClipType.Union, [A.PointsP64], [C.PointsP64], new PolyTree64(), FillRule.EvenOdd); 
        }
        [Benchmark]
        public void Clipper2_D()
        {
            Clipper.BooleanOp(ClipType.Union, [A.PointsPtD], [B.PointsPtD], new PolyTreeD(), FillRule.EvenOdd);
            Clipper.BooleanOp(ClipType.Union, [A.PointsPtD], [C.PointsPtD], new PolyTreeD(), FillRule.EvenOdd);
        }
        [Benchmark] public object Union_2D() => (A.Polygon2D.Union(B.Polygon2D), A.Polygon2D.Union(C.Polygon2D));
        [Benchmark] public object Union_2F() => (A.Polygon2F.Union(B.Polygon2F), A.Polygon2F.Union(C.Polygon2F));
        [Benchmark] public object Union_2I() => (A.Polygon2I.Union(B.Polygon2I), A.Polygon2I.Union(C.Polygon2I));
        [Benchmark] public object Union_2L() => (A.Polygon2L.Union(B.Polygon2L), A.Polygon2L.Union(C.Polygon2L));

    }
}
