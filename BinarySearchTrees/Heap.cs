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

        virtual public N FindKey(int key)
        {
            var apropriateTree = Trees().FirstOrDefault(t => t.key == key);
            if (apropriateTree != null)
                return apropriateTree;
            return Trees().Select(t => t.FindKey(key)).FirstOrDefault(lu => lu != null);
        }

        public void DeleteKey(int key)
        {
            var node = FindKey(key);
            if (node != null)
                Delete(node);
            else
                throw new KeyNotFoundException(string.Format("{0}", key));
        }

        public void DecreaseKeyFrom(int oldKey, int newKey)
        {
            var node = FindKey(oldKey);
            if (node != null)
                DecreaseKey(node, newKey);
            else
                throw new KeyNotFoundException(string.Format("{0}", oldKey));
        }
    }
}
