using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Test.Shapes
{
    public abstract class ShapeTransformsTestBase<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private Polygon<TPrimitive, TVector> Square100x100()
        {
            return new Polygon<TPrimitive, TVector>(new ReadOnlyArray<TVector>(TVector.Create(100, 100), TVector.Create(0, 100), TVector.Create(0, 0), TVector.Create(100, 0), TVector.Create(100, 100)));
        }

        [Fact]
        public void Scale_Polygon_Primitive()
        {
            Assert.Equal("POLYGON ((200 200, 0 200, 0 0, 200 0, 200 200))", 
                Square100x100().Transforms().Scale(TPrimitive.CreateChecked(2)).ToString());
        }

        [Fact]
        public void Scale_Polygon_Integer()
        {
            Assert.Equal("POLYGON ((200 200, 0 200, 0 0, 200 0, 200 200))",
                Square100x100().Transforms().Scale(2).ToString());
        }

        [Fact]
        public void ReverseScale_Polygon_Primitive()
        {
            Assert.Equal("POLYGON ((50 50, 0 50, 0 0, 50 0, 50 50))",
                Square100x100().Transforms().ReverseScale(TPrimitive.CreateChecked(2)).ToString());
        }

        [Fact]
        public void ReverseScale_Polygon_Integer()
        {
            Assert.Equal("POLYGON ((50 50, 0 50, 0 0, 50 0, 50 50))",
                Square100x100().Transforms().ReverseScale(2).ToString());
        }


        [Fact]
        public void Scale_PolygonSet_Integer()
        {
            Assert.Equal("POLYGONSET ((200 200, 0 200, 0 0, 200 0))",
                Square100x100().ToPolygonSet().Transforms().Scale(2).ToString());
        }

        [Fact]
        public void ReverseScale_PolygonSet_Integer()
        {
            Assert.Equal("POLYGONSET ((50 50, 0 50, 0 0, 50 0))",
                Square100x100().ToPolygonSet().Transforms().ReverseScale(2).ToString());
        }


        [Fact]
        public void Scale_PolygonSet_Primitive()
        {
            Assert.Equal("POLYGONSET ((200 200, 0 200, 0 0, 200 0))",
                Square100x100().ToPolygonSet().Transforms().Scale(TPrimitive.CreateChecked(2)).ToString());
        }

        [Fact]
        public void ReverseScale_PolygonSet_Primitive()
        {
            Assert.Equal("POLYGONSET ((50 50, 0 50, 0 0, 50 0))",
                Square100x100().ToPolygonSet().Transforms().ReverseScale(TPrimitive.CreateChecked(2)).ToString());
        }
    }
}
