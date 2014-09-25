namespace JH.Codesequences.Harness
{
    partial class SequencePosition
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
            this.pos_Letter = new System.Windows.Forms.Label();
            this.pos_Seq = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pos_Letter
            // 
            this.pos_Letter.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pos_Letter.Location = new System.Drawing.Point(0, 0);
            this.pos_Letter.Name = "pos_Letter";
            this.pos_Letter.Size = new System.Drawing.Size(25, 24);
            this.pos_Letter.TabIndex = 0;
            this.pos_Letter.Text = "0";
            this.pos_Letter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pos_Letter.Click += new System.EventHandler(this.pos_Letter_Click);
            this.pos_Letter.MouseEnter += new System.EventHandler(this.SequencePosition_MouseEnter);
            this.pos_Letter.MouseLeave += new System.EventHandler(this.SequencePosition_MouseLeave);
            // 
            // pos_Seq
            // 
            this.pos_Seq.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pos_Seq.Location = new System.Drawing.Point(0, 38);
            this.pos_Seq.Name = "pos_Seq";
            this.pos_Seq.Size = new System.Drawing.Size(25, 13);
            this.pos_Seq.TabIndex = 1;
            this.pos_Seq.Text = "0";
            this.pos_Seq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pos_Seq.Click += new System.EventHandler(this.pos_Seq_Click);
            this.pos_Seq.MouseEnter += new System.EventHandler(this.SequencePosition_MouseEnter);
            this.pos_Seq.MouseLeave += new System.EventHandler(this.SequencePosition_MouseLeave);
            // 
            // SequencePosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pos_Seq);
            this.Controls.Add(this.pos_Letter);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SequencePosition";
            this.Size = new System.Drawing.Size(25, 62);
            this.Click += new System.EventHandler(this.SequencePosition_Click);
            this.MouseEnter += new System.EventHandler(this.SequencePosition_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SequencePosition_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pos_Letter;
        private System.Windows.Forms.Label pos_Seq;
    }
}
