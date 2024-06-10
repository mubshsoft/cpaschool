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

public partial class Admin_SuccessfullyCompletedCourseReport : System.Web.UI.Page
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


    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "--Select--")
        {
            return;
        }
        BindBatch();
   
    }



    

  

    
   


    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCourse.SelectedItem.Text == "--Select--")
        //{
        //    return;
        //}

        //BindSemester();
    }




    protected void BindStudent()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            if (ddlbatch.SelectedIndex == 0)
            {
                objLIBExam.BatchId = 0;
            }
            else
            {
                objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);

            }
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetSuccessfullyCompleteCourse(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();
            ImageButton1.Visible = true;



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }






  
    protected void ImageButton3_Click(object sender, EventArgs e)
    {

        lblCourse1.Visible = true;
        lblCourseTitle1.Visible = true;

        lbldate.Visible = true;
        lblShowDate.Visible = true;

        lblBatch1.Visible = true;
        lblBatchTitle.Visible = true;

    

        lblCourseTitle1.Text = Convert.ToString(ddlCourse.SelectedItem);
     
        lblBatchTitle.Text = Convert.ToString(ddlbatch.SelectedItem);
        lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
        BindStudent();
    }
    protected void grdStudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdStudentDetails.PageIndex = e.NewPageIndex;
            BindStudent();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
}





