using Clipper2Lib;

namespace Pmad.Geometry.Benchmark
{
    internal static class SampleValues
    {
        public static List<Vector2I>  RandomList2I  = Enumerable.Range(0, 100).Select(_ => new Vector2I(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100))).ToList();
        public static List<Vector2F>  RandomList2F  = RandomList2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  RandomList2D  = RandomList2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  RandomList2L  = RandomList2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> RandomList2IS = RandomList2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> RandomList2FS = RandomList2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> RandomList2DS = RandomList2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> RandomList2LS = RandomList2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();
        public static List<Vector2FN> RandomList2FN = RandomList2I.Select(p => new Vector2FN(p.X, p.Y)).ToList();
        public static Path64          RandomListP64 = new Path64(RandomList2I.Select(p => new Point64(p.X, p.Y)));

        public static List<Vector2I>  RandomNonZeroList2I  = Enumerable.Range(0, 100).Select(_ => new Vector2I(Random.Shared.Next(1, 100), Random.Shared.Next(1, 100))).ToList();
        public static List<Vector2F>  RandomNonZeroList2F  = RandomNonZeroList2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  RandomNonZeroList2D  = RandomNonZeroList2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  RandomNonZeroList2L  = RandomNonZeroList2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> RandomNonZeroList2IS = RandomNonZeroList2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> RandomNonZeroList2FS = RandomNonZeroList2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> RandomNonZeroList2DS = RandomNonZeroList2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> RandomNonZeroList2LS = RandomNonZeroList2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();
        public static List<Vector2FN> RandomNonZeroList2FN = RandomNonZeroList2I.Select(p => new Vector2FN(p.X, p.Y)).ToList();
        public static Path64          RandomNonZeroListP64 = new Path64(RandomNonZeroList2I.Select(p => new Point64(p.X, p.Y)));


        public static List<Vector2I>  Circle2I  = Enumerable.Range(0, 21).Select(a => new Vector2I((int)(Math.Cos(a * Math.PI / 20) * 100), (int)(Math.Sin(a * Math.PI / 20) * 100))).ToList();
        public static List<Vector2F>  Circle2F  = Circle2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  Circle2D  = Circle2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  Circle2L  = Circle2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> Circle2IS = Circle2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> Circle2FS = Circle2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> Circle2DS = Circle2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> Circle2LS = Circle2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();
        public static List<Vector2FN> Circle2FN = Circle2I.Select(p => new Vector2FN(p.X, p.Y)).ToList();
        public static Path64          CircleP64 = new Path64(Circle2I.Select(p => new Point64(p.X, p.Y)));


    }
}
