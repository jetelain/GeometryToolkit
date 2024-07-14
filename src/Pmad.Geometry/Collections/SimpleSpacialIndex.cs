using System.Collections;
using System.Collections.Concurrent;
using System.Numerics;

namespace Pmad.Geometry.Collections
{
    internal class SimpleSpacialIndex<TPrimitive, TVector, TItem> : IEnumerable<TItem>
        where TPrimitive : unmanaged, IFloatingPointIeee754<TPrimitive>
        where TVector : struct, IVector<TVector>, IVector2<TPrimitive, TVector>, IVectorFP<TPrimitive, TVector>
        where TItem : class
    {
        private class DataNode
        {
            public readonly VectorEnvelope<TVector> range;
            public TItem? value;
            public bool isRemoved;

            public DataNode(TItem value, VectorEnvelope<TVector> range)
            {
                this.value = value;
                this.range = range;
            }
        }
        private class LockArea : IDisposable
        {
            public readonly VectorEnvelope<Vector2I> range;
            public readonly SimpleSpacialIndex<TPrimitive, TVector, TItem> owner;

            public LockArea(VectorEnvelope<Vector2I> range, SimpleSpacialIndex<TPrimitive, TVector, TItem> owner)
            {
                this.range = range;
                this.owner = owner;
            }

            public void Dispose()
            {
                lock (owner.locks)
                {
                    owner.locks.Remove(this);
                }
            }
        }

        private readonly List<DataNode>[,] cells;
        private ConcurrentQueue<DataNode> all = new ConcurrentQueue<DataNode>();
        private readonly List<LockArea> locks = new List<LockArea>();

        private readonly TVector origin;
        private readonly TVector cellSize;
        private readonly TVector maxCellIndex;
        private int removedCount = 0;

        public SimpleSpacialIndex(TVector origin, TVector size, int cellCount)
        {
            this.origin = origin;
            this.cellSize = size / cellCount;
            cells = new List<DataNode>[cellCount, cellCount];
            for (int x = 0; x < cellCount; ++x)
            {
                for (int y = 0; y < cellCount; ++y)
                {
                    cells[x, y] = new List<DataNode>();
                }
            }
            maxCellIndex = Vectors.Create<TPrimitive, TVector>(cellCount - 1, cellCount - 1);
        }

        public IEnumerable<TItem> Values => all.Where(a => !a.isRemoved).Select(a => a.value)!;

        public int Count => all.Count - removedCount;

        public bool TryLock(VectorEnvelope<TVector> lockRange, out IDisposable? cookie)
        {
            var p1 = TVector.Clamp((lockRange.Min - origin) / cellSize, default, maxCellIndex).FloorI();
            var p2 = TVector.Clamp((lockRange.Max - origin) / cellSize, default, maxCellIndex).CeilingI();
            var indexRange = new VectorEnvelope<Vector2I>(p1, p2);
            lock (locks)
            {
                if (locks.Any(a => a.range.Intersects(indexRange)))
                {
                    cookie = null;
                    return false;
                }
                var lockArea = new LockArea(indexRange, owner: this);
                cookie = lockArea;
                locks.Add(lockArea);
            }
            return true;
        }

        private IEnumerable<List<DataNode>> GetCells(VectorEnvelope<TVector> requested)
        {
            var p1 = TVector.Clamp((requested.Min - origin) / cellSize, default, maxCellIndex).FloorI();
            var p2 = TVector.Clamp((requested.Max - origin) / cellSize, default, maxCellIndex).CeilingI();
            for (int x = p1.X; x <= p2.X; ++x)
            {
                for (int y = p1.Y; y <= p2.Y; ++y)
                {
                    yield return cells[x, y];
                }
            }
        }

        public void Insert(TVector valuePosition, TItem value)
        {
            Insert(new VectorEnvelope<TVector>(valuePosition, valuePosition), value);
        }

        public void Insert(VectorEnvelope<TVector> valueRange, TItem value)
        {
            var node = new DataNode(value, valueRange);
            all.Enqueue(node);
            foreach (var cell in GetCells(valueRange))
            {
                cell.Add(node);
            }
        }

        public List<TItem> Search(VectorEnvelope<TVector> searchRange)
        {
            var result = new HashSet<DataNode>();

            foreach (var cell in GetCells(searchRange))
            {
                foreach (var node in cell)
                {
                    if (node.range.Intersects(searchRange) && !node.isRemoved)
                    {
                        result.Add(node);
                    }
                }
            }
            return result.Select(n => n.value!).ToList();
        }

        public void Remove(VectorEnvelope<TVector> valueRange, TItem obj)
        {
            DataNode? node = null;
            foreach (var cell in GetCells(valueRange))
            {
                if (node == null)
                {
                    node = cell.FirstOrDefault(n => n.value == obj);
                }
                if (node != null)
                {
                    cell.Remove(node);
                }
            }
            if (node != null)
            {
                node.isRemoved = true;
                node.value = default;
                Interlocked.Increment(ref removedCount);
            }
        }

        public void Compact()
        {
            if (removedCount > 0)
            {
                foreach (var cell in cells)
                {
                    cell.RemoveAll(n => n.isRemoved);
                }
                all = new ConcurrentQueue<DataNode>(all.Where(a => !a.isRemoved));
                removedCount = 0;
            }
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        public void Clear()
        {
            all.Clear();
            foreach (var list in cells)
            {
                list.Clear();
            }
            removedCount = 0;
        }
    }
}
