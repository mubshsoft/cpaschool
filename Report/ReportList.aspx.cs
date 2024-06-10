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

public partial class Admin_ReportList : System.Web.UI.Page
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

    }

    
 
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
       Response.Redirect("BatchReport.aspx");
    }

  
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("TopicReport.aspx");

    }



    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("FacultyReport.aspx");
    }

    
    protected void LinkButton4_Click(object sender, EventArgs e)
    {

        Page.Response.Redirect("QueryReport.aspx");
    }





    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("StudentNewReport.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("CurrentBatchStatus.aspx");
    }



    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("SuccessfullyCompletedCourseReport.aspx");
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("StudentInMutipleCourseReport.aspx");
    }





}
