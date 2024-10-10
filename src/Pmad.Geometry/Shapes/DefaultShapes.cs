
namespace Pmad.Geometry.Shapes
{
    /// <summary>
    /// Default settings for each vector type, as syntax shortcut
    /// </summary>
    public static class DefaultShapes
    {
        /// <summary>
        /// Default settings for <see cref="Vector2I" />
        /// </summary>
		public static ShapeSettings<int,Vector2I> Vector2I => ShapeSettings<int,Vector2I>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2F" />
        /// </summary>
		public static ShapeSettings<float,Vector2F> Vector2F => ShapeSettings<float,Vector2F>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2L" />
        /// </summary>
		public static ShapeSettings<long,Vector2L> Vector2L => ShapeSettings<long,Vector2L>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2D" />
        /// </summary>
		public static ShapeSettings<double,Vector2D> Vector2D => ShapeSettings<double,Vector2D>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2IS" />
        /// </summary>
		internal static ShapeSettings<int,Vector2IS> Vector2IS => ShapeSettings<int,Vector2IS>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2FS" />
        /// </summary>
		internal static ShapeSettings<float,Vector2FS> Vector2FS => ShapeSettings<float,Vector2FS>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2LS" />
        /// </summary>
		internal static ShapeSettings<long,Vector2LS> Vector2LS => ShapeSettings<long,Vector2LS>.Default;

        /// <summary>
        /// Default settings for <see cref="Vector2DS" />
        /// </summary>
		internal static ShapeSettings<double,Vector2DS> Vector2DS => ShapeSettings<double,Vector2DS>.Default;

	}
}
