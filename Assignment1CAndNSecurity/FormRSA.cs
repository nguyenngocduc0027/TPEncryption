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
using System.Security;
using System.Xml;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Assignment1CAndNSecurity
{
    public partial class FormRSA : Form
    {
        public FormRSA()
        {
            InitializeComponent();
        }
        
        private delegate void btnEncryptDecrypt();

        private RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        private string pathKeysXML = "";
        private bool isEncryptFile = true;

        private void enabledOrDisableButtons(bool isEnable)
        {
            if (!isEnable)
            {
                this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
                this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
                this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
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
                this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
                this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
                this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
                this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
                this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            }

            this.btnReset.Enabled = isEnable;
            this.btnBack.Enabled = isEnable;
            //this.btnExit.Enabled = isEnable;
            this.btnOutOpen.Enabled = isEnable;
            //this.tbOutput.Enabled = isEnable;
            this.btnEncrypt.Enabled = isEnable;
            this.btnDecrypt.Enabled = isEnable;
            this.btnGenerateKey.Enabled = isEnable;
            this.btnOpenFileIn.Enabled = isEnable;
            this.btnOpenFileKeys.Enabled = isEnable;
            this.btnOpenFolderIn.Enabled = isEnable;
        }

        private void RSA_Algorithm(string inputFile, string outputFile, RSAParameters RSAKeyInfo, bool isEncrypt)
        {
            try {

                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;

                FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                FileStream fsCiperText = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                fsCiperText.SetLength(0);

                byte[] bin, encryptedData;
                long rdlen = 0;
                long totlen = fsInput.Length;
                int len;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 100;

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportParameters(RSAKeyInfo);

                int maxBytesCanEncrypted;
                if (isEncrypt)
                    maxBytesCanEncrypted = ((RSA.KeySize - 384) / 8) + 37;
                else
                    maxBytesCanEncrypted = RSA.KeySize / 8;

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    bin = new byte[maxBytesCanEncrypted];
                    len = fsInput.Read(bin, 0, maxBytesCanEncrypted);

                    if (isEncrypt) encryptedData = RSA.Encrypt(bin, false);
                    else encryptedData = RSA.Decrypt(bin, false);

                    fsCiperText.Write(encryptedData, 0, encryptedData.Length);
                    rdlen = rdlen + len;

                    this.label1.Text = "Tên tệp xử lý : " + Path.GetFileName(inputFile) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    this.label1.Update();
                    this.label1.Refresh();

                    this.progressBar1.Value =(int) ((rdlen * 100) / totlen);
                }

                fsCiperText.Close();
                fsInput.Close();
            }
            catch (Exception ex) {
                FormMessageBox.ShowBox("Failed: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRSA_Load(object sender, EventArgs e)
        {
            this.comboBoxLengKey.Items.Add("512bits");
            this.comboBoxLengKey.Items.Add("1024bits");
            this.comboBoxLengKey.Items.Add("2048bits");
            this.comboBoxLengKey.Items.Add("4096bits");

            this.comboBoxLengKey.Text = "1024bits";
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            try {

                int lengthKey=0;
                if (this.comboBoxLengKey.Text == "1024bits") lengthKey = 1024;
                else if (this.comboBoxLengKey.Text == "512bits") lengthKey = 512;
                else if (this.comboBoxLengKey.Text == "2048bits") lengthKey = 2048;
                else if (this.comboBoxLengKey.Text == "4096bits") lengthKey = 4096;

                RSA = new RSACryptoServiceProvider(lengthKey);

                //String pathPrivateKey = @"D:\privateKey.xml";
                String pathPrivateKey = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "keys.xml");
                
                File.WriteAllText(pathPrivateKey, RSA.ToXmlString(true));  // Private Key
                
                pathKeysXML = pathPrivateKey;
                tbPathKeys.Text = pathPrivateKey;

                if (File.Exists(pathKeysXML))
                {
                    if (Path.GetExtension(pathKeysXML) == ".xml")
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(File.ReadAllText(pathKeysXML));
                        try
                        {
                            XmlNode xnList = xml.SelectSingleNode("/RSAKeyValue/Modulus");
                            tbN.Text = xnList.InnerText;
                            xnList = xml.SelectSingleNode("/RSAKeyValue/Exponent");
                            tbE.Text = xnList.InnerText;
                            xnList = xml.SelectSingleNode("/RSAKeyValue/D");
                            tbD.Text = xnList.InnerText;
                        }
                        catch (Exception ix)
                        {
                            FormMessageBox.ShowBox(ix.Message);
                        }
                    }
                }
                FormMessageBox.ShowBox("Tạo Khóa Thành Công Với Độ Dài ! " + lengthKey.ToString() + " bits. Đường dẫn: " + pathKeysXML);
            }
            catch (Exception ie) {
                FormMessageBox.ShowBox("Failed: "+ie.Message);
            }
            
        }

        private void btnOpenFileKeys_Click(object sender, EventArgs e)
        {
            this.tbD.Clear(); this.tbE.Clear(); this.tbN.Clear();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pathKeysXML = op.FileName;
                tbPathKeys.Text = op.FileName; 
            }

            if (File.Exists(pathKeysXML))
            {

                if (Path.GetExtension(pathKeysXML) == ".xml")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(File.ReadAllText(pathKeysXML));
                    try {
                        XmlNode xnList = xml.SelectSingleNode("/RSAKeyValue/Modulus");
                        tbN.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/Exponent");
                        tbE.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/D");
                        tbD.Text = xnList.InnerText;
                    }
                    catch (Exception ex)
                    {
                        FormMessageBox.ShowBox("Failed: " + ex.Message);
                    }
                }
            }
                 

        }

        private void btnOpenFolderIn_Click(object sender, EventArgs e)
        {
            isEncryptFile = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.tbInput.Text = folderBrowserDialog1.SelectedPath;
        }
        private void btnOpenFileIn_Click(object sender, EventArgs e)
        {
            this.tbOutput.Clear();
            isEncryptFile = true;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                tbInput.Text = op.FileName;
        }

        private void btnOutOpen_Click(object sender, EventArgs e)
        {
            if (Strings.Len(Strings.Trim(tbOutput.Text)) > 0)
            {
                try
                {
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = Path.GetDirectoryName(tbOutput.Text);
                    prc.Start();
                }
                catch (Exception ioex)
                {
                    FormMessageBox.ShowBox("Failed: " + ioex.Message);
                }
            }
            else
            {
                FormMessageBox.ShowBox("Không mở được,do quá trình mã hóa\nhoặc giải mã chưa thực thi!");
            }
        }

        private void btnEncryptClick()
        {
            enabledOrDisableButtons(false);

            if (this.tbPathKeys.Text.Length==0||this.tbN.Text.Length == 0 || this.tbD.Text.Length == 0 || this.tbE.Text.Length == 0)
            {
                FormMessageBox.ShowBox("Key không hợp lệ ! Vui lòng chọn lại tệp tin key hoặc nhấn generate để tự sinh ! Xin cảm ơn! ");
                enabledOrDisableButtons(true);
                return;
            }

            try
            {
                if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbPathKeys.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbN.Text)) != 0)
                {

                    //Calculator time ex...
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();

                    string inputFileName = tbInput.Text, outputFileName = "";

                    if (isEncryptFile)
                    {
                        outputFileName = tbInput.Text + ".tpEn";
                        this.tbOutput.Text = outputFileName;
                    }
                    //get Keys.
                    RSA = new RSACryptoServiceProvider();
                    RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));
                    if (isEncryptFile)
                        RSA_Algorithm(inputFileName, outputFileName, RSA.ExportParameters(true), true);
                    else
                    {
                        string[] filePaths = Directory.GetFiles(inputFileName, "*");

                        if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                        {
                            FormMessageBox.ShowBox("Thư mục rỗng!");
                            enabledOrDisableButtons(true);
                            return;
                        }

                        outputFileName = filePaths[0];
                        this.tbOutput.Text = Path.GetDirectoryName(outputFileName);

                        for (int i = 0; i < filePaths.Length; i++)
                        {
                            if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                                RSA_Algorithm(filePaths[i], filePaths[i] + ".tpEn", RSA.ExportParameters(true), true);
                        }
                    }
                    enabledOrDisableButtons(true);
                    sw.Stop();
                    double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                    FormMessageBox.ShowBox("Thời gian thực thi " + elapsedMs.ToString() + "s");
                }
                else
                {
                    enabledOrDisableButtons(true);
                    FormMessageBox.ShowBox("Dữ liệu không đủ để mã hóa!");
                }
            }
            catch (Exception ex)
            {
                enabledOrDisableButtons(true);
                FormMessageBox.ShowBox("Failed: " + ex.Message);
            }
            enabledOrDisableButtons(true);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            btnEncryptDecrypt s = new btnEncryptDecrypt(btnEncryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnDecryptClick()
        {
            enabledOrDisableButtons(false);

            try
            {
                if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
                   Strings.Len(Strings.Trim(tbPathKeys.Text)) != 0 &&
                   Strings.Len(Strings.Trim(tbN.Text)) != 0)
                {
                    //Calculator time ex...
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();

                    string inputFileName = tbInput.Text, outputFileName = "";

                    if (isEncryptFile && Path.GetExtension(inputFileName) != ".tpEn")
                    {
                        FormMessageBox.ShowBox("Tệp tin này không được hỗ trợ đển giải mã!");
                        enabledOrDisableButtons(true);
                        return;
                    }

                    if (isEncryptFile)
                    {
                        outputFileName = inputFileName.Substring(0, inputFileName.Length - 5);
                        this.tbOutput.Text = outputFileName;
                    }

                    RSA = new RSACryptoServiceProvider();
                    RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));

                    if (isEncryptFile)
                        RSA_Algorithm(inputFileName, outputFileName, RSA.ExportParameters(true), false);
                    else
                    {
                        string[] filePaths = Directory.GetFiles(inputFileName, "*.tpEn", SearchOption.AllDirectories);
                        if (filePaths.Length == 0 || (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db")))
                        {
                            FormMessageBox.ShowBox("Thư mục rỗng!");
                            enabledOrDisableButtons(true);
                            return;
                        }

                        outputFileName = filePaths[0];
                        this.tbOutput.Text = Path.GetDirectoryName(outputFileName);

                        for (int i = 0; i < filePaths.Length; i++)
                            if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                                RSA_Algorithm(filePaths[i], filePaths[i].Substring(0, filePaths[i].Length - 5), RSA.ExportParameters(true), false);

                    }
                    enabledOrDisableButtons(true);
                    sw.Stop();
                    double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                    FormMessageBox.ShowBox("Thời gian thực thi " + elapsedMs.ToString() + "s");
                }
                else
                {
                    FormMessageBox.ShowBox("Không đủ điều kiện để giải mã !");
                }

            }
            catch (Exception ex)
            {
                FormMessageBox.ShowBox("Failed: " + ex.Message);
            }
            enabledOrDisableButtons(true);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            btnEncryptDecrypt s = new btnEncryptDecrypt(btnDecryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = true;
            this.tbPathKeys.Clear();
            this.tbInput.Clear();
            this.tbN.Clear();
            this.tbD.Clear();
            this.tbE.Clear();
            this.tbOutput.Clear();
            this.pathKeysXML = "";
            this.comboBoxLengKey.Text = "1024bits";
            this.label1.Text = "";
            this.label1.Update();
            RSA = new RSACryptoServiceProvider();
            if (this.progressBar1.Value > 0)
                this.progressBar1.Value = 0;
            FormMessageBox.ShowBox("Reset successful!");
        }
        /*
            II.Part make up UI*****************************************************
            */
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
        
        private void btnOpenFileKeys_MouseHover(object sender, EventArgs e)
        {
            this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFileKeys_MouseLeave(object sender, EventArgs e)
        {
            this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
        }

        private void btnOpenFileKeys_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
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
