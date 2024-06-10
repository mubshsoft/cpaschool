using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using fmsf.DAL;
using fmsf.lib;

public partial class ForgottenPassword : System.Web.UI.Page
{
    SqlConnection con;
    string constring;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            LIBStudent objLIB = new LIBStudent();
            DalAddStudent_CS objDal = new DalAddStudent_CS();
            LIBStudentListing objLibListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIB.StudentEmail = txtEmail.Text.ToString();
            
            tp.MessagePacket = (object)objLIB;

            tp = objDal.GetStudentDetails(tp);
            objLibListing = (LIBStudentListing)tp.MessageResultset;
            if (objLibListing != null)
            {
                if (objLibListing.Count > 0)
                { 
                    var name = objLibListing[0].FirstName.ToString() + " " + objLibListing[0].LastName.ToString();
                    var upassword = objLibListing[0].Password;
                    //sendEmailtoUser(txtEmail.Text, name, upassword); old mail method which was made comment by wahid on 3 oct 2020

                    string strBody = "";

                    strBody = CommonUtility.prcFindInFile(HttpContext.Current.Server.MapPath("Admin/MailFormats/") + "ForgotPassword.htm", "#Name#", name);
                    strBody = CommonUtility.prcFindInString(strBody, "#Password#", upassword);
                    CommonUtility.SendMail(ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[0], ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[1], txtEmail.Text, "", "", "", "Password from fmsflearningsystems ", strBody);

                    lblMessage.Text = "Your password is sent on your email id. !";
                }
                else
                {
                    lblMessage.Text = "Invalid Email !";
                }
            }

           /* constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
            con = new SqlConnection(constring);
            using (SqlCommand cmd = new SqlCommand("SP_getUserDetail", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                con.Close();
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    var name = ds.Tables[0].Rows[0]["firstName"].ToString() + " " + ds.Tables[0].Rows[0]["lastname"].ToString();
                    var upassword = ds.Tables[0].Rows[0]["password"].ToString();
                    sendEmailtoUser(txtEmail.Text, name, upassword);
                }
                else
                {
                    lblMessage.Text = "Invalid Email !";
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }*/
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnlostPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    private void sendEmailtoUser(string uemail, string userName, string userPassword)
    {
        try{
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                mail.From = new MailAddress("coordinator@fmsflearningsystems.org", "FMSF");
                mail.To.Add(uemail);
                mail.Subject = "Password from fmsflearningsystems";
                mail.Body = "<hr/>Dear " + userName + "<br/><br/>  Your password is " + userPassword + "<br/><br/>Please use your password to login  <a href='http://www.fmsflearningsystems.org/Login.aspx' target='_blank'>http://www.fmsflearningsystems.org/Login.aspx";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("coordinator@fmsflearningsystems.org", "fmsf@123");
                
                SmtpServer.Send(mail);
                lblMessage.Text = "Password sent on your email";
        }
        catch(Exception ex){
            lblMessage.Text = "Mail Not Sent!";
        }
    }
}