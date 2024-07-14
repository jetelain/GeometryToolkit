using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class SmallestRotatedRectangleBenchmark
    {
        [Benchmark]
        public void Vector2D_Dispatcher() => RotatedRectangle<double, Vector2D>.GetSmallestContaining(SampleValuesRO.RandomList2D);

        [Benchmark]
        public void Vector2D_Virtual() => RotatedRectangle<double, Vector2D>.GetSmallestContaining_Virtual(SampleValuesRO.RandomList2D);

        [Benchmark]
        public void Vector2D_StaticOperators() => RotatedRectangle<double, Vector2D>.GetSmallestContaining_StaticOperators(SampleValuesRO.RandomList2D);

        [Benchmark]
        public void Vector2D_Direct() => SmallestRotatedRectangle.Compute(ShapeSettings<double, Vector2D>.Default, SampleValuesRO.RandomList2D.AsSpan());

        [Benchmark]
        public void Vector2F_Dispatcher() => RotatedRectangle<float, Vector2F>.GetSmallestContaining(SampleValuesRO.RandomList2F);

        [Benchmark]
        public void Vector2F_StaticOperators() => RotatedRectangle<float, Vector2F>.GetSmallestContaining_StaticOperators(SampleValuesRO.RandomList2F);

        [Benchmark]
        public void Vector2F_Virtual() => RotatedRectangle<float, Vector2F>.GetSmallestContaining_Virtual(SampleValuesRO.RandomList2F);

        [Benchmark]
        public void Vector2F_Direct() => SmallestRotatedRectangle.Compute(ShapeSettings<float, Vector2F>.Default, SampleValuesRO.RandomList2F.AsSpan());

        [Benchmark]
        public void Vector2FN_Dispatcher() => RotatedRectangle<float, Vector2FN>.GetSmallestContaining(SampleValuesRO.RandomList2FN);

        [Benchmark]
        public void Vector2FN_StaticOperators() => RotatedRectangle<float, Vector2FN>.GetSmallestContaining_StaticOperators(ShapeSettings<float, Vector2FN>.Default, SampleValuesRO.RandomList2FN.AsSpan());

        [Benchmark]
        public void Vector2FN_Direct() => SmallestRotatedRectangle.Compute(ShapeSettings<float, Vector2FN>.Default, SampleValuesRO.RandomList2FN.AsSpan());

        [Benchmark]
        public void Vector2FN_Virtual() => RotatedRectangle<float, Vector2FN>.GetSmallestContaining_Virtual(SampleValuesRO.RandomList2FN);

    }
}
