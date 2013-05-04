using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace DInnerDecisionService
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Test : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string name)
        {
            return name+", Hello World";
        }

        [WebMethod]
        public string GetRestaurant(double latitude, double longitude, double r)
        {
            //Create the URL
            List<String> infos = new List<string>();
            string lat = latitude.ToString("0.0000");
            string lon = longitude.ToString("0.0000");

            string query = "餐厅";
            string tag = "";
            string output = "xml";
            string scope = "1";
            string page_size = "20";
            string ak = "21a5b61532027825cb09c76b29eacf8c";
            string radius = r.ToString("0");

            string strURL = RequestAddressGenerator(query,output,scope,page_size,ak,lat,lon,radius);

            string xml = RequestRestaurantInfo(strURL);

            return XMLInfoExtractor(xml);
        }

        private static string XMLInfoExtractor(string xml)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xml);
            string result = "";
            const string _STATUS_ELEMENT_NAME = "message";
            const string _STATUS_OK = "ok";
            XmlNodeList xmlNodeList_1 = xmlDoc.GetElementsByTagName(_STATUS_ELEMENT_NAME);
            if (xmlNodeList_1.Item(0).InnerText == _STATUS_OK)
            {
                const string _ELEMENT_NAME = "name";
                XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(_ELEMENT_NAME);
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    result += xmlNodeList.Item(i).InnerText + " ";
                }
                return result;
            }
            else
            {
                return "-1";
            }
        }

        private static string RequestRestaurantInfo(string strURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream s = response.GetResponseStream();
            XmlTextReader reader = new XmlTextReader(s);
            reader.MoveToContent();
            string xml = reader.ReadOuterXml();
            return xml;
        }

        private string RequestAddressGenerator(string query, string output, string scope, string page_size, string ak, string lat, string lon, string radius)
        {
            return "http://api.map.baidu.com/place/v2/search?ak=" + ak + "&output=" + output + "&query=" + query + "&page_size=" + page_size + "&page_num=0&scope=" + scope + "&location=" + lat + "," + lon + "&radius=" + radius;
        }
    }
}
