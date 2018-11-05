using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BTreeNode
    {
        int capacity; // number of values
        public List<int> keys; // capacity
        public List<BTreeNode> children; // capacity + 1

        override public string ToString() => ToString(0);

        public string ToString(int depth)
        {
            string tab = new String(' ', 4 * depth);
            string[] strs = Enumerable.Repeat<string>("_", capacity + 1).ToArray();
            for (int i = 0; i < capacity + 1; i++)
            {
                var node = children[i];
                if (node != null)
                    strs[i] = "\n" + node.ToString(depth + 1);
            }
            return $"{tab}(Node {string.Join(" ", keys)} {string.Join(" ", strs)})";
        }

        BTreeNode(int capacity)
        {
            if (capacity < 2)
                throw new Exception($"too small capacity: {capacity}");
            this.capacity = capacity;
            keys = new List<int>(capacity + 1); // because i store when new overflowing key added
            // children = new List<BTreeNode>(capacity + 1);
            children = Enumerable.Repeat<BTreeNode>(null, capacity + 1).ToList();
        }

        public BTreeNode(int key, int capacity) : this(capacity)
        {
            keys.Add(key);
        }

        public BTreeNode(List<int> keys, int capacity) : this(capacity)
        {
            if (keys.Count > capacity)
                throw new Exception($"too many elements in keys: {keys.Count}");
            this.keys = keys;
        }

        public bool HasNoChilds => children.All(n => n == null);
        public int NChildren => children.Count(n => n != null);
        public int NKeys => keys.Count;
    }
}
