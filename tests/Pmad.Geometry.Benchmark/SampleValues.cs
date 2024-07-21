using Clipper2Lib;

namespace Pmad.Geometry.Benchmark
{
    internal static class SampleValues
    {
        public static List<Vector2I>  RandomList2I  = Enumerable.Range(0, 400).Select(_ => new Vector2I(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100))).ToList();
        public static List<Vector2F>  RandomList2F  = RandomList2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  RandomList2D  = RandomList2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  RandomList2L  = RandomList2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> RandomList2IS = RandomList2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> RandomList2FS = RandomList2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> RandomList2DS = RandomList2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> RandomList2LS = RandomList2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();

        public static List<(Vector2I ,Vector2I )> RandomPairList2I  = Enumerable.Range(0, 400).Select(_ => (new Vector2I(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100)), new Vector2I(Random.Shared.Next(1, 200), Random.Shared.Next(1, 200)))).ToList();
        public static List<(Vector2F ,Vector2F )> RandomPairList2F  = RandomPairList2I.Select(p => (new Vector2F(p.Item1.X, p.Item1.Y) ,new Vector2F (p.Item2.X, p.Item2.Y) )).ToList();
        public static List<(Vector2D ,Vector2D )> RandomPairList2D  = RandomPairList2I.Select(p => (new Vector2D(p.Item1.X, p.Item1.Y) ,new Vector2D (p.Item2.X, p.Item2.Y) )).ToList();
        public static List<(Vector2L ,Vector2L )> RandomPairList2L  = RandomPairList2I.Select(p => (new Vector2L(p.Item1.X, p.Item1.Y) ,new Vector2L (p.Item2.X, p.Item2.Y) )).ToList();
        public static List<(Vector2IS,Vector2IS)> RandomPairList2IS = RandomPairList2I.Select(p => (new Vector2IS(p.Item1.X, p.Item1.Y),new Vector2IS(p.Item2.X, p.Item2.Y))).ToList();
        public static List<(Vector2FS,Vector2FS)> RandomPairList2FS = RandomPairList2I.Select(p => (new Vector2FS(p.Item1.X, p.Item1.Y),new Vector2FS(p.Item2.X, p.Item2.Y))).ToList();
        public static List<(Vector2DS,Vector2DS)> RandomPairList2DS = RandomPairList2I.Select(p => (new Vector2DS(p.Item1.X, p.Item1.Y),new Vector2DS(p.Item2.X, p.Item2.Y))).ToList();
        public static List<(Vector2LS,Vector2LS)> RandomPairList2LS = RandomPairList2I.Select(p => (new Vector2LS(p.Item1.X, p.Item1.Y),new Vector2LS(p.Item2.X, p.Item2.Y))).ToList();

        public static List<(Vector2I ,Vector2I ,Vector2I )> RandomTripletList2I  = Enumerable.Range(0, 400).Select(_ => (new Vector2I(Random.Shared.Next(-100, 100), Random.Shared.Next(-100, 100)), new Vector2I(Random.Shared.Next(1, 200), Random.Shared.Next(-200, 1)), new Vector2I(Random.Shared.Next(-200, 1), Random.Shared.Next(-200, 1)))).ToList();
        public static List<(Vector2F ,Vector2F ,Vector2F )> RandomTripletList2F  = RandomTripletList2I.Select(p => (new Vector2F(p.Item1.X, p.Item1.Y) ,new Vector2F (p.Item2.X, p.Item2.Y),new Vector2F (p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2D ,Vector2D ,Vector2D )> RandomTripletList2D  = RandomTripletList2I.Select(p => (new Vector2D(p.Item1.X, p.Item1.Y) ,new Vector2D (p.Item2.X, p.Item2.Y),new Vector2D (p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2L ,Vector2L ,Vector2L )> RandomTripletList2L  = RandomTripletList2I.Select(p => (new Vector2L(p.Item1.X, p.Item1.Y) ,new Vector2L (p.Item2.X, p.Item2.Y),new Vector2L (p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2IS,Vector2IS,Vector2IS)> RandomTripletList2IS = RandomTripletList2I.Select(p => (new Vector2IS(p.Item1.X, p.Item1.Y),new Vector2IS(p.Item2.X, p.Item2.Y),new Vector2IS(p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2FS,Vector2FS,Vector2FS)> RandomTripletList2FS = RandomTripletList2I.Select(p => (new Vector2FS(p.Item1.X, p.Item1.Y),new Vector2FS(p.Item2.X, p.Item2.Y),new Vector2FS(p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2DS,Vector2DS,Vector2DS)> RandomTripletList2DS = RandomTripletList2I.Select(p => (new Vector2DS(p.Item1.X, p.Item1.Y),new Vector2DS(p.Item2.X, p.Item2.Y),new Vector2DS(p.Item3.X, p.Item3.Y))).ToList();
        public static List<(Vector2LS,Vector2LS,Vector2LS)> RandomTripletList2LS = RandomTripletList2I.Select(p => (new Vector2LS(p.Item1.X, p.Item1.Y),new Vector2LS(p.Item2.X, p.Item2.Y),new Vector2LS(p.Item3.X, p.Item3.Y))).ToList();

        public static List<Vector2I>  PosList2I  = Enumerable.Range(0, 100).Select(s => new Vector2I(new Random(s * 13).Next(-100, 100), new Random(s * 29).Next(-100, 100))).ToList();
        public static List<Vector2F>  PosList2F  = PosList2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  PosList2D  = PosList2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  PosList2L  = PosList2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> PosList2IS = PosList2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> PosList2FS = PosList2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> PosList2DS = PosList2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> PosList2LS = PosList2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();
        public static Path64          PosListP64 = new Path64(PosList2I.Select(p => new Point64(p.X, p.Y)));

        public static List<Vector2I>  Circle2I  = Enumerable.Range(0, 41).Select(a => new Vector2I((int)(Math.Cos(a * Math.PI / 20) * 100), (int)(Math.Sin(a * Math.PI / 20) * 100))).ToList();
        public static List<Vector2F>  Circle2F  = Circle2I.Select(p => new Vector2F(p.X, p.Y)).ToList();
        public static List<Vector2D>  Circle2D  = Circle2I.Select(p => new Vector2D(p.X, p.Y)).ToList();
        public static List<Vector2L>  Circle2L  = Circle2I.Select(p => new Vector2L(p.X, p.Y)).ToList();
        public static List<Vector2IS> Circle2IS = Circle2I.Select(p => new Vector2IS(p.X, p.Y)).ToList();
        public static List<Vector2FS> Circle2FS = Circle2I.Select(p => new Vector2FS(p.X, p.Y)).ToList();
        public static List<Vector2DS> Circle2DS = Circle2I.Select(p => new Vector2DS(p.X, p.Y)).ToList();
        public static List<Vector2LS> Circle2LS = Circle2I.Select(p => new Vector2LS(p.X, p.Y)).ToList();
        public static Path64          CircleP64 = new Path64(Circle2I.Select(p => new Point64(p.X, p.Y)));


    }
}
