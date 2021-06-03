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
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();
        }

        static FormMessageBox newMessageBox;
        static string Button_id; 


        public void Show(string text)
        {
            this.label1.Text = text;
        }

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new FormMessageBox();
            newMessageBox.label1.Text = txtMessage;
            
            newMessageBox.ShowDialog();
            return Button_id;
        } 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            newMessageBox.Dispose();
            Button_id = "2"; 
        }
    }
}
