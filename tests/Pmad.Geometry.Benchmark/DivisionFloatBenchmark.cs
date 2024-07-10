using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class DivisionFloatBenchmark
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Divide1(Vector2F left, Vector2F right) => new(left.Vector / right.Vector.WithElement(2, 1).WithElement(3, 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2F Divide2(Vector2F left, Vector2F right) => new(left.ToVector2() / right.ToVector2());

        [Benchmark]
        public void Divide_Vector128() => SampleValues.RandomNonZeroList2F.ForEach(p => Divide1(p, p));

        [Benchmark]
        public void Divide_Vector2() => SampleValues.RandomNonZeroList2F.ForEach(p => Divide2(p, p));
    }
}
