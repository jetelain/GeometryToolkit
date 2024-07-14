using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class CrossProductBenchmark
    {
        [Benchmark]
        public void CrossProductVector2D() => SampleValues.RandomPairList2D.ForEach(p => Vector2D.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2D_Scalar() => SampleValues.RandomPairList2D.ForEach(p => Vector2D.CrossProductScalar(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2F() => SampleValues.RandomPairList2F.ForEach(p => Vector2F.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2I() => SampleValues.RandomPairList2I.ForEach(p => Vector2I.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2L() => SampleValues.RandomPairList2L.ForEach(p => Vector2L.CrossProduct(p.Item1, p.Item2));
        [Benchmark]
        public void CrossProductVector2L_Scalar() => SampleValues.RandomPairList2L.ForEach(p => Vector2L.CrossProductScalar(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2DS() => SampleValues.RandomPairList2DS.ForEach(p => Vector2DS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2FS() => SampleValues.RandomPairList2FS.ForEach(p => Vector2FS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2IS() => SampleValues.RandomPairList2IS.ForEach(p => Vector2IS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2LS() => SampleValues.RandomPairList2LS.ForEach(p => Vector2LS.CrossProduct(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProductVector2FN() => SampleValues.RandomPairList2FN.ForEach(p => Vector2FN.CrossProduct(p.Item1, p.Item2));
    }
}
