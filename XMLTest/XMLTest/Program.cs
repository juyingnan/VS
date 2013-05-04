using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLTest
{
    public class DOMExample
    {
        private string getXMLDocument(string url)
        {
            // Grab the dvd document from its source

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

        public static void Main(string[] args)
        {
            // Check to see that we have a single URI argument
            if (args.Length != 1)
            {
                return;
            }

            string url = args[0];
            DOMExample domExample = new DOMExample();
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(domExample.getXMLDocument(url));

            // Search DOM tree for a set of elements with particular name and namespace

            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("character", "http://dvd.example.org");

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                // Dump the contents of the elements we've found to standard output.
                Console.WriteLine(xmlNodeList.Item(i).OuterXml);
            }
            Console.ReadLine();
        }
    }

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 100; // TODO: Initialize to an appropriate value

            int b = 2; // TODO: Initialize to an appropriate value

            int expected = 50; // TODO: Initialize to an appropriate value

            int actual;

            actual = a / b;

            Assert.AreEqual(expected, actual);

            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
