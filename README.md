# GeometryToolkit
Geometry shapes and primitives toolkit

This project aim to provide highly optimized versions of 2D geometry arithmetic primitives used by [GameRealisticMap](https://github.com/jetelain/ArmaRealMap) and [MapToolkit](https://github.com/jetelain/mapkit).

Those primitives are performance critical for the two related projects (data processing requires usually many hours, even little improvements can save a lot of time).

Current toolkit is an experimentation around Vector128, Vector2 and plain scalar implementations. It makes heavy use of generics and text templating to test multiple implementations of 2D vectors and shapes. It's intend to measure their relative performances on modern hardware.

It includes a fork of [Clipper2](https://github.com/AngusJohnson/Clipper2) from Angus Johnson.

## Experimental implementations

| Vector	| Polygon    | Description               |  
| --------- | ---------- | ------------------------- |           
| Vector2I  | Polygon2I  | `Vector128` with `double` |           
| Vector2F  | Polygon2F  | `Vector128` with `float`  |           
| Vector2L  | Polygon2L  | `Vector128` with `long`   |           
| Vector2D  | Polygon2D  | `Vector128` with `double` |           
| Vector2IS | Polygon2IS | Two scalar `int`		     |           
| Vector2FS | Polygon2FS | Two scalar `float`		 |           
| Vector2LS | Polygon2LS | Two scalar `long`		 |           
| Vector2DS | Polygon2DS | Two scalar `double`		 |
| Vector2FN | Polygon2FN | `Vector2` wrapper 		 |