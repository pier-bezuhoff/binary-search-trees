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

        public virtual string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            var strs = Children().Select(n => "\n" + n.ToString(depth + 1));
            // string[] strs = Enumerable.Repeat("_", capacity + 1).ToArray();
            return string.Format("{0}(Node {1} {2})", tab, string.Join(" ", Keys()), string.Join(" ", strs));
        }

        public virtual IEnumerable<int> Keys() => new List<int>(1) { key };

        public abstract IEnumerable<N> Children();

        public virtual int NChildren() => Children().Count();

        public virtual N AChild() => Children().First();

        public virtual bool IsLeaf() => NChildren() == 0;

        public virtual bool HasAChild() => NChildren() == 1;

        public virtual bool Has2Children() => NChildren() == 2;

        public virtual int Height()
        {
            var childrenHeight = (int?) Children().Select(child => child == null ? 0 : child.Height()).Max();
            return 1 + childrenHeight.GetValueOrDefault(0);
        }

        public virtual int CompareTo(N other) => key.CompareTo(other.key);
    }
}
