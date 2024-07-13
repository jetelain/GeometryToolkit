using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark
{
    public class LargestRotatedRectangleBenchmark
    {
        [Benchmark]
        public void Vector2D_() => RotatedRectangle<double,Vector2D>.GetLargestBetween(SampleValuesRO.Circle2D);

        [Benchmark]
        public void Vector2F() => RotatedRectangle<float, Vector2F>.GetLargestBetween(SampleValuesRO.Circle2F);

        [Benchmark]
        public void Vector2FN() => RotatedRectangle<float, Vector2FN>.GetLargestBetween(SampleValuesRO.Circle2FN);

    }
}
