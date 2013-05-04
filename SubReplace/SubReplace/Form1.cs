using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SubReplace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileTypeBox.SelectedIndex = 0;
        }

        bool isAddressValid = false;

        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            addressLable.Text = folderBrowserDialog1.SelectedPath;
            if (addressLable.Text != "")
            {
                isAddressValid = true;
            }
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {

            if (isAddressValid)
            {
                if (textFromBox.Text == "")
                {
                    MessageBox.Show("Please finish the content you want to replace!");
                }
                else
                {
                    DirectoryInfo directory = new DirectoryInfo(addressLable.Text);
                    String pattern = "*." + fileTypeBox.SelectedItem.ToString();
                    String allFilePath = GetFiles(directory, pattern);
                    string[] filePath = allFilePath.Split(new char[] { ';' });
                    int replaceCount = SubFileReplace(filePath, textFromBox.Text, textToBox.Text);
                    MessageBox.Show(replaceCount.ToString() + " file(s) replaces");
                }
            }
            else
            {
                MessageBox.Show("Please choose the path!");
            }
        }

        private int SubFileReplace(string[] filePath, string pFrom, string pTo)
        {
            string[] buffer = new string[10000];
            for (int i = 0; i < filePath.Length - 1; i++)
            {
                int lineCount = 0;
                Encoding e = GetEncoding(filePath[i], Encoding.Unicode);
                using (StreamReader sr = new StreamReader(filePath[i],e))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        buffer[lineCount++] = line;
                    }
                }
                
                using (StreamWriter sw = new StreamWriter(filePath[i],false,e))
                {
                    String line = "";
                    for (int j = 0; j <= lineCount - 1; j++)
                    {
                        line = buffer[j].Replace(pFrom, pTo);
                        sw.WriteLine(line);
                    }
                }
            }
            return filePath.Length - 1;
        }

        private string GetFiles(DirectoryInfo directory, string pattern)
        {
            String result = "";
            if (directory.Exists || pattern.Trim() != string.Empty)
            {

                foreach (FileInfo info in directory.GetFiles(pattern))
                {
                    result = result + info.FullName.ToString() + ";";
                }

                foreach (DirectoryInfo info in directory.GetDirectories())
                {
                    GetFiles(info, pattern);
                }
            }
            return result;
        }

        /// <summary>
        /// 取得一个文本文件的编码方式。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。< /param>
        /// <returns></returns>
        ///
        public static Encoding GetEncoding(string fileName, Encoding defaultEncoding)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Encoding targetEncoding = GetEncoding(fs, defaultEncoding);
            fs.Close();
            return targetEncoding;
        }

        /// <summary>
        /// 取得一个文本文件流的编码方式。

        /// </summary>
        /// <param name="stream">文本文件流。</param>

        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。< /param>
        /// <returns></returns>
        ///
        public static Encoding GetEncoding(FileStream stream, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;

                //保存当前Seek位置
                long origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);
                int nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());

                if (stream.Length >= 3)
                {
                    byte3 = Convert.ToByte(stream.ReadByte());
                }

                if (stream.Length >= 4)
                {
                    byte4 = Convert.ToByte(stream.ReadByte());
                }
                //根据文件流的前4个字节判断Encoding
                //Unicode {0xFF, 0xFE};
                //BE-Unicode {0xFE, 0xFF};
                //UTF8 = {0xEF, 0xBB, 0xBF};

                if (byte1 == 0xFE && byte2 == 0xFF)//UnicodeBe
                {
                    targetEncoding = Encoding.BigEndianUnicode;
                }

                if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)//Unicode
                {
                    targetEncoding = Encoding.Unicode;
                }

                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8
                {
                    targetEncoding = Encoding.UTF8;
                }

                //恢复Seek位置
                stream.Seek(origPos, SeekOrigin.Begin);
            }
            return targetEncoding;
        }
    }
}
