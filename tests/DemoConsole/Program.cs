using System.Text.Json;
using Pmad.Geometry;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Json;
using Pmad.Geometry.Processing;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Shapes.Svg;

// -----------------------------------------------------------------------
// Pmad.Geometry README examples
// -----------------------------------------------------------------------

Section("ShapeSettings");
{
    var settings = DefaultShapes.Vector2D;
    var settings2 = ShapeSettings<double, Vector2D>.Default;
    Console.WriteLine($"Settings OK: {settings != null}, {settings2 != null}");
}

Section("2D Vectors");
{
    var a = new Vector2D(1.0, 2.0);
    var b = new Vector2D(4.0, 6.0);

    Vector2D sum   = a + b;
    double   len   = a.LengthD();
    double   dot   = Vector2D.DotD(a, b);
    double   cross = Vector2D.CrossProductD(a, b);

    bool hit = Vectors.HasSegmentIntersection(a, b, new Vector2D(0, 3), new Vector2D(5, 3), out var pt);
    double angle = Vectors.AngleRadians(a, b);

    Console.WriteLine($"sum={sum}, len={len:F4}, dot={dot}, cross={cross}");
    Console.WriteLine($"segment intersection hit={hit}, pt={pt}");
    Console.WriteLine($"angle={angle:F4} rad");
}

Section("Matrix transforms");
{
    var rotation = Matrix3x2<double, Vector2D>.CreateRotationD(Math.PI / 4, Vector2D.Zero);
    var rotated  = rotation.Transform(new Vector2D(1.0, 0.0));
    Console.WriteLine($"rotated={rotated}");
}

Section("VectorEnvelope (Bounding Box)");
{
    var envelope = VectorEnvelope<Vector2D>.FromPoints(new Vector2D(0, 0), new Vector2D(10, 10));
    bool inside  = envelope.Contains(new Vector2D(5, 5));
    Console.WriteLine($"envelope={envelope}, contains (5,5)={inside}");
}

Section("Polygon");
{
    var settings = DefaultShapes.Vector2D;

    var rect   = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));
    var circle = settings.CreateCirclePolygon(new Vector2D(5, 5), radius: 5.0);

    bool inside = rect.IsInside(new Vector2D(3, 3));
    bool onEdge = rect.IsInsideOrOnBoundary(new Vector2D(0, 5));

    double area     = rect.AreaD;
    Vector2D center = rect.Centroid;

    Console.WriteLine($"rect area={area}, centroid={center}");
    Console.WriteLine($"IsInside (3,3)={inside}, IsInsideOrOnBoundary (0,5)={onEdge}");
    Console.WriteLine($"circle points={circle.Shell.Count}");

    MultiPolygon<double, Vector2D> bigger  = rect.Offset(2.0);
    MultiPolygon<double, Vector2D> smaller = rect.Offset(-1.0);
    Console.WriteLine($"bigger area={bigger.AreaD:F2}, smaller area={smaller.AreaD:F2}");

    MultiPolygon<double, Vector2D> crown      = rect.Crown(innnerOffset: 1.0, outerOffset: 2.0);
    MultiPolygon<double, Vector2D> outerCrown = rect.OuterCrown(2.0);
    MultiPolygon<double, Vector2D> innerCrown = rect.InnerCrown(1.0);
    Console.WriteLine($"crown area={crown.AreaD:F2}, outerCrown area={outerCrown.AreaD:F2}, innerCrown area={innerCrown.AreaD:F2}");

    var other = settings.CreateRectanglePolygon(new Vector2D(5, 5), new Vector2D(15, 15));
    MultiPolygon<double, Vector2D> union        = rect.Union(other);
    MultiPolygon<double, Vector2D> intersection = rect.Intersection(other);
    MultiPolygon<double, Vector2D> difference   = rect.Substract(other);
    Console.WriteLine($"union area={union.AreaD:F2}, intersection area={intersection.AreaD:F2}, difference area={difference.AreaD:F2}");

    double dist = rect.Distance(new Vector2D(20, 5));
    Console.WriteLine($"distance to (20,5)={dist:F2}");
}

Section("Polygon with holes");
{
    var settings = DefaultShapes.Vector2D;

    var shell = new ReadOnlyArray<Vector2D>(
        new Vector2D(0,0), new Vector2D(0,10),
        new Vector2D(10,10), new Vector2D(10,0), new Vector2D(0,0));

    var hole = new ReadOnlyArray<Vector2D>(
        new Vector2D(3,3), new Vector2D(3,7),
        new Vector2D(7,7), new Vector2D(7,3), new Vector2D(3,3));

    var poly = new Polygon<double, Vector2D>(settings, shell,
        new ReadOnlyArray<ReadOnlyArray<Vector2D>>(hole));

    Console.WriteLine($"poly with hole area={poly.AreaD:F2}");
}

