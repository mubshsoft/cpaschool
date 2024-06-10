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

public partial class FacultyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("StudentPanel.aspx");

            }
            if (!Page.IsPostBack)
            {

                ViewState["chk"] = "1";
                BindCorseDropDown();
               

            }
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
            objLIBExam.Stid =Convert.ToInt32(Session["stid"]);
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseBYid(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select Course-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex == 0)
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        Session["Course"] = ddlCourse.SelectedItem.Text;
        ViewState["chk"] = "2";
        BindFacultySetList(CourseId);

        DataTable  dtt = new DataTable();
        dtt = (DataTable)ViewState["dt"];

        ddlPaper.DataSource = dtt.DefaultView.ToTable(true, "paperId", "PaperTitle");
        ddlPaper.DataTextField = "PaperTitle";
        ddlPaper.DataValueField = "paperId";
        ddlPaper.DataBind();
        ddlPaper.Items.Insert(0, "SELECT");
    }

    protected void ddlPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            DataTable dtt = new DataTable();
            dtt = (DataTable)ViewState["dt"];

            DataView dataView = dtt.DefaultView;
            if (!string.IsNullOrEmpty(ddlPaper.SelectedValue))
            {
                dataView.RowFilter = "paperId = '" + ddlPaper.SelectedValue + "'";
            }

           
            grdFacultySet.DataSource = dataView;
            grdFacultySet.DataBind();

           
        }
    }
    protected void BindFacultySetList(int courseid)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.Stid = Convert.ToInt32(Session["stid"]);
            objLIBExam.CourseId = courseid;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetFacultySetList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;

            grdFacultySet.DataSource = objLibExamListing;
            grdFacultySet.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Fid"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("SemesterTitle"));
            dt.Columns.Add(new DataColumn("ModuleTitle"));
            dt.Columns.Add(new DataColumn("PaperTitle"));
            dt.Columns.Add(new DataColumn("paperId"));


            for (int i=0;i< objLibExamListing.Count;i++)
            {
                DataRow row = dt.NewRow();

                row["fid"] = objLibExamListing[i].fid;
                row["Name"] = objLibExamListing[i].Name;
                row["SemesterTitle"] = objLibExamListing[i].SemesterTitle;
                row["ModuleTitle"] = objLibExamListing[i].ModuleTitle;
                row["PaperTitle"] = objLibExamListing[i].PaperTitle;
                row["paperId"] = objLibExamListing[i].paperId;
                dt.Rows.Add(row);
            }
            ViewState["dt"] = dt;

           

            


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdFacultySet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        grdFacultySet.PageIndex = e.NewPageIndex;
        if (ViewState["chk"].ToString() == "1")
        {
            BindCorseDropDown();
        }
        else
        {
            int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            BindFacultySetList(CourseId);
        }
       
       
    }
}
