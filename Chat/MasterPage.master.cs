using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con;
    string constring;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userEmail"] == null)
        {
            //Response.Redirect("Default-new.aspx");
        }
        else
        {

            getUserDetail(Session["userEmail"].ToString());
        }
    }
    protected void getUserDetail(string userEmail)
    {
        try
        {
            constring = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            con = new SqlConnection(constring);
            using (SqlCommand cmd = new SqlCommand("SP_getUserDetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userEmail", userEmail);
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lblUserName.Text = ds.Tables[0].Rows[0]["userName"].ToString();
                lblUserEmail.Text = ds.Tables[0].Rows[0]["userContact"].ToString(); ;
                lblUserImage.Text = "<img class='img-circle' src='https://s3.amazonaws.com/uifaces/faces/twitter/jsa/48.jpg' alt='User Image'>";
                con.Close();
            }
        }
        catch (Exception ex)
        { }

    }
}
