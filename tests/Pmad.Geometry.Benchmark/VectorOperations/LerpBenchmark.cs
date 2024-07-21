using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class LerpBenchmark
    {
        [Benchmark]
        public void LerpVector2D() => SampleValues.RandomPairList2D.ForEach(p => Vector2D.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2D_Vectors() => SampleValues.RandomPairList2D.ForEach(p => Vectors.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2F() => SampleValues.RandomPairList2F.ForEach(p => Vector2F.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2F_Float() => SampleValues.RandomPairList2F.ForEach(p => Vector2F.Lerp(p.Item1, p.Item2, 0.5f));

        [Benchmark]
        public void LerpVector2I() => SampleValues.RandomPairList2I.ForEach(p => Vector2I.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2L() => SampleValues.RandomPairList2L.ForEach(p => Vector2L.Lerp(p.Item1, p.Item2, 0.5d));
        [Benchmark]
        public void LerpVector2L_Vectors() => SampleValues.RandomPairList2L.ForEach(p => Vectors.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2DS() => SampleValues.RandomPairList2DS.ForEach(p => Vector2DS.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2FS() => SampleValues.RandomPairList2FS.ForEach(p => Vector2FS.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2IS() => SampleValues.RandomPairList2IS.ForEach(p => Vector2IS.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void LerpVector2LS() => SampleValues.RandomPairList2LS.ForEach(p => Vector2LS.Lerp(p.Item1, p.Item2, 0.5d));
    }
}
