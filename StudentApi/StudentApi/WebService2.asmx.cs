using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace StudentApi
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        public void SendJSON(string JSONtxt)
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json"; 
            Context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Context.Response.Flush();
            Context.Response.Write(JSONtxt);

        }
        [WebMethod]

        public void getAllStudent()
        {

            List<student> studentlist = new List<student>();
            studentlist = DBAccess.getStudents();
            string List = JsonConvert.SerializeObject(studentlist);
            string jsonTxt = List;
            SendJSON(List);

        }

        [WebMethod]

        public void getStudentByID(string sid)
        {
            
            List<student> studentlist = new List<student>();
            studentlist = DBAccess.getSpecificStudent(sid);
            string List = JsonConvert.SerializeObject(studentlist); 
            string jsonTxt =  List;
             SendJSON(jsonTxt);

        }

        [WebMethod]
        public void PostAllStudent(string SId, string Sname, string Scourse, string Smarks)
        {
            int affectedRows = DBAccess.postStudents(SId, Sname, Scourse, Smarks);
            if (affectedRows > 0)
            {
                Context.Response.Write("Successfully Posted");
            }
            else
            {
                Context.Response.Write("Cannot Successfully Posted");
            }

        }


        [WebMethod]
        public void PutAllStudent(string SId,string Sname, string Scourse, string Smarks)
        {
            int affectedRows = DBAccess.putStudents(SId,Sname, Scourse, Smarks);
            if (affectedRows > 0)
            {
                Context.Response.Write("Successfully Updated");
            }
            else
            {
                Context.Response.Write("Cannot Successfully Updated");
            }

        }

        [WebMethod]
        public void DeleteAllStudent(string SId)
        {
            int affectedRows = DBAccess.deleteStudent(SId);
            if (affectedRows > 0)
            {
                Context.Response.Write("Successfully Deleted");
            }
            else
            {
                Context.Response.Write("Cannot Successfully Deleted");
            }
        }



    }
}
