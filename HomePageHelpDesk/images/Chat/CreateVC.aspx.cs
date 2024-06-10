using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class CreateVC : System.Web.UI.Page
{
    SqlConnection con;
    string constring;

    protected void Page_Load(object sender, EventArgs e)
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);
        string RoomName = Random("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 14);
        lblRoomId.Text = RoomName;
        if (Session["role"] == null)
        {
            Response.Redirect("../Login.aspx");
        }
        else
        {
            if ((Session["role"].ToString()) == "Faculty" || (Session["role"].ToString()) == "Admin")
            {
                bindRooms();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
    protected void bindRooms()
    {
        txtOrganiserEmail.Text = Session["userEmail"].ToString();
        txtVCRoomCreator.Text = Session["userFullName"].ToString();
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_getRooms", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrganiserEmail", Session["userEmail"].ToString());
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddlRooms.DataTextField = ds.Tables[0].Columns["RoomName"].ToString();
                ddlRooms.DataValueField = ds.Tables[0].Columns["RoomId"].ToString();
                ddlRooms.DataSource = ds.Tables[0];
                ddlRooms.DataBind();
                con.Close();
            }
        }
        catch (Exception ex)
        {
            lblVCRoom.Text = "<font style='color:Red'>Error while creating Room [" + ex.Message + "]</font>";
        }
    }

    private string Random(string chars, int length)
    {
        var randomString = new StringBuilder();
        var random = new Random();

        for (int i = 0; i < length; i++)
            randomString.Append(chars[random.Next(chars.Length)]);

        return randomString.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            var members = txtMembers.Text.Split(',');
            int RoomSize = members.Length;
            txtMembers.Text = txtOrganiserEmail.Text + ", " + txtMembers.Text;
            using (SqlCommand cmd = new SqlCommand("VCSP_CreateRoom", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoomName", txtRoomName.Text);
                cmd.Parameters.AddWithValue("@RoomDate", txtRoomDate.Text);
                cmd.Parameters.AddWithValue("@RoomCreator", txtVCRoomCreator.Text);
                cmd.Parameters.AddWithValue("@RoomTopic", txtConfTopic.Text);
                cmd.Parameters.AddWithValue("@RoomId", lblRoomId.Text);
                cmd.Parameters.AddWithValue("@RoomUsers", txtMembers.Text);
                cmd.Parameters.AddWithValue("@RoomStatus", "Active");
                cmd.Parameters.AddWithValue("@RoomType", "VC");
                cmd.Parameters.AddWithValue("@RoomSize", RoomSize);
                cmd.Parameters.AddWithValue("@OrganiserEmail", txtOrganiserEmail.Text);
                con.Close();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                bindRooms();
                lblVCRoom.Text = "<font style='color:green'>Room Create Successfuly with " + RoomSize + " members</font>";
                txtRoomName.Text = txtVCRoomCreator.Text = txtConfTopic.Text = txtMembers.Text = txtOrganiserEmail.Text = "";
                //send mails to all members about room created
                //sendMail(members);
            }
        }
        catch (Exception ex)
        {
            lblVCRoom.Text = "<font style='color:Red'>Error while creating Room [" + ex.Message + "]</font>";
        }
    }
    protected void ddlRooms_SelectedIndexChanged(object sender, EventArgs e)
    {
        var RoomId = ddlRooms.SelectedItem.Value;
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

                txtRoomName.Text = ds.Tables[0].Rows[0]["RoomName"].ToString();
                txtVCRoomCreator.Text = ds.Tables[0].Rows[0]["RoomCreator"].ToString();
                txtConfTopic.Text = ds.Tables[0].Rows[0]["RoomTopic"].ToString();
                txtMembers.Text = ds.Tables[0].Rows[0]["RoomUsers"].ToString();
                txtOrganiserEmail.Text = ds.Tables[0].Rows[0]["OrganiserEmail"].ToString();
                lblRoomId.Text = RoomId;
                con.Close();
            }
        }
        catch (Exception ex)
        {
            lblVCRoom.Text = "<font style='color:Red'>Error while creating Room [" + ex.Message + "]</font>";
        }
    }
}