using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Smart8
{
    [DataContract]
    public class EmbeddedFingerprintExplainer : IEmbeddedDeviceExplainer
    {
        public string ReceiveRawCommand(string rawCommand)
        {
            return ExplainRawCommand(rawCommand);
        }

        public string ExplainRawCommand(string rawCommand)
        {
            string OperateCommand;

            switch (rawCommand)
            {
                case "SF": OperateCommand = "SEND_FINGERPRINT";
                    break;
                case "SH": OperateCommand = "SEND_BHEARTBEAT";
                    break;
                default:
                    OperateCommand = "";
                    break;
            }

            return SendExplainedCommand(OperateCommand);
        }

        public string SendExplainedCommand(string command)
        {
            return command;
        }

        [DataMember]
        public int ID;
    }
}