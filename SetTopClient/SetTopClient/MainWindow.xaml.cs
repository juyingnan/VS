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

namespace SetTopClient
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
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += new EventHandler(dt_Tick);//调用函数
            dt.Start();

            scsb.DataSource = @"BUNNY-PC\SQLEXPRESS";
            scsb.InitialCatalog = "CableDatabase";
            scsb.UserID = "sa";
            scsb.Password = "test";

            r[0] = channel1;
            r[1] = channel2;
            r[2] = channel3;
            r[3] = channel4;
            r[4] = channel5;
            r[5] = channel6;
            r[6] = channel7;
            r[7] = channel8;
            r[8] = channel9;
            r[9] = channel10;

            ChannelUpdate(CUSTOMERID_INPUT.Text);
            DisplayUpdate();

            request.CustomerID = CUSTOMERID_INPUT.Text;
            request.EventID = int.Parse(CHANNEL_INPUT.Text);

            proxy.initiate(request);
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            ChannelUpdate(CUSTOMERID_INPUT.Text);
            DisplayUpdate();
        }

        private void DisplayUpdate()
        {
            for (int i = 0; i < setTopStatus.Length; i++)
            {
                if (setTopStatus[i])
                {
                    r[i].Fill = Brushes.Green;
                }
                else
                    r[i].Fill = Brushes.Red;
            }
        }

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        bool[] setTopStatus = new bool[10];
        Rectangle[] r = new Rectangle[10];
        CableOperator.ClientPortTypeClient proxy = new CableOperator.ClientPortTypeClient("ClientSOAP11port_http");
        CableOperator.ClientRequest request = new CableOperator.ClientRequest();

        private void ChannelUpdate(string p)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (GetCableInfo(p, "Channel" + i.ToString()) == "True")
                {
                    setTopStatus[i - 1] = true;
                }
                else setTopStatus[i - 1] = false;
            }   
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

        private void BUY_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            request.CustomerID = CUSTOMERID_INPUT.Text;
            request.EventID = int.Parse(CHANNEL_INPUT.Text);

            proxy.I2(CUSTOMERID_INPUT.Text, int.Parse(CHANNEL_INPUT.Text));
        }

    }
}
