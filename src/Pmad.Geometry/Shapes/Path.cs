﻿using Clipper2Lib;
using Pmad.Geometry.Algorithms;
using Pmad.Geometry.Collections;

namespace Pmad.Geometry.Shapes
{
    public sealed class Path<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
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

        public bool IsCounterClockWise => IsClosed && Points.GetSignedAreaD() > 0;

        public bool IsClockWise => IsClosed && Points.GetSignedAreaD() < 0;

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
    }
}