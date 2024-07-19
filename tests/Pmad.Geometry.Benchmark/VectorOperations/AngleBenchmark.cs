using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class AngleBenchmark
    {

        [Benchmark]
        public void AngleVector2D_Std() => SampleValuesRO.RandomPairList2D.ForEach(p => _ = Vectors.AngleRadians(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2D_Abs() => SampleValuesRO.RandomPairList2D.ForEach(p => _ = Vectors.AngleRadiansAbs(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2DS_Std() => SampleValuesRO.RandomPairList2DS.ForEach(p => _ = Vectors.AngleRadians(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2DS_Abs() => SampleValuesRO.RandomPairList2DS.ForEach(p => _ = Vectors.AngleRadiansAbs(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2L_Std() => SampleValuesRO.RandomPairList2L.ForEach(p => _ = Vectors.AngleRadians(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2L_Abs() => SampleValuesRO.RandomPairList2L.ForEach(p => _ = Vectors.AngleRadiansAbs(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2LS_Std() => SampleValuesRO.RandomPairList2LS.ForEach(p => _ = Vectors.AngleRadians(p.Item1, p.Item2));

        [Benchmark]
        public void AngleVector2LS_Abs() => SampleValuesRO.RandomPairList2LS.ForEach(p => _ = Vectors.AngleRadiansAbs(p.Item1, p.Item2));
    }
}
