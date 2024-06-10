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


public partial class Faculty_FacultyIntegratedReport : System.Web.UI.Page
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
            ddlCourse.Items.Insert(0, "--Select Course--");

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

            ddlbatch.Items.Insert(0, "--Select Batch--");

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

            ds = objDalExam.GetFacultyIntegratedReport(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;
            

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

            ds = objDalExam.GetFacultyIntegratedReportwithoutparameter(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

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
            objLIBExam.FacultyName = Convert.ToString(TextBox1.Text);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetfacultytReport4Search1(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;




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
            objLIBExam.FacultyEmail = Convert.ToString(TextBox1.Text);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetfacultytReport4Search2(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;




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

                HiddenField hdnFacultyid = (HiddenField)e.Row.FindControl("hdnFacultyid");
                LinkButton l = (LinkButton)e.Row.FindControl("lnkPdetails");
                l.PostBackUrl = "~/Report/FacultyCompleteFormReport.aspx?Fid=" + hdnFacultyid.Value;


                //HiddenField hdnFacultyid = (HiddenField)e.Row.FindControl("hdnFacultyid");
                HiddenField hdnCourseTitle = (HiddenField)e.Row.FindControl("hdnCourseTitle");
                HiddenField hdnBatch = (HiddenField)e.Row.FindControl("hdnBatch");
                HiddenField HiddenBatch = (HiddenField)e.Row.FindControl("HiddenBatch");
                HiddenField hdnFacultyName = (HiddenField)e.Row.FindControl("hdnFacultyName");

                               LinkButton l1 = (LinkButton)e.Row.FindControl("lnkdetails");
                //l1.PostBackUrl = "~/FacultyIntegratedReport1.aspx?Fid=" + hdnFacultyid.Value +
                //                                                "&Course=" + hdnCourseTitle.Value +
                //                                                "&Batch=" + hdnBatch.Value +
                //                                                "&FacultyName=" + hdnFacultyName.Value;


               l1.PostBackUrl = "~/Faculty/FacultyIntegratedReport1.aspx?Fid=" + hdnFacultyid.Value + "&Course=" + hdnCourseTitle.Value + "&Batch=" + HiddenBatch.Value + "&FacultyName=" + hdnFacultyName.Value; 
                                                                      
            }




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }



    }



    protected void ImageButton3_Click(object sender, EventArgs e)
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
    protected void ImageButton4_Click(object sender, EventArgs e)
    {
        bindgrid1();
    }
    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportPage.aspx");
    }
}
