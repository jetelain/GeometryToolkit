using System.Runtime.Intrinsics;
using BenchmarkDotNet.Running;

namespace Pmad.Geometry.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Vector128.IsHardwareAccelerated: {0}", Vector128.IsHardwareAccelerated);
            Console.WriteLine("Vector64.IsHardwareAccelerated: {0}", Vector64.IsHardwareAccelerated);

            BenchmarkRunner
                .Run([
                    typeof(MultiplicationBenchmark),
                    typeof(DivisionBenchmark),
                    typeof(DivisionFloatBenchmark),
                    typeof(CrossProductBenchmark),
                    typeof(SumBenchmark),
                    typeof(LengthBenchmark),
                    typeof(PointInPolygonBenchmark)
                ]);
        }
    }
}
