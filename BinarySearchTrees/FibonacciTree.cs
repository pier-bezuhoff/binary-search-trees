using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class FibonacciTree : Tree<BinaryNode>
    {
        public static int[] fibs;
        public static int[] maxKeys;

        public static void Init()
        {
            FillFibs();
        }

        public static void FillFibs()
        {
            int a = 1, b = 1;
            fibs = new int[50];
            fibs[0] = a;
            fibs[1] = b;
            for (int i = 2; i < 50; i++)
            {
                int tmp = b;
                b = a + b;
                a = tmp;
                fibs[i] = b;
            }
        }

        public static void FillMaxKeys()
        {
            int a = 0, b = 1;
            maxKeys = new int[50];
            maxKeys[0] = a;
            maxKeys[1] = b;
            for (int i = 2; i < 50; i++)
            {
                int tmp = b;
                b = a + b + 1;
                a = tmp;
                maxKeys[i] = b;
            }
        }

        public override void Include(int key)
        {
            Include(key, root);
        }

        public void Include(int key, BinaryNode root)
        {
            BinaryNode node = new BinaryNode(key);
            if (root == null)
            {
                if (key == fibs[1])
                {
                    root = node;
                    return;
                }
                else
                {
                    root = new BinaryNode(fibs[1]);
                }
            }
            int height = root.Height();
            int maxKey = maxKeys[height];
            if (key > maxKey)
            {
                int rootKey = fibs.First(fib => fib >= key);
                // add new root
            }
            bool notFound = true;
            int delta;
            while (notFound)
            {
                delta = fibs[height - 1];
                if (root.key < key) // root < node
                {
                    if (key - root.key == delta)
                    {
                        if (root.right == null)
                        {
                            root.right = node;
                            notFound = false;
                        }
                        else
                        {
                            NotUniqueKey(key);
                            notFound = false;
                        }
                    }
                    else
                    {
                        if (root.right == null)
                        {
                            root.right = new BinaryNode(root.key + delta);
                        }
                        height--;
                        root = root.right; // next iteration
                    }
                }
                else if (key < root.key) // node < root
                {
                    if (root.key - key == delta)
                    {
                        if (root.left == null)
                        {
                            root.left = node;
                            notFound = false;
                        }
                        else
                        {
                            NotUniqueKey(key);
                            notFound = false;
                        }
                    }
                    else
                    {
                        if (root.left == null)
                        {
                            root.left = new BinaryNode(root.key - delta);
                        }
                        height--;
                        root = root.left; // next iteration
                    }
                }
                else
                {
                    NotUniqueKey(key);
                    notFound = false;
                }
            }
        }
    }
}
