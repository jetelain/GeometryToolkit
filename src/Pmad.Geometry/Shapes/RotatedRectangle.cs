using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public sealed class RotatedRectangle<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        private Lazy<VectorEnvelope<TVector>> bounds;

        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        public TVector Center { get; }

        public TVector Size { get; }

        public double Radians { get; }

        public double Degrees => Radians * 180 / Math.PI;

        public VectorEnvelope<TVector> Bounds => bounds.Value;

        public RotatedRectangle(TVector center, TVector size, double radians) 
            : this(ShapeSettings<TPrimitive, TVector>.Default, center, size, radians)
        {

        }

        public RotatedRectangle(ShapeSettings<TPrimitive, TVector> settings, TVector center, TVector size, double radians)
        {
            Settings = settings;
            Center = center;
            Size = size;
            Radians = radians;
            bounds = new Lazy<VectorEnvelope<TVector>>(() => VectorEnvelope<TVector>.FromList(GetPoints()));
        }

        public ReadOnlyArray<TVector> GetPoints()
        {
            var matrix = Matrix3x2<TPrimitive,TVector>.CreateRotation(Radians, Center);
            var halfSize = Size.Divide(2);
            var p1 = Center.Substract(halfSize);
            var p3 = Center.Add(halfSize);
            return new ReadOnlyArray<TVector>(
                matrix.Transform(p1),
                matrix.Transform(Vectors.Create<TPrimitive,TVector>(p3.X, p1.Y)),
                matrix.Transform(p3),
                matrix.Transform(Vectors.Create<TPrimitive,TVector>(p1.X, p3.Y))
            );
        }

        public Polygon<TPrimitive, TVector> ToPolygon()
        {
            var points = GetPoints();
            var shell = new ReadOnlyArrayBuilder<TVector>(5);
            shell.AddRange(points);
            shell.Add(points[0]);
            return new Polygon<TPrimitive, TVector>(Settings, shell.Build());
        }

        public static RotatedRectangle<TPrimitive, TVector> GetSmallestContaining_Virtual(ReadOnlyArray<TVector> points)
        {
            return GetSmallestContaining_Virtual(ShapeSettings<TPrimitive, TVector>.Default, points.AsSpan());
        }

        public static RotatedRectangle<TPrimitive, TVector> GetSmallestContaining_Virtual(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
        {
            return GetSmallestContaining_Virtual(settings, points.AsSpan());
        }

        private static RotatedRectangle<TPrimitive, TVector> GetSmallestContaining_Virtual(ShapeSettings<TPrimitive, TVector> settings, ReadOnlySpan<TVector> points)
        {
            TVector resultSize = default;
            TVector resultCenter = default;
            double resultAngle = 0;
            double resultArea = double.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = a.Substract(b).Atan2D();

                var rotate = Matrix2x2<TPrimitive, TVector>.CreateRotation(-theta);

                var max = rotate.Transform(points[0].Substract(a));
                var min = max;
                for (var j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j].Substract(a));
                    max = r.Max(max);
                    min = r.Min(min);
                }
                var size = max.Substract(min);
                var area = size.AreaD();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2<TPrimitive, TVector>.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = resultP3.Add(resultP1).Divide(2).Add(a);
                }
                a = b;
            }

            return new(settings, resultCenter, resultSize, resultAngle);
        }

        public static RotatedRectangle<TPrimitive, TVector> GetSmallestContaining(ReadOnlyArray<TVector> points)
        {
            return GetSmallestContaining_Dispatch(ShapeSettings<TPrimitive, TVector>.Default, points.AsSpan());
        }

        public static RotatedRectangle<TPrimitive, TVector> GetSmallestContaining(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
        {
            return GetSmallestContaining_Dispatch(settings, points.AsSpan());
        }

        private static RotatedRectangle<TPrimitive,TVector> GetSmallestContaining_Dispatch(ShapeSettings<TPrimitive,TVector> settings, ReadOnlySpan<TVector> points)
        {
            TVector resultSize = default;
            TVector resultCenter = default;
            double resultAngle = 0;
            double resultArea = double.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = Vectors.Substract(a, b).Atan2D();

                var rotate = Matrix2x2<TPrimitive, TVector>.CreateRotation(-theta);

                var max = rotate.Transform(Vectors.Substract(points[0], a));
                var min = max;
                for (var j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(Vectors.Substract(points[j], a));
                    max = Vectors.Max(r,max);
                    min = Vectors.Min(r,min);
                }
                var size = Vectors.Substract(max, min);
                var area = size.AreaD();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2<TPrimitive, TVector>.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = Vectors.Add(Vectors.Divide(Vectors.Add(resultP3, resultP1), 2), a);
                }
                a = b;
            }

            return new(settings, resultCenter, resultSize, resultAngle);
        }

        public static RotatedRectangle<TPrimitive, TVector>? GetLargestBetween(ReadOnlyArray<TVector> points)
        {
            return GetLargestBetween(ShapeSettings<TPrimitive, TVector>.Default, points);
        }

        public static RotatedRectangle<TPrimitive, TVector>? GetLargestBetween(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
        {
            var outerSegments = points.Zip(points.Skip(1).Concat(points.Take(1))).ToList();
            var allSegments = points.SelectMany(p1 => points.Where(p2 => !p2.Equals(p1)).Select(p2 => (P1: p1, P2: p2))).ToList();
            InnerCandidate? result = null;
            foreach (var segment in allSegments)
            {
                TVector? xp1;
                TVector? xp2;

                var candidate = Consider(outerSegments, segment.P1, segment.P2, out xp1, out xp2);

                if (candidate == null)
                {
                    if (xp1 != null)
                    {
                        for (var i = 99; i > 0 && candidate == null; i--)
                        {
                            var p2 = Vectors.Lerp<TPrimitive, TVector>(segment.P1, segment.P2, i / 100d);
                            candidate = Consider(outerSegments, segment.P1, p2, out _, out _);
                        }
                    }
                    else if (xp2 != null)
                    {
                        for (var i = 1; i < 100 && candidate == null; i++)
                        {
                            var p1 = Vectors.Lerp<TPrimitive, TVector>(segment.P1, segment.P2, i / 100d);
                            candidate = Consider(outerSegments, p1, segment.P2, out _, out _);
                        }
                    }
                }

                if (candidate != null && (result == null || candidate.Area > result.Area))
                {
                    result = candidate;
                }
            }
            return result?.ToRotatedRectangle(settings);
        }

        private static (TVector? Point, double Distance) ClosestSegmentIntersection(IEnumerable<(TVector First, TVector Second)> segments, TVector start, TVector end)
        {
            TVector? result = null;
            double resultFromStart = double.PositiveInfinity;
            foreach (var segment in segments)
            {
                TVector intersection;
                if (Vectors.HasSegmentIntersection(start, end, segment.First, segment.Second, out intersection))
                {
                    var intersectionFromStart = start.Substract(intersection).LengthD();
                    if (intersectionFromStart != 0 && (result == null || intersectionFromStart < resultFromStart))
                    {
                        result = intersection;
                        resultFromStart = intersectionFromStart;
                    }
                }
            }
            return (result, resultFromStart);
        }

        private sealed class InnerCandidate
        {
            private readonly TVector ab;
            private readonly TVector size;
            private readonly TVector center;

            public InnerCandidate(TVector a, TVector b, TVector c)
            {
                ab = b.Substract(a);
                var ac = c.Substract(a);
                size = Vectors.Create<TPrimitive, TVector>(ab.Length(), ac.Length());
                center = a.Add(ab.Add(ac).Divide(2));
                Area = size.AreaD();
            }

            private double Radians => ab.Negate().Atan2D();

            public double Area { get; }

            internal RotatedRectangle<TPrimitive, TVector> ToRotatedRectangle(ShapeSettings<TPrimitive, TVector> settings)
            {
                return new RotatedRectangle<TPrimitive, TVector>(settings, center, size, Radians);
            }
        }

        private static (TVector? Point, double Distance) ClosestLineIntersection(IEnumerable<(TVector First, TVector Second)> segments, TVector start, TVector end)
        {
            TVector? result = null;
            double resultFromStart = double.PositiveInfinity;
            foreach (var segment in segments)
            {
                TVector intersection;
                if (Vectors.HasLineIntersection(start, end, segment.First, segment.Second, out intersection))
                {
                    var intersectionFromStart = start.Substract(intersection).LengthD();
                    if (intersectionFromStart != 0 && (result == null || intersectionFromStart < resultFromStart))
                    {
                        result = intersection;
                        resultFromStart = intersectionFromStart;
                    }
                }
            }
            return (result, resultFromStart);
        }

        private static InnerCandidate? Consider(List<(TVector First, TVector Second)> outerSegments, TVector p1, TVector p2, out TVector? xp1, out TVector? xp2)
        {
            var delta = p2.Substract(p1).Normalize().Rotate90().Multiply(1000);
            var x1 = ClosestSegmentIntersection(outerSegments, p1, p1.Add(delta));
            var x2 = ClosestSegmentIntersection(outerSegments, p2, p2.Add(delta));
            xp1 = x1.Point;
            xp2 = x2.Point;
            if (x1.Point != null && x2.Point != null)
            {
                return (x1.Distance <= x2.Distance) ?
                    new InnerCandidate(p1, p2, x1.Point.Value) :
                    new InnerCandidate(p2, p1, x2.Point.Value);
            }
            return null;
        }
    }
}
