using Pmad.Geometry.Shapes;

namespace Pmad.Geometry.Processing.Test
{
    public class PartitionQuadTreeTest
    {
        private readonly Vector2I Min = new Vector2I(0, 0);
        private readonly Vector2I Max = new Vector2I(100, 100);

        private readonly Path<int, Vector2I> ItemA = new Path<int, Vector2I>(new Vector2I(10, 10), new Vector2I(40, 40));
        private readonly Path<int, Vector2I> ItemAA = new Path<int, Vector2I>(new Vector2I(10, 10), new Vector2I(20, 20));
        private readonly Path<int, Vector2I> ItemAB = new Path<int, Vector2I>(new Vector2I(10, 30), new Vector2I(20, 40));
        private readonly Path<int, Vector2I> ItemAD = new Path<int, Vector2I>(new Vector2I(30, 30), new Vector2I(40, 40));

        private readonly Path<int, Vector2I> ItemB = new Path<int, Vector2I>(new Vector2I(10, 60), new Vector2I(40, 90));

        private readonly Path<int, Vector2I> ItemC = new Path<int, Vector2I>(new Vector2I(60, 10), new Vector2I(90, 40));

        private readonly Path<int, Vector2I> ItemD = new Path<int, Vector2I>(new Vector2I(60, 60), new Vector2I(90, 90));
        private readonly Path<int, Vector2I> ItemDA = new Path<int, Vector2I>(new Vector2I(60, 60), new Vector2I(70, 70));
        private readonly Path<int, Vector2I> ItemDB = new Path<int, Vector2I>(new Vector2I(60, 80), new Vector2I(70, 90));
        private readonly Path<int, Vector2I> ItemDD = new Path<int, Vector2I>(new Vector2I(80, 80), new Vector2I(90, 90));

        private readonly Path<int, Vector2I> ItemE = new Path<int, Vector2I>(new Vector2I(40, 40), new Vector2I(60, 60));

