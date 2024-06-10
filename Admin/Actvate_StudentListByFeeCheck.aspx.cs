using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_Actvate_StudentListByFeeCheck : System.Web.UI.Page
{
    DataSet dsPaperid = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "Admin")
            { }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
        if (!Page.IsPostBack)
        {

            BindActivateStudent();
            BindInActivateStudent();
        }
    }
    ////2nd gridview BindActivateStudent()  SP_ReportActvateStudentInfo_FeeStatusActivate
    protected void BindActivateStudent()
    {
        //DataSet ds = new DataSet();
        try
        {
            int paperid = 0;
            string ss = Request.QueryString["Examid"].ToString();
            int examid = 0;
            examid = Convert.ToInt32(ss);
            int bid = Convert.ToInt32(Request.QueryString["bid"]);
            //string activate = "-1";
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            objLIBExam.BatchId = bid;
            tp.MessagePacket = (object)objLIBExam;
            dsPaperid = objDalExam.GetPaperIdForSupply(tp);
            if (dsPaperid.Tables[0] != null)
            {
                if (dsPaperid.Tables[0].Rows.Count > 0)
                {
                    paperid = Convert.ToInt32(dsPaperid.Tables[0].Rows[0]["PaperId"].ToString());
                }
            }
            objLIBExam.paperId = paperid;
            //objLIBExam.Activate = activate;
            //objLIBExam.CourseId = 0;
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentActivateExam_FeeStatusActivate(tp);
            grdActveStudent.DataSource = ds;
            grdActveStudent.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    //1st gridview BindInActivateStudent()   SP_ReportActvateStudentInfo_FeeStatus
    protected void BindInActivateStudent()
    {
        //DataSet ds=new DataSet();
        try
        {
            int paperid = 0;
            int examid = Convert.ToInt32(Request.QueryString["examid"]);
            int bid = Convert.ToInt32(Request.QueryString["bid"]);
            //string activate = "-1";
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            objLIBExam.BatchId = bid;
            tp.MessagePacket = (object)objLIBExam;
            dsPaperid = objDalExam.GetPaperIdForSupply(tp);
            if (dsPaperid.Tables[0] != null)
            {
                if (dsPaperid.Tables[0].Rows.Count > 0)
                {
                    paperid = Convert.ToInt32(dsPaperid.Tables[0].Rows[0]["PaperId"].ToString());
                }
            }
            objLIBExam.paperId = paperid;
            //objLIBExam.Activate = activate;
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentActivateExam_FeeStatus(tp);
            grdInActiveStudent.DataSource = ds;
            grdInActiveStudent.DataBind();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            btnClose.Visible = true;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            btnClose.Visible = false;
                            btnSave.Visible = false;

                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        int ExamId, bid, addResult;
        string UserId;
        ExamId = 0;
        bid = 0;
        //Stid = 0;
        //CourseId = 0;
        //PaperId = 0;
        addResult = 0;
        UserId = "";
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        try
        {
            for (int i = 0; i < grdInActiveStudent.Rows.Count; i++)
            {
                //string userid = ((Label)grdInActiveStudent.Rows[i].FindControl("lbluserid")).Text.ToString();
                UserId = ((Label)grdInActiveStudent.Rows[i].FindControl("lblbatch")).Text.ToString();
                ExamId = Convert.ToInt32(Request.QueryString["examid"]);
                bid = Convert.ToInt32(Request.QueryString["bid"]);
                string strStid = "select * from student where email= '" + UserId + "'";
                string strCourseId = "select * from examset where examid=" + ExamId;
                DataTable dtStid = new DataTable();
                DataTable dtCourseId = new DataTable();
                dtStid = objDalExam.getdata(strStid);
                dtCourseId = objDalExam.getdata(strCourseId);
                CheckBox chk = (CheckBox)grdInActiveStudent.Rows[i].FindControl("chk");
                if (chk.Checked == true)
                {
                    TransportationPacket tp = new TransportationPacket();
                    objLIBExam.ExamId = ExamId;
                    objLIBExam.BatchId = bid;
                    objLIBExam.UserId = UserId;
                    if(dtStid != null)
                    {
                        if(dtStid.Rows.Count > 0)
                        {
                            for(int a=0; a<dtStid.Rows.Count; a++)
                            {
                                objLIBExam.stid = Convert.ToInt32(dtStid.Rows[a]["stid"].ToString());
                            }
                        }
                    }
                    if (dtCourseId != null)
                    {
                        if (dtCourseId.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtCourseId.Rows.Count; j++)
                            {
                                objLIBExam.CourseId = Convert.ToInt32(dtCourseId.Rows[j]["CourseId"].ToString());
                                objLIBExam.paperId = Convert.ToInt32(dtCourseId.Rows[j]["PaperId"].ToString());
                            }
                        }
                    }
                    tp.MessagePacket = (object)objLIBExam;
                    addResult = objDalExam.UpdateActivateStudentExamSet_FeeStatus(tp);
                }
            }
            BindActivateStudent();
            BindInActivateStudent();
        }
        catch
        {
        }
    }
    protected void grdInActiveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInActiveStudent.PageIndex = e.NewPageIndex;
        BindInActivateStudent();
    }
    protected void grdActveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActveStudent.PageIndex = e.NewPageIndex;
        BindActivateStudent();
    }
    protected void grdActveStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int stid, CourseId, examid, bid, paperid;
        string userid;
        stid = 0;
        CourseId = 0;
        examid = 0;
        bid = 0;
        paperid = 0;
        userid = "";
        try
        {
            if (e.CommandName == "Deactivate")
            {
                /////////New Begin
                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                LIBExamListing objLibExamListing = new LIBExamListing();
                TransportationPacket tp = new TransportationPacket();

                userid = e.CommandArgument.ToString();
                examid = Convert.ToInt32(Request.QueryString["examid"]);
                bid = Convert.ToInt32(Request.QueryString["bid"]);
                string strStid = "select * from student where email='" + userid + "'";
                string strCourseId = "select * from examset where examid=" + examid;
                DataTable dtStid = new DataTable();
                DataTable dtCourseId = new DataTable();
                dtCourseId = objDalExam.getdata(strCourseId);
                dtStid = objDalExam.getdata(strStid);
                if (dtStid != null)
                {
                    if (dtStid.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtStid.Rows.Count; i++)
                        {
                            stid = Convert.ToInt32(dtStid.Rows[i]["stid"].ToString());
                        }
                    }
                }
                if (dtCourseId != null)
                {
                    if (dtCourseId.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtCourseId.Rows.Count; j++)
                        {
                            CourseId = Convert.ToInt32(dtCourseId.Rows[j]["CourseId"].ToString());
                            paperid = Convert.ToInt32(dtCourseId.Rows[j]["PaperId"].ToString());
                        }
                    }
                }

                objLIBExam.ExamId = examid;
                objLIBExam.BatchId = bid;
                objLIBExam.UserId = userid;
                objLIBExam.stid = stid;
                objLIBExam.CourseId = CourseId;
                objLIBExam.paperId = paperid;
                //objLIBExam.Activate = activate;
                tp.MessagePacket = (object)objLIBExam;
                /////////New End
                //DALExam objDalExam = new DALExam();
                //string str = "delete from studentactiveexam  where id=" + id;
                //string str = "Update FeeStatus set FeeStatus='0' where stid=" + stid + "and courseid=" + CourseId;
                //string str = "Update StudentSemester set FeeStatus='1' where stid=" + stid + "and courseid=" + CourseId;
                //objDalExam.ExeNQcomsp(str);
                objDalExam.UpdateActivateStudentFeeSubmitForSupply(tp);

                BindInActivateStudent();
                BindActivateStudent();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}
