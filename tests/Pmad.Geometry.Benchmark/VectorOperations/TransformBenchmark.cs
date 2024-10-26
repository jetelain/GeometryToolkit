using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class TransformBenchmark
    {
        [Benchmark]
        public object Naive_2D() => SampleValuesRO.Circle2D.Select(i => i * 2 ).ToArray();

        [Benchmark]
        public object Classic_2D() => 
            TransformHelper<double, Vector2D, ScaleTransform<double, Vector2D>>.TransformClassic(new ScaleTransform<double, Vector2D>(2), SampleValuesRO.Circle2D);

        [Benchmark]
        public object Vector_2D() =>
            TransformHelper<double, Vector2D, ScaleTransform<double, Vector2D>>.Transform(new ScaleTransform<double, Vector2D>(2), SampleValuesRO.Circle2D);

        [Benchmark]
        public object Classic_2F() =>
            TransformHelper<float, Vector2F, ScaleTransform<float, Vector2F>>.TransformClassic(new ScaleTransform<float, Vector2F>(2), SampleValuesRO.Circle2F);

        [Benchmark]
        public object Vector_2F() =>
            TransformHelper<float, Vector2F, ScaleTransform<float, Vector2F>>.Transform(new ScaleTransform<float, Vector2F>(2), SampleValuesRO.Circle2F);

    }
}
