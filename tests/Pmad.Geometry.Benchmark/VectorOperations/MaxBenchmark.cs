using System.Linq;
using System.Numerics;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class MaxBenchmark
    {
        [Benchmark(Baseline = true)]
        public object Naive2D() => new Vector2D(SampleValuesRO.RandomList2D.Max(p => p.X), SampleValuesRO.RandomList2D.Max(p => p.Y));

        [Benchmark]
        public object MaxVector2D() => SampleValuesRO.RandomList2D.Max();

        [Benchmark]
        public object MaxVector2F() => SampleValuesRO.RandomList2F.Max();

        [Benchmark]
        public object MaxVector2I() => SampleValuesRO.RandomList2I.Max();

        [Benchmark]
        public object MaxVector2L() => SampleValuesRO.RandomList2L.Max();

        [Benchmark]
        public object MaxVector2DS() => SampleValuesRO.RandomList2DS.Max();

        [Benchmark]
        public object MaxVector2FS() => SampleValuesRO.RandomList2FS.Max();

        [Benchmark]
        public object MaxVector2IS() => SampleValuesRO.RandomList2IS.Max();

        [Benchmark]
        public object MaxVector2LS() => SampleValuesRO.RandomList2LS.Max();

    }
}
