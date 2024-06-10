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
public partial class Admin_CopyQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       try
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
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    hdnExamId.Value = Request.QueryString["ExamID"].ToString();
                    lbloldexamset.Text = Request.QueryString["examcode"].ToString();
                    //lblSection.Text = Request.QueryString["sectionName"].ToString();
                   // hdnSectionId.Value = Request.QueryString["sectionId"].ToString();
                    //BindQuestionList();
                    BindExamSetList();

                }


            }
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
            if (ddlexamset.SelectedItem.Text == "--Select--")
            {
                return;
            }
            else
            {
                hdnNewexamid.Value = ddlexamset.SelectedItem.Value;
            }

            int addResult = 0;
            DataSet ds = new DataSet();
            ds = BindQuestionList();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        LIBExam objLibExam = new LIBExam();
                        DALExam OBJDALExam = new DALExam();
                        TransportationPacket tp = new TransportationPacket();
                         objLibExam.ExamId = Convert.ToInt32(ddlexamset.SelectedItem.Value);
                         objLibExam.OldExamId = Convert.ToInt32(hdnExamId.Value);
                        // insert section
                         int addresultsection = insertExamSection(objLibExam.ExamId, objLibExam.OldExamId);
                         if (addresultsection != -1)
                         {
                             // insert section question 
                             int addresultsectionQue = insertSectionQuestion(objLibExam.ExamId, objLibExam.OldExamId);
                             //insert question
                             for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                             {
                                 objLibExam.OldQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                                 objLibExam.QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                                 objLibExam.MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                                 objLibExam.Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                                 objLibExam.QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                                 objLibExam.OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                                 int oldcategoryid = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"].ToString());
                                 int categoryid = GetCategoryId(oldcategoryid);
                                 objLibExam.CategoryID = categoryid;

                                 if (objLibExam.QUESTYPE.ToString() == "Objective")
                                 {
                                     //objLibExam.Answer = txtAnswer.Text;
                                     objLibExam.Descriptive = false;
                                 }
                                 else if (objLibExam.QUESTYPE.ToString() == "Descriptive")
                                 {
                                     objLibExam.Descriptive = true;

                                 }
                                 else
                                 {

                                     objLibExam.Descriptive = false;
                                 }



                                 tp.MessagePacket = (object)objLibExam;

                                 addResult = OBJDALExam.AddUpdateExamQuestion(tp);
                                 if (addResult == 1 && objLibExam.OPTIONTYPE != "")
                                 {
                                     //insert question option
                                     int queid = OBJDALExam.GetMaxQuesNo(tp);
                                     int addResult1 = insertQuestionOption(queid, objLibExam.OldQuestionId);

                                 }
                                 if (addResult == 1 && objLibExam.QUESTYPE.ToString() == "Case Study" || addResult == 1 && objLibExam.QUESTYPE.ToString() == "Fill Blank")
                                 {
                                     int newqueid = OBJDALExam.GetMaxQuesNo(tp);
                                     insertquestionlist(newqueid, objLibExam.OldQuestionId);
                                 }
                             }
                         }
                    }
                }
            }
            

            if (addResult > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Questions Saved Successfully'); </script>");
                btnSave.Visible = false;
                //txtQuestion.Text = "";
                //txtquestionNo.Text = "";
                //ddlcategory.SelectedIndex = 0;
                BindSubmitedQuestionList();

            }
            else if (addResult == -11)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Allready created'); </script>");
                BindSubmitedQuestionList();
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindExamSetList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetExamSetList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlexamset.DataSource = objLibExamListing;
            ddlexamset.DataTextField = "ExamCode";
            ddlexamset.DataValueField = "ExamId";
            ddlexamset.DataBind();
            ddlexamset.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected DataSet BindSubQuestionList(int OldQuestionid)
    {
        DataSet ds=new DataSet();
        try
        {
           
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = OldQuestionid;
            tp.MessagePacket = (object)objLIBExam;
              ds = objDalExam.GetSubQuestionList_CopyQuestion(tp);
         

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return ds;


    }
    protected void insertquestionlist( int newquestionid,int oldquestionid)
    {
        int addResult = 0;
        DataSet ds = new DataSet();
        ds = BindSubQuestionList(oldquestionid);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows != null)
                {
                    LIBExam objLibExam = new LIBExam();
                    DALExam OBJDALExam = new DALExam();
                    TransportationPacket tp = new TransportationPacket();
                    //objLibExam.ExamId = Convert.ToInt32(ddlexamset.SelectedItem.Value);
                    //objLibExam.OldExamId = Convert.ToInt32(hdnExamId.Value);
                    //// insert section
                    //int addresultsection = insertExamSection(objLibExam.ExamId, objLibExam.OldExamId);
                    //if (addresultsection != -1)
                    //{
                        // insert section question 
                       // int addresultsectionQue = insertSectionQuestion(objLibExam.ExamId, objLibExam.OldExamId);
                        //insert question
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            objLibExam.QuestionId = newquestionid;
                            //objLibExam.QuestionText = Utility.CheckNullString(txtQuestion.Text);
                            objLibExam.QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                            objLibExam.QuesNo = ds.Tables[0].Rows[i]["QuesNo"].ToString();
                            objLibExam.Type = ds.Tables[0].Rows[i]["Type"].ToString();



                            objLibExam.OldSubQuestionId = Convert.ToInt32(ds.Tables[0].Rows[i]["SubQuestionId"].ToString());
                            //objLibExam.QuestionText = ds.Tables[0].Rows[i]["QuestionText"].ToString();
                            //objLibExam.MaxQueMarks = Convert.ToInt32(ds.Tables[0].Rows[i]["MaxQueMarks"].ToString());
                            objLibExam.Answer = ds.Tables[0].Rows[i]["Answer"].ToString();
                            objLibExam.QUESTYPE = ds.Tables[0].Rows[i]["QUESTYPE"].ToString();
                            //objLibExam.OPTIONTYPE = ds.Tables[0].Rows[i]["OPTIONTYPE"].ToString();
                           // int oldcategoryid = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"].ToString());
                            //int categoryid = GetCategoryId(oldcategoryid);
                            //objLibExam.CategoryID = categoryid;

                            if (objLibExam.QUESTYPE.ToString() == "Objective")
                            {
                                //objLibExam.Answer = txtAnswer.Text;
                                objLibExam.Descriptive = false;
                            }
                            else if (objLibExam.QUESTYPE.ToString() == "Descriptive")
                            {
                                objLibExam.Descriptive = true;

                            }
                            else
                            {

                                objLibExam.Descriptive = false;
                            }



                            tp.MessagePacket = (object)objLibExam;

                            addResult = OBJDALExam.AddUpdateExamSubQuestion(tp);
                            if (addResult == 1 && objLibExam.QUESTYPE.ToString() == "Objective")
                            {
                                //insert sub question option
                                int subqueid = OBJDALExam.GetMaxSubQuesNo(tp);
                                int addResult1 = insertSubQuestionOption(subqueid, objLibExam.OldSubQuestionId);

                            }
                           
                        }
                    //}
                }
            }
        }
    }

    protected DataSet BindQuestionList()
    {
        DataSet ds=new DataSet();
        try
        {
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(Utility.CheckNullString(hdnExamId.Value));
            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetQuestionList(tp);
            // objLibExamListing = (LIBExamListing)tp.MessageResultset;
            //gvQuestionList.DataSource = ds;
            //gvQuestionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return ds;
    }
    protected int GetCategoryId(int oldcategoryid)
    {
        int CATEGORYID = 0;
        try
        {

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(Utility.CheckNullString(ddlexamset.SelectedItem.Value));
            objLIBExam.CategoryID = oldcategoryid;
            tp.MessagePacket = (object)objLIBExam;
            CATEGORYID = objDalExam.GetCATEGORYID(tp);
            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        return CATEGORYID;
    }
    protected int insertQuestionOption(int newquestionid, int oldquestionid)
    {
        int addResult = 0;
        try
        {

            
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

           
            objLibExam.QuestionId = Convert.ToInt32(newquestionid);
            objLibExam.OldQuestionId = Convert.ToInt32(oldquestionid);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddCopyQuestionOption(tp);
        }
        catch(Exception ex)
        {
        }
        return addResult;

    }
    protected int insertSubQuestionOption(int newquestionid, int oldquestionid)
    {
        int addResult = 0;
        try
        {


            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();


            objLibExam.SubQuestionId = Convert.ToInt32(newquestionid);
            objLibExam.OldSubQuestionId = Convert.ToInt32(oldquestionid);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddsubCopyQuestionOption(tp);
        }
        catch (Exception ex)
        {
        }
        return addResult;

    }

    protected int insertExamSection(int newexamid, int oldexamid)
    {
        int addResult = 0;
        try
        {


            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();


            objLibExam.ExamId = Convert.ToInt32(newexamid);
            objLibExam.OldExamId = Convert.ToInt32(oldexamid);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddCopyExamSection(tp);
        }
        catch (Exception ex)
        {
        }
        return addResult;

    }

    protected int insertSectionQuestion(int newexamid, int oldexamid)
    {
        int addResult = 0;
        try
        {


            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();


            objLibExam.ExamId = Convert.ToInt32(newexamid);
            objLibExam.OldExamId = Convert.ToInt32(oldexamid);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddCopySectionQuestion(tp);
        }
        catch (Exception ex)
        {
        }
        return addResult;

    }
    protected void BindSubmitedQuestionList()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32((hdnNewexamid.Value));
            //objLIBExam.CategoryID = Convert.ToInt32(Utility.CheckNullString(hdnSectionId.Value));

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetQuestionList(tp);
           // objLibExamListing = (LIBExamListing)tp.MessageResultset;
            gvQuestionList.DataSource = ds;
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

            objLibExam.QuestionId = Convert.ToInt32(hdnQuestionId);
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.DeleteExamQuestion(tp);

            if (addResult > 0)
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam Question  Deleted'); </script>");
                BindSubmitedQuestionList();
            }


            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Exam Question'); </script>");

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
        BindSubmitedQuestionList();
    }
    protected void gvQuestionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQuestionList.EditIndex = -1;
        BindSubmitedQuestionList();

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
            objLibExam.QuestionId = Convert.ToInt32(hdnDeleteQuestionId);
           // objLibExam.QuesNo = Convert.ToInt32(txtQuestionNo.Text);
            objLibExam.QuesNo = txtQuestionNo.Text;
            objLibExam.Answer = txtAnswer.Text;
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateExamQuestion(tp);

            if (addResult > 0)
            {
                gvQuestionList.EditIndex = -1;
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam Question Updated'); </script>");
                BindSubmitedQuestionList();
            }
            else if (addResult == -11)
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Question'); </script>");

            }

            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Exam Question'); </script>");


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    //protected void gvQuestionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        gvQuestionList.PageIndex = e.NewPageIndex;
    //        BindSubmitedQuestionList();

    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}
    #endregion
    protected void gvQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               

                //valu.PostBackUrl = "~/Admin/AddOption.aspx?QuestionId=" + hdnAddQuestionId.Value + " &sid=" + hdnExamId.Value;
                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Question ? ') ");
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
}
