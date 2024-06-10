using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_AllNotification : System.Web.UI.Page
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
        bindAllNotifications();
    }
    private void bindAllNotifications()
    {
        
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);
        try
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetAllNotification", con))
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

    protected void lnkbtnDelNote_Command(Object sender, CommandEventArgs e)
    {
        try
        {
            string Id = e.CommandArgument.ToString();
            using (SqlCommand cmd = new SqlCommand("SP_DeleteNotification", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",Id);
                con.Close();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Notification Deleted'); </script>");
                bindAllNotifications();
            }
        }
        catch (Exception ex)
        {
        }
    }
}