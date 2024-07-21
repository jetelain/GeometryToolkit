using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class LengthBenchmark
    {
        [Benchmark]
        public double LengthVector2D() => SampleValuesRO.RandomList2D.GetLengthD();

        [Benchmark]
        public double LengthVector2F() => SampleValuesRO.RandomList2F.GetLengthD();

        [Benchmark]
        public double LengthVector2I() => SampleValuesRO.RandomList2I.GetLengthD();

        [Benchmark]
        public double LengthVector2L() => SampleValuesRO.RandomList2L.GetLengthD();

        [Benchmark]
        public double LengthVector2DS() => SampleValuesRO.RandomList2DS.GetLengthD();

        [Benchmark]
        public double LengthVector2FS() => SampleValuesRO.RandomList2FS.GetLengthD();

        [Benchmark]
        public double LengthVector2IS() => SampleValuesRO.RandomList2IS.GetLengthD();

        [Benchmark]
        public double LengthVector2LS() => SampleValuesRO.RandomList2LS.GetLengthD();
    }
}
