using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class SmallestRotatedRectangleBenchmark
    {
        [Benchmark]
        public void Vector2D_StaticOperators() => RotatedRectangle<double, Vector2D>.GetSmallestContaining(SampleValuesRO.RandomList2D);

        [Benchmark]
        public void Vector2D_Direct() => SmallestRotatedRectangle.Compute(ShapeSettings<double, Vector2D>.Default, SampleValuesRO.RandomList2D.AsSpan());

        [Benchmark]
        public void Vector2F_StaticOperators() => RotatedRectangle<float, Vector2F>.GetSmallestContaining(SampleValuesRO.RandomList2F);

        [Benchmark]
        public void Vector2F_Direct() => SmallestRotatedRectangle.Compute(ShapeSettings<float, Vector2F>.Default, SampleValuesRO.RandomList2F.AsSpan());
    }
}
