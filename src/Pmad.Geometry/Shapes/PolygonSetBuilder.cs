using System.Numerics;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public struct PolygonSetBuilder<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly Paths64 paths = new Paths64();
        private readonly ShapeSettings<TPrimitive, TVector> settings;

        public PolygonSetBuilder(ShapeSettings<TPrimitive, TVector> settings)
        {
            this.settings = settings;
        }

        public PolygonSetBuilder()
            : this(ShapeSettings<TPrimitive, TVector>.Default)
        {

        }

        public void AddPath(ReadOnlySpan<TVector> vectors)
        {
            paths.Add(settings.ToClipper(vectors));
        }

        public void AddPath(ReadOnlyArray<TVector> vectors)
        {
            paths.Add(settings.ToClipper(vectors));
        }

        public void AddPath(IEnumerable<TVector> vectors)
        {
            paths.Add(new Path64(vectors.Select(settings.ToClipper)));
        }

        public PolygonSet<TPrimitive, TVector> Build()
        {
            return new PolygonSet<TPrimitive, TVector>(paths, settings);
        }
    }
}
