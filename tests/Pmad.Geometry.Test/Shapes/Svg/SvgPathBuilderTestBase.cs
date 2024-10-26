using System.Numerics;
using Pmad.Geometry.Shapes;
using Pmad.Geometry.Shapes.Svg;

namespace Pmad.Geometry.Test.Shapes.Svg
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
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(new ShapeSettings<TPrimitive, TVector>(1, 3));

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
        public void AppendPolygon()
        {
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(ShapeSettings<TPrimitive, TVector>.Default);

            builder.AppendPolygon(ShapeSettings<TPrimitive, TVector>.Default.CreateRectanglePolygon(TVector.Create(10,20), TVector.Create(20,35)));

            Assert.Equal("M10,20 v15 h10 v-15 h-10 z", builder.ToString());

            builder.Builder.Clear();

            builder.AppendPolygon(ShapeSettings<TPrimitive, TVector>.Default.CreatePolygon(new (
                TVector.Create(0, 0), 
                TVector.Create(15, 10),
                TVector.Create(10, 15),
                TVector.Create(0, 0)
                )));

            Assert.Equal("M0,0 l15,10 l-5,5 l-10,-15 z", builder.ToString());

            builder.Builder.Clear();

            builder.AppendPolygon(ShapeSettings<TPrimitive, TVector>.Default.CreatePolygon(new(
                TVector.Create(0, 0),
                TVector.Create(100, 0),
                TVector.Create(100, 100),
                TVector.Create(0, 100),
                TVector.Create(0, 0)
                ), new( [new(TVector.Create(40, 40),
                TVector.Create(60, 40),
                TVector.Create(60, 60),
                TVector.Create(40, 60),
                TVector.Create(40, 40))])));

            Assert.Equal("M0,0 h100 v100 h-100 v-100 z M40,40 h20 v20 h-20 v-20 z", builder.ToString());
        }

        [Fact]
        public void AppendCircle()
        {
            using var builder = new SvgPathBuilder<TPrimitive, TVector>(ShapeSettings<TPrimitive, TVector>.Default);

            builder.AppendCircle(TVector.Create(100, 150), 100);

            Assert.Equal("M100,150 m 100,0 a 100,100 0 1,1 -200,0 a 100,100 0 1,1 200,0 z", builder.ToString());
        }
    }
}