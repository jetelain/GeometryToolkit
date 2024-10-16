﻿using System.Runtime.CompilerServices;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Algorithms
{
    public static class AlgorithmsDispatcher
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon<TVector>(this ReadOnlyArray<TVector> points, TVector pt)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return ((ReadOnlyArray<Vector2I>)(object)points).TestPointInPolygon((Vector2I)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return ((ReadOnlyArray<Vector2F>)(object)points).TestPointInPolygon((Vector2F)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return ((ReadOnlyArray<Vector2L>)(object)points).TestPointInPolygon((Vector2L)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return ((ReadOnlyArray<Vector2D>)(object)points).TestPointInPolygon((Vector2D)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return ((ReadOnlyArray<Vector2IS>)(object)points).TestPointInPolygon((Vector2IS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return ((ReadOnlyArray<Vector2FS>)(object)points).TestPointInPolygon((Vector2FS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return ((ReadOnlyArray<Vector2LS>)(object)points).TestPointInPolygon((Vector2LS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return ((ReadOnlyArray<Vector2DS>)(object)points).TestPointInPolygon((Vector2DS)(object)pt);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon<TVector>(this IReadOnlyList<TVector> points, TVector pt)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return ((IReadOnlyList<Vector2I>)(object)points).TestPointInPolygon((Vector2I)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return ((IReadOnlyList<Vector2F>)(object)points).TestPointInPolygon((Vector2F)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return ((IReadOnlyList<Vector2L>)(object)points).TestPointInPolygon((Vector2L)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return ((IReadOnlyList<Vector2D>)(object)points).TestPointInPolygon((Vector2D)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return ((IReadOnlyList<Vector2IS>)(object)points).TestPointInPolygon((Vector2IS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return ((IReadOnlyList<Vector2FS>)(object)points).TestPointInPolygon((Vector2FS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return ((IReadOnlyList<Vector2LS>)(object)points).TestPointInPolygon((Vector2LS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return ((IReadOnlyList<Vector2DS>)(object)points).TestPointInPolygon((Vector2DS)(object)pt);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon<TVector>(this List<TVector> points, TVector pt)
            where TVector : struct, IVector<TVector>
        {
            if (typeof(TVector) == typeof(Vector2I))
            {
                return ((List<Vector2I>)(object)points).TestPointInPolygon((Vector2I)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2F))
            {
                return ((List<Vector2F>)(object)points).TestPointInPolygon((Vector2F)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2L))
            {
                return ((List<Vector2L>)(object)points).TestPointInPolygon((Vector2L)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2D))
            {
                return ((List<Vector2D>)(object)points).TestPointInPolygon((Vector2D)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2IS))
            {
                return ((List<Vector2IS>)(object)points).TestPointInPolygon((Vector2IS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2FS))
            {
                return ((List<Vector2FS>)(object)points).TestPointInPolygon((Vector2FS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2LS))
            {
                return ((List<Vector2LS>)(object)points).TestPointInPolygon((Vector2LS)(object)pt);
            }
            if (typeof(TVector) == typeof(Vector2DS))
            {
                return ((List<Vector2DS>)(object)points).TestPointInPolygon((Vector2DS)(object)pt);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

	}
}
