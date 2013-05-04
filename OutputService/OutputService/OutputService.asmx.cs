using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace OutputService
{
    /// <summary>
    /// Summary description for OutputService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OutputService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string CustomerID, string RequestEventID, string ResponseEventID, string result)
        {
            return "Dear " + CustomerID + ", request channel:" + RequestEventID + ", response channel:" + ResponseEventID + ", result:" + result;
        }
    }
}
