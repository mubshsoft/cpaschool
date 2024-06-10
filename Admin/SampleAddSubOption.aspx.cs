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
public partial class Admin_SampleAddSubOption : System.Web.UI.Page
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



        try
        {

            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    hdnQuestionID.Value = Request.QueryString["SubQuestionId"].ToString();
                    //hdnSampleId.Value= Request.QueryString["sid"].ToString();
                    BindQuestionOptionList();
                    BindQuestionBySubQuestionId();
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

    protected void BindQuestionBySubQuestionId()
    {
        try
        {
            string question = "";
            LIBSample objLIBSample = new LIBSample();
            DALSample objDALSample = new DALSample();
            LIBSampleListing objLIBSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SubQuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBSample;

            tp = objDALSample.GetSampleQuestionBySubQuestionId(tp);
            objLIBSampleListing = (LIBSampleListing)tp.MessageResultset;
            lblQuestion.Text = objLIBSampleListing[0].Question;
            lblanswer.Text = objLIBSampleListing[0].AnsText; 

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            int addResult = 0;
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTIONTYPE = Utility.CheckNullString(ddlOptionType.SelectedItem.Text);
            objLibSample.OPTIONS = Utility.CheckNullString(txtoption.Text);
            objLibSample.SubQuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSubQuestionOption(tp);

            if (addResult > 0)
            {
               ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question Option Saved Successfully');", true);
                txtoption.Text = "";
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTID = Convert.ToInt32(hdnOptId);
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.DeleteSubQuestionOption(tp);

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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.OPTID = Convert.ToInt32(hdnOptId);
            objLibSample.OPTIONS = (txtOption.Text);
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSubQuestionOption(tp);

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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SubQuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            tp.MessagePacket = (object)objLIBSample;

            tp = objDalSample.GetSubQuestionOptionList(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            gvQuestionOptionList.DataSource = objLibSampleListing;
            gvQuestionOptionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
         int addresult = CheckQuestionAnswer();
        if (addresult == 1)
        {
            Response.Redirect("SampleAddSubQuestion.aspx?QuestionId=" + Request.QueryString["QuestionId"] + "&sid=" + Request.QueryString["sid"] + "&sectionName=" + Request.QueryString["sectionName"] + "&sectionId=" + Request.QueryString["sectionId"] + "&Type=" + Request.QueryString["Type"]);
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SubQuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionID.Value));
            objLIBSample.AnsText = lblanswer.Text;
            tp.MessagePacket = (object)objLIBSample;

            addresult = objDalSample.CheckQuestionSubOptionAns(tp);


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
