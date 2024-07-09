using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class SumBenchmark
    {
        [Benchmark]
        public Vector2D SumVector2D() => SampleValues.RandomList2D.Sum();

        [Benchmark]
        public Vector2F SumVector2F() => SampleValues.RandomList2F.Sum();

        [Benchmark]
        public Vector2I SumVector2I() => SampleValues.RandomList2I.Sum();

        [Benchmark]
        public Vector2L SumVector2L() => SampleValues.RandomList2L.Sum();

        [Benchmark]
        public Vector2DS SumVector2DS() => SampleValues.RandomList2DS.Sum();

        [Benchmark]
        public Vector2FS SumVector2FS() => SampleValues.RandomList2FS.Sum();

        [Benchmark]
        public Vector2IS SumVector2IS() => SampleValues.RandomList2IS.Sum();

        [Benchmark]
        public Vector2LS SumVector2LS() => SampleValues.RandomList2LS.Sum();

        [Benchmark]
        public Vector2FN SumVector2FN() => SampleValues.RandomList2FN.Sum();
    }
}
