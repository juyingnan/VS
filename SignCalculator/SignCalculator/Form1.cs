using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace SignCalculator
{
    public partial class signCalculator : Form
    {
        public string[] buffer = new String[1000];
        public GSISN[] gSign = new GSISN[1000];
        public int lineNumber = 0;
        public int maxLineNumber = 0;
        public Excel.Application app;
        public Excel.Workbooks wbs;
        public Excel.Workbook Book1;
        Excel.Worksheet Sheet2;
        System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;  //记录当前环境变量

        public signCalculator()
        {
            InitializeComponent();
            CurrencySelectionBox.SelectedIndex = 0;
        }

        private void fileLoadingButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            numberInputButton.Enabled = true;
            outputDetailButton.Enabled = true;
            openDetailButton.Enabled = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                lineNumber = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    buffer[lineNumber++] = line + ";";
                }
                lineNumber -= 1;
                textBox2.Text = Convert.ToString(lineNumber);
                DataGet(lineNumber);
                fileAddress.Text = openFileDialog1.FileName;
                maxLineNumber = lineNumber;
            }
        }

        private void DataGet(int lineNumber)
        {
            for (int i = 0; i <= lineNumber; i++)
            {
                gSign[i] = new GSISN();
                gSign[i].data = buffer[i].Split(new char[] { ';' });
                gSign[i].data[17] = gSign[i].data[11].Substring(0, 3) + " " + gSign[i].data[2] + " * " + gSign[i].data[1];

            }
            checkedListBox1.Items.AddRange(gSign[0].data);
            if (checkedListBox1.Items.Count > 16)
            {
                checkedListBox1.SetItemChecked(0, true);
                checkedListBox1.SetItemChecked(1, true);
                checkedListBox1.SetItemChecked(2, true);
                checkedListBox1.SetItemChecked(6, true);
            }
        }

        private void numberInputButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (maxLineNumber >= Convert.ToInt16(textBox2.Text))
                {
                    lineNumber = Convert.ToInt16(textBox2.Text);
                    MessageBox.Show("You have chosen to show top " + lineNumber.ToString() + " sign(s).");
                }
                else
                {
                    MessageBox.Show("This number must be less than the quantity of signs");
                    textBox2.Text = lineNumber.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("input error", "", MessageBoxButtons.OK);
            }
        }

        private void outputDetailButton_Click(object sender, EventArgs e)
        {
            OutputDetail(true);
        }

        private void OutputDetail(bool toSave)
        {
            int columnCount = 1;
            bool isSaved = false;
            //******************************************************DATAFILLING
            ExcelCreate();
            columnCount = DataFilling(columnCount);
            //******************************************************STATISTICS
            const int WIDTH_HEIGHT = 17;
            const int W = 6;
            columnCount = DataStatistics(WIDTH_HEIGHT, columnCount, System.IO.File.Exists(Application.StartupPath + "\\price" + CurrencySelectionBox.SelectedItem.ToString() + ".dat"));
            columnCount = DataStatistics(W, columnCount, false);
            //***********************************************************

            //************************************************************SAVE
            if (toSave)
            {
                isSaved = ExcelSaving(isSaved);
            }
        }

        private int DataStatistics(int statisticsIndex, int columnCount, bool p)
        {
            string[] statisticsType = new string[60];
            int[] statisticsData = new int[60];
            int statisticsCounter = 0;
            double[] statiticsPrice = new double[60];

            for (int i = 0; i <= lineNumber; i++)
            {
                bool isSearched = false;
                for (int j = 0; j <= statisticsCounter; j++)
                {
                    if (gSign[i].data[statisticsIndex] == statisticsType[j])
                    {
                        isSearched = true;
                        statisticsData[j]++;
                        break;
                    }
                }
                if (!isSearched)
                {
                    statisticsType[statisticsCounter] = gSign[i].data[statisticsIndex];
                    statisticsData[statisticsCounter]++;
                    statisticsCounter++;
                }
            }

            //*******************************************************************************

            StatisticsSorting(statisticsType, statisticsData, statisticsCounter);

            //*******************************************************************************
            return StatisticsFilling(ref columnCount, statisticsType, statisticsData, statisticsCounter, p);
        }

        private static void StatisticsSorting(string[] statisticsType, int[] statisticsData, int statisticsCounter)
        {
            for (int i = 1; i <= statisticsCounter; i++)
                for (int j = 1; j <= statisticsCounter - i - 1; j++)
                {
                    if (statisticsType[j].CompareTo(statisticsType[j + 1]) > 0)
                    {
                        string temp = statisticsType[j];
                        statisticsType[j] = statisticsType[j + 1];
                        statisticsType[j + 1] = temp;
                        int temp2 = statisticsData[j];
                        statisticsData[j] = statisticsData[j + 1];
                        statisticsData[j + 1] = temp2;
                    }
                }
        }

        private int StatisticsFilling(ref int columnCount, string[] statisticsType, int[] statisticsData, int statisticsCounter, bool p)
        {
            statisticsData[0] = 0;  //remove the first line
            if (p)
            {
                double totalPrice = 0;
                for (int i = 0; i <= statisticsCounter; i++)
                {
                    Sheet2.Cells[i + 1, columnCount + 1] = statisticsType[i];
                    if (statisticsData[i] != 0)
                    {
                        Sheet2.Cells[i + 1, columnCount] = i;
                        Sheet2.Cells[i + 1, columnCount + 2] = statisticsData[i];
                        Sheet2.Cells[i + 1, columnCount + 3] = PriceGet(statisticsType[i]);
                        Sheet2.Cells[i + 1, columnCount + 4] = Convert.ToDouble(PriceGet(statisticsType[i])) * statisticsData[i];
                        totalPrice += Convert.ToDouble(PriceGet(statisticsType[i])) * statisticsData[i];
                    }
                }

                Sheet2.Cells[statisticsCounter + 1, columnCount + 4] = totalPrice;
                Sheet2.Cells[statisticsCounter + 1, columnCount + 3] = "Total (" + CurrencySelectionBox.SelectedItem.ToString()+")"; 
                Sheet2.Cells[1, columnCount] = "No.";
                Sheet2.Cells[1, columnCount + 1] = "Type & Size";
                Sheet2.Cells[1, columnCount + 2] = "Quantity";
                Sheet2.Cells[1, columnCount + 3] = "Unit price (" + CurrencySelectionBox.SelectedItem.ToString() + ")";
                Sheet2.Cells[1, columnCount + 4] = "Subtotal (" + CurrencySelectionBox.SelectedItem.ToString() + ")";
                Excel.Range range1 = Sheet2.get_Range(Sheet2.Cells[1, columnCount + 3], Sheet2.Cells[statisticsCounter + 1, columnCount + 4]);
                range1.NumberFormat = "#,##0.00";

                Sheet2.Columns.AutoFit();
                StatisticFormat(columnCount + 1, statisticsCounter);
                StatisticFormat(columnCount + 3, statisticsCounter + 1);

                columnCount += 6;
                return columnCount;
            }
            else
            {
                for (int i = 0; i <= statisticsCounter; i++)
                {
                    Sheet2.Cells[i + 1, columnCount + 1] = statisticsType[i];
                    if (statisticsData[i] != 0)
                    {
                        Sheet2.Cells[i + 1, columnCount + 2] = statisticsData[i];
                        Sheet2.Cells[i + 1, columnCount] = i;
                    }
                }

                Sheet2.Cells[1, columnCount + 2] = "Subtotal";
                Sheet2.Cells[1, columnCount] = "No.";

                Sheet2.Columns.AutoFit();
                StatisticFormat(columnCount + 1, statisticsCounter);

                columnCount += 4;
                return columnCount;
            }
        }

        private string PriceGet(string p)
        {
            Price[] price = new Price[57];
            int lineNumber;
            string[] buffer = new string[100];
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\price" + CurrencySelectionBox.SelectedItem.ToString() + ".dat"))  /////
            {
                String line;
                lineNumber = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    buffer[lineNumber++] = line;
                }
                lineNumber -= 1;
                for (int i = 1; i <= lineNumber; i++)
                {
                    price[i] = new Price();
                    price[i].buffer = buffer[i].Split(new char[] { ';' });
                    price[i].DataAssign();
                }
            }
            for (int i = 1; i <= 56; i++)
            {
                String pTemp = price[i].type + " " + price[i].height + " * " + price[i].width;
                if (pTemp.ToString() == p)
                {
                    return price[i].price.ToString();
                }
            }
            return "0";
        }

        private void StatisticFormat(int columnCount, int statisticsCounter)
        {
            Excel.Range range1 = Sheet2.get_Range(Sheet2.Cells[1, columnCount], Sheet2.Cells[statisticsCounter, columnCount]);
            Excel.Range range2 = Sheet2.get_Range(Sheet2.Cells[1, columnCount + 1], Sheet2.Cells[statisticsCounter, columnCount + 1]);
            range1.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 187, 185).ToArgb();
            range2.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 185, 218).ToArgb();
            range1.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            range1.Borders.LineStyle = 1;
            range2.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            range2.Borders.LineStyle = 1;
        }

        private bool ExcelSaving(bool isSaved)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                Book1.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                isSaved = true;
            }
            catch
            {
                MessageBox.Show("Not saved");
            }
            ExcelClose();
            if (isSaved)
            {
                string savedFilePath = "Saved @ " + saveFileDialog1.FileName;
                MessageBox.Show(savedFilePath);
            }
            return isSaved;
        }

        private int DataFilling(int columnCount)
        {
            for (int i = 0; i <= lineNumber; i++)
            {
                columnCount = 1;
                for (int j = 0; j < gSign[i].data.Length; j++)
                {
                    if (checkedListBox1.GetItemChecked(j))
                    {
                        Sheet2.Cells[i + 1, columnCount++] = gSign[i].data[j];
                    }
                }
            }
            Sheet2.Columns.AutoFit();

            if (columnCount > 1)
            {
                DataFormat(columnCount - 1);
            }
            columnCount += 1;
            return columnCount;
        }

        private void DataFormat(int columnCount)
        {
            Excel.Range title = Sheet2.get_Range(Sheet2.Cells[1, 1], Sheet2.Cells[1, 100]);
            title.Font.Bold = true;
            Excel.Range ALL = Sheet2.get_Range(Sheet2.Cells[1, 1], Sheet2.Cells[100, 1001]);
            ALL.Font.Name = "Calibri";

            Excel.Range range1 = Sheet2.get_Range(Sheet2.Cells[1, 1], Sheet2.Cells[lineNumber + 1, columnCount]);
            range1.Cells.Interior.Color = System.Drawing.Color.FromArgb(176, 243, 255).ToArgb();
            range1.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            range1.Borders.LineStyle = 1;
        }

        private void ExcelCreate()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");   //设置环境变量为en，防止Excel错误0x80028018
            app = new Excel.Application();
            wbs = app.Workbooks;
            Book1 = wbs.Add(true);
            Sheet2 = (Excel.Worksheet)Book1.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Sheet2.Name = "Output";
        }

        public void ExcelClose()
        {
            //关闭一个Excel对象，销毁对象
            Book1.Close(false, Type.Missing, Type.Missing);
            wbs.Close();
            app.Quit();
            Book1 = null;
            wbs = null;
            app = null;
            GC.Collect();
            System.Threading.Thread.CurrentThread.CurrentCulture = CurrentCI;  //恢复环境变量
        }

        private void openDetailButton_Click(object sender, EventArgs e)
        {
            OutputDetail(false);
            app.Visible = true;
        }

        private void PriceFormOpenButton_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\price"+CurrencySelectionBox.SelectedItem.ToString()+".dat"))
            {
                PriceInputForm priceForm = new PriceInputForm(Application.StartupPath + "\\price"+CurrencySelectionBox.SelectedItem.ToString()+".dat",CurrencySelectionBox.SelectedIndex);
                priceForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Can't find Price File");
            }
        }
    }
}
