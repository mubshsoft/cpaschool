using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Defibrillator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string strSessionTimeOut = System.Configuration.ConfigurationManager.AppSettings["SessionTimeOut"].ToString();
        //int TimeOut = Convert.ToInt32(strSessionTimeOut);
        //Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) - TimeOut));

    }
}
