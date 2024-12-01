using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// Coordinate space settings.
    /// </summary>
    /// <typeparam name="TPrimitive"></typeparam>
    /// <typeparam name="TVector"></typeparam>
    public sealed class ShapeSettings<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        /// <summary>
        /// Default settings. Suited for metric coordinates with milimeter precision.
        /// </summary>
        public static readonly ShapeSettings<TPrimitive, TVector> Default = new ShapeSettings<TPrimitive, TVector>();

        private readonly TVector scale;

        public ShapeSettings()
            : this(GetDefaultScale(), 3)
        {

        }

        public ShapeSettings(int scaleForClipper, int negligibleClipperDistance) 
        {
            if (typeof(TPrimitive) == typeof(long) || typeof(TPrimitive) == typeof(int))
            {
                if (scaleForClipper != 1)
                {
                    ThrowHelper.ThrowNotSupportedException();
                }
            }
            scale = TVector.Create(TPrimitive.CreateChecked(scaleForClipper), TPrimitive.CreateChecked(scaleForClipper));
            ScaleForClipper = scaleForClipper;

            NegligibleClipperArea = (long)(negligibleClipperDistance * negligibleClipperDistance);
            NegligibleDistance = (double)negligibleClipperDistance / scaleForClipper;
            NegligibleArea = NegligibleDistance * NegligibleDistance;
        }

        /// <summary>
        /// Scale used for Clipper2 operations
        /// </summary>
        public int ScaleForClipper { get; }

        /// <summary>
        /// Polygons with area below this value (in vector units) are considered negligible, and will be filtered out.
        /// 
        /// This is intend to avoid rounding error artefacs.
        /// </summary>
        public double NegligibleArea { get; }

        /// <summary>
        /// Points that distance is below this value (in vector units) are considered the same.
        /// </summary>
        public double NegligibleDistance { get; }

        public double NegligibleDistanceSquared => NegligibleArea;

        /// <summary>
        /// Polygons with area below this value (in clipper units) are considered negligible, and will be filtered out.
        /// 
        /// This is intend to avoid rounding error artefacs.
        /// </summary>
        public long NegligibleClipperArea { get; }

        private static int GetDefaultScale()
        {
            if (typeof(TPrimitive) == typeof(long) || typeof(TPrimitive) == typeof(int))
            {
                return 1;
            }
            return 1000;
        }

        internal MultiPolygon<TPrimitive, TVector> ToMultiPolygon(PolyPath64 polyTree64)
        {
            var result = new List<Polygon<TPrimitive, TVector>>();
            FromClipper(result, polyTree64);
            return new MultiPolygon<TPrimitive,TVector>(result);
        }

        internal List<Polygon<TPrimitive, TVector>> ToPolygonList(PolyPath64 polyTree64)
        {
            var result = new List<Polygon<TPrimitive, TVector>>();
            FromClipper(result, polyTree64);
            return result;
        }

        private void FromClipper(List<Polygon<TPrimitive, TVector>> result, PolyPath64 polyTree64)
        {
            foreach (PolyPath64 node in polyTree64)
            {
                if (Math.Abs(Clipper.Area(node.Polygon!)) < NegligibleClipperArea)
                {
                    continue;
                }
                var shell = FromClipperToRing(node.Polygon!);
                var holes = new ReadOnlyArray<TVector>[node.Count];
                for (int i = 0; i < node.Count; ++i)
                {
                    holes[i] = FromClipperToRing(node[i].Polygon!);
                }
                result.Add(new Polygon<TPrimitive, TVector>(this, shell, new (holes)));
                foreach (var subchild in node.Cast<PolyPath64>())
                {
                    FromClipper(result, subchild);
                }
            }
        }

        internal ReadOnlyArray<TVector> FromClipperToRing(List<Point64> points)
        {
            var count = points.Count;
            var result = new TVector[count + 1];
            var source = CollectionsMarshal.AsSpan(points);
            var target = new Span<TVector>(result);
            for (int i = 0; i < count; i++)
            {
                target[i] = FromClipper(source[i]);
            }
            target[count] = target[0];
            return new ReadOnlyArray<TVector>(result);
        }

        internal Path64 ToClipper(ReadOnlyArray<TVector> shell)
        {
            return ToClipper(shell.AsSpan());
        }

        internal Path64 ToClipper(ReadOnlySpan<TVector> source)
        {
            var count = source.Length;
            var result = new Path64(count);
            CollectionsMarshal.SetCount(result, count);
            var target = CollectionsMarshal.AsSpan(result);
            for (int i = 0; i < count; i++)
            {
                target[i] = ToClipper(source[i]);
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Point64 ToClipper(TVector value)
        {
            if (typeof(TPrimitive) == typeof(long))
            {
                return new((long)(object)value.X, (long)(object)value.Y);
            }
            if (typeof(TPrimitive) == typeof(int))
            {
                return new((int)(object)value.X, (int)(object)value.Y);
            }
            var scaled = value * scale;
            if (typeof(TPrimitive) == typeof(double))
            {
                return new((double)(object)scaled.X, (double)(object)scaled.Y);
            }
            if (typeof(TPrimitive) == typeof(float))
            {
                return new((float)(object)scaled.X, (float)(object)scaled.Y);
            }
            ThrowHelper.ThrowNotSupportedException();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TVector FromClipper(Point64 value)
        {
            if (typeof(TPrimitive) == typeof(long))
            {
                return TVector.Create(value.X, value.Y);
            }
            if (typeof(TPrimitive) == typeof(int))
            {
                return TVector.Create(value.X, value.Y);
            }
            return TVector.Create(value.X, value.Y) / scale;
        }

        internal Rect64 ToClipper(VectorEnvelope<TVector> rect)
        {
            var min = ToClipper(rect.Min);
            var max = ToClipper(rect.Max);
            return new Rect64(min.X, min.Y, max.X, max.Y);
        }

        internal ReadOnlyArray<TVector> FromClipper(Path64 points)
        {
            var count = points.Count;
            var result = new TVector[count];
            var source = CollectionsMarshal.AsSpan(points);
            var target = new Span<TVector>(result);
            for (int i = 0; i < count; i++)
            {
                target[i] = FromClipper(source[i]);
            }
            return new ReadOnlyArray<TVector>(result);
        }

        public bool AlmostEquals(TVector a, TVector b)
        {
            return (a - b).LengthSquaredD() < NegligibleDistanceSquared;
        }
    }
}
