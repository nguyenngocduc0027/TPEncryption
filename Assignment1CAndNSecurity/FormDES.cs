using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Assignment1CAndNSecurity
{

    public partial class FormDES : Form
    {
        private delegate void btnEncryptDecryptDelegate();

        public FormDES()
        {
            InitializeComponent();
        }

        bool isEncryptFile = true;
        private string inputFileName, outputFileName = "", mode;
        private string key;
        private bool isStopMakeup = true;
        private bool[] checkMakeUpList = { true, false, false, false, false, false, false, false };
        // private bool 

        private void FormDES_Load(object sender, EventArgs e)
        {
            this.comboBoxMode.Items.Add("CBC");
            this.comboBoxMode.Items.Add("ECB");
            this.comboBoxMode.Items.Add("CFB");

            this.cbCheckIsEncryptFolder.Items.Add("Only This Folder");
            this.cbCheckIsEncryptFolder.Items.Add("The Folder And Its Sub-folders");

            this.cbCheckIsEncryptFolder.Text = "Only This Folder";
            this.comboBoxMode.Text = "CBC";
        }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         * Button open file.
         */
        private void btnOpenIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = true;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.tbInput.Text = openFile.FileName;
            }
        }

        private void btnOpenFolderIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.tbInput.Text = folderBrowserDialog1.SelectedPath;
        }

        /*
         * DES Algorithm contains both the encryption and decryption.
         * DESAlgorithm ( <string> input file name, <string> output file name, <string> key ,<string> mode=CBC or ECB or CFB , <bool> is the process Encryption? )
         * EX: DESAlgorithm("C:\thienphuoc.png","C:\thienphuoc.png.tpEn","thienphuoc","CBC",true)
         */
        void DESAlgorithm(string sInputFilename, string sOutputFilename, string sKey, string mode, bool isEncrypt)
        {
            try
            {
                this.label1.Text = "Tên tệp xử lý : " + Path.GetFileName(sInputFilename).ToString();
                this.label1.Update();
                this.label1.Refresh();

                this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
                this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;

                byte[] bytes = Convert.FromBase64String(sKey); //Key 8 bytes = 64bits.

                if (!isEncrypt)
                {
                    sOutputFilename =Path.Combine(Path.GetDirectoryName(sOutputFilename),Path.GetFileNameWithoutExtension(sOutputFilename) + "_1" + Path.GetExtension(sOutputFilename));
                }

                //Open the input file and create the output file.
                FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
                FileStream fsOutput = new FileStream(sOutputFilename, FileMode.OpenOrCreate, FileAccess.Write);
                fsOutput.SetLength(0);

                long totlen = fsInput.Length;           // Get file size.
                int numberBytesRead = 10485760, len;     // Each reading 10MB.
                byte[] bin = new byte[numberBytesRead];
                long rdlen = 0;


                //Set parameter for progress bar.
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;

                //DES 
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

                //Set mode for DES Algorithm.
                if (mode == "ECB") DES.Mode = CipherMode.ECB;
                else if (mode == "CBC") DES.Mode = CipherMode.CBC;
                else if (mode == "CFB") DES.Mode = CipherMode.CFB;


                CryptoStream encStream;

                if (isEncrypt)
                    encStream = new CryptoStream(fsOutput, DES.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
                else
                    encStream = new CryptoStream(fsOutput, DES.CreateDecryptor(bytes, bytes), CryptoStreamMode.Write); 


                /* Read from the input file , 
                 * each reading "numberBytesRead", 
                 * then encrypted and written to the output file.
                 */
                while (rdlen < totlen)
                {
                    len = fsInput.Read(bin, 0, numberBytesRead);//Each reading 100bytes
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;

                    this.label1.Text = "Tên tệp xử lý : " + Path.GetFileName(sInputFilename) + "\t Thành công: " + ((long)(rdlen * 100) / totlen).ToString() + " %";
                    this.label1.Refresh();

                    progressBar1.Value = (int)((rdlen * 100) / totlen);
                }

                encStream.Close();
                fsOutput.Close();
                fsInput.Close();
            }
            catch (Exception e)
            {
                FormMessageBox.ShowBox("Failed : "+e.Message);
            }
        }

        private void btnEncryptClick()
        {
            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 && Strings.Len(Strings.Trim(tbKey.Text)) != 0 && Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0)
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();

                enabledOrDisableButtons(false);

                this.key = tbKey.Text;                         //get Key. (base64String)
                if (key.Length < 8)
                {
                    FormMessageBox.ShowBox("Bạn vui lòng nhập độ dài KEY phải lớn hơn hoặc bằng 8!");
                    enabledOrDisableButtons(true);
                    return;
                }

                this.inputFileName = tbInput.Text;             //get Input file.

                if (isEncryptFile)
                {
                    this.outputFileName = tbInput.Text + ".tpEn";
                    this.tbOutput.Text = outputFileName;
                }

                this.mode = comboBoxMode.Text;                 //get Mode.

                if (key.Length >= 8 && key.Length < 12)
                    for (int i = 0; i < 12 - tbKey.Text.Length; i++)
                        key += "t";

                if (key.Length >= 12) key = key.Substring(0, 11) + "=";

                if (isEncryptFile) // Encrypt 1 file.
                    DESAlgorithm(this.inputFileName, this.outputFileName, this.key, this.mode, true);
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

                    this.outputFileName = filePaths[0];
                    this.tbOutput.Text = Path.GetDirectoryName(this.outputFileName);


                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                            DESAlgorithm(filePaths[i], filePaths[i] + ".tpEn", this.key, this.mode, true);
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
            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 && Strings.Len(Strings.Trim(tbKey.Text)) != 0 &&   Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0)
            {
                //Calculator time execution....
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();

                enabledOrDisableButtons(false);

                this.key = tbKey.Text;
                if (this.key.Length < 8)
                {
                    FormMessageBox.ShowBox("Độ dài KEY phải lớn hơn hoặc bằng 8!");
                    enabledOrDisableButtons(true);
                    return;
                }

                this.inputFileName = tbInput.Text;

                if (isEncryptFile && Path.GetExtension(inputFileName) != ".tpEn")
                {
                    FormMessageBox.ShowBox("Tệp tin này không được hỗ trợ đển giải mã!");
                    enabledOrDisableButtons(true);
                    return;
                }

                this.outputFileName = tbInput.Text;
                if (isEncryptFile)
                {
                    this.outputFileName = this.outputFileName.Substring(0, this.outputFileName.Length - 5);
                    this.tbOutput.Text = outputFileName;
                    this.tbOutput.Update();
                }

                this.mode = comboBoxMode.Text;

                if (key.Length >= 8 && key.Length < 12)
                    for (int i = 0; i < 12 - tbKey.Text.Length; i++)
                        key += "t";

                if (key.Length >= 12) key = key.Substring(0, 11) + "=";

                if (isEncryptFile) // Encrypt 1 file.
                    DESAlgorithm(this.inputFileName, this.outputFileName, this.key, this.mode, false);
                else
                {
                    //Get all files ".tpEn" from path.
                    string[] filePaths = Directory.GetFiles(inputFileName, "*.tpEn");

                    if (cbCheckIsEncryptFolder.Text == "The Folder And Its Sub-folders")
                        filePaths = Directory.GetFiles(inputFileName, "*.tpEn", SearchOption.AllDirectories);

                    if (filePaths.Length == 0)
                    {
                        FormMessageBox.ShowBox("Thư mục hiện tại không có chứa file dạng .tpEn!");
                        enabledOrDisableButtons(true);
                        return;
                    }

                    this.outputFileName = filePaths[0];
                    this.tbOutput.Text = Path.GetDirectoryName(this.outputFileName);

                    for (int i = 0; i < filePaths.Length; i++)
                        DESAlgorithm(filePaths[i], filePaths[i].Substring(0, filePaths[i].Length - 5), this.key, this.mode, false);

                }
                enabledOrDisableButtons(true);
                sw.Stop();
                double elapsedMs = sw.Elapsed.TotalMilliseconds / 1000;
                FormMessageBox.ShowBox("Tổng thời gian chương trình đã thực thi là : " + elapsedMs.ToString() + " s");
            }
            else
            {
                FormMessageBox.ShowBox("Dữ liệu không đủ để chương trình gải mã ! Vui lòng cung cấp đầy đủ dữ liệu !");

            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            btnEncryptDecryptDelegate s = new btnEncryptDecryptDelegate(btnEncryptClick);
            s.BeginInvoke(null, null);
        }

        /*
         Generate key (Base 64).
         */
        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            tbKey.Text = Convert.ToBase64String(desCrypto.Key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            btnEncryptDecryptDelegate s = new btnEncryptDecryptDelegate(btnDecryptClick);
            s.BeginInvoke(null, null);
        }

        private void btnOutOpen_Click(object sender, EventArgs e)
        {
            if (this.outputFileName.Length > 0)
            {
                try
                {
                    System.Diagnostics.Process prc = new System.Diagnostics.Process();
                    prc.StartInfo.FileName = Path.GetDirectoryName(outputFileName);
                    prc.Start();
                }
                catch (Exception exc)
                {
                    FormMessageBox.ShowBox("Failed : " + exc.Message);

                }
            }
            else
            {
                FormMessageBox.ShowBox("Không mở được thư mục xuất , do quá trình mã hóa hoặc giải mã chưa thực thi!");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbKey.Clear();
            this.tbInput.Clear();
            this.tbOutput.Clear();
            this.comboBoxMode.Text = "CBC";
            this.cbCheckIsEncryptFolder.Text = "Only This Folder";
            this.outputFileName = "";
            this.inputFileName = "";
            this.label1.Text = "";
            this.label1.Update();
            if (this.progressBar1.Value > 0)
                this.progressBar1.Value = 0;

            FormMessageBox.ShowBox("Reset successful !");
        }


        //II.Part make up UI
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isStopMakeup)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (this.checkMakeUpList[i])
                    {
                        if (i == 0)
                        {
                            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
                            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
                            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
                            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
                            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
                            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
                            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
                            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
                        }
                        else if (i == 1)
                        {
                            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
                            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
                            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
                            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
                            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
                            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
                            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
                            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
                        }
                        else if (i == 2)
                        {
                            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
                            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
                            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
                            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
                            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
                            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
                            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
                            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
                        }
                        else if (i == 3)
                            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
                        else if (i == 4)
                            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
                        else if (i == 5)
                            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
                        else if (i == 6)
                            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
                        else if (i == 7)
                            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;

                        this.checkMakeUpList[i] = false;
                        if (i != 7) this.checkMakeUpList[i + 1] = true;
                        if (i == 7) this.checkMakeUpList[0] = true;
                        break;
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.isStopMakeup = !this.isStopMakeup;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMain fe = new FormMain();
            this.Hide();
            fe.ShowDialog();
            this.Close();
        }

        private void tbInput_Click(object sender, EventArgs e)
        {
            FormMessageBox.ShowBox("Chon open file or Open folder");
        }
    }
}
