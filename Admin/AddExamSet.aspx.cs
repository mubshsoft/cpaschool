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
using System.Data.SqlClient;

public partial class Admin_AddExamSet : System.Web.UI.Page
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
            if (Session.Count <= 0)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!Page.IsPostBack)
            {

                BindCorseDropDown();
                BindExamSetList();
                DataSet dsyear = CLS_C.fnQuerySelectDs("SP_GetYearList");
                ddlyear.DataSource = dsyear;
                ddlyear.DataTextField = "year";
                ddlyear.DataValueField = "year";
                ddlyear.DataBind();
                ddlyear.Items.Insert(0, "-Select-");

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
            int courseid = 0;
            int year = 0;
            if (ddlcoursefillter.SelectedItem.Text != "-Select-")
            {
                courseid = Convert.ToInt32(ddlcoursefillter.SelectedValue); 
            }
            if (ddlyear.SelectedItem.Text != "--Select--")
            {
                year = Convert.ToInt32(ddlyear.SelectedValue);
            }
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = courseid;
            objLIBExam.Year = year;
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetExamSetList_(tp);
         
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdExamSet.DataSource = objLibExamListing;
            grdExamSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindCorseDropDown()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourse(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0,"-Select-");

            ddlcoursefillter.DataSource = objLibExamListing;
            ddlcoursefillter.DataTextField = objLIBExam.CourseDispalyText;
            ddlcoursefillter.DataValueField = objLIBExam.CourseValueField;
            ddlcoursefillter.DataBind();
            ddlcoursefillter.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindSemesterDropDown(int CourseId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = CourseId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSemester(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlSem.DataSource = objLibExamListing;
            ddlSem.DataTextField = objLIBExam.SemesterDispalyText;
            ddlSem.DataValueField = objLIBExam.SemesterValueField;
            ddlSem.DataBind();
            ddlSem.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindModuleDropDown(int SemId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.SemesterId = SemId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetModule(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlModule.DataSource = objLibExamListing;
            ddlModule.DataTextField = objLIBExam.ModuleDispalyText;
            ddlModule.DataValueField = objLIBExam.ModuleValueField;
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindPaperDropDown(int ModuleId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ModuleId = ModuleId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetPaper(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlPaper.DataSource = objLibExamListing;
            ddlPaper.DataTextField = objLIBExam.PaperDispalyText;
            ddlPaper.DataValueField = objLIBExam.PaperValueField;
            ddlPaper.DataBind();
            ddlPaper.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        else
        {
            lblreqcourse.Text = "";

        }
        if (ddlPaper.Items.Count>0)
        {
        if (ddlPaper.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Paper'); </script>");
            lblreqpaper.Text = "Select Paper";
            return;
        }
        else
        {
            lblreqpaper.Text = "";

        }
        }
        if (ddlModule.Items.Count > 0)
        {
            if (ddlModule.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
                lblreqmodule.Text = "Select Module";
                return;
            }
            else
            {
                lblreqmodule.Text = "";
            }
        }
        if (ddlSem.Items.Count > 0)
        {
            if (ddlSem.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
                lblreqsem.Text = "Select Semester";
                return;
            }
            else
            {
                lblreqsem.Text = "";
            }

        }
        try
        {
            if (string.IsNullOrEmpty(txtTimeAllowted.Text))
            {
                lblTimeReq.Text = "Enter Time Period for the Exam Set";
                return;
            }
            else
            {
                lblTimeReq.Text = "";
            }

           
            if (string.IsNullOrEmpty(txtexamcode.Text))
            {
                lblreqexamcode.Text = "Enter Exam Code";
                return;
            }
            else
            {
                lblreqexamcode.Text = "";
            }


            int addResult = 0;
           
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.examcode = txtexamcode.Text;
            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
            objLIBExam.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
            objLIBExam.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
            objLIBExam.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
            objLIBExam.TimeAllowted  = Convert.ToInt32(txtTimeAllowted.Text)* 60;
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddExamSet(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam created successfully');", true);
                //lblMessage.Text = "Exam Set Saved Successfully";
                txtexamcode.Text = "";
                BindExamSetList();
                ddlCourse.SelectedIndex = 0;
                ddlModule.SelectedIndex = 0;
                ddlPaper.SelectedIndex = 0;
                ddlSem.SelectedIndex = 0;
                txtTimeAllowted.Text = "";
            }
            else if (addResult == -11)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
                lblMessage.Text = "Duplicate Exam Set";

            }

            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
                lblMessage.Text = "Failed to Save Exam Set";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        BindSemesterDropDown(CourseId);
        LIBExam objLibExam = new LIBExam();

        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLibExam.CourseId = CourseId;

        tp.MessagePacket = (object)objLibExam;

        hdncoursecode.Value = objDalExam.GetCourseCodeByID(tp);

    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSem.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
            lblreqsem.Text = "Select Semester";
            return;
        }
        int semId = Convert.ToInt32(ddlSem.SelectedValue);
        BindModuleDropDown(semId);
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModule.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
            lblreqmodule.Text = "Select Module";
            return;
        }
        int ModuleId = Convert.ToInt32(ddlModule.SelectedValue);
        BindPaperDropDown(ModuleId);


    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
                LinkButton lnkEditExam = (LinkButton)e.Row.FindControl("lnkEditDetailsExam");
                LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopyExam");
                HiddenField hdnExamID = (HiddenField)e.Row.FindControl("hdnExamID");
                Label examcode = (Label)e.Row.FindControl("lblexamcodeNo");
                valu.PostBackUrl = "~/Admin/AddSelectSection.aspx?ExamID=" + hdnExamID.Value;
                lnkEditExam.PostBackUrl = "~/Admin/SelectSection.aspx?ExamID=" + hdnExamID.Value;
                copyques.PostBackUrl = "~/Admin/CopyQuestion.aspx?ExamID=" + hdnExamID.Value +"&examcode="+examcode.Text;

                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteExamSet");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Exam Set ? '); ");



            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void chkuseexam_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grdExamSet.Rows)
        {
            LinkButton valu = (LinkButton)gv.FindControl("lnkDetailsExam");
            LinkButton copyques = (LinkButton)gv.FindControl("lnkCopyExam");
            HiddenField hdnExamID = (HiddenField)gv.FindControl("hdnExamID");

            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.ExamId = Convert.ToInt32(hdnExamID.Value);

            tp.MessagePacket = (object)objLibExam;
              int maxque = OBJDALExam.GetMaxQuesNo(tp);
            if (chkuseexam.Checked == true)
            {
                valu.Visible = false;
                copyques.Visible = true;
                if (maxque == -1)
                {
                    copyques.Enabled = false;
                }
            }
            else
            {
                valu.Visible = true;
                copyques.Visible = false;
            }
        }
    }
    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "Delete")
        {
            id = Convert.ToInt32(e.CommandArgument);
            //string strChk = "select es.ExamId from ExamSet es INNER JOIN EXAM_CATEGORY ec on es.ExamId=ec.ExamId where es.ExamId=" + id;
           DALExam objDalExam = new DALExam();
            //DataSet ds = new DataSet();
            //DataTable dtt = new DataTable();
            //dtt = objDalExam.getdata(strChk);
            //if (dtt.Rows.Count > 0)
            //{
            //    lblMessage.Text = "Exam has some section - can't be deleted";
            //}
            //else
            //{
                string str = "update ExamSet set active=0 where ExamId=" + id;
                objDalExam.ExeNQcomsp(str);
                lblMessage.Text = "Record deleted successfully";
                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            //}
            BindExamSetList();
        }
    }
    protected void grdExamSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdExamSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdExamSet.EditIndex = e.NewEditIndex;
        BindExamSetList();
    }
    protected void grdExamSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdExamSet.EditIndex = -1;
        BindExamSetList();

    }
    protected void grdExamSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnExamID = ((HiddenField)grdExamSet.Rows[e.RowIndex].FindControl("hdnExamID")).Value;
            TextBox txtTimeAllowted = (TextBox)grdExamSet.Rows[e.RowIndex].FindControl("txtTimeAllowted");
           
           
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLibExam.ExamId = Convert.ToInt32(hdnExamID);
            objLibExam.TimeAllowted = Convert.ToInt32(txtTimeAllowted.Text);
          
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.UpdateExamSet(tp);

            if (addResult > 0)
            {
                grdExamSet.EditIndex = -1;

             
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Examset Updated');", true);
                BindExamSetList();
            }
            else if (addResult == -11)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Examset');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Examset');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdExamSet.PageIndex = e.NewPageIndex;
            BindExamSetList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    //public static void ExeNQcomsp(string strQ)
    //{
    //    String strSQLConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;

    //    SqlConnection con = new SqlConnection(strSQLConnectionString);

    //    SqlCommand ObjSqlCommand = null;
    //    int intReturnValue = 0;
    //    try
    //    {
    //        con.Open();
    //        ObjSqlCommand = new SqlCommand(strQ, con);
    //        intReturnValue = ObjSqlCommand.ExecuteNonQuery();
    //        ObjSqlCommand.Connection.Close();


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //} 

    protected void ddlcoursefillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindExamSetList();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindExamSetList();
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