Section("WKT serialization");
{
    var settings = DefaultShapes.Vector2D;
    var rect     = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));
    string wkt   = rect.ToString();
    var fromWkt  = settings.ParsePolygon(wkt);
    Console.WriteLine($"WKT: {wkt}");
    Console.WriteLine($"fromWkt area={fromWkt?.AreaD:F2}");
}

Section("SVG path");
{
    var settings  = DefaultShapes.Vector2D;
    var rect      = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));
    string svgPath = rect.ToSvgPath();
    Console.WriteLine($"SVG path: {svgPath}");
}

Section("MultiPolygon");
{
    var settings = DefaultShapes.Vector2D;
    var rect     = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));
    var other    = settings.CreateRectanglePolygon(new Vector2D(5, 5), new Vector2D(15, 15));

    MultiPolygon<double, Vector2D> mp = rect.Union(other);

    foreach (Polygon<double, Vector2D> p in mp)
    {
        Console.WriteLine($"Area = {p.AreaD:F2}");
    }

    double totalArea  = mp.AreaD;
    bool   containsPt = mp.Contains(new Vector2D(3, 3));
    Console.WriteLine($"totalArea={totalArea:F2}, contains (3,3)={containsPt}");
}

Section("Path");
{
    var path = new Path<double, Vector2D>(
        new Vector2D(0, 0),
        new Vector2D(5, 5),
        new Vector2D(10, 0));

    double length   = path.LengthD;
    bool   isClosed = path.IsClosed;
    Console.WriteLine($"path length={length:F4}, isClosed={isClosed}");

    MultiPolygon<double, Vector2D> buffered = path.ToPolygon(width: 2.0);
    Console.WriteLine($"buffered area={buffered.AreaD:F2}");

    var cropBox = new VectorEnvelope<Vector2D>(new Vector2D(0, 0), new Vector2D(6, 6));
    IEnumerable<Path<double, Vector2D>> cropped = path.Crop(cropBox);
    Console.WriteLine($"cropped paths={cropped.Count()}");

    Polygon<double, Vector2D> polyShell = path.ToPolygonAsShell();
    Console.WriteLine($"polyShell area={polyShell.AreaD:F2}");
}

Section("RotatedRectangle");
{
    var rr = new RotatedRectangle<double, Vector2D>(
        center:  new Vector2D(5, 5),
        size:    new Vector2D(8, 4),
        radians: Math.PI / 6);

    double area    = rr.AreaD;
    double degrees = rr.Degrees;
    Polygon<double, Vector2D> poly = rr.ToPolygon();
    Console.WriteLine($"rr area={area:F2}, degrees={degrees:F2}, poly points={poly.Shell.Count}");

    var points = new ReadOnlyArray<Vector2D>(new Vector2D(0,0), new Vector2D(3,1), new Vector2D(2,4));
    RotatedRectangle<double, Vector2D> smallest = RotatedRectangle<double, Vector2D>.GetSmallestContaining(points);
    Console.WriteLine($"smallest rr area={smallest.AreaD:F2}");
}

Section("Circle");
{
    var c = new Circle<double, Vector2D>(center: new Vector2D(5, 5), radius: 3.0);

    bool   inside = c.IsInside(new Vector2D(6, 6));
    double area   = c.AreaD;
    Console.WriteLine($"circle inside (6,6)={inside}, area={area:F4}");

    var points = new List<Vector2D> { new(0,0), new(4,0), new(2,3) };
    Circle<double, Vector2D> enclosing = Circle<double, Vector2D>.GetSmallestContaining(points);
    Console.WriteLine($"enclosing circle center={enclosing.Center}, radius={enclosing.Radius:F4}");

    Polygon<double, Vector2D> poly = c.ToPolygon(count: 32);
    Console.WriteLine($"circle poly points={poly.Shell.Count}");
}

// -----------------------------------------------------------------------
// Pmad.Geometry.Processing README examples
// -----------------------------------------------------------------------

Section("Processing – Sequential union");
{
    var settings = DefaultShapes.Vector2D;
    List<Polygon<double, Vector2D>> polygons = new()
    {
        settings.CreateRectanglePolygon(new Vector2D(0,  0), new Vector2D(5, 5)),
        settings.CreateRectanglePolygon(new Vector2D(3,  3), new Vector2D(8, 8)),
        settings.CreateRectanglePolygon(new Vector2D(10, 0), new Vector2D(15, 5)),
    };

    MultiPolygon<double, Vector2D> merged = polygons.UnionAll();
    Console.WriteLine($"sequential union area={merged.AreaD:F2}");
}

