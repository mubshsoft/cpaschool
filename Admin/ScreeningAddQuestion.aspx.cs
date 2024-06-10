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
public partial class Admin_ScreeningAddQuestion : System.Web.UI.Page
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

                    hdnScrId.Value = Request.QueryString["ScrId"].ToString();
                    lblSection.Text = Request.QueryString["sectionName"].ToString();
                    hdnSectionId.Value = Request.QueryString["sectionId"].ToString();
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

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                if (string.IsNullOrEmpty(Editor1.Value))
                {
                    return;
                }

            }
            if (txtMarks.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks cannot be left blank'); </script>");
                return;
            }

            int addResult = 0;
            string path = "";
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            if (ddlQuestionType.SelectedItem.Text == "Case Study")
            {
                objLibScreening.QuestionText = Utility.CheckNullString(Editor1.Value);
            }
            else
            {
                objLibScreening.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            }
            //objLibScreening.QuesNo = Convert.ToInt32(Utility.CheckNullString(txtquestionNo.Text));
            objLibScreening.MaxQueMarks = Convert.ToInt32(Utility.CheckNullString(txtMarks.Text));
            objLibScreening.ScrId = Convert.ToInt32(Utility.CheckNullString(hdnScrId.Value));
            objLibScreening.CategoryID = Convert.ToInt32(hdnSectionId.Value);
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
            if (ddlQuestionType.SelectedItem.Text == "Objective Question")
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

            if (FileUpload1.HasFile)
            {

                string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadQuestionImage\\";
                //string filename = uploadFolder + FileUpload1.PostedFile.FileName + "_Scrid" + hdnScrId.Value;
                string filename = uploadFolder + "Scrid_" + hdnScrId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
                if (file.Exists)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('File already exist');", true);
                    return;
                }
                else
                {
                    FileUpload1.SaveAs(filename);

                }
                //path = FileUpload1.PostedFile.FileName  +"_Scrid" + hdnScrId.Value;
                path = "Scrid_" + hdnScrId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            }

            objLibScreening.UploadQuestionImagePath = path;

            if (hdneditorupdate.Value == "1")
            {
                objLibScreening.QuestionId = Convert.ToInt32(hdnCaseStudyQuesId.Value);
            }
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateScreeningQuestion(tp);

            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question Saved Successfully');", true);
                txtQuestion.Text = "";
                txtAnswer.Text = "";
                txtMarks.Text = "";

                //txtquestionNo.Text = "";
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
            DataSet ds = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Convert.ToInt32(Utility.CheckNullString(hdnScrId.Value));
            objLIBScreening.CategoryID = Convert.ToInt32(Utility.CheckNullString(hdnSectionId.Value));

            tp.MessagePacket = (object)objLIBScreening;
            tp = objDalScreening.GetQuestionListbyCategory(tp);
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

            objLibScreening.QuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibScreening;
            //wahid

            string strChk = "select ques.QuestionId from ScreeningQUESTIONS ques INNER JOIN Screeningques_options opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALScreening objDalScreening = new DALScreening();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalScreening.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
                //lblMessage.Text = "Question has some options - can't be deleted";
            }
            else
            {
                addResult = OBJDALScreening.DeleteScreeningQuestion(tp);
            }

            //addResult = OBJDALScreening.DeleteScreeningQuestion(tp);
            //wahid
            if (addResult > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question  Deleted'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question  Deleted');", true);
                BindQuestionList();
            }


            else
            {
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Screening Question'); </script>");
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
        HiddenField hdnDeleteQuestionId = (HiddenField)gvQuestionList.Rows[e.NewEditIndex].FindControl("hdnAddQuestionId");
        HiddenField hdnQUESTYPE = (HiddenField)gvQuestionList.Rows[e.NewEditIndex].FindControl("hdnQUESTYPE");
        Label lblQuesText = (Label)gvQuestionList.Rows[e.NewEditIndex].FindControl("lblName");
        // Label lblAnswer = (Label)gvQuestionList.Rows[e.NewEditIndex].FindControl("lblAnswer");
        Label lblMaxQueMarks = (Label)gvQuestionList.Rows[e.NewEditIndex].FindControl("lblMaxQueMarks");
        if (hdnQUESTYPE.Value == "Case Study")
        {

            hdneditorupdate.Value = "1";
            txtQuestion.Visible = false;
            Editor1.Visible = true;
            Editor1.Value = lblQuesText.Text;
            txtMarks.Text = lblMaxQueMarks.Text;
            //txtAnswer.Text = lblAnswer.Text;
            txtAnswer.Enabled = false;
            hdnCaseStudyQuesId.Value = hdnDeleteQuestionId.Value;
            ddlQuestionType.SelectedIndex = ddlQuestionType.Items.IndexOf(ddlQuestionType.Items.FindByValue(hdnQUESTYPE.Value));
        }
        else
        {
            gvQuestionList.EditIndex = e.NewEditIndex;
            BindQuestionList();
        }

    }
    protected void gvQuestionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        HiddenField hdnQUESTYPE = (HiddenField)gvQuestionList.Rows[e.RowIndex].FindControl("hdnQUESTYPE");
        if (hdnQUESTYPE.Value != "Case Study")
        {
            gvQuestionList.EditIndex = -1;
            BindQuestionList();
        }

    }
    protected void gvQuestionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnDeleteQuestionId = ((HiddenField)gvQuestionList.Rows[e.RowIndex].FindControl("hdnDeleteQuestionId")).Value;
            TextBox txtQuestion = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtQuestion");
            //TextBox txtQuestionNo = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtQuestionNo");
            TextBox txtAnswer = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtAnswer");
            TextBox txtMaxQueMarks = (TextBox)gvQuestionList.Rows[e.RowIndex].FindControl("txtMaxQueMarks");
            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLibScreening.MaxQueMarks = Convert.ToInt32(txtMaxQueMarks.Text);
            objLibScreening.QuestionText = txtQuestion.Text;
            objLibScreening.QuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            //txtQuestionNo    objLibScreening.QuesNo = Convert.ToInt32(txtQuestionNo.Text);
            objLibScreening.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.AddUpdateScreeningQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Screening Question'); </script>");
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
                LinkButton valu = (LinkButton)e.Row.FindControl("linkAddOption");
                HiddenField hdnAddQuestionId = (HiddenField)e.Row.FindControl("hdnAddQuestionId");
                HiddenField hdnQUESTYPE = (HiddenField)e.Row.FindControl("hdnQUESTYPE");
                Session["question"] = (Label)e.Row.FindControl("lblName");

                if (hdnQUESTYPE.Value == "Descriptive" || hdnQUESTYPE.Value == "Subjective" || hdnQUESTYPE.Value == "Descriptive2" || hdnQUESTYPE.Value == "Image Question")
                {
                    valu.Enabled = false;
                }
                else
                {
                    valu.PostBackUrl = "~/Admin/ScreeningAddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + "&sid=" + hdnScrId.Value + "&sectionId=" + hdnSectionId.Value + "&sectionName=" + lblSection.Text;
                }

                if (hdnQUESTYPE.Value == "Case Study")
                {
                    string type1 = "Case Study";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnScrId.Value;
                    valu.PostBackUrl = "~/Admin/ScreeningAddSubQuestion.aspx?sid=" + hdnScrId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text+ "&Type=" + type1;
                }
                if (hdnQUESTYPE.Value == "Fill Blank")
                {
                    string type2 = "Fill Blank";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnExamId.Value;
                    valu.PostBackUrl = "~/Admin/ScreeningAddSubQuestion.aspx?sid=" + hdnScrId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text + "&Type=" + type2;
                }
                //valu.PostBackUrl = "~/Admin/AddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnScrId.Value;
                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Question ? ') ");
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + hdnScrId.Value);
    }
    protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlQuestionType.SelectedItem.Text == "Descriptive Questions (Table)")
        {
            trup1.Visible = true;
        }
        else
        {
            trup1.Visible = false;
        }
       
        if (ddlQuestionType.SelectedItem.Text == "Fill Blank")
        {
            txtQuestion.Text = "Fill in the blank";
        }

        else
        {
            txtQuestion.Text = "";
        }
        if (ddlQuestionType.SelectedItem.Text == "Case Study")
        {
            Editor1.Visible = true;
        }
        else
        {
            Editor1.Visible = false;
        }

        if (ddlQuestionType.SelectedIndex == 1)
        {
            txtAnswer.Enabled = true;
        }
        else
        {
            txtAnswer.Enabled = false;
        }
    }
   // protected void gvQuestionList_RowCommand(object sender, GridViewCommandEventArgs e)
   //{
   //    int id;
   //    if (e.CommandName == "Delete")
   //    {
   //        id = Convert.ToInt32(e.CommandArgument);
   //        string strChk = "select ques.QuestionId from QUESTIONS ques INNER JOIN OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + id;
   //        DALScreening objDalScreening = new DALScreening();
   //        DataSet ds = new DataSet();
   //        DataTable dtt = new DataTable();
   //        dtt = objDalScreening.getdata(strChk);
   //        if (dtt.Rows.Count > 0)
   //        {
   //            lblMessage.Text = "Question has some options - can't be deleted";
   //        }
   //        else
   //        {
   //            string str = "delete from QUESTIONS where QuestionId=" + id;
   //            //ExeNQcomsp(str);
   //            objDalScreening.ExeNQcomsp(str);
   //            lblMessage.Text = "Record deleted successfully";
   //            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
   //        }
   //        BindQuestionList();
   //    }
   // }

    //private void DeleteQuestion(string  id)
    //{
    //    string strChk = "select ques.QuestionId from QUESTIONS ques INNER JOIN OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + id;
    //    DALScreening objDalScreening = new DALScreening();
    //    DataSet ds = new DataSet();
    //    DataTable dtt = new DataTable();
    //    dtt = objDalScreening.getdata(strChk);
    //    if (dtt.Rows.Count > 0)
    //    {
    //        lblMessage.Text = "Question has some options - can't be deleted";
    //    }
    //    else
    //    {
    //        string str = "delete from QUESTIONS where QuestionId=" + id;
    //        //ExeNQcomsp(str);
    //        objDalScreening.ExeNQcomsp(str);
    //        lblMessage.Text = "Record deleted successfully";
    //        lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
    //    }
    //    BindQuestionList();
    //}
}
