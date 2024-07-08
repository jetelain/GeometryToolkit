using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class DivisionBenchmark
    {
        private int x1 = 12;
        private int y1 = 13;
        private int x2 = 14;
        private int y2 = 15;

        [Benchmark]
        public Vector2D DivisionVector2D() => new Vector2D(x1, y1) / new Vector2D(x2, y2);

        [Benchmark]
        public Vector2F DivisionVector2F() => new Vector2F(x1, y1) / new Vector2F(x2, y2);

        [Benchmark]
        public Vector2I DivisionVector2I() => new Vector2I(x1, y1) / new Vector2I(x2, y2);

        [Benchmark]
        public Vector2L DivisionVector2L() => new Vector2L(x1, y1) / new Vector2L(x2, y2);

        [Benchmark]
        public Vector2 DivisionVector2() => new Vector2(x1, y1) / new Vector2(x2, y2);


        [Benchmark]
        public Vector2DS DivisionVector2DS() => new Vector2DS(x1, y1) / new Vector2DS(x2, y2);

        [Benchmark]
        public Vector2FS DivisionVector2FS() => new Vector2FS(x1, y1) / new Vector2FS(x2, y2);

        [Benchmark]
        public Vector2IS DivisionVector2IS() => new Vector2IS(x1, y1) / new Vector2IS(x2, y2);

        [Benchmark]
        public Vector2LS DivisionVector2LS() => new Vector2LS(x1, y1) / new Vector2LS(x2, y2);
    }
}
