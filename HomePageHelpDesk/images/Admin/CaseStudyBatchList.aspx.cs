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

public partial class Admin_CaseStudyBatchList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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

            if (!Page.IsPostBack)
            {
                BindCorseDropDown();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
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
    public void bindgrid1()
    {
        try
        {
            string strq = "select b.bid as BatchId,b.courseID,c.CourseTitle,b.BatchCode as BatchTitle from batch b INNER JOIN course c on b.courseID=c.CourseID order by b.bid desc";

            DALAssignment objDalAssignment = new DALAssignment();

            DataTable tbl = new DataTable();
            tbl = objDalAssignment.getdata(strq);


            if (tbl.Rows != null)
            {

                GrdBatch.DataSource = tbl.DefaultView;
                GrdBatch.DataBind();
                GrdBatch.Visible = true;
                // added by chhaya for adding batch filter
                trbatch.Visible = true;
                ddlbatch.DataSource = tbl.DefaultView;
                ddlbatch.DataTextField = "BatchCode";
                ddlbatch.DataValueField = "bid";
                ddlbatch.DataBind();
                ddlbatch.Items.Insert(0, "SELECT");
                if (tbl.Rows.Count > 0)
                {
                    lblMessage.Text = "No batch is created for this course";
                    GrdBatch.Visible = false;
                }

            }


        }
        catch (Exception ex)
        {
        }
    }



    protected void BindBatchList()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetSubmitedAssignmentBatchList(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            GrdBatch.DataSource = objLibAssignmentListing;
            GrdBatch.DataBind();

            ddlbatch.DataSource = objLibAssignmentListing;
            ddlbatch.DataTextField = "BatchTitle";
            ddlbatch.DataValueField = "BatchId";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "SELECT");

            if (objLibAssignmentListing.Count == 0)
            {
                lblMessage.Text = "No batch is created for this course";
                GrdBatch.Visible = false;
            }
            else
            {
                GrdBatch.Visible = true;
                lblMessage.Text = "";
            }



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Course'); </script>");
            return;
        }
        BindBatchList();
    }
    protected void GrdBatch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdBatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("CaseStudyPanel.aspx");
    }
    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindbatchgrid();
    }
    public void bindbatchgrid()
    {
        try
        {
            //If ddlCourse.SelectedItem.Text = "SELECT" Then
            // lblMessage.Text = "Please select course"
            // bindgrid1()
            // Exit Sub
            //End If
            if (ddlbatch.SelectedItem.Text == "SELECT")
            {
                // lblMessage.Text = "Please select Batch"
                BindBatchList();
                return;
            }
            string strq = "select b.bid as batchid ,b.courseID,c.CourseTitle,b.BatchCode as batchtitle from batch b INNER JOIN course c on b.courseID=c.CourseID where b.bid=" + ddlbatch.SelectedValue + " order by b.bid desc";
            DataSet dsbatch = new DataSet();
            dsbatch = CLS.fnQuerySelectDs(strq);
            if (dsbatch != null)
            {
                if (dsbatch.Tables != null)
                {
                    if (dsbatch.Tables[0].Rows != null)
                    {
                        if (dsbatch.Tables[0].Rows.Count > 0)
                        {
                            GrdBatch.DataSource = dsbatch;
                            GrdBatch.DataBind();

                            GrdBatch.Visible = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}
