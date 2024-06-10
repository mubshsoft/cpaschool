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
public partial class Student_CaseStudyDownload : System.Web.UI.Page
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
                string type;
                if(Request.QueryString["type"].ToString()!=null)
                {
                    type = Request.QueryString["type"].ToString();
                    if(type== "Online")
                    {
                        tblonlie.Visible = true;
                        tbloffline.Visible = false;
                    }
                    else
                    {
                        tblonlie.Visible = false ;
                        tbloffline.Visible = true; 
                    }
                }
                hdnAsgnId.Value = Request.QueryString["CSId"].ToString();
                BindCaseStudy();
                BindCaseStudyAnswers();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindCaseStudy()
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(Request.QueryString["CSId"]);

            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetCaseStudyInstruction(tp);

            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblcaseStudy.Text = objLibAssignmentListing[0].CaseStudyText;
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindCaseStudyAnswers()
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(Request.QueryString["CSId"]);
            objLIBAssignment.UserId = Session["username"].ToString();

            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetCaseStudyAnswers(tp);

            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    txtCasestudy.Text = objLibAssignmentListing[0].AnsText;
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void lnkbtndownload_Click1(object sender, EventArgs e)
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

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            if (string.IsNullOrEmpty(txtCasestudy.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Your Answer');", true);

                return;
            }


            int addResult = 0;

            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.UserId = Session["username"].ToString();
            objLIBAssignment.AnsText = txtCasestudy.Text;
            objLIBAssignment.UploadAnsPath = "";

            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.AddUpdateOnlineCaseStudyAnswers(tp);

            if (addResult > 0)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully'); location.href='StudentPanel.aspx';", true);

                txtCasestudy.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Case Study Set');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Save Case Study Set');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        string CSID = hdnAsgnId.Value;
        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>openPopup('SubmitOfflineCaseStudy.aspx?CSId=" + CSID + "'); </script>");
        //Response.Write("javascript:openPopup('SubmitManualAssignment.aspx?Courseid=" + AsgnId + "')");
    }
}
