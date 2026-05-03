using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// A contiguous segment of a <see cref="Path{TPrimitive,TVector}"/>, split at angle thresholds.
    /// </summary>
    /// <typeparam name="TPrimitive">Numeric primitive type of the vector components.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public class PathSegment<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public PathSegment(ReadOnlyArray<TVector> points, double angleWithNext = double.NaN)
        {
            Points = points;
            DegreesWithNext = Math.Round(angleWithNext, 4);
        }

        /// <summary>Ordered points forming this segment.</summary>
        public ReadOnlyArray<TVector> Points { get; }

        /// <summary>Returns <see langword="true"/> if this segment is followed by another segment.</summary>
        public bool HasNext => !double.IsNaN(DegreesWithNext);

        /// <summary>Angle (in degrees) between this segment and the next, or <see cref="double.NaN"/> if this is the last segment.</summary>
        public double DegreesWithNext { get; }

        /// <summary>Total length of the segment in double precision.</summary>
        public double LengthD => Points.GetLengthD();

        /// <summary>Total length of the segment in single precision.</summary>
        public float LengthF => Points.GetLengthF();

        /// <summary>First point of the segment.</summary>
        public TVector First => Points[0];

        /// <summary>Last point of the segment.</summary>
        public TVector Last => Points[Points.Count - 1];

        /// <summary>Returns <see langword="true"/> if the first and last points are equal.</summary>
        public bool IsClosed => First.Equals(Last);

        /// <summary>
        /// Splits a path into segments when a path makes an angle above specified threshold
        /// </summary>
        /// <param name="path"></param>
        /// <param name="thresholdInDegrees"></param>
        /// <returns></returns>
        public static List<PathSegment<TPrimitive, TVector>> FromPath(Path<TPrimitive, TVector> path, double thresholdInDegrees = 45)
        {
            return FromPath(path.Points, thresholdInDegrees);
        }

        /// <summary>
        /// Splits a path into segments when a path makes an angle above specified threshold
        /// </summary>
        /// <param name="points"></param>
        /// <param name="thresholdInDegrees"></param>
        /// <returns></returns>
        public static List<PathSegment<TPrimitive, TVector>> FromPath(ReadOnlyArray<TVector> points, double thresholdInDegrees = 45)
        {
            var thresholdInRadians = thresholdInDegrees * Math.PI / 180;
            var segments = new List<PathSegment<TPrimitive, TVector>>();
            var currentSegment = new ReadOnlyArrayBuilder<TVector>() { points[0] };
            var previousDelta = TVector.Zero;
            var previousPoint = points[0];
            foreach (var point in points.Skip(1))
            {
                var delta = (point - previousPoint);
                if (currentSegment.Count > 1)
                {
                    var angle = Vectors.AngleRadians(previousDelta, delta);
                    if (Math.Abs(angle) > thresholdInRadians)
                    {
                        // Adding this point creates an angle > threshold
                        // Ends current segment, and starts a new one
                        segments.Add(new PathSegment<TPrimitive, TVector>(points: currentSegment.Build(), angleWithNext: angle * 180 / Math.PI));
                        currentSegment = new ReadOnlyArrayBuilder<TVector>() { previousPoint, point };
                    }
                    else
                    {
                        currentSegment.Add(point);
                    }
                }
                else
                {
                    currentSegment.Add(point);
                }
                previousPoint = point;
                previousDelta = delta;
            }
            if (currentSegment.Count > 1)
            {
                if (segments.Count > 0 && points[0].Equals(points[points.Count - 1]))
                {
                    // It's a loop, compute angle with first segment
                    var delta = (points[1] - points[0]);
                    var angle = Vectors.AngleRadians(previousDelta, delta);
                    if (Math.Abs(angle) > thresholdInRadians)
                    {
                        segments.Add(new PathSegment<TPrimitive, TVector>(points: currentSegment.Build(), angleWithNext: angle * 180 / Math.PI));
                    }
                    else
                    {
                        // edit first segment
                        var first = segments[0];
                        currentSegment.AddRange(first.Points.Skip(1));
                        segments[0] = new PathSegment<TPrimitive, TVector>(currentSegment.Build(), first.DegreesWithNext);
                    }
                }
                else
                {
                    // Not a loop
                    segments.Add(new PathSegment<TPrimitive, TVector>(currentSegment.Build()));
                }
            }
            return segments;
        }
    }
}
