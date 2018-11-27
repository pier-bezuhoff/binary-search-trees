using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract public class Heap<N> : ITreeLike where N : NodeT<N>
    {
        public Heap() { }

        public override string ToString()
        {
            return string.Format(
                "[\n{0}\n]",
                string.Join("\n", Trees().Select(t => t.ToString())));
        }

        abstract public IEnumerable<N> Trees();

        public int Min() => Trees().Min().key;

        abstract public int PopMin();
        abstract public void DecreaseKey(N node, int newKey);
        abstract public void Delete(N node);
        abstract public void Include(int key);
    }
}
