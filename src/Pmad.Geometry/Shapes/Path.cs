using System.Numerics;
using System.Text;
using Pmad.Geometry.Clipper2Lib;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// Path, ordered list of points.
    /// </summary>
    /// <typeparam name="TPrimitive">Numeric primitive type of the vector components.</typeparam>
    /// <typeparam name="TVector">Vector type.</typeparam>
    public sealed class Path<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        public Path(params TVector[] points)
            : this(ShapeSettings<TPrimitive, TVector>.Default, new ReadOnlyArray<TVector>(points))
        {

        }

        public Path(ReadOnlyArray<TVector> points)
            : this(ShapeSettings<TPrimitive,TVector>.Default, points)
        {

        }

        public Path(ShapeSettings<TPrimitive, TVector> settings, ReadOnlyArray<TVector> points)
        {
            this.Settings = settings;
            this.Points = points;
            Bounds = VectorEnvelope<TVector>.FromList(points);
        }

        /// <summary>Coordinate space settings.</summary>
        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        /// <summary>Ordered list of points forming the path.</summary>
        public ReadOnlyArray<TVector> Points { get; }

        /// <summary>Axis-aligned bounding box of the path.</summary>
        public VectorEnvelope<TVector> Bounds { get; }

        /// <summary>Total length of the path in double precision.</summary>
        public double LengthD => Points.GetLengthD();

        /// <summary>Total length of the path in single precision.</summary>
        public float LengthF => Points.GetLengthF();

        /// <summary>First point of the path.</summary>
        public TVector First => Points[0];

        /// <summary>Last point of the path.</summary>
        public TVector Last => Points[Points.Count - 1];

        /// <summary>Returns <see langword="true"/> if the first and last points are equal.</summary>
        public bool IsClosed => First.Equals(Last);

        /// <summary>Returns <see langword="true"/> if the path is closed and its signed area is positive (counter-clockwise winding).</summary>
        public bool IsCounterClockWise => IsClosed && SignedArea<TPrimitive, TVector>.GetSignedAreaD(Points) > 0;

        /// <summary>Returns <see langword="true"/> if the path is closed and its signed area is negative (clockwise winding).</summary>
        public bool IsClockWise => IsClosed && SignedArea<TPrimitive, TVector>.GetSignedAreaD(Points) < 0;

        /// <summary>
        /// Buffers the path by <paramref name="width"/> to produce a polygon.
        /// <paramref name="width"/> is the full buffer width (i.e. half-width on each side).
        /// </summary>
        /// <param name="width">Total buffer width in vector units.</param>
        /// <param name="endType">How to cap the ends of the path.</param>
        /// <param name="joinType">How to join consecutive segments.</param>
        public MultiPolygon<TPrimitive, TVector> ToPolygon(double width, EndType endType = EndType.Butt, JoinType joinType = JoinType.Square)
        {
            var offset = new ClipperOffset();
            offset.AddPath(Settings.ToClipper(Points), joinType, endType);
            var solution = new PolyTree64(); ;
            offset.Execute(width * Settings.ScaleForClipper / 2, solution);
            return Settings.ToMultiPolygon(solution);
        }

        /// <summary>
        /// Create a polygon whose shell is the current path
        /// </summary>
        /// <returns></returns>
        public Polygon<TPrimitive, TVector> ToPolygonAsShell()
        {
            if (!IsClosed)
            {
                var points = new ReadOnlyArrayBuilder<TVector>(Points.Count + 1); 
                points.AddRange(Points);
                points.Add(Points[0]);
                return new Polygon<TPrimitive, TVector>(Settings, points.Build());
            }
            return new Polygon<TPrimitive, TVector>(Settings, Points);
        }

        /// <summary>Clips the path to the given bounding box. May return multiple sub-paths.</summary>
        public IEnumerable<Path<TPrimitive, TVector>> Crop(VectorEnvelope<TVector> rect)
        {
            var result = Clipper.RectClipLines(Settings.ToClipper(rect), Settings.ToClipper(Points));

            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        /// <summary>Clips the path to the given bounding box while preserving the original orientation of each sub-path.</summary>
        public IEnumerable<Path<TPrimitive, TVector>> CropKeepOrientation(VectorEnvelope<TVector> rect)
        {
            var result = PathClipperHelper.RectClipLinesKeepOrientation(Settings.ToClipper(rect), Settings.ToClipper(Points), IsClosed);

            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        /// <summary>Returns the minimum distance from <paramref name="point"/> to the nearest point on the path.</summary>
        public double Distance(TVector point)
        {
            return Points.NearestPointPath(point).Distance;
        }

        public TVector NearestPointBoundary(TVector point)
        {
            return Points.NearestPointPath(point).Point;
        }

        public (TVector Point, double Distance) NearestPointDistanceBoundary(TVector point)
        {
            return Points.NearestPointPath(point);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("LINESTRING ");
            ToStringHelper<TPrimitive, TVector>.ToStringAppend(sb, Points.AsSpan());
            return sb.ToString();
        }

        public Path<TPrimitive, TVector> ToReverse()
        {
            return new Path<TPrimitive, TVector>(Settings, Points.ToReverse());
        }

        public Path<TPrimitive, TVector> Simplify()
        {
            return new Path<TPrimitive, TVector>(Settings, Points.Simplify(Settings.NegligibleDistanceSquared));
        }

        public Path<TPrimitive, TVector> Simplify(double epsilon)
        {
            return new Path<TPrimitive, TVector>(Settings, Points.Simplify(epsilon * epsilon));
        }

        public IEnumerable<Path<TPrimitive, TVector>> Substract(Polygon<TPrimitive,TVector> polygon)
        {
            if (!Bounds.Intersects(polygon.Bounds))
            {
                return [this];
            }
            var result = PathClipperHelper.Difference(Settings.ToClipper(Points), polygon.ToClipper());
            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        public IEnumerable<Path<TPrimitive, TVector>> SubstractKeepOrientation(Polygon<TPrimitive, TVector> polygon)
        {
            if (!Bounds.Intersects(polygon.Bounds))
            {
                return [this];
            }
            var result = PathClipperHelper.DifferenceKeepOrientation(Settings.ToClipper(Points), polygon.ToClipper(), IsClosed);
            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        public IEnumerable<Path<TPrimitive, TVector>> Intersection(Polygon<TPrimitive, TVector> polygon)
        {
            if (!Bounds.Intersects(polygon.Bounds))
            {
                return Enumerable.Empty<Path<TPrimitive, TVector>>();
            }
            var result = PathClipperHelper.Intersection(Settings.ToClipper(Points), polygon.ToClipper());
            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        public IEnumerable<Path<TPrimitive, TVector>> IntersectionKeepOrientation(Polygon<TPrimitive, TVector> polygon)
        {
            if (!Bounds.Intersects(polygon.Bounds))
            {
                return Enumerable.Empty<Path<TPrimitive, TVector>>();
            }
            var result = PathClipperHelper.IntersectionKeepOrientation(Settings.ToClipper(Points), polygon.ToClipper(), IsClosed);
            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

        public IEnumerable<Path<TPrimitive, TVector>> SubstractAll(IEnumerable<Polygon<TPrimitive, TVector>> others)
        {
            var result = new List<Path<TPrimitive, TVector>>() { this };
            foreach (var other in others.Where(o => Bounds.Intersects(o.Bounds)))
            {
                var previousResult = result;
                result = new List<Path<TPrimitive, TVector>>();
                foreach (var subjet in previousResult)
                {
                    result.AddRange(subjet.Substract(other));
                }
            }
            return result;
        }

        public IEnumerable<Path<TPrimitive, TVector>> SubstractAllKeepOrientation(IEnumerable<Polygon<TPrimitive, TVector>> others)
        {
            var result = new List<Path<TPrimitive, TVector>>() { this };
            foreach (var other in others.Where(o => Bounds.Intersects(o.Bounds)))
            {
                var previousResult = result;
                result = new List<Path<TPrimitive, TVector>>();
                foreach (var subjet in previousResult)
                {
                    result.AddRange(subjet.SubstractKeepOrientation(other));
                }
            }
            return result;
        }

        public Path<TPrimitive, TVector> WithSettings(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (settings == Settings)
            {
                return this;
            }
            return new Path<TPrimitive, TVector>(settings, Points);
        }
    }
}
