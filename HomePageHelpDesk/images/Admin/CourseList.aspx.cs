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
public partial class CourseList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            

            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseListdetails(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            gvQuestionList.DataSource = objLibExamListing;
            gvQuestionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvQuestionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnCourseId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnCourseId")).Value;

        try
        {
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.CourseId = Convert.ToInt32(hdnCourseId);
            tp.MessagePacket = (object)objLibExam;

            addResult = OBJDALExam.DeleteCourseDetail(tp);
           ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Course  Deleted');", true);
            BindCourseList();
           


          
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    
    protected void gvQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            HiddenField hdncourseid = (HiddenField)e.Row.FindControl("hdnCourseId");

            LinkButton l = (LinkButton)e.Row.FindControl("linkAddOption");
            l.PostBackUrl = "~/Admin/AddCourseDetails.aspx?courseid=" + hdncourseid.Value;
            
            LinkButton l2 = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
            l2.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Course Detail ? '); ");


            LinkButton linkEditBanner = (LinkButton)e.Row.FindControl("linkEditBanner");
            linkEditBanner.PostBackUrl = "~/Admin/AddBanner.aspx?courseid=" + hdncourseid.Value;
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


   


    protected void gvQuestionList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("addcoursedetails.aspx");
    }
    protected void gvQuestionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestionList.PageIndex = e.NewPageIndex;
        BindCourseList();
    }
}
