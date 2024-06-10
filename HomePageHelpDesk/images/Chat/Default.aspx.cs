using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Chat_Default : System.Web.UI.Page
{
    SqlConnection con;
    string constring;

    protected void Page_Load(object sender, EventArgs e)
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);
        if (Session["role"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            if ((Session["role"].ToString()) == "Admin" || (Session["role"].ToString()) == "Faculty" || (Session["role"].ToString()) == "Student")
            {
                //one time register for VC
                VCRegister(Session["role"].ToString());
            }
            if ((Session["role"].ToString()) == "Admin" || (Session["role"].ToString()) == "Faculty")
            {
                admin.Visible = true;
            }
            if ((Session["role"].ToString()) == "Student")
            {
                student.Visible = true;
            }
        }
    }

    protected void VCRegister(string userRole)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_geVCUserDetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@userRole", userRole);
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Session["userEmail"] = ds.Tables[0].Rows[0]["userEmail"].ToString();
                Session["userFullName"] = ds.Tables[0].Rows[0]["userName"].ToString();
                registerUser(ds.Tables[0].Rows[0]["userName"].ToString(), ds.Tables[0].Rows[0]["userPassword"].ToString(), ds.Tables[0].Rows[0]["userContact"].ToString(), ds.Tables[0].Rows[0]["userEmail"].ToString());
                con.Close();
            }
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void registerUser(string userName, string userPassword, string userContact, string userEmail)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_RegisterUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);
                cmd.Parameters.AddWithValue("@userContact", userContact);
                cmd.Parameters.AddWithValue("@userEmail", userEmail);
                cmd.Parameters.AddWithValue("@userCompany", "");
                
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