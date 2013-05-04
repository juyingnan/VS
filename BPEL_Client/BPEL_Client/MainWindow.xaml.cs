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
using BPEL_Client.ServiceReference1;

namespace BPEL_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            proxy1 = new ServiceReference1.CorrelationPortTypeClient("CorrelationSOAP11port_http");
            proxy2 = new ServiceReference2.No_CorrelationPortTypeClient("No_CorrelationSOAP11port_http");
            proxy3 = new ServiceReference3.BPEL_LOANPortTypeClient("BPEL_LOANSOAP11port_http");
        }

        ServiceReference1.CorrelationPortTypeClient proxy1;
        ServiceReference1.CorrelationRequest a1 = new ServiceReference1.CorrelationRequest();
        ServiceReference1.CorrelationResponse b1;

        ServiceReference2.No_CorrelationPortTypeClient proxy2;
        ServiceReference2.No_CorrelationRequest a2 = new ServiceReference2.No_CorrelationRequest();
        ServiceReference2.No_CorrelationResponse b2;

        ServiceReference3.BPEL_LOANPortTypeClient proxy3;
        ServiceReference3.BPEL_LOANRequest a3 = new ServiceReference3.BPEL_LOANRequest();
        ServiceReference3.BPEL_LOANResponse b3;

        //WebReference.No_Correlation p = new WebReference.No_Correlation();

        private void GO_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            a1.input = double.Parse(INPUT_BOX.Text);
            b1 = proxy1.process(a1);
            OUTPUT_BOX.Text = b1.result.ToString();
        }

        private void GO_BUTTON_2_Click(object sender, RoutedEventArgs e)
        {
            a2.input = int.Parse(INPUT_BOX_2.Text);
            b2 = proxy2.process(a2);
            OUTPUT_BOX_2.Text = b2.result.ToString();
        }

        private void GO_BUTTON_3_Click(object sender, RoutedEventArgs e)
        {
            a3.money = double.Parse(INPUT_BOX_LOAN.Text);
            a3.name = INPUT_BOX_NAME.Text;
            b3 = proxy3.process(a3);
            OUTPUT_BOX_LOAN.Text = INPUT_BOX_NAME.Text + ", now you owe the bank $" + b3.result.ToString()+".";
        }
    }
}
