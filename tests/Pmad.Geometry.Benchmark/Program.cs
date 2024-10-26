using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Benchmark.ShapeOperations;
using Pmad.Geometry.Benchmark.VectorOperations;
using Pmad.Geometry.Shapes.Svg;

namespace Pmad.Geometry.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Vector<double>.Count: {0}", Vector<double>.Count);
            Console.WriteLine("Vector<float>.Count: {0}", Vector<float>.Count);
            Console.WriteLine("Vector512.IsHardwareAccelerated: {0}", Vector512.IsHardwareAccelerated);
            Console.WriteLine("Vector256.IsHardwareAccelerated: {0}", Vector256.IsHardwareAccelerated);
            Console.WriteLine("Vector128.IsHardwareAccelerated: {0}", Vector128.IsHardwareAccelerated);
            Console.WriteLine("Vector64.IsHardwareAccelerated: {0}", Vector64.IsHardwareAccelerated);


            BenchmarkRunner
                .Run([
                    //typeof(MultiplicationBenchmark),
                    //typeof(DivisionBenchmark),
                    //typeof(DivisionFloatBenchmark),
                    //typeof(CrossProductBenchmark),
                    //typeof(CrossProduct3Benchmark),
                    //typeof(SumBenchmark),
                    //typeof(LengthBenchmark),
                    //typeof(PointInPolygonBenchmark),
                    //typeof(SwapXYBenchmark),
                    //typeof(AdditionBenchmark),
                    //typeof(SmallestRotatedRectangleBenchmark),
                    //typeof(MaxBenchmark),
                    //typeof(LargestRotatedRectangleBenchmark),
                    //typeof(ReadOnlyArrayBenchmark),
                    //typeof(GetSignedAreaBenchmark),
                    //typeof(CircleFromTwoPointsBenchmark),
                    //typeof(CircleFromThreePointsBenchmark),
                    //typeof(NearestPointPathBenchmark),
                    //typeof(AngleBenchmark),
                    //typeof(LerpBenchmark),
                    //typeof(SimplifyBenchmark),
                    //typeof(ComparativeBenchmark),
                    //typeof(DotDBenchmark),
                    //typeof(CentroidBenchmark),
                    //typeof(IntersectsBenchmark),
                    //typeof(IntersectionAreaBenchmark),
                    //typeof(IntersectionBenchmark),
                    //typeof(UnionBenchmark),
                    //typeof(ShapeSettingsBenchmark)
                    //typeof(MatrixRotationBenchmark)
                    //typeof(SinCosBenchmark)
                    //typeof(ToStringBenchmark)
                    //typeof(TextBenchmark)
                    //typeof(SvgBenchmark)
                    typeof(TransformBenchmark)
                ]);
        }
    }
}
