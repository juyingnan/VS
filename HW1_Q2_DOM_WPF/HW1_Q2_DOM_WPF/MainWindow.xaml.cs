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

namespace HW1_Q2_DOM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Grab the xml document from its source
        private string getXMLDocument(string url)
        {
            // Grab the dvd document from its source

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] webData = wc.DownloadData(url);

            // Get the downloaded data into a form suitable for XML processing

            char[] charData = new char[webData.Length];

            charData = System.Text.Encoding.UTF8.GetChars(webData);

            string xmlStr = new String(charData);

            // Clean up the document (first "<" and last ">" and everything in between)

            int start = xmlStr.IndexOf("<", 0, xmlStr.Length - 1);
            int length = xmlStr.LastIndexOf(">") - start + 1;

            // Return only the XML document parts
            return xmlStr.Substring(start, length);
        }

        private void task1Button_Click(object sender, RoutedEventArgs e)
        {
            string url = URL_TEXTBOX.Text;
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            try
            {
                xmlDoc.LoadXml(getXMLDocument(url));
            }
            catch (Exception)
            {
                MessageBox.Show("Read XML file failed");
                return;
            }

            // Search DOM tree for a set of elements with particular name and attribute
            //part 1
            string _ELEMENT_NAME_1 = _ELEMENT_NAME_1_TEXTBOX.Text;
            string _ATTRIBUTE_NAME_1 = _ATTRIBUTE_NAME_1_TEXTBOX.Text;
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_1);

            //output: all complex type names
            //Clear the screen
            RESULT1_TEXTBOX.Text = "";
            if (xmlNodeList.Count > 0)
            {
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    try
                    {
                        // Dump the contents of the elements we've found to standard output.
                        RESULT1_TEXTBOX.Text +=
                            "<" + _ELEMENT_NAME_1 + " " +
                            xmlNodeList.Item(i).Attributes.GetNamedItem(_ATTRIBUTE_NAME_1).OuterXml
                            + "></" + _ELEMENT_NAME_1 + ">\n";
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }

            //if nothing found, show a result
            if (RESULT1_TEXTBOX.Text == "")
            {
                RESULT1_TEXTBOX.Text = "Nothing found.";
            }
        }

        private void task2Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = URL_TEXTBOX.Text;
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            try
            {
                xmlDoc.LoadXml(getXMLDocument(url));
            }
            catch (Exception)
            {
                MessageBox.Show("Read XML file failed");
                return;
            }

            // Search DOM tree for a set of elements with particular name and attribute
            //part 2
            string _ELEMENT_NAME_2_1 = _ELEMENT_NAME_2_1_TEXTBOX.Text;
            string _ELEMENT_NAME_2_2 = _ELEMENT_NAME_2_2_TEXTBOX.Text;
            string _ATTRIBUTE_NAME_2 = _ATTRIBUTE_NAME_2_TEXTBOX.Text;
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_2_2);

            //output: All operation names in portType
            //Clear the screen
            RESULT2_TEXTBOX.Text = "";

            if (xmlNodeList.Count > 0)
            {
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    try
                    {
                        // Dump the contents of the elements we've found to standard output.
                        if (xmlNodeList.Item(i).ParentNode.Name == _ELEMENT_NAME_2_1)
                        {
                            RESULT2_TEXTBOX.Text +=
                                "<" + _ELEMENT_NAME_2_2 + " " +
                                xmlNodeList.Item(i).Attributes.GetNamedItem(_ATTRIBUTE_NAME_2).OuterXml
                                + "></" + _ELEMENT_NAME_2_2 + ">\n";
                        }
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }

            //if nothing found, show a result
            if (RESULT2_TEXTBOX.Text == "")
            {
                RESULT2_TEXTBOX.Text = "Nothing found.";
            }

        }

        private void task3Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = URL_TEXTBOX.Text;
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            //XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
            //xmlDoc.AppendChild(xmldecl);
            try
            {
                //this 
                xmlDoc.LoadXml(getXMLDocument(url));
                //xmlDoc.Load(url);
            }
            catch (Exception)
            {
                MessageBox.Show("Read XML file failed");
                return;
            }

            // Search DOM tree for a set of elements with particular name and attribute
            //part 3
            string _ELEMENT_NAME_3 = _ELEMENT_NAME_3_TEXTBOX.Text;
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_3);

            //output: service element and its sub-elements
            //Clear the screen
            RESULT3_TEXTBOX.Text = "";

            if (xmlNodeList.Count > 0)
            {
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    try
                    {
                        // Dump the contents of the elements we've found to standard output.
                        RESULT3_TEXTBOX.Text += xmlNodeList.Item(i).OuterXml;
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }

            //if nothing found, show a result
            if (RESULT3_TEXTBOX.Text == "")
            {
                RESULT3_TEXTBOX.Text = "Nothing found.";
            }
        }

        private void task1AltButton_Click(object sender, RoutedEventArgs e)
        {
            string url = URL_TEXTBOX.Text;
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            try
            {
                xmlDoc.LoadXml(getXMLDocument(url));
            }
            catch (Exception)
            {
                MessageBox.Show("Read XML file failed");
                return;
            }

            // Search DOM tree for a set of elements with particular name and attribute
            //part 1
            string _ELEMENT_NAME_1 = _ELEMENT_NAME_1ALT_TEXTBOX.Text;
            string _ATTRIBUTE_NAME_1 = _ATTRIBUTE_NAME_1ALT_TEXTBOX.Text;
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_1);

            /*
            //output: all complex type names
            //Clear the screen
            RESULT1_TEXTBOX.Text = "";
            if (xmlNodeList.Count > 0)
            {
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    //if complexType has subElement
                    if (xmlNodeList[i].HasChildNodes)
                    {
                        //traverse all childNodes of complexType
                        foreach (XmlNode item in xmlNodeList[i].ChildNodes)
                        {
                            //if a chileNode of complexType still has childNodes
                            if (item.HasChildNodes)
                            {
                                //traverse all grandchildNodes of complextype
                                foreach (XmlNode subItem in item)
                                {
                                    try
                                    {
                                        //output its name
                                        RESULT1Alt_TEXTBOX.Text +=
                            "<" + subItem.Name + " " +
                            subItem.Attributes.GetNamedItem(_ATTRIBUTE_NAME_1).OuterXml
                            + "></" + subItem.Name + ">\n";
                                    }
                                    catch (Exception)
                                    {
                                        //do nothing
                                    }
                                }
                            }
                        }
                    }
                }
            }
             */

            foreach (XmlNode item in xmlNodeList)
            {
                RESULT1Alt_TEXTBOX.Text += item.OuterXml + "\n";
            }


            //if nothing found, show a result
            if (RESULT1Alt_TEXTBOX.Text == "")
            {
                RESULT1Alt_TEXTBOX.Text = "Nothing found.";
            }

        }
    }
}
