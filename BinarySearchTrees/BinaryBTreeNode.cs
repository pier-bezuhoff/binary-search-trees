using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class BinaryBTreeNode : Node
    {
        public BinaryBTreeNode(int key) : base(key)
        {
        }

        new public string ToString(int depth)
        {
            string tab = new String(' ', 4 * depth);
            string leftStr = "_", middleStr = "_", rightStr = "_";
            if (Left != null)
                leftStr = "\n" + Left.ToString(depth + 1);
            if (Middle != null)
                leftStr = "\n" + Middle.ToString(depth + 1);
            if (Right != null)
                rightStr = "\n" + Right.ToString(depth + 1);
            return $"{tab}(Node {key} {leftStr} {middleStr} {rightStr})";
        }

        public void AddChild(BinaryBTreeNode node)
        {
            if (node.key < key)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.AddChild(node);
            }
            else
            {
                if (Middle == null)
                    Middle = node;
                else if (node.key < Middle.key)
                    Middle.AddChild(node);
                else if (Right == null)
                    Right = node;
                else
                    Right.AddChild(node);
            }
        }

        public new List<BinaryBTreeNode> Children => new List<BinaryBTreeNode>(3) { Left, Middle, Right }.FindAll(n => n != null);

        public new int NChildren => Children.Count();

        public new bool HasNoChilds => Left == null && Right == null && Middle == null;

        public int BHeight
        {
            get
            {
                if (HasNoChilds)
                    return 1;
                else
                {
                    List<BinaryBTreeNode> nodes = new List<BinaryBTreeNode>(3) { Left, Middle, Right };
                    return 1 + nodes.Where(n => n != null).Max(n => n.BHeight);
                }
            }
        }

        public bool Full
        {
            get
            {
                if (HasNoChilds)
                    return true;
                else if (NChildren == 3)
                {
                    int h = Left.BHeight;
                    return Children.All(n => n.BHeight == h);
                }
                else
                    return false;
            }
        }

        public new BinaryBTreeNode Left { get; set; } = null;
        public BinaryBTreeNode Middle { get; set; } = null;
        public new BinaryBTreeNode Right { get; set; } = null;
    }
}
