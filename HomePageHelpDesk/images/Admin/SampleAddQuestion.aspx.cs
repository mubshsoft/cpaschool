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
public partial class Admin_SampleAddQuestion : System.Web.UI.Page
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

                    hdnSamId.Value = Request.QueryString["SamId"].ToString();
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            if (ddlQuestionType.SelectedItem.Text == "Case Study")
            {
                objLibSample.QuestionText = Utility.CheckNullString(Editor1.Value);
            }
            else
            {
                objLibSample.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            }
            //objLibSample.QuesNo = Convert.ToInt32(Utility.CheckNullString(txtquestionNo.Text));
            objLibSample.MaxQueMarks = Convert.ToInt32(Utility.CheckNullString(txtMarks.Text));
            objLibSample.SamId = Convert.ToInt32(Utility.CheckNullString(hdnSamId.Value));
            objLibSample.CategoryID = Convert.ToInt32(hdnSectionId.Value);
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
            if (ddlQuestionType.SelectedItem.Text == "Objective Question")
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

            if (FileUpload1.HasFile)
            {

                string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadQuestionImage\\";
                //string filename = uploadFolder + FileUpload1.PostedFile.FileName + "_Sampleid" + hdnSamId.Value;
                string filename = uploadFolder + "Sampleid_" + hdnSamId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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
               // path = FileUpload1.PostedFile.FileName + "_Sampleid" + hdnSamId.Value;
                path = "Sampleid_" + hdnSamId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

            }

            objLibSample.UploadQuestionImagePath = path;
            if (hdneditorupdate.Value == "1")
            {
                objLibSample.QuestionId = Convert.ToInt32(hdnCaseStudyQuesId.Value);
            }

            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSampleQuestion(tp);

            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question Saved Successfully');", true);
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
            DataSet ds = new DataSet();
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SamId = Convert.ToInt32(Utility.CheckNullString(hdnSamId.Value));
            objLIBSample.CategoryID = Convert.ToInt32(Utility.CheckNullString(hdnSectionId.Value));

            tp.MessagePacket = (object)objLIBSample;
            tp = objDalSample.GetQuestionListbyCategory(tp);
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

            objLibSample.QuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibSample;
            //wahid

            string strChk = "select ques.QuestionId from SampleQUESTIONS ques INNER JOIN Sampleques_options opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + Convert.ToInt32(hdnQuestionId);
            DALSample objDalSample = new DALSample();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalSample.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
                //lblMessage.Text = "Question has some options - can't be deleted";
            }
            else
            {
                addResult = OBJDALSample.DeleteSampleQuestion(tp);
            }

            //addResult = OBJDALSample.DeleteSampleQuestion(tp);
            //wahid
            if (addResult > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question  Deleted'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question  Deleted');", true);
                BindQuestionList();
            }


            else
            {
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Sample Question'); </script>");
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
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLibSample.MaxQueMarks = Convert.ToInt32(txtMaxQueMarks.Text);
            objLibSample.QuestionText = txtQuestion.Text;
            objLibSample.QuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            //txtQuestionNo    objLibSample.QuesNo = Convert.ToInt32(txtQuestionNo.Text);
            objLibSample.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.AddUpdateSampleQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Question Updated'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Question Updated');", true);
                BindQuestionList();
            }
            else if (addResult == -11)
            {
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Sample Question'); </script>");
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
                    valu.PostBackUrl = "~/Admin/SampleAddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + "&sid=" + hdnSamId.Value + "&sectionId=" + hdnSectionId.Value + "&sectionName=" + lblSection.Text;
                }

                if (hdnQUESTYPE.Value == "Case Study")
                {
                    string type1 = "Case Study";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnSamId.Value;
                    valu.PostBackUrl = "~/Admin/SampleAddSubQuestion.aspx?sid=" + hdnSamId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text+ "&Type=" + type1;
                }
                if (hdnQUESTYPE.Value == "Fill Blank")
                {
                    string type2 = "Fill Blank";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnExamId.Value;
                    valu.PostBackUrl = "~/Admin/SampleAddSubQuestion.aspx?sid=" + hdnSamId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text + "&Type=" + type2;
                }
                //valu.PostBackUrl = "~/Admin/AddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnSamId.Value;
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
        Response.Redirect("SampleSelectSection.aspx?SamId=" + hdnSamId.Value);
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
   //        DALSample objDalSample = new DALSample();
   //        DataSet ds = new DataSet();
   //        DataTable dtt = new DataTable();
   //        dtt = objDalSample.getdata(strChk);
   //        if (dtt.Rows.Count > 0)
   //        {
   //            lblMessage.Text = "Question has some options - can't be deleted";
   //        }
   //        else
   //        {
   //            string str = "delete from QUESTIONS where QuestionId=" + id;
   //            //ExeNQcomsp(str);
   //            objDalSample.ExeNQcomsp(str);
   //            lblMessage.Text = "Record deleted successfully";
   //            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
   //        }
   //        BindQuestionList();
   //    }
   // }

    //private void DeleteQuestion(string  id)
    //{
    //    string strChk = "select ques.QuestionId from QUESTIONS ques INNER JOIN OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + id;
    //    DALSample objDalSample = new DALSample();
    //    DataSet ds = new DataSet();
    //    DataTable dtt = new DataTable();
    //    dtt = objDalSample.getdata(strChk);
    //    if (dtt.Rows.Count > 0)
    //    {
    //        lblMessage.Text = "Question has some options - can't be deleted";
    //    }
    //    else
    //    {
    //        string str = "delete from QUESTIONS where QuestionId=" + id;
    //        //ExeNQcomsp(str);
    //        objDalSample.ExeNQcomsp(str);
    //        lblMessage.Text = "Record deleted successfully";
    //        lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
    //    }
    //    BindQuestionList();
    //}
}
