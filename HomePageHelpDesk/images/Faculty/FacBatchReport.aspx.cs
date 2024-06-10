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

public partial class Fac_BatchReport : System.Web.UI.Page
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
                
                BindBatch();
                lbldate.Visible = false;
                lblshowdate.Visible = false;
                lblBatchCode.Visible = false;
                lblBatch1.Visible = false;
               
            }
                                           
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

            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetBatchforReport(tp);        
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlbatch.DataSource = objLibExamListing;
            ddlbatch.DataTextField = "BatchTitle";
            ddlbatch.DataValueField = "BatchId";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "--Select Batch--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    


    public void BindGrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);
            objLIBExam.Category = Convert.ToString(ddlCategory.SelectedValue);
            objLIBExam.Gender = Convert.ToString(ddlGender.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetBatchReportData(tp);
            grdBatchDetails.DataSource = ds;
            grdBatchDetails.DataBind();
           
            



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

           
        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        
      
    }






    //protected void grdBatchDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        grdBatchDetails.PageIndex = e.NewPageIndex;
    //        BindGrid1();
    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}



    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportToExcel("FacultySubjectAssignReportList.xls", grdBatchDetails);
    }
    protected void btnExportToWord_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportToWord("FacultySubjectAssignReportList.doc", grdBatchDetails);
    }




    protected void grdBatchDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdBatchDetails.PageIndex = e.NewPageIndex;
            BindGrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
   
    protected void ImageButton3_Click(object sender, EventArgs e)
    {

        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        lbldate.Visible = true;
        BindGrid1();
        lblBatchCode.Text = Convert.ToString(ddlbatch.SelectedItem);

        //lblBatch.Visible = false;
        //ddlbatch.Visible = false;

        lbldate.Visible = true;
        lblshowdate.Visible = true;
        lblBatchCode.Visible = true;
        lblBatch1.Visible = true;

        lblGender.Visible = true;
        lblGender1.Visible = true;
       
        lblCategory.Visible = true;
        lblCategory1.Visible = true;

        lblGender1.Text = Convert.ToString(ddlGender.SelectedItem);
        lblCategory1.Text = Convert.ToString(ddlCategory.SelectedItem);
        



        lblshowdate.Text = Convert.ToString(DateTime.Now.ToString());
    }
    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportPage.aspx");
    }
}
