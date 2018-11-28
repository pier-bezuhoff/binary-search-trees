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
        private bool treeMode = false; // false => heap mode
        private List<RadioButton> treeRadio;
        private List<RadioButton> heapRadio;

        ITree tree;
        IHeap heap;
        public MainForm()
        {
            InitializeComponent();
            Action<TextBox, Button> connectEnter = (field, button) => {
                field.KeyUp += (object sender, KeyEventArgs e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        button.PerformClick();
                        e.Handled = true;
                    }
                };
            };
            connectEnter(IncludeField, Include);
            connectEnter(DeleteKeyField, DeleteKey);
            connectEnter(DecreaseFromKeyField, DecreaseKey);
            connectEnter(DecreaseToKeyField, DecreaseKey);
            treeRadio = new List<RadioButton>() { ChooseB, ChooseFibonacci, ChooseOptimalSearch };
            heapRadio = new List<RadioButton>() { ChooseBinomialHeap, ChooseFibonacciHeap, Choose23Heap };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTreeOrHeap();
        }

        private void CreateTreeOrHeap()
        {
            if (ChooseB.Checked) ;
            else if (ChooseFibonacci.Checked) ;
            else if (ChooseOptimalSearch.Checked) ;
            else if (Choose23Heap.Checked)
                heap = new Heap23();
            else if (ChooseFibonacciHeap.Checked)
                heap = new FibonacciHeap();
            treeMode = treeRadio.Any(r => r.Checked);
            ShowTreeOrHeap();
            usedKeys = new List<int>();
            LastRandomIncluded.Text = "";
        }

        private void ShowTreeOrHeap()
        {
            OldTreeSExp.Text = NewTreeSExp.Text.ToString();
            if (treeMode)
                NewTreeSExp.Text = tree.ToString();
            else
                NewTreeSExp.Text = heap.ToString();
        }

        private void IncludeKey(string s)
        {
            try
            {
                int key = int.Parse(s);
                if (treeMode)
                    tree.Include(key);
                else
                    heap.Include(key);
            }
            finally
            {
                ShowTreeOrHeap();
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

        private void IncludeField_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Include.PerformClick();
                e.Handled = true;
            }
        }

        private void ChooseB_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void ChooseFibonacci_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void ChooseOptimalSearch_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void ChooseBinomialHeap_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void ChooseFibonacciHeap_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void Choose23Heap_CheckedChanged(object sender, EventArgs e) => CreateTreeOrHeap();
        private void Clear_Click(object sender, EventArgs e) => CreateTreeOrHeap();

        private void IncludeRandom_Click(object sender, EventArgs e)
        {
            var x = GenerateUniqueKey();
            IncludeKey(x.ToString());
            LastRandomIncluded.Text = x.ToString();
        }

        private void DecreaseFromToArrow_Click(object sender, EventArgs e) { }

        private void DeleteMin_Click(object sender, EventArgs e)
        {
            if (!treeMode)
            {
                heap.PopMin();
                ShowTreeOrHeap();
            }
        }

        private void DeleteKey_Click(object sender, EventArgs e)
        {
            if (!treeMode)
            {
                try
                {
                    int key = int.Parse(DeleteKeyField.Text.ToString());
                    heap.DeleteKey(key);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid format!");
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("Key not found!");
                }
                ShowTreeOrHeap();
            }
        }

        private void DeleteKeyField_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DeleteKey.PerformClick();
                e.Handled = true;
            }
        }

        private void DecreaseKey_Click(object sender, EventArgs e)
        {
            if (!treeMode)
            {
                try
                {
                    int oldKey = int.Parse(DecreaseFromKeyField.Text.ToString());
                    int newKey = int.Parse(DecreaseToKeyField.Text.ToString());
                    heap.DecreaseKeyFrom(oldKey, newKey);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid format!");
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("Key not found!");
                }
                ShowTreeOrHeap();
            }
        }

        private void DecreaseKeyField_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DecreaseKey.PerformClick();
                e.Handled = true;
            }
        }
    }
}