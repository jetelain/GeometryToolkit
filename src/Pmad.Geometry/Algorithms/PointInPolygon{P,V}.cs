/**********************************************************************************
* Author    :  Angus Johnson, Julien Etelain                                      *
* Copyright :  Angus Johnson 2010-2024, Julien Etelain 2024                       *
* Purpose   :  PointInPolygon for each supported vector type, to avoid conversion *
* License   :  http://www.boost.org/LICENSE_1_0.txt                               *
***********************************************************************************/
using System.Numerics;
using System.Runtime.CompilerServices;
using Pmad.Geometry.Clipper2Lib;

namespace Pmad.Geometry.Algorithms
{
    public static class PointInPolygon<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CrossProduct(TVector pt1, TVector pt2, TVector pt3)
            => TVector.CrossProduct(pt1, pt2, pt3);

        public static PointInPolygonResult Test(ReadOnlySpan<TVector> polygon, TVector pt)
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
                    d = TVector.CrossProduct(prev, curr, pt);
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
                    d = TVector.CrossProduct(polygon[len - 1], polygon[0], pt);
                else
                    d = TVector.CrossProduct(polygon[i - 1], polygon[i], pt);
                if (d == 0) return PointInPolygonResult.IsOn;
                if ((d < 0) == isAbove) val = !val;
            }

            if (!val)
                return PointInPolygonResult.IsOutside;
            return PointInPolygonResult.IsInside;
        }


    }
}
