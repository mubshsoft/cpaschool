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

public partial class Faculty_ProgressReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
        }
        else
        {

        }
        if (!Page.IsPostBack)
        {
            BindCorseDropDown();
            BindAssignment();
        }
    }

    protected void BindCorseDropDown()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetCourse(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibAssignmentListing;
            ddlCourse.DataTextField = objLIBAssignment.CourseDispalyText;
            ddlCourse.DataValueField = objLIBAssignment.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindAssignment()
    {
        try
        {
            string ss = Session["username"].ToString();
            int bid = 0;

            LIBExam objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBExamListing objLibAssignmentListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = ss;
            objLIBAssignment.BatchId = bid;


            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.GetListOfExamandAssignmentToFaculty(tp);
            ViewState["ds"] = ds;
            GrdExam.DataSource = ds;
            GrdExam.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ViewState["ds"] != null)
            {
                ds = (DataSet)ViewState["ds"];
                ds.Tables[0].DefaultView.RowFilter = "courseid = " + ddlCourse.SelectedValue;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();

                if (dt.Rows.Count > 0)
                {
                    ddlBatch.DataSource = dt.DefaultView.ToTable(true, "bid", "batchcode");
                    ddlBatch.DataTextField = "BatchCode";
                    ddlBatch.DataValueField = "bid";
                    ddlBatch.DataBind();
                    ddlBatch.Items.Insert(0, "SELECT");

                    GrdExam.DataSource = dt;
                    GrdExam.DataBind();
                    GrdExam.Visible = true;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Record Found.";
                    ddlBatch.Items.Clear();
                    GrdExam.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void GrdExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            if (ViewState["ds"] != null)
            {
                ds = (DataSet)ViewState["ds"];
                ds.Tables[0].DefaultView.RowFilter = "bid = " + ddlBatch.SelectedValue;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();

                if (dt.Rows.Count > 0)
                {
                  
                    GrdExam.DataSource = dt;
                    GrdExam.DataBind();
                    GrdExam.Visible = true;


                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Record Found.";
                    GrdExam.Visible = false;
                }

                GetUserList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void GetUserList()
    {
        if (ddlBatch.SelectedItem.Text == "-Select-")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select batch');", true);
            return;
        }

        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBExamListing objLibAssignmentListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.BatchId = Convert.ToInt32(ddlBatch.SelectedItem.Value);
            
            tp.MessagePacket = (object)objLIBAssignment;
            
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetProgressReports(tp);

            GrdUserList.DataSource = ds;
            GrdUserList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void GrdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUserList.PageIndex = e.NewPageIndex;
        GetUserList();
    }
    protected void GrdUserList_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


              //  LinkButton lnkbtntype = (LinkButton)e.Row.FindControl("lnkbtntype");

               
                HiddenField hdnUserID = (HiddenField)e.Row.FindControl("hdnUserID");


                //LinkButton lnkSubmitMarkformanual = (LinkButton)e.Row.FindControl("lnkSubmitMarkformanual");

                //lnkbtntype.Visible = true;
                //lnkbtntype.PostBackUrl = "~/Faculty/ExamInstruction.aspx?Exid=" + hdnExamId.Value + "&uid=" + hdnUserID.Value + "&Batchid=" + hdnBatchid.Value;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}