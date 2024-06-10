using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class VC : System.Web.UI.Page
{
    SqlConnection con;
    string constring;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userEmail"] == null)
        {
            Response.Redirect("../logout.aspx");
        }
        else
        {
            txtRoomId.Value = Session["RoomId"].ToString();
            txtUserEmail.Value = Session["userEmail"].ToString();
            getRoomDetails(Session["RoomId"].ToString());
            //get list of all members with active members
        }
    }
    protected void getRoomDetails(string RoomId)
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);
       
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_roomDetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomId", RoomId);
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                string[] namesArray = ds.Tables[0].Rows[0]["RoomUsers"].ToString().Split(',');
                rptrVCMembers.DataSource = namesArray;
                rptrVCMembers.DataBind();

                roomUsers.Value = ds.Tables[0].Rows[0]["RoomUsers"].ToString();
                roomOrganiser.Value = ds.Tables[0].Rows[0]["OrganiserEmail"].ToString();
                roomTopic.Value = ds.Tables[0].Rows[0]["RoomTopic"].ToString();
                con.Close();
            }
        }
        catch (Exception ex)
        { }
    }
}