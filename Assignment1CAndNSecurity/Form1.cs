using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1CAndNSecurity
{
    public partial class FormMain : Form
    {
        //Play music.
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        //Effect snow or 
        int i = 0;Timer t;
        snowflake[] snowflakes;

        public FormMain()
        {
            InitializeComponent();
            player.SoundLocation = "musicBackground.wav";
            player.Play();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            //Set properties form main.
            this.TopMost = true;
            this.Size = Screen.PrimaryScreen.Bounds.Size + (new Size(20, 20));
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;

            //Generate Effect snow.
            snowflakes = new snowflake[100];
            t = new Timer();
            t.Interval = 100;
            t.Tick += new EventHandler(t_Tick);
            t.Start();

        }

        void t_Tick(object sender, EventArgs e)
        {
            if (i >= 40)
            {
                t.Stop();return;
            }
            snowflakes[i] = new snowflake();
            Controls.Add(snowflakes[i]);
            i++;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDecryption_Click(object sender, EventArgs e)
        {
            FormMD5 fe = new FormMD5();
             this.Hide();
             fe.ShowDialog();
             this.Close();
        }

        private void btnEncryption_Click(object sender, EventArgs e)
        {
//             FormDES fe = new FormDES();
//             fe.ShowDialog(this);

//             FormDES fe = new FormDES();
//              this.Hide();
//              fe.ShowDialog();
//              this.Close();

//             FormAES fe = new FormAES();
//              this.Hide();
//              fe.ShowDialog();
//              this.Close();


            FormRSA fe = new FormRSA();
             this.Hide();
             fe.ShowDialog();
             this.Close();

        }

        private void btnEncryption_MouseHover(object sender, EventArgs e)
        {
            btnRSA.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnRSASel;
        }

        private void btnDecryption_MouseHover(object sender, EventArgs e)
        {
            btnHashAlg.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnHashAlgSel;
        }

        private void btnDecryption_MouseLeave(object sender, EventArgs e)
        {
            btnHashAlg.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnHashAlg;
        }

        private void btnEncryption_MouseLeave(object sender, EventArgs e)
        {
            btnRSA.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnRSANon;
        }

        private void btnDecryption_MouseMove(object sender, MouseEventArgs e)
        {
            btnHashAlg.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnHashAlgSel;
        }

        private void btnEncryption_MouseMove(object sender, MouseEventArgs e)
        {
            btnRSA.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnRSASel;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
        }

        private void btnDES_Click(object sender, EventArgs e)
        {
            FormDES fe = new FormDES();
             this.Hide();
             fe.ShowDialog();
             this.Close();

        }

        private void btnAES_Click(object sender, EventArgs e)
        {
//             FormAES fe = new FormAES();
//             fe.ShowDialog(this);
            FormAES fe = new FormAES();
            this.Hide();
            fe.ShowDialog();
            this.Close();
        }


        private void btnDES_MouseHover(object sender, EventArgs e)
        {
            this.btnDES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDESSel;
        }
        private void btnDES_MouseLeave(object sender, EventArgs e)
        {
            this.btnDES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDESNon;
        }
        private void btnDES_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnDES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDESSel;
        }

        private void btnAES_MouseHover(object sender, EventArgs e)
        {
            this.btnAES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnAESSel;
        }
        private void btnAES_MouseLeave(object sender, EventArgs e)
        {
            this.btnAES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnAESNon;
        }
        private void btnAES_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnAES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnAESSel;
        }



    }
   
    class snowflake : PictureBox
    {
        public snowflake()
        {
            create();
            move();
        }

        Random r = new Random();

        private void create()
        {
            this.Location = new Point(r.Next(0, Screen.PrimaryScreen.Bounds.Width), r.Next(0, Screen.PrimaryScreen.Bounds.Height));
            this.MinimumSize = new Size(7, 7);
            this.Size = new Size(20, 20);
            
            int rd=r.Next(1, 6);
            if (rd==1)        this.BackgroundImage = Image.FromFile("la1.png");
            else if (rd == 2) this.BackgroundImage = Image.FromFile("la2.png");
            else if (rd == 3) this.BackgroundImage = Image.FromFile("la3.png");
            else if (rd == 4) this.BackgroundImage = Image.FromFile("la4.png");
            else if (rd == 5) this.BackgroundImage = Image.FromFile("la5.png");
            else if (rd == 6) this.BackgroundImage = Image.FromFile("la6.png");

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void move()
        {
            //this.Location += new Size(1, 3);
            Timer t = new Timer();
            t.Interval = 40;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.Location += new Size(1, 3);
            if (this.Location.X > Screen.PrimaryScreen.Bounds.Width || this.Location.Y > Screen.PrimaryScreen.Bounds.Height)
                this.Location = new Point(r.Next(-Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Width), r.Next(-Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Height));

        }
    }
}
