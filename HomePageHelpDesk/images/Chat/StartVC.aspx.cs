using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class StartVC : System.Web.UI.Page
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
            constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
            con = new SqlConnection(constring);
            //getAllActiveUsers
            //Start Room or Join Room 
            // Required information: RoomId, UserDetails
            if (!IsPostBack)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("VCSP_getUserRoom", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"].ToString());
                        con.Close();
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        lblOrganiser.Text = ds.Tables[0].Rows[0]["RoomCreator"].ToString();
                        lblOrganiserEmail.Text = ds.Tables[0].Rows[0]["OrganiserEmail"].ToString();
                        ddlRooms.DataTextField = ds.Tables[0].Columns["RoomName"].ToString();
                        ddlRooms.DataValueField = ds.Tables[0].Columns["RoomId"].ToString();
                        lblTopic.Text = ds.Tables[0].Rows[0]["RoomTopic"].ToString();
                        //lblRoomMembers.Text = ds.Tables[0].Rows[0]["RoomUsers"].ToString().Replace(",", "<br/>");
                        string[] namesArray = ds.Tables[0].Rows[0]["RoomUsers"].ToString().Split(',');
                        createMemberList(namesArray);
                        ddlRooms.DataSource = ds.Tables[0];
                        ddlRooms.DataBind();
                        con.Close();
                        if (ddlRooms.Items.Count > 0)
                        {
                            ddlRooms.Enabled = true;
                            btnSubmit.Visible = true;
                            lblMSG.Visible = false;
                            activeRoomMembers(ddlRooms.SelectedItem.Value);
                        }
                    }
                }
                catch (Exception ex) { }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlRooms.Items.Count > 0)
        {
            Session["RoomId"] = ddlRooms.SelectedItem.Value;
            insertRoomMember();
            Response.Redirect("VC.aspx");
        }
        else
        {

        }
    }
    protected void insertRoomMember()
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_InsertRoomUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomId", Session["RoomId"].ToString());
                cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"].ToString());
                cmd.Parameters.AddWithValue("@RoomType", "VC");
                con.Close();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch (Exception ex)
        { }
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

                lblOrganiser.Text = ds.Tables[0].Rows[0]["RoomCreator"].ToString();
                lblOrganiserEmail.Text = ds.Tables[0].Rows[0]["OrganiserEmail"].ToString();
                lblTopic.Text = ds.Tables[0].Rows[0]["RoomTopic"].ToString();
                string[] namesArray = ds.Tables[0].Rows[0]["RoomUsers"].ToString().Split(',');
                createMemberList(namesArray);
                //txtOrganiserEmail.Text = ds.Tables[0].Rows[0]["OrganiserEmail"].ToString();
                //lblRoomId.Text = RoomId;
                activeRoomMembers(RoomId);
                con.Close();
            }
        }
        catch (Exception ex)
        {}
    }
    protected void createMemberList(string[] namesArray)
    {
        var str = "<ul class='list-group'>";
        for (int i = 0; i < namesArray.Length; i++)
        {
            str += "<li class='list-group-item'><i class='fa fa-user userspan'></i> " + namesArray[i] + "</li>";
        }
        str += "</ul>";
        lblRoomMembers.Text = str;
    }

    protected void activeRoomMembers(string RoomId)
    {
        lblActiveMembers.Text = "";
        try
        {
            using (SqlCommand cmd = new SqlCommand("VCSP_getActiveMembers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomId", RoomId);
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lblActiveMembers.Text = lblActiveMembers.Text + ds.Tables[0].Rows[i]["userEmail"].ToString() +" , ";
                }
                con.Close();
            }
        }
        catch (Exception ex)
        { }
    }
}
