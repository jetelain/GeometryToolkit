using System.Numerics;
using Clipper2Lib;

namespace Pmad.Geometry.Shapes
{
    internal static class PathClipperHelper
    {
        public static Paths64 RectClipLinesKeepOrientation(Rect64 clip, Path64 initialPoints, bool isClosed)
        {
            var clipped = Clipper.RectClipLines(clip, initialPoints);

            // Clipper v1 does not keep orientation of lines. Clipper2Lib seems to keep orientation, this code might be useless now.

            if (isClosed)
            {
                var noMoreExists = initialPoints.Where(p => !clipped.Any(c => c.Any(np => np == p))).ToList();
                if (noMoreExists.Count > 0)
                {
                    var newStart = initialPoints.FindIndex(p => p == noMoreExists[0]);
                    if (newStart != -1)
                    {
                        initialPoints = new Path64(initialPoints.Skip(newStart).Concat(initialPoints.Skip(1).Take(newStart)));
                    }
                }
                else if (clipped.Count == 1 && clipped[0].Count == initialPoints.Count) // all points are still here, same length, it's all the same
                {
                    return new Paths64(1) { initialPoints };
                }
#if DEBUG
                else
                {
                    throw new InvalidOperationException("Unsupported edge case");
                }
#endif
            }
            foreach (var result in clipped)
            {
                if (result.Count < 2)
                {
                    continue;
                }
                var indices = result.Select(np => initialPoints.FindIndex(p => np == p)).Where(i => i != -1).Take(2).ToList();
                if (indices.Count > 1)
                {
                    if (indices[0] > indices[1])
                    {
                        result.Reverse();
                    }
                }
                else if (indices.Count == 1)
                {
                    var initialReferenceIndex = indices[0];
                    var sharedReferencePoint = initialPoints[initialReferenceIndex];
                    var resultReferenceIndex = result.FindIndex(p => sharedReferencePoint == p);

                    if (resultReferenceIndex == result.Count - 1)
                    {
                        if (initialReferenceIndex == 0)
                        {
                            result.Reverse();
                        }
                        else
                        {
                            CheckVector(result, sharedReferencePoint, result[resultReferenceIndex - 1], initialPoints[initialReferenceIndex - 1]);
                        }
                    }
                    else
                    {
                        if (initialReferenceIndex == initialPoints.Count - 1)
                        {
                            result.Reverse();
                        }
                        else
                        {
                            CheckVector(result, sharedReferencePoint, result[resultReferenceIndex + 1], initialPoints[initialReferenceIndex + 1]);
                        }
                    }
                }
#if DEBUG
                else
                {
                    throw new InvalidOperationException("Unsupported edge case");
                }
#endif
            }
            return clipped;
        }

        private static void CheckVector(Path64 result, Point64 sharedReferencePoint, Point64 resultComparePoint, Point64 initialComparePoint)
        {
            // TODO: Find a better algorithm
            var initialVect = initialComparePoint - sharedReferencePoint;
            var resultVect = resultComparePoint - sharedReferencePoint;
            if (Vector2.Dot(Vector2.Normalize(new (initialVect.X, initialVect.Y)), Vector2.Normalize(new (resultVect.X, resultVect.Y))) <= 0)
            {
                result.Reverse();
            }
        }

    }
}
