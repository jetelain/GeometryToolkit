using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class CrossProduct3Benchmark
    {
        [Benchmark]
        public void CrossProductVector2D() => SampleValues.RandomTripletList2D.ForEach(p => Vector2D.CrossProduct(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void CrossProductVector2D_Scalar() => SampleValues.RandomTripletList2D.ForEach(p => Vector2D.CrossProductScalar(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2F() => SampleValues.RandomTripletList2F.ForEach(p => Vector2F.CrossProduct(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2I() => SampleValues.RandomTripletList2I.ForEach(p => Vector2I.CrossProduct(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void CrossProductVector2L() => SampleValues.RandomTripletList2L.ForEach(p => Vector2L.CrossProduct(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void CrossProductVector2L_Scalar() => SampleValues.RandomTripletList2L.ForEach(p => Vector2L.CrossProductScalar(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2DS() => SampleValues.RandomTripletList2DS.ForEach(p => Vector2DS.CrossProduct(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2FS() => SampleValues.RandomTripletList2FS.ForEach(p => Vector2FS.CrossProduct(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2IS() => SampleValues.RandomTripletList2IS.ForEach(p => Vector2IS.CrossProduct(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2LS() => SampleValues.RandomTripletList2LS.ForEach(p => Vector2LS.CrossProduct(p.Item1, p.Item2, p.Item3));

        //[Benchmark]
        //public void CrossProductVector2FN() => SampleValues.RandomTripletList2FN.ForEach(p => Vector2FN.CrossProduct(p.Item1, p.Item2, p.Item3));
    }
}
