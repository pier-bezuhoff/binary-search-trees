using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract public class Heap<N> : ITreeLike where N : NodeT<N>
    {
        public List<N> trees = new List<N>();

        public Heap() { }

        public override string ToString()
        {
            return string.Format("[\n{0}\n]", string.Join("\n", trees.Select(t => t.ToString())));
        }

        public N Min() => trees.Min();

        abstract public void Include(int key);
    }
}
