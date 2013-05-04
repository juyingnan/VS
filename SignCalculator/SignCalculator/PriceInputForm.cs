using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SignCalculator
{
    public partial class PriceInputForm : Form
    {
        Price[] price = new Price[57];
        String priceFilePath;

        public PriceInputForm(string priceFilePath, int ComboBoxindex)
        {
            InitializeComponent();
            dataGridView1.Rows.Add(13);
            PriceFileOpen(priceFilePath);
            this.priceFilePath = priceFilePath;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = ComboBoxindex;
            PriceToTable();
        }

        private void PriceToTable()
        {
            int i = 0;
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                for (int j = 1; j <= 56; j++)
                {
                    if (price[j].type == comboBox1.SelectedItem.ToString() && price[j].height == comboBox2.SelectedItem.ToString())
                    {
                        dataGridView1[0, i].Value = price[j].width;
                        dataGridView1[1, i++].Value = price[j].price;
                    }
                }
        }

        private void PriceFileOpen(string priceFilePath)
        {
            int lineNumber;
            string[] buffer = new string[100];
            using (StreamReader sr = new StreamReader(priceFilePath))
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
        } 

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PriceToTable();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PriceToTable();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PriceSaveButton_Click(object sender, EventArgs e)
        {
            TableToPrice();
            PriceToFile();
        }

        private void PriceToFile()
        {
            using (StreamWriter sw = new StreamWriter(priceFilePath))
            {
                String line;
                sw.WriteLine("Type;Width;Height;Price");
                for (int j = 1; j <= 56; j++)
                {
                    line = price[j].type + ";" + price[j].width + ";" + price[j].height + ";" + price[j].price;
                    sw.WriteLine(line);
                }
            }
        }

        private void TableToPrice()
        {
            for (int i = 0; i < 14; i++)
            {
                for (int j = 1; j <= 56; j++)
                {
                    if (price[j].type == comboBox1.SelectedItem.ToString() && price[j].height == comboBox2.SelectedItem.ToString() && price[j].width == dataGridView1[0, i].Value.ToString())
                    {
                        try
                        {
                            price[j].price = Convert.ToDouble(dataGridView1[1, i].Value);
                        }
                        catch (FormatException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            priceFilePath = priceFilePath.Replace(priceFilePath.Substring(priceFilePath.Length - 7, 7), comboBox3.SelectedItem.ToString() + ".dat");
            PriceFileOpen(priceFilePath);
            PriceToTable();
        }


    }
}
