namespace Luschny.Tree
{
    partial class PartitionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderBox = new System.Windows.Forms.GroupBox();
            this.radioBranch = new System.Windows.Forms.RadioButton();
            this.radioLevel = new System.Windows.Forms.RadioButton();
            this.radioPost = new System.Windows.Forms.RadioButton();
            this.radioIn = new System.Windows.Forms.RadioButton();
            this.radioPre = new System.Windows.Forms.RadioButton();
            this.traverseBox = new System.Windows.Forms.GroupBox();
            this.radioLeftRight = new System.Windows.Forms.RadioButton();
            this.radioRightLeft = new System.Windows.Forms.RadioButton();
            this.computeBox = new System.Windows.Forms.GroupBox();
            this.radioRevConjugate = new System.Windows.Forms.RadioButton();
            this.radioReverse = new System.Windows.Forms.RadioButton();
            this.radioConjugate = new System.Windows.Forms.RadioButton();
            this.radioPartition = new System.Windows.Forms.RadioButton();
            this.buttonRun = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBoxOEIS = new System.Windows.Forms.ComboBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.orderBox.SuspendLayout();
            this.traverseBox.SuspendLayout();
            this.computeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderBox
            // 
            this.orderBox.Controls.Add(this.radioBranch);
            this.orderBox.Controls.Add(this.radioLevel);
            this.orderBox.Controls.Add(this.radioPost);
            this.orderBox.Controls.Add(this.radioIn);
            this.orderBox.Controls.Add(this.radioPre);
            this.orderBox.Location = new System.Drawing.Point(16, 71);
            this.orderBox.Name = "orderBox";
            this.orderBox.Size = new System.Drawing.Size(202, 182);
            this.orderBox.TabIndex = 0;
            this.orderBox.TabStop = false;
            this.orderBox.Text = "Order";
            // 
            // radioBranch
            // 
            this.radioBranch.Location = new System.Drawing.Point(38, 142);
            this.radioBranch.Name = "radioBranch";
            this.radioBranch.Size = new System.Drawing.Size(114, 24);
            this.radioBranch.TabIndex = 4;
            this.radioBranch.Text = "Branchorder";
            this.radioBranch.UseVisualStyleBackColor = true;
            this.radioBranch.CheckedChanged += new System.EventHandler(this.radioBranch_CheckedChanged);
            // 
            // radioLevel
            // 
            this.radioLevel.Location = new System.Drawing.Point(38, 112);
            this.radioLevel.Name = "radioLevel";
            this.radioLevel.Size = new System.Drawing.Size(114, 24);
            this.radioLevel.TabIndex = 3;
            this.radioLevel.Text = "Levelorder";
            this.radioLevel.UseVisualStyleBackColor = true;
            this.radioLevel.CheckedChanged += new System.EventHandler(this.radioLevel_CheckedChanged);
            // 
            // radioPost
            // 
            this.radioPost.Checked = true;
            this.radioPost.Location = new System.Drawing.Point(38, 82);
            this.radioPost.Name = "radioPost";
            this.radioPost.Size = new System.Drawing.Size(114, 24);
            this.radioPost.TabIndex = 2;
            this.radioPost.TabStop = true;
            this.radioPost.Text = "Postorder";
            this.radioPost.UseVisualStyleBackColor = true;
            this.radioPost.CheckedChanged += new System.EventHandler(this.radioPost_CheckedChanged);
            // 
            // radioIn
            // 
            this.radioIn.Location = new System.Drawing.Point(38, 52);
            this.radioIn.Name = "radioIn";
            this.radioIn.Size = new System.Drawing.Size(104, 24);
            this.radioIn.TabIndex = 1;
            this.radioIn.Text = "Inorder";
            this.radioIn.UseVisualStyleBackColor = true;
            this.radioIn.CheckedChanged += new System.EventHandler(this.radioIn_CheckedChanged);
            // 
            // radioPre
            // 
            this.radioPre.Location = new System.Drawing.Point(38, 22);
            this.radioPre.Name = "radioPre";
            this.radioPre.Size = new System.Drawing.Size(104, 24);
            this.radioPre.TabIndex = 0;
            this.radioPre.Text = "Preorder";
            this.radioPre.UseVisualStyleBackColor = true;
            this.radioPre.CheckedChanged += new System.EventHandler(this.radioPre_CheckedChanged);
            // 
            // traverseBox
            // 
            this.traverseBox.Controls.Add(this.radioLeftRight);
            this.traverseBox.Controls.Add(this.radioRightLeft);
            this.traverseBox.Location = new System.Drawing.Point(16, 442);
            this.traverseBox.Name = "traverseBox";
            this.traverseBox.Size = new System.Drawing.Size(202, 87);
            this.traverseBox.TabIndex = 1;
            this.traverseBox.TabStop = false;
            this.traverseBox.Text = "Traverse";
            // 
            // radioLeftRight
            // 
            this.radioLeftRight.Location = new System.Drawing.Point(38, 52);
            this.radioLeftRight.Name = "radioLeftRight";
            this.radioLeftRight.Size = new System.Drawing.Size(114, 24);
            this.radioLeftRight.TabIndex = 1;
            this.radioLeftRight.Text = "Left to Right";
            this.radioLeftRight.UseVisualStyleBackColor = true;
            this.radioLeftRight.CheckedChanged += new System.EventHandler(this.radioLeftRight_CheckedChanged);
            // 
            // radioRightLeft
            // 
            this.radioRightLeft.Checked = true;
            this.radioRightLeft.Location = new System.Drawing.Point(38, 22);
            this.radioRightLeft.Name = "radioRightLeft";
            this.radioRightLeft.Size = new System.Drawing.Size(114, 24);
            this.radioRightLeft.TabIndex = 0;
            this.radioRightLeft.TabStop = true;
            this.radioRightLeft.Text = "Right to Left";
            this.radioRightLeft.UseVisualStyleBackColor = true;
            this.radioRightLeft.CheckedChanged += new System.EventHandler(this.radioRightLeft_CheckedChanged);
            // 
            // computeBox
            // 
            this.computeBox.Controls.Add(this.radioRevConjugate);
            this.computeBox.Controls.Add(this.radioReverse);
            this.computeBox.Controls.Add(this.radioConjugate);
            this.computeBox.Controls.Add(this.radioPartition);
            this.computeBox.Location = new System.Drawing.Point(16, 271);
            this.computeBox.Name = "computeBox";
            this.computeBox.Size = new System.Drawing.Size(202, 154);
            this.computeBox.TabIndex = 3;
            this.computeBox.TabStop = false;
            this.computeBox.Text = "Compute";
            // 
            // radioRevConjugate
            // 
            this.radioRevConjugate.Location = new System.Drawing.Point(38, 112);
            this.radioRevConjugate.Name = "radioRevConjugate";
            this.radioRevConjugate.Size = new System.Drawing.Size(119, 24);
            this.radioRevConjugate.TabIndex = 3;
            this.radioRevConjugate.Text = "RevConjugate";
            this.radioRevConjugate.UseVisualStyleBackColor = true;
            this.radioRevConjugate.CheckedChanged += new System.EventHandler(this.radioRevConjugate_CheckedChanged);
            // 
            // radioReverse
            // 
            this.radioReverse.Location = new System.Drawing.Point(38, 82);
            this.radioReverse.Name = "radioReverse";
            this.radioReverse.Size = new System.Drawing.Size(104, 24);
            this.radioReverse.TabIndex = 2;
            this.radioReverse.Text = "Reverse";
            this.radioReverse.UseVisualStyleBackColor = true;
            this.radioReverse.CheckedChanged += new System.EventHandler(this.radioReverse_CheckedChanged);
            // 
            // radioConjugate
            // 
            this.radioConjugate.Location = new System.Drawing.Point(38, 52);
            this.radioConjugate.Name = "radioConjugate";
            this.radioConjugate.Size = new System.Drawing.Size(104, 24);
            this.radioConjugate.TabIndex = 1;
            this.radioConjugate.Text = "Conjugate";
            this.radioConjugate.UseVisualStyleBackColor = true;
            this.radioConjugate.CheckedChanged += new System.EventHandler(this.radioConjugate_CheckedChanged);
            // 
            // radioPartition
            // 
            this.radioPartition.Checked = true;
            this.radioPartition.Location = new System.Drawing.Point(38, 22);
            this.radioPartition.Name = "radioPartition";
            this.radioPartition.Size = new System.Drawing.Size(104, 24);
            this.radioPartition.TabIndex = 0;
            this.radioPartition.TabStop = true;
            this.radioPartition.Text = "Partition";
            this.radioPartition.UseVisualStyleBackColor = true;
            this.radioPartition.CheckedChanged += new System.EventHandler(this.radioPartition_CheckedChanged);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(54, 592);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(119, 32);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(54, 548);
            this.numericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(119, 22);
            this.numericUpDown.TabIndex = 6;
            this.numericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // comboBoxOEIS
            // 
            this.comboBoxOEIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOEIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.comboBoxOEIS.FormattingEnabled = true;
            this.comboBoxOEIS.Items.AddRange(new object[] {
            "OEIS Sequences",
            "A228100 Fenner-Loizou tree",
            "A036036 Hindenburg, HMF",
            "A080577 Mathematica, Sage",
            "A080576 Maple",
            "A036037",
            "A182937",
            "A193073"});
            this.comboBoxOEIS.Location = new System.Drawing.Point(16, 25);
            this.comboBoxOEIS.Name = "comboBoxOEIS";
            this.comboBoxOEIS.Size = new System.Drawing.Size(202, 24);
            this.comboBoxOEIS.TabIndex = 7;
            this.comboBoxOEIS.Tag = "";
            this.comboBoxOEIS.SelectedIndexChanged += new System.EventHandler(this.comboBoxOEIS_SelectedIndexChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.comboBoxOEIS);
            this.splitContainer.Panel1.Controls.Add(this.numericUpDown);
            this.splitContainer.Panel1.Controls.Add(this.buttonRun);
            this.splitContainer.Panel1.Controls.Add(this.computeBox);
            this.splitContainer.Panel1.Controls.Add(this.traverseBox);
            this.splitContainer.Panel1.Controls.Add(this.orderBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.richTextBox);
            this.splitContainer.Size = new System.Drawing.Size(572, 643);
            this.splitContainer.SplitterDistance = 229;
            this.splitContainer.TabIndex = 0;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.HotTrack;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.ForeColor = System.Drawing.Color.Gold;
            this.richTextBox.Location = new System.Drawing.Point(8, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(319, 612);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // PartitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 643);
            this.Controls.Add(this.splitContainer);
            this.Name = "PartitionForm";
            this.Text = "Partition Trees";
            this.orderBox.ResumeLayout(false);
            this.traverseBox.ResumeLayout(false);
            this.computeBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox orderBox;
        private System.Windows.Forms.RadioButton radioBranch;
        private System.Windows.Forms.RadioButton radioLevel;
        private System.Windows.Forms.RadioButton radioPost;
        private System.Windows.Forms.RadioButton radioIn;
        private System.Windows.Forms.RadioButton radioPre;
        private System.Windows.Forms.GroupBox traverseBox;
        private System.Windows.Forms.RadioButton radioLeftRight;
        private System.Windows.Forms.RadioButton radioRightLeft;
        private System.Windows.Forms.GroupBox computeBox;
        private System.Windows.Forms.RadioButton radioRevConjugate;
        private System.Windows.Forms.RadioButton radioReverse;
        private System.Windows.Forms.RadioButton radioConjugate;
        private System.Windows.Forms.RadioButton radioPartition;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ComboBox comboBoxOEIS;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.RichTextBox richTextBox;

    }
}

