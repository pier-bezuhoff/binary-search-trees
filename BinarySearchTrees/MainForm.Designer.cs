namespace BinarySearchTrees
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseB = new System.Windows.Forms.RadioButton();
            this.TreeChooser = new System.Windows.Forms.GroupBox();
            this.ChooseBinomialHeap = new System.Windows.Forms.RadioButton();
            this.ChooseFibonacciHeap = new System.Windows.Forms.RadioButton();
            this.Choose23Heap = new System.Windows.Forms.RadioButton();
            this.ChooseOptimalSearch = new System.Windows.Forms.RadioButton();
            this.ChooseFibonacci = new System.Windows.Forms.RadioButton();
            this.OldTreeSExp = new System.Windows.Forms.RichTextBox();
            this.IncludeField = new System.Windows.Forms.TextBox();
            this.Include = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.IncludeRandom = new System.Windows.Forms.Button();
            this.LastRandomIncluded = new System.Windows.Forms.TextBox();
            this.DeleteMin = new System.Windows.Forms.Button();
            this.DecreaseKey = new System.Windows.Forms.Button();
            this.DecreaseFromKeyField = new System.Windows.Forms.TextBox();
            this.DecreaseToKeyField = new System.Windows.Forms.TextBox();
            this.DecreaseFromToArrow = new System.Windows.Forms.Label();
            this.DeleteKey = new System.Windows.Forms.Button();
            this.DeleteKeyField = new System.Windows.Forms.TextBox();
            this.NewTreeSExp = new System.Windows.Forms.RichTextBox();
            this.OldNewSExpArrow = new System.Windows.Forms.Label();
            this.TreeChooser.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseB
            // 
            this.ChooseB.AutoSize = true;
            this.ChooseB.Location = new System.Drawing.Point(18, 25);
            this.ChooseB.Name = "ChooseB";
            this.ChooseB.Size = new System.Drawing.Size(126, 24);
            this.ChooseB.TabIndex = 0;
            this.ChooseB.Text = "Binary B-tree";
            this.ChooseB.UseVisualStyleBackColor = true;
            this.ChooseB.CheckedChanged += new System.EventHandler(this.ChooseB_CheckedChanged);
            // 
            // TreeChooser
            // 
            this.TreeChooser.Controls.Add(this.ChooseBinomialHeap);
            this.TreeChooser.Controls.Add(this.ChooseFibonacciHeap);
            this.TreeChooser.Controls.Add(this.Choose23Heap);
            this.TreeChooser.Controls.Add(this.ChooseOptimalSearch);
            this.TreeChooser.Controls.Add(this.ChooseFibonacci);
            this.TreeChooser.Controls.Add(this.ChooseB);
            this.TreeChooser.Location = new System.Drawing.Point(31, 31);
            this.TreeChooser.Name = "TreeChooser";
            this.TreeChooser.Size = new System.Drawing.Size(682, 127);
            this.TreeChooser.TabIndex = 1;
            this.TreeChooser.TabStop = false;
            this.TreeChooser.Text = "Tree/Heap";
            // 
            // ChooseBinomialHeap
            // 
            this.ChooseBinomialHeap.AutoSize = true;
            this.ChooseBinomialHeap.Location = new System.Drawing.Point(18, 76);
            this.ChooseBinomialHeap.Name = "ChooseBinomialHeap";
            this.ChooseBinomialHeap.Size = new System.Drawing.Size(134, 24);
            this.ChooseBinomialHeap.TabIndex = 5;
            this.ChooseBinomialHeap.TabStop = true;
            this.ChooseBinomialHeap.Text = "Binomial heap";
            this.ChooseBinomialHeap.UseVisualStyleBackColor = true;
            this.ChooseBinomialHeap.CheckedChanged += new System.EventHandler(this.ChooseBinomialHeap_CheckedChanged);
            // 
            // ChooseFibonacciHeap
            // 
            this.ChooseFibonacciHeap.AutoSize = true;
            this.ChooseFibonacciHeap.Checked = true;
            this.ChooseFibonacciHeap.Location = new System.Drawing.Point(158, 76);
            this.ChooseFibonacciHeap.Name = "ChooseFibonacciHeap";
            this.ChooseFibonacciHeap.Size = new System.Drawing.Size(142, 24);
            this.ChooseFibonacciHeap.TabIndex = 4;
            this.ChooseFibonacciHeap.TabStop = true;
            this.ChooseFibonacciHeap.Text = "Fibonacci heap";
            this.ChooseFibonacciHeap.UseVisualStyleBackColor = true;
            this.ChooseFibonacciHeap.CheckedChanged += new System.EventHandler(this.ChooseFibonacciHeap_CheckedChanged);
            // 
            // Choose23Heap
            // 
            this.Choose23Heap.AutoSize = true;
            this.Choose23Heap.Location = new System.Drawing.Point(306, 76);
            this.Choose23Heap.Name = "Choose23Heap";
            this.Choose23Heap.Size = new System.Drawing.Size(97, 24);
            this.Choose23Heap.TabIndex = 3;
            this.Choose23Heap.Text = "2-3 heap";
            this.Choose23Heap.UseVisualStyleBackColor = true;
            this.Choose23Heap.CheckedChanged += new System.EventHandler(this.Choose23Heap_CheckedChanged);
            // 
            // ChooseOptimalSearch
            // 
            this.ChooseOptimalSearch.AutoSize = true;
            this.ChooseOptimalSearch.Location = new System.Drawing.Point(306, 25);
            this.ChooseOptimalSearch.Name = "ChooseOptimalSearch";
            this.ChooseOptimalSearch.Size = new System.Drawing.Size(172, 24);
            this.ChooseOptimalSearch.TabIndex = 2;
            this.ChooseOptimalSearch.Text = "Optimal search tree";
            this.ChooseOptimalSearch.UseVisualStyleBackColor = true;
            this.ChooseOptimalSearch.CheckedChanged += new System.EventHandler(this.ChooseOptimalSearch_CheckedChanged);
            // 
            // ChooseFibonacci
            // 
            this.ChooseFibonacci.AutoSize = true;
            this.ChooseFibonacci.Location = new System.Drawing.Point(158, 25);
            this.ChooseFibonacci.Name = "ChooseFibonacci";
            this.ChooseFibonacci.Size = new System.Drawing.Size(134, 24);
            this.ChooseFibonacci.TabIndex = 1;
            this.ChooseFibonacci.Text = "Fibonacci tree";
            this.ChooseFibonacci.UseVisualStyleBackColor = true;
            this.ChooseFibonacci.CheckedChanged += new System.EventHandler(this.ChooseFibonacci_CheckedChanged);
            // 
            // OldTreeSExp
            // 
            this.OldTreeSExp.Location = new System.Drawing.Point(31, 164);
            this.OldTreeSExp.Name = "OldTreeSExp";
            this.OldTreeSExp.ReadOnly = true;
            this.OldTreeSExp.Size = new System.Drawing.Size(323, 756);
            this.OldTreeSExp.TabIndex = 2;
            this.OldTreeSExp.Text = "";
            // 
            // IncludeField
            // 
            this.IncludeField.Location = new System.Drawing.Point(895, 75);
            this.IncludeField.Name = "IncludeField";
            this.IncludeField.Size = new System.Drawing.Size(187, 26);
            this.IncludeField.TabIndex = 3;
            // 
            // Include
            // 
            this.Include.Location = new System.Drawing.Point(895, 31);
            this.Include.Name = "Include";
            this.Include.Size = new System.Drawing.Size(187, 38);
            this.Include.TabIndex = 4;
            this.Include.Text = "Include";
            this.Include.UseVisualStyleBackColor = true;
            this.Include.Click += new System.EventHandler(this.Include_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(895, 473);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(187, 35);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // IncludeRandom
            // 
            this.IncludeRandom.Location = new System.Drawing.Point(895, 107);
            this.IncludeRandom.Name = "IncludeRandom";
            this.IncludeRandom.Size = new System.Drawing.Size(187, 39);
            this.IncludeRandom.TabIndex = 6;
            this.IncludeRandom.Text = "Include random";
            this.IncludeRandom.UseVisualStyleBackColor = true;
            this.IncludeRandom.Click += new System.EventHandler(this.IncludeRandom_Click);
            // 
            // LastRandomIncluded
            // 
            this.LastRandomIncluded.Location = new System.Drawing.Point(895, 152);
            this.LastRandomIncluded.Name = "LastRandomIncluded";
            this.LastRandomIncluded.ReadOnly = true;
            this.LastRandomIncluded.Size = new System.Drawing.Size(187, 26);
            this.LastRandomIncluded.TabIndex = 7;
            // 
            // DeleteMin
            // 
            this.DeleteMin.Location = new System.Drawing.Point(895, 199);
            this.DeleteMin.Name = "DeleteMin";
            this.DeleteMin.Size = new System.Drawing.Size(187, 39);
            this.DeleteMin.TabIndex = 8;
            this.DeleteMin.Text = "Delete min";
            this.DeleteMin.UseVisualStyleBackColor = true;
            this.DeleteMin.Click += new System.EventHandler(this.DeleteMin_Click);
            // 
            // DecreaseKey
            // 
            this.DecreaseKey.Location = new System.Drawing.Point(895, 358);
            this.DecreaseKey.Name = "DecreaseKey";
            this.DecreaseKey.Size = new System.Drawing.Size(187, 34);
            this.DecreaseKey.TabIndex = 9;
            this.DecreaseKey.Text = "Decrease key";
            this.DecreaseKey.UseVisualStyleBackColor = true;
            this.DecreaseKey.Click += new System.EventHandler(this.DecreaseKey_Click);
            // 
            // DecreaseFromKeyField
            // 
            this.DecreaseFromKeyField.Location = new System.Drawing.Point(895, 398);
            this.DecreaseFromKeyField.Name = "DecreaseFromKeyField";
            this.DecreaseFromKeyField.Size = new System.Drawing.Size(84, 26);
            this.DecreaseFromKeyField.TabIndex = 10;
            // 
            // DecreaseToKeyField
            // 
            this.DecreaseToKeyField.Location = new System.Drawing.Point(1014, 398);
            this.DecreaseToKeyField.Name = "DecreaseToKeyField";
            this.DecreaseToKeyField.Size = new System.Drawing.Size(68, 26);
            this.DecreaseToKeyField.TabIndex = 11;
            // 
            // DecreaseFromToArrow
            // 
            this.DecreaseFromToArrow.AutoSize = true;
            this.DecreaseFromToArrow.Location = new System.Drawing.Point(985, 401);
            this.DecreaseFromToArrow.Name = "DecreaseFromToArrow";
            this.DecreaseFromToArrow.Size = new System.Drawing.Size(23, 20);
            this.DecreaseFromToArrow.TabIndex = 12;
            this.DecreaseFromToArrow.Text = "->";
            this.DecreaseFromToArrow.Click += new System.EventHandler(this.DecreaseFromToArrow_Click);
            // 
            // DeleteKey
            // 
            this.DeleteKey.Location = new System.Drawing.Point(895, 244);
            this.DeleteKey.Name = "DeleteKey";
            this.DeleteKey.Size = new System.Drawing.Size(187, 34);
            this.DeleteKey.TabIndex = 13;
            this.DeleteKey.Text = "Delete key";
            this.DeleteKey.UseVisualStyleBackColor = true;
            this.DeleteKey.Click += new System.EventHandler(this.DeleteKey_Click);
            // 
            // DeleteKeyField
            // 
            this.DeleteKeyField.Location = new System.Drawing.Point(895, 284);
            this.DeleteKeyField.Name = "DeleteKeyField";
            this.DeleteKeyField.Size = new System.Drawing.Size(186, 26);
            this.DeleteKeyField.TabIndex = 14;
            // 
            // NewTreeSExp
            // 
            this.NewTreeSExp.Location = new System.Drawing.Point(389, 164);
            this.NewTreeSExp.Name = "NewTreeSExp";
            this.NewTreeSExp.ReadOnly = true;
            this.NewTreeSExp.Size = new System.Drawing.Size(324, 756);
            this.NewTreeSExp.TabIndex = 15;
            this.NewTreeSExp.Text = "";
            // 
            // OldNewSExpArrow
            // 
            this.OldNewSExpArrow.AutoSize = true;
            this.OldNewSExpArrow.BackColor = System.Drawing.SystemColors.Control;
            this.OldNewSExpArrow.Location = new System.Drawing.Point(360, 152);
            this.OldNewSExpArrow.Name = "OldNewSExpArrow";
            this.OldNewSExpArrow.Size = new System.Drawing.Size(23, 20);
            this.OldNewSExpArrow.TabIndex = 16;
            this.OldNewSExpArrow.Text = "->";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 932);
            this.Controls.Add(this.OldNewSExpArrow);
            this.Controls.Add(this.NewTreeSExp);
            this.Controls.Add(this.DeleteKeyField);
            this.Controls.Add(this.DeleteKey);
            this.Controls.Add(this.DecreaseFromToArrow);
            this.Controls.Add(this.DecreaseToKeyField);
            this.Controls.Add(this.DecreaseFromKeyField);
            this.Controls.Add(this.DecreaseKey);
            this.Controls.Add(this.DeleteMin);
            this.Controls.Add(this.LastRandomIncluded);
            this.Controls.Add(this.IncludeRandom);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Include);
            this.Controls.Add(this.IncludeField);
            this.Controls.Add(this.OldTreeSExp);
            this.Controls.Add(this.TreeChooser);
            this.Name = "MainForm";
            this.Text = "BinarySearchTrees";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TreeChooser.ResumeLayout(false);
            this.TreeChooser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ChooseB;
        private System.Windows.Forms.GroupBox TreeChooser;
        private System.Windows.Forms.RadioButton ChooseOptimalSearch;
        private System.Windows.Forms.RadioButton ChooseFibonacci;
        private System.Windows.Forms.RichTextBox OldTreeSExp;
        private System.Windows.Forms.TextBox IncludeField;
        private System.Windows.Forms.Button Include;
        private System.Windows.Forms.RadioButton Choose23Heap;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button IncludeRandom;
        private System.Windows.Forms.TextBox LastRandomIncluded;
        private System.Windows.Forms.RadioButton ChooseFibonacciHeap;
        private System.Windows.Forms.Button DeleteMin;
        private System.Windows.Forms.Button DecreaseKey;
        private System.Windows.Forms.TextBox DecreaseFromKeyField;
        private System.Windows.Forms.TextBox DecreaseToKeyField;
        private System.Windows.Forms.Label DecreaseFromToArrow;
        private System.Windows.Forms.RadioButton ChooseBinomialHeap;
        private System.Windows.Forms.Button DeleteKey;
        private System.Windows.Forms.TextBox DeleteKeyField;
        private System.Windows.Forms.RichTextBox NewTreeSExp;
        private System.Windows.Forms.Label OldNewSExpArrow;
    }
}

