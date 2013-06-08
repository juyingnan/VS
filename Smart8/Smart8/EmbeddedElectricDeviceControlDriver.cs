using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart8
{
    public class EmbeddedElectricDeviceControlDriver : IEmbeddedDeviceDriver
    {
        public string ReceiveExplainedCommand(string command)
        {
            switch (command)
            {
                case "TURN_ON":
                    isOn = true;
                    break;
                case "TURN_OFF":
                    isOn = false;
                    break;
                case "BRIGHTNESS+":
                        brightness++;
                    if (brightness > 9) brightness = 9;
                    break;
                case "BRIGHTNESS-":
                        brightness--;
                    if (brightness < 0) brightness = 0;
                    break;
                case "VOLUME+":
                        volume++;
                    if (volume > 9) volume = 9;
                    break;
                case "VOLUME-":
                        volume--;
                    if (volume < 0) volume = 0;
                    break;
                case "SEND_BHEARTBEAT":
                    return SendHeartBeat().ToString();
                default:
                    return "Undefined command";
            }
            return GetStatus();
        }

        public int SendHeartBeat()
        {
            return 1;
        }

        int brightness = 3;

        int volume = 3;

        bool isOn = false;

        public int ID;

        public string GetStatus()
        {
            return "Electric Device ID:" + ID + " is " + (isOn ? "ON" : "OFF") + ", Brightness: " + brightness.ToString() + ", Volume: " + volume.ToString();
        }
    }
}