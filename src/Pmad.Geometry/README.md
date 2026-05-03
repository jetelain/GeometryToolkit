# Pmad.Geometry

[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry?logo=nuget)](https://www.nuget.org/packages/Pmad.Geometry/)
[![LICENSE BSL 1.0](https://img.shields.io/badge/License-BSL_1.0-yellow.svg)](https://www.boost.org/LICENSE_1_0.txt) 

Core 2D geometry primitives for .NET 8+: vectors, polygons, paths, circles, and rotated rectangles — all generic over the numeric type.

## Installation

```
dotnet add package Pmad.Geometry
```

## Choosing a vector type

All shapes are generic over `(TPrimitive, TVector)`. Use the type that fits your coordinate system:

| Type       | Primitive | Best for |
| ---------- | --------- | -------- |
| `Vector2I` | `int`     | Integer grid coordinates |
| `Vector2F` | `float`   | Single-precision coordinates |
| `Vector2L` | `long`    | Large integer coordinates (e.g. fixed-point) |
| `Vector2D` | `double`  | Double-precision coordinates |

## ShapeSettings

`ShapeSettings<TPrimitive, TVector>` controls the coordinate scale used internally by Clipper2 for boolean operations.
The default settings are suited for metric coordinates with millimetre precision.
Use `DefaultShapes.Vector2D` (and similar) for a concise reference to the default settings of each type.

```csharp
// Use the default settings for double-precision coordinates
var settings = DefaultShapes.Vector2D;
// Or use the default directly
var settings2 = ShapeSettings<double, Vector2D>.Default;
```

## 2D Vectors

Vectors support standard arithmetic operators (`+`, `-`, `*`, `/`), comparison, and geometric helpers.

```csharp
var a = new Vector2D(1.0, 2.0);
var b = new Vector2D(4.0, 6.0);

Vector2D sum   = a + b;            // (5, 8)
double   len   = a.LengthD();      // √5
double   dot   = Vector2D.DotD(a, b);
double   cross = Vector2D.CrossProductD(a, b);

// Line / segment intersection
bool hit = Vectors.HasSegmentIntersection(a, b, new Vector2D(0,3), new Vector2D(5,3), out var pt);

// Angle between two vectors (radians, -π … π)
double angle = Vectors.AngleRadians(a, b);
```

### Matrix transforms

```csharp
var rotation = Matrix3x2<double, Vector2D>.CreateRotationD(Math.PI / 4, Vector2D.Zero);
var rotated  = rotation.Transform(new Vector2D(1.0, 0.0));
```

## VectorEnvelope (Bounding Box)

```csharp
var envelope = VectorEnvelope<Vector2D>.FromPoints(new Vector2D(0, 0), new Vector2D(10, 10));
bool inside  = envelope.Contains(new Vector2D(5, 5)); // true
```

## Polygon

A polygon has a `Shell` (outer ring) and optional `Holes`.

```csharp
var settings = DefaultShapes.Vector2D;

// Rectangle polygon
var rect = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));

// Circular approximation polygon (12-sided by default)
var circle = settings.CreateCirclePolygon(new Vector2D(5, 5), radius: 5.0);

// Point-in-polygon test
bool inside = rect.IsInside(new Vector2D(3, 3));             // true
bool onEdge = rect.IsInsideOrOnBoundary(new Vector2D(0, 5)); // true

// Properties
double area     = rect.AreaD;
Vector2D center = rect.Centroid;

// Offsetting (expands or shrinks the polygon)
MultiPolygon<double, Vector2D> bigger  = rect.Offset(2.0);
MultiPolygon<double, Vector2D> smaller = rect.Offset(-1.0);

// Crown (ring between two offsets)
MultiPolygon<double, Vector2D> crown      = rect.Crown(innnerOffset: 1.0, outerOffset: 2.0);
MultiPolygon<double, Vector2D> outerCrown = rect.OuterCrown(2.0);
MultiPolygon<double, Vector2D> innerCrown = rect.InnerCrown(1.0);

// Boolean operations with another polygon
var other = settings.CreateRectanglePolygon(new Vector2D(5, 5), new Vector2D(15, 15));
MultiPolygon<double, Vector2D> union        = rect.Union(other);
MultiPolygon<double, Vector2D> intersection = rect.Intersection(other);
MultiPolygon<double, Vector2D> difference   = rect.Substract(other);

// Distance from a point to the polygon boundary
double dist = rect.Distance(new Vector2D(20, 5));
```

### Polygon with holes

```csharp
var shell = new ReadOnlyArray<Vector2D>(
    new Vector2D(0,0), new Vector2D(0,10),
    new Vector2D(10,10), new Vector2D(10,0), new Vector2D(0,0));

var hole = new ReadOnlyArray<Vector2D>(
    new Vector2D(3,3), new Vector2D(3,7),
    new Vector2D(7,7), new Vector2D(7,3), new Vector2D(3,3));

var poly = new Polygon<double, Vector2D>(settings, shell,
    new ReadOnlyArray<ReadOnlyArray<Vector2D>>(hole));
```

### WKT serialization

```csharp
string wkt     = rect.ToString();
var    fromWkt = settings.ParsePolygon(wkt);
```

### SVG path

```csharp
string svgPath = rect.ToSvgPath();
```

## MultiPolygon

A `MultiPolygon` is an ordered list of non-overlapping `Polygon` instances. Boolean operations on a `Polygon` return a `MultiPolygon`.

```csharp
MultiPolygon<double, Vector2D> mp = rect.Union(other);

foreach (Polygon<double, Vector2D> p in mp)
{
    Console.WriteLine($"Area = {p.AreaD}");
}

double totalArea  = mp.AreaD;
bool   containsPt = mp.Contains(new Vector2D(3, 3));
```

## Path

A `Path` is an ordered sequence of points. It can be open or closed.

```csharp
var path = new Path<double, Vector2D>(
    new Vector2D(0, 0),
    new Vector2D(5, 5),
    new Vector2D(10, 0));

double length   = path.LengthD;
bool   isClosed = path.IsClosed;

// Buffer a path into a polygon (width = total width, not half-width)
MultiPolygon<double, Vector2D> buffered = path.ToPolygon(width: 2.0);

// Crop path to a bounding box
var cropBox = new VectorEnvelope<Vector2D>(new Vector2D(0,0), new Vector2D(6,6));
IEnumerable<Path<double, Vector2D>> cropped = path.Crop(cropBox);

// Treat the path itself as a polygon shell
Polygon<double, Vector2D> polyShell = path.ToPolygonAsShell();
```

## RotatedRectangle

```csharp
var rr = new RotatedRectangle<double, Vector2D>(
    center:  new Vector2D(5, 5),
    size:    new Vector2D(8, 4),
    radians: Math.PI / 6);   // 30°

double area    = rr.AreaD;
double degrees = rr.Degrees;
Polygon<double, Vector2D> poly = rr.ToPolygon();

// Smallest rotated rectangle containing a set of points
var points = new List<Vector2D> { new(0,0), new(3,1), new(2,4) };
RotatedRectangle<double, Vector2D> smallest = RotatedRectangle<double, Vector2D>.GetSmallestContaining(points);
```

## Circle

```csharp
var c = new Circle<double, Vector2D>(center: new Vector2D(5, 5), radius: 3.0);

bool   inside = c.IsInside(new Vector2D(6, 6));
double area   = c.AreaD;

// Smallest enclosing circle for a set of points
var points = new List<Vector2D> { new(0,0), new(4,0), new(2,3) };
Circle<double, Vector2D> enclosing = Circle<double, Vector2D>.GetSmallestContaining(points);

// Convert to polygon approximation
Polygon<double, Vector2D> poly = c.ToPolygon(count: 32);
```

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.  
Copyright Angus Johnson 2010-2024 (Clipper2).
