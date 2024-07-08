using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class CrossProductBenchmark
    {
        private int x1 = 12;
        private int y1 = 13;
        private int x2 = 14;
        private int y2 = 15;

        [Benchmark]
        public double CrossProductVector2D() => Vector2D.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2D_Scalar() => Vector2D.CrossProductScalar(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2F() => Vector2F.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2I() => Vector2I.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2L() => Vector2L.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2DS() => Vector2DS.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2FS() => Vector2FS.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2IS() => Vector2IS.CrossProduct(new(x1, y1), new(x2, y2));

        [Benchmark]
        public double CrossProductVector2LS() => Vector2LS.CrossProduct(new(x1, y1), new(x2, y2));

    }
}
