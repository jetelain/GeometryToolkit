using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class SumBenchmark
    {
        [Benchmark]
        public object SumVector2D() => SampleValuesRO.RandomList2D.Sum();

        [Benchmark]
        public object SumVector2F() => SampleValuesRO.RandomList2F.Sum();

        [Benchmark]
        public object SumVector2I() => SampleValuesRO.RandomList2I.Sum();

        [Benchmark]
        public object SumVector2L() => SampleValuesRO.RandomList2L.Sum();

        [Benchmark]
        public object SumVector2DS() => SampleValuesRO.RandomList2DS.Sum();

        [Benchmark]
        public object SumVector2FS() => SampleValuesRO.RandomList2FS.Sum();

        [Benchmark]
        public object SumVector2IS() => SampleValuesRO.RandomList2IS.Sum();

        [Benchmark]
        public object SumVector2LS() => SampleValuesRO.RandomList2LS.Sum();
    }
}
