# GeometryToolkit
Geometry shapes and primitives toolkit

This project aim to provide highly optimized versions of 2D geometry arithmetic primitives used by [GameRealisticMap](https://github.com/jetelain/ArmaRealMap) and [MapToolkit](https://github.com/jetelain/mapkit).

Those primitives are performance critical for the two related projects (data processing requires usually many hours, even little improvements can save a lot of time).

Current toolkit is an experimentation around Vector128, Vector2 and plain scalar implementations. It makes heavy use of generics and text templating to test multiple implementations of 2D vectors and shapes. It's intend to measure their relative performances on modern hardware.

It includes a fork of [Clipper2](https://github.com/AngusJohnson/Clipper2) from Angus Johnson.

## Experimental implementations

| Vector	| Description               |
| --------- | ------------------------- |
| Vector2I  | Two scalar `int` (some operations are optimised with `Vector128`) |
| Vector2F  | `Vector2` wrapper         |
| Vector2L  | `Vector128` with `long`   |
| Vector2D  | `Vector128` with `double` |
| Vector2IS | Two scalar `int`		    |
| Vector2FS | Two scalar `float`		|
| Vector2LS | Two scalar `long`		    |
| Vector2DS | Two scalar `double`	    |

## License

Licensed under [Boost Software License - Version 1.0](https://www.boost.org/LICENSE_1_0.txt) terms.

Copyright Julien Etelain 2024.
Copyright Angus Johnson 2010-2024.
