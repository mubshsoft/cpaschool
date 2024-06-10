using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections;
using fmsf.lib;
using fmsf.DAL;

public partial class Student_chartnew1 : System.Web.UI.Page
{
    private static int bt;
    private static int stid;
    protected void Page_Load(object sender, EventArgs e)
    {
        stid = Convert.ToInt32(Request.QueryString["stid"].ToString());
        bt = Convert.ToInt32(Request.QueryString["bt"].ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetStudentProgressRpt()
    {


        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        DataSet ds = new DataSet();
        objLIBExam.bid = bt;
        objLIBExam.stid = stid;
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.GetProgressGraph(tp);

        DataTable dt;
        //dt = (DataTable)ds.Tables[0];
        dt = objDalExam.getdata("select Exam, Assignment,isnull(projectmarks,0) as project,forum from(select ExamMarks as Exam,AssignmentMarks as Assignment,forum,CaseStudymarks,projectmarks=(select Project from StudentSemMarks where stid=mrk.stid and bid=mrk.bid)  from StudentPaperMarks mrk where bid=61 and stid=345)a");
        List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();

        try
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow row in dt.Rows)
                    {

                        List<Dictionary<string, object>> parentRow1 = new List<Dictionary<string, object>>();
                        Dictionary<string, object> childRow1;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string str = row[dt.Columns[i].ColumnName.ToString()].ToString();
                            if (str != "NO")
                            {
                                childRow1 = new Dictionary<string, object>();
                                childRow1.Add("y", row[dt.Columns[i].ColumnName.ToString()]);
                                childRow1.Add("label", dt.Columns[i].ColumnName.ToString());

                                parentRow1.Add(childRow1);
                            }
                        }

                        parentRow.Add(parentRow1);
                    }
                }
            }



        }
        catch (Exception ec)
        {
        }

        return jsSerializer.Serialize(parentRow);


    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetPaperList()
    {
        DataSet ds = new DataSet();
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.bid = bt;
        objLIBExam.stid = Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
        tp.MessagePacket = (object)objLIBExam;
        List<LIBExam> ls = objDalExam.GetPaperList(tp);
        var json = new
        {
            rows = ls

        };

        // Return JSON data
        JavaScriptSerializer js = new JavaScriptSerializer();
        string retJSON = js.Serialize(json);
        return retJSON;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetStudentProgressPie()
    {
        DataSet ds = new DataSet();
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.bid = bt;
        objLIBExam.stid = stid;
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.GetProgressGraph(tp);

        DataTable dt;
        dt = (DataTable)ds.Tables[0];

        //dt = objDalExam.getdata("select Exam, Assignment,isnull(projectmarks,70) as project from(select ExamMarks as Exam,AssignmentMarks as Assignment,projectmarks=(select Project from StudentSemMarks where stid=mrk.stid and bid=mrk.bid)  from StudentPaperMarks mrk where bid=89 and stid=580)a");

        List<List<Dictionary<string, object>>> parentRow = new List<List<Dictionary<string, object>>>();

        try
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow row in dt.Rows)
                    {

                        List<Dictionary<string, object>> parentRow1 = new List<Dictionary<string, object>>();
                        Dictionary<string, object> childRow1;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string str = row[dt.Columns[i].ColumnName.ToString()].ToString();
                            if (str != "NO")
                            {
                                childRow1 = new Dictionary<string, object>();
                                childRow1.Add("y", row[dt.Columns[i].ColumnName.ToString()]);
                                childRow1.Add("name", dt.Columns[i].ColumnName.ToString());

                                parentRow1.Add(childRow1);
                            }

                        }

                        parentRow.Add(parentRow1);
                    }
                }
            }



        }
        catch (Exception ec)
        {
        }

        return jsSerializer.Serialize(parentRow);


    }
}