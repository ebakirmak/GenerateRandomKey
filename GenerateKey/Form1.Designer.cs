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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeyGenerate));
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblKeyLength = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rdoAES = new System.Windows.Forms.RadioButton();
            this.rdoBlowFish = new System.Windows.Forms.RadioButton();
            this.cmbKeyLength = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGenerator = new System.Windows.Forms.TabPage();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.tabMain.SuspendLayout();
            this.tabGenerator.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(13, 24);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(84, 13);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "Encryption Type";
            this.lblAlgorithm.Click += new System.EventHandler(this.lblAlgorithm_Click);
            // 
            // lblKeyLength
            // 
            this.lblKeyLength.AutoSize = true;
            this.lblKeyLength.Location = new System.Drawing.Point(13, 57);
            this.lblKeyLength.Name = "lblKeyLength";
            this.lblKeyLength.Size = new System.Drawing.Size(61, 13);
            this.lblKeyLength.TabIndex = 1;
            this.lblKeyLength.Text = "Key Length";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(139, 151);
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
            this.rdoAES.Location = new System.Drawing.Point(139, 21);
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
            this.rdoBlowFish.Location = new System.Drawing.Point(206, 21);
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
            this.cmbKeyLength.Location = new System.Drawing.Point(139, 52);
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
            this.lblError.Location = new System.Drawing.Point(13, 184);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 14;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(140, 114);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(146, 20);
            this.dtpEnd.TabIndex = 21;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(139, 83);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(147, 20);
            this.dtpStart.TabIndex = 19;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabGenerator);
            this.tabMain.Controls.Add(this.tabHelp);
            this.tabMain.Controls.Add(this.tabAbout);
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(421, 267);
            this.tabMain.TabIndex = 18;
            // 
            // tabGenerator
            // 
            this.tabGenerator.BackColor = System.Drawing.Color.Transparent;
            this.tabGenerator.Controls.Add(this.lblLink);
            this.tabGenerator.Controls.Add(this.lblEnd);
            this.tabGenerator.Controls.Add(this.lblStart);
            this.tabGenerator.Controls.Add(this.dtpEnd);
            this.tabGenerator.Controls.Add(this.btnGenerate);
            this.tabGenerator.Controls.Add(this.dtpStart);
            this.tabGenerator.Controls.Add(this.lblAlgorithm);
            this.tabGenerator.Controls.Add(this.rdoBlowFish);
            this.tabGenerator.Controls.Add(this.lblError);
            this.tabGenerator.Controls.Add(this.cmbKeyLength);
            this.tabGenerator.Controls.Add(this.rdoAES);
            this.tabGenerator.Controls.Add(this.lblKeyLength);
            this.tabGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabGenerator.Name = "tabGenerator";
            this.tabGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerator.Size = new System.Drawing.Size(413, 241);
            this.tabGenerator.TabIndex = 0;
            this.tabGenerator.Text = "Generator";
            this.tabGenerator.Click += new System.EventHandler(this.tabGenerator_Click);
            // 
            // tabHelp
            // 
            this.tabHelp.BackColor = System.Drawing.Color.Transparent;
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHelp.Size = new System.Drawing.Size(413, 241);
            this.tabHelp.TabIndex = 1;
            this.tabHelp.Text = "Help";
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.Transparent;
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Controls.Add(this.lblCopyright);
            this.tabAbout.Controls.Add(this.lblVersion);
            this.tabAbout.Controls.Add(this.lblProductName);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(413, 241);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(13, 87);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 22;
            this.lblStart.Text = "Start Date";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(13, 118);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(52, 13);
            this.lblEnd.TabIndex = 23;
            this.lblEnd.Text = "End Date";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(13, 24);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(35, 13);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "label1";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(13, 55);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(35, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "label2";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(13, 86);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(35, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(301, 197);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(13, 203);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(0, 13);
            this.lblLink.TabIndex = 25;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // frmKeyGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 268);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKeyGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "alg";
            this.Text = "ENCRYPTİON KEY GENERATOR SW ";
            this.Load += new System.EventHandler(this.frmKeyGenerate_Load);
            this.tabMain.ResumeLayout(false);
            this.tabGenerator.ResumeLayout(false);
            this.tabGenerator.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGenerator;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblLink;
    }
}

