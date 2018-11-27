using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearchTrees
{
    public partial class MainForm : Form
    {
        private List<int> usedKeys = new List<int>();
        private Random generator = new Random();
        private int minBound = 1;
        private int maxBound = 200;
        ITreeLike tree;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void CreateTreeLike()
        {
            if (ChooseB.Checked)
                ;//tree = new BTree(3);
            else if (ChooseFibonacci.Checked)
                ;
            else if (ChooseOptimalSearch.Checked)
                ;
            else if (Choose23Heap.Checked)
                tree = new Heap23();
            TreeSExp.Text = tree.ToString();
            usedKeys = new List<int>();
            LastRandomIncluded.Text = "";
        }

        private void IncludeKey(string s)
        {
            try
            {
                int key = int.Parse(s);
                tree.Include(key);
            }
            finally
            {
                TreeSExp.Text = tree.ToString();
            }
        }

        private int GenerateUniqueKey()
        {
            if (usedKeys.Count() + 1 >= maxBound - minBound)
                maxBound += 100;
            var x = generator.Next(minBound, maxBound);
            while (usedKeys.Contains(x))
                x = generator.Next(minBound, maxBound);
            usedKeys.Add(x);
            return x;
        }

        private void Include_Click(object sender, EventArgs e)
        {
            IncludeKey(IncludeField.Text.ToString());
        }

        private void ChooseB_CheckedChanged(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void ChooseFibonacci_CheckedChanged(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void ChooseOptimalSearch_CheckedChanged(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void Choose23Heap_CheckedChanged(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            CreateTreeLike();
        }

        private void IncludeRandom_Click(object sender, EventArgs e)
        {
            var x = GenerateUniqueKey();
            IncludeKey(x.ToString());
            LastRandomIncluded.Text = x.ToString();
        }

        private void DecreaseFromToArrow_Click(object sender, EventArgs e)
        {

        }
    }
}