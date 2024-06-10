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
public partial class Admin_AssignmentAddQuestion : System.Web.UI.Page
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

                    hdnAsgnId.Value = Request.QueryString["AsgnId"].ToString();
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
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            if (ddlQuestionType.SelectedItem.Text == "Case Study")
            {
                objLibAssignment.QuestionText = Utility.CheckNullString(Editor1.Value);
            }
            else
            {
                objLibAssignment.QuestionText = Utility.CheckNullString(txtQuestion.Text);
            }
            //objLibAssignment.QuesNo = Convert.ToInt32(Utility.CheckNullString(txtquestionNo.Text));
            objLibAssignment.MaxQueMarks = Convert.ToInt32(Utility.CheckNullString(txtMarks.Text));
            objLibAssignment.AsgnId = Convert.ToInt32(Utility.CheckNullString(hdnAsgnId.Value));
            objLibAssignment.CategoryID = Convert.ToInt32(hdnSectionId.Value);
            if (ddlQuestionType.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Question Type'); </script>");

                return;
            }
            else
            {
                objLibAssignment.QUESTYPE = Utility.CheckNullString(ddlQuestionType.SelectedItem.Value);

            }
            if (ddlQuestionType.SelectedItem.Text == "Objective Question")
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

            if (FileUpload1.HasFile)
            {

                string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadQuestionImage\\";
                string filename = uploadFolder + "Asgnid_" + hdnAsgnId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                //string filename = uploadFolder + FileUpload1.PostedFile.FileName + "_Asgnid" + hdnAsgnId.Value;
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
                //path = FileUpload1.PostedFile.FileName + "_Asgnid" + hdnAsgnId.Value;
                path = "Asgnid_" + hdnAsgnId.Value + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

            }

            objLibAssignment.UploadQuestionImagePath = path;
            if (hdneditorupdate.Value == "1")
            {
                objLibAssignment.QuestionId = Convert.ToInt32(hdnCaseStudyQuesId.Value);
            }

            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateAssignmentQuestion(tp);

            if (addResult > 0)
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment Question Saved Successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment Question Saved Successfully');", true);
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
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Assignment Question'); </script>");
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
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(Utility.CheckNullString(hdnAsgnId.Value));
            objLIBAssignment.CategoryID = Convert.ToInt32(Utility.CheckNullString(hdnSectionId.Value));

            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetQuestionListbyCategory(tp);
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

            objLibAssignment.QuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibAssignment;
            //wahid

            string strChk = "select ques.QuestionId from AssignmentQUESTIONS ques INNER JOIN Assignmentques_options opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + Convert.ToInt32(hdnQuestionId);
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
                addResult = OBJDALAssignment.DeleteAssignmentQuestion(tp);
            }

            //addResult = OBJDALAssignment.DeleteAssignmentQuestion(tp);
            //wahid
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
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLibAssignment.MaxQueMarks = Convert.ToInt32(txtMaxQueMarks.Text);
            objLibAssignment.QuestionText = txtQuestion.Text;
            objLibAssignment.QuestionId = Convert.ToInt32(hdnDeleteQuestionId);
            //txtQuestionNo    objLibAssignment.QuesNo = Convert.ToInt32(txtQuestionNo.Text);
            objLibAssignment.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateAssignmentQuestion(tp);

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
                    valu.PostBackUrl = "~/Admin/AssignmentAddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + "&sid=" + hdnAsgnId.Value + "&sectionId=" + hdnSectionId.Value + "&sectionName=" + lblSection.Text;
                }

                if (hdnQUESTYPE.Value == "Case Study")
                {
                    string type1 = "Case Study";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnAsgnId.Value;
                    valu.PostBackUrl = "~/Admin/AssignmentAddSubQuestion.aspx?sid=" + hdnAsgnId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text+ "&Type=" + type1;
                }
                if (hdnQUESTYPE.Value == "Fill Blank")
                {
                    string type2 = "Fill Blank";
                    //valu.PostBackUrl = "~/Admin/AddSubQuestion.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnExamId.Value;
                    valu.PostBackUrl = "~/Admin/AssignmentAddSubQuestion.aspx?sid=" + hdnAsgnId.Value + "&sectionId=" + hdnSectionId.Value + " &QuestionId=" + hdnAddQuestionId.Value + "&sectionName=" + lblSection.Text + "&Type=" + type2;
                }
                //valu.PostBackUrl = "~/Admin/AddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnAsgnId.Value;
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
        Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + hdnAsgnId.Value);
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
   //        DALAssignment objDalAssignment = new DALAssignment();
   //        DataSet ds = new DataSet();
   //        DataTable dtt = new DataTable();
   //        dtt = objDalAssignment.getdata(strChk);
   //        if (dtt.Rows.Count > 0)
   //        {
   //            lblMessage.Text = "Question has some options - can't be deleted";
   //        }
   //        else
   //        {
   //            string str = "delete from QUESTIONS where QuestionId=" + id;
   //            //ExeNQcomsp(str);
   //            objDalAssignment.ExeNQcomsp(str);
   //            lblMessage.Text = "Record deleted successfully";
   //            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
   //        }
   //        BindQuestionList();
   //    }
   // }

    //private void DeleteQuestion(string  id)
    //{
    //    string strChk = "select ques.QuestionId from QUESTIONS ques INNER JOIN OPTIONS opt on ques.QuestionId=opt.QuestionId where ques.QuestionId=" + id;
    //    DALAssignment objDalAssignment = new DALAssignment();
    //    DataSet ds = new DataSet();
    //    DataTable dtt = new DataTable();
    //    dtt = objDalAssignment.getdata(strChk);
    //    if (dtt.Rows.Count > 0)
    //    {
    //        lblMessage.Text = "Question has some options - can't be deleted";
    //    }
    //    else
    //    {
    //        string str = "delete from QUESTIONS where QuestionId=" + id;
    //        //ExeNQcomsp(str);
    //        objDalAssignment.ExeNQcomsp(str);
    //        lblMessage.Text = "Record deleted successfully";
    //        lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
    //    }
    //    BindQuestionList();
    //}
}
