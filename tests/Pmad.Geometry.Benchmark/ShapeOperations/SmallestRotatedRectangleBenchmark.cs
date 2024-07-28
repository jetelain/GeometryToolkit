using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class SmallestRotatedRectangleBenchmark
    {
        [Benchmark]
        public void Vector2D() => RotatedRectangle<double, Vector2D>.GetSmallestContaining(SampleValuesRO.RandomList2D);

        [Benchmark]
        public void Vector2F() => RotatedRectangle<float, Vector2F>.GetSmallestContaining(SampleValuesRO.RandomList2F);

        [Benchmark]
        public void Vector2DS() => RotatedRectangle<double, Vector2DS>.GetSmallestContaining(SampleValuesRO.RandomList2DS);

        [Benchmark]
        public void Vector2FS() => RotatedRectangle<float, Vector2FS>.GetSmallestContaining(SampleValuesRO.RandomList2FS);

    }
}
