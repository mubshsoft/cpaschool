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

public partial class ActiveExamReport : System.Web.UI.Page
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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourse(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = courseid;
            tp.MessagePacket = (object)objLIBExam;
           DataSet ds = objDalExam.GetBatchByCourseId(tp);
            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlbatch.DataSource = ds;
            ddlbatch.DataTextField = "batchcode";
            ddlbatch.DataValueField = "bid";
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
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = courseid;
            objLIBExam.BatchId = bid;
            objLIBExam.FromDate = frmdt; 
            objLIBExam.ToDate = todt;

            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportActivateExam(tp);
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
    protected void ImageButton3_Click(object sender, EventArgs e)
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
        ImageButton1.Visible = true;


    }
}
