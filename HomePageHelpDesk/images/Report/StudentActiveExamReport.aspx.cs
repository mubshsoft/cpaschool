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

public partial class StudentActiveExamReport : System.Web.UI.Page
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

                BindExamDropDown();
                ddlbatch.Items.Insert(0, "-Select-");
            }


        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        
    }


    protected void BindExamDropDown()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetExamSetList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlExam.DataSource = objLibExamListing;
            ddlExam.DataTextField = "ExamCode";
            ddlExam.DataValueField = "Examid";
            ddlExam.DataBind();
            ddlExam.Items.Insert(0, "-Select-");

           


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
           
            if (ddlExam.SelectedItem.Text == "-Select-")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Exam'); </script>");
                return;
            }
            int examid = Convert.ToInt32(ddlExam.SelectedValue);
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            tp.MessagePacket = (object)objLIBExam;
           DataSet ds = objDalExam.GetBatchByExamId(tp);
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

            int examid = 0;
            if (ddlExam.SelectedItem.Text != "-Select-")
            {
                examid = Convert.ToInt32(ddlExam.SelectedValue);
            }
            int bid = 0;
            if (ddlbatch.SelectedItem.Text != "-Select-")
            {
                bid = Convert.ToInt32(ddlbatch.SelectedValue);
            }
            string activate = ddlstatus.SelectedValue.ToString();

           
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            objLIBExam.BatchId = bid;
            objLIBExam.Activate = activate; 
           
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentActivateExam(tp);
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












    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
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
        if (ddlExam.SelectedItem.Text == "-Select-")
        {
            lblexam.Text = "All Exam Set";
        }
        else
        {
            lblexam.Text = ddlExam.SelectedItem.Text;
        }

        if (ddlbatch.SelectedItem.Text == "-Select-")
        {
            lblbatch.Text = "All Batch";
        }
        else
        {
            lblbatch.Text = ddlbatch.SelectedItem.Text;
        }



        BindGrid();
    }
}
