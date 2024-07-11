using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark
{
    public class PointInPolygonBenchmark
    {
        [Benchmark(Baseline=true)] 
        public void PointInPolygon() => SampleValues.PosListP64.ForEach(p => InternalClipper.PointInPolygon(p, SampleValues.CircleP64));

        [Benchmark] public void PointInPolygon_2D() => SampleValues.PosList2D.ForEach(p => SampleValues.Circle2D.TestPointInPolygon(p));
        //[Benchmark] public void PointInPolygon_2F() => SampleValues.PosList2F.ForEach(p => SampleValues.Circle2F.TestPointInPolygon(p));
        //[Benchmark] public void PointInPolygon_2I() => SampleValues.PosList2I.ForEach(p => SampleValues.Circle2I.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2L() => SampleValues.PosList2L.ForEach(p => SampleValues.Circle2L.TestPointInPolygon(p));

        //[Benchmark] public void PointInPolygon_2DS() => SampleValues.PosList2DS.ForEach(p => SampleValues.Circle2DS.TestPointInPolygon(p));
        //[Benchmark] public void PointInPolygon_2FS() => SampleValues.PosList2FS.ForEach(p => SampleValues.Circle2FS.TestPointInPolygon(p));
        //[Benchmark] public void PointInPolygon_2IS() => SampleValues.PosList2IS.ForEach(p => SampleValues.Circle2IS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2LS() => SampleValues.PosList2LS.ForEach(p => SampleValues.Circle2LS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2FN() => SampleValues.PosList2FN.ForEach(p => SampleValues.Circle2FN.TestPointInPolygon(p));
    }
}
