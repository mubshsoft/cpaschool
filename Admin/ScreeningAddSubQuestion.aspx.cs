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
public partial class ScreeningAddSubQuestion : System.Web.UI.Page
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

                    hdnQuestionId.Value = Request.QueryString["QuestionId"].ToString();
                    hdnSectionId.Value = Request.QueryString["sid"].ToString();
                    hdnType.Value = Request.QueryString["Type"].ToString();
                    BindQuestionList();
                    //BindCategoryList();

                }


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }

    //protected void BindCategoryList()
    //{
    //    try
    //    {
    //        LIBCategory objLIBCategory = new LIBCategory();
    //        DALCategory objDalCategory = new DALCategory();
    //        LIBCategoryListing objLibCategoryListing = new LIBCategoryListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBCategory.ScreeningId = Convert.ToInt32(hdnScreeningId.Value);

    //        tp.MessagePacket = (object)objLIBCategory;

    //        tp = objDalCategory.GetAssignedCategoryList(tp);
    //        objLibCategoryListing = (LIBCategoryListing)tp.MessageResultset;
    //        ddlcategory.DataSource = objLibCategoryListing;
    //        ddlcategory.DataTextField = objLIBCategory.CatogeryDisplayText;
    //        ddlcategory.DataValueField = objLIBCategory.CategoryValueField;
    //        ddlcategory.DataBind();
    //        ddlcategory.Items.Insert(0, "-Select-");

    //        //for (int i = 0; i < objLibCategoryListing.Count; i++)
    //        //{
    //        //    if (Convert.ToBoolean(objLibCategoryListing[i].ScreeningId))
    //        //    {
    //        //        ddlcategory.Items[i].Selected = true;
    //        //    }
    //        //}



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                return;
            }
            

            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLibScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
            objLibScreening.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            objLibScreening.QuesNo = Utility.CheckNullString(txtquestionNo.Text);
            objLibScreening.Type = hdnType.Value;
           
            if (ddlQuestionType.SelectedIndex == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Question Type');", true);
                return;
            }
            else
            {
                objLibScreening.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective")
            {
                objLibScreening.Answer = txtAnswer.Text;
                objLibScreening.Descriptive = false;
            }
            else if (ddlQuestionType.SelectedItem.Text == "Descriptive")
            {
                objLibScreening.Descriptive = true;

            }
            else
            {

                objLibScreening.Descriptive = false;
            }
          
                  

            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateScreeningSubQuestion(tp);

            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question Saved Successfully');", true);
                txtQuestion.Text = "";
                txtquestionNo.Text = "";
                txtAnswer.Text = "";
                //ddlcategory.SelectedIndex = 0;
                BindQuestionList();

            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Question');", true);
            }

            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Screening Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Screening Question');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindQuestionList()
    {
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
            tp.MessagePacket = (object)objLIBScreening;
            tp = objDalScreening.GetSubQuestionList(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            gvQuestionList.DataSource = objLibScreeningListing;
            gvQuestionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    #region gvQuestionList Events
    protected void gvQuestionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnQuestionId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnQuestionId")).Value;

        try
        {
            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLibScreening.SubQuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibScreening;


            string strChk = "select ques.SubQuestionId from Screeningsubquestions ques INNER JOIN Screeningsubques_options opt on ques.SubQuestionId=opt.SubQuestionId where ques.SubQuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALScreening objDalScreening = new DALScreening();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalScreening.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Question has some options - can't be deleted'); </script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question has some options - can't be deleted');", true);
            
            }
            else
            {
                addResult = OBJDALScreening.DeleteScreeningSubQuestion(tp);
                if (addResult > 0)
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question  Deleted'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question  Deleted');", true);
                    BindQuestionList();
                }


                else
                {
                  //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Screening Question'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question has some options - cannot be delete');", true);
                }
            }
            //addResult = OBJDALScreening.DeleteScreeningSubQuestion(tp);

           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void gvQuestionList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvQuestionList.EditIndex = e.NewEditIndex;
        BindQuestionList();
    }
    protected void gvQuestionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuestionList.EditIndex = -1;
        BindQuestionList();

    }
    protected void gvQuestionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnDeleteQuestionId = ((HiddenField)gvQuestionList.Rows[e.RowIndex].FindControl("hdnDeleteQuestionId")).Value;
            TextBox txtQuestion = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtQuestion");
            TextBox txtQuestionNo = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtQuestionNo");
            TextBox txtAnswer = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtAnswer");
            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLibScreening.QuestionText = txtQuestion.Text;
            objLibScreening.SubQuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            objLibScreening.QuesNo = txtQuestionNo.Text;
            objLibScreening.Answer = txtAnswer.Text;
            objLibScreening.Type = hdnType.Value;
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateScreeningSubQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Screening Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Screening Question');", true);
            }

            else
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Screening Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Screening Question');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void gvQuestionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvQuestionList.PageIndex = e.NewPageIndex;
            BindQuestionList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    #endregion
    protected void gvQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnQUESTYPE = (HiddenField)e.Row.FindControl("hdnQUESTYPE");
                LinkButton valu = (LinkButton)e.Row.FindControl("linkAddOption");
                HiddenField hdnAddQuestionId = (HiddenField)e.Row.FindControl("hdnAddQuestionId");
                if (hdnQUESTYPE.Value == "Subjective")
                {
                    valu.Enabled = false;
                }
                Session["question"] = (Label)e.Row.FindControl("lblName");
                valu.PostBackUrl = "~/Admin/ScreeningAddSubOption.aspx?SubQuestionId=" + hdnAddQuestionId.Value + "&QuestionId=" + hdnQuestionId.Value + "&sid=" + Request.QueryString["sid"] + "&sectionName=" + Request.QueryString["sectionName"] + "&sectionId=" + Request.QueryString["sectionId"] + "&Type=" + Request.QueryString["Type"];
                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Question ? ') ");
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlQuestionType.SelectedItem.Text=="Subjective")
        {
            txtAnswer.Enabled = false;
        }
        else
        {
            txtAnswer.Enabled = true ;
        }
    }
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        string SectionId = Request.QueryString["sectionId"].ToString();
        string secName = Request.QueryString["sectionName"].ToString();
        Response.Redirect("ScreeningAddQuestion.aspx?ScrID=" + hdnSectionId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);

        //string secName = Request.QueryString["sectionName"].ToString();
       
        //Response.Redirect("AddQuestion.aspx?ScreeningID=" + hdnScreeningId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
    }
}
