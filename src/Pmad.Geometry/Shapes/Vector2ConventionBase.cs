using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public abstract class Vector2ConventionBase<TPrimitive, TVector, TAlgorithms>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TAlgorithms : IVectorAlgorithms<TPrimitive, TVector>, new()
    {
        public readonly TAlgorithms Algorithms = new();

        public TVector Create(double x, double y) => Algorithms.Create(x, y);

        public TVector Create(int x, int y) => Algorithms.Create(x, y);

        public TVector Create(TPrimitive x, TPrimitive y) => Algorithms.Create(x, y);

        public PointInPolygonResult PointInPolygon(List<TVector> path, TVector pt) => Algorithms.TestPointInPolygon(path, pt);

        public abstract double ScaleForClipper { get; }
    }
}
