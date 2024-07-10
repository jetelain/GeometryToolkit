using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class MultiplicationBenchmark
    {
        [Benchmark]
        public void MultiplicationVector2D() => SampleValues.RandomList2D.ForEach(p => _ = p * p);  

        [Benchmark]
        public void MultiplicationVector2F() => SampleValues.RandomList2F.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2I() => SampleValues.RandomList2I.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2L() => SampleValues.RandomList2L.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2DS() => SampleValues.RandomList2DS.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2FS() => SampleValues.RandomList2FS.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2IS() => SampleValues.RandomList2IS.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2LS() => SampleValues.RandomList2LS.ForEach(p => _ = p * p);

        [Benchmark]
        public void MultiplicationVector2FN() => SampleValues.RandomList2FN.ForEach(p => _ = p * p);
    }
}
