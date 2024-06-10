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
using fmsf.DAL;
using fmsf.lib;

public partial class AddSectionQue : System.Web.UI.Page
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
            if (Session.Count <= 0)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!Page.IsPostBack)
            {
                hdnCategoryId.Value = Request.QueryString["sectionId"].ToString();
                hdnExamid.Value = Request.QueryString["ExamID"].ToString();


                //if ((Request.QueryString["a"].ToString().Length)> 0)
                //{
                //    btnSave.Visible=false;
                //}
                //else
                //{
                //    btnSave.Visible=true;
                //}


                if (Request.QueryString.Count > 0)
                {
                    try
                    {
                        if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                        {
                            btnSave.Visible = false;
                            btnSaveContinue.Visible = true;
                        }
                        else
                        {
                            btnSave.Visible = true;
                            btnSaveContinue.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        btnSave.Visible = true;
                        btnSaveContinue.Visible = false;
                    }
                }


                BindSectionList();

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
   

    protected void BindSectionList()
    {
        
        
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamid.Value);
            objLIBExam.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;
          tp = objDalExam.GetNoQuestionInSection(tp);
          objLibExamListing = (LIBExamListing)tp.MessageResultset;
          if (objLibExamListing != null)
          {

              if (objLibExamListing.Count > 0)
              {
                  txtmax_sec.Text = objLibExamListing[0].MaxQueInSection.ToString();
                  txtmaxattempt.Text = objLibExamListing[0].MaxAttemptQue.ToString();
                 // txtmaxmarks.Text = objLibExamListing[0].MaxQueMarks.ToString();
                  //btnSave.Visible = false;
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
                int addResult = 0;

                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                TransportationPacket tp = new TransportationPacket();

                objLIBExam.ExamId = Convert.ToInt32(hdnExamid.Value);
                objLIBExam.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                objLIBExam.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
                objLIBExam.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
                tp.MessagePacket = (object)objLIBExam;
                addResult = objDalExam.AddQueInSection(tp);

                if (addResult == 1 )
                {
                   lblMessage.Text = "Saved Successfully";
                   txtmaxattempt.Text = "";
                   txtmax_sec.Text = "";
                   //Response.Redirect("SelectSection.aspx?ExamId=" + hdnExamid.Value);
                   Response.Redirect("StudentInstructionSummary.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString());
                }
                //else if (addResult == -11)
                //{

                //    lblMessage.Text = "Duplicate Section Option";

                //}
                else if (addResult == 2)
                {

                    lblMessage.Text = "Updated Successfully";
                    txtmaxattempt.Text = "";
                    txtmax_sec.Text = "";
                    Response.Redirect("SelectSection.aspx?ExamId=" + hdnExamid.Value);

                }
                else
                {

                    lblMessage.Text = "Failed to Save Section Option";

                }
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }


       

        

    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            try
            {
                if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                {
                   Response.Redirect("AddSelectSection.aspx?ExamId=" + Request.QueryString["ExamID"].ToString(),false);
                                   
                }
                else
                {
                    Response.Redirect("SelectSection.aspx?ExamId=" + Request.QueryString["ExamID"].ToString(),false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("SelectSection.aspx?ExamId=" + Request.QueryString["ExamID"].ToString(),false);
            }
        }

       
    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {

        try
        {
            int addResult = 0;

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.ExamId = Convert.ToInt32(hdnExamid.Value);
            objLIBExam.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            objLIBExam.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
            objLIBExam.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddQueInSection(tp);

            if (addResult == 1)
            {
                lblMessage.Text = "Saved Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                //Response.Redirect("SelectSection.aspx?ExamId=" + hdnExamid.Value);
                Response.Redirect("StudentInstructionSummary.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
            }
            //else if (addResult == -11)
            //{

            //    lblMessage.Text = "Duplicate Section Option";

            //}
            else if (addResult == 2)
            {

                lblMessage.Text = "Updated Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                Response.Redirect("SelectSection.aspx?ExamId=" + hdnExamid.Value);

            }
            else
            {

                lblMessage.Text = "Failed to Save Section Option";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


       
        //Response.Redirect("StudentInstructionSummary.aspx?ExamID=" + Request.QueryString["ExamID"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
    }
}
