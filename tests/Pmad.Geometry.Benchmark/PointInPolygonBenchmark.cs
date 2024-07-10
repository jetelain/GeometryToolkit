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
        public void PointInPolygon() => SampleValues.RandomListP64.ForEach(p => InternalClipper.PointInPolygon(p, SampleValues.CircleP64));

        [Benchmark] public void PointInPolygon_2D() => SampleValues.RandomList2D.ForEach(p => SampleValues.Circle2D.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2F() => SampleValues.RandomList2F.ForEach(p => SampleValues.Circle2F.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2I() => SampleValues.RandomList2I.ForEach(p => SampleValues.Circle2I.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2L() => SampleValues.RandomList2L.ForEach(p => SampleValues.Circle2L.TestPointInPolygon(p));

        [Benchmark] public void PointInPolygon_2DS() => SampleValues.RandomList2DS.ForEach(p => SampleValues.Circle2DS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2FS() => SampleValues.RandomList2FS.ForEach(p => SampleValues.Circle2FS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2IS() => SampleValues.RandomList2IS.ForEach(p => SampleValues.Circle2IS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2LS() => SampleValues.RandomList2LS.ForEach(p => SampleValues.Circle2LS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2FN() => SampleValues.RandomList2FN.ForEach(p => SampleValues.Circle2FN.TestPointInPolygon(p));
    }
}
