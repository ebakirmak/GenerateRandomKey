namespace GenerateKey
{
    partial class frmKeyGenerate
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
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblKeyLength = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbCountDay = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.rdoAES = new System.Windows.Forms.RadioButton();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.rdoBlowFish = new System.Windows.Forms.RadioButton();
            this.cmbKeyLength = new System.Windows.Forms.ComboBox();
            this.grpAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(99, 62);
            this.lblAlgorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(133, 20);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Select Algorithm: ";
            // 
            // lblKeyLength
            // 
            this.lblKeyLength.AutoSize = true;
            this.lblKeyLength.Location = new System.Drawing.Point(98, 106);
            this.lblKeyLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKeyLength.Name = "lblKeyLength";
            this.lblKeyLength.Size = new System.Drawing.Size(134, 20);
            this.lblKeyLength.TabIndex = 1;
            this.lblKeyLength.Text = "Write Key Length:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(308, 177);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(112, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbCountDay
            // 
            this.cmbCountDay.FormattingEnabled = true;
            this.cmbCountDay.Items.AddRange(new object[] {
            "Weekly",
            "Monthly"});
            this.cmbCountDay.Location = new System.Drawing.Point(262, 135);
            this.cmbCountDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCountDay.Name = "cmbCountDay";
            this.cmbCountDay.Size = new System.Drawing.Size(199, 28);
            this.cmbCountDay.TabIndex = 7;
            this.cmbCountDay.Text = "0";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(144, 143);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(88, 20);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Count Day:";
            // 
            // rdoAES
            // 
            this.rdoAES.AutoSize = true;
            this.rdoAES.Location = new System.Drawing.Point(15, 18);
            this.rdoAES.Name = "rdoAES";
            this.rdoAES.Size = new System.Drawing.Size(60, 24);
            this.rdoAES.TabIndex = 9;
            this.rdoAES.TabStop = true;
            this.rdoAES.Text = "AES";
            this.rdoAES.UseVisualStyleBackColor = true;
            this.rdoAES.CheckedChanged += new System.EventHandler(this.rdoAES_CheckedChanged);
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.rdoBlowFish);
            this.grpAlgorithm.Controls.Add(this.rdoAES);
            this.grpAlgorithm.Location = new System.Drawing.Point(262, 34);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(203, 48);
            this.grpAlgorithm.TabIndex = 10;
            this.grpAlgorithm.TabStop = false;
            // 
            // rdoBlowFish
            // 
            this.rdoBlowFish.AutoSize = true;
            this.rdoBlowFish.Location = new System.Drawing.Point(84, 18);
            this.rdoBlowFish.Name = "rdoBlowFish";
            this.rdoBlowFish.Size = new System.Drawing.Size(91, 24);
            this.rdoBlowFish.TabIndex = 11;
            this.rdoBlowFish.TabStop = true;
            this.rdoBlowFish.Text = "BlowFish";
            this.rdoBlowFish.UseVisualStyleBackColor = true;
            // 
            // cmbKeyLength
            // 
            this.cmbKeyLength.DropDownHeight = 100;
            this.cmbKeyLength.DropDownWidth = 199;
            this.cmbKeyLength.FormattingEnabled = true;
            this.cmbKeyLength.IntegralHeight = false;
            this.cmbKeyLength.Location = new System.Drawing.Point(262, 98);
            this.cmbKeyLength.MaxDropDownItems = 4;
            this.cmbKeyLength.Name = "cmbKeyLength";
            this.cmbKeyLength.Size = new System.Drawing.Size(199, 28);
            this.cmbKeyLength.TabIndex = 11;
            this.cmbKeyLength.Click += new System.EventHandler(this.cmbKeyLength_Click);
            // 
            // frmKeyGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 282);
            this.Controls.Add(this.cmbKeyLength);
            this.Controls.Add(this.grpAlgorithm);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cmbCountDay);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblKeyLength);
            this.Controls.Add(this.lblAlgorithm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKeyGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "alg";
            this.Text = "KEY GENERATOR";
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Label lblKeyLength;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbCountDay;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.RadioButton rdoAES;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.RadioButton rdoBlowFish;
        private System.Windows.Forms.ComboBox cmbKeyLength;
    }
}

