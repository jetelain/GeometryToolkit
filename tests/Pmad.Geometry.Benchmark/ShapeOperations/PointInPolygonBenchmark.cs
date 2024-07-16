﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Benchmark.ShapeOperations
{
    public class PointInPolygonBenchmark
    {
        [Benchmark(Baseline = true)]
        public void PointInPolygon() => SampleValues.PosListP64.ForEach(p => InternalClipper.PointInPolygon(p, SampleValues.CircleP64));

        [Benchmark] public void PointInPolygon_2D() => SampleValuesRO.PosList2D.ForEach(p => SampleValuesRO.Circle2D.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2D_Generic() => SampleValuesRO.PosList2D.ForEach(p => PointInPolygon<double,Vector2D>.Test(SampleValuesRO.Circle2D.AsSpan(), p));
        [Benchmark] public void PointInPolygon_2F() => SampleValuesRO.PosList2F.ForEach(p => SampleValuesRO.Circle2F.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2I() => SampleValuesRO.PosList2I.ForEach(p => SampleValuesRO.Circle2I.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2L() => SampleValuesRO.PosList2L.ForEach(p => SampleValuesRO.Circle2L.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2L_Generic() => SampleValuesRO.PosList2L.ForEach(p => PointInPolygon<long, Vector2L>.Test(SampleValuesRO.Circle2L.AsSpan(), p));
        [Benchmark] public void PointInPolygon_2DS() => SampleValuesRO.PosList2DS.ForEach(p => SampleValuesRO.Circle2DS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2FS() => SampleValuesRO.PosList2FS.ForEach(p => SampleValuesRO.Circle2FS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2IS() => SampleValuesRO.PosList2IS.ForEach(p => SampleValuesRO.Circle2IS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2LS() => SampleValuesRO.PosList2LS.ForEach(p => SampleValuesRO.Circle2LS.TestPointInPolygon(p));
        [Benchmark] public void PointInPolygon_2FN() => SampleValuesRO.PosList2FN.ForEach(p => SampleValuesRO.Circle2FN.TestPointInPolygon(p));
    }
}