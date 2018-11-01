using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class Node : IComparable<Node>
    {
        public int key;
        public bool parasitic = false;

        public Node(int key)
        {
            this.key = key;
        }

        override public string ToString() => ToString(0);

        public string ToString(int depth)
        {
            string tab = new String(' ', 4 * depth);
            string leftStr = "_", rightStr = "_";
            if (Left != null)
                leftStr = "\n" + Left.ToString(depth + 1);
            if (Right != null)
                rightStr = "\n" + Right.ToString(depth + 1);
            return $"{tab}(Node {key} {leftStr} {rightStr})";
        }

        public List<Node> Children => new List<Node>(2) { Left, Right }.FindAll(n => n != null);

        public int NChildren => Children.Count();

        public Node AChild
        {
            get
            {
                if (Right != null)
                    return Right;
                else if (Left != null)
                    return Left;
                else
                    throw new SystemException("has no a child");
            }
        }

        public bool HasNoChilds => Right == null && Left == null;

        public bool HasAChild => Right == null ^ Left == null;

        public bool Has2Childs => Right != null && Left != null;

        public int Height
        {
            get
            {
                if (HasNoChilds)
                    return 1;
                else if (Left == null)
                {
                    return 1 + Right.Height;
                }
                else if (Right == null)
                {
                    return 1 + Left.Height;
                }
                else
                {
                    return 1 + Math.Max(Left.Height, Right.Height);
                }
            }
        }

        public Node Right { get; set; } = null;
        public Node Left { get; set; } = null;

        public int CompareTo(Node other)
        {
            return key.CompareTo(other.key);
        }
    }
}
