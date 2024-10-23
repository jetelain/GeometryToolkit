using System.Numerics;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Svg;

namespace Pmad.Geometry.Test.Svg
{
    public abstract class SvgPathBuilderTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {

        [Fact]
        public void AppendScalar_DefaultPrecision()
        {
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(ShapeSettings<TPrimitive, TVector>.Default);

            builder.AppendScalar(TPrimitive.Zero);
            Assert.Equal("0", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.One);
            Assert.Equal("1", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(100));
            Assert.Equal("100", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123));
            Assert.Equal("123", builder.ToString());
        }

        [Fact]
        public void AppendScalar_IntegerPrecision()
        {
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(new ShapeSettings<TPrimitive, TVector>(1,3));

            builder.AppendScalar(TPrimitive.Zero);
            Assert.Equal("0", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.One);
            Assert.Equal("1", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(100));
            Assert.Equal("100", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123));
            Assert.Equal("123", builder.ToString());
        }
    }
}
