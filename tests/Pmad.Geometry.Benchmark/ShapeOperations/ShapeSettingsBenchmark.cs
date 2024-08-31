using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class ShapeSettingsBenchmark
    {
        private readonly ShapeSettings<long, Vector2L> shapeSettings = ShapeSettings<long, Vector2L>.Default;

        [Benchmark] public object FromClipper() => shapeSettings.FromClipper(SampleValues.PosListP64);

        [Benchmark] public object FromClipperToRing() => shapeSettings.FromClipperToRing(SampleValues.PosListP64);

        [Benchmark] public object ToClipper() => shapeSettings.ToClipper(SampleValuesRO.PosList2L);
    }
}
