using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Smart8
{
    [DataContract]
    public class EmbeddedFingerprintProcessor : IEmbeddedDeviceFactory
    {
        public string ExplainRawCommand(string command)
        {
            string c = embeddedFingerprintExplaner.ExplainRawCommand(command);
            return OperateDevice(c);
        }

        public string OperateDevice(string command)
        {
            return embeddedFingerDriver.ReceiveExplainedCommand(command);
        }

        [DataMember]
        public EmbeddedFingerprintDriver embeddedFingerDriver = new EmbeddedFingerprintDriver();
        [DataMember]
        public EmbeddedFingerprintExplainer embeddedFingerprintExplaner = new EmbeddedFingerprintExplainer();

        [DataMember]
        public int ID;

        public EmbeddedFingerprintProcessor(int ID)
        {
            this.ID = ID;
            embeddedFingerDriver.ID = ID;
            embeddedFingerprintExplaner.ID = ID;
        }        
    }
}