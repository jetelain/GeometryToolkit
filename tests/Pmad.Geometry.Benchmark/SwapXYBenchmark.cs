using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class SwapXYBenchmark
    {
        [Benchmark] public void Vector2D() => SampleValues.RandomList2D.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2D_Inline() => SampleValues.RandomList2D.ForEach(p => p.SwapXYInline());
        [Benchmark] public void Vector2D_Static() => SampleValues.RandomList2D.ForEach(p => p.SwapXYStatic());
        [Benchmark] public void Vector2F() => SampleValues.RandomList2F.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2I() => SampleValues.RandomList2I.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2L() => SampleValues.RandomList2L.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2L_Inline() => SampleValues.RandomList2L.ForEach(p => p.SwapXYInline());
        [Benchmark] public void Vector2L_Static() => SampleValues.RandomList2L.ForEach(p => p.SwapXYStatic());
        [Benchmark] public void Vector2DS() => SampleValues.RandomList2DS.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2FS() => SampleValues.RandomList2FS.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2IS() => SampleValues.RandomList2IS.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2LS() => SampleValues.RandomList2LS.ForEach(p => p.SwapXY());
        [Benchmark] public void Vector2FN() => SampleValues.RandomList2FN.ForEach(p => p.SwapXY());


    }
}
