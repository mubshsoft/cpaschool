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

public partial class Admin_SendNotification : System.Web.UI.Page
{
    SqlConnection con;
    string constring;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        constring = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
        con = new SqlConnection(constring);

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
    protected void btnSendNotification_Click(object sender, EventArgs e)
    {
        try{
            using (SqlCommand cmd = new SqlCommand("SP_AddMobNotification", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", txtNotTitle.Text);
                cmd.Parameters.AddWithValue("@Message", txtNotMessage.Text);
                cmd.Parameters.AddWithValue("@Rurl", txtRefURL.Text);
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
                //send();
                sendPHP();
            }
        }
        catch(Exception ex){
        }
    }
    private void sendPHP()
    {
        string deviceId = "APA91bFLoJq1VydVzvMamAltjGteCm5Iepk88U2nY5CWYvwlorplNljTSCb-w17cfuZ48ZhtY0CmUbawuJsEIr-OjF6TgZGcKfTewShF_cfRDkCdfEM0rUg";
        string message = txtNotMessage.Text;
        string tickerText = "Patient Registration";
        string contentTitle = txtNotTitle.Text;
        string response = "";
        using (SqlCommand cmd = new SqlCommand("SP_GetMobUsers", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@keyId", ddlPPFY.SelectedValue);
            //cmd.Parameters.AddWithValue("@Agid", lblAgeCode.Text);
            con.Close();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();


            dt = ds.Tables[0];
            con.Close();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    deviceId = dt.Rows[i]["keyId"].ToString();

                    string url = "http://accesspgmee.com/SendNotification.php?message=" + message + "&title=" + contentTitle + "&Key=" + deviceId;
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    WebResponse response1 = request.GetResponse();
                    Stream streamResponse = response1.GetResponseStream();
                    //StreamReader streamRead = new StreamReader(streamResponse);
                    //string strResponse = streamRead.ReadToEnd();
                    //XmlTextReader xtr = new XmlTextReader(new System.IO.StringReader(strResponse));
                    //txtXML.Text = strResponse;

                    //response = response + "<br>" + SendGCMNotification("AIzaSyAUKcuHgnzhBK1o2slQm1N-MZ2u-iupSsk", postData);
                }
                txtNotMessage.Text = "";
                txtNotTitle.Text = "";
                txtRefURL.Text = "";
                lblststus.Text = "Notification Sent";
            }



        }
    }
    private void send()
    {
        //RegisterId you got from Android Developer.
        string deviceId = "APA91bFLoJq1VydVzvMamAltjGteCm5Iepk88U2nY5CWYvwlorplNljTSCb-w17cfuZ48ZhtY0CmUbawuJsEIr-OjF6TgZGcKfTewShF_cfRDkCdfEM0rUg";
        string message = txtNotMessage.Text;
        string tickerText = "Patient Registration";
        string contentTitle = txtNotTitle.Text;
        string response = "";
        using (SqlCommand cmd = new SqlCommand("SP_GetMobUsers", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@keyId", ddlPPFY.SelectedValue);
            //cmd.Parameters.AddWithValue("@Agid", lblAgeCode.Text);
            con.Close();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = new DataTable();


            dt = ds.Tables[0];
            con.Close();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    deviceId = dt.Rows[i]["keyId"].ToString();
                    string postData =
                                    "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
                                      "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                                                 "\"title\":\"" + contentTitle + "\", " +
                                                 "\"message\": \"" + message + "\"}}";

                    response = response + "<br>" + SendGCMNotification("AIzaSyAUKcuHgnzhBK1o2slQm1N-MZ2u-iupSsk", postData);
                }
            }


        }

        //Label1.Text = response;
    }


     private string SendGCMNotification(string apiKey, string postData)
   {
       try
       {
       ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

       //  
       //  MESSAGE CONTENT  
       byte[] byteArray = Encoding.UTF8.GetBytes(postData);
       string postDataContentType = "application/json";
       //  
       //  CREATE REQUEST  
       HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
       Request.Method = "POST";
       //  Request.KeepAlive = false;  

       Request.ContentType = postDataContentType;
       Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
       Request.ContentLength = byteArray.Length;

       Stream dataStream = Request.GetRequestStream();
       dataStream.Write(byteArray, 0, byteArray.Length);
       dataStream.Close();

       //  
       //  SEND MESSAGE  
       
           WebResponse Response = Request.GetResponse();

           HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
           if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
           {
               var text = "Unauthorized - need new token";
           }
           else if (!ResponseCode.Equals(HttpStatusCode.OK))
           {
               var text = "Response from web service isn't OK";
           }

           StreamReader Reader = new StreamReader(Response.GetResponseStream());
           string responseLine = Reader.ReadToEnd();
           Reader.Close();
           txtNotMessage.Text = ResponseCode.ToString();
           return responseLine;
       }
       catch (Exception e)
       {
           txtNotMessage.Text = "Not Received: " + e.Message.ToString() ;
       }
       return "error";
   }


     public static bool ValidateServerCertificate(
                                                  object sender,
                                                  X509Certificate certificate,
                                                  X509Chain chain,
                                                  SslPolicyErrors sslPolicyErrors)
     {
         return true;
     }
       
}