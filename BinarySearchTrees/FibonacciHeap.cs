using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class FibonacciHeap : Heap<FibonacciHeapNode>
    {
        public FibonacciHeapNode root = null; // min

        public FibonacciHeap() {}

        override public IEnumerable<FibonacciHeapNode> Trees() => root == null? new List<FibonacciHeapNode>() : root.Siblings();
        override public FibonacciHeapNode Root() => root;

        override public void Include(int key)
        {
            Include(new FibonacciHeapNode(key));
        }

        public void Include(FibonacciHeapNode node)
        {
            if (root == null)
                root = node;
            else
                root = root.AddLeft(node);
        }

        public void Merge(FibonacciHeap heap)
        {
            if (root == null)
                root = heap.root;
            else
                root = root.AddLeft(heap.root);
        }

        override public int PopMin()
        {
            var oldRoot = root;
            if (root == null)
                throw new Exception("Empty heap has no min!");
            foreach (var child in root.Children())
                child.parent = null;
            var newRoot = root.Remove();
            if (newRoot == null) // single root
                root = root.child;
            else
            {
                root = newRoot;
                if (oldRoot.child != null)
                {
                    root.AddLeft(oldRoot.child);
                }
                Consolidate();
            }
            return oldRoot.key;
        }

        override public void DecreaseKey(FibonacciHeapNode node, int newKey)
        {
            if (node.key < newKey)
                throw new Exception(string.Format("new key {0} > old key {1} of {2}", newKey, node.key, node));
            else if (node.key > newKey)
            {
                node.key = newKey;
                var parent = node.parent;
                if (parent != null && newKey < parent.key)
                {
                    Cut(node);
                    CascadingCut(parent);
                }
            }
            root = Trees().Min();
        }

        override public void Delete(FibonacciHeapNode node)
        {
            DecreaseKey(node, int.MinValue);
            PopMin();
        }

        /* Merge trees with the same degree */
        void Consolidate()
        {
            int maxDegree = (int) Math.Ceiling(Math.Log(Trees().Sum(t => 2 ^ t.degree)) / Math.Log(2));
            // root trees with degrees 0, 1..
            var fixedTrees = Enumerable.Repeat<FibonacciHeapNode>(null, 2 + maxDegree).ToList();
            var trees = Trees().ToList();
            foreach(var node in trees)
            {
                node.Remove();
                var tree = node;
                // merge until empty cell found
                while (fixedTrees[tree.degree] != null)
                {
                    var same = fixedTrees[tree.degree];
                    if (tree.key > same.key)
                    {
                        var tmp = tree;
                        tree = same;
                        same = tmp;
                    }
                    // now tree <= same
                    fixedTrees[tree.degree] = null;
                    tree.AddChild(same);
                    // same.marked = false;
                }
                fixedTrees[tree.degree] = tree;
            }
            // now <= 1 tree in each cell
            root = null;
            foreach (var tree in fixedTrees.Where(x => x != null))
                Include(tree);
        }

        // promote to the top
        void Cut(FibonacciHeapNode node)
        {
            node.parent.RemoveChild(node);
            Include(node);
            node.marked = false; // why?
        }

        // TODO: understand CascadingCut
        // where is recurion?
        void CascadingCut(FibonacciHeapNode node)
        {
            while (node != null && node.marked)
            {
                var parent = node.parent;
                Cut(node);
                node = parent;
            }
            if (node != null)
                node.marked = true;
        }
    }
}
