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
public partial class AddSubQuestion : System.Web.UI.Page
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
    //        objLIBCategory.ExamId = Convert.ToInt32(hdnExamId.Value);

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
    //        //    if (Convert.ToBoolean(objLibCategoryListing[i].ExamId))
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
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
            objLibExam.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            objLibExam.QuesNo = Utility.CheckNullString(txtquestionNo.Text);
            objLibExam.Type = hdnType.Value;
            if (ddlQuestionType.SelectedIndex == 0)
            {
               // Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Question Type');", true);
                return;
            }
            else
            {
                objLibExam.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective")
            {
                objLibExam.Answer = txtAnswer.Text;
                objLibExam.Descriptive = false;
            }
            else if (ddlQuestionType.SelectedItem.Text == "Descriptive")
            {
                objLibExam.Descriptive = true;

            }
            else
            {

                objLibExam.Descriptive = false;
            }
          
                  

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateExamSubQuestion(tp);

            if (addResult > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam Question Saved Successfully');", true);
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
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Exam Question');", true);
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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSubQuestionList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            gvQuestionList.DataSource = objLibExamListing;
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
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.SubQuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibExam;


            string strChk = "select ques.SubQuestionId from subquestions ques INNER JOIN subques_options opt on ques.SubQuestionId=opt.SubQuestionId where ques.SubQuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALExam objDalExam = new DALExam();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalExam.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
                //lblMessage.Text = "Question has some options - can't be deleted";
            }
            else
            {
                addResult = OBJDALExam.DeleteExamSubQuestion(tp);
            }
            //addResult = OBJDALExam.DeleteExamSubQuestion(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam Question  Deleted'); </script>");
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Question  Deleted'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam Question  Deleted');", true);
                BindQuestionList();
            }


            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Exam Question'); </script>");
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Exam Question'); </script>");
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
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.QuestionText = txtQuestion.Text;
            objLibExam.SubQuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            objLibExam.QuesNo = txtQuestionNo.Text;
            objLibExam.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateExamSubQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam Question Updated'); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Question'); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Exam Question');", true);
            }

            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Exam Question'); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Exam Question');", true);
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
                valu.PostBackUrl = "~/Admin/AddSubOption.aspx?SubQuestionId=" + hdnAddQuestionId.Value + "&QuestionId=" + hdnQuestionId.Value + "&sid=" + Request.QueryString["sid"] + "&sectionName=" + Request.QueryString["sectionName"] + "&sectionId=" + Request.QueryString["sectionId"] + "&Type=" + Request.QueryString["Type"];
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
        if (ddlQuestionType.SelectedItem.Text == "Descriptive")
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
        Response.Redirect("AddQuestion.aspx?ExamID=" + hdnSectionId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);

        //string secName = Request.QueryString["sectionName"].ToString();
       
        //Response.Redirect("AddQuestion.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + SectionId + "&sectionName=" + secName);
    }
}
