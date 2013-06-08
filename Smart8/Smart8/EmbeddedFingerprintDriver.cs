using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Smart8
{
    [DataContract]
    public class EmbeddedFingerprintDriver:IEmbeddedDeviceDriver
    {
        public int SendHeartBeat()
        {
            return 1;
        }

        public string ReceiveExplainedCommand(string command)
        {
            switch (command)
            {
                case "SEND_FINGERPRINT":
                    Random r = new Random();
                    int number =r.Next(1,1000);
                    DateTime t = DateTime.Now.AddMinutes(-5);
                    lastFingerPrint = "Fingerprint Device ID: "+ID+", Employer No." + number + ", Access Time:" + t.ToShortDateString() + ", " + t.ToLongTimeString();
                    return lastFingerPrint;
                case "SEND_BHEARTBEAT":
                    return SendHeartBeat().ToString();
                default:
                    return "Undefined command";
            }                
        }

        [DataMember]
        string lastFingerPrint="TestUser";

        [DataMember]
        public int ID;
    }
}