using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BinomialHeap : Heap<BinomialTree>
    {
        private BinomialTree root = null; // min degree

        public override BinomialTree Root() => root;

        // invariant: degree-ascending order
        public override IEnumerable<BinomialTree> Trees() => root == null? new List<BinomialTree>(0) : root.Siblings();

        public void Merge(BinomialHeap heap)
        {
            if (root == null)
                root = heap.root;
            else if (heap.root != null)
            {
                BinomialTree tree = null, tree1 = root, tree2 = heap.root;
                Func<BinomialTree, BinomialTree> Advance = t =>
                {
                    if (tree != null)
                        tree.sibling = t;
                    else
                        root = t;
                    tree = t;
                    return t.sibling;
                };
                // merging lists, keeping degree-order
                while (tree1 != null && tree2 != null)
                {
                    if (tree1.degree <= tree2.degree)
                        tree1 = Advance(tree1);
                    else
                        tree2 = Advance(tree2);
                }
                while (tree1 != null)
                    tree1 = Advance(tree1);
                while (tree2 != null)
                    tree2 = Advance(tree2);
                // merging trees with same degrees
                tree = root;
                while (tree?.sibling != null)
                {
                    var next = tree.sibling;
                    if (tree.degree == next.degree)
                    {
                        if (tree.key <= next.key)
                        {
                            tree.sibling = next.sibling;
                            tree.AddChild(next);
                            next = tree;
                        }
                        else
                        {
                            next.AddChild(tree);
                            if (tree == root)
                                root = next;
                        }
                    }
                    tree = next;
                }
            }
        }

        public override void DecreaseKey(BinomialTree node, int newKey)
        {
            if (newKey > node.key)
                throw new Exception(string.Format("new key {0} > old key {1}", newKey, node.key));
            else if (newKey < node.key)
            {
                node.key = newKey;
                while (node.parent != null && node.key < node.parent.key)
                {
                    var low = node.key;
                    node.key = node.parent.key;
                    node.parent.key = low;
                    node = node.parent;
                }
            }
        }

        public override void Delete(BinomialTree node)
        {
            DecreaseKey(node, int.MinValue);
            PopMin();
        }

        public override void Include(int key)
        {
            var heap = new BinomialHeap { root = new BinomialTree(key) };
            Merge(heap);
        }

        public override int PopMin()
        {
            if (root == null)
                throw new Exception("Empty heap has no min!");
            var min = Trees().Min();
            if (min != root)
            {
                var sister = root; // sister.sibling = this
                while (sister.sibling != min)
                    sister = sister.sibling;
                sister.sibling = min.sibling; // forget him
            }
            else
                root = min.sibling;
            // BUG: order is broken((
            // reverse linking in order to keep degree-order
            var childRoot = min.child;
            BinomialTree previous = null;
            while (childRoot.sibling != null)
            {
                var next = childRoot.sibling;
                childRoot.sibling = previous;
                previous = childRoot;
                childRoot = next;
            }
            childRoot.sibling = previous;
            var childHeap = new BinomialHeap { root = childRoot };
            foreach (var child in childHeap.Trees())
                child.parent = null;
            Merge(childHeap);
            return min.key;
        }
    }
}
