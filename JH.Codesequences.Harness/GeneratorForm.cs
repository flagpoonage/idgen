using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH.Codesequences.Harness
{
    public partial class GeneratorForm : Form
    {
        public List<PatternTemplate> Templates { get; set; }

        public GeneratorForm()
        {
            InitializeComponent();

            this.Templates = new List<PatternTemplate>();

            this.FormClosing += GeneratorForm_FormClosing;

            this.LoadTemplates();

            this.saveFileDialog1.DefaultExt = "sqc";

            var di = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;

            var savepath = Path.Combine(di.FullName, "Sequences");

            if(!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            this.saveFileDialog1.InitialDirectory = savepath;
            this.saveFileDialog1.FileName = "NewSequence.sqc";
            this.saveFileDialog1.Filter = "Sequence Files (*.sqc)|*.sqc";
        }

        void GeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.CheckExit())
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckExit())
            {
                Application.Exit();
            }
        }

        private bool CheckExit()
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "Exit program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private bool CheckSequenceReset()
        {
            if (MessageBox.Show("Are you sure you want to reset the sequence?", "Reset sequence", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void testSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sequence = this.sequenceGenerator1.GenerateSequence();

            var testform = new TestForm(sequence);

            testform.ShowDialog();
        }

        private void sequenceGenerator1_Load(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CheckSequenceReset())
            {
                this.sequenceGenerator1.Reset();
            }
        }

        public void LoadTemplates()
        {
            var files = Directory.GetFiles("Templates");

            foreach (var f in files)
            {
                var pt = PatternTemplate.LoadFromFile(f);

                if (pt != null)
                {
                    this.Templates.Add(pt);

                    this.positionToolStripMenuItem.DropDownItems.Add(
                        new ToolStripMenuItem(pt.Name, null, SelectTemplate));
                }
            }

        }

        private void SelectTemplate(object sender, EventArgs e)
        {
            var t = this.Templates.SingleOrDefault(a => a.Name == ((ToolStripMenuItem)sender).Text);

            this.sequenceGenerator1.SetTemplate(t);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.saveFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var location = this.saveFileDialog1.FileName;

                var sq = this.sequenceGenerator1.GenerateSequenceByteData();

                var str = sq.Select(a => a.ToString()).Aggregate((a, b) => string.Format("{0}, {1}", a, b));

                using (var sw = new StreamWriter(location))
                {
                    sw.Write(Encoding.ASCII.GetString(sq));
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.openFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                using (var sr = new StreamReader(this.openFileDialog1.FileName))
                {
                    var str = sr.ReadToEnd();

                    var bytes = Encoding.ASCII.GetBytes(str);

                    this.sequenceGenerator1.LoadSequence(bytes);
                }
            }
        }
    }
}
