using System.Buffers;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace Pmad.Geometry.Shapes.Svg
{
    public sealed class SvgPathBuilder<TPrimitive, TVector> : IDisposable
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly StringBuilder builder;
        private readonly string? numberFormat;
        private readonly char[] bufferArray;

        public SvgPathBuilder(ShapeSettings<TPrimitive, TVector> settings)
            : this(new StringBuilder(1024), GetNumberFormat(settings))
        {

        }

        public SvgPathBuilder(StringBuilder builder, ShapeSettings<TPrimitive, TVector> settings)
            : this(builder, GetNumberFormat(settings))
        {

        }

        public SvgPathBuilder(StringBuilder builder, string? numberFormat)
        {
            this.builder = builder;
            this.numberFormat = numberFormat;
            bufferArray = ArrayPool<char>.Shared.Rent(64);
        }

        public StringBuilder Builder => builder;

        public static string? GetNumberFormat(ShapeSettings<TPrimitive, TVector> shapeSettings)
        {
            if (typeof(TPrimitive) == typeof(int) || typeof(TPrimitive) == typeof(long))
            {
                return null;
            }
            if (shapeSettings.ScaleForClipper == 1)
            {
                return "0";
            }
            var sb = new StringBuilder();
            sb.Append("0.");
            var remain = shapeSettings.ScaleForClipper - 1;
            while (remain > 0)
            {
                sb.Append('0');
                remain /= 10;
            }
            return sb.ToString();
        }

        public void AppendPolygon(Polygon<TPrimitive, TVector> polygon)
        {
            AppendClosedPath(polygon.Shell.AsSpan());
            foreach (var hole in polygon.Holes)
            {
                builder.Append(' ');
                AppendClosedPath(hole.AsSpan());
            }
        }

        public void AppendClosedPath(ReadOnlySpan<TVector> points)
        {
            if (points.Length == 0)
            {
                return;
            }
            AppendPath(points);
            builder.Append(" z");
        }

        public void AppendPath(Path<TPrimitive, TVector> points)
        {
            AppendPath(points.Points.AsSpan());
        }

        public void AppendPath(ReadOnlySpan<TVector> points)
        {
            if (points.Length == 0)
            {
                return;
            }
            var previous = points[0];
            builder.Append('M'); // M x y
            AppendPoint(previous);

            for (int i = 1; i < points.Length; i++)
            {
                var px = points[i];
                var delta = px - previous;
                if (delta.X == TPrimitive.Zero)
                {
                    builder.Append(" v"); // v dy
                    AppendScalar(delta.Y);
                }
                else if (delta.Y == TPrimitive.Zero)
                {
                    builder.Append(" h"); // h dx
                    AppendScalar(delta.X);
                }
                else
                {
                    builder.Append(" l"); // l dx dy
                    AppendPoint(delta);
                }
                previous = px;
            }

        }

        public void AppendPoint(TVector px)
        {
            AppendScalar(px.X);
            builder.Append(',');
            AppendScalar(px.Y);
        }

        public void AppendScalar(TPrimitive d)
        {
            if (typeof(TPrimitive) == typeof(int) || typeof(TPrimitive) == typeof(long) || numberFormat == null)
            {
                builder.Append(CultureInfo.InvariantCulture, $"{d}");
                return;
            }
            var buffer = new Span<char>(bufferArray);
            if (d.TryFormat(buffer, out var written, numberFormat, CultureInfo.InvariantCulture))
            {
                // Fast Path
                if (numberFormat.Length > 1) // "0.0...", trim excess 0 after decimal separator
                {
                    builder.Append(buffer.Slice(0, written).TrimEnd('0').TrimEnd('.'));
                }
                else // "0"
                {
                    builder.Append(buffer.Slice(0, written));
                }
            }
            else
            {
                // Slow Path
                if (numberFormat.Length > 1) // "0.0...", trim excess 0 after decimal separator
                {
                    builder.Append(d.ToString(numberFormat, CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.'));
                }
                else // "0"
                {
                    builder.Append(d.ToString(numberFormat, CultureInfo.InvariantCulture));
                }
            }
        }

        private string FormatDouble(double d)
        {
            if (numberFormat == null)
            {
                return d.ToString(CultureInfo.InvariantCulture);
            }
            if (numberFormat.Length > 1) // "0.0...", trim excess 0 after decimal separator
            {
                return d.ToString(numberFormat, CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
            }
            return d.ToString(numberFormat, CultureInfo.InvariantCulture);
        }

        public void AppendCircle(TVector center, double radius)
        {
            builder.Append('M');
            AppendPoint(center);
            var radiusStr = FormatDouble(radius);
            var radius2Str = FormatDouble(radius * 2);
            builder.Append(CultureInfo.InvariantCulture, $" m {radiusStr},0 a {radiusStr},{radiusStr} 0 1,1 -{radius2Str},0 a {radiusStr},{radiusStr} 0 1,1 {radius2Str},0 z");
        }

        public void Dispose()
        {
            ArrayPool<char>.Shared.Return(bufferArray);
        }

        public override string ToString()
        {
            return builder.ToString();
        }

        public void Append(char value)
        {
            builder.Append(value);
        }
    }
}
