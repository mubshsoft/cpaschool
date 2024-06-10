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
public partial class AddOption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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

            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    hdnQuestionID.Value = Request.QueryString["QuestionId"].ToString();
                    hdnExamId.Value= Request.QueryString["sid"].ToString();
                   
                    BindQuestionOptionList();
                    BindQuestionByQuestionId();
                    int addresult1 = CheckQuestionAnswer();
                    if (addresult1 == 1)
                    {
                        lnkbtnans.Enabled = false;
                    }
                    else
                    {
                        lnkbtnans.Enabled = true;
                    }
                     
                }


            }

           
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlOptionType.SelectedItem.Text == "-Select-")
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please select Option type'); </script>");
                return;
            }

            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.OPTIONTYPE = Utility.CheckNullString(ddlOptionType.SelectedItem.Text);
            objLibExam.OPTIONS = Utility.CheckNullString(txtoption.Text);
            objLibExam.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateQuestionOption(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Option Saved Successfully');", true);
               
                BindQuestionOptionList();
                txtoption.Text = "";
                int addresult1 = CheckQuestionAnswer();
                if (addresult1 == 1)
                {
                    lnkbtnans.Enabled = false;
                }
                else
                {
                    lnkbtnans.Enabled = true;
                }


            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Question Option');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question Option'); </script>");
               

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Question Option');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Question Option'); </script>");
               
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    #region gvQuestionOptionList Events
    protected void gvQuestionOptionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnOptId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnOptId")).Value;


        try
        {
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.OPTID = Convert.ToInt32(hdnOptId);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.DeleteQuestionOption(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question Option  Deleted');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Question Option  Deleted'); </script>");
                
                BindQuestionOptionList();
                int addresult1 = CheckQuestionAnswer();
                if (addresult1 == 1)
                {
                    lnkbtnans.Enabled = false;
                }
                else
                {
                    lnkbtnans.Enabled = true;
                }

            }


            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Delete Question Option');", true);
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Question Option'); </script>");
             

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void gvQuestionOptionList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQuestionOptionList.EditIndex = e.NewEditIndex;
        BindQuestionOptionList();
    }
    protected void gvQuestionOptionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuestionOptionList.EditIndex = -1;
        BindQuestionOptionList();

    }
    protected void gvQuestionOptionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnOptId = ((HiddenField)gvQuestionOptionList.Rows[e.RowIndex].FindControl("hdnOptId")).Value;
            TextBox txtOption = (TextBox)gvQuestionOptionList.Rows[e.RowIndex].FindControl("txtOption");
            TextBox txtQuestionNo = (TextBox)gvQuestionOptionList.Rows[e.RowIndex].FindControl("txtQuestionNo");
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.OPTID = Convert.ToInt32(hdnOptId);
            objLibExam.OPTIONS = (txtOption.Text);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateQuestionOption(tp);

            if (addResult > 0)
            {
                gvQuestionOptionList.EditIndex = -1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Option Updated');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Option Updated'); </script>");
               
                BindQuestionOptionList();
                int addresult1 = CheckQuestionAnswer();
                if (addresult1 == 1)
                {
                    lnkbtnans.Enabled = false;
                }
                else
                {
                    lnkbtnans.Enabled = true;
                }

            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Option');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Option'); </script>");
               

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Option');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Option'); </script>");
                

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void gvQuestionOptionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvQuestionOptionList.PageIndex = e.NewPageIndex;


            BindQuestionOptionList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    #endregion


    protected void BindQuestionOptionList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetQuestionOptionList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            gvQuestionOptionList.DataSource = objLibExamListing;
            gvQuestionOptionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindQuestionByQuestionId()
    {
        try
        {
            string question = "";
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetQuestionByQuestionId(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            lblQuestion.Text = objLibExamListing[0].Question;
            lblanswer.Text = objLibExamListing[0].AnsText; 

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected int CheckQuestionAnswer()
    {
        int addresult = 0;
        try
        {
            
            string question = "";
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            objLIBExam.AnsText = lblanswer.Text;
            tp.MessagePacket = (object)objLIBExam;

            addresult = objDalExam.CheckQuestionOptionAns(tp);
            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return addresult;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        int addresult = CheckQuestionAnswer();
        if (addresult == 1)
        {
            string secName = Request.QueryString["sectionName"].ToString();
            string SectionId = Request.QueryString["sectionId"].ToString();
            Response.Redirect("AddQuestion.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Add  Answer Option !');", true);
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Add  Answer Option !'); </script>");

        }
    }
    protected void lnkbtnans_Click(object sender, EventArgs e)
    {
        txtoption.Text = lblanswer.Text;
    }
}
