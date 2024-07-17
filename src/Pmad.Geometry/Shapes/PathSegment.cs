﻿using System.Numerics;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public class PathSegment<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public PathSegment(ReadOnlyArray<TVector> points, double angleWithNext = double.NaN)
        {
            Points = points;
            DegreesWithNext = Math.Round(angleWithNext, 4);
        }

        public ReadOnlyArray<TVector> Points { get; }

        public bool HasNext => !double.IsNaN(DegreesWithNext);

        public double DegreesWithNext { get; }

        public double LengthD => Points.GetLengthD();

        public float LengthF => Points.GetLengthF();

        public TVector First => Points[0];

        public TVector Last => Points[Points.Count - 1];

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
            var segments = new List<PathSegment<TPrimitive, TVector>>();
            var currentSegment = new ReadOnlyArrayBuilder<TVector>() { points[0] };
            var previousDeltaAngle = 0.0;
            var previousPoint = points[0];
            foreach (var point in points.Skip(1))
            {
                var deltaAngle = (point - previousPoint).Atan2D() * 180 / MathF.PI;
                if (currentSegment.Count > 1)
                {
                    var angle = NormalizeAngle((deltaAngle - previousDeltaAngle) % 360);
                    if (Math.Abs(angle) > thresholdInDegrees)
                    {
                        // Adding this point creates an angle > threshold
                        // Ends current segment, and starts a new one
                        segments.Add(new PathSegment<TPrimitive, TVector>(points: currentSegment.Build(), angleWithNext: angle));
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
                previousDeltaAngle = deltaAngle;
            }
            if (currentSegment.Count > 1)
            {
                if (segments.Count > 0 && points[0].Equals(points[points.Count - 1]))
                {
                    // It's a loop, compute angle with first segment
                    var deltaAngle = (points[1] - points[0]).Atan2D() * 180 / MathF.PI;
                    var angle = NormalizeAngle((deltaAngle - previousDeltaAngle) % 360);
                    if (Math.Abs(angle) > thresholdInDegrees)
                    {
                        segments.Add(new PathSegment<TPrimitive, TVector>(points: currentSegment.Build(), angleWithNext: angle));
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

        private static double NormalizeAngle(double degrees)
        {
            if (degrees > 180)
            {
                return degrees - 360;
            }
            if (degrees <= -180)
            {
                return degrees + 360;
            }
            return degrees;
        }


    }
}