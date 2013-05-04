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

namespace OnlineShopLiteDemoClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            proxy = new OnlineShopLiteService.OnlineShopPortTypeClient("OnlineShopSOAP11port_http");
        }

        OnlineShopLiteService.OnlineShopPortTypeClient proxy;
        OnlineShopLiteService.OnlineShopRequest request = new OnlineShopLiteService.OnlineShopRequest();
        OnlineShopLiteService.OnlineShopResponse response = new OnlineShopLiteService.OnlineShopResponse();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            request.CustomerID = CUSTOMER_ID_TEXTBOX.Text;
            request.CreditCardNo = CRESIT_CARD_NO_TEXTBOX.Text;
            request.ToasterType = TOASTER_TYPE_COMBOBOX.SelectionBoxItem.ToString();
            request.Quantity = int.Parse(QUANTITY_TEXTBOX.Text);
            request.IsCanceled = (bool)ISCANCEL_CHECKBOX.IsChecked;

            response = proxy.process(request);
            ResultConvert(int.Parse(response.PurchaseResult.ToString()));
        }

        private void ResultConvert(int p)
        {
            switch (p)
            {
                case -1: RESULT_TEXTBOX.Text = "There are not enough toaster and the order has been canceled.";
                    break;
                case 0: RESULT_TEXTBOX.Text = "The Credit Card No is invalid. Please try again.";
                    break;
                case 1: RESULT_TEXTBOX.Text = "Successful! Your toaster will be deliveried soon.";
                    break;
                case 2: RESULT_TEXTBOX.Text = "Successful! Your toaster will be deliveried in 5 days.";
                    break;
                default: RESULT_TEXTBOX.Text = "Unknown result.";
                    break;
            }
        }
    }
}
