using System;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using fmsf.lib;
using fmsf.DAL;
using System.Net.Mail;
public partial class EndScreening : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Screeningusername"] == null)
        {
            Response.Redirect("../Screeninglogin.aspx");
        }
        try
        {

            if (!Page.IsPostBack)
            {

               hdnScrId.Value = Request.QueryString["ScrId"].ToString();
               hdnusername.Value = Request.QueryString["username"].ToString();
                //hdnScrId.Value = Session["ScrId"].ToString();

               string scrMail;
               scrMail = "This " + hdnusername.Value + " has completed the exam.";

               SendMailMessage("fmsf@fmsflearningsystems.org", "coordinator@fmsflearningsystems.org", "", "Screening Exam attempted", scrMail);

                BindQuestionListwithsession();
                EndScreeningTime();
               

            }
          
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       

    }

  
    protected void BindQuestionListwithsession()
    {
        try
        {
           
            
           

            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.UserId = hdnusername.Value;
            

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBScreening;
            int adresult = objDalScreening.GetToatalAttemptQue(tp);

            //lbltxt.Text = "You have successfully completed your Screening for " + Session["paperTitle"].ToString(); ;
            lbltxt.Text = "You have successfully completed your Screening Exam." ; 
            //lbltxt.Text = "You Have successfully completed " + adresult + " Question!" + Session["paperTitle"].ToString();
          
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        Session["Screeningusername"] = "";
        Session.Abandon();
        StringBuilder javaScript = new StringBuilder();

        javaScript.Append("\n<script language=JavaScript>\n");
        javaScript.Append("window.history.forward(1);\n");
        javaScript.Append("</script>\n");

        Page.RegisterClientScriptBlock("HistoryScript", javaScript.ToString());
      
    }

    protected void EndScreeningTime()
    {
        string strQ;
        strQ = "update studentActiveScreening set EndScreeningtime='" + DateTime.Now.ToString() + "' where Scrid='" + hdnScrId.Value + "' and UserId='" + hdnusername.Value.ToString() + "'";
        CLS_C.fnExecuteQuery(strQ);


    }
  
    


   

  
   

  
  

    protected void DLSTSECTION_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {

            DataListItem row = e.Item;
            if (e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hdnQuestionId = (HiddenField)e.Item.FindControl("hdnQuestionId");
                LinkButton lnkbtncatgno = (LinkButton)e.Item.FindControl("lnkbtncatgno");

                LIBScreening objLIBScreening = new LIBScreening();
                DALScreening objDalScreening = new DALScreening();
                LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                objLIBScreening.UserId = Session["Screeningusername"].ToString();
                objLIBScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value); ;

                TransportationPacket tp = new TransportationPacket();
                tp.MessagePacket = (object)objLIBScreening;
                tp = objDalScreening.GetAnsText(tp);
                objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
                if (objLibScreeningListing != null)
                {

                    if (objLibScreeningListing.Count > 0)
                    {
                        lnkbtncatgno.ForeColor = System.Drawing.Color.Red;


                    }
                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    public static void SendMailMessage(string @from, string recepient, string mailCC, string subject, string body)
    {
        try
        {


            MailMessage mMailMessage = new MailMessage();
            mMailMessage.From = new MailAddress(@from);
            mMailMessage.To.Add(new MailAddress(recepient));
            if ((mailCC != null) && (mailCC != string.Empty))
            {

                mMailMessage.CC.Add(new MailAddress(mailCC));
            }
            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
            //Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            //Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0);
            SmtpClient mSmtpClient = new SmtpClient("relay-hosting.secureserver.net");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(@from, "fmsf@123");
            mSmtpClient.Send(mMailMessage);
        }
        catch (Exception ex)
        {

        }
    }
}

