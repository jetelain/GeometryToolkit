using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class AdditionBenchmark
    {
        private int x1 = 12;
        private int y1 = 13;
        private int x2 = 14;
        private int y2 = 15;

        [Benchmark]
        public Vector2D AdditionVector2D() => new Vector2D(x1, y1) + new Vector2D(x2, y2);

        [Benchmark]
        public Vector2F AdditionVector2F() => new Vector2F(x1, y1) + new Vector2F(x2, y2);

        [Benchmark]
        public Vector2I AdditionVector2I() => new Vector2I(x1, y1) + new Vector2I(x2, y2);

        [Benchmark]
        public Vector2L AdditionVector2L() => new Vector2L(x1, y1) + new Vector2L(x2, y2);

        [Benchmark]
        public Vector2 AdditionVector2() => new Vector2(x1, y1) + new Vector2(x2, y2);

        [Benchmark]
        public Vector2DS AdditionVector2DS() => new Vector2DS(x1, y1) + new Vector2DS(x2, y2);

        [Benchmark]
        public Vector2FS AdditionVector2FS() => new Vector2FS(x1, y1) + new Vector2FS(x2, y2);

        [Benchmark]
        public Vector2IS AdditionVector2IS() => new Vector2IS(x1, y1) + new Vector2IS(x2, y2);

        [Benchmark]
        public Vector2LS AdditionVector2LS() => new Vector2LS(x1, y1) + new Vector2LS(x2, y2);

    }
}
