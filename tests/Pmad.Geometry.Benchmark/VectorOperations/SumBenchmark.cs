using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class SumBenchmark
    {
        [Benchmark]
        public Vector2D SumVector2D() => SampleValuesRO.RandomList2D.Sum();

        [Benchmark]
        public Vector2F SumVector2F() => SampleValuesRO.RandomList2F.Sum();

        [Benchmark]
        public Vector2I SumVector2I() => SampleValuesRO.RandomList2I.Sum();

        [Benchmark]
        public Vector2L SumVector2L() => SampleValuesRO.RandomList2L.Sum();

        [Benchmark]
        public Vector2DS SumVector2DS() => SampleValuesRO.RandomList2DS.Sum();

        [Benchmark]
        public Vector2FS SumVector2FS() => SampleValuesRO.RandomList2FS.Sum();

        [Benchmark]
        public Vector2IS SumVector2IS() => SampleValuesRO.RandomList2IS.Sum();

        [Benchmark]
        public Vector2LS SumVector2LS() => SampleValuesRO.RandomList2LS.Sum();
    }
}