        [Fact]
        public void Add_TopLevel()
        {
            var tree = new PartitionQuadTree<Path<int, Vector2I>, int, Vector2I>(new VectorEnvelope<Vector2I>(Min,Max), 2);

            tree.Add(ItemA);
            Assert.Equal(1, tree.Count);
            Assert.Equal(0, tree.NodeCount);
            Assert.Equal([ItemA], tree.Main);
            Assert.Null(tree.ListA);
            Assert.Null(tree.ListB);
            Assert.Null(tree.ListC);
            Assert.Null(tree.ListD);

            tree.Add(ItemB);
            Assert.Equal(2, tree.Count);
            Assert.Equal(0, tree.NodeCount);
            Assert.Equal([ItemA, ItemB], tree.Main);
            Assert.Null(tree.ListA);
            Assert.Null(tree.ListB);
            Assert.Null(tree.ListC);
            Assert.Null(tree.ListD);

            tree.Add(ItemC);
            Assert.Equal(3, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([], tree.ListD!.Main);

            tree.Add(ItemD);
            Assert.Equal(4, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.Add(ItemE);
            Assert.Equal(5, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);
        }


        [Fact]
        public void Add_Nested()
        {
            var tree = new PartitionQuadTree<Path<int, Vector2I>, int, Vector2I>(new VectorEnvelope<Vector2I>(Min, Max), 2);

            tree.Add(ItemA);
            tree.Add(ItemB);
            tree.Add(ItemC);
            tree.Add(ItemD);
            tree.Add(ItemE);
            Assert.Equal(5, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.Add(ItemAA);
            Assert.Equal(6, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA, ItemAA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.Add(ItemAB);
            Assert.Equal(7, tree.Count);
            Assert.Equal(2, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemAA], tree.ListA!.ListA!.Main);
            Assert.Equal([ItemAB], tree.ListA!.ListB!.Main);
            Assert.Equal([], tree.ListA!.ListD!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.Add(ItemAD);
            Assert.Equal(8, tree.Count);
            Assert.Equal(2, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemAA], tree.ListA!.ListA!.Main);
            Assert.Equal([ItemAB], tree.ListA!.ListB!.Main);
            Assert.Equal([ItemAD], tree.ListA!.ListD!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.Add(ItemDA);
            tree.Add(ItemDB);
            tree.Add(ItemDD);

            Assert.Equal(11, tree.Count);
            Assert.Equal(3, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);

            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemAA], tree.ListA!.ListA!.Main);
            Assert.Equal([ItemAB], tree.ListA!.ListB!.Main);
            Assert.Equal([ItemAD], tree.ListA!.ListD!.Main);

            Assert.Equal([ItemB], tree.ListB!.Main);

            Assert.Equal([ItemC], tree.ListC!.Main);

            Assert.Equal([ItemD], tree.ListD!.Main);
            Assert.Equal([ItemDA], tree.ListD!.ListA!.Main);
            Assert.Equal([ItemDB], tree.ListD!.ListB!.Main);
            Assert.Equal([ItemDD], tree.ListD!.ListD!.Main);
        }

        [Fact]
        public void AddRange_TopLevel()
        {
            var tree = new PartitionQuadTree<Path<int, Vector2I>, int, Vector2I>(new VectorEnvelope<Vector2I>(Min, Max), 2);

            tree.AddRange([ItemA]);
            Assert.Equal(1, tree.Count);
            Assert.Equal(0, tree.NodeCount);
            Assert.Equal([ItemA], tree.Main);
            Assert.Null(tree.ListA);
            Assert.Null(tree.ListB);
            Assert.Null(tree.ListC);
            Assert.Null(tree.ListD);

            tree.AddRange([ItemB]);
            Assert.Equal(2, tree.Count);
            Assert.Equal(0, tree.NodeCount);
            Assert.Equal([ItemA, ItemB], tree.Main);
            Assert.Null(tree.ListA);
            Assert.Null(tree.ListB);
            Assert.Null(tree.ListC);
            Assert.Null(tree.ListD);

            tree.AddRange([ItemC]);
            Assert.Equal(3, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([], tree.ListD!.Main);

            tree.AddRange([ItemD]);
            Assert.Equal(4, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);

            tree.AddRange([ItemE]);
            Assert.Equal(5, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);
        }

        [Fact]
        public void AddRange_Nested()
        {
            var tree = new PartitionQuadTree<Path<int, Vector2I>, int, Vector2I>(new VectorEnvelope<Vector2I>(Min, Max), 2);

            tree.AddRange([ItemA, ItemB, ItemC, ItemD, ItemE]);
            Assert.Equal(5, tree.Count);
            Assert.Equal(1, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);
            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemB], tree.ListB!.Main);
            Assert.Equal([ItemC], tree.ListC!.Main);
            Assert.Equal([ItemD], tree.ListD!.Main);


            tree.AddRange([ItemAA, ItemAB, ItemAD, ItemDA, ItemDB, ItemDD]);

            Assert.Equal(11, tree.Count);
            Assert.Equal(3, tree.NodeCount);
            Assert.Equal([ItemE], tree.Main);

            Assert.Equal([ItemA], tree.ListA!.Main);
            Assert.Equal([ItemAA], tree.ListA!.ListA!.Main);
            Assert.Equal([ItemAB], tree.ListA!.ListB!.Main);
            Assert.Equal([ItemAD], tree.ListA!.ListD!.Main);

            Assert.Equal([ItemB], tree.ListB!.Main);

            Assert.Equal([ItemC], tree.ListC!.Main);

            Assert.Equal([ItemD], tree.ListD!.Main);
            Assert.Equal([ItemDA], tree.ListD!.ListA!.Main);
            Assert.Equal([ItemDB], tree.ListD!.ListB!.Main);
            Assert.Equal([ItemDD], tree.ListD!.ListD!.Main);
        }
    }
}
