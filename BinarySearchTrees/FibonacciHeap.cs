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
        int nNodes = 0; // maybe: delete

        public FibonacciHeap() {}

        override public IEnumerable<FibonacciHeapNode> Trees() => root.Siblings();

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
            nNodes++;
        }

        public void Merge(FibonacciHeap heap)
        {
            if (root == null)
                root = heap.root;
            else
                root = root.AddLeft(heap.root);
            nNodes += heap.nNodes;
        }

        override public int PopMin()
        {
            var oldRoot = root;
            if (root == null)
                throw new Exception("Empty heap has no min!");
            foreach (var child in root.Children())
                child.parent = null;
            var newRoot = root.Remove();
            nNodes--;
            if (newRoot == null) // single root
                root = root.child;
            else
            {
                root = newRoot;
                if (oldRoot.child != null)
                    root.AddLeft(oldRoot.child);
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
                if (node.parent != null && newKey < node.parent.key)
                {
                    Cut(node);
                    CascadingCut(node.parent);
                }
            }
            // upd root -> min
        }

        override public void Delete(FibonacciHeapNode node)
        {
            DecreaseKey(node, int.MinValue);
            PopMin();
        }

        /* Merge trees with the same degree */
        void Consolidate()
        {
            int maxDegree = Trees().Max(t => t.degree);
            // root trees with degrees 0, 1..
            var fixedTrees = Enumerable.Repeat<FibonacciHeapNode>(null, 2 + maxDegree).ToList();
            foreach(var node in Trees())
            {
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
                    same.Remove();
                    tree.AddChild(same);
                    // same.marked = false;
                    fixedTrees[tree.degree] = null;
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
            node.marked = false;
        }

        // TODO: understand CascadingCut
        // where is recurion?
        void CascadingCut(FibonacciHeapNode node)
        {
            var parent = node;
            while (parent.marked)
            {
                Cut(parent);
                parent = parent.parent;
            }
            parent.marked = true;
            /*
            if (parent != null)
                if (!node.marked)
                    node.marked = true;
                else
                {
                    Cut(node, parent);
                    CascadingCut(parent);
                }
            */
        }
    }
}
