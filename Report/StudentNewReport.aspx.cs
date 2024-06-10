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


public partial class Admin_StudentNewReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
            if (!Page.IsPostBack)
            {
                BindCourseList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void BindCourseList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetCourseList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = "CourseTitle";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }



    protected void bindgrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            string status = Convert.ToString(ddlApplicationStatus.SelectedValue);
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            objLIBExam.App_Status = status;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetStudentDataforReport1(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
        




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

        
    protected void grdStudentDetails_DataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


               HiddenField hdnAppId = (HiddenField)e.Row.FindControl("hdnAppId");
                                LinkButton l = (LinkButton)e.Row.FindControl("lnkdetails");
                l.PostBackUrl = "~/Report/StudentReportForm.aspx?AppId=" + hdnAppId.Value +
                                                                "&CourseTitle=" + ddlCourse.SelectedItem;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
  
  
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        if (ddlApplicationStatus.SelectedItem.Text == "--Select--")
        {
            return;
        }
        else
        {
            bindgrid1();
        }

         

        lblAppStatus.Visible = true;
        lblAppStatus1.Visible = true;

        lbldate.Visible = true;
        lblshowdate.Visible = true;

        lblCourseTitle.Visible = true;
        lblcourse1.Visible = true;

        lblAppStatus1.Text = Convert.ToString(ddlApplicationStatus.SelectedItem);
        lblCourseTitle.Text = Convert.ToString(ddlCourse.SelectedItem);
        lblshowdate.Text = Convert.ToString(DateTime.Now.ToString());
    }
    protected void grdStudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdStudentDetails.PageIndex = e.NewPageIndex;
            bindgrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
}