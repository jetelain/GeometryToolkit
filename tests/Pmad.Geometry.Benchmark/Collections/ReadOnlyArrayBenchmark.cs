using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Benchmark.Collections
{
    public class ReadOnlyArrayBenchmark
    {
        [Benchmark]
        public object SelectToArray() => SampleValuesRO.RandomList2D.Select(v => new Vector2DS(v.X, v.Y)).ToArray();

        [Benchmark]
        public object UnsafeAs() => SampleValuesRO.RandomList2D.UnsafeAs<Vector2D, Vector2DS>();

        [Benchmark]
        public object CopyAs() => SampleValuesRO.RandomList2D.CopyAs<Vector2D, Vector2DS>();
    }
}
