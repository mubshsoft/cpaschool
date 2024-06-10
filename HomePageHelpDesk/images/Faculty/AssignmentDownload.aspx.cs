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
public partial class Faculty_AssignmentDownload : System.Web.UI.Page
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
                hdnAsgnId.Value = Request.QueryString["AsgnId"].ToString();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void lnkbtnAssignment_Click(object sender, EventArgs e)
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;

            string filename = objDalAssignment.GetAssignmentPathByAsgnId(tp);

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
    protected void lnkbtnSubmitted_Click(object sender, EventArgs e)
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
            objLIBAssignment.UserId = Request.QueryString["uid"].ToString();
            tp.MessagePacket = (object)objLIBAssignment;

            string filename = objDalAssignment.GetAssignmentAnswerByAsgnId(tp);

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