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
using System.Data.SqlClient;
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_ManageActiveCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCourseList();
        }
    }


    protected void BindCourseList()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();


            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseAllList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdCourse.DataSource = objLibExamListing;
            grdCourse.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdCourse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnApprove = (HiddenField)e.Row.FindControl("hdnApprove");
                CheckBox chk = (CheckBox)e.Row.FindControl("chk");

                if (hdnApprove.Value == "True")
                {
                    chk.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void InsertRecord(object sender, EventArgs e)
    {
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        foreach (GridViewRow row in grdCourse.Rows)
        {
            //if ((row.FindControl("chk") as CheckBox).Checked)
            //{
                HiddenField hdnCourseId = (HiddenField)row.FindControl("hdnCourseId");
                HiddenField hdnbid = (HiddenField)row.FindControl("hdnbid");

                CheckBox chk = (CheckBox)row.FindControl("chk");

                objLIBExam.CourseId =Convert.ToInt32(hdnCourseId.Value);
            objLIBExam.Check = chk.Checked;

                tp.MessagePacket = (object)objLIBExam;
                int addResult = objDalExam.ActiveCourse(tp);

                if (addResult > 0)
                {
                }
            //}
        }

        lblMessage.Visible = true;
        lblMessage.Text = "Course Status Updated Successfully.";
        Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Course Status Updated Successfully.'); </script>");

    }

}