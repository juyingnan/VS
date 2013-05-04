using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Xml;


namespace HW2_WS_Q2_RestfulClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<String> a = p.getStudentInfoByGet("1201210631");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        //http request bt GET
        public List<String> getStudentInfoByGet(string ID_No)
        {
            //Create the URL
            List<String> infos = new List<string>();
            String[] functions = { "GetStudentName", "GetStudentGender", "GetStudentMajor", "GetStudentEmailAddress" };
            string function = "";
            for (int i = 0; i < functions.Length; i++)
            {
                function = functions[i];
                string strURL = "http://localhost:8080/axis2/services/StuInfoWebService/" + function + "?ID_No=" + ID_No;

                //Initiate, DO NOT use constructor of HttwWebRequest
                //DO use constructor of WebRequest
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream s = response.GetResponseStream();
                XmlTextReader reader = new XmlTextReader(s);
                reader.MoveToContent();
                string xml = reader.ReadInnerXml();
                ////////
                xml = xml.Split(new Char[] { '<', '>' })[2];
                /////////
                infos.Add(xml);
            }
            return infos;
        }
    }
}
