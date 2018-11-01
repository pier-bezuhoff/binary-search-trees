using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class BinaryBTree : Tree
    {
        public BinaryBTree()
        { }

        public BinaryBTreeNode Root { get; set; } = null;

        public override void Include(int key)
        {
            Include(
                Root,
                delegate (BinaryBTreeNode newRoot) { Root = newRoot; },
                new BinaryBTreeNode(key));
        }

        public void Include(BinaryBTreeNode root, Action<BinaryBTreeNode> rootSetter, BinaryBTreeNode node)
        {
            BinaryBTreeNode left = root.Left, middle = root.Middle, right = root.Right;
            if (root == null)
                rootSetter(node);
            else if (root.key == node.key || root.Children.Any(n => n.key == node.key))
                NotUniqueKey(node.key);
            else if (root.HasNoChilds)
            {
                if (node.key < root.key)
                {
                    node.Right = root;
                    rootSetter(node);
                }
                else // root < node
                    root.Right = node;
            }
            else
            {
                if (node.key < root.key)
                {
                    if (left == null)
                        root.Left = node;
                    else
                    {
                        if (left.Full && left.BHeight - root.Children.Min(n => n.BHeight) >= 1)
                        {
                            // rebuild
                        }
                        else
                            Include(left, delegate (BinaryBTreeNode newLeft) { root.Left = newLeft; }, node);
                    }
                }
                else // root < node
                {
                    if (middle == null)
                        root.Middle = node;
                    else if (middle.key < node.key && right == null)
                        root.Right = node;
                    else if (node.key < middle.key)
                    {
                        if (middle.Full && middle.BHeight - root.Children.Min(n => n.BHeight) >= 1)
                        {
                            // rebuild
                        }
                        else
                            Include(middle, delegate (BinaryBTreeNode newMiddle) { root.Middle = newMiddle; }, node);
                    }
                    else // root < middle < node
                    {
                        if (right.Full && right.BHeight - root.Children.Min(n => n.BHeight) >= 1)
                        {
                            // rebuild
                        }
                        else
                            Include(right, delegate (BinaryBTreeNode newRight) { root.Right = newRight; }, node);
                    }
                }
            }
        }
    }
}