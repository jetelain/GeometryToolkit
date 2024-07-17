﻿using System.Numerics;
using System.Text;
using Clipper2Lib;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
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

        public ShapeSettings<TPrimitive, TVector> Settings { get; }
        
        public ReadOnlyArray<TVector> Points { get; }

        public VectorEnvelope<TVector> Bounds { get; }

        public double LengthD => Points.GetLengthD();

        public float LengthF => Points.GetLengthF();

        public TVector First => Points[0];

        public TVector Last => Points[Points.Count - 1];

        public bool IsClosed => First.Equals(Last);

        public bool IsCounterClockWise => IsClosed && SignedArea<TPrimitive, TVector>.GetSignedAreaD(Points) > 0;

        public bool IsClockWise => IsClosed && SignedArea<TPrimitive, TVector>.GetSignedAreaD(Points) < 0;

        public IEnumerable<Polygon<TPrimitive, TVector>> ToPolygon(double width, EndType endType = EndType.Butt, JoinType joinType = JoinType.Square)
        {
            var offset = new ClipperOffset();
            offset.AddPath(Settings.ToClipper(Points), joinType, endType);
            var solution = new PolyTree64(); ;
            offset.Execute(width * Settings.ScaleForClipper / 2, solution);
            return Settings.FromClipper(solution);
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

        public IEnumerable<Path<TPrimitive, TVector>> ClippedBy(VectorEnvelope<TVector> rect)
        {
            var result = Clipper.RectClipLines(Settings.ToClipper(rect), Settings.ToClipper(Points));

            return result.Select(r => new Path<TPrimitive, TVector>(Settings, Settings.FromClipper(r)));
        }

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
    }
}
