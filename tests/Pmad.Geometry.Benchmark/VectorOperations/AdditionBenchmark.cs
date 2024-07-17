using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class AdditionBenchmark
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TVector StaticOperator<TVector>(TVector item1, TVector item2) where TVector : struct, IVector<TVector>
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TVector Dispatcher<TVector>(TVector item1, TVector item2) where TVector : struct, IVector<TVector>
        {
            return Vectors.Add(item1, item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2D Direct(Vector2D item1, Vector2D item2)
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2L Direct(Vector2L item1, Vector2L item2)
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2DS Direct(Vector2DS item1, Vector2DS item2)
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2LS Direct(Vector2LS item1, Vector2LS item2)
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2FN Direct(Vector2FN item1, Vector2FN item2)
        {
            return item1 + item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Vector2F Direct(Vector2F item1, Vector2F item2)
        {
            return item1 + item2;
        }

        [Benchmark]
        public void AddVector2D_Direct() => SampleValuesRO.RandomPairList2D.ForEach(p => _ = Direct(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2D_StaticOperator() => SampleValuesRO.RandomPairList2D.ForEach(p => _ = StaticOperator(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2D_Dispatch() => SampleValuesRO.RandomPairList2D.ForEach(p => _ = Dispatcher(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2L_Direct() => SampleValuesRO.RandomPairList2L.ForEach(p => _ = Direct(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2L_StaticOperator() => SampleValuesRO.RandomPairList2L.ForEach(p => _ = StaticOperator(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2L_Dispatch() => SampleValuesRO.RandomPairList2L.ForEach(p => _ = Dispatcher(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2DS_Direct() => SampleValuesRO.RandomPairList2DS.ForEach(p => _ = Direct(p.Item1, p.Item2));
        [Benchmark]
        public void AddVector2LS_Direct() => SampleValuesRO.RandomPairList2LS.ForEach(p => _ = Direct(p.Item1, p.Item2));
        [Benchmark]
        public void AddVector2FN_Direct() => SampleValuesRO.RandomPairList2FN.ForEach(p => _ = Direct(p.Item1, p.Item2));
        [Benchmark]
        public void AddVector2F_Direct() => SampleValuesRO.RandomPairList2F.ForEach(p => _ = Direct(p.Item1, p.Item2));

    }
}
