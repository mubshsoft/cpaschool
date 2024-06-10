using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data;
using fmsf.lib;
using fmsf.DAL;


public partial class Calendar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetAutherbyID_j(string Courseid)
    {
        DataSet ds = new DataSet();
        
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        
        LIBEvent objLIBExam = new LIBEvent();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.CourseID = Courseid;
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.GetEventManagementForCalendar(tp);

        Dictionary<string, object> childRow;
        for(int i=0;i<ds.Tables[0].Rows.Count; i++)
        {
            try
            {
                childRow = new Dictionary<string, object>();
                string strsdt = ds.Tables[0].Rows[i]["start_date"].ToString();  
                string stredt = ds.Tables[0].Rows[i]["end_date"].ToString(); 

                childRow.Add("ID", ds.Tables[0].Rows[i]["eventID"].ToString());
                childRow.Add("title", ds.Tables[0].Rows[i]["title"].ToString());

                childRow.Add("start_date", strsdt);
                childRow.Add("end_date", stredt);
                childRow.Add("ParticipantsComposition", ds.Tables[0].Rows[i]["description"].ToString());
                childRow.Add("ThemeColor", ds.Tables[0].Rows[i]["ThemeColor"].ToString());
                childRow.Add("IsFullDay", ds.Tables[0].Rows[i]["IsFullDay"].ToString());

                parentRow.Add(childRow);
            }
            catch (Exception ex)
            {
            }

        }


        return jsSerializer.Serialize(parentRow);


    }
}