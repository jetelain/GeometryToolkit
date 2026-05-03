# Pmad.Geometry.Json

[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry.Json?logo=nuget)](https://www.nuget.org/packages/Pmad.Geometry.Json/)
[![LICENSE BSL 1.0](https://img.shields.io/badge/License-BSL_1.0-yellow.svg)](https://www.boost.org/LICENSE_1_0.txt) 


GeoJSON serialization / deserialization for [Pmad.Geometry](../Pmad.Geometry/README.md) shapes, built on top of `System.Text.Json`.

## Installation

```
dotnet add package Pmad.Geometry.Json
```

## GeoJSON

### Serialize a shape to GeoJSON

Any `Polygon`, `MultiPolygon`, `Path`, or `MultiPath` can be converted to a `GeoJsonGeometry` wrapper and then serialized with `System.Text.Json`.

```csharp
using Pmad.Geometry;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Json;
using System.Text.Json;

var settings = DefaultShapes.Vector2D;
var polygon  = settings.CreateRectanglePolygon(new Vector2D(0, 0), new Vector2D(10, 10));

// Wrap and serialize
GeoJsonGeometry<double, Vector2D> geoJson = polygon.ToGeoJson();
string json = JsonSerializer.Serialize(geoJson);
// {"type":"Polygon","coordinates":[[[0,0],[0,10],[10,10],[10,0],[0,0]]]}
```

### Deserialize a GeoJSON geometry

```csharp
string json = """{"type":"Polygon","coordinates":[[[0,0],[0,10],[10,10],[10,0],[0,0]]]}""";

var geoJson = JsonSerializer.Deserialize<GeoJsonGeometry<double, Vector2D>>(json)!;

Polygon<double, Vector2D>?      polygon = geoJson.Polygon;
MultiPolygon<double, Vector2D>? multi   = geoJson.MultiPolygon;
Path<double, Vector2D>?         path    = geoJson.Path;
```

### GeoJSON Feature and FeatureCollection

```csharp
var feature = new GeoJsonFeature<double, Vector2D>
{
    Geometry   = polygon.ToGeoJson(),
    Properties = JsonSerializer.SerializeToElement(new { name = "area51" })
};

var collection = new GeoJsonFeatureCollection<double, Vector2D>
{
    Features = { feature }
};

string collectionJson = JsonSerializer.Serialize(collection);
```

### Deserializing unknown geometry types

Use `GeoJsonGeometry` (non-generic) when the geometry type is not known at compile-time:

```csharp
var unknown = JsonSerializer.Deserialize<GeoJsonUnknown>(json);
Console.WriteLine(unknown?.Type); // "Polygon"
```

## Coordinates helper

`Coordinates` maps Pmad.Geometry vectors to GeoJSON `[longitude, latitude]` arrays and back:

```csharp
var coord = new Coordinates<double, Vector2D>(new Vector2D(2.35, 48.85)); // Paris
double lon = coord.Longitude; // 2.35
double lat = coord.Latitude;  // 48.85
```

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.
