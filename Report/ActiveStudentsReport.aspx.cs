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


public partial class Report_ActiveStudentsReport : System.Web.UI.Page
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
                bindgrid7();
               
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

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        BindBatch();
    }

    protected void BindBatch()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetBatchByCourseId(tp);
            ddlbatch.DataSource = ds;
            ddlbatch.DataTextField = "batchcode";
            ddlbatch.DataValueField = "bid";
            ddlbatch.DataBind();

            ddlbatch.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void bindgrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetActiveStudentReport(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
      




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void bindgrid7()
    {
        
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();


            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetActiveStudentReportwithoutparameter(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
      

    }
    

    
    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


  
    protected void bindgrid2()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.StudentName = Convert.ToString(TextBox1.Text);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetActiveStudentReport4Search1(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
      




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void bindgrid3()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.StudentEmail = Convert.ToString(TextBox1.Text);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetActiveStudentReport4Search2(tp);
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

                HiddenField hdnStudentId = (HiddenField)e.Row.FindControl("hdnStudentId");
                HiddenField hdnCourseTitle = (HiddenField)e.Row.FindControl("hdnCourseTitle");
                LinkButton l = (LinkButton)e.Row.FindControl("lnkPdetails");
                l.PostBackUrl = "~/Report/StudentReportForm.aspx?Stid=" + hdnStudentId.Value +
                                                                "&CourseTitle=" + hdnCourseTitle.Value +
                                                                "&PageName=" + "IntegratedReport";

         
                HiddenField hdnEmail = (HiddenField)e.Row.FindControl("hdnEmail");
                //HiddenField hdnCourseTitle = (HiddenField)e.Row.FindControl("hdnCourseTitle");
                HiddenField hdnBatch = (HiddenField)e.Row.FindControl("hdnBatch");
                HiddenField hdnBatchId = (HiddenField)e.Row.FindControl("hdnBatchId");
                HiddenField hdnStudentName = (HiddenField)e.Row.FindControl("hdnStudentName");
                LinkButton l1 = (LinkButton)e.Row.FindControl("lnkdetails");
                l1.PostBackUrl = "~/Report/StudentActiveExamDetailReport.aspx?StudentName=" + hdnStudentName.Value +
                                                                "&Course=" + hdnCourseTitle.Value +
                                                                "&Batch=" + hdnBatch.Value +
                                                                "&BatchId=" + hdnBatchId.Value +
                                                                "&StudentEmail=" + hdnEmail.Value +
                                                                "&StudentId=" + hdnStudentId.Value;

            }




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }



    }
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        bindgrid1();
    }
    protected void ImageButton4_Click(object sender, EventArgs e)
    {

        
        if (RadioButton1.Checked == true)
        {
            
            bindgrid2();
        }
        else if (RadioButton2.Checked == true)
        {
            
            bindgrid3();
        }

    }

   
}
