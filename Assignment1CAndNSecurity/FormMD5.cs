using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Assignment1CAndNSecurity
{
    public partial class FormMD5 : Form
    {
        public FormMD5()
        {
            InitializeComponent();
        }

        private delegate void btnEncryptDelegate();

        private void btnEncryptClick() {

            if (comboBoxCheck.Text == "Compare With (So sánh với một mã khác được nhập bên dưới!)" && tbCheck.Text.Length == 0)
            {
                FormMessageBox.ShowBox("Vui lòng nhập mã cần được điểm tra!"); return;
            }

            if (comboBox2.Text.Length == 0)
            { FormMessageBox.ShowBox("Vui lòng chọn loại dữ liệu mã hóa!"); return; }

            if (tbInput.Text.Length == 0)
            { FormMessageBox.ShowBox("Vui lòng nhập dữ liệu là file hoặc text!"); return; }

            try
            {
                String ext = Path.GetExtension(this.tbInput.Text);

                if (this.comboBox2.Text == "File")
                {
                    if (ext.Length == 0) { FormMessageBox.ShowBox("Đây không phải là file!"); return; }

                    if (!File.Exists(this.tbInput.Text)) throw new FileNotFoundException("File : " + this.tbInput.Text + " không tồn tại!");

                    if (this.comboBoxHashAlg.Text == "MD5")
                        tpOutput.Text = HashFile(this.tbInput.Text, new MD5CryptoServiceProvider());
                    else if (this.comboBoxHashAlg.Text == "SHA1")
                        tpOutput.Text = HashFile(this.tbInput.Text, new SHA1Managed());
                    else if (this.comboBoxHashAlg.Text == "SHA256")
                        tpOutput.Text = HashFile(this.tbInput.Text, new SHA256Managed());
                    else if (this.comboBoxHashAlg.Text == "SHA384")
                        tpOutput.Text = HashFile(this.tbInput.Text, new SHA384Managed());
                    else if (this.comboBoxHashAlg.Text == "SHA512")
                        tpOutput.Text = HashFile(this.tbInput.Text, new SHA512Managed());
                    else if (this.comboBoxHashAlg.Text == "RIPEMD160")
                        tpOutput.Text = HashFile(this.tbInput.Text, new RIPEMD160Managed());
                    else
                    {
                        FormMessageBox.ShowBox("Thuật toán Hash không hợp lệ!"); return;
                    }


                }
                else if (this.comboBox2.Text == "Text")
                {
                    var inputBytes = System.Text.Encoding.ASCII.GetBytes(tbInput.Text);
                    byte[] hashBytes;

                    if (this.comboBoxHashAlg.Text == "MD5")
                        hashBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes);
                    else if (this.comboBoxHashAlg.Text == "SHA1")
                        hashBytes = new SHA1Managed().ComputeHash(inputBytes);
                    else if (this.comboBoxHashAlg.Text == "SHA256")
                        hashBytes = new SHA256Managed().ComputeHash(inputBytes);
                    else if (this.comboBoxHashAlg.Text == "SHA384")
                        hashBytes = new SHA384Managed().ComputeHash(inputBytes);
                    else if (this.comboBoxHashAlg.Text == "SHA512")
                        hashBytes = new SHA512Managed().ComputeHash(inputBytes);
                    else if (this.comboBoxHashAlg.Text == "RIPEMD160")
                        hashBytes = new RIPEMD160Managed().ComputeHash(inputBytes);
                    else
                    {
                        FormMessageBox.ShowBox("Thuật toán Hash không hợp lệ!"); return;
                    }

                    // Convert the byte array to hexadecimal string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    tpOutput.Text = sb.ToString();
                }

                if (comboBoxCheck.Text == "Compare With (So sánh với một mã khác được nhập bên dưới!)" && tpOutput.Text == tbCheck.Text.ToUpper())
                {
                    FormMessageBox.ShowBox("Khớp mã!");
                }
                else if (comboBoxCheck.Text == "Compare With (So sánh với một mã khác được nhập bên dưới!)" && tpOutput.Text != tbCheck.Text.ToUpper())
                {
                    FormMessageBox.ShowBox("Mã không khớp!");
                }
                else if (comboBoxCheck.Text == "Calculate (Sinh ra mã của file hoặc đoạn văn bản)")
                {
                    FormMessageBox.ShowBox("Lấy Mã Thành công !");
                }
            }
            catch (Exception ex)
            {
                FormMessageBox.ShowBox("Failed : " + ex.Message);
            }
        }

        private void FormMD5_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("File");
            this.comboBox2.Items.Add("Text");

            this.comboBoxCheck.Items.Add("Compare With (So sánh với một mã khác được nhập bên dưới!)");
            this.comboBoxCheck.Items.Add("Calculate (Sinh ra mã của file hoặc đoạn văn bản)");


            this.comboBoxHashAlg.Items.Add("MD5");
            this.comboBoxHashAlg.Items.Add("SHA1");
            this.comboBoxHashAlg.Items.Add("SHA256");
            this.comboBoxHashAlg.Items.Add("SHA384");
            this.comboBoxHashAlg.Items.Add("SHA512");
            this.comboBoxHashAlg.Items.Add("RIPEMD160");
            
            this.comboBoxHashAlg.Text = "MD5";
            this.comboBox2.Text = "File";

            this.comboBoxCheck.Text = "Calculate (Sinh ra mã của file hoặc đoạn văn bản)";
            this.tbCheck.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btn_en_brow_md5_Click(object sender, EventArgs e)
        {
            tbInput.Clear();
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
                tbInput.Text = openFileDialog1.FileName;
        }

        private void btn_en_md5_Click(object sender, EventArgs e)
        {
            btnEncryptDelegate s = new btnEncryptDelegate(btnEncryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbInput.Clear();
            this.tpOutput.Clear();
            this.comboBox2.Text = "File";
            this.comboBoxHashAlg.Text = "MD5";
            FormMessageBox.ShowBox("Reset Successfully!");
        }

        public static string HashFile(string fileName, HashAlgorithm algorithm)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-","").ToUpper();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain fe = new FormMain();
            this.Hide();
            fe.ShowDialog();
            this.Close();
        }

        private void comboBoxCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCheck.Text == "Compare With (So sánh với một mã khác được nhập bên dưới!)")
                this.tbCheck.Enabled = true;
            else this.tbCheck.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "File")
                this.btn_en_brow_md5.Enabled = true;
            else this.btn_en_brow_md5.Enabled = false;
        }

    }
}
