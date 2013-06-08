using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Services;

namespace Smart8
{
    /// <summary>
    /// Summary description for Smart8_Embedded_Module
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Smart8_Embedded_Module : System.Web.Services.WebService
    {
        public Smart8_Embedded_Module()
        {
            for (int i = 0; i < embeddedFingerprinterDeviceCollection.Length; i++)
            {
                embeddedFingerprinterDeviceCollection[i] = new EmbeddedFingerprintProcessor(i);
            }

            for (int i = 0; i < embeddedElectricDeviceControlCollection.Length; i++)
            {
                embeddedElectricDeviceControlCollection[i] = new EmbeddedElectricDeviceControlProcessor(i);
            }
        }

        static EmbeddedFingerprintProcessor[] embeddedFingerprinterDeviceCollection = new EmbeddedFingerprintProcessor[100];
        static EmbeddedElectricDeviceControlProcessor[] embeddedElectricDeviceControlCollection = new EmbeddedElectricDeviceControlProcessor[100];
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        [WebMethod]
        public string ReceiveRawCommand(string rawCommand)
        {
            //ReadData();
            string type;
            string command;
            int number;
            try
            {
                type = rawCommand.Split('_')[0];
                number = int.Parse(rawCommand.Split('_')[1]);
                command = rawCommand.Split('_')[2];
            }
            catch (Exception)
            {
                return ("WRONG COMMAND FORMAT!");
            }

            string result;
            switch (type)
            {
                case "FP":
                    result = embeddedFingerprinterDeviceCollection[number].ExplainRawCommand(command);
                    break;
                case "EC":
                    result = embeddedElectricDeviceControlCollection[number].ExplainRawCommand(command);
                    break;
                default:
                    result = ("INVALID COMMAND!");
                    break;
            }
            //SaveDate();
            return result;
        }

        private void SaveDate()
        {
            scsb.DataSource = "tcp:ueyfidcaur.database.windows.net,1433";
            scsb.InitialCatalog = "Smart8";
            scsb.UserID = "bunny@ueyfidcaur";
            scsb.Password = "Test1340";

            string content = XMLSerialize(embeddedFingerprinterDeviceCollection);
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE embeddedDevice SET content='" + content + "' WHERE Id=1", con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    try
                    {
                        //return cmd.ExecuteNonQuery().ToString();
                    }
                    catch (Exception e)
                    {
                        //return e.Message;
                    }
                }
            }
        }

        private void ReadData()
        {
            scsb.DataSource = "tcp:ueyfidcaur.database.windows.net,1433";
            scsb.InitialCatalog = "Smart8";
            scsb.UserID = "bunny@ueyfidcaur";
            scsb.Password = "Test1340";
            //Trusted_Connection=False;Encrypt=True;Connection Timeout=30;

            string result;
            using (SqlConnection con = new SqlConnection(scsb.ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT content from embeddedDevice where Id=1", con))
                {
                    if (con.State != ConnectionState.Open) con.Open();
                    try
                    {
                        result = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception e)
                    {
                        result = null;
                    }
                }
            }
            if (result != null)
                embeddedFingerprinterDeviceCollection = XMLDeserialize<EmbeddedFingerprintProcessor[]>(result);
            else
            {
                embeddedFingerprinterDeviceCollection = new EmbeddedFingerprintProcessor[100];
                for (int i = 0; i < embeddedFingerprinterDeviceCollection.Length; i++)
                {
                    embeddedFingerprinterDeviceCollection[i] = new EmbeddedFingerprintProcessor(i);
                }
            }
        }

        /// <summary>
        /// 需要序列化XML数据对象
        /// </summary>
        /// <param name="objectToSerialize"><returns></returns>
        public static string XMLSerialize<T>(T objectToSerialize)
        {
            string result = "";
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(ms, objectToSerialize);
                ms.Position = 0;

                using (StreamReader reader = new StreamReader(ms))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// XML数据反序列化
        /// </summary>
        /// <typeparam name="T">反序列化对象</typeparam>
        /// <param name="xmlstr"><returns></returns>
        public static T XMLDeserialize<T>(string xmlstr)
        {
            byte[] newBuffer = System.Text.Encoding.UTF8.GetBytes(xmlstr);

            if (newBuffer.Length == 0)
            {
                return default(T);
            }
            using (MemoryStream ms = new MemoryStream(newBuffer))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

    }
}
