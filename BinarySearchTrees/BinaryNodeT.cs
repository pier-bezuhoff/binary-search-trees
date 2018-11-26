using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    /* instances should have form: "Instance : BinaryNodeT<Instance>" */
    abstract public class BinaryNodeT<N> : NodeT<N> where N : BinaryNodeT<N>
    {
        public N left = null, right = null;

        public BinaryNodeT(int key) : base(key) { }

        public override IEnumerable<N> Children() => new List<N>(2) { left, right }.FindAll(n => n != null);
    }
}
