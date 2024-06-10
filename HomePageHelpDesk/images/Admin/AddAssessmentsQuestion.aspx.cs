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
using System.IO;
public partial class Admin_AddAssessmentsQuestion : System.Web.UI.Page
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
                Uri myReferrer = Request.UrlReferrer;
                ViewState["pageredirect"] = myReferrer.ToString();

                if (Request.QueryString.Count > 0)
                {

                    hdnUnitID.Value = Request.QueryString["UnitID"].ToString();
                    hdnChapterid.Value = Request.QueryString["ChapterID"].ToString();
                    BindQuestionList();
                   
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
            //change by mala on9 feb

            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                if (string.IsNullOrEmpty(Editor1.Value))
                {
                    return;
                }

            }


            if (txtMarks.Text.Length == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks cannot be left blank'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Marks cannot be left blank');", true);
                return;
            }

            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALChapter OBJDALExam = new DALChapter();
            TransportationPacket tp = new TransportationPacket();

            string text = "questionimage";
            string path = "";
            if (ddlQuestionType.SelectedItem.Text == "Case Study")
            {
                objLibExam.QuestionText = Utility.CheckNullString(Editor1.Value);
            }
            else
            {
                objLibExam.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            }

            //objLibExam.QuesNo = Convert.ToInt32(Utility.CheckNullString(txtquestionNo.Text));
            objLibExam.MaxQueMarks = Convert.ToInt32(Utility.CheckNullString(txtMarks.Text));
            objLibExam.UnitID = Convert.ToInt32(Utility.CheckNullString(hdnUnitID.Value));
            objLibExam.ChapterID = Convert.ToInt32(Utility.CheckNullString(hdnChapterid.Value));
           // objLibExam.CategoryID = Convert.ToInt32(hdnSectionId.Value);
            if (ddlQuestionType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Question Type');", true);
                return;
            }
            else
            {
                objLibExam.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective Question")
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

            if (FileUpload1.HasFile)
            {

                string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadQuestionImage\\";
                string filename = uploadFolder + "Examid_" + hdnExamId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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
                path = "Examid_" + hdnExamId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

            }

            objLibExam.UploadQuestionImagePath = path;
            if (hdneditorupdate.Value == "1")
            {
                objLibExam.QuestionId = Convert.ToInt32(hdnCaseStudyQuesId.Value);
            }
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateUnitQuestion(tp);

            if (addResult > 0)
            {
                // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assessments Question Saved Successfully');", true);
                txtQuestion.Text = "";
                txtAnswer.Text = "";
                txtMarks.Text = "";
                Editor1.Value = "";
               
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Assessments Question');", true);

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
            LIBExam objLIBExam = new LIBExam();
            DALChapter objDalExam = new DALChapter();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UnitID = Convert.ToInt32(Utility.CheckNullString(hdnUnitID.Value));
            objLIBExam.ChapterID = Convert.ToInt32(Utility.CheckNullString(hdnChapterid.Value));

            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetQuestionListbyUnit(tp);
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
        string hdnQuesIamgePath = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnQuesIamgePath")).Value;
        try
        {
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALChapter OBJDALExam = new DALChapter();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.QuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibExam;
            //wahid

            string strChk = "select ques.QuestionId from Assessments_QUESTIONS ques INNER JOIN Assessments_QUES_OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + Convert.ToInt32(hdnQuestionId);
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
                addResult = OBJDALExam.DeleteAssessmentsQuestion(tp);
            }


            if (addResult > 0)
            {
                string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadQuestionImage\\";
                string filename = uploadFolder + hdnQuesIamgePath;
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
                if (file.Exists)
                {
                    File.Delete(filename);
                }
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam Question  Deleted'); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Question  Deleted'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam Question  Deleted');", true);
                BindQuestionList();
            }


            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Exam Question'); </script>");
                // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Question has some options - can't be deleted'); </script>");
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
            LIBExam objLibExam = new LIBExam();
            DALChapter OBJDALExam = new DALChapter();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.MaxQueMarks = Convert.ToInt32(txtMaxQueMarks.Text);
            objLibExam.QuestionText = txtQuestion.Text;
            objLibExam.QuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            
            objLibExam.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateUnitQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assessments Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Exam Question');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Assessments Question');", true);
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
                    valu.PostBackUrl = "~/Admin/AddAssessmentsOption.aspx?QuestionId=" + hdnAddQuestionId.Value + "&uid=" + hdnUnitID.Value + "&ChapterId=" + hdnChapterid.Value ;
                }

                if (hdnQUESTYPE.Value == "Case Study")
                {
                    string type1 = "Case Study";
                    valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?sid=" + hdnExamId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text + "&Type=" + type1;
                }
                if (hdnQUESTYPE.Value == "Fill Blank")
                {
                    string type2 = "Fill Blank";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnExamId.Value;
                    valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?sid=" + hdnExamId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text + "&Type=" + type2;
                }


                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Question ? '); ");



            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
       
            try
            {
                if (ViewState["pageredirect"].ToString() != null)
                {
                    string actual = ViewState["pageredirect"].ToString();
                    Response.Redirect(actual);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("AdminLogin.aspx");
            }
      
    }
    protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
    {

        //code by mala on 9 Feb
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
            txtQuestion.Visible = false;
        }
        else
        {
            Editor1.Visible = false;
            txtQuestion.Visible = true;
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
    //        DALExam objDalExam = new DALExam();
    //        DataSet ds = new DataSet();
    //        DataTable dtt = new DataTable();
    //        dtt = objDalExam.getdata(strChk);
    //        if (dtt.Rows.Count > 0)
    //        {
    //            lblMessage.Text = "Question has some options - can't be deleted";
    //        }
    //        else
    //        {
    //            string str = "delete from QUESTIONS where QuestionId=" + id;
    //            //ExeNQcomsp(str);
    //            objDalExam.ExeNQcomsp(str);
    //            lblMessage.Text = "Record deleted successfully";
    //            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
    //        }
    //        BindQuestionList();
    //    }
    // }

    //private void DeleteQuestion(string  id)
    //{
    //    string strChk = "select ques.QuestionId from QUESTIONS ques INNER JOIN OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + id;
    //    DALExam objDalExam = new DALExam();
    //    DataSet ds = new DataSet();
    //    DataTable dtt = new DataTable();
    //    dtt = objDalExam.getdata(strChk);
    //    if (dtt.Rows.Count > 0)
    //    {
    //        lblMessage.Text = "Question has some options - can't be deleted";
    //    }
    //    else
    //    {
    //        string str = "delete from QUESTIONS where QuestionId=" + id;
    //        //ExeNQcomsp(str);
    //        objDalExam.ExeNQcomsp(str);
    //        lblMessage.Text = "Record deleted successfully";
    //        lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
    //    }
    //    BindQuestionList();
    //}


    protected void gvQuestionList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
