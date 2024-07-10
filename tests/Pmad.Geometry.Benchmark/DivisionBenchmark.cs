using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class DivisionBenchmark
    {
        [Benchmark]
        public void DivisionVector2D() => SampleValues.RandomNonZeroList2D.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2F() => SampleValues.RandomNonZeroList2F.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2I() => SampleValues.RandomNonZeroList2I.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2L() => SampleValues.RandomNonZeroList2L.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2DS() => SampleValues.RandomNonZeroList2DS.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2FS() => SampleValues.RandomNonZeroList2FS.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2IS() => SampleValues.RandomNonZeroList2IS.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2LS() => SampleValues.RandomNonZeroList2LS.ForEach(p => _ = p / p);

        [Benchmark]
        public void DivisionVector2FN() => SampleValues.RandomNonZeroList2FN.ForEach(p => _ = p / p);
    }
}
