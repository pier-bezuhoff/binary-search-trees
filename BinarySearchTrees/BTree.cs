using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BTree : Tree<BTreeNode>
    {
        // BUG: 3 34 12 10 13!
        int capacity;

        public BTree(int capacity)
        {
            this.capacity = capacity;
        }

        public override string ToString()
        {
            return root == null? "()" : root.ToString();
        }

        public override void Include(int key)
        {
            var newRoot = IncludeAndBack(root, new BTreeNode(key, capacity));
            if (newRoot != null)
                root = newRoot;
        }

        /* node could have 0 or 2 childs and 1 (first) key
         * if no new root then return null else new root */
        BTreeNode IncludeAndBack(BTreeNode root, BTreeNode node)
        {
            int key = node.keys.First();
            if (root == null)
                return node;
            else
            {
                if (root.keys.Contains(key))
                    NotUniqueKey(key);
                var ks = root.keys.Where(k => k > key);
                int more = ks.Count() == 0? root.NKeys : root.keys.FindIndex(k => k > key);
                if (root.IsLeaf())
                {
                    root.keys.Insert(more, key);
                    if (node.NChildren() == 2)
                    {
                        root.children[more] = node.children[0];
                        root.children[more + 1] = node.children[1];
                    }
                    else if (!node.IsLeaf())
                        throw new Exception("node cannot have not (0 or 2) childs");
                    // now root.values is sorted list
                    if (root.keys.Count > capacity)
                        return OverflowAndBack(root);
                }
                else
                {
                    if (more >= root.NKeys)
                    {
                        if (root.NKeys < capacity) {
                            root.keys.Add(key);
                            if (node.NChildren() == 2)
                            {
                                root.children[root.NKeys] = node.children[0];
                                root.children[root.NKeys + 1] = node.children[1];
                            } else if (!node.IsLeaf())
                                throw new Exception("node cannot have not (0 or 2) childs");
                        }
                        else
                        {
                            var newRoot = IncludeAndBack(root.children.Last(), node);
                            if (newRoot != null)
                            {
                                root.children[capacity] = newRoot;
                                // key = newRoot.keys.First();
                                // more <-
                                // root.keys.Insert(more, newRoot);
                                // // TODO: move right children and insert newRoot children
                                // return OverflowAndBack(root);
                            }
                        }
                    }
                    else
                    {
                        // include into more-th child
                        var newRoot = IncludeAndBack(root.children[more], node);
                        if (newRoot != null)
                        {
                            root.children[more] = newRoot;
                            // key = newRoot.keys.First();
                            // more <- 
                            // root.keys.Insert(more, newRoot);
                            // if (root.keys.Count > capacity)
                            //     return OverflowAndBack(root);
                        }
                    }
                }
            }
            return null;
        }

        BTreeNode OverflowAndBack(BTreeNode root)
        {
            int middle = capacity / 2;
            var left = new BTreeNode(root.keys.Take(middle).ToList(), capacity);
            var right = new BTreeNode(root.keys.Skip(middle + 1).ToList(), capacity);
            var newRoot = new BTreeNode(root.keys[middle], capacity);
            newRoot.children[0] = left;
            newRoot.children[1] = right;
            return newRoot;
        }
    }
}
