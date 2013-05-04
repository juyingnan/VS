using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW1_Q1_DOM
{
    class XMLProcessor
    {
        private string getXMLDocument(string url)
        {
            // Grab the body of xml document from its source

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] webData = wc.DownloadData(url);

            // Get the downloaded data into a form suitable for XML processing

            char[] charData = new char[webData.Length];
            for (int i = 0; i < charData.Length; i++)
            {
                charData[i] = (char)webData[i];
            }

            string xmlStr = new String(charData);

            // Clean up the document (first "<" and last ">" and everything in between)

            int start = xmlStr.IndexOf("<", 0, xmlStr.Length - 1);
            int length = xmlStr.LastIndexOf(">") - start + 1;

            // Return only the XML document parts
            return xmlStr.Substring(start, length);
        }

        /* PURPOSE
         * this XML processor is to output
         * 1. all message names
         * 2. all operation names of binding elements
         */

        public static void Main(string[] args)
        {
            // Check to see that we have a single URI argument
            if (args.Length != 1)
            {
                return;
            }

            string url = args[0];
            XMLProcessor domExample = new XMLProcessor();
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(domExample.getXMLDocument(url));

            // Search DOM tree for a set of elements with particular name and attribute

            //part 1
            const string _ELEMENT_NAME_1 = "wsdl:message";
            const string _ATTRIBUTE_NAME_1 = "name";
            //get the node list
            XmlNodeList xmlNodeList_1 = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_1);

            //output: all message names
            Console.WriteLine("ALL MESSAGE NAMES");
            if (xmlNodeList_1.Count > 0)
            {
                for (int i = 0; i < xmlNodeList_1.Count; i++)
                {
                    // Dump the contents of the elements we've found to standard output.
                    try
                    {
                        Console.WriteLine(
                        "<" + _ELEMENT_NAME_1 + " " +
                        xmlNodeList_1.Item(i).Attributes.GetNamedItem(_ATTRIBUTE_NAME_1).OuterXml
                        + "></" + _ELEMENT_NAME_1 + ">"
                        );
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }
            Console.WriteLine("\n***********************************************\n");

            //part 2
            const string _ELEMENT_NAME_2_1 = "wsdl:binding";
            const string _ELEMENT_NAME_2_2 = "wsdl:operation";
            const string _ATTRIBUTE_NAME_2 = "name";
            //xmlNodeList 
            //try another way, first find all "operation" elements, and then filter those elements whose parent is "binding"
            XmlNodeList xmlNodeList_2 = xmlDoc.GetElementsByTagName(_ELEMENT_NAME_2_2);

            //output: all message names
            Console.WriteLine("ALL OPERATION NAMES OF BINDING ELEMENTS");
            if (xmlNodeList_2.Count > 0)
            {
                for (int i = 0; i < xmlNodeList_2.Count; i++)
                {
                    // Dump the contents of the elements we've found to standard output.
                    try
                    {
                        //filter those elements whose parent is "binding"
                        if (xmlNodeList_2.Item(i).ParentNode.Name == _ELEMENT_NAME_2_1)
                        {
                            Console.WriteLine(
                            "<" + _ELEMENT_NAME_2_2 + " " +
                            xmlNodeList_2.Item(i).Attributes.GetNamedItem(_ATTRIBUTE_NAME_2).OuterXml
                            + "></" + _ELEMENT_NAME_2_2 + ">"
                            );
                        }
                    }
                    catch (Exception)
                    {
                        //do nothing
                    }
                }
            }
            //to prevent the console window from closing
            Console.ReadLine();
        }
    }
}
