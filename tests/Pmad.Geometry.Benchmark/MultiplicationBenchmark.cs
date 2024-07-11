using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class MultiplicationBenchmark
    {
        [Benchmark]
        public void MultiplicationVector2D() => SampleValues.RandomPairList2D.ForEach(p => _ = p.Item1 * p.Item2);  

        [Benchmark]
        public void MultiplicationVector2F() => SampleValues.RandomPairList2F.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2I() => SampleValues.RandomPairList2I.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2L() => SampleValues.RandomPairList2L.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2DS() => SampleValues.RandomPairList2DS.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2FS() => SampleValues.RandomPairList2FS.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2IS() => SampleValues.RandomPairList2IS.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2LS() => SampleValues.RandomPairList2LS.ForEach(p => _ = p.Item1 * p.Item2);

        [Benchmark]
        public void MultiplicationVector2FN() => SampleValues.RandomPairList2FN.ForEach(p => _ = p.Item1 * p.Item2);
    }
}
