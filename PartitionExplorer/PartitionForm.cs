/// -------  ToujoursEnBeta
/// Author & Copyright : Peter Luschny
/// License: Creative Commons Attribution-ShareAlike 3.0
/// Comments mail to: peter(at)luschny.de
/// Created: 2013-08-16

using System;
using System.Windows.Forms;

namespace Luschny.Tree
{
    using BinTree = Luschny.Tree.BinaryTree<System.Collections.Generic.List<int>>;
    using Direction = Luschny.Tree.PartitionTreeShowcase.Direction;
    using Generator = Luschny.Tree.PartitionTreeShowcase;
    using Tour = Luschny.Tree.BinaryTreeTraversal<System.Collections.Generic.List<int>>;
    using Traversal = Luschny.Tree.PartitionTreeShowcase.Traversal;
    using Visitor = Luschny.Tree.PartitionTreeShowcase.Visitor;

    /// <summary>
    /// PartitionForm
    /// </summary>
    public partial class PartitionForm : Form
    {
        private BinTree tree;
        private Traversal traversal;
        private Visitor visitor;
        private Direction direction;
        private int n, lastn;
        private int seq;
        private bool direct;

        /// <summary>
        /// PartitionForm
        /// </summary>
        public PartitionForm()
        {
            InitializeComponent();

            comboBoxOEIS.SelectedIndex = 0;

            traversal = Traversal.PostOrder;
            visitor = Visitor.Partition;
            direction = Direction.RightLeft;

            radioPost.Checked = true;
            radioPartition.Checked = true;
            radioRightLeft.Checked = true;

            n = 6;
            lastn = n - 1;
            numericUpDown.Value = n;
            direct = true;

            Generator.SetPrinter(WriteLineToBox);
        }

        private void radioPre_CheckedChanged(object sender, EventArgs e)
        {
            traversal = Traversal.PreOrder;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioIn_CheckedChanged(object sender, EventArgs e)
        {
            traversal = Traversal.InOrder;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioPost_CheckedChanged(object sender, EventArgs e)
        {
            traversal = Traversal.PostOrder;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioLevel_CheckedChanged(object sender, EventArgs e)
        {
            traversal = Traversal.LevelOrder;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioBranch_CheckedChanged(object sender, EventArgs e)
        {
            traversal = Traversal.BranchOrder;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioPartition_CheckedChanged(object sender, EventArgs e)
        {
            visitor = Visitor.Partition;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioConjugate_CheckedChanged(object sender, EventArgs e)
        {
            visitor = Visitor.Conjugate;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioReverse_CheckedChanged(object sender, EventArgs e)
        {
            visitor = Visitor.Reverse;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioRevConjugate_CheckedChanged(object sender, EventArgs e)
        {
            visitor = Visitor.ReverseConjugate;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioRightLeft_CheckedChanged(object sender, EventArgs e)
        {
            direction = Direction.RightLeft;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void radioLeftRight_CheckedChanged(object sender, EventArgs e)
        {
            direction = Direction.LeftRight;
            if (direct) comboBoxOEIS.SelectedIndex = 0;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            n = (int)numericUpDown.Value;
        }

        private void comboBoxOEIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            seq = comboBoxOEIS.SelectedIndex;
            if (seq > 0)
            {
                var oeis = Generator.oeis;

                traversal = oeis[seq - 1].Item2;
                visitor = oeis[seq - 1].Item3;
                direction = oeis[seq - 1].Item4;

                direct = false;
                switch (traversal)
                {
                    case Traversal.PostOrder:
                        radioPost.Checked = true;
                        break;
                    case Traversal.PreOrder:
                        radioPre.Checked = true;
                        break;
                }

                switch (visitor)
                {
                    case Visitor.Partition:
                        radioPartition.Checked = true;
                        break;
                    case Visitor.Conjugate:
                        radioConjugate.Checked = true;
                        break;
                    case Visitor.Reverse:
                        radioReverse.Checked = true;
                        break;
                    case Visitor.ReverseConjugate:
                        radioRevConjugate.Checked = true;
                        break;
                }

                switch (direction)
                {
                    case Direction.RightLeft:
                        radioRightLeft.Checked = true;
                        break;
                    case Direction.LeftRight:
                        radioLeftRight.Checked = true;
                        break;
                }
                direct = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            seq = comboBoxOEIS.SelectedIndex;
            if (seq > 0)
            {
                var oeis = Generator.oeis;
                WriteLineToBox(oeis[seq - 1].Item1);
            }

            if (n != lastn)
            {
                tree = Partitions.PartitionTree(n);
                lastn = n;
            }

            var tour = new Tour(tree);
            Generator.Traverse(tour, traversal, visitor, direction);
            var count = tree.Count(tree.GetRoot()).ToString();
            WriteLineToBox("Number of partitions: " + count);
            WriteLineToBox("");
        }

        public void WriteLineToBox(string text)
        {
            richTextBox.AppendText(text + "\n");
            richTextBox.ScrollToCaret();
            richTextBox.Focus();
        }
    }

}
