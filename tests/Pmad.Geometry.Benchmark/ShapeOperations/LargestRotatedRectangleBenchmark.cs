using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class LargestRotatedRectangleBenchmark
    {
        [Benchmark]
        public void Vector2D() => RotatedRectangle<double, Vector2D>.GetLargestBetween(SampleValuesRO.Circle2D);

        [Benchmark]
        public void Vector2F() => RotatedRectangle<float, Vector2F>.GetLargestBetween(SampleValuesRO.Circle2F);

    }
}
