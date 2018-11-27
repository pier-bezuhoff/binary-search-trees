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
            this.Choose23Heap = new System.Windows.Forms.RadioButton();
            this.ChooseOptimalSearch = new System.Windows.Forms.RadioButton();
            this.ChooseFibonacci = new System.Windows.Forms.RadioButton();
            this.TreeSExp = new System.Windows.Forms.RichTextBox();
            this.IncludeField = new System.Windows.Forms.TextBox();
            this.Include = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.IncludeRandom = new System.Windows.Forms.Button();
            this.LastRandomIncluded = new System.Windows.Forms.TextBox();
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
            this.TreeChooser.Controls.Add(this.Choose23Heap);
            this.TreeChooser.Controls.Add(this.ChooseOptimalSearch);
            this.TreeChooser.Controls.Add(this.ChooseFibonacci);
            this.TreeChooser.Controls.Add(this.ChooseB);
            this.TreeChooser.Location = new System.Drawing.Point(31, 31);
            this.TreeChooser.Name = "TreeChooser";
            this.TreeChooser.Size = new System.Drawing.Size(682, 70);
            this.TreeChooser.TabIndex = 1;
            this.TreeChooser.TabStop = false;
            this.TreeChooser.Text = "Tree";
            // 
            // Choose23Heap
            // 
            this.Choose23Heap.AutoSize = true;
            this.Choose23Heap.Checked = true;
            this.Choose23Heap.Location = new System.Drawing.Point(489, 25);
            this.Choose23Heap.Name = "Choose23Heap";
            this.Choose23Heap.Size = new System.Drawing.Size(97, 24);
            this.Choose23Heap.TabIndex = 3;
            this.Choose23Heap.TabStop = true;
            this.Choose23Heap.Text = "2-3 heap";
            this.Choose23Heap.UseVisualStyleBackColor = true;
            this.Choose23Heap.CheckedChanged += new System.EventHandler(this.Choose23Heap_CheckedChanged);
            // 
            // ChooseOptimalSearch
            // 
            this.ChooseOptimalSearch.AutoSize = true;
            this.ChooseOptimalSearch.Location = new System.Drawing.Point(302, 25);
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
            this.ChooseFibonacci.Location = new System.Drawing.Point(150, 25);
            this.ChooseFibonacci.Name = "ChooseFibonacci";
            this.ChooseFibonacci.Size = new System.Drawing.Size(134, 24);
            this.ChooseFibonacci.TabIndex = 1;
            this.ChooseFibonacci.Text = "Fibonacci tree";
            this.ChooseFibonacci.UseVisualStyleBackColor = true;
            this.ChooseFibonacci.CheckedChanged += new System.EventHandler(this.ChooseFibonacci_CheckedChanged);
            // 
            // TreeSExp
            // 
            this.TreeSExp.Location = new System.Drawing.Point(31, 119);
            this.TreeSExp.Name = "TreeSExp";
            this.TreeSExp.ReadOnly = true;
            this.TreeSExp.Size = new System.Drawing.Size(682, 801);
            this.TreeSExp.TabIndex = 2;
            this.TreeSExp.Text = "";
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
            this.Clear.Location = new System.Drawing.Point(895, 190);
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
            this.IncludeRandom.Size = new System.Drawing.Size(187, 30);
            this.IncludeRandom.TabIndex = 6;
            this.IncludeRandom.Text = "Include random";
            this.IncludeRandom.UseVisualStyleBackColor = true;
            this.IncludeRandom.Click += new System.EventHandler(this.IncludeRandom_Click);
            // 
            // LastRandomIncluded
            // 
            this.LastRandomIncluded.Location = new System.Drawing.Point(895, 143);
            this.LastRandomIncluded.Name = "LastRandomIncluded";
            this.LastRandomIncluded.ReadOnly = true;
            this.LastRandomIncluded.Size = new System.Drawing.Size(187, 26);
            this.LastRandomIncluded.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 932);
            this.Controls.Add(this.LastRandomIncluded);
            this.Controls.Add(this.IncludeRandom);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Include);
            this.Controls.Add(this.IncludeField);
            this.Controls.Add(this.TreeSExp);
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
        private System.Windows.Forms.RichTextBox TreeSExp;
        private System.Windows.Forms.TextBox IncludeField;
        private System.Windows.Forms.Button Include;
        private System.Windows.Forms.RadioButton Choose23Heap;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button IncludeRandom;
        private System.Windows.Forms.TextBox LastRandomIncluded;
    }
}

