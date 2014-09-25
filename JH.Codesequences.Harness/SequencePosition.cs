using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JH.Codesequences.Lib;

namespace JH.Codesequences.Harness
{
    public partial class SequencePosition : UserControl
    {
        public delegate void OnClicked(SequencePosition sender);

        public event OnClicked Clicked;

        public Position Position { get; set; }

        public bool UsesSelectionPattern { get; set; }

        public bool Selected { get; private set; }

        public bool IsStatic
        {
            get
            {
                return this.Position.AvailableCharacters.Length == 1;
            }
        }

        public SequencePosition(int rankIndex, int viewIndex)
        {
            InitializeComponent();

            this.pos_Seq.Text = rankIndex.ToString();

            this.Position = new Position()
            {
                AvailableCharacters = Encoding.ASCII.GetBytes("0"),
                CurrentPosition = 0,
                SequenceRankIndex = rankIndex,
                SequenceViewIndex = viewIndex
            };
        }

        private void SequencePosition_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        internal void Check()
        {
            this.BackColor = Color.SkyBlue;

            if (this.Clicked != null && !this.Selected)
            {
                this.Clicked(this);
            }

            this.Selected = true;
        }

        internal void Uncheck()
        {
            this.BackColor = Color.White;

            this.Selected = false;
        }

        private void pos_Letter_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        private void pos_Seq_Click(object sender, EventArgs e)
        {
            this.Check();
        }

        internal void SetRank(int i)
        {
            this.Position.SequenceRankIndex = i;
            this.pos_Seq.Text = i.ToString();
        }

        private void SequencePosition_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Selected)
            {
                this.BackColor = Color.LemonChiffon;
            }
        }

        private void SequencePosition_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Selected)
            {
                this.BackColor = Color.White;
            }
        }

        public void RemoveCharacter(byte b)
        {
            this.Position.AvailableCharacters = this.Position.AvailableCharacters.RemoveFirst(b);

            this.UpdateStartingPosition();
        }

        public void AddCharacter(byte b)
        {
            this.Position.AvailableCharacters = this.Position.AvailableCharacters.AddToEnd(b);

            this.UpdateStartingPosition();
        }

        public void SetPosition(PatternTemplate template)
        {
            this.UsesSelectionPattern = template.UseSelectionOrdering;

            this.Position.AvailableCharacters = template.Data;

            this.UpdateStartingPosition();
        }

        internal void UpdateStartingPosition()
        {
            this.pos_Letter.Text = this.UsesSelectionPattern
                ? Encoding.ASCII.GetString(this.Position.AvailableCharacters)[0].ToString()
                : Encoding.ASCII.GetString(this.Position.OrderedCharacters)[0].ToString();
        }

        internal void Reset(int idx)
        {
            this.pos_Seq.Text = idx.ToString();
            
            this.Position = new Position()
            {
                AvailableCharacters = Encoding.ASCII.GetBytes("0"),
                CurrentPosition = 0,
                SequenceRankIndex = idx,
                SequenceViewIndex = idx
            };

            this.UpdateStartingPosition();
        }
    }
}
