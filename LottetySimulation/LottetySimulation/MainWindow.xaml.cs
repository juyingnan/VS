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

namespace LottetySimulation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int[] StandardNumbers = new int[int.Parse(textBox2.Text)];
            int[] myNumbers = new int[int.Parse(textBox2.Text)];
            int[] statisticsResult = new int[int.Parse(textBox2.Text) + 1];


            for (int i = 0; i < int.Parse(timesBox.Text); i++)
            {
                randomNumbers(StandardNumbers);
                randomNumbers(myNumbers);
                int result = compareTwoGroups(StandardNumbers, myNumbers);
                statistics(result, statisticsResult);

                //test 1
                //outputBox.Text += result.ToString();
                //test 2
                //for (int j = 0; j < StandardNumbers.Length; j++)
                //{
                //    outputBox.Text += StandardNumbers[j] + ",";
                //}
                //test *
                //outputBox.Text += "   ";
                //test
            }
            foreach (var item in statisticsResult)
            {
                outputBox.Text += item.ToString() + ",";
            }
        }

        private void statistics(int result, int[] statisticsResult)
        {
            statisticsResult[result]++;
        }

        private int compareTwoGroups(int[] StandardNumbers, int[] myNumbers)
        {
            int same = 0;
            foreach (var A in myNumbers)
            {
                foreach (var B in StandardNumbers)
                {
                    if (A == B)
                    {
                        same++;
                        break;
                    }
                }
            }
            return same;
        }

        private void randomNumbers(int[] Numbers)
        {
            int max = int.Parse(textBox1.Text);
            int min = 1;
            Random r= new Random(GetRandomSeed());
            for (int i = 0; i < Numbers.Length; i++)
            {
                int temp;
                do
                {
                    temp = r.Next(min, max);
                }
                while (!judgeRepeat(temp, Numbers));
                Numbers[i] = temp;
            }            
        }

        private bool judgeRepeat(int p, int[] Numbers)
        {
            foreach (var item in Numbers)
            {
                if (p == item) return false;
            }                
            return true;
        }

        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        } 
    }
}
