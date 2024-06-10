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

public partial class Admin_StudentInstructionSummary : System.Web.UI.Page
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

        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.ExamId = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
        objLIBExam.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBExam.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBExam;
        addResult = objDalExam.AddUserInstruction(tp);

        if (addResult == 1)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");

            if (Request.QueryString.Count > 0)
            {
                try
                {
                    if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                    {
                        Response.Redirect("~/Admin/AddQuestion.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Admin/SelectSection.aspx?ExamID=" + Request.QueryString["ExamID"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Admin/SelectSection.aspx?ExamID=" + Request.QueryString["ExamID"].ToString());
                }


            }
        }
        else if (addResult == 2)
        {
            lblMessage.Text = "Instruction update successfully";
            Response.Redirect("SelectSection.aspx?ExamID=" + Request.QueryString["ExamID"].ToString());
        }

        else
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
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
                    Response.Redirect("SelectSection.aspx?ExamID=" + Request.QueryString["ExamID"].ToString());
                }
                else
                {
                    Response.Redirect("AddSectionQue.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1",false);     
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("SelectSection.aspx?ExamID=" + Request.QueryString["ExamID"].ToString());
            }
        }
    }

    protected void  getInstructionSummary()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.ExamId = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
            objLIBExam.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
            string st;
            st = objDalExam.GetInstruction(objLIBExam.ExamId, objLIBExam.CategoryID);
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

        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.ExamId = Convert.ToInt32(Request.QueryString["ExamID"].ToString());
        objLIBExam.CategoryID = Convert.ToInt32(Request.QueryString["sectionId"].ToString());
        objLIBExam.InstructionText = txtInstruction.Text;

        tp.MessagePacket = (object)objLIBExam;
        addResult = objDalExam.AddUserInstruction(tp);

        if (addResult>0)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Instruction saved successfully'); </script>");
            Response.Redirect("~/Admin/AddQuestion.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
        }
    }
}
