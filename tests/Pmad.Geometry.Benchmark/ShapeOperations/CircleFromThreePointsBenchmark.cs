using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class CircleFromThreePointsBenchmark
    {
        [Benchmark] public void FromThreePoints_2D() => SampleValuesRO.RandomTripletList2D.ForEach(p => Circle<double, Vector2D>.FromThreePoints(ShapeSettings<double, Vector2D>.Default, p.Item1, p.Item2, p.Item3));

        [Benchmark] public void FromThreePoints_2F() => SampleValuesRO.RandomTripletList2F.ForEach(p => Circle<float, Vector2F>.FromThreePoints(ShapeSettings<float, Vector2F>.Default, p.Item1, p.Item2, p.Item3));
    }
}
