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

        override public string ToString()
        {
            return Root == null ? "()" : Root.ToString();
        }

        public override void Include(int key)
        {
            Root = Include(Root, new BinaryBTreeNode(key));
        }

        /* -> new root */
        public BinaryBTreeNode Include(BinaryBTreeNode root, BinaryBTreeNode node)
        {
            if (root == null)
                return node;
            else if (root.key == node.key || root.Children.Any(n => n.key == node.key))
                NotUniqueKey(node.key);
            else if (root.HasNoChilds)
            {
                if (node.key < root.key)
                {
                    node.Right = root;
                    return node;
                }
                else // root < node
                    root.Right = node;
            }
            else
            {
                if (node.key < root.key)
                {
                    if (root.Left == null)
                        root.Left = node;
                    else
                    {
                        root.Left = Include(root.Left, node);
                        if (root.LeftBHeight - root.RightBHeight > 1)
                            return RotateRight(root);
                        return root;
                    }
                }
                else // root < node
                {
                    if (root.Right == null)
                        root.Right = node;
                    else
                    {
                        root.Right = Include(root.Right, node);
                        if (root.RightBHeight - root.LeftBHeight > 1)
                            return RotateLeft(root);
                        return root;
                    }
                }
            }
            return root;
        }

        /* rotate L -> R; root.Left.NChildren >= 1
         * => new root */
        BinaryBTreeNode RotateRight(BinaryBTreeNode root)
        {
            BinaryBTreeNode left = root.Left, right = root.Right, newRoot;
            if (left.Right == null)
            {
                newRoot = left;
                left = left.Left; // cannot be null
            }
            else
            {
                newRoot = left.Rightmost;
                var rightmostParent = left;
                while (rightmostParent.Right != newRoot)
                    rightmostParent = rightmostParent.Right;
                rightmostParent.Right = null;
            }
            root.Clear();
            right = Include(right, root);
            // rebalance left subtree
            left = Rebalance(left);
            newRoot.Left = left;
            newRoot.Right = right;
            return newRoot;
        }

        /* rotate L <- R; root.Right.NChildren >= 1
         * => new root */
        BinaryBTreeNode RotateLeft(BinaryBTreeNode root)
        {
            BinaryBTreeNode left = root.Left, right = root.Right, newRoot;
            if (right.Left == null)
            {
                newRoot = right;
                right = right.Right; // cannot be null
            }
            else
            {
                newRoot = right.Leftmost;
                var leftmostParent = right;
                while (leftmostParent.Left != newRoot)
                    leftmostParent = leftmostParent.Left;
                leftmostParent.Left = null;
            }
            root.Clear();
            left = Include(left, root);
            // rebalance right subtree
            right = Rebalance(right);
            newRoot.Left = left;
            newRoot.Right = right;
            return newRoot;
        }

        /* should be Full - n + 1 - 1
         * => new root */
        BinaryBTreeNode Rebalance(BinaryBTreeNode root)
        {
            if (root.HasNoChilds)
                return root;
            else if (root.NChildren == 1)
            {
                if (root.Right == null)
                    return RotateRight(root);
                else // root.Left == null
                    return RotateLeft(root);
            }
            // NChildren == 2; at least one of left or right is not Full
            else if (root.Right.Full)
                root.Left = Rebalance(root.Left);
            else if (root.Left.Full)
            {
                if (root.Right.NChildren == 1) // cannot be 0
                {
                    if (root.Right.Left == null)
                        root.Right = RotateLeft(root.Right);
                    else // right.Right == null
                        root.Right = RotateRight(root.Right);
                }
                else // right.NChildren == 2
                {
                    if (root.Right.Left.Full)
                        root.Right.Right = Rebalance(root.Right.Right);
                    else if (root.Right.Right.Full)
                        root.Right.Left = Rebalance(root.Right.Left);
                    else
                    {
                        if (root.Right.LeftBHeight - root.Right.RightBHeight >= 1)
                            root.Right = RotateRight(root.Right);
                        else
                            root.Right = RotateLeft(root.Right);
                    }
                }
            }
            else if (root.LeftBHeight - root.RightBHeight >= 1)
                return RotateRight(root);
            else if (root.RightBHeight - root.LeftBHeight >= 1)
                return RotateLeft(root);
            return root;
        }
    }
}