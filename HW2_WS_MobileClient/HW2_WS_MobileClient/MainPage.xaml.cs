using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using HW2_WS_MobileClient.StuInfoDBService;
using HW2_WS_MobileClient.TomcatServices;

namespace HW2_WS_MobileClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            HW2_WS_MobileClient.StuInfoDBService.StuInfoWebServiceSoapClient proxy = new StuInfoWebServiceSoapClient();
            proxy.GetStudentNameCompleted += new EventHandler<HW2_WS_MobileClient.StuInfoDBService.GetStudentNameCompletedEventArgs>(proxy_GetStudentNameCompleted);
            proxy.GetStudentNameAsync(ASP_INPUT_TEXTBOX.Text);
        }

        void proxy_GetStudentNameCompleted(object sender, HW2_WS_MobileClient.StuInfoDBService.GetStudentNameCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ASP_RESULT_TEXTBLOCK.Text += e.Result+"\n";
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TomcatServices.StuInfoWebServicePortTypeClient proxy2 = new StuInfoWebServicePortTypeClient();
            proxy2.GetStudentNameCompleted += new EventHandler<TomcatServices.GetStudentNameCompletedEventArgs>(proxy2_GetStudentNameCompleted);
            proxy2.GetStudentNameAsync(TC_INPUT_TEXTBOX.Text);
        }

        void proxy2_GetStudentNameCompleted(object sender, TomcatServices.GetStudentNameCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                TC_RESULT_TEXTBLOCK.Text += e.Result + "\n";
            }
        }
    }
}