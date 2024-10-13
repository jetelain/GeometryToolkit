using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Clipper2Lib;
using MapToolkit;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class CentroidBenchmark
    {

        [Benchmark] public object ShellCentroid_NTS() => SampleValues.CircleNTS.Centroid;

        [Benchmark] public object ShellCentroid_2D() => Centroid<double, Vector2D>.GetCentroid(SampleValuesRO.Circle2D);

        [Benchmark] public object ShellCentroid_2L() => Centroid<long, Vector2L>.GetCentroid(SampleValuesRO.Circle2L);

    }
}
