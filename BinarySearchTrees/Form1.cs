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
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ChooseB.Checked)
            {
                tree = new BinaryBTree();
            } else if (ChooseFibonacci.Checked)
            {
                tree = new FibonacciTree();
            } else if (ChooseOptimalSearch.Checked)
            {
                tree = new OptimalSearchTree();
            }
            TreeSExp.Text = tree.ToString();
        }

        private void include_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(IncludeField.Text.ToString());
                tree.Include(key);
            }
            finally
            {
                TreeSExp.Text = tree.ToString();
            }
        }

        private void chooseB_CheckedChanged(object sender, EventArgs e)
        {
            if (ChooseB.Checked)
            {
                tree = new BinaryBTree();
                TreeSExp.Text = tree.ToString();
            }
        }

        private void chooseFibonacci_CheckedChanged(object sender, EventArgs e)
        {
            if (ChooseFibonacci.Checked)
            {
                tree = new FibonacciTree();
                TreeSExp.Text = tree.ToString();
            }
        }

        private void chooseOptimalSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChooseOptimalSearch.Checked)
            {
                tree = new OptimalSearchTree();
                TreeSExp.Text = tree.ToString();
            }
        }
    }
}