Section("Processing – Parallel union");
{
    var settings = DefaultShapes.Vector2D;
    List<Polygon<double, Vector2D>> polygons = new()
    {
        settings.CreateRectanglePolygon(new Vector2D(0,  0), new Vector2D(5, 5)),
        settings.CreateRectanglePolygon(new Vector2D(3,  3), new Vector2D(8, 8)),
        settings.CreateRectanglePolygon(new Vector2D(10, 0), new Vector2D(15, 5)),
    };

    MultiPolygon<double, Vector2D> merged = await polygons.ParallelUnionAll(idealPartition: 100);
    Console.WriteLine($"parallel union area={merged.AreaD:F2}");
}

Section("Processing – Merge mode SmallIsolated");
{
    var settings = DefaultShapes.Vector2D;
    List<Polygon<double, Vector2D>> polygons = new()
    {
        settings.CreateRectanglePolygon(new Vector2D(0,  0), new Vector2D(3, 3)),
        settings.CreateRectanglePolygon(new Vector2D(10, 0), new Vector2D(13, 3)),
    };

    MultiPolygon<double, Vector2D> merged = await polygons.ParallelUnionAll(mode: PolygonsMergeMode.SmallIsolated);
    Console.WriteLine($"SmallIsolated union polygons={merged.Count}, area={merged.AreaD:F2}");
}

Section("Processing – SubstractAllSplitted");
{
    var settings = DefaultShapes.Vector2D;
    var basePolys = new List<Polygon<double, Vector2D>>
    {
        settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(20, 20)),
    };
    var cutouts = new List<Polygon<double, Vector2D>>
    {
        settings.CreateRectanglePolygon(new Vector2D(5, 5), new Vector2D(10, 10)),
    };

    IReadOnlyCollection<Polygon<double, Vector2D>> result =
        basePolys.SubstractAllSplitted(cutouts, targetArea: 1_000_000);
    Console.WriteLine($"subtracted count={result.Count}, area={result.Sum(p => p.AreaD):F2}");
}

Section("Processing – FilterOverlaps");
{
    var settings = DefaultShapes.Vector2D;
    List<Polygon<double, Vector2D>> polygons = new()
    {
        settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10)),
        settings.CreateRectanglePolygon(new Vector2D(1, 1), new Vector2D(9,  9)),
        settings.CreateRectanglePolygon(new Vector2D(20, 0), new Vector2D(30, 10)),
    };

    List<Polygon<double, Vector2D>> filtered = polygons.FilterOverlaps();
    Console.WriteLine($"filtered count={filtered.Count}");
}

// -----------------------------------------------------------------------
// Pmad.Geometry.Json README examples
// -----------------------------------------------------------------------

Section("GeoJSON – Serialize a polygon");
{
    var settings = DefaultShapes.Vector2D;
    var polygon  = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));

    GeoJsonGeometry<double, Vector2D> geoJson = polygon.ToGeoJson();
    string json = JsonSerializer.Serialize(geoJson);
    Console.WriteLine($"json: {json}");
}

Section("GeoJSON – Deserialize a polygon");
{
    string json = """{"type":"Polygon","coordinates":[[[0,0],[0,10],[10,10],[10,0],[0,0]]]}""";

    var geoJson = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(json)!;

    Polygon<double, Vector2D>?      polygon = geoJson.Coordinates.AsPolygon();
    MultiPolygon<double, Vector2D>? multi   = geoJson.Coordinates.AsMultiPolygon();
    Path<double, Vector2D>?         path    = geoJson.Coordinates.AsLineString();

    Console.WriteLine($"deserialized polygon area={polygon?.AreaD:F2}, multi={multi != null}, path={path != null}");
}

Section("GeoJSON – Feature and FeatureCollection");
{
    var settings = DefaultShapes.Vector2D;
    var polygon  = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));

    var feature = new GeoJsonFeature<double, Vector2D>(
        geometry: polygon.ToGeoJson(),
        properties: null);

    var collection = new GeoJsonFeatureCollection<double, Vector2D>(feature);

    string collectionJson = JsonSerializer.Serialize(collection);
    Console.WriteLine($"collection json={collectionJson}");
}

Section("Coordinates helper");
{
    var coord = new Coordinates<double, Vector2D>(new Vector2D(2.35, 48.85)); // Paris
    var point = coord.AsPoint();
    double lon = point.X; // 2.35
    double lat = point.Y;  // 48.85
    Console.WriteLine($"lon={lon}, lat={lat}");
}

Console.WriteLine();
Console.WriteLine("All examples completed successfully.");

static void Section(string name)
{
    Console.WriteLine();
    Console.WriteLine($"=== {name} ===");
}
