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
using System.IO;

public partial class Admin_CaseStudyFinalAnswerSheet : System.Web.UI.Page
{
    int NOS = 0;
    string strHeading = "";
    int totalObjectiveMarks = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../login.aspx");

            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CaseStudyType"] != null)
                {
                    trtimeAllotted.Visible = false;
                    trtimeTaken.Visible = false;
                    trDateofassignment.Visible = false;
                    trSummary.Visible = false;
                    trGrandTotal.Visible = false;
                    trAnswerSheet.Visible = false;
                    trManualMarks.Visible = true;
                    if (Request.QueryString["CaseStudyType"].ToString() == "Manual" || Request.QueryString["CaseStudyType"].ToString() == "Download")
                    {

                        String strManual;
                        strManual = "select TotalMarks,Feedback,FacultyName=(select email from FacultyRegistration where fid=CaseStudyManualFinalMarks.fid) from CaseStudyManualFinalMarks where CSId=" + Request.QueryString["CSId"].ToString() + " And Userid='" + Request.QueryString["uid"].ToString() + "'";
                        DataSet dsManual = new DataSet();
                        dsManual = CLS_C.fnQuerySelectDs(strManual);

                        if (dsManual.Tables[0].Rows.Count > 0)
                        {
                            txtManualAssignmentMarks.Text = dsManual.Tables[0].Rows[0]["TotalMarks"].ToString();
                            txtManualFeedback.Text = dsManual.Tables[0].Rows[0]["Feedback"].ToString();
                            lblFaculty.Text = dsManual.Tables[0].Rows[0]["FacultyName"].ToString();
                            txtManualAssignmentMarks.Enabled = false;
                            txtManualFeedback.Enabled = false;
                            btnAddMarks.Visible = false;
                        }

                    }
                    else
                    {
                        String strOnline;
                        strOnline = "select TotalMarks,Feedback,FacultyName=(select email from FacultyRegistration where fid=CaseStudyFinalMarks.fid) from CaseStudyFinalMarks where CSId=" + Request.QueryString["CSId"].ToString() + " And Userid='" + Request.QueryString["uid"].ToString() + "'";
                        DataSet dsOnline = new DataSet();
                        dsOnline = CLS_C.fnQuerySelectDs(strOnline);

                        if (dsOnline.Tables[0].Rows.Count > 0)
                        {
                            txtManualAssignmentMarks.Text = dsOnline.Tables[0].Rows[0]["TotalMarks"].ToString();
                            txtManualFeedback.Text = dsOnline.Tables[0].Rows[0]["Feedback"].ToString();
                            lblFaculty.Text= dsOnline.Tables[0].Rows[0]["FacultyName"].ToString();
                            txtManualAssignmentMarks.Enabled = false;
                            txtManualFeedback.Enabled = false;
                            btnAddMarks.Visible = false;
                        }
                    }
                }

                hdnAsgnId.Value = Request.QueryString["CSId"].ToString();
                BindInstructionList();
                hdnuserid.Value = Request.QueryString["uid"].ToString();

               
                //GetUserList();
               
