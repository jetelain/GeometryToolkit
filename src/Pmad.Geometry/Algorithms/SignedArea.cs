using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Algorithms
{
	public static class SignedArea
	{
        public static double GetSignedArea(this IReadOnlyList<Vector2I> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2I.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2I> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2I.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static float GetSignedArea(this IReadOnlyList<Vector2F> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            float area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2F.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static float GetSignedArea(this ReadOnlyArray<Vector2F> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            float area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2F.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2L> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2L.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2L> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2L.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2D> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2D.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2D> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2D.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2IS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2IS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2IS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2IS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2FS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2FS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2FS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2FS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2LS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2LS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2LS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2LS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static double GetSignedArea(this IReadOnlyList<Vector2DS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2DS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static double GetSignedArea(this ReadOnlyArray<Vector2DS> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            double area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2DS.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
        public static float GetSignedArea(this IReadOnlyList<Vector2FN> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            float area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2FN.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }

        public static float GetSignedArea(this ReadOnlyArray<Vector2FN> points)
        {
            if (points.Count < 3)
            {
                return 0;
            }
            var v1 = points[points.Count-1];
            float area = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var v2 = points[i];
                area += Vector2FN.CrossProduct(v1, v2);
                v1 = v2;
            }
            return area / 2;
        }
	}
}
