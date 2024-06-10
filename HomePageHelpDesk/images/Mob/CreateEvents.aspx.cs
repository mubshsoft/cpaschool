using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Mob_CreateEvents : System.Web.UI.Page
{
    SqlConnection con;
    string constring;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "MobAdmin")
            { }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }
    protected void btnCreateEvent_Click(object sender, EventArgs e)
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);

        try
        {
            using (SqlCommand cmd = new SqlCommand("SP_CreateMobEvents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@EventDate", txtEventDate.Text);
                cmd.Parameters.AddWithValue("@Message", txtMessage.Text);
                cmd.Parameters.AddWithValue("@Eurl", txtRefURL.Text);
                cmd.Parameters.AddWithValue("@Img", "");
                con.Close();
                con.Open();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //DataTable dt = new DataTable();


                //dt = ds.Tables[0];
                cmd.ExecuteNonQuery();
                con.Close();
                lblststus.Text = "Event Created";
                txtEventDate.Text = "";
                txtMessage.Text = "";
                txtRefURL.Text = "";
                txtTitle.Text = "";
            }
        }
        catch (Exception ex)
        {
        }
    }
}