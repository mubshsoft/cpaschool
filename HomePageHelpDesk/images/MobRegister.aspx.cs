using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;


public partial class MobRegister : System.Web.UI.Page
{
    SqlConnection con;
    string constring;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
            con = new SqlConnection(constring);
            using (SqlCommand cmd = new SqlCommand("SP_AddMobUsers", con))
            {
                string keyId = Request.QueryString["keyId"];
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyId", keyId);
                
                con.Close();
                con.Open();
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception ex)
        {
        }
    }
}