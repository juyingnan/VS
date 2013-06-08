using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart8
{
    public class EmbeddedElectricDeviceControlProcessor : IEmbeddedDeviceFactory
    {
        public string ExplainRawCommand(string command)
        {
            string c = embeddedElectricDeviceControlExplainer.ExplainRawCommand(command);
            return OperateDevice(c);
        }

        public string OperateDevice(string command)
        {
            return embeddedElectricDeviceControlDriver.ReceiveExplainedCommand(command);
        }

        public EmbeddedElectricDeviceControlDriver embeddedElectricDeviceControlDriver = new EmbeddedElectricDeviceControlDriver();
        public EmbeddedElectricDeviceControlExplainer embeddedElectricDeviceControlExplainer = new EmbeddedElectricDeviceControlExplainer();

        public int ID;

        public EmbeddedElectricDeviceControlProcessor(int ID)
        {
            this.ID = ID;
            embeddedElectricDeviceControlDriver.ID = ID;
            embeddedElectricDeviceControlExplainer.ID = ID;
        }        
    }
}