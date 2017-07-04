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
            this.btnLocation = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grpAlgorithm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(22, 41);
            this.lblAlgorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(133, 20);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Select Algorithm: ";
            // 
            // lblKeyLength
            // 
            this.lblKeyLength.AutoSize = true;
            this.lblKeyLength.Location = new System.Drawing.Point(3, 81);
            this.lblKeyLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKeyLength.Name = "lblKeyLength";
            this.lblKeyLength.Size = new System.Drawing.Size(142, 20);
            this.lblKeyLength.TabIndex = 1;
            this.lblKeyLength.Text = "Select Key Length:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(189, 194);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 35);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbCountDay
            // 
            this.cmbCountDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCountDay.FormattingEnabled = true;
            this.cmbCountDay.Items.AddRange(new object[] {
            "Weekly",
            "Monthly"});
            this.cmbCountDay.Location = new System.Drawing.Point(172, 114);
            this.cmbCountDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCountDay.Name = "cmbCountDay";
            this.cmbCountDay.Size = new System.Drawing.Size(199, 24);
            this.cmbCountDay.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(13, 118);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(135, 20);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Select Key Count:";
            // 
            // rdoAES
            // 
            this.rdoAES.AutoSize = true;
            this.rdoAES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoAES.Location = new System.Drawing.Point(15, 18);
            this.rdoAES.Name = "rdoAES";
            this.rdoAES.Size = new System.Drawing.Size(53, 20);
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
            this.grpAlgorithm.Location = new System.Drawing.Point(172, 13);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(199, 48);
            this.grpAlgorithm.TabIndex = 10;
            this.grpAlgorithm.TabStop = false;
            // 
            // rdoBlowFish
            // 
            this.rdoBlowFish.AutoSize = true;
            this.rdoBlowFish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoBlowFish.Location = new System.Drawing.Point(84, 18);
            this.rdoBlowFish.Name = "rdoBlowFish";
            this.rdoBlowFish.Size = new System.Drawing.Size(80, 20);
            this.rdoBlowFish.TabIndex = 11;
            this.rdoBlowFish.TabStop = true;
            this.rdoBlowFish.Text = "BlowFish";
            this.rdoBlowFish.UseVisualStyleBackColor = true;
            // 
            // cmbKeyLength
            // 
            this.cmbKeyLength.DropDownHeight = 100;
            this.cmbKeyLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyLength.DropDownWidth = 199;
            this.cmbKeyLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbKeyLength.FormattingEnabled = true;
            this.cmbKeyLength.IntegralHeight = false;
            this.cmbKeyLength.Location = new System.Drawing.Point(172, 77);
            this.cmbKeyLength.MaxDropDownItems = 4;
            this.cmbKeyLength.Name = "cmbKeyLength";
            this.cmbKeyLength.Size = new System.Drawing.Size(199, 24);
            this.cmbKeyLength.TabIndex = 11;
            this.cmbKeyLength.Click += new System.EventHandler(this.cmbKeyLength_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(161, 12);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(39, 25);
            this.btnLocation.TabIndex = 12;
            this.btnLocation.Text = "...";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLocation.Location = new System.Drawing.Point(1, 15);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(160, 20);
            this.txtLocation.TabIndex = 13;
            this.txtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocation_KeyPress);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblError.Location = new System.Drawing.Point(168, 250);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLocation);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Location = new System.Drawing.Point(171, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 40);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 155);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(133, 20);
            this.lblLocation.TabIndex = 16;
            this.lblLocation.Text = "Choose Location:";
            // 
            // frmKeyGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 295);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.cmbCountDay);
            this.Controls.Add(this.lblAlgorithm);
            this.Controls.Add(this.grpAlgorithm);
            this.Controls.Add(this.cmbKeyLength);
            this.Controls.Add(this.lblKeyLength);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKeyGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "alg";
            this.Text = "KEY GENERATOR";
            this.Load += new System.EventHandler(this.frmKeyGenerate_Load);
            this.grpAlgorithm.ResumeLayout(false);
            this.grpAlgorithm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLocation;
    }
}

