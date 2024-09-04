using Clipper2Lib;
using GameRealisticMap.Geometries;
using NetTopologySuite.Geometries;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Benchmark
{
    internal class PolygonSampleSet
    {
        public static PolygonSampleSet CreateCircle(int radius)
            => CreateCircle(0, 0, radius);

        public static PolygonSampleSet CreateCircle(int x, int y, int radius) 
            => new PolygonSampleSet(Enumerable.Range(0, 41).Select(a => new Vector2I((int)(Math.Cos(a * Math.PI / 20) * radius) + x, (int)(Math.Sin(a * Math.PI / 20) * radius) + y)));

        public PolygonSampleSet(IEnumerable<Vector2I> source)
        {
            Points2I = source.ToReadOnlyArray();
            Points2F = Points2I.Select(p => new Vector2F(p.X, p.Y)).ToReadOnlyArray();
            Points2D = Points2I.Select(p => new Vector2D(p.X, p.Y)).ToReadOnlyArray();
            Points2L = Points2I.Select(p => new Vector2L(p.X, p.Y)).ToReadOnlyArray();
            Points2IS = Points2I.Select(p => new Vector2IS(p.X, p.Y)).ToReadOnlyArray();
            Points2FS = Points2I.Select(p => new Vector2FS(p.X, p.Y)).ToReadOnlyArray();
            Points2DS = Points2I.Select(p => new Vector2DS(p.X, p.Y)).ToReadOnlyArray();
            Points2LS = Points2I.Select(p => new Vector2LS(p.X, p.Y)).ToReadOnlyArray();
            PointsP64 = new Path64(Points2I.Select(p => new Point64(p.X, p.Y)));
            PointsPtD = new PathD(Points2I.Select(p => new PointD(p.X, p.Y)));
            PointsGRM = Points2I.Select(p => new TerrainPoint(p.X, p.Y)).ToList();
            PointsNTS = Points2I.Select(p => new Coordinate(p.X, p.Y)).ToArray();

            Polygon2I = new(Points2I);
            Polygon2F = new(Points2F);
            Polygon2D = new(Points2D);
            Polygon2L = new(Points2L);
            Polygon2IS = new(Points2IS);
            Polygon2FS = new(Points2FS);
            Polygon2DS = new(Points2DS);
            Polygon2LS = new(Points2LS);
            PolygonGRM = new(PointsGRM);
            PolygonNTS = new(new(PointsNTS));
        }

        public readonly ReadOnlyArray<Vector2I> Points2I;
        public readonly ReadOnlyArray<Vector2F> Points2F;
        public readonly ReadOnlyArray<Vector2D> Points2D;
        public readonly ReadOnlyArray<Vector2L> Points2L;
        public readonly ReadOnlyArray<Vector2IS> Points2IS;
        public readonly ReadOnlyArray<Vector2FS> Points2FS;
        public readonly ReadOnlyArray<Vector2DS> Points2DS;
        public readonly ReadOnlyArray<Vector2LS> Points2LS;
        public readonly Path64 PointsP64;
        public readonly PathD PointsPtD;
        public readonly List<TerrainPoint> PointsGRM;
        public readonly Coordinate[] PointsNTS;

        public readonly Shapes.Polygon<int, Vector2I> Polygon2I;
        public readonly Shapes.Polygon<float, Vector2F> Polygon2F;
        public readonly Shapes.Polygon<double, Vector2D> Polygon2D;
        public readonly Shapes.Polygon<long, Vector2L> Polygon2L;
        public readonly Shapes.Polygon<int, Vector2IS> Polygon2IS;
        public readonly Shapes.Polygon<float, Vector2FS> Polygon2FS;
        public readonly Shapes.Polygon<double, Vector2DS> Polygon2DS;
        public readonly Shapes.Polygon<long, Vector2LS> Polygon2LS;
        public readonly TerrainPolygon PolygonGRM;
        public readonly Polygon PolygonNTS;
    }
}
