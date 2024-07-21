using System.Numerics;
using BenchmarkDotNet.Attributes;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Benchmark
{
    public class Test<TPrimitive, TVector> : ITest 
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly ReadOnlyArray<TVector> RandomList;
        private readonly ReadOnlyArray<(TVector, TVector)> RandomPairList;
        private readonly ReadOnlyArray<(TVector, TVector, TVector)> RandomTripletList;
        private readonly ReadOnlyArray<TVector> PosList;
        private readonly ReadOnlyArray<TVector> Circle;

        public Test(ReadOnlyArray<TVector> randomList, ReadOnlyArray<(TVector, TVector)> randomPairList, ReadOnlyArray<(TVector, TVector, TVector)> randomTripletList, ReadOnlyArray<TVector> posList, ReadOnlyArray<TVector> circle)
        {
            RandomList = randomList;
            RandomPairList = randomPairList;
            RandomTripletList = randomTripletList;
            PosList = posList;
            Circle = circle;
        }

        [Benchmark]
        public double GetSignedArea() => SignedArea<TPrimitive, TVector>.GetSignedAreaD(Circle);

        [Benchmark]
        public object Max() => RandomList.Max();

        [Benchmark]
        public object Min() => RandomList.Min();

        [Benchmark]
        public object Sum() => RandomList.Sum();

        [Benchmark]
        public object VectorEnvelope() => VectorEnvelope<TVector>.FromList(RandomList);

        [Benchmark]
        public double GetLengthD() => RandomList.GetLengthD();

        [Benchmark]
        public object Simplify() => RandomList.Simplify();

        [Benchmark]
        public void PointInPolygon() => PosList.ForEach(p => Circle.TestPointInPolygon(p));

        [Benchmark]
        public void AngleRadians() => RandomPairList.ForEach(p => _ = Vectors.AngleRadians(p.Item1, p.Item2));

        [Benchmark]
        public void CrossProduct3() => RandomTripletList.ForEach(p => TVector.CrossProduct(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void CrossProductD() => RandomPairList.ForEach(p => TVector.CrossProductD(p.Item1, p.Item2));

        [Benchmark]
        public void DotD() => RandomPairList.ForEach(p => TVector.DotD(p.Item1, p.Item2));

        [Benchmark]
        public void Lerp() => RandomPairList.ForEach(p => TVector.Lerp(p.Item1, p.Item2, 0.5d));

        [Benchmark]
        public void NearestPointSegment() => RandomTripletList.ForEach(p => Vectors.NearestPointSegment(p.Item1, p.Item2, p.Item3));

        [Benchmark]
        public void NearestPointPath() => PosList.ForEach(p => Circle.NearestPointPath(p));

        public override string ToString()
        {
            return typeof(TVector).Name;
        }

    }
}
