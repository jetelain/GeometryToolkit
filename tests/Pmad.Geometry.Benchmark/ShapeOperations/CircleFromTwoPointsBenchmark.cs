using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class CircleFromTwoPointsBenchmark
    {
        [Benchmark] public void FromTwoPoints_2D() => SampleValuesRO.RandomPairList2D.ForEach(p => Circle<double, Vector2D>.FromTwoPoints(ShapeSettings<double, Vector2D>.Default, p.Item1, p.Item2));

        [Benchmark] public void FromTwoPoints_2F() => SampleValuesRO.RandomPairList2F.ForEach(p => Circle<float, Vector2F>.FromTwoPoints(ShapeSettings<float, Vector2F>.Default, p.Item1, p.Item2));



    }
}
