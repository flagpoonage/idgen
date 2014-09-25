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
    public partial class SequenceGenerator : UserControl
    {
        public int PositionCount { get; private set; }

        public List<SequencePosition> Positions { get; private set; }

        public bool IsPositionSelected { get; set; }

        public SequencePosition SelectedPosition { get; set; }

        private bool CheckInitializing { get; set; }

        public SequenceGenerator()
        {
            this.Construct(8);
        }

        public SequenceGenerator(int positions = 8)
        {
            this.Construct(positions);
        }

        private void Construct(int positions)
        {
            InitializeComponent();

            this.advance_numeric.Maximum = positions - 1;

            this.Positions = new List<SequencePosition>();

            this.PositionCount = positions;

            this.GeneratePositions();

            this.asciiCheckboard.Pressed += asciiCheckboard_Pressed;
        }

        void asciiCheckboard_Pressed(ASCIIPressbox sender)
        {
            if (sender.Checked)
            {
                this.SelectedPosition.AddCharacter(sender.Value);
            }
            else
            {
                if (this.SelectedPosition.Position.AvailableCharacters.Length == 1)
                {
                    sender.Check();
                }
                else
                {
                    this.SelectedPosition.RemoveCharacter(sender.Value);
                }
            }

            this.DisplaySequence();
        }

        private void GeneratePositions(Position[] position)
        {
            var pRev = position.Reverse().ToArray();

            this.seq_panel.Controls.Clear();
            this.Positions = new List<SequencePosition>();

            for (int i = 0; i < pRev.Length; i++)
            {
                var p = new SequencePosition(i, i);

                p.Clicked += p_Clicked;

                p.Name = string.Format("posSP_{0}", i);
                
                p.SetPosition(new PatternTemplate(Encoding.ASCII.GetString(pRev[i].AvailableCharacters))
                {
                    UseSelectionOrdering = !pRev[i].AvailableCharacters.IsEqualTo(pRev[i].OrderedCharacters, true)
                });

                seq_panel.Controls.Add(p);

                p.Left = ((p.Width + 1) * this.PositionCount) - (i * (p.Width + 1)) - p.Width - 1;

                this.Positions.Add(p);

            }

            this.PositionCount = this.Positions.Count;

            this.Positions[0].Check();
        }

        private void GeneratePositions()
        {
            for (int i = 0; i < this.PositionCount; i++)
            {
                var p = new SequencePosition(i, i);

                p.Clicked += p_Clicked;

                p.Name = string.Format("posSP_{0}", i);

                seq_panel.Controls.Add(p);

                p.Left = ((p.Width + 1) * this.PositionCount) - (i * (p.Width + 1)) - p.Width - 1;

                this.Positions.Add(p);

            }

            this.Positions[0].Check();

        }

        void p_Clicked(SequencePosition sender)
        {
            this.SelectedPosition = sender;

            foreach (var p in this.Positions)
            {
                if (p != sender)
                {
                    p.Uncheck();
                }
            }

            this.DisplayPosition();
        }

        private void DisplayPosition()
        {
            this.DisplaySequence();
            this.DisplayKeyboard();
        }

        private void DisplaySequence()
        {
            if (this.SelectedPosition.UsesSelectionPattern)
            {
                this.comboBox1.SelectedItem = "Order by selection";
                this.sequenceCharsTb.Text = Encoding.ASCII.GetString(this.SelectedPosition.Position.AvailableCharacters);
            }
            else
            {
                this.comboBox1.SelectedItem = "Standard ordering";
                this.sequenceCharsTb.Text = Encoding.ASCII.GetString(this.SelectedPosition.Position.OrderedCharacters);
            }

            this.advance_numeric.Value = this.SelectedPosition.Position.SequenceRankIndex;
        }

        private void DisplayKeyboard()
        {
            this.asciiCheckboard.Unpress();

            this.asciiCheckboard.PressButtons(this.SelectedPosition.Position.AvailableCharacters);
        }

        private void charCount_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (charCount_numeric.Value > this.PositionCount)
            {
                this.PositionCount = (int)charCount_numeric.Value;

                this.AddPositions();
            }
            else
            {
                this.PositionCount = (int)charCount_numeric.Value;

                this.RemovePositions();
            }

            this.advance_numeric.Maximum = this.PositionCount - 1;
        }

        private void RemovePositions()
        {
            bool hasSelection = false;

            while (this.Positions.Count > this.PositionCount)
            {
                var p = this.Positions[this.Positions.Count - 1];

                if (p.Selected && !hasSelection)
                {
                    hasSelection = true;
                }

                seq_panel.Controls.Remove(p);
                this.Positions.Remove(p);

                this.ShiftPositionsLeft();
            }

            if (hasSelection)
            {
                this.Positions[this.Positions.Count - 1].Check();
            }

            var ctls = this.Positions.OrderBy(a => a.Position.SequenceRankIndex).ToArray();

            for (int i = 0; i < ctls.Length; i++)
            {
                ctls[i].SetRank(i);
            }
        }

        private void ShiftPositionsRight()
        {
            foreach (var p in this.Positions)
            {
                p.Left += p.Width + 1;
            }
        }

        private void ShiftPositionsLeft()
        {
            foreach (var p in this.Positions)
            {
                p.Left -= p.Width + 1;
            }
        }

        private void AddPositions()
        {
            while (this.Positions.Count < this.PositionCount)
            {
                this.ShiftPositionsRight();

                var p = new SequencePosition(this.Positions.Count, this.Positions.Count);

                p.Clicked += p_Clicked;

                p.Name = string.Format("posSP_{0}", this.Positions.Count);

                p.Left = 0;

                seq_panel.Controls.Add(p);

                this.Positions.Add(p);
            }
        }

        private void OrderMethodChanged(object sender, EventArgs e)
        {
            this.SelectedPosition.UsesSelectionPattern = (string)this.comboBox1.SelectedItem == "Order by selection";

            if (this.SelectedPosition.UsesSelectionPattern)
            {
                this.sequenceCharsTb.Text = Encoding.ASCII.GetString(this.SelectedPosition.Position.AvailableCharacters);
            }
            else
            {
                this.sequenceCharsTb.Text = Encoding.ASCII.GetString(this.SelectedPosition.Position.OrderedCharacters);
            }

            this.SelectedPosition.UpdateStartingPosition();
        }

        private void OrderChanged(object sender, EventArgs e)
        {
            var p = this.Positions.SingleOrDefault(a => a.Position.SequenceRankIndex == (int)this.advance_numeric.Value);

            p.SetRank(this.SelectedPosition.Position.SequenceRankIndex);

            this.SelectedPosition.SetRank((int)this.advance_numeric.Value);
        }

        internal CodeSequence GenerateSequence()
        {
            var bytes = this.GenerateSequenceByteData();

            var sq = CodeSequence.CreateFromBytes(bytes, true);
            
            return sq;
        }

        private byte[] JoinBytesBy(List<IEnumerable<byte>> bytes, byte seperator)
        {
            var data = new List<byte>();

            for (int i = 0; i < bytes.Count; i++)
            {
                data.AddRange(bytes[i]);

                if (i != bytes.Count - 1)
                {
                    // Group seperator
                    data.Add(29);
                }
            }

            return data.ToArray();
        }

        public byte[] GenerateSequenceByteData()
        {
            var currentPosition = new byte[this.Positions.Count];

            var patternList = new List<byte[]>();
            var positionalBytes = new List<byte>();
            var patternalBytes = new List<byte>();

            var sequencing = new byte[this.Positions.Count];

            //for (int i = 0; i < this.Positions.Count; i++)
            //{
            //    var p = this.Positions.Select(a => a.Position.SequenceRankIndex).ToArray();

            //    sequencing[i] = (byte)p[i];
            //}

            for (int i = 0; i < this.Positions.Count; i++)
            {
                sequencing[i] = (byte)this.Positions[i].Position.SequenceRankIndex;
                currentPosition[i] = this.Positions[i].Position.AvailableCharacters[0];

                if (this.Positions[i].Position.AvailableCharacters.Length != 1)
                {
                    if (this.Positions[i].UsesSelectionPattern)
                    {
                        patternList.Add(this.Positions[i].Position.AvailableCharacters);
                    }
                    else
                    {
                        patternList.Add(this.Positions[i].Position.OrderedCharacters);
                    }
                }
            }

            //currentPosition = currentPosition.Reverse().ToArray();

            patternList = this.CreateUniquePatterns(patternList);

            for (int i = 0; i < patternList.Count; i++)
            {
                patternalBytes.AddRange(patternList[i]);

                if (i != patternList.Count - 1)
                {
                    patternalBytes.Add(30);
                }
            }

            for (int i = 0; i < this.Positions.Count; i++)
            {
                if (this.Positions[i].Position.AvailableCharacters.Length == 1)
                {
                    positionalBytes.Add(this.Positions[i].Position.AvailableCharacters[0]);

                }
                else
                {
                    var pIdx = 0;

                    if (this.Positions[i].UsesSelectionPattern)
                    {
                        pIdx = patternList.IndexOfValues(this.Positions[i].Position.AvailableCharacters);
                    }
                    else
                    {
                        pIdx = patternList.IndexOfValues(this.Positions[i].Position.OrderedCharacters);
                    }

                    positionalBytes.AddRange(new byte[] { 26, (byte)pIdx });
                }

                if (i != this.Positions.Count - 1)
                {
                    positionalBytes.Add(30);
                }
            }

            sequencing = sequencing.Reverse().ToArray();

            return this.JoinBytesBy(
                new List<IEnumerable<byte>>()
                {
                    currentPosition,
                    positionalBytes,
                    patternalBytes,
                    sequencing,
                },
                29);
        }

        private List<byte[]> CreateUniquePatterns(List<byte[]> patternList)
        {
            var unique = new List<byte[]>();

            foreach (var p in patternList)
            {
                var isUnique = true;

                for (int i = 0; i < unique.Count; i++)
                {
                    if (unique[i].IsEqualTo(p, true))
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    unique.Add(p);
                }
            }

            return unique;
        }


        internal void SetTemplate(PatternTemplate template)
        {
            this.SelectedPosition.SetPosition(template);

            this.DisplayPosition();
        }

        internal void Reset()
        {
            this.PositionCount = 8;
            this.RemovePositions();

            for (int i = 0; i < this.PositionCount; i++)
            {
                this.Positions[i].Reset(i);
            }

            this.DisplayPosition();
        }

        internal void LoadSequence(byte[] bytes)
        {
            var cs = CodeSequence.CreateFromBytes(bytes, true);

            this.Positions = new List<SequencePosition>(); 

            this.GeneratePositions(cs.Positions);

            this.DisplayPosition();
        }
    }
}
