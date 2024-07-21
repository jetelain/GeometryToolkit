using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class CrossProductBenchmark
    {
        [Benchmark]
        public void CrossProductVector2D() => SampleValuesRO.RandomPairList2D.ForEach(p => Vector2D.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2F() => SampleValuesRO.RandomPairList2F.ForEach(p => Vector2F.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2I() => SampleValuesRO.RandomPairList2I.ForEach(p => Vector2I.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2L() => SampleValuesRO.RandomPairList2L.ForEach(p => Vector2L.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2DS() => SampleValuesRO.RandomPairList2DS.ForEach(p => Vector2DS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2FS() => SampleValuesRO.RandomPairList2FS.ForEach(p => Vector2FS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2IS() => SampleValuesRO.RandomPairList2IS.ForEach(p => Vector2IS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2LS() => SampleValuesRO.RandomPairList2LS.ForEach(p => Vector2LS.CrossProduct(p.Item1, p.Item2));
    }
}
