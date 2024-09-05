using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace Pmad.Geometry.Benchmark.VectorOperations
{
    public class MatrixRotationBenchmark
    {

        const float AngleF = 1;
        const double AngleD = 1;

        [Benchmark] public void Matrix2x2() => SampleValuesRO.RandomList2F.ForEach(p => Vector2.Transform(p.ToVector2(), System.Numerics.Matrix3x2.CreateRotation(AngleF)));
        [Benchmark] public void Matrix2x2_Generic_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix2x2<double, Vector2D>.CreateRotation(AngleD).Transform(p));
        [Benchmark] public void Matrix2x2_GenericD_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix2x2<double, Vector2D>.CreateRotationD(AngleD).Transform(p));
        [Benchmark] public void Matrix2x2_Generic_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix2x2<float, Vector2F>.CreateRotation(AngleF).Transform(p));
        [Benchmark] public void Matrix2x2_GenericD_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix2x2<float, Vector2F>.CreateRotationD(AngleD).Transform(p));

        [Benchmark] public void Matrix3x2() => SampleValuesRO.RandomList2F.ForEach(p => Vector2.Transform(p.ToVector2(), System.Numerics.Matrix3x2.CreateRotation(AngleF, default)));
        [Benchmark] public void Matrix3x2_Generic_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix3x2<double, Vector2D>.CreateRotation(AngleD, default).Transform(p));
        [Benchmark] public void Matrix3x2_GenericD_2D() => SampleValuesRO.RandomList2D.ForEach(p => Matrix3x2<double, Vector2D>.CreateRotationD(AngleD, default).Transform(p));
        [Benchmark] public void Matrix3x2_Generic_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix3x2<float, Vector2F>.CreateRotation(AngleF, default).Transform(p));
        [Benchmark] public void Matrix3x2_GenericD_2F() => SampleValuesRO.RandomList2F.ForEach(p => Matrix3x2<float, Vector2F>.CreateRotationD(AngleD, default).Transform(p));
    }
}
