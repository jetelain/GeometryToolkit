using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Transforms;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class TransformBenchmark
    {

        [Benchmark]
        public object ScaleAndTranslate_Classic_2D() =>
            new ScaleAndTranslateTransform<double, Vector2D>(2, new Vector2D(10, 15)).TransformClassic(SampleValuesRO.Circle2D);

        [Benchmark]
        public object ScaleAndTranslate_Vector_2D() =>
            new ScaleAndTranslateTransform<double, Vector2D>(2, new Vector2D(10, 15)).Transform(SampleValuesRO.Circle2D);

        [Benchmark]
        public object Translate_Classic_2D() =>
            new TranslateTransform<double, Vector2D>(new Vector2D(10, 15)).TransformClassic(SampleValuesRO.Circle2D);

        [Benchmark]
        public object Translate_Vector_2D() =>
            new TranslateTransform<double, Vector2D>(new Vector2D(10, 15)).Transform(SampleValuesRO.Circle2D);

        [Benchmark]
        public object Scale_Classic_2D() =>
            new MultiplyTransform<double, Vector2D>(2).TransformClassic(SampleValuesRO.Circle2D);

        [Benchmark]
        public object Scale_Vector_2D() =>
            new MultiplyTransform<double, Vector2D>(2).Transform(SampleValuesRO.Circle2D);

        [Benchmark]
        public object ScaleAndTranslate_Naive_2D() => SampleValuesRO.Circle2D.Select(i => i * 2 + new Vector2D(10, 15)).ToArray();

        [Benchmark]
        public object Translate_Naive_2D() => SampleValuesRO.Circle2D.Select(i => i + new Vector2D(10, 15)).ToArray();

        [Benchmark]
        public object Scale_Naive_2D() => SampleValuesRO.Circle2D.Select(i => i * 2).ToArray();

    }
}
