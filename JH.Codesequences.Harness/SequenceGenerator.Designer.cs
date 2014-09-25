namespace JH.Codesequences.Harness
{
    partial class SequenceGenerator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.charCount_numeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.seq_panel = new System.Windows.Forms.Panel();
            this.sequenceCharsTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.advance_numeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.asciiCheckboard = new JH.Codesequences.Harness.ASCIICheckboard();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.charCount_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // charCount_numeric
            // 
            this.charCount_numeric.Location = new System.Drawing.Point(20, 26);
            this.charCount_numeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.charCount_numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.charCount_numeric.Name = "charCount_numeric";
            this.charCount_numeric.ReadOnly = true;
            this.charCount_numeric.Size = new System.Drawing.Size(120, 20);
            this.charCount_numeric.TabIndex = 0;
            this.charCount_numeric.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.charCount_numeric.ValueChanged += new System.EventHandler(this.charCount_numeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Character Count";
            // 
            // seq_panel
            // 
            this.seq_panel.BackColor = System.Drawing.Color.LightGray;
            this.seq_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.seq_panel.Location = new System.Drawing.Point(20, 57);
            this.seq_panel.Name = "seq_panel";
            this.seq_panel.Size = new System.Drawing.Size(519, 62);
            this.seq_panel.TabIndex = 22;
            // 
            // sequenceCharsTb
            // 
            this.sequenceCharsTb.Location = new System.Drawing.Point(19, 402);
            this.sequenceCharsTb.Name = "sequenceCharsTb";
            this.sequenceCharsTb.ReadOnly = true;
            this.sequenceCharsTb.Size = new System.Drawing.Size(511, 20);
            this.sequenceCharsTb.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Sequence";
            // 
            // advance_numeric
            // 
            this.advance_numeric.Location = new System.Drawing.Point(20, 152);
            this.advance_numeric.Name = "advance_numeric";
            this.advance_numeric.ReadOnly = true;
            this.advance_numeric.Size = new System.Drawing.Size(74, 20);
            this.advance_numeric.TabIndex = 1;
            this.advance_numeric.ValueChanged += new System.EventHandler(this.OrderChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Advance order";
            // 
            // asciiCheckboard
            // 
            this.asciiCheckboard.BackColor = System.Drawing.Color.LightGray;
            this.asciiCheckboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.asciiCheckboard.Location = new System.Drawing.Point(20, 191);
            this.asciiCheckboard.Name = "asciiCheckboard";
            this.asciiCheckboard.Size = new System.Drawing.Size(510, 181);
            this.asciiCheckboard.TabIndex = 24;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Standard ordering",
            "Order by selection"});
            this.comboBox1.Location = new System.Drawing.Point(112, 151);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 21);
            this.comboBox1.TabIndex = 91;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.OrderMethodChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Pattern order method";
            // 
            // SequenceGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.asciiCheckboard);
            this.Controls.Add(this.sequenceCharsTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seq_panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.charCount_numeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.advance_numeric);
            this.Name = "SequenceGenerator";
            this.Size = new System.Drawing.Size(553, 457);
            ((System.ComponentModel.ISupportInitialize)(this.charCount_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advance_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown charCount_numeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel seq_panel;
        private System.Windows.Forms.NumericUpDown advance_numeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sequenceCharsTb;
        private System.Windows.Forms.Label label3;
        private ASCIICheckboard asciiCheckboard;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}
