using System.Runtime.Intrinsics;
using System.Text;
using BenchmarkDotNet.Running;
using Pmad.Geometry.Benchmark.Collections;
using Pmad.Geometry.Benchmark.ShapeOperations;
using Pmad.Geometry.Benchmark.VectorOperations;

namespace Pmad.Geometry.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Vector128.IsHardwareAccelerated: {0}", Vector128.IsHardwareAccelerated);
            Console.WriteLine("Vector64.IsHardwareAccelerated: {0}", Vector64.IsHardwareAccelerated);

            BenchmarkRunner
                .Run([
                    typeof(MultiplicationBenchmark),
                    typeof(DivisionBenchmark),
                    typeof(DivisionFloatBenchmark),
                    typeof(CrossProductBenchmark),
                    typeof(CrossProduct3Benchmark),
                    typeof(SumBenchmark),
                    typeof(LengthBenchmark),
                    typeof(PointInPolygonBenchmark),
                    typeof(SwapXYBenchmark),
                    typeof(AdditionBenchmark),
                    typeof(SmallestRotatedRectangleBenchmark),
                    typeof(MaxBenchmark),
                    typeof(LargestRotatedRectangleBenchmark),
                    typeof(ReadOnlyArrayBenchmark)
                ]);
        }
    }
}
