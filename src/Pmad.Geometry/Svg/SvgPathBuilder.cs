using System.Buffers;
using System.Globalization;
using System.Numerics;
using System.Text;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Svg
{
    ref struct SvgPathBuilder<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly StringBuilder builder;
        private readonly string? numberFormat;
        private readonly char[] bufferArray;
        private readonly Span<char> buffer;

        public SvgPathBuilder(ShapeSettings<TPrimitive,TVector> settings) 
            : this(new StringBuilder(), GetNumberFormat(settings))
        {

        }

        public SvgPathBuilder(StringBuilder builder, string? numberFormat)
        {
            this.builder = builder;
            this.numberFormat = numberFormat;
            bufferArray = ArrayPool<char>.Shared.Rent(64);
            buffer = new Span<char>(bufferArray);
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

        public void AppendSvgClosedPath(ReadOnlySpan<TVector> points)
        {
            if (points.Length == 0)
            {
                return;
            }
            AppendSvgPath(points);
            builder.Append(" z");
        }

        public void AppendSvgPath(ReadOnlySpan<TVector> points)
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
