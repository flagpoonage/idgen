namespace JH.Codesequences.Harness
{
    partial class TestForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.initCodeTb = new System.Windows.Forms.TextBox();
            this.currentCodeTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.advancePosition = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.advanceBtn = new System.Windows.Forms.Button();
            this.outputChk = new System.Windows.Forms.CheckBox();
            this.codeList = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxCodeTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.randomButton = new System.Windows.Forms.Button();
            this.validationText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.advancePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial Code";
            // 
            // initCodeTb
            // 
            this.initCodeTb.Location = new System.Drawing.Point(15, 25);
            this.initCodeTb.Name = "initCodeTb";
            this.initCodeTb.ReadOnly = true;
            this.initCodeTb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.initCodeTb.Size = new System.Drawing.Size(245, 20);
            this.initCodeTb.TabIndex = 1;
            // 
            // currentCodeTb
            // 
            this.currentCodeTb.Location = new System.Drawing.Point(15, 114);
            this.currentCodeTb.Name = "currentCodeTb";
            this.currentCodeTb.ReadOnly = true;
            this.currentCodeTb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.currentCodeTb.Size = new System.Drawing.Size(245, 20);
            this.currentCodeTb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Code";
            // 
            // advancePosition
            // 
            this.advancePosition.Location = new System.Drawing.Point(15, 154);
            this.advancePosition.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.advancePosition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.advancePosition.Name = "advancePosition";
            this.advancePosition.Size = new System.Drawing.Size(245, 20);
            this.advancePosition.TabIndex = 4;
            this.advancePosition.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Advance by";
            // 
            // advanceBtn
            // 
            this.advanceBtn.Location = new System.Drawing.Point(15, 242);
            this.advanceBtn.Name = "advanceBtn";
            this.advanceBtn.Size = new System.Drawing.Size(120, 27);
            this.advanceBtn.TabIndex = 6;
            this.advanceBtn.Text = "Advance Code";
            this.advanceBtn.UseVisualStyleBackColor = true;
            this.advanceBtn.Click += new System.EventHandler(this.advanceBtnClick);
            // 
            // outputChk
            // 
            this.outputChk.AutoSize = true;
            this.outputChk.Checked = true;
            this.outputChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outputChk.Location = new System.Drawing.Point(15, 219);
            this.outputChk.Name = "outputChk";
            this.outputChk.Size = new System.Drawing.Size(133, 17);
            this.outputChk.TabIndex = 7;
            this.outputChk.Text = "Advance incrementally";
            this.outputChk.UseVisualStyleBackColor = true;
            this.outputChk.CheckedChanged += new System.EventHandler(this.outputChk_CheckedChanged);
            // 
            // codeList
            // 
            this.codeList.FormattingEnabled = true;
            this.codeList.Location = new System.Drawing.Point(278, 25);
            this.codeList.Name = "codeList";
            this.codeList.Size = new System.Drawing.Size(274, 316);
            this.codeList.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Advanced Codes";
            // 
            // maxCodeTb
            // 
            this.maxCodeTb.Location = new System.Drawing.Point(15, 71);
            this.maxCodeTb.Name = "maxCodeTb";
            this.maxCodeTb.ReadOnly = true;
            this.maxCodeTb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maxCodeTb.Size = new System.Drawing.Size(245, 20);
            this.maxCodeTb.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max Code";
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(141, 242);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(119, 27);
            this.randomButton.TabIndex = 12;
            this.randomButton.Text = "Random Code";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // validationText
            // 
            this.validationText.Location = new System.Drawing.Point(15, 298);
            this.validationText.Name = "validationText";
            this.validationText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.validationText.Size = new System.Drawing.Size(245, 20);
            this.validationText.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Code to validate";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Validate Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Increment Size";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(15, 193);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(245, 20);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 363);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.validationText);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.maxCodeTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codeList);
            this.Controls.Add(this.outputChk);
            this.Controls.Add(this.advanceBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.advancePosition);
            this.Controls.Add(this.currentCodeTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.initCodeTb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patternal - Code Tester";
            ((System.ComponentModel.ISupportInitialize)(this.advancePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox initCodeTb;
        private System.Windows.Forms.TextBox currentCodeTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown advancePosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button advanceBtn;
        private System.Windows.Forms.CheckBox outputChk;
        private System.Windows.Forms.ListBox codeList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maxCodeTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.TextBox validationText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}