                BindAssignmentDate();


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindInstructionList()
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(hdnAsgnId.Value.ToString());
            objLIBAssignment.StudentEmail = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetCaseStudyInstruction(tp);

            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblCourseName.Text = objLibAssignmentListing[0].CourseTitle;
                    lblCourseCode.Text = objLibAssignmentListing[0].CourseCode;
                    lblAssignmentCode.Text = objLibAssignmentListing[0].CSCode;
                    lblPaperName.Text = objLibAssignmentListing[0].PaperTitle;
                }
            }

            tp = objDalAssignment.GetStudenInfo(tp);

            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                try
                {
                    if (objLibAssignmentListing.Count > 0)
                    {
                        DataTable dtEx = new DataTable();
                        dtEx = objDalAssignment.getdata("select refrenceid from studentregcourse where stid=" + objLibAssignmentListing[0].Stid.ToString() + " and courseid in(select courseid from CaseStudyset where CSId=" + Convert.ToInt32(hdnAsgnId.Value.ToString()) + ")");
                        lblStid.Text = dtEx.Rows[0]["refrenceid"].ToString();

                        //lblStid.Text = objLibAssignmentListing[0].Stid.ToString();
                        //lblStudentName.Text = objLibAssignmentListing[0].StudentName;

                    }
                }
                catch (Exception ex)
                { }
            }
            DataTable dt = new DataTable();
            dt = objDalAssignment.getdata("select TimeAllowted from CaseStudySet where CSId=" + Request.QueryString["CSid"].ToString());
            lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString()) / 60).ToString() + " min";


            DataTable dt1 = new DataTable();
            dt1 = objDalAssignment.getdata("select firstname + ' ' + lastname as name from student where email='" + Request.QueryString["uid"].ToString() + "'");
            lblStudentName.Text = dt1.Rows[0]["name"].ToString();

            DataTable dt3 = new DataTable();
            dt3 = objDalAssignment.getdata("select ActivateDate,EndAssignmenttime from studentActiveCaseStudy where CSId=" + Request.QueryString["CSId"].ToString() + " and  UserId='" + Request.QueryString["uid"].ToString() + "'");
            DateTime date1;
            DateTime date2;
            date1 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            string st = dt3.Rows[0]["EndAssignmenttime"].ToString();
            try
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["EndAssignmenttime"]);

            }
            catch (Exception ex)
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            }

            TimeSpan difference = date2.Subtract(date1);

            double totalSeconds = difference.Seconds;
            double totalMinuts = difference.Minutes;
            lblTimeTaken.Text = totalMinuts.ToString() + ":" + totalSeconds.ToString() + " min";



            //lblDate.Text = DateTime.Now.ToShortDateString();
            DataSet ds = new DataSet();
           // ds = objDalAssignment.GetInstructionSummary(tp);

            
            //dlstInstructionSummary.DataSource = ds;
            //dlstInstructionSummary.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindAssignmentDate()
    {
        try
        {
            LIBCaseStudy objLIBExam = new LIBCaseStudy();
            DALCaseStudy objDalExam = new DALCaseStudy();
            LIBCaseStudyListing objLibExamListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CSId = Convert.ToInt32(hdnAsgnId.Value.ToString());
            objLIBExam.UserId = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetCaseStudyDate(tp);

            objLibExamListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibExamListing != null)
            {
                if (objLibExamListing.Count > 0)
                {

                    lblDate.Text = Convert.ToString(objLibExamListing[0].activateDate);

                }
            }


        }



        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }





    protected void btnStartAssignment_Click(object sender, ImageClickEventArgs e)
    {
        int intAsgnId;
        try
        {
            intAsgnId = Convert.ToInt32(hdnAsgnId.Value);
            string strQAssignment;
            strQAssignment = "update studentActiveCaseStudy set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where CSId=" + intAsgnId + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQAssignment);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitAssignment.aspx?AsgnId=" + hdnAsgnId.Value + "&review=0");
    }
    protected void lnkbtnexport_Click(object sender, EventArgs e)
    {
        //Response.Clear();

        //Response.Buffer = true;

        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");

        //Response.Charset = "";
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-word ";

        //StringWriter sw = new StringWriter();

        //HtmlTextWriter hw = new HtmlTextWriter(sw);


        ////dlstanswers.DataBind();

        //dlstanswers.RenderControl(hw);
        ////LstUserAssignmentinfo.RenderControl(hw) 
        //Response.Output.Write(sw.ToString());

        //Response.Flush();

        //Response.End(); 
    }

    
    
    private void export()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=AnswerSheet_" + Request.QueryString["uid"] + ".doc");

        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-word ";

        StringWriter stringWriter = new StringWriter();

        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        this.RenderControl(htmlTextWriter);

        Response.Write(stringWriter.ToString());
        Response.End();
    }

    protected void ImgBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacultyListAssignment.aspx");
    }



    protected void btnAddMarks_Click(object sender, EventArgs e)
    {
        try
        {


            LIBCaseStudy objLibAssignment = new LIBCaseStudy();
            DALCaseStudy OBJDALAssignment = new DALCaseStudy();
            TransportationPacket tp = new TransportationPacket();


            objLibAssignment.CSId = Convert.ToInt32(hdnAsgnId.Value);
            objLibAssignment.UserId = hdnuserid.Value;
            objLibAssignment.TotalMarks = Convert.ToInt32(txtManualAssignmentMarks.Text);
            objLibAssignment.Feedback = txtManualFeedback.Text;
            objLibAssignment.FacultyId = Convert.ToInt32(Session["fid"]);

            tp.MessagePacket = (object)objLibAssignment;
            int addResult = OBJDALAssignment.AddUpdateManualCaseStudyFinalMarks(tp);
            if (addResult == 1)
            {
                txtManualFeedback.Text = "";
                txtManualAssignmentMarks.Text = "";
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks Added Successfully'); </script>");

            }
        }
        catch (Exception ex)
        {

        }
    }
}
