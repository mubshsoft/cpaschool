using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Mob_UpcomingEvents : System.Web.UI.Page
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
            {
                bindEvents();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }
    private void bindEvents()
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);
        try
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetAllMobEvents", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                rptrNotList.DataSource = ds;
                rptrNotList.DataBind();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkbtnDelEvent_Command(Object sender, CommandEventArgs e)
    {
        try
        {
            string Id = e.CommandArgument.ToString();
            using (SqlCommand cmd = new SqlCommand("SP_DeleteMobEvent", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Close();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Event Deleted'); </script>");
                bindEvents();
            }
        }
        catch (Exception ex)
        {
        }
    }
}