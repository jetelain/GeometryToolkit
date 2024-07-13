/**********************************************************************************
* Author    :  Angus Johnson, Julien Etelain                                      *
* Copyright :  Angus Johnson 2010-2024, Julien Etelain 2024                       *
* Purpose   :  PointInPolygon for each supported vector type, to avoid conversion *
* License   :  http://www.boost.org/LICENSE_1_0.txt                               *
***********************************************************************************/
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Algorithms
{
	public static class SmallestRotatedRectangle
	{
        public static RotatedRectangle<float,Vector2F> Compute(ShapeSettings<float,Vector2F> settings, ReadOnlySpan<Vector2F> points)
        {
            Vector2F resultSize = default;
            Vector2F resultCenter = default;
            float resultAngle = 0;
            float resultArea = float.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = (a - b).Atan2();

                var rotate = Matrix2x2F.CreateRotation(-theta);

                var max = rotate.Transform(points[0] - a);
                var min = max;

                for (int j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j] - a);
                    max = Vector2F.Max(r, max);
                    min = Vector2F.Min(r, min);
                }
                var size = max - min;
                var area = size.Area();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2F.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = ((resultP3 + resultP1) / 2) + a;
                }
                a = b;
            }

            return new (settings, resultCenter, resultSize, resultAngle);
        }
        public static RotatedRectangle<double,Vector2D> Compute(ShapeSettings<double,Vector2D> settings, ReadOnlySpan<Vector2D> points)
        {
            Vector2D resultSize = default;
            Vector2D resultCenter = default;
            double resultAngle = 0;
            double resultArea = double.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = (a - b).Atan2();

                var rotate = Matrix2x2D.CreateRotation(-theta);

                var max = rotate.Transform(points[0] - a);
                var min = max;

                for (int j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j] - a);
                    max = Vector2D.Max(r, max);
                    min = Vector2D.Min(r, min);
                }
                var size = max - min;
                var area = size.Area();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2D.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = ((resultP3 + resultP1) / 2) + a;
                }
                a = b;
            }

            return new (settings, resultCenter, resultSize, resultAngle);
        }
        public static RotatedRectangle<float,Vector2FS> Compute(ShapeSettings<float,Vector2FS> settings, ReadOnlySpan<Vector2FS> points)
        {
            Vector2FS resultSize = default;
            Vector2FS resultCenter = default;
            float resultAngle = 0;
            float resultArea = float.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = (a - b).Atan2();

                var rotate = Matrix2x2FS.CreateRotation(-theta);

                var max = rotate.Transform(points[0] - a);
                var min = max;

                for (int j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j] - a);
                    max = Vector2FS.Max(r, max);
                    min = Vector2FS.Min(r, min);
                }
                var size = max - min;
                var area = size.Area();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2FS.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = ((resultP3 + resultP1) / 2) + a;
                }
                a = b;
            }

            return new (settings, resultCenter, resultSize, resultAngle);
        }
        public static RotatedRectangle<double,Vector2DS> Compute(ShapeSettings<double,Vector2DS> settings, ReadOnlySpan<Vector2DS> points)
        {
            Vector2DS resultSize = default;
            Vector2DS resultCenter = default;
            double resultAngle = 0;
            double resultArea = double.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = (a - b).Atan2();

                var rotate = Matrix2x2DS.CreateRotation(-theta);

                var max = rotate.Transform(points[0] - a);
                var min = max;

                for (int j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j] - a);
                    max = Vector2DS.Max(r, max);
                    min = Vector2DS.Min(r, min);
                }
                var size = max - min;
                var area = size.Area();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2DS.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = ((resultP3 + resultP1) / 2) + a;
                }
                a = b;
            }

            return new (settings, resultCenter, resultSize, resultAngle);
        }
        public static RotatedRectangle<float,Vector2FN> Compute(ShapeSettings<float,Vector2FN> settings, ReadOnlySpan<Vector2FN> points)
        {
            Vector2FN resultSize = default;
            Vector2FN resultCenter = default;
            float resultAngle = 0;
            float resultArea = float.MaxValue;

            var a = points[points.Length - 1];

            for (var i = 0; i < points.Length; i++)
            {
                var b = points[i];

                var theta = (a - b).Atan2();

                var rotate = Matrix2x2FN.CreateRotation(-theta);

                var max = rotate.Transform(points[0] - a);
                var min = max;

                for (int j = 1; j < points.Length; j++)
                {
                    var r = rotate.Transform(points[j] - a);
                    max = Vector2FN.Max(r, max);
                    min = Vector2FN.Min(r, min);
                }
                var size = max - min;
                var area = size.Area();
                if (area < resultArea)
                {
                    resultArea = area;
                    resultSize = size;
                    resultAngle = theta;

                    var reverseRotate = Matrix2x2FN.CreateRotation(theta);
                    var resultP3 = reverseRotate.Transform(max);
                    var resultP1 = reverseRotate.Transform(min);
                    resultCenter = ((resultP3 + resultP1) / 2) + a;
                }
                a = b;
            }

            return new (settings, resultCenter, resultSize, resultAngle);
        }
	}
}
