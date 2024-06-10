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
public partial class Admin_SampleAddOption : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
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
                    hdnSamId.Value= Request.QueryString["sid"].ToString();
                    BindQuestionByQuestionId();
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Please select Option type');", true);
                return;
            }

            int addResult = 0;
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTIONTYPE = Utility.CheckNullString(ddlOptionType.SelectedItem.Text);
            objLibSample.OPTIONS = Utility.CheckNullString(txtoption.Text);
            objLibSample.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateQuestionOption(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Option Saved Successfully');", true);
               
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question Option');", true);
               

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Question Option');", true);
               
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTID = Convert.ToInt32(hdnOptId);
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.DeleteQuestionOption(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Question Option  Deleted');", true);
                
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Question Option');", true);
             

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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTID = Convert.ToInt32(hdnOptId);
            objLibSample.OPTIONS = (txtOption.Text);
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateQuestionOption(tp);

            if (addResult > 0)
            {
                gvQuestionOptionList.EditIndex = -1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Option Updated');", true);
               
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Option');", true);
               

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Option');", true);
                

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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBSample;

            tp = objDalSample.GetQuestionOptionList(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            gvQuestionOptionList.DataSource = objLibSampleListing;
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDALSample = new DALSample();
            LIBSampleListing objLIBSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBSample;

            tp = objDALSample.GetSampleQuestionByQuestionId(tp);
            objLIBSampleListing = (LIBSampleListing)tp.MessageResultset;
            lblQuestion.Text = objLIBSampleListing[0].Question;
            lblanswer.Text = objLIBSampleListing[0].AnsText; 

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
         int addresult = CheckQuestionAnswer();
        if (addresult == 1)
        {
        string secName = Request.QueryString["sectionName"].ToString();
        string SectionId = Request.QueryString["sectionId"].ToString();
        Response.Redirect("SampleAddQuestion.aspx?SamId=" + hdnSamId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "<SCRIPT LANGUAGE='javascript'>alert('Please Add  Answer Option !');", true);

        }

     }
    protected int CheckQuestionAnswer()
    {
        int addresult = 0;
        try
        {

            string question = "";
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            objLIBSample.AnsText = lblanswer.Text;
            tp.MessagePacket = (object)objLIBSample;

            addresult = objDalSample.CheckQuestionOptionAns(tp);


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return addresult;
    }
    protected void lnkbtnans_Click(object sender, EventArgs e)
    {
        txtoption.Text = lblanswer.Text;
    }
}
