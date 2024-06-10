using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Certificate : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lblname.Text  = Request.QueryString["name"].ToString();
        lblCourse.Text = Request.QueryString["coursecode"].ToString();
        lblStartdate.Text = Request.QueryString["cStartDate"].ToString();
        lblEndtdate.Text = Request.QueryString["cEndDate"].ToString();
        Response.Write("<script>window.print();</script>");
    }
}