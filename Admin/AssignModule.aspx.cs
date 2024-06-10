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

public partial class Admin_AssignModule : System.Web.UI.Page
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
                BindData();
             
                
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindData()
    {
        try
        {
          DataSet ds=  CLS_C.fnQuerySelectDs("sp_GetListAssignedBatch2Module");
            grdlist.DataSource = ds;
            grdlist.DataBind();
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

         



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "Delete")
        {
           // id = Convert.ToInt32(e.CommandArgument);
            CLS_C.fnExecuteQuery("delete from BatchModule where id=" + e.CommandArgument);
            lblMessage.Text = "Record deleted successfully";
            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            //}
            Response.Redirect(Request.Url.ToString(), false);
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
    long res=    CLS_C.fnExecuteQuery("exec SP_InserModuleassign2Batch " + ddlModule.SelectedValue + "," + ddlCourse.SelectedValue + "," + ddlBatch.SelectedValue);
    BindData();
        //try
        //{
            

        //    int addResult = 0;
           
        //    LIBExam objLIBExam = new LIBExam();
        //    DALExam objDalExam = new DALExam();
        //    TransportationPacket tp = new TransportationPacket();
        //    objLIBExam.examcode = txtexamcode.Text;
        //    objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
        //    objLIBExam.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
        //    objLIBExam.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
        //    objLIBExam.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
        //    objLIBExam.TimeAllowted  = Convert.ToInt32(txtTimeAllowted.Text)* 60;
        //    tp.MessagePacket = (object)objLIBExam;
        //    addResult = objDalExam.AddExamSet(tp);

        //    if (addResult > 0)
        //    {
        //        //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam created successfully');", true);
        //        //lblMessage.Text = "Exam Set Saved Successfully";
        //        txtexamcode.Text = "";
        //        BindExamSetList();
        //        ddlCourse.SelectedIndex = 0;
        //        ddlModule.SelectedIndex = 0;
        //        ddlPaper.SelectedIndex = 0;
        //        ddlSem.SelectedIndex = 0;
        //        txtTimeAllowted.Text = "";
        //    }
        //    else if (addResult == -11)
        //    {
        //        //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
        //        lblMessage.Text = "Duplicate Exam Set";

        //    }

        //    else
        //    {
        //        //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
        //        lblMessage.Text = "Failed to Save Exam Set";

        //    }
        //}
        //catch (Exception ex)
        //{
        //    HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        //}

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCourse.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
                lblreqcourse.Text = "Select Course";
                return;
            }


            DataSet ds = CLS_C.fnQuerySelectDs("select * from batch where courseid=" + ddlCourse.SelectedValue);
            ddlBatch.DataSource = ds;
            ddlBatch.DataTextField = "batchcode";
            ddlBatch.DataValueField = "bid";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, "-Select-");

            DataSet ds1 = CLS_C.fnQuerySelectDs("select * from module where semid in (select SemID from Semester where courseid=" + ddlCourse.SelectedValue + ")");
            ddlModule.DataSource = ds1;
            ddlModule.DataTextField = "Moduletitle";
            ddlModule.DataValueField = "moduleid";
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, "-Select-");
        }
        catch (Exception ex)
        {
        }

    }
    
}
