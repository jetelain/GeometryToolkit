using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pmad.Geometry.Benchmark
{
    public class AdditionBenchmark
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TVector Virtual<TVector>(TVector item1, TVector item2) where TVector : struct, IVector<TVector>
        {
            return item1.Add(item2);
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

        [Benchmark]
        public void AddVector2D_Direct() => SampleValues.RandomPairList2D.ForEach(p => _ = Direct(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2D_Virtual() => SampleValues.RandomPairList2D.ForEach(p => _ = Virtual(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2D_Dispatch() => SampleValues.RandomPairList2D.ForEach(p => _ = Dispatcher(p.Item1,p.Item2));

        [Benchmark]
        public void AddVector2L_Direct() => SampleValues.RandomPairList2L.ForEach(p => _ = Direct(p.Item1, p.Item2));
        
        [Benchmark]
        public void AddVector2L_Virtual() => SampleValues.RandomPairList2L.ForEach(p => _ = Virtual(p.Item1, p.Item2));
        
        [Benchmark]
        public void AddVector2L_Dispatch() => SampleValues.RandomPairList2L.ForEach(p => _ = Dispatcher(p.Item1, p.Item2));

        [Benchmark]
        public void AddVector2DS_Direct() => SampleValues.RandomPairList2DS.ForEach(p => _ = Direct(p.Item1, p.Item2));
        [Benchmark]
        public void AddVector2LS_Direct() => SampleValues.RandomPairList2LS.ForEach(p => _ = Direct(p.Item1, p.Item2));
        [Benchmark]
        public void AddVector2FN_Direct() => SampleValues.RandomPairList2FN.ForEach(p => _ = Direct(p.Item1, p.Item2));

    }
}
