using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    abstract class Tree
    {
        public Node Root { get; set; } = null;

        public Tree()
        {}

        public Tree(Node root)
        {
            Root = root;
        }

        override public string ToString()
        {
            if (Root == null)
                return "()";
            else
                return Root.ToString();
        }

        abstract public void Include(int key);

        public void NotUniqueKey(int key)
        {
            throw new SystemException(String.Format("key {0} already exists!", key));
        }
    }
}
