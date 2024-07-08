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


    }
}
