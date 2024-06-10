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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class SelectExamSet : System.Web.UI.Page
{
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


        try
        {
            if (!Page.IsPostBack)
            {

                BindCorseDropDown();
                try
                {
                    if (Request.QueryString["back"].ToString() == "1")
                    {
                        ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString["cid"].ToString()));
                        BindbatchDropDown(int.Parse(Request.QueryString["cid"].ToString()));
                        ddlbatch.SelectedIndex = ddlbatch.Items.IndexOf(ddlbatch.Items.FindByValue(Request.QueryString["bt"].ToString()));
                        BindSemesterDropDown(int.Parse(Request.QueryString["cid"].ToString()));
                        ddlSem.SelectedIndex = ddlSem.Items.IndexOf(ddlSem.Items.FindByValue(Request.QueryString["sid"].ToString()));
                        BindModuleDropDown(int.Parse(Request.QueryString["sid"].ToString()));
                        ddlModule.SelectedIndex = ddlModule.Items.IndexOf(ddlModule.Items.FindByValue(Request.QueryString["mid"].ToString()));
                        BindPaperDropDown(int.Parse(Request.QueryString["mid"].ToString()));
                        ddlPaper.SelectedIndex = ddlPaper.Items.IndexOf(ddlPaper.Items.FindByValue(Request.QueryString["pid"].ToString()));
                        bindDataSem();
                    }
                    else if (Request.QueryString["back"].ToString() == "2")
                    {
                        ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString["cid"].ToString()));
                        BindbatchDropDown(int.Parse(Request.QueryString["cid"].ToString()));
                        ddlbatch.SelectedIndex = ddlbatch.Items.IndexOf(ddlbatch.Items.FindByValue(Request.QueryString["bt"].ToString()));
                        BindSemesterDropDown(int.Parse(Request.QueryString["cid"].ToString()));
                        bindDataSem();
                    }

                }
                catch (Exception ex)
                {
                    HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                }

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
   
    protected void BindCorseDropDown()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourse(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0,"-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindSemesterDropDown(int CourseId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = CourseId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSemester(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlSem.DataSource = objLibExamListing;
            ddlSem.DataTextField = objLIBExam.SemesterDispalyText;
            ddlSem.DataValueField = objLIBExam.SemesterValueField;
            ddlSem.DataBind();
            ddlSem.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindbatchDropDown(int CourseId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = CourseId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetBatchByCourseid(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlbatch.DataSource = objLibExamListing;
            ddlbatch.DataTextField = "BatchCode1";
            ddlbatch.DataValueField = "bid1";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindModuleDropDown(int SemId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.SemesterId = SemId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetModule(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlModule.DataSource = objLibExamListing;
            ddlModule.DataTextField = objLIBExam.ModuleDispalyText;
            ddlModule.DataValueField = objLIBExam.ModuleValueField;
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindPaperDropDown(int ModuleId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ModuleId = ModuleId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetPaper(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlPaper.DataSource = objLibExamListing;
            ddlPaper.DataTextField = objLIBExam.PaperDispalyText;
            ddlPaper.DataValueField = objLIBExam.PaperValueField;
            ddlPaper.DataBind();
            ddlPaper.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindData();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSem.SelectedItem.Text == "-Select-")
        {
            lblreqsem.Text = "Select Semester";
            return;
        }
        int semId = Convert.ToInt32(ddlSem.SelectedValue);
        BindModuleDropDown(semId);
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModule.SelectedItem.Text == "-Select-")
        {
            lblreqmodule.Text = "Select Module";
            return;
        }
        int ModuleId = Convert.ToInt32(ddlModule.SelectedValue);
        BindPaperDropDown(ModuleId);


    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
                LinkButton lnkEditExam = (LinkButton)e.Row.FindControl("lnkEditDetailsExam");
                LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopyExam");
                HiddenField hdnExamID = (HiddenField)e.Row.FindControl("hdnExamID");
                Label examcode = (Label)e.Row.FindControl("lblexamcodeNo");
                valu.PostBackUrl = "~/Admin/AddSelectSection.aspx?ExamID=" + hdnExamID.Value;
                lnkEditExam.PostBackUrl = "~/Admin/SelectSection.aspx?ExamID=" + hdnExamID.Value;
                copyques.PostBackUrl = "~/Admin/CopyQuestion.aspx?ExamID=" + hdnExamID.Value +"&examcode="+examcode.Text;
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
   


    protected void lnkExam_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMarksEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&add=1");
    }

    protected void lnkAssign_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMarksEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&add2=2");
    }
    protected void lnkDiscussion_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMarksEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&diss=1");
    }
    protected void lnkProject_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddDisscussionEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&pro=2");
    }
    protected void lnkColumn1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddDisscussionEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&mrk1=1");
    }
    protected void lnkColumn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddDisscussionEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&mrk2=2");
    }

    protected void lnkCaseStudy_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCaseStudyEvaluation.aspx?cid=" + ddlCourse.SelectedValue + "&bt=" + ddlbatch.SelectedValue + "&sid=" + ddlSem.SelectedValue + "&pid=" + ddlPaper.SelectedValue + "&mid=" + ddlModule.SelectedValue + "&cs=1");
    }

    protected void bindData()
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        BindSemesterDropDown(CourseId);
        BindbatchDropDown(CourseId);
        LIBExam objLibExam = new LIBExam();

        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLibExam.CourseId = CourseId;

        tp.MessagePacket = (object)objLibExam;

        hdncoursecode.Value = objDalExam.GetCourseCodeByID(tp);

        // added by wahid

        try
        {
            DALExam OBJDALExam = new DALExam();
            //LIBExam objLibExam = new LIBExam();
            //TransportationPacket tp = new TransportationPacket();
            LIBExamListing objLIBExamListing = new LIBExamListing();
            objLibExam.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
            tp.MessagePacket = (object)objLibExam;
            tp = OBJDALExam.GetEvaluationCriteria(tp);
            objLIBExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLIBExamListing != null)
            {
                if (objLIBExamListing.Count > 0)
                {
                    lnkColumn1.Text = objLIBExamListing[0].ColumnName1;
                    lnkColumn2.Text = objLIBExamListing[0].ColumnName2;
                    if (objLIBExamListing[0].AssignmentMarks == true)
                    {
                        lnkAssign.Enabled = true;

                    }
                    else
                    {
                        lnkAssign.Enabled = false;
                    }

                    if (objLIBExamListing[0].ExamMarks == true)
                    {
                        lnkExam.Enabled = true;

                    }
                    else
                    {
                        lnkExam.Enabled = false;
                    }
                    if (objLIBExamListing[0].DiscussionForumMarks == true)
                    {

                        lnkDiscussion.Enabled = true;
                    }
                    else
                    {
                        lnkDiscussion.Enabled = false;
                    }
                    if (objLIBExamListing[0].ProjectMarks == true)
                    {
                        lnkProject.Enabled = true;
                    }
                    else
                    {
                        lnkProject.Enabled = false;
                    }


                    if (objLIBExamListing[0].CaseStudyMarks == true)
                    {
                        btnCaseStudy.Enabled = true;
                    }
                    else
                    {
                        btnCaseStudy.Enabled = false;
                    }

                }
                else
                {
                    lnkColumn1.Text = "";
                    lnkColumn2.Text = "";
                    lnkAssign.Enabled = false;
                    lnkProject.Enabled = false;
                    lnkDiscussion.Enabled = false;
                    lnkExam.Enabled = false;
                    btnCaseStudy.Enabled = false;
                }
            }
            if (CourseId == 1)
            {
                lnkColumn1.Visible = false;
                lnkColumn2.Visible = false;
            }
            else
            {
                lnkColumn1.Visible = true;
                lnkColumn2.Visible = true;
            }

        }
        catch (Exception EX)
        {
        }

    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageStudentInfo.aspx");
    }

    protected void bindDataSem()
    {
       
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        LIBExam objLibExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLibExam.CourseId = CourseId;

        tp.MessagePacket = (object)objLibExam;

        hdncoursecode.Value = objDalExam.GetCourseCodeByID(tp);

        // added by wahid

        try
        {
            DALExam OBJDALExam = new DALExam();
            //LIBExam objLibExam = new LIBExam();
            //TransportationPacket tp = new TransportationPacket();
            LIBExamListing objLIBExamListing = new LIBExamListing();
            objLibExam.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
            tp.MessagePacket = (object)objLibExam;
            tp = OBJDALExam.GetEvaluationCriteria(tp);
            objLIBExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLIBExamListing != null)
            {
                if (objLIBExamListing.Count > 0)
                {
                    lnkColumn1.Text = objLIBExamListing[0].ColumnName1;
                    lnkColumn2.Text = objLIBExamListing[0].ColumnName2;
                    if (objLIBExamListing[0].AssignmentMarks == true)
                    {
                        lnkAssign.Enabled = true;

                    }
                    else
                    {
                        lnkAssign.Enabled = false;
                    }

                    if (objLIBExamListing[0].ExamMarks == true)
                    {
                        lnkExam.Enabled = true;

                    }
                    else
                    {
                        lnkExam.Enabled = false;
                    }
                    if (objLIBExamListing[0].DiscussionForumMarks == true)
                    {

                        lnkDiscussion.Enabled = true;
                    }
                    else
                    {
                        lnkDiscussion.Enabled = false;
                    }
                    if (objLIBExamListing[0].ProjectMarks == true)
                    {
                        lnkProject.Enabled = true;
                    }
                    else
                    {
                        lnkProject.Enabled = false;
                    }

                    if (objLIBExamListing[0].CaseStudyMarks == true)
                    {
                        btnCaseStudy.Enabled = true;

                    }
                    else
                    {
                        btnCaseStudy.Enabled = false;
                    }

                }
                else
                {
                    lnkColumn1.Text = "";
                    lnkColumn2.Text = "";
                    lnkAssign.Enabled = false;
                    lnkProject.Enabled = false;
                    lnkDiscussion.Enabled = false;
                    btnCaseStudy.Enabled = false;
                    lnkExam.Enabled = false;
                }
            }

        }
        catch (Exception EX)
        {
        }

    }
}
