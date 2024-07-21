using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark
{
    public class ComparativeBenchmark : ITest
    {
        [ParamsSource(nameof(Tests))]
        public ITest Test;

        public static IEnumerable<ITest> Tests() => new ITest[] 
        {  
            new Test<double,Vector2D>(SampleValuesRO.RandomList2D, SampleValuesRO.RandomPairList2D, SampleValuesRO.RandomTripletList2D, SampleValuesRO.PosList2D, SampleValuesRO.Circle2D),
            new Test<double,Vector2DS>(SampleValuesRO.RandomList2DS, SampleValuesRO.RandomPairList2DS, SampleValuesRO.RandomTripletList2DS, SampleValuesRO.PosList2DS, SampleValuesRO.Circle2DS),

            new Test<float,Vector2F>(SampleValuesRO.RandomList2F, SampleValuesRO.RandomPairList2F, SampleValuesRO.RandomTripletList2F, SampleValuesRO.PosList2F, SampleValuesRO.Circle2F),
            new Test<float,Vector2FS>(SampleValuesRO.RandomList2FS, SampleValuesRO.RandomPairList2FS, SampleValuesRO.RandomTripletList2FS, SampleValuesRO.PosList2FS, SampleValuesRO.Circle2FS),

            new Test<int,Vector2I> (SampleValuesRO.RandomList2I,  SampleValuesRO.RandomPairList2I,  SampleValuesRO.RandomTripletList2I,  SampleValuesRO.PosList2I,  SampleValuesRO.Circle2I),
            new Test<int,Vector2IS>(SampleValuesRO.RandomList2IS, SampleValuesRO.RandomPairList2IS, SampleValuesRO.RandomTripletList2IS, SampleValuesRO.PosList2IS, SampleValuesRO.Circle2IS),

            new Test<long,Vector2L> (SampleValuesRO.RandomList2L,  SampleValuesRO.RandomPairList2L,  SampleValuesRO.RandomTripletList2L,  SampleValuesRO.PosList2L,  SampleValuesRO.Circle2L),
            new Test<long,Vector2LS>(SampleValuesRO.RandomList2LS, SampleValuesRO.RandomPairList2LS, SampleValuesRO.RandomTripletList2LS, SampleValuesRO.PosList2LS, SampleValuesRO.Circle2LS),
        };

        [Benchmark]
        public void AngleRadians() => Test.AngleRadians();

        [Benchmark]
        public void CrossProduct3() => Test.CrossProduct3();

        [Benchmark]
        public void CrossProductD() => Test.CrossProductD();

        [Benchmark]
        public void DotD() => Test.DotD();

        [Benchmark]
        public double GetLengthD() => Test.GetLengthD();

        [Benchmark]
        public double GetSignedArea() => Test.GetSignedArea();

        [Benchmark]
        public void Lerp() => Test.Lerp();

        [Benchmark]
        public object Max() => Test.Max();

        [Benchmark]
        public object Min() => Test.Min();

        [Benchmark]
        public void NearestPointPath() => Test.NearestPointPath();

        [Benchmark]
        public void NearestPointSegment() => Test.NearestPointSegment();

        [Benchmark]
        public void PointInPolygon() => Test.PointInPolygon();

        [Benchmark]
        public object Simplify() => Test.Simplify();

        [Benchmark]
        public object Sum() => Test.Sum();

        [Benchmark]
        public object VectorEnvelope() => Test.VectorEnvelope();
    }
}
