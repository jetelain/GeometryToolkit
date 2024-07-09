using Clipper2Lib;

namespace Pmad.Geometry.Algorithms
{
	public sealed class Vector2IAlgorithms : IVectorAlgorithms<int,Vector2I>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2I> points, Vector2I point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2I> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2I> points) => (float)points.GetSignedArea();

		public Vector2I Create(int x, int y) => new (x, y);

		public Vector2I Create(double x, double y) => new ((int)x, (int)y);
	}

	public sealed class Vector2FAlgorithms : IVectorFPAlgorithms<float,Vector2F>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2F> points, Vector2F point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2F> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2F> points) => (float)points.GetSignedArea();

		public IPathFollower<float,Vector2F> CreateFollower(IEnumerable<Vector2F> points) => new PathFollowerVector2F(points);

		public Vector2F Create(float x, float y) => new (x, y);

		public Vector2F Create(int x, int y) => new (x, y);

		public Vector2F Create(double x, double y) => new ((float)x, (float)y);
	}

	public sealed class Vector2LAlgorithms : IVectorAlgorithms<long,Vector2L>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2L> points, Vector2L point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2L> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2L> points) => (float)points.GetSignedArea();

		public Vector2L Create(long x, long y) => new (x, y);

		public Vector2L Create(int x, int y) => new (x, y);

		public Vector2L Create(double x, double y) => new ((long)x, (long)y);
	}

	public sealed class Vector2DAlgorithms : IVectorFPAlgorithms<double,Vector2D>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2D> points, Vector2D point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2D> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2D> points) => (float)points.GetSignedArea();

		public IPathFollower<double,Vector2D> CreateFollower(IEnumerable<Vector2D> points) => new PathFollowerVector2D(points);

		public Vector2D Create(double x, double y) => new (x, y);

		public Vector2D Create(int x, int y) => new (x, y);
	}

	public sealed class Vector2ISAlgorithms : IVectorAlgorithms<int,Vector2IS>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2IS> points, Vector2IS point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2IS> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2IS> points) => (float)points.GetSignedArea();

		public Vector2IS Create(int x, int y) => new (x, y);

		public Vector2IS Create(double x, double y) => new ((int)x, (int)y);
	}

	public sealed class Vector2FSAlgorithms : IVectorFPAlgorithms<float,Vector2FS>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2FS> points, Vector2FS point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2FS> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2FS> points) => (float)points.GetSignedArea();

		public IPathFollower<float,Vector2FS> CreateFollower(IEnumerable<Vector2FS> points) => new PathFollowerVector2FS(points);

		public Vector2FS Create(float x, float y) => new (x, y);

		public Vector2FS Create(int x, int y) => new (x, y);

		public Vector2FS Create(double x, double y) => new ((float)x, (float)y);
	}

	public sealed class Vector2LSAlgorithms : IVectorAlgorithms<long,Vector2LS>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2LS> points, Vector2LS point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2LS> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2LS> points) => (float)points.GetSignedArea();

		public Vector2LS Create(long x, long y) => new (x, y);

		public Vector2LS Create(int x, int y) => new (x, y);

		public Vector2LS Create(double x, double y) => new ((long)x, (long)y);
	}

	public sealed class Vector2DSAlgorithms : IVectorFPAlgorithms<double,Vector2DS>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2DS> points, Vector2DS point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2DS> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2DS> points) => (float)points.GetSignedArea();

		public IPathFollower<double,Vector2DS> CreateFollower(IEnumerable<Vector2DS> points) => new PathFollowerVector2DS(points);

		public Vector2DS Create(double x, double y) => new (x, y);

		public Vector2DS Create(int x, int y) => new (x, y);
	}

	public sealed class Vector2FNAlgorithms : IVectorFPAlgorithms<float,Vector2FN>
	{
		public PointInPolygonResult TestPointInPolygon(IReadOnlyList<Vector2FN> points, Vector2FN point) => points.TestPointInPolygon(point);
		
		public double GetSignedAreaD(IReadOnlyList<Vector2FN> points) => points.GetSignedArea();

		public float GetSignedAreaF(IReadOnlyList<Vector2FN> points) => (float)points.GetSignedArea();

		public IPathFollower<float,Vector2FN> CreateFollower(IEnumerable<Vector2FN> points) => new PathFollowerVector2FN(points);

		public Vector2FN Create(float x, float y) => new (x, y);

		public Vector2FN Create(int x, int y) => new (x, y);

		public Vector2FN Create(double x, double y) => new ((float)x, (float)y);
	}

}
