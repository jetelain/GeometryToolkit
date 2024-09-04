using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class MatrixRotationBenchmark
    {
        [Benchmark] public void Matrix2x2_Generic_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix2x2<double, Vector2D>.CreateRotation(1).Transform(p));
        [Benchmark] public void Matrix2x2_GenericD_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix2x2<double, Vector2D>.CreateRotation(1).Transform(p));
        [Benchmark] public void Matrix2x2_Specific_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix2x2D.CreateRotation(1).Transform(p));
        //[Benchmark] public void Matrix2x2_Generic_2DS() => SampleValuesRO.RandomList2DS.ForEach(p => Matrix2x2<double, Vector2DS>.CreateRotation(1).Transform(p));
        //[Benchmark] public void Matrix2x2_Specific_2DS() => SampleValuesRO.RandomList2DS.ForEach(p => Matrix2x2DS.CreateRotation(1).Transform(p));

        [Benchmark] public void Matrix2x2_Generic_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix2x2<float, Vector2F>.CreateRotation(1).Transform(p));
        [Benchmark] public void Matrix2x2_Specific_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix2x2F.CreateRotation(1).Transform(p));
        //[Benchmark] public void Matrix2x2_Generic_2FS() => SampleValuesRO.RandomList2FS.ForEach(p => Matrix2x2<float, Vector2FS>.CreateRotation(1).Transform(p));
        //[Benchmark] public void Matrix2x2_Specific_2FS() => SampleValuesRO.RandomList2FS.ForEach(p => Matrix2x2FS.CreateRotation(1).Transform(p));
    }
}
