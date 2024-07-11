using Clipper2Lib;

namespace Pmad.Geometry.Shapes
{
    public sealed class Factory2I : ShapeFactoryBase<int, Vector2I, Polygon2I, Factory2I>
    {
        public static readonly Factory2I Default = new ();

        public override Vector2I FromClipper(Point64 value)
        {
            return new ((int)value.X, (int)value.Y);
        }

        public override Point64 ToClipper(Vector2I value)
        {
            return new (value.X, value.Y);
        }

        public override double ScaleForClipper => 1;
		public override Polygon2I CreatePolygon(IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2I CreatePolygon(IReadOnlyList<Vector2I> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2I> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2I.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2F : ShapeFactoryBase<float, Vector2F, Polygon2F, Factory2F>
    {
        public static readonly Factory2F Default = new ();

        private readonly float scale;

        public Factory2F(float scale = 1000)
        {
            this.scale = scale;
        }

        public override Vector2F FromClipper(Point64 value)
        {
            return new Vector2F(value.X, value.Y) / scale;
        }

        public override Point64 ToClipper(Vector2F value)
        {
            var scaled = value * scale;
            return new (scaled.X, scaled.Y);
        }
        
        public override double ScaleForClipper => scale;
		public override Polygon2F CreatePolygon(IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2F CreatePolygon(IReadOnlyList<Vector2F> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2F> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2F.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2L : ShapeFactoryBase<long, Vector2L, Polygon2L, Factory2L>
    {
        public static readonly Factory2L Default = new ();

        public override Vector2L FromClipper(Point64 value)
        {
            return new ((long)value.X, (long)value.Y);
        }

        public override Point64 ToClipper(Vector2L value)
        {
            return new (value.X, value.Y);
        }

        public override double ScaleForClipper => 1;
		public override Polygon2L CreatePolygon(IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2L CreatePolygon(IReadOnlyList<Vector2L> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2L> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2L.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2D : ShapeFactoryBase<double, Vector2D, Polygon2D, Factory2D>
    {
        public static readonly Factory2D Default = new ();

        private readonly double scale;

        public Factory2D(double scale = 1000)
        {
            this.scale = scale;
        }

        public override Vector2D FromClipper(Point64 value)
        {
            return new Vector2D(value.X, value.Y) / scale;
        }

        public override Point64 ToClipper(Vector2D value)
        {
            var scaled = value * scale;
            return new (scaled.X, scaled.Y);
        }
        
        public override double ScaleForClipper => scale;
		public override Polygon2D CreatePolygon(IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2D CreatePolygon(IReadOnlyList<Vector2D> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2D> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2D.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2IS : ShapeFactoryBase<int, Vector2IS, Polygon2IS, Factory2IS>
    {
        public static readonly Factory2IS Default = new ();

        public override Vector2IS FromClipper(Point64 value)
        {
            return new ((int)value.X, (int)value.Y);
        }

        public override Point64 ToClipper(Vector2IS value)
        {
            return new (value.X, value.Y);
        }

        public override double ScaleForClipper => 1;
		public override Polygon2IS CreatePolygon(IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2IS CreatePolygon(IReadOnlyList<Vector2IS> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2IS> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2IS.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2FS : ShapeFactoryBase<float, Vector2FS, Polygon2FS, Factory2FS>
    {
        public static readonly Factory2FS Default = new ();

        private readonly float scale;

        public Factory2FS(float scale = 1000)
        {
            this.scale = scale;
        }

        public override Vector2FS FromClipper(Point64 value)
        {
            return new Vector2FS(value.X, value.Y) / scale;
        }

        public override Point64 ToClipper(Vector2FS value)
        {
            var scaled = value * scale;
            return new (scaled.X, scaled.Y);
        }
        
        public override double ScaleForClipper => scale;
		public override Polygon2FS CreatePolygon(IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2FS CreatePolygon(IReadOnlyList<Vector2FS> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2FS> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2FS.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2LS : ShapeFactoryBase<long, Vector2LS, Polygon2LS, Factory2LS>
    {
        public static readonly Factory2LS Default = new ();

        public override Vector2LS FromClipper(Point64 value)
        {
            return new ((long)value.X, (long)value.Y);
        }

        public override Point64 ToClipper(Vector2LS value)
        {
            return new (value.X, value.Y);
        }

        public override double ScaleForClipper => 1;
		public override Polygon2LS CreatePolygon(IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2LS CreatePolygon(IReadOnlyList<Vector2LS> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2LS> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2LS.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2DS : ShapeFactoryBase<double, Vector2DS, Polygon2DS, Factory2DS>
    {
        public static readonly Factory2DS Default = new ();

        private readonly double scale;

        public Factory2DS(double scale = 1000)
        {
            this.scale = scale;
        }

        public override Vector2DS FromClipper(Point64 value)
        {
            return new Vector2DS(value.X, value.Y) / scale;
        }

        public override Point64 ToClipper(Vector2DS value)
        {
            var scaled = value * scale;
            return new (scaled.X, scaled.Y);
        }
        
        public override double ScaleForClipper => scale;
		public override Polygon2DS CreatePolygon(IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2DS CreatePolygon(IReadOnlyList<Vector2DS> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2DS> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2DS.FromClipper(this, polyTree64);
		}
    }
    public sealed class Factory2FN : ShapeFactoryBase<float, Vector2FN, Polygon2FN, Factory2FN>
    {
        public static readonly Factory2FN Default = new ();

        private readonly float scale;

        public Factory2FN(float scale = 1000)
        {
            this.scale = scale;
        }

        public override Vector2FN FromClipper(Point64 value)
        {
            return new Vector2FN(value.X, value.Y) / scale;
        }

        public override Point64 ToClipper(Vector2FN value)
        {
            var scaled = value * scale;
            return new (scaled.X, scaled.Y);
        }
        
        public override double ScaleForClipper => scale;
		public override Polygon2FN CreatePolygon(IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
		{
			return new (this, shell, holes);
		}
		
		public override Polygon2FN CreatePolygon(IReadOnlyList<Vector2FN> shell)
		{
			return new (this, shell);
		}

        internal override IEnumerable<Polygon2FN> FromClipper(PolyPath64 polyTree64)
		{
			return Polygon2FN.FromClipper(this, polyTree64);
		}
    }
}
