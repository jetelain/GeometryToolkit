using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class CrossProductBenchmark
    {
        [Benchmark]
        public void CrossProductVector2D() => SampleValues.RandomList2D.ForEach(p => Vector2D.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2D_Scalar() => SampleValues.RandomList2D.ForEach(p => Vector2D.CrossProductScalar(p, p));

        [Benchmark]
        public void CrossProductVector2F() => SampleValues.RandomList2F.ForEach(p => Vector2F.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2I() => SampleValues.RandomList2I.ForEach(p => Vector2I.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2L() => SampleValues.RandomList2L.ForEach(p => Vector2L.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2DS() => SampleValues.RandomList2DS.ForEach(p => Vector2DS.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2FS() => SampleValues.RandomList2FS.ForEach(p => Vector2FS.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2IS() => SampleValues.RandomList2IS.ForEach(p => Vector2IS.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2LS() => SampleValues.RandomList2LS.ForEach(p => Vector2LS.CrossProduct(p, p));

        [Benchmark]
        public void CrossProductVector2FN() => SampleValues.RandomList2FN.ForEach(p => Vector2FN.CrossProduct(p, p));
    }
}
