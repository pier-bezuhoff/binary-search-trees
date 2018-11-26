using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BinaryNode : BinaryNodeT<BinaryNode>
    {
        public BinaryNode(int key) : base(key) { }
    }
}
