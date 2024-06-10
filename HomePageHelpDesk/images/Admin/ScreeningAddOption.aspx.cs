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
public partial class Admin_ScreeningAddOption : System.Web.UI.Page
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
                    hdnScrId.Value= Request.QueryString["sid"].ToString();
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
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please select Option type');", true);
                return;
            }

            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLibScreening.OPTIONTYPE = Utility.CheckNullString(ddlOptionType.SelectedItem.Text);
            objLibScreening.OPTIONS = Utility.CheckNullString(txtoption.Text);
            objLibScreening.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateQuestionOption(tp);

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
               

            }

            else
            {
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Question Option');", true);
               
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
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLibScreening.OPTID = Convert.ToInt32(hdnOptId);
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.DeleteQuestionOption(tp);

            if (addResult > 0)
            {
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question Option  Deleted');", true);
                
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
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLibScreening.OPTID = Convert.ToInt32(hdnOptId);
            objLibScreening.OPTIONS = (txtOption.Text);
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateQuestionOption(tp);

            if (addResult > 0)
            {
                gvQuestionOptionList.EditIndex = -1;
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Option Updated');", true);
               
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
               

            }

            else
            {
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Option');", true);
                

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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetQuestionOptionList(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            gvQuestionOptionList.DataSource = objLibScreeningListing;
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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetQuestionByQuestionId(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            lblQuestion.Text = objLibScreeningListing[0].Question;
            lblanswer.Text = objLibScreeningListing[0].AnsText; 


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
        Response.Redirect("ScreeningAddQuestion.aspx?ScrId=" + hdnScrId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
        }
        else
        {
           ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Add  Answer Option !');", true);

        }
    }
    protected int CheckQuestionAnswer()
    {
        int addresult = 0;
        try
        {

            string question = "";
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            objLIBScreening.AnsText = lblanswer.Text;
            tp.MessagePacket = (object)objLIBScreening;

            addresult = objDalScreening.CheckQuestionOptionAns(tp);


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
