using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart8
{
    interface IEmbeddedDeviceExplainer
    {
        string ReceiveRawCommand(string rawCommand);

         string ExplainRawCommand(string rawCommand);

         string SendExplainedCommand(string command);
    }
}
