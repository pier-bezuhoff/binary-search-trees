using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BinomialTree : NodeT<BinomialTree>
    {
        public BinomialTree parent = null;
        public BinomialTree child = null; // left
        public BinomialTree sibling = null; // right
        public int degree = 0; // n of children

        public BinomialTree(int key) : base(key) { }

        // invariant: degree-ascending order
        public IEnumerable<BinomialTree> Siblings()
        {
            var tree = this;
            while (tree != null)
            {
                yield return tree;
                tree = tree.sibling;
            }
        }

        override public IEnumerable<BinomialTree> Children() => child == null? new List<BinomialTree>(0) : child.Siblings();

        public void AddChild(BinomialTree tree)
        {
            var oldChild = child;
            child = tree;
            child.parent = this;
            child.sibling = oldChild;
            if (tree.degree == degree)
                degree++;
        }
    }
}
