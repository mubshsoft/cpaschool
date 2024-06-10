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

public partial class Admin_SignupCriteria : System.Web.UI.Page
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
                hdnCourseId.Value = Request.QueryString["CourseId"];
                BindEvalutionCriteria();

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    public void BindEvalutionCriteria()
    {

        try
        {
            DALExam OBJDALExam = new DALExam();
            LIBExam objLibExam = new LIBExam();
            TransportationPacket tp = new TransportationPacket();
            LIBExamListing objLIBExamListing = new LIBExamListing();
            objLibExam.CourseId = Convert.ToInt32(hdnCourseId.Value);
            tp.MessagePacket = (object)objLibExam;
            tp = OBJDALExam.GetSignupCriteria(tp);
            objLIBExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLIBExamListing != null)
            {
                if (objLIBExamListing.Count > 0)
                {
                   
                    if (objLIBExamListing[0].ApplicantCategory == true)
                    {
                        chkApplicantCategory.Checked = true;

                    }

                    if (objLIBExamListing[0].CurrentProfession == true)
                    {
                        chkCurrentProfession.Checked = true;

                    }

                    if (objLIBExamListing[0].EvaluationCategory == true)
                    {

                        chkEvaluationCategory.Checked = true;
                    }

                    if (objLIBExamListing[0].EducationalDetails == true)
                    {
                        ChkEduDetails.Checked = true;

                    }

                    if (objLIBExamListing[0].WorkExperience == true)
                    {
                        chkWorkExp.Checked = true;
                    }
                }
            }
        }
        catch (Exception EX)
        {
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.CourseId = Convert.ToInt32(hdnCourseId.Value);

            if (chkApplicantCategory.Checked == true)
            {
                objLibExam.ApplicantCategory = true;
            }
            else
            {
                objLibExam.ApplicantCategory = false;
            }

            if (chkCurrentProfession.Checked == true)
            {
                objLibExam.CurrentProfession = true;
            }
            else
            {
                objLibExam.CurrentProfession = false;
            }

            if (chkEvaluationCategory.Checked == true)
            {
                objLibExam.EvaluationCategory = true;
            }
            else
            {
                objLibExam.EvaluationCategory = false;
            }

            if (ChkEduDetails.Checked == true)
            {
                objLibExam.EducationalDetails = true;
            }
            else
            {
                objLibExam.EducationalDetails = false;
            }

            if (chkWorkExp.Checked == true)
            {
                objLibExam.WorkExperience = true;
            }
            else
            {
                objLibExam.WorkExperience = false;
            }

            
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddSignupCriteria(tp);

            if (addResult > 0)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Signup Criteria Saved Successfully'); location.href='CourseID.aspx' ;", true);
               
            }
            else if (addResult == -11)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Exam Question');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}