using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class BinaryBTreeNode // inheritance was bad idea
    {
        public int key;

        public BinaryBTreeNode(int key)
        {
            this.key = key;
        }

        public void Clear()
        {
            Right = null;
            Left = null;
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

        public List<BinaryBTreeNode> Children => new List<BinaryBTreeNode>(3) { Left, Right }.FindAll(n => n != null);

        public int NChildren => Children.Count();

        public bool HasNoChilds => Left == null && Right == null;

        /* height of B-Tree */
        public int BHeight
        {
            get
            {
                return 1 + Math.Max(LeftBHeight, RightBHeight);
            }
        }

        public int LeftBHeight
        {
            get
            {
                if (Left == null)
                    return 0;
                else if (Left.HasNoChilds)
                    return 1;
                else
                    return Left.BHeight;
            }
        }

        public int RightBHeight
        {
            get
            {
                if (Right == null)
                    return 0;
                else if (Right.HasNoChilds)
                    return 0;
                else
                    return Right.Children.Max(n => n.BHeight);
            }
        }

        public bool Full
        {
            get
            {
                if (HasNoChilds)
                    return true;
                else if (NChildren == 2)
                    return Left.Full && Right.Full && LeftBHeight == RightBHeight;
                else
                    return false;
            }
        }

        public BinaryBTreeNode Leftmost
        {
            get
            {
                BinaryBTreeNode node = this;
                while (node != null && node.Left != null)
                    node = node.Left;
                return node;
            }
        }

        public BinaryBTreeNode Rightmost
        {
            get
            {
                BinaryBTreeNode node = this;
                while (node != null && node.Right != null)
                    node = node.Right;
                return node;
            }
        }

        public BinaryBTreeNode Left { get; set; } = null;
        public BinaryBTreeNode Right { get; set; } = null;
    }
}
