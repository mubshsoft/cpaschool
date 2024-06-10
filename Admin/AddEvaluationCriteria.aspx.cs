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
public partial class AddEvaluationCriteria : System.Web.UI.Page
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

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.CourseId =Convert.ToInt32(hdnCourseId.Value);
            if (chkAssignM.Checked == true)
            {
                objLibExam.AssignmentMarks = true;

            }
            else
            {
                objLibExam.AssignmentMarks = false;
            }
            if (ChkExamM.Checked == true)
            {
                objLibExam.ExamMarks = true;

            }
            else
            {
                objLibExam.ExamMarks = false;
            }
            if (chkDFM.Checked == true)
            {
                objLibExam.DiscussionForumMarks = true;

            }
            else
            {
               objLibExam.DiscussionForumMarks = false;
            }
            if (chkProjectM.Checked == true)
            {
                objLibExam.ProjectMarks = true;

            }
            else
            {
                objLibExam.ProjectMarks = false;
            }

            if (chkCaseStudy.Checked == true)
            {
                objLibExam.CaseStudyMarks = true;

            }
            else
            {
                objLibExam.CaseStudyMarks = false;
            }

            objLibExam.ColumnName1 = (Utility.CheckNullString(txtColumn1.Text));
            objLibExam.ColumnName2 = Utility.CheckNullString(txtColumn2.Text);
            
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddEvaluationCriteria(tp);

            if (addResult > 0)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Evaluation Criteria Saved Successfully');", true);
                Response.Redirect("CourseID.aspx");

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
            tp = OBJDALExam.GetEvaluationCriteria(tp);
            objLIBExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLIBExamListing != null)
            {
                if (objLIBExamListing.Count > 0)
                {
                    txtColumn1.Text = objLIBExamListing[0].ColumnName1;
                    txtColumn2.Text = objLIBExamListing[0].ColumnName2;
                    if (objLIBExamListing[0].AssignmentMarks == true)
                    {
                        chkAssignM.Checked = true;

                    }
                   
                    if (objLIBExamListing[0].ExamMarks == true)
                    {
                        ChkExamM.Checked = true;

                    }

                    if (objLIBExamListing[0].DiscussionForumMarks == true)
                    {
                        
                        chkDFM.Checked = true;
                    }

                    if (objLIBExamListing[0].ProjectMarks == true)
                    {
                        chkProjectM.Checked = true;

                    }

                    if (objLIBExamListing[0].CaseStudyMarks == true)
                    {
                        chkCaseStudy.Checked = true;

                    }



                }
            }
        }
        catch (Exception EX)
        {
        }
    }
}
