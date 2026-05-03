# Pmad.Geometry

[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry?logo=nuget)](https://www.nuget.org/packages/Pmad.Geometry/)
[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry.Json?logo=nuget&label=Pmad.Geometry.Json)](https://www.nuget.org/packages/Pmad.Geometry.Json/)
[![NuGet](https://img.shields.io/nuget/v/Pmad.Geometry.Processing?logo=nuget&label=Pmad.Geometry.Processing)](https://www.nuget.org/packages/Pmad.Geometry.Processing/)
[![LICENSE BSL 1.0](https://img.shields.io/badge/License-BSL_1.0-yellow.svg)](https://www.boost.org/LICENSE_1_0.txt) 

Geometry shapes and primitives toolkit (2D) for .NET 8+.

This project provides optimized 2D geometry arithmetic primitives used by [GameRealisticMap](https://github.com/jetelain/ArmaRealMap) and [Pmad.Cartography](https://github.com/jetelain/mapkit).

> **API might change in future releases.**

It includes a fork of [Clipper2](https://github.com/AngusJohnson/Clipper2) from Angus Johnson.

## Packages

| Package | Description |
| ------- | ----------- |
| [Pmad.Geometry](src/Pmad.Geometry/README.md) | Core 2D vectors, polygons, paths and shapes |
| [Pmad.Geometry.Json](src/Pmad.Geometry.Json/README.md) | GeoJSON serialization/deserialization |
| [Pmad.Geometry.Processing](src/Pmad.Geometry.Processing/README.md) | Bulk polygon operations with progress tracking |

## Vector implementations

| Vector   | Description               | Note |
| -------- | ------------------------- | ---- |
| `Vector2I` | Two scalar `int`        | Some operations optimised with `Vector128` |
| `Vector2F` | `Vector2` wrapper       | |
| `Vector2L` | `Vector128` with `long` | |
| `Vector2D` | `Vector128` with `double` | |

## Performance

(Lower is better — 1 µs = 1 microsecond, 1 ns = 1 nanosecond)

Intel Core i7-14700KF, 1 CPU, .NET 8.0.8, X64 RyuJIT AVX2

| Implementation            | Union   | Intersection | Point in Polygon | Signed Area |
| ------------------------- | ------: | -----------: | ---------------: | ----------: |
| NetTopologySuite (double) | 40.1 µs | 38.1 µs      | 260.0 µs         | 61.4 ns     |
| Original GRM (float)      | 12.3 µs | 9.4 µs       | 5.4 µs           |             |
| Original Clipper2 (long)  |         |              | 2.5 µs           | 36.2 ns     |
| Pmad.Geometry Vector2I    | 7.6 µs  | 6.8 µs       | 2.0 µs           | 31.1 ns     |
| Pmad.Geometry Vector2F    | 7.9 µs  | 6.9 µs       | 2.1 µs           | 29.0 ns     |
| Pmad.Geometry Vector2L    | 7.8 µs  | 6.8 µs       | 2.1 µs           | 25.6 ns     |
| Pmad.Geometry Vector2D    | 7.9 µs  | 6.7 µs       | 2.7 µs           | 18.5 ns     |

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.  
Copyright Angus Johnson 2010-2024.
