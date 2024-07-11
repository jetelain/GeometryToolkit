using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public sealed class Polygon2I : PolygonBase<int, Vector2I, Polygon2I, Factory2I>
    {
		public Polygon2I(IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
            : this(Factory2I.Default, shell, holes)
        {
        }
		
		public Polygon2I(Factory2I factory, IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2I(Factory2I factory, IReadOnlyList<Vector2I> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2I CreatePolygon(IReadOnlyList<Vector2I> shell, IReadOnlyList<IReadOnlyList<Vector2I>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2I This => this;
    }
    public sealed class Polygon2F : PolygonBase<float, Vector2F, Polygon2F, Factory2F>
    {
		public Polygon2F(IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
            : this(Factory2F.Default, shell, holes)
        {
        }
		
		public Polygon2F(Factory2F factory, IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2F(Factory2F factory, IReadOnlyList<Vector2F> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2F CreatePolygon(IReadOnlyList<Vector2F> shell, IReadOnlyList<IReadOnlyList<Vector2F>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2F This => this;
    }
    public sealed class Polygon2L : PolygonBase<long, Vector2L, Polygon2L, Factory2L>
    {
		public Polygon2L(IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
            : this(Factory2L.Default, shell, holes)
        {
        }
		
		public Polygon2L(Factory2L factory, IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2L(Factory2L factory, IReadOnlyList<Vector2L> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2L CreatePolygon(IReadOnlyList<Vector2L> shell, IReadOnlyList<IReadOnlyList<Vector2L>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2L This => this;
    }
    public sealed class Polygon2D : PolygonBase<double, Vector2D, Polygon2D, Factory2D>
    {
		public Polygon2D(IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
            : this(Factory2D.Default, shell, holes)
        {
        }
		
		public Polygon2D(Factory2D factory, IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2D(Factory2D factory, IReadOnlyList<Vector2D> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2D CreatePolygon(IReadOnlyList<Vector2D> shell, IReadOnlyList<IReadOnlyList<Vector2D>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2D This => this;
    }
    public sealed class Polygon2IS : PolygonBase<int, Vector2IS, Polygon2IS, Factory2IS>
    {
		public Polygon2IS(IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
            : this(Factory2IS.Default, shell, holes)
        {
        }
		
		public Polygon2IS(Factory2IS factory, IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2IS(Factory2IS factory, IReadOnlyList<Vector2IS> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2IS CreatePolygon(IReadOnlyList<Vector2IS> shell, IReadOnlyList<IReadOnlyList<Vector2IS>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2IS This => this;
    }
    public sealed class Polygon2FS : PolygonBase<float, Vector2FS, Polygon2FS, Factory2FS>
    {
		public Polygon2FS(IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
            : this(Factory2FS.Default, shell, holes)
        {
        }
		
		public Polygon2FS(Factory2FS factory, IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2FS(Factory2FS factory, IReadOnlyList<Vector2FS> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2FS CreatePolygon(IReadOnlyList<Vector2FS> shell, IReadOnlyList<IReadOnlyList<Vector2FS>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2FS This => this;
    }
    public sealed class Polygon2LS : PolygonBase<long, Vector2LS, Polygon2LS, Factory2LS>
    {
		public Polygon2LS(IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
            : this(Factory2LS.Default, shell, holes)
        {
        }
		
		public Polygon2LS(Factory2LS factory, IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2LS(Factory2LS factory, IReadOnlyList<Vector2LS> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2LS CreatePolygon(IReadOnlyList<Vector2LS> shell, IReadOnlyList<IReadOnlyList<Vector2LS>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2LS This => this;
    }
    public sealed class Polygon2DS : PolygonBase<double, Vector2DS, Polygon2DS, Factory2DS>
    {
		public Polygon2DS(IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
            : this(Factory2DS.Default, shell, holes)
        {
        }
		
		public Polygon2DS(Factory2DS factory, IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2DS(Factory2DS factory, IReadOnlyList<Vector2DS> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2DS CreatePolygon(IReadOnlyList<Vector2DS> shell, IReadOnlyList<IReadOnlyList<Vector2DS>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2DS This => this;
    }
    public sealed class Polygon2FN : PolygonBase<float, Vector2FN, Polygon2FN, Factory2FN>
    {
		public Polygon2FN(IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
            : this(Factory2FN.Default, shell, holes)
        {
        }
		
		public Polygon2FN(Factory2FN factory, IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
            : base(factory, shell, holes)
        {
        }

		public Polygon2FN(Factory2FN factory, IReadOnlyList<Vector2FN> shell)
            : base(factory, shell, NoHoles)
        {
        }

		protected override Polygon2FN CreatePolygon(IReadOnlyList<Vector2FN> shell, IReadOnlyList<IReadOnlyList<Vector2FN>> holes)
		{
			return new (Factory, shell, holes);
		}

		protected override Polygon2FN This => this;
    }
}
