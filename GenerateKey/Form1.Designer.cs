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
            this.rdoAES = new System.Windows.Forms.RadioButton();
            this.rdoBlowFish = new System.Windows.Forms.RadioButton();
            this.cmbKeyLength = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(9, 32);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(84, 13);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Encryption Type";
            // 
            // lblKeyLength
            // 
            this.lblKeyLength.AutoSize = true;
            this.lblKeyLength.Location = new System.Drawing.Point(9, 65);
            this.lblKeyLength.Name = "lblKeyLength";
            this.lblKeyLength.Size = new System.Drawing.Size(61, 13);
            this.lblKeyLength.TabIndex = 1;
            this.lblKeyLength.Text = "Key Length";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(115, 158);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rdoAES
            // 
            this.rdoAES.AutoSize = true;
            this.rdoAES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoAES.Location = new System.Drawing.Point(115, 28);
            this.rdoAES.Margin = new System.Windows.Forms.Padding(2);
            this.rdoAES.Name = "rdoAES";
            this.rdoAES.Size = new System.Drawing.Size(53, 20);
            this.rdoAES.TabIndex = 9;
            this.rdoAES.TabStop = true;
            this.rdoAES.Text = "AES";
            this.rdoAES.UseVisualStyleBackColor = true;
            this.rdoAES.CheckedChanged += new System.EventHandler(this.rdoAES_CheckedChanged);
            // 
            // rdoBlowFish
            // 
            this.rdoBlowFish.AutoSize = true;
            this.rdoBlowFish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoBlowFish.Location = new System.Drawing.Point(182, 28);
            this.rdoBlowFish.Margin = new System.Windows.Forms.Padding(2);
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
            this.cmbKeyLength.Location = new System.Drawing.Point(115, 59);
            this.cmbKeyLength.Margin = new System.Windows.Forms.Padding(2);
            this.cmbKeyLength.MaxDropDownItems = 4;
            this.cmbKeyLength.Name = "cmbKeyLength";
            this.cmbKeyLength.Size = new System.Drawing.Size(147, 24);
            this.cmbKeyLength.TabIndex = 11;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 191);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.rdoBlowFish);
            this.groupBox2.Controls.Add(this.btnGenerate);
            this.groupBox2.Controls.Add(this.rdoAES);
            this.groupBox2.Controls.Add(this.lblKeyLength);
            this.groupBox2.Controls.Add(this.cmbKeyLength);
            this.groupBox2.Controls.Add(this.lblError);
            this.groupBox2.Controls.Add(this.lblAlgorithm);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(373, 298);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(116, 123);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(146, 20);
            this.dtpEnd.TabIndex = 21;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(115, 97);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(147, 20);
            this.dtpStart.TabIndex = 19;
            // 
            // frmKeyGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 317);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKeyGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "alg";
            this.Text = "ENCRYPTİON KEY GENERATOR SW ";
            this.Load += new System.EventHandler(this.frmKeyGenerate_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Label lblKeyLength;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton rdoAES;
        private System.Windows.Forms.RadioButton rdoBlowFish;
        private System.Windows.Forms.ComboBox cmbKeyLength;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}

