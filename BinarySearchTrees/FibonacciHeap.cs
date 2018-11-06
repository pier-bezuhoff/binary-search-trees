using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class FibonacciHeap<E> where E: IComparable<E>
    {
        public FibonacciHeapNode<E> root = null;
        int nNodes = 0;

        public FibonacciHeap() {}

        IEnumerable<FibonacciHeapNode<E>> Roots => root.Siblings;

        public void Include(E key)
        {
            Include(new FibonacciHeapNode<E>(key));
        }

        public void Include(FibonacciHeapNode<E> node)
        {
            if (root == null)
                root = node;
            else
                root = root.AddLeft(node);
            nNodes++;
        }

        public void Merge(FibonacciHeap<E> heap)
        {
            if (root == null)
                root = heap.root;
            else
                root = root.AddLeft(heap.root);
            nNodes += heap.nNodes;
        }

        public FibonacciHeapNode<E> PopMin()
        {
            var oldRoot = root;
            if (root == null)
                throw new Exception("empty heap has no min");
            foreach (var child in root.Children)
                child.parent = null;
            var newRoot = root.Remove();
            nNodes--;
            if (newRoot == null) // single root
                root = root.child;
            else
            {
                root = newRoot;
                Consolidate();
            }
            return oldRoot;
        }

        void DecreaseKey(FibonacciHeapNode<E> node, E newKey)
        {
            if (node.key.CompareTo(newKey) < 0)
                throw new Exception($"new key {newKey} > old key {node.key} of {node}");
            else if (node.key.CompareTo(newKey) > 0)
            {
                node.key = newKey;
                var y = node.parent;
                if (y != null && node.CompareTo(y) < 0)
                {
                    // cut node y
                    // cascading cut y
                }
                if (node.CompareTo(root) < 0)
                    root = node;
            }

        }

        void Consolidate()
        {
            // TODO: understand Consolidate, Cut and CascadingCut
            // A[i] = y <=> y.nChildren = i && y <- Roots
            List<FibonacciHeapNode<E>> A = Enumerable.Repeat<FibonacciHeapNode<E>>(
                null,
                1 + Roots.Select(r => r.nChildren).Max()).ToList();
            foreach(var node in Roots)
            {
                var x = node;
                int d = node.nChildren;
                while (A[d] != null)
                {
                    var y = A[d];
                    if (x.CompareTo(y) > 0)
                    {
                        var tmp = x;
                        x = y;
                        y = tmp;
                    }
                    y.Remove();
                    x.AddChild(y);
                    y.marked = false;
                    A[d] = null;
                    d++;
                }
                A[d] = x;
            }
            root = null;
            foreach (var a in A.Where(x => x != null))
                Include(a);
        }

        void Cut(FibonacciHeapNode<E> node, FibonacciHeapNode<E> parent)
        {
            parent.RemoveChild(node);
            Include(node);
            node.marked = false;
        }

        void CascadingCut(FibonacciHeapNode<E> node)
        {
            var parent = node.parent;
            if (parent != null)
                if (!node.marked)
                    node.marked = true;
                else
                {
                    Cut(node, parent);
                    CascadingCut(parent);
                }
        }
    }
}
