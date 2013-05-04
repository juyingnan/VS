using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ExcelReadingAndCalc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 定义全局变量
        /// </summary>
        //三个矩阵
        string[,] A1 = new string[4000, 3];
        string[,] A2 = new string[4000, 4];
        string[,] A3 = new string[4000, 4];
        //三个矩阵的实际行数
        int A1_count = 0;
        int A2_count = 0;
        int A3_count = 0;
        //读取和写入文件时的临时变量
        int lineNumber = 0;
        public string[] buffer = new String[4000];
        //前两个文件的路径
        string filePath1;
        string filePath2;

        public MainWindow()
        {
            InitializeComponent();
        }

        //点击第一个按钮时，运行下面的inputButton1_Click(object sender, RoutedEventArgs e)
        private void inputButton1_Click(object sender, RoutedEventArgs e)
        {
            //下面if之前的四行程序为定义“打开文件窗口”
            Microsoft.Win32.OpenFileDialog openDataFileDialog1 = new Microsoft.Win32.OpenFileDialog();  //新建窗口
            openDataFileDialog1.DefaultExt = "csv"; //设定默认后缀名
            openDataFileDialog1.Filter = "CSV(.csv)|*.csv"; //设定默认后缀过滤器
            //窗口显示
            Nullable<bool> result = openDataFileDialog1.ShowDialog();
            //如果文件名不为空，则开始读取数据
            if (result == true && openDataFileDialog1.FileName != "")
            {
                try  //try表明尝试读取，如果失败，则运行下面的catch，弹出错误内容
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    //创建一个数据流，读取文件，这段不用记，知道是干嘛的就行，以后可以直接拷走用，把变量名一改就行
                    using (StreamReader sr = new StreamReader(openDataFileDialog1.FileName))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        lineNumber = 0; //从第0行开始读
                        //每一行后面加个","，作为分隔符。现在读取到的数据以行为单位，还没有分开
                        while ((line = sr.ReadLine()) != null)
                        {
                            buffer[lineNumber++] = line + ",";
                        }
                        //将地址名称在主界面显示
                        excelFilePath1.Text = openDataFileDialog1.FileName;
                        //将读取的数据写入内存里的矩阵
                        DataGet_1(lineNumber);
                    }
                    //记录文件路径，保存结果时用到
                    filePath1 = openDataFileDialog1.FileName;
                }
                    //若读取失败，运行一下程序，显示错误信息。
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //这个函数用来将数据写入矩阵1
        private void DataGet_1(int lineNumber)
        {
            //临时变量，临时存储每行内容
            string[] temp = new string[3];
            //根据实际行数，来循环
            for (int i = 0; i < lineNumber; i++)
            {
                //split是一个内置函数，可以将读取的每一行数据按照后面括号里的符号进行分割，将分割后的数据填入临时数组
                temp = buffer[i].Split(new char[] { ',' });
                for (int j = 0; j < 3; j++)
                {
                    //将临时数组的数据放入矩阵
                    A1[i, j] = temp[j];
                }
                //统一格式
                //if (!A1[i, 0].Contains("�D"))
                //    A1[i, 0] = int.Parse(A1[i, 0]).ToString();
                //A1[i, 1] = A1[i, 1].Replace('/', '-');
                //if (!A1[i, 2].Contains("�D"))
                //    A1[i, 2] = double.Parse(A1[i, 2]).ToString();
            }
            //矩阵实际行数
            A1_count = lineNumber;
            //主界面显示矩阵行数
            excelFilePath1.Text += "  " + A1_count + " rows";
        }

        //点击第二个按钮时，运行下面的inputButton2_Click(object sender, RoutedEventArgs e)，具体内容和上一个几乎一样，就不注释了
        private void inputButton2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openDataFileDialog2 = new Microsoft.Win32.OpenFileDialog();
            openDataFileDialog2.DefaultExt = "csv";
            openDataFileDialog2.Filter = "CSV(.csv)|*.csv";
            //show dailog
            Nullable<bool> result = openDataFileDialog2.ShowDialog();
            //wait the result
            if (result == true && openDataFileDialog2.FileName != "")
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(openDataFileDialog2.FileName))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        lineNumber = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            buffer[lineNumber++] = line + ",";
                        }
                        //lineNumber -= 1;
                        excelFilePath2.Text = openDataFileDialog2.FileName;
                        DataGet_2(lineNumber);
                    }
                    filePath2 = openDataFileDialog2.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //这个函数用来将数据写入矩阵2，除了列数变成4以外，其余也一样
        private void DataGet_2(int lineNumber)
        {
            string[] temp = new string[4];
            for (int i = 0; i < lineNumber; i++)
            {
                temp = buffer[i].Split(new char[] { ',' });
                for (int j = 0; j < 4; j++)
                {
                    A2[i, j] = temp[j];
                }
                //if (!A2[i, 0].Contains("�D"))
                //    A2[i, 0] = int.Parse(A2[i, 0]).ToString();
                //A2[i, 1] = A2[i, 1].Replace('/', '-');
                //if (!A2[i, 2].Contains("�D"))
                //    A2[i, 2] = double.Parse(A2[i, 2]).ToString();
            }
            A2_count = lineNumber;
            excelFilePath2.Text += "  " + A2_count + " rows";
        }

        //按下计算按钮以后，运行以下函数calAndOutputButton_Click(object sender, RoutedEventArgs e)
        private void calAndOutputButton_Click(object sender, RoutedEventArgs e)
        {
            //双重循环，这个逻辑和你的一样
            for (int i = 0; i < A1_count; i++)
            {
                for (int j = 0; j < A2_count; j++)
                {
                    if (A1[i, 0] == A2[j, 0] && A1[i, 1] == A2[j, 1] && A1[i, 2] == A2[j, 2])
                    {
                        A3[A3_count, 0] = A2[j, 0];
                        A3[A3_count, 1] = A2[j, 1];
                        A3[A3_count, 2] = A2[j, 2];
                        A3[A3_count, 3] = A2[j, 3];
                        A3_count++;
                    }
                }
            }
            //主界面显示结果的行数
            Result.Text = A3_count + " rows output data";
            //调用输出函数，将结果输出
            OutputToCSV(A3_count);
            //运算完成后，清空A3的行数，以方便下次运算
            //clear the count of A3 after calculation
            A3_count = 0;
        }

        //本函数实现结果输出
        private void OutputToCSV(int lineCount)
        {
            //临时变量
            string line = "";
            //输出路径，路径和文件1路径一致，文件名由_result_+文件名1+文件名2+_组成
            string outputPath = System.IO.Path.GetDirectoryName(filePath1) + "\\_result_" + System.IO.Path.GetFileNameWithoutExtension(filePath1) + "_" + System.IO.Path.GetFileNameWithoutExtension(filePath2)+"_.csv";
            //调用数据流输出，和读取部分一样，理解用途就行，以后可以拷走用
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                //循环，输出每一行
                for (int i = 0; i < lineCount; i++)
                {
                    //这个循环把矩阵内容先移到缓存，然后把缓存四部分拼起来，组成一行的内容
                    //其实直接把矩阵拼起来也行，line = A3[i, 0]+"," +A3[i, 1]+","A3[i, 2]+","A3[i, 3];也行，一句就够了，懒得改了
                    for (int j = 0; j < 4; j++)
                    {
                        buffer[j] = A3[i, j];
                    }
                    line = buffer[0] + "," + buffer[1] + "," + buffer[2] + "," + buffer[3];
                    //将拼好的一句写入文件
                    sw.WriteLine(line);
                }
            }
            //主界面显示输出结果
            Result.Text += " has been saved to " + System.IO.Path.GetFullPath(outputPath);
        }
    }
}
    