using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class LengthBenchmark
    {
        [Benchmark]
        public double LengthVector2D() => SampleValues.RandomList2D.GetLengthD();

        [Benchmark]
        public double LengthVector2F() => SampleValues.RandomList2F.GetLengthD();

        [Benchmark]
        public double LengthVector2I() => SampleValues.RandomList2I.GetLengthD();

        [Benchmark]
        public double LengthVector2L() => SampleValues.RandomList2L.GetLengthD();

        [Benchmark]
        public double LengthVector2DS() => SampleValues.RandomList2DS.GetLengthD();

        [Benchmark]
        public double LengthVector2FS() => SampleValues.RandomList2FS.GetLengthD();

        [Benchmark]
        public double LengthVector2IS() => SampleValues.RandomList2IS.GetLengthD();

        [Benchmark]
        public double LengthVector2LS() => SampleValues.RandomList2LS.GetLengthD();

        [Benchmark]
        public double LengthVector2FN() => SampleValues.RandomList2FN.GetLengthD();
    }
}
