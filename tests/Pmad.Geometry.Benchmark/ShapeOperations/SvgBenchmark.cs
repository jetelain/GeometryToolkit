using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Shapes.Svg;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class SvgBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100);

        [Benchmark] public object ToSvgPath_2D() => A.Polygon2D.ToSvgPath();

        [Benchmark] public object ToSvgPath_2L() => A.Polygon2L.ToSvgPath();

    }
}
