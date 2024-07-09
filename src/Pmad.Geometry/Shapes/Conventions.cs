using Clipper2Lib;
using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Vector2IConvention : Vector2ConventionBase<int, Vector2I, Polygon2I, Vector2IAlgorithms, Vector2IConvention>
    {
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
    public sealed class Vector2FConvention : Vector2ConventionBase<float, Vector2F, Polygon2F, Vector2FAlgorithms, Vector2FConvention>
    {
        private readonly float scale;

        public Vector2FConvention(float scale = 1000)
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
    public sealed class Vector2LConvention : Vector2ConventionBase<long, Vector2L, Polygon2L, Vector2LAlgorithms, Vector2LConvention>
    {
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
    public sealed class Vector2DConvention : Vector2ConventionBase<double, Vector2D, Polygon2D, Vector2DAlgorithms, Vector2DConvention>
    {
        private readonly double scale;

        public Vector2DConvention(double scale = 1000)
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
    public sealed class Vector2ISConvention : Vector2ConventionBase<int, Vector2IS, Polygon2IS, Vector2ISAlgorithms, Vector2ISConvention>
    {
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
    public sealed class Vector2FSConvention : Vector2ConventionBase<float, Vector2FS, Polygon2FS, Vector2FSAlgorithms, Vector2FSConvention>
    {
        private readonly float scale;

        public Vector2FSConvention(float scale = 1000)
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
    public sealed class Vector2LSConvention : Vector2ConventionBase<long, Vector2LS, Polygon2LS, Vector2LSAlgorithms, Vector2LSConvention>
    {
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
    public sealed class Vector2DSConvention : Vector2ConventionBase<double, Vector2DS, Polygon2DS, Vector2DSAlgorithms, Vector2DSConvention>
    {
        private readonly double scale;

        public Vector2DSConvention(double scale = 1000)
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
    public sealed class Vector2FNConvention : Vector2ConventionBase<float, Vector2FN, Polygon2FN, Vector2FNAlgorithms, Vector2FNConvention>
    {
        private readonly float scale;

        public Vector2FNConvention(float scale = 1000)
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
