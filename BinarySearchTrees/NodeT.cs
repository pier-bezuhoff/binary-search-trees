using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    /* instances should have form: "Instance : NodeT<Instance>" */
    abstract public class NodeT<N> : IComparable<N> where N : NodeT<N>
    {
        public int key;

        public NodeT(int key)
        {
            this.key = key;
        }

        override public string ToString() => ToString(0);

        virtual public string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            var strs = Children().Select(n => "\n" + n.ToString(depth + 1));
            // string[] strs = Enumerable.Repeat("_", capacity + 1).ToArray();
            return string.Format("{0}(Node {1} {2})", tab, string.Join(" ", Keys()), string.Join(" ", strs));
        }

        virtual public IEnumerable<int> Keys() => new List<int>(1) { key };
        abstract public IEnumerable<N> Children();

        virtual public int NChildren() => Children().Count();
        virtual public N AChild() => Children().First();
        virtual public bool IsLeaf() => NChildren() == 0;
        virtual public bool HasAChild() => NChildren() == 1;
        virtual public bool Has2Children() => NChildren() == 2;

        virtual public int Height()
        {
            var childrenHeight = (int?) Children().Select(child => child == null ? 0 : child.Height()).Max();
            return 1 + childrenHeight.GetValueOrDefault(0);
        }

        /* Search key only among children or null */
        virtual public N FindKey(int key)
        {
            return Children().Select(n => n.FindKey(key)).FirstOrDefault();
        }

        virtual public int CompareTo(N other) => key.CompareTo(other.key);
    }
}
