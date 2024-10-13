using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Clipper2Lib;
using MapToolkit;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class GetSignedAreaBenchmark
    {
        [Benchmark] public object GetSignedArea_Clipper() => Clipper.Area(SampleValues.CircleP64);

        [Benchmark] public object GetSignedArea_NTS() => SampleValues.CircleNTS.Area;
        [Benchmark] public object GetSignedArea_MapKit() => SampleValues.PosListGRM.GetSignedArea();

        [Benchmark] public object GetSignedArea_2D_Shoelace() => SignedArea<double, Vector2D>.GetSignedAreaD(SampleValuesRO.Circle2D);
        [Benchmark] public object GetSignedArea_2L_Shoelace() => SignedArea<long, Vector2L>.GetSignedAreaD(SampleValuesRO.Circle2L);
        [Benchmark] public object GetSignedArea_2F_Shoelace() => SignedArea<float, Vector2F>.GetSignedAreaD(SampleValuesRO.Circle2F);
        [Benchmark] public object GetSignedArea_2I_Shoelace() => SignedArea<int, Vector2I>.GetSignedAreaD(SampleValuesRO.Circle2I);

    }
}
