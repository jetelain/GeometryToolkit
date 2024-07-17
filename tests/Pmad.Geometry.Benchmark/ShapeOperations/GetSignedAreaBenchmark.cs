using BenchmarkDotNet.Attributes;
using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class GetSignedAreaBenchmark
    {
        [Benchmark] public void GetSignedArea_Clipper() => Clipper.Area(SampleValues.CircleP64);

        [Benchmark] public void GetSignedArea_2D_Shoelace() => SignedArea<double, Vector2D>.GetSignedAreaD(SampleValuesRO.Circle2D);
        [Benchmark] public void GetSignedArea_2D_Classic() => SignedArea<double,Vector2D>.GetSignedAreaClassicD(SampleValuesRO.Circle2D);

        [Benchmark] public void GetSignedArea_2L_Shoelace() => SignedArea<long, Vector2L>.GetSignedAreaD(SampleValuesRO.Circle2L);
        [Benchmark] public void GetSignedArea_2L_Classic() => SignedArea<long, Vector2L>.GetSignedAreaClassicD(SampleValuesRO.Circle2L);

    }
}
