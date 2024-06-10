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

public partial class Admin_StudentInMutipleCourseReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
            if (!Page.IsPostBack)
            {
                BindGrid1();
            }
        }


        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }



    protected void BindGrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            lblshowdate.Text = Convert.ToString(DateTime.Now.ToString());
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objStudent;
            tp = objDalAddStudent_CS.GetStudentsInMultipleCourse(tp);
            objStudentListing = (LIBStudentListing)tp.MessageResultset;

            grdStudentReport.DataSource = objStudentListing;
            grdStudentReport.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;


            
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }



    protected void grdStudentReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdStudentReport.PageIndex = e.NewPageIndex;
            BindGrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}
