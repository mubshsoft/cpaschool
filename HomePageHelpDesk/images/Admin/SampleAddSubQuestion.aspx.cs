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
public partial class SampleAddSubQuestion : System.Web.UI.Page
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
    //        objLIBCategory.SampleId = Convert.ToInt32(hdnSampleId.Value);

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
    //        //    if (Convert.ToBoolean(objLibCategoryListing[i].SampleId))
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLibSample.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
            objLibSample.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            objLibSample.QuesNo = Utility.CheckNullString(txtquestionNo.Text);
            objLibSample.Type = hdnType.Value;
           
            if (ddlQuestionType.SelectedIndex == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Question Type');", true);
                return;
            }
            else
            {
                objLibSample.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective")
            {
                objLibSample.Answer = txtAnswer.Text;
                objLibSample.Descriptive = false;
            }
            else if (ddlQuestionType.SelectedItem.Text == "Descriptive")
            {
                objLibSample.Descriptive = true;

            }
            else
            {

                objLibSample.Descriptive = false;
            }
          
                  

            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSampleSubQuestion(tp);

            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question Saved Successfully');", true);
                txtQuestion.Text = "";
                txtquestionNo.Text = "";
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
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Sample Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Sample Question');", true);
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
            tp.MessagePacket = (object)objLIBSample;
            tp = objDalSample.GetSubQuestionList(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            gvQuestionList.DataSource = objLibSampleListing;
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.SubQuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibSample;


            string strChk = "select ques.SubQuestionId from Samplesubquestions ques INNER JOIN Samplesubques_options opt on ques.SubQuestionId=opt.SubQuestionId where ques.SubQuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALSample objDalSample = new DALSample();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalSample.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Question has some options - can't be deleted'); </script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question has some options - can't be deleted');", true);
            
            }
            else
            {
                addResult = OBJDALSample.DeleteSampleSubQuestion(tp);
                if (addResult > 0)
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question  Deleted'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question  Deleted');", true);
                    BindQuestionList();
                }


                else
                {
                  //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Sample Question'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question has some options - cannot be delete');", true);
                }
            }
            //addResult = OBJDALSample.DeleteSampleSubQuestion(tp);

           
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLibSample.QuestionText = txtQuestion.Text;
            objLibSample.SubQuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            objLibSample.QuesNo = txtQuestionNo.Text;
            objLibSample.Answer = txtAnswer.Text;
            objLibSample.Type = hdnType.Value;
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSampleSubQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Sample Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Sample Question');", true);
            }

            else
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Sample Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Sample Question');", true);

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
                valu.PostBackUrl = "~/Admin/SampleAddSubOption.aspx?SubQuestionId=" + hdnAddQuestionId.Value + "&QuestionId=" + hdnQuestionId.Value + "&sid=" + Request.QueryString["sid"] + "&sectionName=" + Request.QueryString["sectionName"] + "&sectionId=" + Request.QueryString["sectionId"] + "&Type=" + Request.QueryString["Type"];
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
        Response.Redirect("SampleAddQuestion.aspx?SamId=" + hdnSectionId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);

        //string secName = Request.QueryString["sectionName"].ToString();
       
        //Response.Redirect("AddQuestion.aspx?SampleID=" + hdnSampleId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
    }
}
