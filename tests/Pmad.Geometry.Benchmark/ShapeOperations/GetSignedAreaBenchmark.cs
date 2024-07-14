using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class GetSignedAreaBenchmark
    {
        [Benchmark] public void GetSignedArea_2D() => SampleValuesRO.Circle2D.GetSignedArea();
        [Benchmark] public void GetSignedArea_2D_Generic() => SignedArea<double,Vector2D>.GetSignedAreaD(SampleValuesRO.Circle2D);

    }
}
