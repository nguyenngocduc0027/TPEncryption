using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Assignment1CAndNSecurity
{
    public partial class FormAES : Form
    {
        public FormAES()
        {
            InitializeComponent();
        }

        private bool isEncryptFile = true;
        private delegate void btnEncryptDecryptDelegate();

        private void enabledOrDisableButtons(bool isEnable)
        {
            if (!isEnable)
            {
                this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
                this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
                this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
                this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
                this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
                this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
            }
            else
            {
                this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
                this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
                this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
                this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
                this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
                this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            }

            this.btnReset.Enabled = isEnable;
            this.btnBack.Enabled = isEnable;
            this.btnExit.Enabled = isEnable;
            this.btnOutOpen.Enabled = isEnable;
            //this.tbOutput.Enabled = isEnable;
            this.btnEncrypt.Enabled = isEnable;
            this.btnDecrypt.Enabled = isEnable;
            this.btnGenerateKey.Enabled = isEnable;
            this.btnOpenFileIn.Enabled = isEnable;
            this.btnOpenFolderIn.Enabled = isEnable;
        }

        private void FormAES_Load(object sender, EventArgs e)
        {
            this.comboBoxMode.Items.Add("CBC");
            this.comboBoxMode.Items.Add("ECB");
            this.comboBoxMode.Items.Add("CFB");
            this.comboBoxMode.Text = "CBC";

            this.cbCheckIsEncryptFolder.Items.Add("Only This Folder");
            this.cbCheckIsEncryptFolder.Items.Add("The Folder And Its Sub-folders");
            this.cbCheckIsEncryptFolder.Text = "Only This Folder";

            this.cbSelectKeyLength.Items.Add("128bits");
            this.cbSelectKeyLength.Items.Add("192bits");
            this.cbSelectKeyLength.Items.Add("256bits");

            this.cbSelectKeyLength.Text = "256bits";

        }


        private void AESAlgorithm(String inputFile, String OutputFile, String keys, bool isEncrypt, String mode)
        {
            try
            {
              //  this.label1.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile).ToString();
              //  this.label1.Update();

                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;


                if (!isEncrypt)
                {
                    OutputFile = Path.Combine(Path.GetDirectoryName(OutputFile), Path.GetFileNameWithoutExtension(OutputFile) + "_1" + Path.GetExtension(OutputFile));
                }

                FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fsCiperText = new FileStream(OutputFile, FileMode.Create, FileAccess.Write);

                fsCiperText.SetLength(0);
                int numberBytesRead = 10485760;//10MB
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;
                
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;

                AesCryptoServiceProvider AESProvider = new AesCryptoServiceProvider();
               
                try
                {
                    AESProvider.Key = Convert.FromBase64String(keys);
                    AESProvider.IV = ASCIIEncoding.ASCII.GetBytes(keys.Substring(0, 16));
                }
                catch (Exception ioex)
                {
                    FormMessageBox.ShowBox("Failed: " + ioex.Message);
                    return;
                }

                if (mode == "ECB") AESProvider.Mode = CipherMode.ECB;
                else if (mode == "CBC") AESProvider.Mode = CipherMode.CBC;
                else if (mode == "CFB") AESProvider.Mode = CipherMode.CFB;

                CryptoStream cryptStream;
                if (isEncrypt)
                    cryptStream = new CryptoStream(fsCiperText, AESProvider.CreateEncryptor(), CryptoStreamMode.Write);
                else
                    cryptStream = new CryptoStream(fsCiperText, AESProvider.CreateDecryptor(), CryptoStreamMode.Write);

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fsInput.Read(bin, 0, numberBytesRead);
                    cryptStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                   
                    this.label1.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    this.label1.Refresh();

                    progressBar1.Value = (int)((rdlen * 100) / totlen);

                }

                if (progressBar1.IsHandleCreated &&isEncryptFile)
                {
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = Path.GetDirectoryName(tbOutput.Text);
                    prc.Start();
                }

                cryptStream.Close();
                fsInput.Close();
                fsCiperText.Close();
            }
            catch (Exception ioex)
            {
                FormMessageBox.ShowBox("Failed: " + ioex.Message);
            }

        }
       
        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            if (Strings.Len(Strings.Trim(cbSelectKeyLength.Text)) != 0)
            {
                if (cbSelectKeyLength.Text == "128bits")
                    aes.KeySize = 128;
                else if (cbSelectKeyLength.Text == "192bits")
                    aes.KeySize = 192;
                else aes.KeySize = 256; 

                aes.GenerateKey();
                tbKey.Text = Convert.ToBase64String(aes.Key);
            }
        }

        private void btnOpenFileIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = true;
            this.tbOutput.Clear();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                tbInput.Text = op.FileName;
            }
        }

        private void btnOpenFolderIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.tbInput.Text = folderBrowserDialog1.SelectedPath;

        }

        private void btnOutOpen_Click(object sender, EventArgs e)
        {
            if (Strings.Len(Strings.Trim(tbOutput.Text)) > 0)
            {
                try
                {
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    if (!isEncryptFile)
                        prc.StartInfo.FileName = tbOutput.Text;
                    else
                        prc.StartInfo.FileName =Path.GetDirectoryName( tbOutput.Text );

                    prc.Start();
                }
                catch (Exception ioex)
                {
                    FormMessageBox.ShowBox("Failed: " +ioex.Message);
                }
            }
            else
            {
                FormMessageBox.ShowBox("Thư mục không mở được , do quá trình mã hóa hoặc giải mã chưa thực thi!");
            }
        }

        private void btnEncryptClick()
        {
            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
               Strings.Len(Strings.Trim(tbKey.Text)) != 0 &&
               Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0
               )
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                enabledOrDisableButtons(false);

                string inputFileName, outputFileName = "", mode, key;
                inputFileName = tbInput.Text;

                key = tbKey.Text;

                if (key.Length < 8)
                {
                    FormMessageBox.ShowBox("Bạn vui lòng nhập độ dài KEY phải lớn hơn hoặc bằng 8!");
                    enabledOrDisableButtons(true);
                    return;
                }

                if (isEncryptFile)
                {
                    outputFileName = tbInput.Text + ".tpEn";
                    this.tbOutput.Text = outputFileName;
                }

                mode = comboBoxMode.Text;

                if (key.Length != 32 && key.Length != 24 && key.Length != 44)
                {
                    for (int i = 0; i < 32 - (tbKey.Text.Length); i++)
                        key += "t";
                }

                if (key.Length == 24) key = key.Substring(0, 22) + "==";
                if (key.Length == 44) key = key.Substring(0, 43) + "=";

                if (this.isEncryptFile)
                    AESAlgorithm(inputFileName, outputFileName, key, true, mode);
                else
                {
                    string[] filePaths = Directory.GetFiles(inputFileName);

                    if (cbCheckIsEncryptFolder.Text == "The Folder And Its Sub-folders")
                        filePaths = Directory.GetFiles(inputFileName, "*", SearchOption.AllDirectories);

                    if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                    {
                        FormMessageBox.ShowBox("Thư mục hiện tại bạn chọn là thư mục rỗng ! Vui lòng chọn lại thư mục khác !");
                        enabledOrDisableButtons(true);
                        return;
                    }

                    outputFileName = filePaths[0];
                    this.tbOutput.Text = Path.GetDirectoryName(outputFileName);

                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                            AESAlgorithm(filePaths[i], filePaths[i] + ".tpEn", key, true, mode);
                    }

                }
                enabledOrDisableButtons(true);
                sw.Stop();
                double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                FormMessageBox.ShowBox("Tổng thời gian chương trình đã thực thi là : " + elapsedMs.ToString() + " s");
            }
            else
            {
                FormMessageBox.ShowBox("Dữ liệu không đủ để chương trình mã hóa ! Vui lòng cung cấp đầy đủ dữ liệu !");
            }

        }

        private void btnDecryptClick()
        {
            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
            Strings.Len(Strings.Trim(tbKey.Text)) != 0 &&
            Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0
            )
            {
                //Calculator time execution....
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                enabledOrDisableButtons(false);
                string inputFileName, outputFileName = "", mode, keySize, key;
                inputFileName = tbInput.Text;

                if (isEncryptFile && Path.GetExtension(inputFileName) != ".tpEn")
                {
                    FormMessageBox.ShowBox("Tệp tin này không được hỗ trợ đển giải mã!");
                    enabledOrDisableButtons(true);
                    return;
                }

                key = tbKey.Text;

                if (key.Length < 8)
                { 
                    FormMessageBox.ShowBox("Độ dài KEY phải lớn hơn hoặc bằng 8!");
                    enabledOrDisableButtons(true);
                    return;
                }

                if (isEncryptFile)
                {
                    outputFileName = tbInput.Text.Substring(0, tbInput.Text.Length - 5);
                    this.tbOutput.Text = outputFileName;
                }

                mode = comboBoxMode.Text;


                if (key.Length != 32 && key.Length != 24 && key.Length != 44)
                    for (int i = 0; i < 32 - tbKey.Text.Length; i++)
                        key += "t";

                if (key.Length == 24) key = key.Substring(0, 22) + "==";
                if (key.Length == 44) key = key.Substring(0, 43) + "=";

                if (isEncryptFile)
                    AESAlgorithm(inputFileName, outputFileName, key, false, mode);
                else
                {

                    string[] filePaths = Directory.GetFiles(inputFileName,"*.tpEn");

                    if (cbCheckIsEncryptFolder.Text == "The Folder And Its Sub-folders")
                        filePaths = Directory.GetFiles(inputFileName, "*.tpEn", SearchOption.AllDirectories);

                    if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                    {
                        FormMessageBox.ShowBox("Thư mục hiện tại không có chứa file dạng .tpEn!");
                        enabledOrDisableButtons(true);
                        return;
                    }

                    outputFileName = filePaths[0];
                    this.tbOutput.Text = Path.GetDirectoryName(outputFileName);

                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                            AESAlgorithm(filePaths[i], filePaths[i].Substring(0, filePaths[i].Length - 5), key, false, mode);
                    }

                }
                enabledOrDisableButtons(true);
                sw.Stop();
                double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                FormMessageBox.ShowBox("Tổng thời gian chương trình đã thực thi là : " + elapsedMs.ToString() + " s");
            }
            else
            {
                FormMessageBox.ShowBox("Dữ liệu không đủ để chương trình thực thi ! Vui lòng cung cấp đầy đủ dữ liệu !");
            }
        }
        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            btnEncryptDecryptDelegate s = new btnEncryptDecryptDelegate(btnEncryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
          btnEncryptDecryptDelegate s = new btnEncryptDecryptDelegate(btnDecryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = true;
            this.tbKey.Clear();
            this.tbInput.Clear();
            this.tbOutput.Clear();
            this.comboBoxMode.Text = "CBC";
            this.label1.Text = "";
            this.label1.Update();
            this.label1.Refresh();

            this.cbSelectKeyLength.Text = "256bits";
            if (this.progressBar1.Value > 0)
                this.progressBar1.Value = 0;
            FormMessageBox.ShowBox("Reset successful!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//II.Part make up***********************************************************.
        private void btnGenerateKey_MouseHover(object sender, EventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;

        }

        private void btnGenerateKey_MouseLeave(object sender, EventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
        }

        private void btnGenerateKey_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
        }

        private void btnOpenFileIn_MouseHover(object sender, EventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFileIn_MouseLeave(object sender, EventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
        }

        private void btnOpenFileIn_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFolderIn_MouseHover(object sender, EventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOpenFolderIn_MouseLeave(object sender, EventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
        }

        private void btnOpenFolderIn_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOutOpen_MouseHover(object sender, EventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnOutOpen_MouseLeave(object sender, EventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
        }

        private void btnOutOpen_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnEncrypt_MouseHover(object sender, EventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnEncrypt_MouseLeave(object sender, EventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
        }

        private void btnEncrypt_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnDecrypt_MouseHover(object sender, EventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnDecrypt_MouseLeave(object sender, EventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
        }

        private void btnDecrypt_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain fe = new FormMain();
            this.Hide();
            fe.ShowDialog();
            this.Close();
        }

    }
}
