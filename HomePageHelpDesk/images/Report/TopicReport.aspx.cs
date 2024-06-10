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
using System.Text.RegularExpressions;

public partial class Admin_TopicReport : System.Web.UI.Page
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
                lblCourse.Visible = false;
               
                lblBatch.Visible = false;
                lblTopic.Visible = false;
                lbldate.Visible = false;
                lblSemester.Visible = false;

                lblCourseTitle.Visible = false;
                lblbatchTitle.Visible = false;
                lblTopicTitle.Visible = false;
                lblshowdate.Visible = false;
                lblSemesterTitle.Visible = false;


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

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "--Select--")
        {
            return;
        }
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
  
    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "--Select--")
        {
            return;
        }

        BindSemester();
    }

    protected void BindSemester()
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
            ds = objDalExam.GetSemesterByCourseId(tp);
            ddlSemester.DataSource = ds;
            ddlSemester.DataTextField = "SemesterTitle";
            ddlSemester.DataValueField = "SemId";
            ddlSemester.DataBind();

            ddlSemester.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "--Select--")
        {
            return;
        }

        if (ddlbatch.SelectedItem.Text == "--Select--")
        {
            return;
        }

        BindTopic();
    }
    
    protected void BindTopic()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.SemesterId = Convert.ToInt32(ddlSemester.SelectedValue);
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetTopicBySemId(tp);
            ddlTopic1.DataSource = ds;
            ddlTopic1.DataTextField = "Topic";
            ddlTopic1.DataValueField = "SubjectId";
            ddlTopic1.DataBind();

            ddlTopic1.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindTopicReport()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.SubjectId = Convert.ToInt32(ddlTopic1.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetTopicReportBySubjectId(tp);
            grdStudentDetails.DataSource = ds;
            grdStudentDetails.DataBind();

            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void grdStudentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            grdStudentDetails.PageIndex = e.NewPageIndex;
            BindTopicReport();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    
    protected void ddlTopic1_SelectedIndexChanged1(object sender, EventArgs e)
    {

        //if (ddlCourse.SelectedItem.Text == "--Select--")
        //{
        //    return;
        //}

        //if (ddlbatch.SelectedItem.Text == "--Select--")
        //{
        //    return;
        //}

        //if (ddlSemester.SelectedItem.Text == "--Select--")
        //{
        //    return;
        //}
        

    }
   
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        ddlbatch.Visible = true;
        ddlCourse.Visible = true;
        ddlSemester.Visible = true;
        ddlTopic1.Visible = true;

        

        lblCourse.Visible = true;
        lblBatch.Visible = true;
        lblTopic.Visible = true;
        lbldate.Visible = true;
        lblSemester.Visible = true;

        lblCourseTitle.Visible = true;
        lblbatchTitle.Visible = true;
        lblTopicTitle.Visible = true;
        lblshowdate.Visible = true;
        lblSemesterTitle.Visible = true;

        lblCourseTitle.Text = Convert.ToString(ddlCourse.SelectedItem);
        lblbatchTitle.Text = Convert.ToString(ddlbatch.SelectedItem);
        lblTopicTitle.Text = Convert.ToString(ddlTopic1.SelectedItem);
        lblshowdate.Text = Convert.ToString(DateTime.Now.ToString());
        lblSemesterTitle.Text = Convert.ToString(ddlSemester.SelectedItem);
        ImageButton1.Visible = true;
       

        BindTopicReport();

    }
    protected void grdStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label valu = (Label)e.Row.FindControl("lblPostReply");
                string data = valu.Text;
                data = data.Replace("dq$", "\"\"");
                data = data.Replace("com$", ",");
                data = data.Replace("qu$", "'");
                data = data.Replace("amp$", "&");


                valu.Text = data;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}

