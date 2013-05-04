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

namespace OnlineShopLiteDemo2Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            proxy = new OnlineShopLiteService.OnlineShopPortTypeClient("OnlineShopSOAP12port_http");
        }

        OnlineShopLiteService.OnlineShopPortTypeClient proxy;
        OnlineShopLiteService.OnlineShopRequest request = new OnlineShopLiteService.OnlineShopRequest();
        OnlineShopLiteService.OnlineShopResponse response = new OnlineShopLiteService.OnlineShopResponse();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RESULT_TEXTBOX.Text = "";

            request.OrderID = orderIDGenerator(CUSTOMER_ID_TEXTBOX.Text);
            request.CreditCardNo = CRESIT_CARD_NO_TEXTBOX.Text;
            request.ToasterType = TOASTER_TYPE_COMBOBOX.SelectionBoxItem.ToString();
            request.Quantity = int.Parse(QUANTITY_TEXTBOX.Text);

            response = proxy.process(request);
            ResultConvert();
        }

        private void ResultConvert()
        {
            switch (int.Parse(response.OrderResult.ToString()))
            {
                case -1: if (MessageBox.Show("About your order: "+response.OrderID+"\nThere are not enough toasters in stock, but we will try to get enough for you and the delivery will be delayed for several days. Will you cancel the order?", "Will you cancel the order?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        request.OrderID = response.OrderID;
                        request.CreditCardNo = CRESIT_CARD_NO_TEXTBOX.Text;
                        request.ToasterType = TOASTER_TYPE_COMBOBOX.SelectionBoxItem.ToString();
                        request.Quantity = int.Parse(QUANTITY_TEXTBOX.Text);
                        request.IsCanceled = true;

                        response = proxy.process(request);
                        ResultConvert();
                    }
                    else
                    {
                        request.OrderID = response.OrderID;
                        request.CreditCardNo = CRESIT_CARD_NO_TEXTBOX.Text;
                        request.ToasterType = TOASTER_TYPE_COMBOBOX.SelectionBoxItem.ToString();
                        request.Quantity = int.Parse(QUANTITY_TEXTBOX.Text);
                        request.IsCanceled = false;

                        response = proxy.process(request);
                        ResultConvert();
                    }
                    break;
                case 0: RESULT_TEXTBOX.Text = "The Credit Card No is invalid. Your order " + response.OrderID + " has been canceled. Please try again.";
                    break;
                case 1: RESULT_TEXTBOX.Text = "Successful! Your order ID is "+response.OrderID+". Your toaster will be deliveried soon.";
                    break;
                case 2: RESULT_TEXTBOX.Text = "Successful! Your order ID is " + response.OrderID + ". Your toaster will be deliveried in 5 days.";
                    break;
                case -2: RESULT_TEXTBOX.Text = "Your order " + response.OrderID + " has been canceled. The money has been returned to your account:" + request.CreditCardNo + ".";
                    break;
                case -3: RESULT_TEXTBOX.Text = "Unknown result. Code = -3";
                    break;
                case -4: RESULT_TEXTBOX.Text = "Your Credit Card No is invalid. Your order " + response.OrderID + " has been canceled. Please try again.";
                    break;
                default: RESULT_TEXTBOX.Text = "Unknown result.";
                    break;
            }
        }

        private string orderIDGenerator(string p)
        {
            return p + DateTime.Now.Ticks.ToString();
        }
    }
}
