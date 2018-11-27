using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    class Heap23 : Heap<Tree23>
    {
        private List<Tree23> trees = new List<Tree23>();

        public Heap23() { }

        override public IEnumerable<Tree23> Trees() => trees;
        public override Tree23 Root() => trees.Count() == 0? null : trees[0];

        override public void Include(int key)
        {
            var tree = new Tree23(key);
            Include(tree);
        }

        void Include(Tree23 tree)
        {
            var same = trees.FirstOrDefault(t => t.degree == tree.degree);
            if (same == null)
                trees.Add(tree);
            else
            {
                trees.Remove(same);
                var merged = same.Merge(tree);
                foreach (var t in merged)
                    Include(t);
            }
        }

        public override int PopMin()
        {
            throw new NotImplementedException();
        }

        public override void DecreaseKey(Tree23 node, int newKey)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Tree23 node)
        {
            throw new NotImplementedException();
        }
    }
}
