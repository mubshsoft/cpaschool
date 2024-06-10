using System;
using System.IO;
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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class DownLoadLectureContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["username"] == null)
        //{
        //    Response.Redirect("../Default.aspx");
        //}
        //else
        //{
           
        //        Response.Redirect("../login.aspx");
           
        //}


        try
        {
            
            if (!Page.IsPostBack)
            {

               
                BindPaperFileList();

               
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindPaperFileList()
    {
        try
        {
            int semid = Getcurrentsem();

            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.SemesterId = semid;
	    objLIBExam.stid = Convert.ToInt32(Request.QueryString["sid"]);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetPaperFileBySemId(tp);
            DataTable dt = ds.Tables[0].Clone();
            foreach (DataTable table in ds.Tables)
            {
                   foreach (DataRow dr in table.Rows)
                {

                    string path =Request.PhysicalApplicationPath+ dr["UploadFilePath"].ToString();

                    try
                    {
                        System.IO.FileInfo file = new System.IO.FileInfo(path);
                        if (file.Exists)
                        {
                            DataRow drNew = dt.NewRow();
                            drNew.ItemArray = dr.ItemArray;
                            dt.Rows.Add(drNew);
                            dt.AcceptChanges();
                        }
                    }
                    catch (Exception)
                    {
                    }

                    
                   
                    
                }
            }
            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdExamSet.DataSource = dt;
            grdExamSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected int Getcurrentsem()
    { 
        int semid = 0;
        try
        {
           

            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId =Convert.ToInt32(Request.QueryString["id"]);
            objLIBExam.Stid = Convert.ToInt32(Request.QueryString["sid"]);
            tp.MessagePacket = (object)objLIBExam;

            semid = objDalExam.GetCurrentSem(tp);

           

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return semid;

    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            //    LinkButton valu = (LinkButton)e.Row.FindControl("lnkDeleteExamSet");
            //    string path = valu.CommandArgument.ToString();
            //System.IO.FileInfo file = new System.IO.FileInfo(path);
           
            //if (file.Exists)
            //{
            //    valu.Visible = true;
            //}
            //else
            //{
            //    valu.Visible = false;
               
            //}


            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdExamSet.PageIndex = e.NewPageIndex;
        BindPaperFileList();
    }
    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            string path = Request.PhysicalApplicationPath + e.CommandArgument.ToString();
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('file does not exist'); history.go(-1)</script>");
            }
        }
    }
}
