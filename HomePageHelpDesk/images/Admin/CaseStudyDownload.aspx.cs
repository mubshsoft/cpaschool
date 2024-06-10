using System;
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
using fmsf.DAL;
using fmsf.lib;

public partial class Admin_CaseStudyDownload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../login.aspx");

            }
            if (!Page.IsPostBack)
            {
                hdnAsgnId.Value = Request.QueryString["CSId"].ToString();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void lnkbtndownloadOrg_Click(object sender, EventArgs e)
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(Request.QueryString["CSId"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;

            string filename = objDalAssignment.GetCaseStudyPathByCsId(tp);

            if (filename != "")
            {
                //string path = Path.Combine(Request.PhysicalApplicationPath, ExcelFolder);
                //path = Path.Combine(path, filename);
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
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
                    Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void lnkbtndownload_Click1(object sender, EventArgs e)
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(Request.QueryString["CSId"].ToString());
            objLIBAssignment.UserId = Request.QueryString["uid"].ToString();
            tp.MessagePacket = (object)objLIBAssignment;

            string filename = objDalAssignment.GetCaseStudyAnswerByCSId(tp);

            if (filename != "")
            {

                System.IO.FileInfo file = new System.IO.FileInfo(filename);
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
                    Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

}