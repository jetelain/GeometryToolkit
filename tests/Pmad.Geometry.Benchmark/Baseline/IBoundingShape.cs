using NetTopologySuite.Geometries;

namespace GameRealisticMap.Geometries
{
    public interface IBoundingShape : ITerrainEnvelope
    {
        TerrainPoint Center { get; }

        float Angle { get; }

        Polygon Poly { get; }
        TerrainPolygon Polygon { get; }
    }
}
