using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH.Codesequences.Harness
{
    public partial class ASCIIPressbox : UserControl
    {
        public delegate void OnClicked(ASCIIPressbox sender);

        public event OnClicked Clicked;

        private char character;

        public byte Value { get; set; }

        public bool Checked { get; set; }

        public char Character
        {
            get
            {
                return this.character;
            }
            set
            {
                this.character = value;
                this.label1.Text = this.character.ToString();
            }
        }

        public ASCIIPressbox()
        {
            InitializeComponent();
        }

        private void PressboxMouseEnter(object sender, EventArgs e)
        {
            if (!this.Checked)
            {
                this.BackColor = Color.LemonChiffon;
            }
        }

        private void PressboxMouseLeave(object sender, EventArgs e)
        {
            if (!this.Checked)
            {
                this.BackColor = Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Checked = !this.Checked;

            if (this.Checked)
            {
                this.BackColor = Color.SkyBlue;
            }
            else
            {
                this.BackColor = Color.LemonChiffon;
            }

            if (this.Clicked != null)
            {
                this.Clicked(this);
            }
        }

        internal void Check()
        {
            this.Checked = true;
            this.BackColor = Color.SkyBlue;
        }

        internal void Uncheck()
        {
            this.Checked = false;
            this.BackColor = Color.White;
        }
    }
}
