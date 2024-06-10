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


public partial class Admin_CourseID : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                BindCourseList();
            }
        }
             catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }



    protected void BindCourseList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetCourseList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdCourseID.DataSource = objLibExamListing;
            grdCourseID.DataBind();
            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdCourseID_DataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                HiddenField hdnCourseId = (HiddenField)e.Row.FindControl("hdnCourseId");



                LinkButton l = (LinkButton)e.Row.FindControl("lnkEdit");
                LinkButton lnkSignup = (LinkButton)e.Row.FindControl("lnkSignup");

                l.PostBackUrl = "~/Admin/AddEvaluationCriteria.aspx?CourseId=" + hdnCourseId.Value;
                lnkSignup.PostBackUrl = "~/Admin/SignupCriteria.aspx?CourseId=" + hdnCourseId.Value;


            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }




    }
   
    protected void grdCourseID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCourseID.PageIndex = e.NewPageIndex;
        BindCourseList();
    } 
}


