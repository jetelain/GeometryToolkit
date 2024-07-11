using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Path2I : PathBase<int, Vector2I, Polygon2I, Path2I, Factory2I>
    {
		public Path2I(IReadOnlyList<Vector2I> points)
            : this(Factory2I.Default, points)
        {
        }
		
		public Path2I(Factory2I factory, IReadOnlyList<Vector2I> points)
            : base(factory, points)
        {
        }

        protected override Path2I CreatePath(IReadOnlyList<Vector2I> points)
		{
			return new (Factory, points);
		}

		protected override Path2I This => this;
    }
    public sealed class Path2F : PathBase<float, Vector2F, Polygon2F, Path2F, Factory2F>
    {
		public Path2F(IReadOnlyList<Vector2F> points)
            : this(Factory2F.Default, points)
        {
        }
		
		public Path2F(Factory2F factory, IReadOnlyList<Vector2F> points)
            : base(factory, points)
        {
        }

        protected override Path2F CreatePath(IReadOnlyList<Vector2F> points)
		{
			return new (Factory, points);
		}

		protected override Path2F This => this;
    }
    public sealed class Path2L : PathBase<long, Vector2L, Polygon2L, Path2L, Factory2L>
    {
		public Path2L(IReadOnlyList<Vector2L> points)
            : this(Factory2L.Default, points)
        {
        }
		
		public Path2L(Factory2L factory, IReadOnlyList<Vector2L> points)
            : base(factory, points)
        {
        }

        protected override Path2L CreatePath(IReadOnlyList<Vector2L> points)
		{
			return new (Factory, points);
		}

		protected override Path2L This => this;
    }
    public sealed class Path2D : PathBase<double, Vector2D, Polygon2D, Path2D, Factory2D>
    {
		public Path2D(IReadOnlyList<Vector2D> points)
            : this(Factory2D.Default, points)
        {
        }
		
		public Path2D(Factory2D factory, IReadOnlyList<Vector2D> points)
            : base(factory, points)
        {
        }

        protected override Path2D CreatePath(IReadOnlyList<Vector2D> points)
		{
			return new (Factory, points);
		}

		protected override Path2D This => this;
    }
    public sealed class Path2IS : PathBase<int, Vector2IS, Polygon2IS, Path2IS, Factory2IS>
    {
		public Path2IS(IReadOnlyList<Vector2IS> points)
            : this(Factory2IS.Default, points)
        {
        }
		
		public Path2IS(Factory2IS factory, IReadOnlyList<Vector2IS> points)
            : base(factory, points)
        {
        }

        protected override Path2IS CreatePath(IReadOnlyList<Vector2IS> points)
		{
			return new (Factory, points);
		}

		protected override Path2IS This => this;
    }
    public sealed class Path2FS : PathBase<float, Vector2FS, Polygon2FS, Path2FS, Factory2FS>
    {
		public Path2FS(IReadOnlyList<Vector2FS> points)
            : this(Factory2FS.Default, points)
        {
        }
		
		public Path2FS(Factory2FS factory, IReadOnlyList<Vector2FS> points)
            : base(factory, points)
        {
        }

        protected override Path2FS CreatePath(IReadOnlyList<Vector2FS> points)
		{
			return new (Factory, points);
		}

		protected override Path2FS This => this;
    }
    public sealed class Path2LS : PathBase<long, Vector2LS, Polygon2LS, Path2LS, Factory2LS>
    {
		public Path2LS(IReadOnlyList<Vector2LS> points)
            : this(Factory2LS.Default, points)
        {
        }
		
		public Path2LS(Factory2LS factory, IReadOnlyList<Vector2LS> points)
            : base(factory, points)
        {
        }

        protected override Path2LS CreatePath(IReadOnlyList<Vector2LS> points)
		{
			return new (Factory, points);
		}

		protected override Path2LS This => this;
    }
    public sealed class Path2DS : PathBase<double, Vector2DS, Polygon2DS, Path2DS, Factory2DS>
    {
		public Path2DS(IReadOnlyList<Vector2DS> points)
            : this(Factory2DS.Default, points)
        {
        }
		
		public Path2DS(Factory2DS factory, IReadOnlyList<Vector2DS> points)
            : base(factory, points)
        {
        }

        protected override Path2DS CreatePath(IReadOnlyList<Vector2DS> points)
		{
			return new (Factory, points);
		}

		protected override Path2DS This => this;
    }
    public sealed class Path2FN : PathBase<float, Vector2FN, Polygon2FN, Path2FN, Factory2FN>
    {
		public Path2FN(IReadOnlyList<Vector2FN> points)
            : this(Factory2FN.Default, points)
        {
        }
		
		public Path2FN(Factory2FN factory, IReadOnlyList<Vector2FN> points)
            : base(factory, points)
        {
        }

        protected override Path2FN CreatePath(IReadOnlyList<Vector2FN> points)
		{
			return new (Factory, points);
		}

		protected override Path2FN This => this;
    }
}
