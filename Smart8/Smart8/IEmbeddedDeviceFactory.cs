using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart8
{
    interface IEmbeddedDeviceFactory
    {
         string ExplainRawCommand(string command);

         string OperateDevice(string command);
    }
}
