using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart8
{
    public class EmbeddedElectricDeviceControlExplainer : IEmbeddedDeviceExplainer
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
                case "ON": OperateCommand = "TURN_ON";
                    break;
                case "OFF": OperateCommand = "TURN_OFF";
                    break;
                case "B+": OperateCommand = "BRIGHTNESS+";
                    break;
                case "B-": OperateCommand = "BRIGHTNESS-";
                    break;
                case "V+": OperateCommand = "VOLUME+";
                    break;
                case "V-": OperateCommand = "VOLUME-";
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

        public int ID;
    }
}