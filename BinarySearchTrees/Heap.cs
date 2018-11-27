using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract public class Heap<N> : IHeap where N : NodeT<N>
    {
        public Heap() { }

        public override string ToString()
        {
            return string.Format(
                "[\n{0}\n]",
                string.Join("\n", Trees().Select(t => t.ToString())));
        }

        abstract public IEnumerable<N> Trees();
        abstract public N Root();

        public int Min() => Trees().Min().key;

        abstract public int PopMin();
        abstract public void DecreaseKey(N node, int newKey);
        abstract public void Delete(N node);
        abstract public void Include(int key);

        public void DeleteKey(int key)
        {
            var root = Root();
            if (root != null)
            {
                if (root.key == key)
                    Delete(root);
                else
                {
                    var node = root.FindKey(key);
                    if (node != null)
                        Delete(node);
                }
            }
        }

        public void DecreaseKeyFrom(int oldKey, int newKey)
        {
            var root = Root();
            if (root != null)
            {
                if (root.key == oldKey)
                    DecreaseKey(root, newKey);
                else
                {
                    var node = root.FindKey(oldKey);
                    if (node != null)
                        DecreaseKey(node, newKey);
                }
            }
        }
    }
}
