using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract public class Tree<N> : ITree where N : NodeT<N>
    {
        public N root = null;

        public Tree() { }

        public override string ToString()
        {
            if (root == null)
                return "()";
            else
                return root.ToString();
        }

        abstract public void Include(int key);

        public void NotUniqueKey(int key)
        {
            Console.WriteLine(string.Format("key {0} already exists!", key));
            // throw new SystemException($"key {key} already exists!");
        }
    }
}
