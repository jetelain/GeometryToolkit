using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class DotDBenchmark
    {
        [Benchmark]
        public void DotDVector2D() => SampleValuesRO.RandomPairList2D.ForEach(p => Vector2D.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2F() => SampleValuesRO.RandomPairList2F.ForEach(p => Vector2F.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2I() => SampleValuesRO.RandomPairList2I.ForEach(p => Vector2I.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2L() => SampleValuesRO.RandomPairList2L.ForEach(p => Vector2L.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2DS() => SampleValuesRO.RandomPairList2DS.ForEach(p => Vector2DS.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2FS() => SampleValuesRO.RandomPairList2FS.ForEach(p => Vector2FS.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2IS() => SampleValuesRO.RandomPairList2IS.ForEach(p => Vector2IS.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void DotDVector2LS() => SampleValuesRO.RandomPairList2LS.ForEach(p => Vector2LS.DotD(p.Item1, p.Item2));
    }
}
