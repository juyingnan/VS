using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace BPEL_Compensate_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += new EventHandler(dt_Tick);//调用函数
            dt.Start();

            scsb.DataSource = @"BUNNY-PC\SQLEXPRESS";
            scsb.InitialCatalog = "CableDatabase";
            scsb.UserID = "sa";
            scsb.Password = "test";


            ChannelUpdate("John");
        }
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        bool[] setTopStatus = new bool[10];
        Rectangle[] r = new Rectangle[10];

        private void dt_Tick(object sender, EventArgs e)
        {
            ChannelUpdate("John");
        }

        private void ChannelUpdate(string p)
        {
            if (GetCableInfo(p, "Channel8") == "True")
                channel1.Fill = Brushes.Green;
            else channel1.Fill = Brushes.Red;
            if (GetCableInfo(p, "Channel9") == "True")
                channel2.Fill = Brushes.Green;
            else channel2.Fill = Brushes.Red;
        }

        public string GetCableInfo(String CustomerID, String EventID)
        {
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT " + EventID + " from CustomerCableInfo where CustomerID='" + CustomerID + "'", con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    try
                    {
                        return cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
        }

    }
}
