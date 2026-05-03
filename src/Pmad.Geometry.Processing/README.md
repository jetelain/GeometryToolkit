# Pmad.Geometry.Processing

[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry.Processing?logo=nuget)](https://www.nuget.org/packages/Pmad.Geometry.Processing/) 
[![LICENSE BSL 1.0](https://img.shields.io/badge/License-BSL_1.0-yellow.svg)](https://www.boost.org/LICENSE_1_0.txt) 

Bulk polygon operations for [Pmad.Geometry](../Pmad.Geometry/README.md) with optional progress reporting via [Pmad.ProgressTracking](https://www.nuget.org/packages/Pmad.ProgressTracking/).

Provides efficient union, subtraction, and overlap-filtering for large collections of polygons, including a parallel implementation backed by a quad-tree spatial index.

## Installation

```
dotnet add package Pmad.Geometry.Processing
```

## Union of a polygon list

### Sequential union

```csharp
using Pmad.Geometry;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Processing;

List<Polygon<double, Vector2D>> polygons = GetPolygons();

// Merge all polygons into a single MultiPolygon
MultiPolygon<double, Vector2D> merged = polygons.UnionAll();
```

### Parallel union (recommended for large datasets)

The parallel variant partitions the space into a quad-tree and processes each cell concurrently.

```csharp
// idealPartition: target number of polygons per quad-tree cell (default 100)
MultiPolygon<double, Vector2D> merged =
    await polygons.ParallelUnionAll(idealPartition: 100);
```

### Union with progress reporting

```csharp
using Pmad.ProgressTracking;

IProgressScope scope = ...; // your progress scope

MultiPolygon<double, Vector2D> merged =
    await polygons.ParallelUnionAll(scope, stepName: "Merging polygons");
```

### Merge modes

The `PolygonsMergeMode` enum controls the merging strategy:

| Value           | Description |
| --------------- | ----------- |
| `LargeConnected` | Polygons tend to form large connected areas (e.g. forests). **Default.** |
| `SmallIsolated`  | Polygons remain small and isolated (e.g. buildings). |

```csharp
MultiPolygon<double, Vector2D> merged =
    await polygons.ParallelUnionAll(mode: PolygonsMergeMode.SmallIsolated);
```

## Subtract from a polygon list

`SubstractAllSplitted` removes a set of polygons from each polygon in the input list.
The input is split to keep individual polygons below `targetArea` (avoids very large intermediate geometries).

```csharp
List<Polygon<double, Vector2D>>          base    = GetBasePolygons();
IReadOnlyCollection<Polygon<double, Vector2D>> cutouts = GetCutouts();

IReadOnlyCollection<Polygon<double, Vector2D>> result =
    base.SubstractAllSplitted(cutouts, targetArea: 1_000_000);
```

## Filter overlapping polygons

Remove duplicates / overlapping polygons from a list, keeping the largest non-overlapping set:

```csharp
List<Polygon<double, Vector2D>> filtered = polygons.FilterOverlaps();
```

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.
