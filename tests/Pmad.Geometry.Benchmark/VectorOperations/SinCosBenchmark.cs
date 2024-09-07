using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class SinCosBenchmark
    {
        [Benchmark] public object SinCos_Double_Alone() => Math.SinCos(1.0);
        [Benchmark] public object SinCos_Double() => MatrixHelper.SinCos(1.0);
        [Benchmark] public void SinCos_Double_Dispatcher() => MatrixHelper.SinCos<double>(1.0);
        [Benchmark] public object SinCos_Float_Alone() => MathF.SinCos(1f);
        [Benchmark] public object SinCos_Float() => MatrixHelper.SinCos(1f);
        [Benchmark] public void SinCos_Float_Dispatcher() => MatrixHelper.SinCos<float>(1f);
    }
}
