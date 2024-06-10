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

public partial class AssignmentInstruction : System.Web.UI.Page
{
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
                hdnAsgnId.Value = Request.QueryString["AsgnId"].ToString();

                BindInstructionList();
               

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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value.ToString());
            objLIBAssignment.StudentEmail = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetAssignmentInstruction(tp);
            
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblCourseName.Text = objLibAssignmentListing[0].CourseTitle;
                    lblCourseCode.Text = objLibAssignmentListing[0].CourseCode;
                    lblAssignmentCode.Text = objLibAssignmentListing[0].Assignmentcode;
                    lblPaperName.Text = objLibAssignmentListing[0].PaperTitle;
                }
            }

            tp = objDalAssignment.GetStudenInfo(tp);

            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblStid.Text = objLibAssignmentListing[0].Stid.ToString();
                    //lblStudentName.Text = objLibAssignmentListing[0].StudentName;
                    
                }
            }
            DataTable dt = new DataTable();
            dt = objDalAssignment.getdata("select TimeAllowted from AssignmentSet where AsgnId=" + Request.QueryString["AsgnId"].ToString());
            lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString())/60).ToString() + " min";


            DataTable dt1 = new DataTable();
            dt1 = objDalAssignment.getdata("select firstname + ' ' + lastname as name from student where email='" + Request.QueryString["uid"].ToString() + "'");
            lblStudentName.Text = dt1.Rows[0]["name"].ToString();


            lblDate.Text = DateTime.Now.ToShortDateString();
            DataSet ds = new DataSet();
            ds = objDalAssignment.GetInstructionSummary(tp);

            //objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            dlstInstructionSummary.DataSource = ds;
            dlstInstructionSummary.DataBind();
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
            strQAssignment = "update studentActiveAssignment set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where AsgnId=" + intAsgnId + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQAssignment);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitAssignment.aspx?AsgnId=" + hdnAsgnId.Value + "&review=0");
    }
}

