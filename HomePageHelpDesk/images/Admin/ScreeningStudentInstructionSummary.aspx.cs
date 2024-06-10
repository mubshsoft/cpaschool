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

public partial class Admin_ScreeningStudentInstructionSummary : System.Web.UI.Page
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

        LIBScreening objLIBScreening = new LIBScreening();
        DALScreening objDalScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLIBScreening.ScrId = Convert.ToInt32(Request.QueryString["ScrId"].ToString());
        objLIBScreening.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBScreening.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBScreening;
        addResult = objDalScreening.AddUserInstruction(tp);

        if (addResult >0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");

            if (Request.QueryString.Count > 0)
            {
                try
                {
                    if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                    {
                        Response.Redirect("~/Admin/ScreeningAddQuestion.aspx?ScrId=" + Request.QueryString["ScrId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Admin/ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Admin/ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString());
                }


            }
        }
         else
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Screening Set'); </script>");
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
                    Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString());
                }
                else
                {
                    Response.Redirect("ScreeningAddSectionQue.aspx?ScrId=" + Request.QueryString["ScrId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1", false);     
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString());
            }
        }
    }

    protected void  getInstructionSummary()
    {
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(Request.QueryString["ScrId"].ToString());
            objLIBScreening.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
            tp.MessagePacket = (object)objLIBScreening;
            string st;
            st = objDalScreening.GetInstruction(tp);
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

        LIBScreening objLIBScreening = new LIBScreening();
        DALScreening objDalScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLIBScreening.ScrId = Convert.ToInt32(Request.QueryString["ScrId"].ToString());
        objLIBScreening.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBScreening.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBScreening;
        addResult = objDalScreening.AddUserInstruction(tp);

        if (addResult > 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");
            Response.Redirect("~/Admin/ScreeningAddQuestion.aspx?ScrId=" + Request.QueryString["ScrId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save'); </script>");
        }
    }
}
