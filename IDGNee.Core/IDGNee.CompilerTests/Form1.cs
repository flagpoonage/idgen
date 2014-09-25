using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDGNee.CompilerTests
{
    public partial class InstructionCompiler : Form
    {
        public InstructionCompiler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var compiler = new IDGNee.Core.Compilers.InstructionCompiler();

            try
            {
                var output = compiler.Compile(textBox1.Text);

                textBox2.Text = "Compilation successful!";
            }
            catch(Exception ex)
            {
                textBox2.Text = ex.ToString();
            }
        }
    }
}
