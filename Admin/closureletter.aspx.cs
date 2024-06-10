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

public partial class Admin_closureletter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["stid"].ToString()!="" && Request.QueryString["bt"].ToString() !="")
            {
                lblName.Text = Request.QueryString["stid"].ToString();
                lblbatch.Text = Request.QueryString["bt"].ToString();
                lblCourse.Text = Request.QueryString["coursecode"].ToString();

                lblDate.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                Response.Write("<script>window.print();</script>");
            }
        }
    }

    private int Len(string p)
    {
        throw new NotImplementedException();
    }
}
