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
using System.Data.SqlClient;

public partial class Student_StudentDashboard : System.Web.UI.Page
{
    private static int bid;
    protected string VideoDemo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        if (!Page.IsPostBack)
        {
            try
            {
                hdnBid.Value = GetBatchofStudforGraph();
                bid = Convert.ToInt32(hdnBid.Value);
                StudentForDownloadmeterial();
                bindDemoVideo();
                bindNews();
               
            }
            catch(Exception ex)
            {

            }
        }

    }

    
    private string GetBatchofStudforGraph()
    {
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.Stid = Convert.ToInt32(Session["stid"]);

        tp.MessagePacket = (object)objLIBExam;
        return Convert.ToString(objDalExam.GetBatchofStudforGraph(tp));
      
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetStudentProgressPie(string PaperID)
    {
        DataSet ds = new DataSet();
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.paperId = Convert.ToInt32(PaperID);
        objLIBExam.bid = bid;
        objLIBExam.stid =Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
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


    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string LoadPaper()
    {
        DataSet ds = new DataSet();

        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();

        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.bid = bid;
        objLIBExam.stid = Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.PaperList4ProgressGraph(tp);

        Dictionary<string, object> childRow;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            try
            {
                childRow = new Dictionary<string, object>();
                childRow.Add("PaperId", ds.Tables[0].Rows[i]["PaperId"].ToString());
                childRow.Add("papertitle", ds.Tables[0].Rows[i]["papertitle"].ToString());
                parentRow.Add(childRow);
            }
            catch (Exception ex)
            {
            }
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
        objLIBExam.bid = bid;
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

    public void bindDemoVideo()
    {
        var objParamList = new List<SqlParameter>();
        try
        {
            string strq = "select TOP 1 * from DemoManual where type='Video' and checked=1 order by id desc";
            var ds = new DataSet();
            ds = CLS.fnQuerySelectDs(strq);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //lnkDemoVideo.Visible = true;
               // lblCaption.Text = ds.Tables[0].Rows[0]["Caption"].ToString();
                string strPath = ds.Tables[0].Rows[0]["filepath"].ToString();
                string fullpath = "../" + strPath;
                VideoDemo = fullpath;
                
               // IframeVideo.Attributes.Add("src", fullpath);
            }
            else
            {
                //lnkDemoVideo.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void StudentForDownloadmeterial()
    {
        try
        {
            string strq = "select stid from student where email='" + Session["username"].ToString() + "'";
            var ds = new DataSet();
            ds = CLS.fnQuerySelectDs(strq);
            string studentid = ds.Tables[0].Rows[0]["stid"].ToString();
            string strq1 = "select stid from student where stid in(select stid from StudentRegBatch where stid='" + studentid + "')";
            var ds1 = new DataSet();
            ds1 = CLS.fnQuerySelectDs(strq1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                lnkCourseMeterial.Attributes.Add("href", "StudentListCourse.aspx");
                lnkCourseMeterial.Attributes.Remove("href");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnIDCard_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string sessVal = Session["username"].ToString();
            string str_StID = "select stid from Student where email='" + sessVal + "'";
            var dsStID = new DataSet();
            dsStID = CLS.fnQuerySelectDsGrv(str_StID);
            int StID = 0;
            int StID_Suppl = 0;
            int BID = 0;
            string Paperid_Suppl = "";
            string Paperid = "";
            string Str_Examid = "";
            int Examid = 0;
            if (dsStID.Tables[0]!=null)
            {
                if (dsStID.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0, loopTo = dsStID.Tables[0].Rows.Count - 1; i <= loopTo; i++)
                        StID = Convert.ToInt32(dsStID.Tables[0].Rows[i]["stid"].ToString());
                    string str_BID = "select distinct bid from StudentRegBatch where stid=" + StID;
                    var dsBID = new DataSet();
                    dsBID = CLS.fnQuerySelectDsGrv(str_BID);
                    // ''''Batch if Begin'''''''''
                    if (dsBID.Tables[0]!=null)
                    {
                        if (dsBID.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0, loopTo1 = dsBID.Tables[0].Rows.Count - 1; j <= loopTo1; j++)
                                BID = Convert.ToInt32(dsBID.Tables[0].Rows[j]["bid"].ToString());
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('StudentIDCard.aspx?stid=" + StID + "&bid=" + BID + "');", true);
                        }
                        // ''''Batch if End'''''''''
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void bindNews()
    {
        try
        {
            string strq = "select NewsId,NewsDesc as descr,newsdate as ndate from News where NewsType='General' union select EventId, eventtitle as descr,eventdate as ndate from event";
            var dsNews = new DataSet();
            dsNews = CLS.fnQuerySelectDs(strq);
            if (dsNews is object)
            {
                if (dsNews.Tables is object)
                {
                    if (dsNews.Tables[0].Rows is object)
                    {
                        if (dsNews.Tables[0].Rows.Count > 0)
                        {
                            dlnews.DataSource = dsNews;
                            dlnews.DataBind();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnExamset_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string sessVal = Session["username"].ToString();
            string str_StID = "select stid from Student where email='" + sessVal + "'";
            var dsStID = new DataSet();
            dsStID = CLS.fnQuerySelectDsGrv(str_StID);
            int StID = 0;
            int StID_Suppl = 0;
            int BID = 0;
            string Paperid_Suppl = "";
            string Paperid = "";
            string Str_Examid = "";
            int Examid = 0;
            // '''''''''''''''''''''''''''''''''''''''''''**************New Code 14/01/2014 Start*******************''''''''''''''''''''''''''''''''''''''''''''''''''
            // ''''StudentPaperMarks if Begin'''''''''
            if (dsStID.Tables[0] is object)
            {
                if (dsStID.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0, loopTo = dsStID.Tables[0].Rows.Count - 1; i <= loopTo; i++)
                        // StID = StID + Convert.ToInt32(dsStID.Tables(0).Rows(i)("stid").ToString())
                        StID = Convert.ToInt32(dsStID.Tables[0].Rows[i]["stid"].ToString());
                    // Dim str_BID As String = "select distinct bid from StudentPaperMarks where stid=" & StID
                    string str_BID = "select distinct bid from StudentRegBatch where stid=" + StID;
                    var dsBID = new DataSet();
                    dsBID = CLS.fnQuerySelectDsGrv(str_BID);
                    // ''''Batch if Begin'''''''''
                    if (dsBID.Tables[0] is object)
                    {
                        if (dsBID.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0, loopTo1 = dsBID.Tables[0].Rows.Count - 1; j <= loopTo1; j++)
                                BID = Convert.ToInt32(dsBID.Tables[0].Rows[j]["bid"].ToString());

                            // Dim str_StID_Suppl As String = "select distinct stid from studentpapermarks where bid=" & BID & ""
                            string str_StID_Suppl = "select distinct stid from studentpapermarks where stid=" + StID + "";
                            var dsStID_Suppl = new DataSet();
                            dsStID_Suppl = CLS.fnQuerySelectDsGrv(str_StID_Suppl);
                            if (dsStID_Suppl.Tables[0] is object)
                            {
                                if (dsStID_Suppl.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0, loopTo2 = dsStID_Suppl.Tables[0].Rows.Count - 1; i <= loopTo2; i++)
                                        // StID_Suppl = StID_Suppl + Convert.ToInt32(dsStID_Suppl.Tables(0).Rows(i)("stid").ToString())
                                        StID_Suppl = Convert.ToInt32(dsStID_Suppl.Tables[0].Rows[i]["stid"].ToString());
                                    if (dsStID_Suppl.Tables[0] is object && dsStID.Tables[0] is object)
                                    {
                                        // Dim str_paperID_Suppl As String = "Select distinct paperId from StudentPaperMarks where stid=" & StID & " and bid=" & BID & " and Examstatus=0"
                                        string str_examID_Suppl = "Select distinct ExamId from StudentSupplyExamAssign where stid=" + StID + " and bid=" + BID + "";
                                        // Dim dsPaperid_Suppl As New DataSet()
                                        var dsExamId_Suppl = new DataSet();
                                        dsExamId_Suppl = CLS.fnQuerySelectDsGrv(str_examID_Suppl);
                                        // ''''Paper if Begin (26-02-2014) Begin'''''''''
                                        // Dim str_examID_Suppl_1 As String = "select distinct ExamId from examset where examid not in (select distinct ExamId from StudentPaperMarks inner join examset on examset.paperid=StudentPaperMarks.paperid where examset.examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') and StudentPaperMarks.stid=" & StID & " and StudentPaperMarks.examstatus=0) and examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "')"
                                        string str_examID_Suppl_1 = "select distinct ExamId from examset where examid not in (select distinct ExamId from StudentPaperMarks inner join examset on examset.paperid=StudentPaperMarks.paperid where examset.examid in (select distinct ExamId from StudentActiveExam where userid='" + sessVal + "') and StudentPaperMarks.stid=" + StID + ") and examid in (select distinct ExamId from StudentActiveExam where userid='" + sessVal + "')";
                                        var dsExamId_Suppl_1 = new DataSet();
                                        dsExamId_Suppl_1 = CLS.fnQuerySelectDsGrv(str_examID_Suppl_1);
                                        // ''''Paper if Begin (26-02-2014) End'''''''''
                                        if (dsExamId_Suppl_1.Tables[0] is object)
                                        {
                                            if (dsExamId_Suppl_1.Tables[0].Rows.Count > 0)
                                            {
                                                for (int k = 0, loopTo3 = dsExamId_Suppl_1.Tables[0].Rows.Count - 1; k <= loopTo3; k++)
                                                    Paperid_Suppl = Paperid_Suppl + dsExamId_Suppl_1.Tables[0].Rows[k]["ExamId"].ToString() + ",";
                                            }

                                            if (dsExamId_Suppl.Tables[0].Rows.Count > 0)
                                            {
                                                for (int k = 0, loopTo4 = dsExamId_Suppl.Tables[0].Rows.Count - 1; k <= loopTo4; k++)
                                                    // Paperid_Suppl = Paperid_Suppl + dsPaperid_Suppl.Tables(0).Rows(k)("paperId").ToString() + ","
                                                    Paperid_Suppl = Paperid_Suppl + dsExamId_Suppl.Tables[0].Rows[k]["ExamId"].ToString() + ",";
                                            }
                                        }
                                        else
                                        {
                                            Paperid_Suppl = "0";
                                        }

                                        // ''''Paper if End'''''''''
                                        Response.Redirect("ExamSet.aspx?STID=" + StID_Suppl.ToString() + "&Bid=" + BID.ToString() + "&pid=" + Paperid_Suppl.ToString());
                                    }
                                    else
                                    {
                                        Response.Redirect("ExamSet.aspx");
                                    }
                                }
                            }
                            // '''''''''''''''New Something
                            // If dsStID_Suppl.Tables(0) Is Nothing AndAlso dsStID.Tables(0) IsNot Nothing Then
                            if (dsStID.Tables[0] is object && StID_Suppl == 0)
                            {
                                // Dim str_paperID As String = "select distinct PaperId from examset where examid in (select distinct ExamId from StudentActiveExam where userid='" & sessVal & "') order by PaperId"
                                string str_ExamID1 = "select distinct ExamId from examset where examid in (select distinct ExamId from StudentActiveExam where userid='" + sessVal + "') order by ExamId";
                                var dsExamId = new DataSet();
                                // dsPaperid = CLS.fnQuerySelectDsGrv(str_paperID)
                                dsExamId = CLS.fnQuerySelectDsGrv(str_ExamID1);

                                // ''''Paper if Begin'''''''''
                                if (dsExamId.Tables[0] is object)
                                {
                                    if (dsExamId.Tables[0].Rows.Count > 0)
                                    {
                                        for (int x = 0, loopTo5 = dsExamId.Tables[0].Rows.Count - 1; x <= loopTo5; x++)
                                            Paperid = Paperid + dsExamId.Tables[0].Rows[x]["ExamId"].ToString() + ",";
                                    }
                                    else
                                    {
                                        Paperid = "0,";
                                    }
                                }
                                // ''''Paper if End'''''''''

                                Response.Redirect("ExamSet.aspx?STID=" + StID.ToString() + "&Bid=" + BID.ToString() + "&pid=" + Paperid.ToString());
                            }
                            else
                            {
                                Response.Redirect("ExamSet.aspx");
                            }


                            // If a IsNot Nothing AndAlso c Is Nothing Then

                            // ElseIf b = c Then
                            // Else
                            // End If
                        }
                    }
                    // ''''Batch if End'''''''''
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetCourse()
    {
        DataSet ds = new DataSet();
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
       
        objLIBExam.stid = Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
        tp.MessagePacket = (object)objLIBExam;
        List<LIBExam> ls = objDalExam.GetCourseListBySTD(tp);
        var json = new
        {
            rows = ls

        };

        // Return JSON data
        JavaScriptSerializer js = new JavaScriptSerializer();
        string retJSON = js.Serialize(json);
        return retJSON;

    }
   

   
    
}