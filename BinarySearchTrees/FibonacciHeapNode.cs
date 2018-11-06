using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class FibonacciHeapNode<E>: IComparable<FibonacciHeapNode<E>> where E : IComparable<E>
    {
        public E key;
        public FibonacciHeapNode<E> parent = null;
        public FibonacciHeapNode<E> child = null;
        public FibonacciHeapNode<E> left, right;
        public int nSiblings = 1;
        public int nChildren = 0;
        public bool marked = false;

        public FibonacciHeapNode(E key) {
            this.key = key;
            left = right = this;
        }

        override public string ToString() => ToString(0);

        private string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            return string.Join("\n", Siblings.Select(
                node => $"{tab}(Node {node.key}\n{node.child.ToString(depth + 1)})"));
        }

        public IEnumerable<FibonacciHeapNode<E>> Siblings
        {
            get
            {
                yield return this;
                var sibling = left;
                while (sibling != this)
                {
                    yield return sibling;
                    sibling = sibling.left;
                }
            }
        }

        public IEnumerable<FibonacciHeapNode<E>> Children =>
            child == null? Enumerable.Empty<FibonacciHeapNode<E>>() : child.Siblings;

        public int CompareTo(FibonacciHeapNode<E> node)
        {
            return key.CompareTo(node.key);
        }

        public FibonacciHeapNode<E> Remove()
        {
            if (nSiblings == 1)
                return null;
            left.right = right;
            right.left = left;
            return left.Siblings.Min();
        }

        public FibonacciHeapNode<E> AddLeft(FibonacciHeapNode<E> node)
        {
            node.left.left = left;
            node.right = this;
            left.right = node.left;
            left = node;
            // and merge similar trees
            nSiblings += node.nSiblings;
            if (this.CompareTo(node) < 0)
                return this;
            else
                return node;
        }

        public FibonacciHeapNode<E> AddRight(FibonacciHeapNode<E> node)
        {
            node.right.right = right;
            node.left = this;
            right.left = node.right;
            right = node;
            // and merge similar trees
            nSiblings += node.nSiblings;
            if (this.CompareTo(node) < 0)
                return this;
            else
                return node;
        }

        public void RemoveChild(FibonacciHeapNode<E> node)
        {
            if (node == child)
                child = node.Remove();
            else
                node.Remove();
            node.parent = null;
            nChildren--;
        }

        public void AddChild(FibonacciHeapNode<E> node)
        {
            if (child == null)
                child = node;
            else
                child = child.AddLeft(node);
            node.parent = this;
            nChildren++;
        }

        /* merge two trees if they share the same form */
        public FibonacciHeapNode<E> Merge(FibonacciHeapNode<E> first, FibonacciHeapNode<E> second)
        {
            if (first.CompareTo(second) > 0)
            {
                second.AddChild(first);
                return second;
            }
            else // first.key != second.key!
            {
                first.AddChild(second);
                return first;
            }
        }

        void MergeSimilar(FibonacciHeapNode<E> node)
        {
            if (node.nSiblings > 1)
            {
                //
            }
        }
    }
}
