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

public partial class StudentActiveExamDetailReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        lblcourse.Text = Convert.ToString(Request.QueryString["Course"]);
        lblBatch.Text = Convert.ToString(Request.QueryString["Batch"]);
        lblStudentName.Text = Convert.ToString(Request.QueryString["StudentName"]);

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
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
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
            if (!Page.IsPostBack)
            {

                BindGrid();
                BindLoginGrid();
                bindQuerygrid();
                BindTopic();
                bindStatus();
            }


        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        
    }





  
    protected void BindGrid()
    {
        try
        {              
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UserId = Convert.ToString(Request.QueryString["StudentEmail"]);
            objLIBExam.BatchId = Convert.ToInt32(Request.QueryString["BatchId"]);
            
           
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentActivateExamDetails(tp);
            grdReport.DataSource = ds;
            grdReport.DataBind();
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    


   
    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdReport.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindLoginGrid()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();

            objStudent.stid = Convert.ToInt32(Request.QueryString["StudentId"]);

            tp.MessagePacket = (object)objStudent;

            tp = objDalAddStudent_CS.GetActiveStudentLoginReport(tp);
            objStudentListing = (LIBStudentListing)tp.MessageResultset;

            GridLoginReport.DataSource = objStudentListing;
            GridLoginReport.DataBind();
          




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void GridLoginReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdReport.PageIndex = e.NewPageIndex;
            BindLoginGrid();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void bindQuerygrid()
    {
        try
        {
          
            LIBQueryDetails ObjLIBQueryDetails = new LIBQueryDetails();
            DALQueryDetails objDALQueryDetails = new DALQueryDetails();
            LIBQueryDetailsListing ObjLIBQueryDetailsListing = new LIBQueryDetailsListing();
            TransportationPacket tp = new TransportationPacket();
            ObjLIBQueryDetails.stid = Convert.ToInt32(Request.QueryString["StudentId"]);
            tp.MessagePacket = (object)ObjLIBQueryDetails;
            tp = objDALQueryDetails.GetNumberOfQueries(tp);
            ObjLIBQueryDetailsListing = (LIBQueryDetailsListing)tp.MessageResultset;
            grdQueryDetails.DataSource = ObjLIBQueryDetailsListing;
            grdQueryDetails.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void grdQueryDetails2_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnSubjectid = (HiddenField)e.Row.FindControl("hdnSubjectid");
                Label lbltotal = (Label)e.Row.FindControl("lbltotal");
                try
                {

                    LIBExam objLIBExam = new LIBExam();
                    DALExam objDalExam = new DALExam();
                    LIBExamListing objLibExamListing = new LIBExamListing();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBExam.SubjectId = Convert.ToInt32(hdnSubjectid.Value);
                    objLIBExam.StudentEmail = Convert.ToString(Request.QueryString["StudentEmail"]);
                    tp.MessagePacket = (object)objLIBExam;
                    int ds = objDalExam.CountStudenttotalsubtopic(tp);
                    lbltotal.Text = Convert.ToString(ds);

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
    protected void BindTopic()
    {
        try
        {

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(Request.QueryString["BatchId"]);
            objLIBExam.StudentEmail =Request.QueryString["StudentEmail"].ToString();
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentTopicDetails(tp);
            grdQueryDetails2.DataSource = ds;
            grdQueryDetails2.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void bindStatus()
    {
        try
        {

            LIBQueryDetails ObjLIBQueryDetails = new LIBQueryDetails();
            DALQueryDetails objDALQueryDetails = new DALQueryDetails();
            LIBQueryDetailsListing ObjLIBQueryDetailsListing = new LIBQueryDetailsListing();
            TransportationPacket tp = new TransportationPacket();
            ObjLIBQueryDetails.stid = Convert.ToInt32(Request.QueryString["StudentId"]);
            ObjLIBQueryDetails.Course = Convert.ToString(Request.QueryString["Course"]);
            tp.MessagePacket = (object)ObjLIBQueryDetails;
            tp = objDALQueryDetails.GetStatus(tp);
            ObjLIBQueryDetailsListing = (LIBQueryDetailsListing)tp.MessageResultset;
            grdStatus.DataSource = ObjLIBQueryDetailsListing;
            grdStatus.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }







}
