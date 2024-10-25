using System.Numerics;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Shapes.Svg;

namespace Pmad.Geometry.Test.Shapes.Svg
{
    public abstract class SvgPathBuilderTestFPBase<TPrimitive, TVector> : SvgPathBuilderTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        [Fact]
        public void AppendScalar_DefaultPrecision_FastPath()
        {
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(ShapeSettings<TPrimitive, TVector>.Default);

            builder.AppendScalar(TPrimitive.CreateChecked(123.456));
            Assert.Equal("123.456", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123.4561));
            Assert.Equal("123.456", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123.4569));
            Assert.Equal("123.457", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123.450));
            Assert.Equal("123.45", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123.400));
            Assert.Equal("123.4", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(123.000));
            Assert.Equal("123", builder.ToString());

            builder.Builder.Clear();

            builder.AppendScalar(TPrimitive.CreateChecked(120.000));
            Assert.Equal("120", builder.ToString());
        }

    }
}
