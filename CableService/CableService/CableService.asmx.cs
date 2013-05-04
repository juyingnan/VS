using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CableService
{
    /// <summary>
    /// Summary description for CableService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CableService : System.Web.Services.WebService
    {

        [WebMethod]
        public String GetCableInfo(String CustomerID, int EventID)
        {
            CableOperation s = new CableOperation();
            return s.GetCableInfo(CustomerID, "Channel" + EventID.ToString());
        }

        [WebMethod]
        public String UpdCableInfo(String CustomerID, int EventID, bool b)
        {
            CableOperation s = new CableOperation();
            return s.updCableInfo(CustomerID, "Channel" + EventID.ToString(), b);
        }
    }
}
