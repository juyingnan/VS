using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Net;
using System.IO;
using System.Xml;


namespace HW2_WS_Q2_RESTClient_WPF
{
    class HttpWebOperation
    {
        //http request bt GET
        //to get info of a student
        public List<String> getStudentInfoByGet(string URL, string ID_No)
        {
            //Create the URL
            List<String> infos = new List<string>();
            String[] functions = { "GetStudentName", "GetStudentGender", "GetStudentMajor", "GetStudentEmailAddress" };
            string function = "";
            for (int i = 0; i < functions.Length; i++)
            {
                function = functions[i];
                string strURL = URL + function + "?ID_No=" + ID_No;

                //Initiate, DO NOT use constructor of HttwWebRequest
                //DO use constructor of WebRequest
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream s = response.GetResponseStream();
                    XmlTextReader reader = new XmlTextReader(s);
                    reader.MoveToContent();
                    string xml = reader.ReadInnerXml();
                    ////////
                    xml = xml.Split(new Char[] { '<', '>' })[2];
                    /////////
                    infos.Add(xml);
                }                
            }
            return infos;
        }

        //http request bt POST
        //to add new info of a student
        public String InsertStudentInfoByPost(string URL, String Info)
        {
            string strURL = URL+ "InsertStudentInfo";
            
            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            string param = "Info="+ HttpUtility.UrlEncode(Info, myEncoding);
            
            byte[] bs = Encoding.ASCII.GetBytes(param);
            string result="";

            //Initiate, DO NOT use constructor of HttwWebRequest
            //DO use constructor of WebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //POST
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.ContentLength = bs.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //DEAL with return values here
                Stream s = response.GetResponseStream();
                XmlTextReader reader = new XmlTextReader(s);
                reader.MoveToContent();
                result = reader.ReadInnerXml();
                ////////
                result=result.Split(new Char[] { '<', '>' })[2];
                /////////
            }
            return result;
        }

        //http request bt DELETE
        //to delete info of a student
        public String DeleteStudentInfoByDelete(string URL, string ID_No)
        {
            string strURL = URL+"DeleteStudentInfo?ID_No="+ID_No;

            //string param = "ID_No=" + ID_No;
            //byte[] bs = Encoding.ASCII.GetBytes(param);
            string result = "";

            //Initiate, DO NOT use constructor of HttwWebRequest
            //DO use constructor of WebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            
            //POST
            request.Method = "DELETE";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = bs.Length;

            //using (Stream reqStream = request.GetRequestStream())
            //{
            //    reqStream.Write(bs, 0, bs.Length);
            //}

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //DEAL with return values here
                Stream s = response.GetResponseStream();
                XmlTextReader reader = new XmlTextReader(s);
                reader.MoveToContent();
                result = reader.ReadInnerXml();
                ////////
                result = result.Split(new Char[] { '<', '>' })[2];
                /////////
            }
            return result;
        }

        //http request bt PUT
        //to update info of a student
        public String UpdateStudentInfoByPut(string URL, String Info)
        {
            string strURL = URL+"UpdateStudentInfo/";

            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            string param = "Info=" + HttpUtility.UrlEncode(Info, myEncoding);

            byte[] bs = Encoding.ASCII.GetBytes(param);
            string result = "";

            //Initiate, DO NOT use constructor of HttwWebRequest
            //DO use constructor of WebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //POST
            request.Method = "PUT";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.ContentLength = bs.Length;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                Stream s = response.GetResponseStream();
                XmlTextReader reader = new XmlTextReader(s);
                reader.MoveToContent();
                result = reader.ReadInnerXml();
                ////////
                result = result.Split(new Char[] { '<', '>' })[2];
                /////////
            }
            return result;
        }

    }
}
