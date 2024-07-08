
namespace Pmad.Geometry.Algorithms
{
    public sealed class PathFollowerVector2F : IPathFollower<float, Vector2F>
    {
        private readonly IEnumerator<Vector2F> enumerator;
        private Vector2F previousPoint;
        private Vector2F point;
        private Vector2F previousPosition;
        private Vector2F position;
        private Vector2F delta;
        private float length;
        private float positionOnSegment;
        private bool hasReachedEnd;
        private int index;

        public PathFollowerVector2F(IEnumerable<Vector2F> points, bool keepRightAngles = false)
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
            delta = point - previousPoint;
            length = delta.Length();
            positionOnSegment = default;
            return true;
        }

        public Vector2F Current => position;

        public Vector2F Previous => previousPosition;

        public Vector2F Vector => Vector2F.Normalize(delta);

        public bool KeepRightAngles { get; }

        public bool IsAfterRightAngle { get; private set; }

        public bool IsLast => hasReachedEnd;

        public bool IsFirst => index <= 1;

        /// <summary>
        /// Index in original list
        /// </summary>
        public int Index => index;

        public bool Move(float step)
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
                    if (position != previousPoint)
                    {
                        previousPosition = position;
                        position = previousPoint;
                        return true;
                    }
                    return false;
                }
                if (KeepRightAngles)
                {
                    var angle = Math.Abs(Math.Abs(Math.Acos(Vector2F.Dot(Vector2F.Normalize(delta), Vector2F.Normalize(previousDelta)))) - (Math.PI / 2));
                    if (angle < 0.1d && position != previousPoint)
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
            position = Vector2F.Lerp(previousPoint, point, positionOnSegment / length);
            return true;
        }
    }
    public sealed class PathFollowerVector2D : IPathFollower<double, Vector2D>
    {
        private readonly IEnumerator<Vector2D> enumerator;
        private Vector2D previousPoint;
        private Vector2D point;
        private Vector2D previousPosition;
        private Vector2D position;
        private Vector2D delta;
        private double length;
        private double positionOnSegment;
        private bool hasReachedEnd;
        private int index;

        public PathFollowerVector2D(IEnumerable<Vector2D> points, bool keepRightAngles = false)
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
            delta = point - previousPoint;
            length = delta.Length();
            positionOnSegment = default;
            return true;
        }

        public Vector2D Current => position;

        public Vector2D Previous => previousPosition;

        public Vector2D Vector => Vector2D.Normalize(delta);

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
                    if (position != previousPoint)
                    {
                        previousPosition = position;
                        position = previousPoint;
                        return true;
                    }
                    return false;
                }
                if (KeepRightAngles)
                {
                    var angle = Math.Abs(Math.Abs(Math.Acos(Vector2D.Dot(Vector2D.Normalize(delta), Vector2D.Normalize(previousDelta)))) - (Math.PI / 2));
                    if (angle < 0.1d && position != previousPoint)
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
            position = Vector2D.Lerp(previousPoint, point, positionOnSegment / length);
            return true;
        }
    }
    public sealed class PathFollowerVector2FS : IPathFollower<float, Vector2FS>
    {
        private readonly IEnumerator<Vector2FS> enumerator;
        private Vector2FS previousPoint;
        private Vector2FS point;
        private Vector2FS previousPosition;
        private Vector2FS position;
        private Vector2FS delta;
        private float length;
        private float positionOnSegment;
        private bool hasReachedEnd;
        private int index;

        public PathFollowerVector2FS(IEnumerable<Vector2FS> points, bool keepRightAngles = false)
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
            delta = point - previousPoint;
            length = delta.Length();
            positionOnSegment = default;
            return true;
        }

        public Vector2FS Current => position;

        public Vector2FS Previous => previousPosition;

        public Vector2FS Vector => Vector2FS.Normalize(delta);

        public bool KeepRightAngles { get; }

        public bool IsAfterRightAngle { get; private set; }

        public bool IsLast => hasReachedEnd;

        public bool IsFirst => index <= 1;

        /// <summary>
        /// Index in original list
        /// </summary>
        public int Index => index;

        public bool Move(float step)
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
                    if (position != previousPoint)
                    {
                        previousPosition = position;
                        position = previousPoint;
                        return true;
                    }
                    return false;
                }
                if (KeepRightAngles)
                {
                    var angle = Math.Abs(Math.Abs(Math.Acos(Vector2FS.Dot(Vector2FS.Normalize(delta), Vector2FS.Normalize(previousDelta)))) - (Math.PI / 2));
                    if (angle < 0.1d && position != previousPoint)
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
            position = Vector2FS.Lerp(previousPoint, point, positionOnSegment / length);
            return true;
        }
    }
    public sealed class PathFollowerVector2DS : IPathFollower<double, Vector2DS>
    {
        private readonly IEnumerator<Vector2DS> enumerator;
        private Vector2DS previousPoint;
        private Vector2DS point;
        private Vector2DS previousPosition;
        private Vector2DS position;
        private Vector2DS delta;
        private double length;
        private double positionOnSegment;
        private bool hasReachedEnd;
        private int index;

        public PathFollowerVector2DS(IEnumerable<Vector2DS> points, bool keepRightAngles = false)
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
            delta = point - previousPoint;
            length = delta.Length();
            positionOnSegment = default;
            return true;
        }

        public Vector2DS Current => position;

        public Vector2DS Previous => previousPosition;

        public Vector2DS Vector => Vector2DS.Normalize(delta);

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
                    if (position != previousPoint)
                    {
                        previousPosition = position;
                        position = previousPoint;
                        return true;
                    }
                    return false;
                }
                if (KeepRightAngles)
                {
                    var angle = Math.Abs(Math.Abs(Math.Acos(Vector2DS.Dot(Vector2DS.Normalize(delta), Vector2DS.Normalize(previousDelta)))) - (Math.PI / 2));
                    if (angle < 0.1d && position != previousPoint)
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
            position = Vector2DS.Lerp(previousPoint, point, positionOnSegment / length);
            return true;
        }
    }
}
