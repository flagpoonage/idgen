using JH.Codesequences.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH.Codesequences.Harness
{
    public partial class TestForm : Form
    {
        private CodeSequence Sequence;

        public TestForm(CodeSequence sequence)
        {
            InitializeComponent();

            this.Sequence = sequence;


            this.Sequence.Max();
            this.maxCodeTb.Text = this.Sequence.GetCurrentCode();

            this.Sequence.Reset();
            this.initCodeTb.Text = this.Sequence.GetCurrentCode();
            this.currentCodeTb.Text = this.Sequence.GetCurrentCode();
        }

        private void advanceBtnClick(object sender, EventArgs e)
        {
            this.codeList.Items.Clear();

            if (this.outputChk.Checked)
            {
                for (int i = 0; i < advancePosition.Value; i++)
                {
                    if (advancePosition.Value - i > 0 && advancePosition.Value - i < numericUpDown1.Value)
                    {
                        i += (int)advancePosition.Value - i - 1;
                        this.Sequence.Advance((int)advancePosition.Value - i);
                    }
                    else
                    {
                        i += (int)numericUpDown1.Value - 1;
                        this.Sequence.Advance((int)numericUpDown1.Value);
                    }

                    this.codeList.Items.Add(this.Sequence.GetCurrentCode());
                }
            }
            else
            {
                this.Sequence.Advance((int)advancePosition.Value);
                this.codeList.Items.Add(this.Sequence.GetCurrentCode());
            }

            this.currentCodeTb.Text = this.Sequence.GetCurrentCode();
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            this.codeList.Items.Clear();

            this.Sequence.Random();
            var code = this.Sequence.GetCurrentCode();

            if (this.outputChk.Checked)
            {
                this.codeList.Items.Add(code);
            }

            this.currentCodeTb.Text = code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = validationText.Text;

            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Please enter a code to validate.", "Empty code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                var result=  this.Sequence.Validate(str);

                if (result.IsValid)
                {
                    MessageBox.Show(string.Format("[{0}] is valid", str), "Valid code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format(result.Message, str), "Invalid code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void outputChk_CheckedChanged(object sender, EventArgs e)
        {
            if (outputChk.Checked)
            {
                this.numericUpDown1.Enabled = true;
            }
            else
            {
                this.numericUpDown1.Enabled = false;
            }
        }
    }
}
