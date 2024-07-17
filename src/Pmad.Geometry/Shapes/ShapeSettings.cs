using System.Numerics;
using Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public sealed class ShapeSettings<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public static readonly ShapeSettings<TPrimitive, TVector> Default = new ShapeSettings<TPrimitive, TVector>();

        private readonly TVector scale;

        public ShapeSettings()
            : this(GetDefaultScale())
        {

        }

        public ShapeSettings(int scaleForClipper) 
        {
            if (typeof(TPrimitive) == typeof(long) || typeof(TPrimitive) == typeof(int))
            {
                if (scaleForClipper != 1)
                {
                    ThrowHelper.ThrowNotSupportedException();
                }
            }
            scale = Vectors.Create<TPrimitive,TVector>(scaleForClipper, scaleForClipper);
            ScaleForClipper = scaleForClipper;
        }

        public int ScaleForClipper { get; }

        private static int GetDefaultScale()
        {
            if (typeof(TPrimitive) == typeof(long) || typeof(TPrimitive) == typeof(int))
            {
                return 1;
            }
            return 1000;
        }

        internal IEnumerable<Polygon<TPrimitive, TVector>> FromClipper(PolyPath64 polyTree64)
        {
            var result = new List<Polygon<TPrimitive, TVector>>();
            FromClipper(result, polyTree64);
            return result;
        }

        private void FromClipper(List<Polygon<TPrimitive, TVector>> result, PolyPath64 polyTree64)
        {
            foreach (PolyPath64 node in polyTree64)
            {
                var shell = FromClipperToRing(node.Polygon!);
                var holes = new ReadOnlyArray<TVector>[node.Count];
                for (int i = 0; i < node.Count; ++i)
                {
                    holes[i] = FromClipperToRing(node[i].Polygon!);
                }
                result.Add(new Polygon<TPrimitive, TVector>(this, shell, new (holes)));
                foreach (var subchild in node.Cast<PolyPath64>().SelectMany(h => h.Cast<PolyPath64>()))
                {
                    FromClipper(result, subchild);
                }
            }
        }

        internal ReadOnlyArray<TVector> FromClipperToRing(List<Point64> points)
        {
            var ring = new TVector[points.Count + 1];
            for (int i = 0; i < points.Count; i++)
            {
                ring[i] = FromClipper(points[i]);
            }
            ring[points.Count] = FromClipper(points[0]);
            return new ReadOnlyArray<TVector>(ring);
        }

        internal Path64 ToClipper(ReadOnlyArray<TVector> shell)
        {
            var path = new Path64(shell.Count);
            path.AddRange(shell.Select(ToClipper));
            return path;
        }

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

        public TVector FromClipper(Point64 value)
        {
            if (typeof(TPrimitive) == typeof(long))
            {
                return Vectors.Create<TPrimitive, TVector>(value.X, value.Y);
            }
            if (typeof(TPrimitive) == typeof(int))
            {
                return Vectors.Create<TPrimitive, TVector>(value.X, value.Y);
            }
            return Vectors.Create<TPrimitive,TVector>(value.X, value.Y) / scale;
        }

        public Polygon<TPrimitive, TVector> CreateRectangle(VectorEnvelope<TVector> envelope)
        {
            return CreateRectangle(envelope.Min, envelope.Max);
        }

        public Polygon<TPrimitive, TVector> CreateRectangle(TVector p1, TVector p2)
        {
            return new Polygon<TPrimitive, TVector>(this, new ReadOnlyArray<TVector>(
                p1,
                TVector.Create(p1.X, p2.X),
                p2,
                TVector.Create(p2.X, p1.X),
                p1
            ));
        }

        public Polygon<TPrimitive, TVector> CreatePolygon(ReadOnlyArray<TVector> shell, ReadOnlyArray<ReadOnlyArray<TVector>> holes)
        {
            return new Polygon<TPrimitive, TVector>(this, shell, holes);
        }

        public Polygon<TPrimitive, TVector> CreatePolygon(ReadOnlyArray<TVector> shell)
        {
            return new Polygon<TPrimitive, TVector>(this, shell);
        }

        public Path<TPrimitive, TVector> CreatePath(ReadOnlyArray<TVector> points)
        {
            return new Path<TPrimitive, TVector>(this, points);
        }

        internal Rect64 ToClipper(VectorEnvelope<TVector> rect)
        {
            var min = ToClipper(rect.Min);
            var max = ToClipper(rect.Max);
            return new Rect64(min.X, min.Y, max.X, max.Y);
        }

        internal ReadOnlyArray<TVector> FromClipper(Path64 points)
        {
            var path = new TVector[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                path[i] = FromClipper(points[i]);
            }
            return new ReadOnlyArray<TVector>(path);
        }
    }
}
