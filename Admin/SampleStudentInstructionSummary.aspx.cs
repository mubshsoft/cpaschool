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
using System.Data.SqlClient;

public partial class Admin_SampleStudentInstructionSummary : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                try
                {
                    if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                    {
                        btnSave.Visible = false;
                        btnSaveContinue.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = true;
                        btnSaveContinue.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    btnSave.Visible = true;
                    btnSaveContinue.Visible = false;
                }
            }
           

            getInstructionSummary();
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(txtInstruction.Text))
        //{
        //    txtInstruction.Text = "";
        //    return;
        //}
        //else
        //{
        //    txtInstruction.Text = "";
        //}
        int addResult = 0;

        LIBSample objLIBSample = new LIBSample();
        DALSample objDalSample = new DALSample();
        TransportationPacket tp = new TransportationPacket();
        objLIBSample.SamId = Convert.ToInt32(Request.QueryString["SamId"].ToString());
        objLIBSample.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBSample.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBSample;
        addResult = objDalSample.AddUserInstruction(tp);

        if (addResult >0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");

            if (Request.QueryString.Count > 0)
            {
                try
                {
                    if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                    {
                        Response.Redirect("~/Admin/SampleAddQuestion.aspx?SamId=" + Request.QueryString["SamId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Admin/SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Admin/SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString());
                }


            }
        }
         else
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Sample Set'); </script>");
            lblMessage.Text = "Failed to Save instruction information";

        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            try
            {
                if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 2)
                {
                    Response.Redirect("SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString());
                }
                else
                {
                    Response.Redirect("SampleAddSectionQue.aspx?SamId=" + Request.QueryString["SamId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1", false);     
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString());
            }
        }
    }

    protected void  getInstructionSummary()
    {
        try
        {
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            objLIBSample.SamId = Convert.ToInt32(Request.QueryString["SamId"].ToString());
            objLIBSample.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
            tp.MessagePacket = (object)objLIBSample;
            string st;
            st = objDalSample.GetInstruction(tp);
           txtInstruction.Text = st;
         }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
        int addResult = 0;

        LIBSample objLIBSample = new LIBSample();
        DALSample objDalSample = new DALSample();
        TransportationPacket tp = new TransportationPacket();
        objLIBSample.SamId = Convert.ToInt32(Request.QueryString["SamId"].ToString());
        objLIBSample.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBSample.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBSample;
        addResult = objDalSample.AddUserInstruction(tp);

        if (addResult > 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");
            Response.Redirect("~/Admin/SampleAddQuestion.aspx?SamId=" + Request.QueryString["SamId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save'); </script>");
        }
    }
}
