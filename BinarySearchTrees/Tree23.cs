﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Tree23 : NodeT<Tree23>
    {
        public int height = 1; // length of this trunk
        public int degree = 1; // n of children
        public Tree23 trunk = null; // trunk of (degree - 1)-th trees
        public Tree23 partner = null; // next degree-th tree in trunk

        public Tree23 (int key) : base(key) { } 

        public Tree23 (Tree23 trunkHead) : base(trunkHead.key)
        {
            degree = trunkHead.degree + 1;
            trunk = trunkHead;
            height = trunkHead.Trunk().Count();
        }

        override public string ToString(int depth)
        {
            string tab = new string(' ', 4 * depth);
            if (degree == 1)
                return string.Format("{0}(Node {1})", tab, key);
            var strs = trunk.Trunk().Select(n => "\n" + n.ToString(depth + 1));
            // string[] strs = Enumerable.Repeat("_", capacity + 1).ToArray();
            return string.Format("{0}(Node {1})", tab, string.Join(" ", strs));
        }

        public IEnumerable<Tree23> Trunk()
        {
            yield return this;
            var partner = this.partner;
            while (partner != null)
            {
                yield return partner;
                partner = partner.partner;
            }
        }

        public override IEnumerable<Tree23> Children()
        {
            return trunk == null? new List<Tree23>(0) : trunk.Trunk();
        }

        public List<Tree23> Merge(Tree23 tree)
        {
            if (degree != tree.degree)
                throw new Exception("Merging 2-3-trees with different degrees!");
            var min = this;
            var max = tree;
            if (min.key > max.key)
            {
                max = this;
                min = tree;
            } // now min <= max
            if (degree == 1) // 1 + 1 -> 2
            {
                min.partner = max;
                return new List<Tree23>(1) { new Tree23(min) };
            }
            else if (min.height == 2 && max.height == 2) // x + x -> (x + (x + 1))
            {
                var small = max.trunk.partner;
                small.height = 1;
                max.trunk.partner = null;
                if (max.key >= min.trunk.partner.key)
                {
                    min.trunk.partner.partner = max.trunk;
                }
                else
                {
                    max.trunk.partner = min.trunk.partner;
                    min.trunk.partner = max.trunk;
                }
                var big = min;
                big.height = 3;
                return new List<Tree23>(2) { small, big };
            }
            else // x + x -> x + 1
            {
                min.partner = max;
                return new List<Tree23>(1) { new Tree23(min) };
            }
        }

        // degree > 1, height <= 2, tree.degree <= trunk.degree
        public void IncludeLess(Tree23 tree)
        {
            if (degree == 1)
                throw new Exception("degree should be > 1!");
            if (height <= 2)
                throw new Exception("height should be 2!");
            if (trunk.degree < tree.degree)
                throw new Exception("tree.degree should be <= trunk.degree!");
            if (height == 1)
            {
                var merged = 
            }
        }

        public Tree23 RemoveRoot()
        {
            if (degree == 1)
                throw new Exception("Removing root from T1!");
            if (degree == 2)
                return trunk.partner;
            var trunkHead = trunk;
            trunk = trunk.partner;
            height--;
            trunkHead.partner = null;
            IncludeLess(trunkHead.RemoveRoot());
            return this;
        }
    }
}
