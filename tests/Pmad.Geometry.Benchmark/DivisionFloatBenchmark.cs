using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class DivisionFloatBenchmark
    {
        private int x1 = 12;
        private int y1 = 13;
        private int x2 = 14;
        private int y2 = 15;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Divide1(Vector2F left, Vector2F right) => new(left.Vector / right.Vector.WithElement(2, 1).WithElement(3, 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Divide2(Vector2F left, Vector2F right) => new(left.ToVector2() / right.ToVector2());

        [Benchmark]
        public Vector2F Divide_Vector128() => Divide1(new(x1, y1), new(x2, y2));

        [Benchmark]
        public Vector2F Divide_Vector2() => Divide2(new(x1, y1), new(x2, y2));
    }
}
