using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class SimplifyBenchmark
    {
        [Benchmark]
        public object SimplifyVector2D_Classic() => SampleValuesRO.RandomList2D.SimplifyClassic(1);

        [Benchmark]
        public object SimplifyVector2D_Optimized() => SampleValuesRO.RandomList2D.Simplify(1);
        
        [Benchmark]
        public object SimplifyVector2F() => SampleValuesRO.RandomList2F.Simplify(1);

        [Benchmark]
        public object SimplifyVector2I() => SampleValuesRO.RandomList2I.Simplify(1);

        [Benchmark]
        public object SimplifyVector2L() => SampleValuesRO.RandomList2L.Simplify(1);

        [Benchmark]
        public object SimplifyVector2DS() => SampleValuesRO.RandomList2DS.Simplify(1);

        [Benchmark]
        public object SimplifyVector2FS() => SampleValuesRO.RandomList2FS.Simplify(1);

        [Benchmark]
        public object SimplifyVector2IS() => SampleValuesRO.RandomList2IS.Simplify(1);

        [Benchmark]
        public object SimplifyVector2LS() => SampleValuesRO.RandomList2LS.Simplify(1);
    }
}
