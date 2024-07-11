namespace Pmad.Geometry.Algorithms
{
    public sealed class PathFollower<TPrimitive,TVector>
        where TPrimitive : unmanaged
        where TVector : struct, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
    {
        private readonly IEnumerator<TVector> enumerator;
        private TVector previousPoint;
        private TVector point;
        private TVector previousPosition;
        private TVector position;
        private TVector delta;
        private double length;
        private double positionOnSegment;
        private bool hasReachedEnd;
        private int index;

        public PathFollower(IEnumerable<TVector> points, bool keepRightAngles = false)
        {
            enumerator = points.GetEnumerator();
            index = 0;
            KeepRightAngles = keepRightAngles;
            Init();
        }

        public void Reset()
        {
            enumerator.Reset();
            index = 0;
            Init();
        }

        private void Init()
        {
            IsAfterRightAngle = false;
            previousPosition = default;
            length = default;
            positionOnSegment = default;
            previousPoint = default;
            if (enumerator.MoveNext())
            {
                position = point = enumerator.Current;
                delta = default;
                hasReachedEnd = false;
                MoveNextPoint();
            }
            else
            {
                hasReachedEnd = true;
            }
        }

        private bool MoveNextPoint()
        {
            previousPoint = point;
            if (!enumerator.MoveNext())
            {
                point = default;
                length = default;
                positionOnSegment = default;
                return false;
            }
            index++;
            point = enumerator.Current;
            delta = point.Substract(previousPoint);
            length = delta.LengthD();
            positionOnSegment = default;
            return true;
        }

        public TVector Current => position;

        public TVector Previous => previousPosition;

        public TVector Vector => delta.Normalize();

        public bool KeepRightAngles { get; }

        public bool IsAfterRightAngle { get; private set; }

        public bool IsLast => hasReachedEnd;

        public bool IsFirst => index <= 1;

        /// <summary>
        /// Index in original list
        /// </summary>
        public int Index => index;

        public bool Move(double step)
        {
            if (IsAfterRightAngle)
            {
                index++;
            }
            IsAfterRightAngle = false;
            if (hasReachedEnd)
            {
                return false;
            }
            var remainLength = step;
            while (remainLength + positionOnSegment > length)
            {
                remainLength -= length - positionOnSegment;
                var previousDelta = delta;
                if (!MoveNextPoint())
                {
                    hasReachedEnd = true;
                    if (Vectors.NotEquals(position,previousPoint))
                    {
                        previousPosition = position;
                        position = previousPoint;
                        return true;
                    }
                    return false;
                }
                if (KeepRightAngles)
                {
                    var angle = Math.Abs(Math.Abs(Math.Acos(Vectors.DotD<TPrimitive, TVector>(delta.Normalize(), previousDelta.Normalize()))) - (Math.PI / 2));
                    if (angle < 0.1d && Vectors.NotEquals(position, previousPoint))
                    {
                        index--;
                        previousPosition = position;
                        position = previousPoint;
                        positionOnSegment = 0;
                        IsAfterRightAngle = true;
                        return true;
                    }
                }
            }
            positionOnSegment += remainLength;
            previousPosition = position;
            position = Vectors.Lerp<TPrimitive,TVector>(previousPoint, point, positionOnSegment / length);
            return true;
        }
    }
}
