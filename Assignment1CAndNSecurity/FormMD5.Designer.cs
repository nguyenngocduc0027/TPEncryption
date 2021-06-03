namespace Assignment1CAndNSecurity
{
    partial class FormMD5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMD5));
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tpOutput = new System.Windows.Forms.TextBox();
            this.btn_en_brow_md5 = new System.Windows.Forms.PictureBox();
            this.btn_en_md5 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.PictureBox();
            this.comboBoxHashAlg = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tbCheck = new System.Windows.Forms.TextBox();
            this.comboBoxCheck = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_en_brow_md5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_en_md5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(1154, 605);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(191, 151);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelOutput;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(317, 389);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 78);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelInput;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(317, 238);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(244, 75);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(568, 277);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(219, 20);
            this.tbInput.TabIndex = 5;
            // 
            // tpOutput
            // 
            this.tpOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpOutput.Location = new System.Drawing.Point(568, 425);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Size = new System.Drawing.Size(332, 20);
            this.tpOutput.TabIndex = 6;
            // 
            // btn_en_brow_md5
            // 
            this.btn_en_brow_md5.BackColor = System.Drawing.Color.Transparent;
            this.btn_en_brow_md5.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
            this.btn_en_brow_md5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_en_brow_md5.Location = new System.Drawing.Point(906, 252);
            this.btn_en_brow_md5.Name = "btn_en_brow_md5";
            this.btn_en_brow_md5.Size = new System.Drawing.Size(86, 73);
            this.btn_en_brow_md5.TabIndex = 19;
            this.btn_en_brow_md5.TabStop = false;
            this.btn_en_brow_md5.Click += new System.EventHandler(this.btn_en_brow_md5_Click);
            // 
            // btn_en_md5
            // 
            this.btn_en_md5.BackColor = System.Drawing.Color.Transparent;
            this.btn_en_md5.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
            this.btn_en_md5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_en_md5.Location = new System.Drawing.Point(645, 538);
            this.btn_en_md5.Name = "btn_en_md5";
            this.btn_en_md5.Size = new System.Drawing.Size(226, 128);
            this.btn_en_md5.TabIndex = 20;
            this.btn_en_md5.TabStop = false;
            this.btn_en_md5.Click += new System.EventHandler(this.btn_en_md5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(793, 276);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(106, 21);
            this.comboBox2.TabIndex = 22;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(906, 389);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 73);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.Location = new System.Drawing.Point(972, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 127);
            this.btnReset.TabIndex = 24;
            this.btnReset.TabStop = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // comboBoxHashAlg
            // 
            this.comboBoxHashAlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHashAlg.FormattingEnabled = true;
            this.comboBoxHashAlg.Location = new System.Drawing.Point(568, 342);
            this.comboBoxHashAlg.Name = "comboBoxHashAlg";
            this.comboBoxHashAlg.Size = new System.Drawing.Size(331, 21);
            this.comboBoxHashAlg.TabIndex = 25;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelHashAlgorithm;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(317, 309);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(244, 75);
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // tbCheck
            // 
            this.tbCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCheck.Location = new System.Drawing.Point(567, 511);
            this.tbCheck.Name = "tbCheck";
            this.tbCheck.Size = new System.Drawing.Size(333, 20);
            this.tbCheck.TabIndex = 27;
            // 
            // comboBoxCheck
            // 
            this.comboBoxCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCheck.FormattingEnabled = true;
            this.comboBoxCheck.Location = new System.Drawing.Point(567, 473);
            this.comboBoxCheck.Name = "comboBoxCheck";
            this.comboBoxCheck.Size = new System.Drawing.Size(333, 21);
            this.comboBoxCheck.TabIndex = 29;
            this.comboBoxCheck.SelectedIndexChanged += new System.EventHandler(this.comboBoxCheck_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnBack1;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(1085, 200);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 62);
            this.btnBack.TabIndex = 30;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelCompare;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(317, 478);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(244, 78);
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            // 
            // FormMD5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.bgMD5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboBoxCheck);
            this.Controls.Add(this.tbCheck);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.comboBoxHashAlg);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btn_en_md5);
            this.Controls.Add(this.btn_en_brow_md5);
            this.Controls.Add(this.tpOutput);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMD5";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMD5";
            this.Load += new System.EventHandler(this.FormMD5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_en_brow_md5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_en_md5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tpOutput;
        private System.Windows.Forms.PictureBox btn_en_brow_md5;
        private System.Windows.Forms.PictureBox btn_en_md5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox btnReset;
        private System.Windows.Forms.ComboBox comboBoxHashAlg;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbCheck;
        private System.Windows.Forms.ComboBox comboBoxCheck;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}