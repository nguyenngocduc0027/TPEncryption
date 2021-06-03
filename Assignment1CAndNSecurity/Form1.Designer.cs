using System.Drawing;
namespace Assignment1CAndNSecurity
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnHashAlg = new System.Windows.Forms.PictureBox();
            this.btnAES = new System.Windows.Forms.PictureBox();
            this.btnDES = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRSA = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHashAlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRSA)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(1042, 573);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 177);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            this.btnExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseMove);
            // 
            // btnHashAlg
            // 
            this.btnHashAlg.BackColor = System.Drawing.Color.Transparent;
            this.btnHashAlg.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnHashAlg;
            this.btnHashAlg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHashAlg.Location = new System.Drawing.Point(669, 554);
            this.btnHashAlg.Name = "btnHashAlg";
            this.btnHashAlg.Size = new System.Drawing.Size(207, 177);
            this.btnHashAlg.TabIndex = 3;
            this.btnHashAlg.TabStop = false;
            this.btnHashAlg.Click += new System.EventHandler(this.btnDecryption_Click);
            this.btnHashAlg.MouseLeave += new System.EventHandler(this.btnDecryption_MouseLeave);
            this.btnHashAlg.MouseHover += new System.EventHandler(this.btnDecryption_MouseHover);
            this.btnHashAlg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDecryption_MouseMove);
            // 
            // btnAES
            // 
            this.btnAES.BackColor = System.Drawing.Color.Transparent;
            this.btnAES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnAESNon;
            this.btnAES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAES.Location = new System.Drawing.Point(397, 441);
            this.btnAES.Name = "btnAES";
            this.btnAES.Size = new System.Drawing.Size(207, 177);
            this.btnAES.TabIndex = 4;
            this.btnAES.TabStop = false;
            this.btnAES.Click += new System.EventHandler(this.btnAES_Click);
            this.btnAES.MouseLeave += new System.EventHandler(this.btnAES_MouseLeave);
            this.btnAES.MouseHover += new System.EventHandler(this.btnAES_MouseHover);
            this.btnAES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAES_MouseMove);
            // 
            // btnDES
            // 
            this.btnDES.BackColor = System.Drawing.Color.Transparent;
            this.btnDES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDESNon;
            this.btnDES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDES.Location = new System.Drawing.Point(522, 237);
            this.btnDES.Name = "btnDES";
            this.btnDES.Size = new System.Drawing.Size(207, 177);
            this.btnDES.TabIndex = 5;
            this.btnDES.TabStop = false;
            this.btnDES.Click += new System.EventHandler(this.btnDES_Click);
            this.btnDES.MouseLeave += new System.EventHandler(this.btnDES_MouseLeave);
            this.btnDES.MouseHover += new System.EventHandler(this.btnDES_MouseHover);
            this.btnDES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDES_MouseMove);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.labelTutorial;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(967, 217);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 352);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnRSA
            // 
            this.btnRSA.BackColor = System.Drawing.Color.Transparent;
            this.btnRSA.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnRSANon;
            this.btnRSA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRSA.Location = new System.Drawing.Point(758, 379);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(207, 177);
            this.btnRSA.TabIndex = 7;
            this.btnRSA.TabStop = false;
            this.btnRSA.Click += new System.EventHandler(this.btnEncryption_Click);
            this.btnRSA.MouseLeave += new System.EventHandler(this.btnEncryption_MouseLeave);
            this.btnRSA.MouseHover += new System.EventHandler(this.btnEncryption_MouseHover);
            this.btnRSA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEncryption_MouseMove);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDES);
            this.Controls.Add(this.btnAES);
            this.Controls.Add(this.btnHashAlg);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment 1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHashAlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRSA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox btnHashAlg;
        private System.Windows.Forms.PictureBox btnAES;
        private System.Windows.Forms.PictureBox btnDES;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnRSA;
    }
}

