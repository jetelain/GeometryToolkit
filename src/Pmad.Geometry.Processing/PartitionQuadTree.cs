using System.Numerics;
using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Processing
{
    internal class PartitionQuadTree<TItem, TPrimitive, TVector> 
        where TVector : struct, IVector2<TPrimitive, TVector>
        where TItem : IWithBounds<TVector>
        where TPrimitive : unmanaged, INumber<TPrimitive>
    {
        private readonly VectorEnvelope<TVector> bounds;
        private readonly int partitionSize;

        internal int Count { get; private set; }

        internal int NodeCount => ListA != null ? (1 + ListA.NodeCount + ListB!.NodeCount + ListC!.NodeCount + ListD!.NodeCount) : 0;

        internal List<TItem> Main { get; private set; } = new List<TItem>();
        internal PartitionQuadTree<TItem, TPrimitive, TVector>? ListA { get; private set; }
        internal PartitionQuadTree<TItem, TPrimitive, TVector>? ListB { get; private set; }
        internal PartitionQuadTree<TItem, TPrimitive, TVector>? ListC { get; private set; }
        internal PartitionQuadTree<TItem, TPrimitive, TVector>? ListD { get; private set; }

        public PartitionQuadTree(VectorEnvelope<TVector> bounds, int partitionSize = 100)
        {
            this.bounds = bounds;
            this.partitionSize = partitionSize;
        }

        public void AddRange(List<TItem> itemList)
        {
            Count += itemList.Count;
            if (ListA == null)
            {
                if (itemList.Count + Main.Count >= partitionSize)
                {
                    TransformToQuadNode();
                }
            }
            if (ListA != null)
            {
                foreach (var item in itemList)
                {
                    Dispatch(item.Bounds, item);
                }
            }
            else
            {
                Main.AddRange(itemList);
            }
        }

        public void Add(TItem item)
        {
            Count++;
            if (ListA != null)
            {
                Dispatch(item.Bounds, item);
            }
            else if (Main.Count >= partitionSize)
            {
                TransformToQuadNode();
                Dispatch(item.Bounds, item);
            }
            else
            {
                Main.Add(item);
            }
        }

        private void Add(VectorEnvelope<TVector> itemBounds, TItem item)
        {
            Count++;
            if (ListA != null)
            {
                Dispatch(itemBounds, item);
            }
            else if (Main.Count >= partitionSize)
            {
                TransformToQuadNode();
                Dispatch(itemBounds, item);
            }
            else
            {
                Main.Add(item);
            }
        }

        private void Dispatch(VectorEnvelope<TVector> itemBounds, TItem item)
        {
            if (ListA!.bounds.Contains(itemBounds))
            {
                ListA.Add(itemBounds, item);
            }
            else if (ListB!.bounds.Contains(itemBounds))
            {
                ListB.Add(itemBounds, item);
            }
            else if (ListC!.bounds.Contains(itemBounds))
            {
                ListC.Add(itemBounds, item);
            }
            else if (ListD!.bounds.Contains(itemBounds))
            {
                ListD.Add(itemBounds, item);
            }
            else
            {
                Main.Add(item);
            }
        }

        private void TransformToQuadNode()
        {
            var mid = (bounds.Max + bounds.Min) / 2;
            ListA = new PartitionQuadTree<TItem, TPrimitive, TVector>(new VectorEnvelope<TVector>(bounds.Min, mid), partitionSize);
            ListB = new PartitionQuadTree<TItem, TPrimitive, TVector>(new VectorEnvelope<TVector>(TVector.Create(bounds.Min.X, mid.Y), TVector.Create(mid.X, bounds.Max.Y)), partitionSize);
            ListC = new PartitionQuadTree<TItem, TPrimitive, TVector>(new VectorEnvelope<TVector>(TVector.Create(mid.X, bounds.Min.Y), TVector.Create(bounds.Max.X, mid.Y)), partitionSize);
            ListD = new PartitionQuadTree<TItem, TPrimitive, TVector>(new VectorEnvelope<TVector>(mid, bounds.Max), partitionSize);
            var items = Main;
            Main = new List<TItem>();
            foreach (var item in items)
            {
                Dispatch(item.Bounds, item);
            }
        }
    }
}
