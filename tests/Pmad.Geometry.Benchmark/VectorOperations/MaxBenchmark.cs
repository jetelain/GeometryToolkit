using System.Linq;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class MaxBenchmark
    {
        [Benchmark(Baseline = true)]
        public Vector2D Naive2D() => new(SampleValuesRO.RandomList2D.Max(p => p.X), SampleValuesRO.RandomList2D.Max(p => p.Y));

        [Benchmark]
        public Vector2D MaxVector2D() => SampleValuesRO.RandomList2D.Max();

        [Benchmark]
        public Vector2F MaxVector2F() => SampleValuesRO.RandomList2F.Max();

        [Benchmark]
        public Vector2I MaxVector2I() => SampleValuesRO.RandomList2I.Max();

        [Benchmark]
        public Vector2L MaxVector2L() => SampleValuesRO.RandomList2L.Max();

        [Benchmark]
        public Vector2DS MaxVector2DS() => SampleValuesRO.RandomList2DS.Max();

        [Benchmark]
        public Vector2FS MaxVector2FS() => SampleValuesRO.RandomList2FS.Max();

        [Benchmark]
        public Vector2IS MaxVector2IS() => SampleValuesRO.RandomList2IS.Max();

        [Benchmark]
        public Vector2LS MaxVector2LS() => SampleValuesRO.RandomList2LS.Max();

    }
}
