namespace Assignment1CAndNSecurity
{
    partial class FormRSA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRSA));
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPathKeys = new System.Windows.Forms.TextBox();
            this.btnOpenFileKeys = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnGenerateKey = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tbN = new System.Windows.Forms.TextBox();
            this.tbE = new System.Windows.Forms.TextBox();
            this.tbD = new System.Windows.Forms.TextBox();
            this.btnOpenFolderIn = new System.Windows.Forms.PictureBox();
            this.btnOpenFileIn = new System.Windows.Forms.PictureBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnOutOpen = new System.Windows.Forms.PictureBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.PictureBox();
            this.btnDecrypt = new System.Windows.Forms.PictureBox();
            this.btnEncrypt = new System.Windows.Forms.PictureBox();
            this.comboBoxLengKey = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFolderIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOutOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(1086, 582);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 122);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            this.btnExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelFileKeys;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(261, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tbPathKeys
            // 
            this.tbPathKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPathKeys.Location = new System.Drawing.Point(438, 232);
            this.tbPathKeys.Name = "tbPathKeys";
            this.tbPathKeys.Size = new System.Drawing.Size(395, 20);
            this.tbPathKeys.TabIndex = 3;
            // 
            // btnOpenFileKeys
            // 
            this.btnOpenFileKeys.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
            this.btnOpenFileKeys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFileKeys.Location = new System.Drawing.Point(843, 211);
            this.btnOpenFileKeys.Name = "btnOpenFileKeys";
            this.btnOpenFileKeys.Size = new System.Drawing.Size(94, 85);
            this.btnOpenFileKeys.TabIndex = 6;
            this.btnOpenFileKeys.TabStop = false;
            this.btnOpenFileKeys.Click += new System.EventHandler(this.btnOpenFileKeys_Click);
            this.btnOpenFileKeys.MouseLeave += new System.EventHandler(this.btnOpenFileKeys_MouseLeave);
            this.btnOpenFileKeys.MouseHover += new System.EventHandler(this.btnOpenFileKeys_MouseHover);
            this.btnOpenFileKeys.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOpenFileKeys_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelModulusN;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(261, 269);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 50);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
            this.btnGenerateKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerateKey.Location = new System.Drawing.Point(1069, 211);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(94, 85);
            this.btnGenerateKey.TabIndex = 10;
            this.btnGenerateKey.TabStop = false;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            this.btnGenerateKey.MouseLeave += new System.EventHandler(this.btnGenerateKey_MouseLeave);
            this.btnGenerateKey.MouseHover += new System.EventHandler(this.btnGenerateKey_MouseHover);
            this.btnGenerateKey.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGenerateKey_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelPublicEx;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(261, 324);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(171, 50);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelPrivateEx;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(261, 380);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(171, 50);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // tbN
            // 
            this.tbN.Enabled = false;
            this.tbN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbN.Location = new System.Drawing.Point(438, 289);
            this.tbN.Name = "tbN";
            this.tbN.Size = new System.Drawing.Size(395, 20);
            this.tbN.TabIndex = 13;
            // 
            // tbE
            // 
            this.tbE.Enabled = false;
            this.tbE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbE.Location = new System.Drawing.Point(438, 343);
            this.tbE.Name = "tbE";
            this.tbE.Size = new System.Drawing.Size(395, 20);
            this.tbE.TabIndex = 14;
            // 
            // tbD
            // 
            this.tbD.Enabled = false;
            this.tbD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbD.Location = new System.Drawing.Point(438, 398);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(395, 20);
            this.tbD.TabIndex = 15;
            // 
            // btnOpenFolderIn
            // 
            this.btnOpenFolderIn.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
            this.btnOpenFolderIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFolderIn.Location = new System.Drawing.Point(952, 404);
            this.btnOpenFolderIn.Name = "btnOpenFolderIn";
            this.btnOpenFolderIn.Size = new System.Drawing.Size(98, 83);
            this.btnOpenFolderIn.TabIndex = 19;
            this.btnOpenFolderIn.TabStop = false;
            this.btnOpenFolderIn.Click += new System.EventHandler(this.btnOpenFolderIn_Click);
            this.btnOpenFolderIn.MouseLeave += new System.EventHandler(this.btnOpenFolderIn_MouseLeave);
            this.btnOpenFolderIn.MouseHover += new System.EventHandler(this.btnOpenFolderIn_MouseHover);
            this.btnOpenFolderIn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOpenFolderIn_MouseMove);
            // 
            // btnOpenFileIn
            // 
            this.btnOpenFileIn.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
            this.btnOpenFileIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFileIn.Location = new System.Drawing.Point(834, 404);
            this.btnOpenFileIn.Name = "btnOpenFileIn";
            this.btnOpenFileIn.Size = new System.Drawing.Size(102, 83);
            this.btnOpenFileIn.TabIndex = 18;
            this.btnOpenFileIn.TabStop = false;
            this.btnOpenFileIn.Click += new System.EventHandler(this.btnOpenFileIn_Click);
            this.btnOpenFileIn.MouseLeave += new System.EventHandler(this.btnOpenFileIn_MouseLeave);
            this.btnOpenFileIn.MouseHover += new System.EventHandler(this.btnOpenFileIn_MouseHover);
            this.btnOpenFileIn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOpenFileIn_MouseMove);
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(439, 454);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(394, 20);
            this.tbInput.TabIndex = 17;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelInput;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(262, 437);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(171, 50);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // btnOutOpen
            // 
            this.btnOutOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
            this.btnOutOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOutOpen.Location = new System.Drawing.Point(842, 493);
            this.btnOutOpen.Name = "btnOutOpen";
            this.btnOutOpen.Size = new System.Drawing.Size(94, 83);
            this.btnOutOpen.TabIndex = 22;
            this.btnOutOpen.TabStop = false;
            this.btnOutOpen.Click += new System.EventHandler(this.btnOutOpen_Click);
            this.btnOutOpen.MouseLeave += new System.EventHandler(this.btnOutOpen_MouseLeave);
            this.btnOutOpen.MouseHover += new System.EventHandler(this.btnOutOpen_MouseHover);
            this.btnOutOpen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOutOpen_MouseMove);
            // 
            // tbOutput
            // 
            this.tbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(439, 519);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(394, 20);
            this.tbOutput.TabIndex = 21;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelOutput;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(262, 500);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(171, 50);
            this.pictureBox6.TabIndex = 20;
            this.pictureBox6.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.Location = new System.Drawing.Point(892, 582);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 127);
            this.btnReset.TabIndex = 25;
            this.btnReset.TabStop = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnReset.MouseHover += new System.EventHandler(this.btnReset_MouseHover);
            this.btnReset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseMove);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
            this.btnDecrypt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecrypt.Location = new System.Drawing.Point(616, 545);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(186, 103);
            this.btnDecrypt.TabIndex = 24;
            this.btnDecrypt.TabStop = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            this.btnDecrypt.MouseLeave += new System.EventHandler(this.btnDecrypt_MouseLeave);
            this.btnDecrypt.MouseHover += new System.EventHandler(this.btnDecrypt_MouseHover);
            this.btnDecrypt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDecrypt_MouseMove);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
            this.btnEncrypt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEncrypt.Location = new System.Drawing.Point(410, 545);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(191, 103);
            this.btnEncrypt.TabIndex = 23;
            this.btnEncrypt.TabStop = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            this.btnEncrypt.MouseLeave += new System.EventHandler(this.btnEncrypt_MouseLeave);
            this.btnEncrypt.MouseHover += new System.EventHandler(this.btnEncrypt_MouseHover);
            this.btnEncrypt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEncrypt_MouseMove);
            // 
            // comboBoxLengKey
            // 
            this.comboBoxLengKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLengKey.FormattingEnabled = true;
            this.comboBoxLengKey.Location = new System.Drawing.Point(942, 231);
            this.comboBoxLengKey.Name = "comboBoxLengKey";
            this.comboBoxLengKey.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLengKey.TabIndex = 26;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(369, 653);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(492, 33);
            this.progressBar1.TabIndex = 27;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelLoadingFile;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(176, 638);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(185, 59);
            this.pictureBox7.TabIndex = 28;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(365, 704);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = " ...";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnBack1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(1211, 185);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 77);
            this.btnBack.TabIndex = 32;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormRSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.bgRSA;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboBoxLengKey);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnOutOpen);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnOpenFolderIn);
            this.Controls.Add(this.btnOpenFileIn);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.tbE);
            this.Controls.Add(this.tbN);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnGenerateKey);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnOpenFileKeys);
            this.Controls.Add(this.tbPathKeys);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRSA";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRSA";
            this.Load += new System.EventHandler(this.FormRSA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerateKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFolderIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFileIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOutOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbPathKeys;
        private System.Windows.Forms.PictureBox btnOpenFileKeys;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnGenerateKey;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbN;
        private System.Windows.Forms.TextBox tbE;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.PictureBox btnOpenFolderIn;
        private System.Windows.Forms.PictureBox btnOpenFileIn;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox btnOutOpen;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox btnReset;
        private System.Windows.Forms.PictureBox btnDecrypt;
        private System.Windows.Forms.PictureBox btnEncrypt;
        private System.Windows.Forms.ComboBox comboBoxLengKey;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnBack;
    }
}