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

public partial class SampleInstruction : System.Web.UI.Page
{
    protected string secText = null;
    protected DataSet dsInstruction;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("../login.aspx");

            //}
            if (!Page.IsPostBack)
            {
                hdnSamId.Value = Request.QueryString["SamId"].ToString();
               // Session["paperTitle"] = Request.QueryString["paper"].ToString();
             //   BindInstructionList();
                BindInstructiondata();

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    //protected void BindInstructionList()
    //{
    //    try
    //    {
    //        LIBExam objLIBExam = new LIBExam();
    //        DALExam objDalExam = new DALExam();
    //        LIBExamListing objLibExamListing = new LIBExamListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBExam.SamId = Convert.ToInt32(hdnSamId.Value.ToString());
    //        objLIBExam.StudentEmail = (Session["username"].ToString());
    //        tp.MessagePacket = (object)objLIBExam;

    //        tp = objDalExam.GetExamInstruction(tp);
            
    //        objLibExamListing = (LIBExamListing)tp.MessageResultset;

    //        if (objLibExamListing != null)
    //        {
    //            if (objLibExamListing.Count > 0)
    //            {
    //                lblCourseName.Text = objLibExamListing[0].CourseTitle;
    //                lblCourseCode.Text = objLibExamListing[0].CourseCode;
    //                lblExamCode.Text = objLibExamListing[0].examcode;
    //                lblPaperName.Text = objLibExamListing[0].PaperTitle;
    //            }
    //        }

    //        tp = objDalExam.GetStudenInfo(tp);

    //        objLibExamListing = (LIBExamListing)tp.MessageResultset;

    //        if (objLibExamListing != null)
    //        {
    //            if (objLibExamListing.Count > 0)
    //            {
    //                //lblStid.Text = objLibExamListing[0].Stid.ToString();
    //                //lblStudentName.Text = objLibExamListing[0].StudentName;
                    
    //            }
    //        }
    //        DataTable dt = new DataTable();
    //        dt=objDalExam.getdata("select TimeAllowted from ExamSet where SamId="+ Request.QueryString["SamId"].ToString());
    //        //lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString())/60).ToString() + " min";


    //        DataTable dt1 = new DataTable();
    //        dt1 = objDalExam.getdata("select firstname + ' ' + lastname as name from student where email='" + Session["username"].ToString() + "'");
    //        lblStudentName.Text = dt1.Rows[0]["name"].ToString();


    //        lblDate.Text = DateTime.Now.ToShortDateString();
    //        DataSet ds = new DataSet();
    //        ds = objDalExam.GetInstructionSummary(tp);

    //        //objLibExamListing = (LIBExamListing)tp.MessageResultset;
    //        dlstInstructionSummary.DataSource = ds;
    //        dlstInstructionSummary.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}


   
    protected void btnStartSample_Click1(object sender, EventArgs e)
    {
        int intSamId;
        try
        {
            intSamId = Convert.ToInt32(hdnSamId.Value);
            string strQExam;
            strQExam = "update studentActiveSample set Activate=1,ActivateDate='" + DateTime.Now.ToString() + "' where SamId=" + intSamId + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQExam);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitOnlineSample.aspx?SamId=" + hdnSamId.Value + "&review=0");
    }
    protected void BindInstructiondata()
    {
        string strQ;
        strQ = "select instructionText from Samplestudentinstruction where SamId=" + Request.QueryString["SamId"].ToString() + " and categoryid in (select min(categoryid) from Sample_category where SamId=" + Request.QueryString["SamId"].ToString() + ")";
        dsInstruction = CLS_C.fnQuerySelectDs(strQ);


    }
    
   
}
