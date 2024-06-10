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
public partial class AssignmentAddSubQuestion : System.Web.UI.Page
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
    //        objLIBCategory.AssignmentId = Convert.ToInt32(hdnAssignmentId.Value);

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
    //        //    if (Convert.ToBoolean(objLibCategoryListing[i].AssignmentId))
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
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLibAssignment.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
            objLibAssignment.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            objLibAssignment.QuesNo = Utility.CheckNullString(txtquestionNo.Text);
            objLibAssignment.Type = hdnType.Value;
           
            if (ddlQuestionType.SelectedIndex == 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Question Type');", true);

                return;
            }
            else
            {
                objLibAssignment.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective")
            {
                objLibAssignment.Answer = txtAnswer.Text;
                objLibAssignment.Descriptive = false;
            }
            else if (ddlQuestionType.SelectedItem.Text == "Descriptive")
            {
                objLibAssignment.Descriptive = true;

            }
            else
            {

                objLibAssignment.Descriptive = false;
            }
          
                  

            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateAssignmentSubQuestion(tp);

            if (addResult > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment Question Saved Successfully');", true);

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
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Assignment Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Assignment Question');", true);
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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetSubQuestionList(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            gvQuestionList.DataSource = objLibAssignmentListing;
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
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            objLibAssignment.SubQuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibAssignment;


            string strChk = "select ques.SubQuestionId from Assignmentsubquestions ques INNER JOIN Assignmentsubques_options opt on ques.SubQuestionId=opt.SubQuestionId where ques.SubQuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALAssignment objDalAssignment = new DALAssignment();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalAssignment.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
                //lblMessage.Text = "Question has some options - can't be deleted";
            }
            else
            {
                addResult = OBJDALAssignment.DeleteAssignmentSubQuestion(tp);
            }
            //addResult = OBJDALAssignment.DeleteAssignmentSubQuestion(tp);

            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment Question  Deleted'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment Question  Deleted');", true);
                BindQuestionList();
            }


            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Assignment Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Question has some options - cannot be delete');", true);
            }
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
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            objLibAssignment.QuestionText = txtQuestion.Text;
            objLibAssignment.SubQuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            objLibAssignment.QuesNo = txtQuestionNo.Text;
            objLibAssignment.Answer = txtAnswer.Text;
            objLibAssignment.Type = hdnType.Value;
            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateAssignmentSubQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment Question Updated');", true);
                
                BindQuestionList();
            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Assignment Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Assignment Question');", true);
            }

            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Assignment Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Assignment Question');", true);

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
                valu.PostBackUrl = "~/Admin/AssignmentAddSubOption.aspx?SubQuestionId=" + hdnAddQuestionId.Value + "&QuestionId=" + hdnQuestionId.Value + "&sid=" + Request.QueryString["sid"] + "&sectionName=" + Request.QueryString["sectionName"] + "&sectionId=" + Request.QueryString["sectionId"] + "&Type=" + Request.QueryString["Type"];
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
        Response.Redirect("AssignmentAddQuestion.aspx?AsgnID=" + hdnSectionId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);

        //string secName = Request.QueryString["sectionName"].ToString();
       
        //Response.Redirect("AddQuestion.aspx?AssignmentID=" + hdnAssignmentId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
    }
}
