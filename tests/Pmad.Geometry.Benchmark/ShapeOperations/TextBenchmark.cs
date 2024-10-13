using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using NetTopologySuite.IO;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class TextBenchmark
    {
        private static readonly PolygonSampleSet A = PolygonSampleSet.CreateCircle(0, 0, 100);

        [Benchmark] public object ToString_NTS() => A.PolygonNTS.ToString();

        [Benchmark] public object ToString_2D() => A.Polygon2D.ToString();

        [Benchmark] public object ToString_2L() => A.Polygon2L.ToString();

        [Benchmark] public object Parse_NTS() => new WKTReader().Read("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))");

        [Benchmark] public object Parse_2D() => DefaultShapes.Vector2D.ParsePolygon("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))");

        [Benchmark] public object Parse_2L() => DefaultShapes.Vector2L.ParsePolygon("POLYGON ((100 100, 0 100, 0 0, 100 0, 100 100), (25 75, 75 75, 75 25, 25 25, 25 75))");
    }
}
