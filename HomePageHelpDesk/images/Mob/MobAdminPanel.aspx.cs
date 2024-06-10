using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mob_MobAdminPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["role"]==null){
            Response.Redirect("../Login.aspx");
        }
        else{
            if ((Session["role"].ToString()) == "MobAdmin")
            {}
            else
            {
                Response.Redirect("../Login.aspx");    
            }
        }
    }
}