using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class FibonacciHeapNode: NodeT<FibonacciHeapNode>
    {
        // NOTE: left, right here are siblings
        public FibonacciHeapNode left, right;
        public FibonacciHeapNode parent = null;
        public FibonacciHeapNode child = null;
        public int nSiblings = 1;
        public int degree = 0; // n of children
        public bool marked = false; // true if a child was removed

        public FibonacciHeapNode(int key) : base(key) {
            left = right = this;
        }

        override public string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            return string.Join("\n", Siblings().Select(
                node => string.Format(
                    "{0}(Node {1}\n{2})",
                    tab, node.key, node.child.ToString(depth + 1))));
        }

        public IEnumerable<FibonacciHeapNode> Siblings()
        {
            yield return this;
            var sibling = left;
            while (sibling != this)
            {
                yield return sibling;
                sibling = sibling.left;
            }
        }

        override public IEnumerable<FibonacciHeapNode> Children()
            => child == null? new List<FibonacciHeapNode>(0) : child.Siblings();

        /* Remove this and find new min in siblings or null */
        public FibonacciHeapNode Remove()
        {
            if (nSiblings == 1)
                return null;
            left.right = right;
            right.left = left;
            return left.Siblings().Min();
        }

        public FibonacciHeapNode AddLeft(FibonacciHeapNode node)
        {
            node.left.left = left;
            node.right = this;
            left.right = node.left;
            left = node;
            // and merge similar trees
            nSiblings += node.nSiblings;
            if (key < node.key)
                return this;
            else
                return node;
        }

        public FibonacciHeapNode AddRight(FibonacciHeapNode node)
        {
            node.right.right = right;
            node.left = this;
            right.left = node.right;
            right = node;
            // and merge similar trees
            nSiblings += node.nSiblings;
            if (key < node.key)
                return this;
            else
                return node;
        }

        public void RemoveChild(FibonacciHeapNode node)
        {
            if (node == child)
                child = node.Remove();
            else
                node.Remove();
            node.parent = null;
            degree--;
        }

        public void AddChild(FibonacciHeapNode node)
        {
            if (child == null)
                child = node;
            else
                child = child.AddLeft(node);
            node.parent = this;
            degree++; // assumption: degree == node.degree
        }

        /* merge two trees if they share the same form */
        public FibonacciHeapNode Merge(FibonacciHeapNode first, FibonacciHeapNode second)
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

        void MergeSimilar(FibonacciHeapNode node)
        {
            if (node.nSiblings > 1)
            {
                //
            }
        }
    }
}
