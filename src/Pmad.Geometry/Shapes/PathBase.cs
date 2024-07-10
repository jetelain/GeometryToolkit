using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public abstract class PathBase<TPrimitive, TVector, TPolygon, TPath, TAlgorithms, TFactory> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TPolygon : PolygonBase<TPrimitive, TVector, TPolygon, TAlgorithms, TFactory>
        where TPath : PathBase<TPrimitive, TVector, TPolygon, TPath, TAlgorithms, TFactory>
        where TAlgorithms : IVectorAlgorithms<TPrimitive, TVector>, new()
        where TFactory : ShapeFactoryBase<TPrimitive, TVector, TPolygon, TAlgorithms, TFactory>
    {
        public PathBase(TFactory factory, IReadOnlyList<TVector> points)
        {
            this.Factory = factory;
            this.Points = points;
            Bounds = VectorEnvelope<TVector>.FromList(points);
        }

        public TFactory Factory { get; }
        
        public IReadOnlyList<TVector> Points { get; }

        public VectorEnvelope<TVector> Bounds { get; }

        public double LengthD => Points.GetLengthD();

        public float LengthF => Points.GetLengthF();

        public bool IsClosed => Points[0].Equals(Points[Points.Count-1]);

        public bool IsCounterClockWise => IsClosed && Factory.Algorithms.GetSignedAreaD(Points) > 0;

        public bool IsClockWise => IsClosed && Factory.Algorithms.GetSignedAreaD(Points) < 0;

        protected abstract TPath This { get; }

        protected abstract TPath CreatePath(IReadOnlyList<TVector> points);

        public IEnumerable<TPolygon> ToPolygon(double width, EndType endType = EndType.Butt, JoinType joinType = JoinType.Square)
        {
            var offset = new ClipperOffset();
            offset.AddPath(new Path64(Points.Select(Factory.ToClipper)), joinType, endType);
            var solution = new PolyTree64(); ;
            offset.Execute(width * Factory.ScaleForClipper / 2, solution);
            return Factory.FromClipper(solution);
        }

        /// <summary>
        /// Create a polygon whose shell is the current path
        /// </summary>
        /// <returns></returns>
        public TPolygon ToPolygonAsShell()
        {
            if (!IsClosed)
            {
                var points = new List<TVector>(Points.Count + 1); 
                points.AddRange(Points);
                points.Add(Points[0]);
                return Factory.CreatePolygon(points);
            }
            return Factory.CreatePolygon(Points);
        }
    }
}
