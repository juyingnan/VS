using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HW2_WS_StuInfo_Server
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StuInfoWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public String GetStudentName(String ID_No)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.GetInfo("Name", ID_No);
        }

        [WebMethod]
        public String GetStudentGender(String ID_No)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.GetInfo("Gender", ID_No);
        }

        [WebMethod]
        public String GetStudentMajor(String ID_No)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.GetInfo("Major", ID_No);
        }


        [WebMethod]
        public String GetStudentEmail(String ID_No)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.GetInfo("Email_Address", ID_No);
        }

        [WebMethod]
        public String DeleteStudentInfo(String ID_No)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.DelInfo(ID_No);
        }

        [WebMethod]
        public String InsertStudentInfo(String Info)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.InsInfo(Info);
        }

        [WebMethod]
        public String UpdateStudentInfo(String Info)
        {
            StuInfoDBOperation s = new StuInfoDBOperation();
            return s.updInfo(Info);
        }


    }

}