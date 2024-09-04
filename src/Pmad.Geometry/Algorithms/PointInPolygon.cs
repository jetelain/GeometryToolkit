/**********************************************************************************
* Author    :  Angus Johnson, Julien Etelain                                      *
* Copyright :  Angus Johnson 2010-2024, Julien Etelain 2024                       *
* Purpose   :  PointInPolygon for each supported vector type, to avoid conversion *
* License   :  http://www.boost.org/LICENSE_1_0.txt                               *
***********************************************************************************/
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Algorithms
{
	public static class PointInPolygon
	{
        public static PointInPolygonResult TestPointInPolygon(this List<Vector2I> polygon, Vector2I pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2I>
            // and 25% faster than sticking to IReadOnlyList<Vector2I>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2I> polygon, Vector2I pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2I> polygon, Vector2I pt)
        {
            if (polygon is List<Vector2I> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2I> polygon, Vector2I pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2I.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2I.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2I.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        public static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2I> polygon, Vector2I pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2I.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2I.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2I.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        public static PointInPolygonResult TestPointInPolygon(this List<Vector2F> polygon, Vector2F pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2F>
            // and 25% faster than sticking to IReadOnlyList<Vector2F>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2F> polygon, Vector2F pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2F> polygon, Vector2F pt)
        {
            if (polygon is List<Vector2F> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2F> polygon, Vector2F pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2F.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2F.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2F.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        public static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2F> polygon, Vector2F pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2F.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2F.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2F.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        public static PointInPolygonResult TestPointInPolygon(this List<Vector2L> polygon, Vector2L pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2L>
            // and 25% faster than sticking to IReadOnlyList<Vector2L>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2L> polygon, Vector2L pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2L> polygon, Vector2L pt)
        {
            if (polygon is List<Vector2L> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2L> polygon, Vector2L pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2L.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2L.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2L.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        public static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2L> polygon, Vector2L pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2L.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2L.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2L.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        public static PointInPolygonResult TestPointInPolygon(this List<Vector2D> polygon, Vector2D pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2D>
            // and 25% faster than sticking to IReadOnlyList<Vector2D>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2D> polygon, Vector2D pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        public static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2D> polygon, Vector2D pt)
        {
            if (polygon is List<Vector2D> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2D> polygon, Vector2D pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2D.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2D.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2D.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        public static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2D> polygon, Vector2D pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2D.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2D.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2D.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        internal static PointInPolygonResult TestPointInPolygon(this List<Vector2IS> polygon, Vector2IS pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2IS>
            // and 25% faster than sticking to IReadOnlyList<Vector2IS>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2IS> polygon, Vector2IS pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        internal static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2IS> polygon, Vector2IS pt)
        {
            if (polygon is List<Vector2IS> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2IS> polygon, Vector2IS pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2IS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2IS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2IS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2IS> polygon, Vector2IS pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2IS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2IS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2IS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        internal static PointInPolygonResult TestPointInPolygon(this List<Vector2FS> polygon, Vector2FS pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2FS>
            // and 25% faster than sticking to IReadOnlyList<Vector2FS>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2FS> polygon, Vector2FS pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        internal static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2FS> polygon, Vector2FS pt)
        {
            if (polygon is List<Vector2FS> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2FS> polygon, Vector2FS pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2FS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2FS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2FS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2FS> polygon, Vector2FS pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2FS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2FS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2FS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        internal static PointInPolygonResult TestPointInPolygon(this List<Vector2LS> polygon, Vector2LS pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2LS>
            // and 25% faster than sticking to IReadOnlyList<Vector2LS>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2LS> polygon, Vector2LS pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        internal static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2LS> polygon, Vector2LS pt)
        {
            if (polygon is List<Vector2LS> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2LS> polygon, Vector2LS pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2LS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2LS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2LS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2LS> polygon, Vector2LS pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2LS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2LS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2LS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


        internal static PointInPolygonResult TestPointInPolygon(this List<Vector2DS> polygon, Vector2DS pt)
        {           
            // We achieve 20% faster processing using a Span compared to List<Vector2DS>
            // and 25% faster than sticking to IReadOnlyList<Vector2DS>
            return TestPointInPolygon(CollectionsMarshal.AsSpan(polygon), pt);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlyArray<Vector2DS> polygon, Vector2DS pt)
        {
            return TestPointInPolygon(polygon.AsSpan(), pt);
        }

        internal static PointInPolygonResult TestPointInPolygon(this IReadOnlyList<Vector2DS> polygon, Vector2DS pt)
        {
            if (polygon is List<Vector2DS> list)
            {
                return TestPointInPolygon(list, pt);
            }
            return TestPointInPolygonImpl(polygon, pt);
        }

        private static PointInPolygonResult TestPointInPolygonImpl(IReadOnlyList<Vector2DS> polygon, Vector2DS pt)
        {                
            int len = polygon.Count, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2DS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2DS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2DS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
            
        }

        internal static PointInPolygonResult TestPointInPolygon(this ReadOnlySpan<Vector2DS> polygon, Vector2DS pt)
        {
            int len = polygon.Length, start = 0;
            if (len < 3) return PointInPolygonResult.IsOutside;

            while (start < len && polygon[start].Y == pt.Y) start++;
            if (start == len) return PointInPolygonResult.IsOutside;

            double d;
            bool isAbove = polygon[start].Y < pt.Y, startingAbove = isAbove;
            bool val = false;
            int i = start + 1, end = len;
            while (true)
            {
                if (i == end)
                {
                    if (end == 0 || start == 0) break;
                    end = start;
                    i = 0;
                }

                if (isAbove)
                {
                    while (i < end && polygon[i].Y < pt.Y) i++;
                    if (i == end) continue;
                }
                else
                {
                    while (i < end && polygon[i].Y > pt.Y) i++;
                    if (i == end) continue;
                }

                var curr = polygon[i];
                var prev = (i > 0) ? polygon[i - 1] : polygon[len - 1];

                if (curr.Y == pt.Y)
                {
                    if (curr.X == pt.X || (curr.Y == prev.Y &&
                      ((pt.X < prev.X) != (pt.X < curr.X))))
                        return PointInPolygonResult.IsOn;
                    i++;
                    if (i == start) break;
                    continue;
                }

                if (pt.X < curr.X && pt.X < prev.X)
                {
                    // we're only interested in edges crossing on the left
                }
                else if (pt.X > prev.X && pt.X > curr.X)
                {
                    val = !val; // toggle val
                }
                else
                {
                    d = Vector2DS.CrossProduct(prev, curr, pt);
                    if (d == 0) return PointInPolygonResult.IsOn;
                    if ((d < 0) == isAbove) val = !val;
                }
                isAbove = !isAbove;
                i++;
            }

            if (isAbove != startingAbove)
            {
                if (i == len) i = 0;
                if (i == 0)
                    d = Vector2DS.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = Vector2DS.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


	}
}
