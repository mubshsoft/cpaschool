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

public partial class ScreeningInstruction : System.Web.UI.Page
{
    protected string secText = null;
    protected DataSet dsInstruction;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Screeningusername"] == null)
        {
            Response.Redirect("../Screeninglogin.aspx");
        }
        try
        {
            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("../login.aspx");

            //}
            if (!Page.IsPostBack)
            {


                hdnScrId.Value = Request.QueryString["ScrId"].ToString();
                Session["paperTitle"] = Request.QueryString["paper"].ToString();
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
    //        objLIBExam.ScrId = Convert.ToInt32(hdnScrId.Value.ToString());
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
    //        dt=objDalExam.getdata("select TimeAllowted from ExamSet where ScrId="+ Request.QueryString["ScrId"].ToString());
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


   
    
    protected void btnStartScreening_Click(object sender, ImageClickEventArgs e)
    {
        int intScrId;
        try
        {
            intScrId = Convert.ToInt32(hdnScrId.Value);
            string strQExam;
            
         
            strQExam = "update studentActiveScreening set Activate=1,ActivateDate='" + DateTime.Now.ToString() + "' where ScrId=" + intScrId + "and userid='" + Session["Screeningusername"] + "'";
            CLS_C.fnExecuteQuery(strQExam);

        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitOnlineScreening.aspx?ScrId=" + hdnScrId.Value + "&review=0");
    }
    protected void BindInstructiondata()
    {
        string strQ;
        strQ = "select instructionText from Screeningstudentinstruction where Scrid=" + Request.QueryString["Scrid"].ToString() + " and categoryid in (select min(categoryid) from Screening_category where Scrid=" + Request.QueryString["Scrid"].ToString() + ")";
        dsInstruction = CLS_C.fnQuerySelectDs(strQ);


    }
}
