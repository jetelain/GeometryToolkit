using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class NearestPointPathBenchmark
    {
        [Benchmark]
        public void NearestPointSegment2D() => SampleValues.RandomTripletList2D.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2F() => SampleValues.RandomTripletList2F.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2I() => SampleValues.RandomTripletList2I.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2L() => SampleValues.RandomTripletList2L.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2DS() => SampleValues.RandomTripletList2DS.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2FS() => SampleValues.RandomTripletList2FS.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2IS() => SampleValues.RandomTripletList2IS.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointSegment2LS() => SampleValues.RandomTripletList2LS.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));
    }
}
