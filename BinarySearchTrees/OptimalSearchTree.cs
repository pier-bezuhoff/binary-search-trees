using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class OptimalSearchTree : Tree
    {
        static int nKeys = 7;
        static int[] keys = new int[] {2, 3, 6, 12, 40, 89, 100};
        static int[] nRequests = new int[] {80, 60, 66, 100, 2, 5, 10};
        static int[] nMissing = new int[] {5, 1, 10, 12, 30, 10, 9, 150}; // length nMissing == nKeys + 1
        static int[][] weights, paths, optimalKeys;

        public Node Root { get; set; } = null;

        public OptimalSearchTree()
        {
            int keyIndex = optimalKeys[0][nKeys - 1];
            Root = new Node(keys[keyIndex]);
            Root.Left = (new OptimalSearchTree(0, keyIndex - 1)).Root;
            Root.Right = (new OptimalSearchTree(keyIndex + 1, nKeys - 1)).Root;
        }

        public OptimalSearchTree(int from, int to)
        {
            if (from > to)
            {
                Root = null;
            } else if (from == to)
            {
                Root = new Node(keys[from]);
            }
            else
            {
                int keyIndex = optimalKeys[from][to];
                Root = new Node(keys[keyIndex]);
                Root.Left = (new OptimalSearchTree(from, keyIndex - 1)).Root;
                Root.Right = (new OptimalSearchTree(keyIndex + 1, to)).Root;
            }
        }

        public static void Init()
        {
            weights = new int[nKeys][];
            paths = new int[nKeys][];
            optimalKeys = new int[nKeys][];
            for (int i = 0; i < nKeys; i++)
            {
                weights[i] = new int[nKeys];
                paths[i] = new int[nKeys];
                optimalKeys[i] = new int[nKeys];
            }
            for (int i = 0; i < nKeys; i++)
            {
                weights[i][i] = 0; // nMissing[i];
                paths[i][i] = weights[i][i];
                for (int j = i + 1; j < nKeys; j++)
                {
                    weights[i][j] = weights[i][j - 1] + nRequests[j] + nMissing[j];
                    int optimalKey = keys.Skip(i + 1).Take(j - i).Min(k => paths[i][k] + paths[k - 1][j]);
                    optimalKeys[i][j] = optimalKey;
                    paths[i][j] = weights[i][j] + paths[i][optimalKey] + paths[optimalKey - 1][j];
                }
            }
        }

        public override void Include(int key)
        {
            throw new NotImplementedException();
        }
    }
}
