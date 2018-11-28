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
        public int degree = 0; // n of children
        public bool marked = false; // true if a child was removed

        public FibonacciHeapNode(int key) : base(key) {
            left = right = this;
        }

        override public string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            return string.Format(
                    "{0}(Node {1}{2})",
                    tab, key,
                    child == null? "" : "\n" + string.Join("\n", Children().Select(c => c.ToString(depth + 1))));
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

        public int NSiblings() => Siblings().Count();

        override public IEnumerable<FibonacciHeapNode> Children()
            => child == null? new List<FibonacciHeapNode>(0) : child.Siblings();

        /* Remove this and find new min in siblings or null */
        public FibonacciHeapNode Remove()
        {
            if (NSiblings() == 1)
                return null;
            left.LinkRight(right);
            var newMin = left.Siblings().Min();
            this.LinkRight(this);
            return newMin;
        }

        private void LinkRight(FibonacciHeapNode node)
        {
            this.right = node;
            node.left = this;
        }

        public FibonacciHeapNode AddLeft(FibonacciHeapNode node)
        {
            var siblings = node.Siblings().ToList();
            foreach (var s in siblings)
                s.parent = parent;
            left.LinkRight(node.right);
            node.LinkRight(this);
            if (key < node.key)
                return this;
            else
                return node;
        }

        public FibonacciHeapNode AddRight(FibonacciHeapNode node)
        {
            var siblings = node.Siblings().ToList();
            foreach (var s in siblings)
                s.parent = parent;
            node.left.LinkRight(right);
            this.LinkRight(node);
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
            node.parent = null; // mark, maybe?
            // degree--; // not so simple, I think
            degree = Degree();
        }

        public void AddChild(FibonacciHeapNode node)
        {
            if (child == null)
            {
                child = node;
                node.left = node.right = node;
            }
            else
                child = child.AddLeft(node);
            node.parent = this;
            degree = Degree();
            // degree++; // I think, it fails sometimes
        }

        /* Shallow compute degree (from children only) */
        private int Degree() => child == null? 0 : 1 + Children().Select(c => c.degree).Max();
    }
}
