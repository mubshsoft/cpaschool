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


public partial class Report_ActiveAssignmentReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

                BindCorseDropDown();
                ddlbatch.Items.Insert(0, "-Select-");
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
    
    protected void BindBatchDropDown()
    {
        try
        {

            if (ddlCourse.SelectedItem.Text == "-Select-")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
                return;
            }

            int courseid = Convert.ToInt32(ddlCourse.SelectedValue);
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.CourseId = courseid;
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetBatchByCourseid(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
                      
            ddlbatch.DataSource = objLibAssignmentListing;
            ddlbatch.DataTextField = "BatchTitle";
            ddlbatch.DataValueField = "BatchId";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "-Select-");




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

            int courseid = 0;
            if (ddlCourse.SelectedItem.Text != "-Select-")
            {
                courseid = Convert.ToInt32(ddlCourse.SelectedValue);
            }
            int bid = 0;
            if (ddlbatch.SelectedItem.Text != "-Select-")
            {
                bid = Convert.ToInt32(ddlbatch.SelectedValue);
            }
            string frmdt = txtfrmdt.Text;
            string todt = txttodt.Text;

            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.CourseId = courseid;
            objLIBAssignment.BatchId = bid;
            objLIBAssignment.FromDate = frmdt;
            objLIBAssignment.ToDate = todt;

            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.ReportActivateAssignment(tp);
            grdReport.DataSource = ds;
            grdReport.DataBind();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            print_grid.Visible = true;
                        }

                    }
                }
            }




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBatchDropDown();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            lblcourse.Text = "All Course";
        }
        else
        {
            lblcourse.Text = ddlCourse.SelectedItem.Text;
        }

        if (ddlbatch.SelectedItem.Text == "-Select-")
        {
            lblbatch.Text = "All Batch";
        }
        else
        {
            lblbatch.Text = ddlbatch.SelectedItem.Text;
        }

        lblactivatedt.Text = txtfrmdt.Text;
        lbltoactivatedt.Text = txttodt.Text;
        print_grid.Visible = true;
        BindGrid();
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

}
