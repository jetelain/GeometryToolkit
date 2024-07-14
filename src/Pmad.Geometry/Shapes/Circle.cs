using Pmad.Geometry.Algorithms;

namespace Pmad.Geometry.Shapes
{
    public class Circle<TPrimitive, TVector> : IWithBounds<TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        public VectorEnvelope<TVector> Bounds { get; }

        public TVector Center { get; }

        public double Radius { get; }

        public double AreaD => Math.PI * Radius * Radius;

        public ShapeSettings<TPrimitive, TVector> Settings { get; }

        public Circle(TVector center, double radius)
            : this(ShapeSettings<TPrimitive, TVector>.Default, center, radius)
        {

        }

        public Circle(ShapeSettings<TPrimitive, TVector> settings, TVector center, double radius)
        {
            Center = center;
            Radius = radius;
            Settings = settings;
            var radiusVector = Vectors.Create<TPrimitive, TVector>(radius, radius);
            Bounds = new (Vectors.Substract(center, radiusVector), Vectors.Add(center, radiusVector));
        }

        public bool IsInside(TVector point)
        {
            return Vectors.Substract(Center, point).LengthD() < Radius;
        }

        public bool IsInsideOrOnBoundary(TVector point)
        {
            return Vectors.Substract(Center, point).LengthD() <= Radius;
        }

        public bool Contains(TVector point) => IsInsideOrOnBoundary(point);

        public static Circle<TPrimitive, TVector> FromTwoPoints(ShapeSettings<TPrimitive, TVector> settings, TVector a, TVector b)
        {
            return new (settings, Vectors.Divide(Vectors.Add(b, a), 2), Vectors.Substract(b, a).LengthD() / 2);
        }

        public static Circle<TPrimitive, TVector> FromThreePoints(ShapeSettings<TPrimitive, TVector> settings, TVector a, TVector b, TVector c)
        {
            return AlgorithmsDispatcher.GetCircleFromThreePoints(settings, a, b, c);
        }

        private static Circle<TPrimitive, TVector> Create(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points)
        {
            switch (points.Count)
            {
                case 0:
                    return new Circle<TPrimitive, TVector>(settings, default, 0);

                case 1:
                    return new Circle<TPrimitive, TVector>(settings, points[0], 0);

                case 2:
                    return FromTwoPoints(settings, points[0], points[1]);

                case 3:
                    return FromThreePoints(settings, points[0], points[1], points[2]);

                default:
                    throw new ArgumentException();
            }
        }

        public static Circle<TPrimitive, TVector> CreateFromWelzl(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points)
        {
            var shuffle = points.OrderBy(_ => Random.Shared.NextDouble()).ToList();
            return CreateFromWelzl(settings, shuffle, new List<TVector>());
        }

        public static Circle<TPrimitive, TVector> CreateFromWelzlStable(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points)
        {
            return CreateFromWelzl(settings, points.ToList(), new List<TVector>());
        }

        private static Circle<TPrimitive, TVector> CreateFromWelzl(ShapeSettings<TPrimitive, TVector> settings, List<TVector> points, List<TVector> boundary)
        {
            if (points.Count == 0 || boundary.Count == 3)
            {
                return Create(settings, boundary);
            }

            var lastIndex = points.Count - 1;
            var removed = points[lastIndex];
            points.RemoveAt(lastIndex);

            var circle = CreateFromWelzl(settings, points, boundary);
            if (!circle.IsInsideOrOnBoundary(removed))
            {
                boundary.Add(removed);
                circle = CreateFromWelzl(settings, points, boundary);
                boundary.RemoveAt(boundary.Count - 1);
            }

            points.Add(removed);
            return circle;
        }

        public static Circle<TPrimitive, TVector> CreateFromRitter(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points)
        {
            return CreateFromRitter(settings, points, points[Random.Shared.Next(0, points.Count)]);
        }

        public static Circle<TPrimitive, TVector> CreateFromRitterStable(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points)
        {
            return CreateFromRitter(settings, points, points.OrderBy(e => e.LengthSquared()).First());
        }

        private static Circle<TPrimitive, TVector> CreateFromRitter(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points, TVector p)
        {
            var othersByDistance = points.Where(e => !e.Equals(p)).OrderByDescending(e => Vectors.Substract(e, p).LengthSquared()).ToList();
            var q = othersByDistance[0];
            var c = FromTwoPoints(settings, p, q);
            foreach (var e in othersByDistance.Skip(1))
            {
                if (!c.IsInsideOrOnBoundary(e))
                {
                    c = new (c.Center, Vectors.Substract(e, c.Center).LengthD());
                }
            }
            return c;
        }

        public static Circle<TPrimitive, TVector> GetSmallestContaining(IReadOnlyList<TVector> points, int attempts = 10)
        {
            return GetSmallestContaining(ShapeSettings<TPrimitive,TVector>.Default, points, attempts);
        }

        public static Circle<TPrimitive, TVector> GetSmallestContaining(ShapeSettings<TPrimitive, TVector> settings, IReadOnlyList<TVector> points, int attempts = 10)
        {
            if (points.Count < 4) // Trivial cases
            {
                return Create(settings, points);
            }
            bool canWelzl = points.Count < 4000; // May stackoverflow otherwise
            var result = CreateFromRitterStable(settings, points);
            if (canWelzl)
            {
                result = Min(result, CreateFromWelzlStable(settings, points));
            }
            for (int i = 0; i < attempts; ++i)
            {
                result = Min(result, CreateFromRitter(settings, points));
                if (canWelzl)
                {
                    result = Min(result, CreateFromWelzl(settings, points));
                }
            }
            return result;
        }

        private static Circle<TPrimitive, TVector> Min(Circle<TPrimitive, TVector> left, Circle<TPrimitive, TVector> right)
        {
            if (right.Radius < left.Radius)
            {
                return right;
            }
            return left;
        }
    }
}
