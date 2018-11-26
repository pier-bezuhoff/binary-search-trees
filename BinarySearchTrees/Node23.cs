using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Node23 : BinaryNodeT<Node23>
    {
        public int degree = 1; // n of children + 1 (this)
        public Node23(int key) : base(key) { }
    }
}
