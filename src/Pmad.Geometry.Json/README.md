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

Polygon<double, Vector2D>?      polygon = geoJson.Coordinates.AsPolygon();
MultiPolygon<double, Vector2D>? multi   = geoJson.Coordinates.AsMultiPolygon();
Path<double, Vector2D>?         path    = geoJson.Coordinates.AsLineString();
```

### GeoJSON Feature and FeatureCollection

```csharp
var feature = new GeoJsonFeature<double, Vector2D>(
    geometry:   polygon.ToGeoJson(),
    properties: null);

var collection = new GeoJsonFeatureCollection<double, Vector2D>(feature);

string collectionJson = JsonSerializer.Serialize(collection);
```

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.
