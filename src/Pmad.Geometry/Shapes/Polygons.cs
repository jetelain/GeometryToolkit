using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Polygon2I : PolygonBase<int, Vector2I, Polygon2I, Vector2IAlgorithms, Vector2IConvention>
    {
		public Polygon2I(IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2I(Vector2IConvention convention, IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2I(Vector2IConvention convention, IReadOnlyList<Vector2I> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2I CreatePolygon(IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2I This => this;
    }
    public sealed class Polygon2F : PolygonBase<float, Vector2F, Polygon2F, Vector2FAlgorithms, Vector2FConvention>
    {
		public Polygon2F(IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2F(Vector2FConvention convention, IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2F(Vector2FConvention convention, IReadOnlyList<Vector2F> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2F CreatePolygon(IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2F This => this;
    }
    public sealed class Polygon2L : PolygonBase<long, Vector2L, Polygon2L, Vector2LAlgorithms, Vector2LConvention>
    {
		public Polygon2L(IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2L(Vector2LConvention convention, IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2L(Vector2LConvention convention, IReadOnlyList<Vector2L> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2L CreatePolygon(IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2L This => this;
    }
    public sealed class Polygon2D : PolygonBase<double, Vector2D, Polygon2D, Vector2DAlgorithms, Vector2DConvention>
    {
		public Polygon2D(IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2D(Vector2DConvention convention, IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2D(Vector2DConvention convention, IReadOnlyList<Vector2D> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2D CreatePolygon(IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2D This => this;
    }
    public sealed class Polygon2IS : PolygonBase<int, Vector2IS, Polygon2IS, Vector2ISAlgorithms, Vector2ISConvention>
    {
		public Polygon2IS(IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2IS(Vector2ISConvention convention, IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2IS(Vector2ISConvention convention, IReadOnlyList<Vector2IS> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2IS CreatePolygon(IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2IS This => this;
    }
    public sealed class Polygon2FS : PolygonBase<float, Vector2FS, Polygon2FS, Vector2FSAlgorithms, Vector2FSConvention>
    {
		public Polygon2FS(IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2FS(Vector2FSConvention convention, IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2FS(Vector2FSConvention convention, IReadOnlyList<Vector2FS> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2FS CreatePolygon(IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2FS This => this;
    }
    public sealed class Polygon2LS : PolygonBase<long, Vector2LS, Polygon2LS, Vector2LSAlgorithms, Vector2LSConvention>
    {
		public Polygon2LS(IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2LS(Vector2LSConvention convention, IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2LS(Vector2LSConvention convention, IReadOnlyList<Vector2LS> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2LS CreatePolygon(IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2LS This => this;
    }
    public sealed class Polygon2DS : PolygonBase<double, Vector2DS, Polygon2DS, Vector2DSAlgorithms, Vector2DSConvention>
    {
		public Polygon2DS(IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2DS(Vector2DSConvention convention, IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2DS(Vector2DSConvention convention, IReadOnlyList<Vector2DS> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2DS CreatePolygon(IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2DS This => this;
    }
    public sealed class Polygon2FN : PolygonBase<float, Vector2FN, Polygon2FN, Vector2FNAlgorithms, Vector2FNConvention>
    {
		public Polygon2FN(IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
            : this(new(), shell, holes)
        {
        }
		
		public Polygon2FN(Vector2FNConvention convention, IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
            : base(convention, shell, holes)
        {
        }

		public Polygon2FN(Vector2FNConvention convention, IReadOnlyList<Vector2FN> shell)
            : base(convention, shell, NoHoles)
        {
        }

		protected override Polygon2FN CreatePolygon(IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
		{
			return new (Convention, shell, holes);
		}

		protected override Polygon2FN This => this;
    }
}
