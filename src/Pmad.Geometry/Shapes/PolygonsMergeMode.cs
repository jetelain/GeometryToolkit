namespace Pmad.Geometry.Shapes
{
    public enum PolygonsMergeMode
    {
        /// <summary>
        /// Polygons will tends to form large areas that will merge together. Like forests on a map.
        /// </summary>
        LargeConnected,

        /// <summary>
        /// Polygons will not tends to form large areas. Like buildings on a map.
        /// </summary>
        SmallIsolated
    }
}
