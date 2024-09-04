﻿# Pmad.Geometry
Geometry shapes and primitives toolkit

This project aim to provide highly optimized versions of 2D geometry arithmetic primitives used by [GameRealisticMap](https://github.com/jetelain/ArmaRealMap) and [MapToolkit](https://github.com/jetelain/mapkit).

Those primitives are performance critical for the two related projects (data processing requires usually many hours, even little improvements can save a lot of time).

Current toolkit is an experimentation around Vector128, Vector2 and plain scalar implementations. It makes heavy use of generics and text templating to test multiple implementations of 2D vectors and shapes. It's intend to measure their relative performances on modern hardware.

It includes a fork of [Clipper2](https://github.com/AngusJohnson/Clipper2) from Angus Johnson.

## Implementations

| Vector	| Description               | Note
| --------- | ------------------------- | ------------------------- |
| Vector2I  | Two scalar `int`          | Some operations are optimised with `Vector128` |
| Vector2F  | `Vector2` wrapper         |                                  |
| Vector2L  | `Vector128` with `long`   |                                  |
| Vector2D  | `Vector128` with `double` |                                  |

## Performance

(Lower is better, 1 us : 1 Microsecond (0.000001 sec), 1 ns   : 1 Nanosecond (0.000000001 sec))

Intel Core i7-14700KF, 1 CPU, with .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

### Polygon operations

| Implementation            |Union    |Intersection|Point in Polygon|Signed Area|
| -----------------------   |--------:|-----------:|---------------:|---------:|
| NetTopologySuite (double) | 40.1 us | 38.1 us	   | 260.0 us	    | 61.4 ns	|
| Original GRM (float)      | 12.3 us | 9.4 us	   | 5.4 us		    |			|
| Original Clipper2 (long)  |         |			   | 2.5 us		    | 36.2 ns	|
| Original Clipper2 (double)|         |			   |       		    |       	|
| Pmad.Geometry Vector2I    | 7.6 us  | 6.8 us	   | 2.0 us		    |	31.1 ns	|
| Pmad.Geometry Vector2F    | 7.9 us  | 6.9 us	   | 2.1 us		    |	29.0 ns	|
| Pmad.Geometry Vector2L    | 7.8 us  | 6.8 us	   | 2.1 us		    | 25.6 ns	|
| Pmad.Geometry Vector2D    | 7.9 us  | 6.7 us	   | 2.7 us		    | 18.5 ns	|

## Features

2 dimensions vectors arithmetic with long, int, float and double support.

Matrix transforms on 2 dimensions vectors.

2 dimensions polygon arithmetic.


## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.
Copyright Angus Johnson 2010-2024.
