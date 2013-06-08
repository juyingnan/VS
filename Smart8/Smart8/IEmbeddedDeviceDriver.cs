using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart8
{
    interface IEmbeddedDeviceDriver
    {
         string ReceiveExplainedCommand(string command);

         int SendHeartBeat();
    }
}
