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

public partial class ScreeningLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if(Convert.ToInt16(txtUsername.Text.Length)<= 0)
        {
            lblMessage.Text = "Username cannot be left blank";
            return;
        }


         if(Convert.ToInt16(txtPassword.Text.Length) <= 0)
        {
            lblMessage.Text = "Password cannot be left blank";
            return;
        }
        

        DataSet dss = new DataSet();
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.UserName = txtUsername.Text;
            objLIBScreening.Password = txtPassword.Text;
            tp.MessagePacket = (object)objLIBScreening;

            dss = objDalScreening.UserAurhnticate(tp);
            if (dss != null)
                if (dss != null)
                {
                    if (dss.Tables != null)
                    {
                        if (dss.Tables[0].Rows.Count>0)
                        {
                            Session["Screeningusername"] = txtUsername.Text;
                            Response.Redirect("~/Student/ScreeningSet.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Invalid User";
                         }
                    }
                }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
}
