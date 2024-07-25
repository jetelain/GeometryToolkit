using System.Numerics;
using Pmad.Geometry.Collections;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Json
{
    public struct Coordinates<TPrimitive, TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
        where TVector : struct, IVector2<TPrimitive, TVector>
    {
        private readonly object? coordinates;

        internal Coordinates(object? coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(TVector coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(Path<TPrimitive, TVector> coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(Polygon<TPrimitive, TVector> coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(MultiPolygon<TPrimitive, TVector> coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(IReadOnlyList<Path<TPrimitive, TVector>> coordinates)
        {
            this.coordinates = coordinates;
        }

        public Coordinates(IReadOnlyList<TVector> coordinates)
        {
            this.coordinates = coordinates;
        }

        internal object? Value => coordinates;

        public TVector AsPoint()
        {
            if (coordinates is TVector data)
            {
                return data;
            }
            return default;
        }

        public Path<TPrimitive, TVector>? AsLineString()
        {
            return AsLineString(ShapeSettings<TPrimitive, TVector>.Default);
        }

        public Path<TPrimitive, TVector>? AsLineString(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (coordinates is ReadOnlyArray<TVector> data)
            {
                return new Path<TPrimitive, TVector>(settings, data);
            }
            return (coordinates as Path<TPrimitive, TVector>)?.WithSettings(settings);
        }

        public Polygon<TPrimitive, TVector>? AsPolygon()
        {
            return AsPolygon(ShapeSettings<TPrimitive, TVector>.Default);
        }

        public Polygon<TPrimitive, TVector>? AsPolygon(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (coordinates is ReadOnlyArray<ReadOnlyArray<TVector>> data)
            {
                return new Polygon<TPrimitive, TVector>(settings, data[0], data.Skip(1).ToReadOnlyArray());
            }
            return (coordinates as Polygon<TPrimitive, TVector>)?.WithSettings(settings);
        }

        public IReadOnlyList<TVector> AsMultiPoint()
        {
            if (coordinates is ReadOnlyArray<TVector> multi)
            {
                return multi;
            }
            return (coordinates as IReadOnlyList<TVector>) ?? new List<TVector>();
        }

        public IReadOnlyList<Path<TPrimitive, TVector>>? AsMultiLineString()
        {
            return AsMultiLineString(ShapeSettings<TPrimitive, TVector>.Default);
        }

        public IReadOnlyList<Path<TPrimitive, TVector>> AsMultiLineString(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (coordinates is ReadOnlyArray<ReadOnlyArray<TVector>> multi)
            {
                return multi.Select(data => new Path<TPrimitive, TVector>(settings, data)).ToArray();
            }
            var paths = coordinates as IReadOnlyList<Path<TPrimitive, TVector>>;
            if (paths != null)
            {
                return paths.Select(p => p.WithSettings(settings)).ToList();
            }
            return new List<Path<TPrimitive, TVector>>();
        }

        public MultiPolygon<TPrimitive, TVector>? AsMultiPolygon()
        {
            return AsMultiPolygon(ShapeSettings<TPrimitive, TVector>.Default);
        }

        public MultiPolygon<TPrimitive, TVector> AsMultiPolygon(ShapeSettings<TPrimitive, TVector> settings)
        {
            if (coordinates is ReadOnlyArray<ReadOnlyArray<ReadOnlyArray<TVector>>> data)
            {
                return new MultiPolygon<TPrimitive, TVector>(data.Select(p => new Polygon<TPrimitive, TVector>(settings, p[0], p.Skip(1).ToReadOnlyArray())).ToList());
            }
            return (coordinates as MultiPolygon<TPrimitive, TVector>)?.WithSettings(settings) ?? MultiPolygon<TPrimitive, TVector>.Empty;
        }

    }
}
