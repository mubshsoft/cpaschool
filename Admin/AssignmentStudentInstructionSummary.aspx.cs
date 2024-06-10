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

public partial class Admin_AssignmentStudentInstructionSummary : System.Web.UI.Page
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

        LIBAssignment objLIBAssignment = new LIBAssignment();
        DALAssignment objDalAssignment = new DALAssignment();
        TransportationPacket tp = new TransportationPacket();
        objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
        objLIBAssignment.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBAssignment.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBAssignment;
        addResult = objDalAssignment.AddUserInstruction(tp);

        if (addResult >0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");

            if (Request.QueryString.Count > 0)
            {
                try
                {
                    if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                    {
                        Response.Redirect("~/Admin/AssignmentAddQuestion.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Admin/AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Admin/AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString());
                }


            }
        }
         else
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Assignment Set'); </script>");
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
                    Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString());
                }
                else
                {
                    Response.Redirect("AssignmentAddSectionQue.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1", false);     
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString());
            }
        }
    }

    protected void  getInstructionSummary()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
            objLIBAssignment.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;
            string st;
            st = objDalAssignment.GetInstruction(tp);
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

        LIBAssignment objLIBAssignment = new LIBAssignment();
        DALAssignment objDalAssignment = new DALAssignment();
        TransportationPacket tp = new TransportationPacket();
        objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
        objLIBAssignment.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBAssignment.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBAssignment;
        addResult = objDalAssignment.AddUserInstruction(tp);

        if (addResult > 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");
            Response.Redirect("~/Admin/AssignmentAddQuestion.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save'); </script>");
        }
    }
}
