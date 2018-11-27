using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    interface IHeap
    {
        void Include(int key);
        int Min();
        int PopMin();
        void DeleteKey(int key);
        void DecreaseKeyFrom(int oldKey, int newKey);
    }
}
