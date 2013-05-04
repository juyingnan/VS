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
using System.Xml;

namespace RssReader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RssGetting();
        }

        private void RssGetting()
        {
            string rssAddress = "http://www.lzbt.net/rss.php";//RSS地址

            XmlDocument doc = new XmlDocument();//创建文档对象
            try
            {
                doc.Load(rssAddress);//加载XML 包括 HTTP：// 和本地
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//异常处理
            }

            XmlNodeList list = doc.GetElementsByTagName("item"); //获得项           

            foreach (XmlNode node in list) //循环每一项
            {
                XmlElement ele = (XmlElement)node;
                //添加到列表内
                ListViewItem item = new ListViewItem();
                item.Content=ele.GetElementsByTagName("title")[0].InnerText;//获得标题
                item.Tag = ele.GetElementsByTagName("link")[0].InnerText;//获得联接
                mainRssList.Items.Add(item);
                //添加结束
            }
        }
    }
}
