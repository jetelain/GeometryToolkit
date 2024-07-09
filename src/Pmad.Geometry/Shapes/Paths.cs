using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Path2I : PathBase<int, Vector2I, Polygon2I, Path2I, Vector2IAlgorithms, Vector2IConvention>
    {
		public Path2I(IReadOnlyList<Vector2I> points)
            : this(new(), points)
        {
        }
		
		public Path2I(Vector2IConvention convention, IReadOnlyList<Vector2I> points)
            : base(convention, points)
        {
        }

        protected override Path2I CreatePath(IReadOnlyList<Vector2I> points)
		{
			return new (Convention, points);
		}

		protected override Path2I This => this;
    }
    public sealed class Path2F : PathBase<float, Vector2F, Polygon2F, Path2F, Vector2FAlgorithms, Vector2FConvention>
    {
		public Path2F(IReadOnlyList<Vector2F> points)
            : this(new(), points)
        {
        }
		
		public Path2F(Vector2FConvention convention, IReadOnlyList<Vector2F> points)
            : base(convention, points)
        {
        }

        protected override Path2F CreatePath(IReadOnlyList<Vector2F> points)
		{
			return new (Convention, points);
		}

		protected override Path2F This => this;
    }
    public sealed class Path2L : PathBase<long, Vector2L, Polygon2L, Path2L, Vector2LAlgorithms, Vector2LConvention>
    {
		public Path2L(IReadOnlyList<Vector2L> points)
            : this(new(), points)
        {
        }
		
		public Path2L(Vector2LConvention convention, IReadOnlyList<Vector2L> points)
            : base(convention, points)
        {
        }

        protected override Path2L CreatePath(IReadOnlyList<Vector2L> points)
		{
			return new (Convention, points);
		}

		protected override Path2L This => this;
    }
    public sealed class Path2D : PathBase<double, Vector2D, Polygon2D, Path2D, Vector2DAlgorithms, Vector2DConvention>
    {
		public Path2D(IReadOnlyList<Vector2D> points)
            : this(new(), points)
        {
        }
		
		public Path2D(Vector2DConvention convention, IReadOnlyList<Vector2D> points)
            : base(convention, points)
        {
        }

        protected override Path2D CreatePath(IReadOnlyList<Vector2D> points)
		{
			return new (Convention, points);
		}

		protected override Path2D This => this;
    }
    public sealed class Path2IS : PathBase<int, Vector2IS, Polygon2IS, Path2IS, Vector2ISAlgorithms, Vector2ISConvention>
    {
		public Path2IS(IReadOnlyList<Vector2IS> points)
            : this(new(), points)
        {
        }
		
		public Path2IS(Vector2ISConvention convention, IReadOnlyList<Vector2IS> points)
            : base(convention, points)
        {
        }

        protected override Path2IS CreatePath(IReadOnlyList<Vector2IS> points)
		{
			return new (Convention, points);
		}

		protected override Path2IS This => this;
    }
    public sealed class Path2FS : PathBase<float, Vector2FS, Polygon2FS, Path2FS, Vector2FSAlgorithms, Vector2FSConvention>
    {
		public Path2FS(IReadOnlyList<Vector2FS> points)
            : this(new(), points)
        {
        }
		
		public Path2FS(Vector2FSConvention convention, IReadOnlyList<Vector2FS> points)
            : base(convention, points)
        {
        }

        protected override Path2FS CreatePath(IReadOnlyList<Vector2FS> points)
		{
			return new (Convention, points);
		}

		protected override Path2FS This => this;
    }
    public sealed class Path2LS : PathBase<long, Vector2LS, Polygon2LS, Path2LS, Vector2LSAlgorithms, Vector2LSConvention>
    {
		public Path2LS(IReadOnlyList<Vector2LS> points)
            : this(new(), points)
        {
        }
		
		public Path2LS(Vector2LSConvention convention, IReadOnlyList<Vector2LS> points)
            : base(convention, points)
        {
        }

        protected override Path2LS CreatePath(IReadOnlyList<Vector2LS> points)
		{
			return new (Convention, points);
		}

		protected override Path2LS This => this;
    }
    public sealed class Path2DS : PathBase<double, Vector2DS, Polygon2DS, Path2DS, Vector2DSAlgorithms, Vector2DSConvention>
    {
		public Path2DS(IReadOnlyList<Vector2DS> points)
            : this(new(), points)
        {
        }
		
		public Path2DS(Vector2DSConvention convention, IReadOnlyList<Vector2DS> points)
            : base(convention, points)
        {
        }

        protected override Path2DS CreatePath(IReadOnlyList<Vector2DS> points)
		{
			return new (Convention, points);
		}

		protected override Path2DS This => this;
    }
}
