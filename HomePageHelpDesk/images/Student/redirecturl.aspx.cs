using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

public partial class Student_redirecturl : System.Web.UI.Page
{
    protected IntegrationKit.libfuncs myUtility = new IntegrationKit.libfuncs();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                populate(sender, e);
            }
        }
        catch (Exception ex)
        {
            //MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }
        finally
        {
           
        }
    }
    /// <summary>
    /// ABCP_ID()   RS
    /// (Checksum = "true") AndAlso (AuthDesc = "Y") - 1        
    /// (Checksum = "true") AndAlso (AuthDesc = "B") - 2
    /// ABCP_ID   USD
    /// (Checksum = "true") AndAlso (AuthDesc = "Y") - 11
    /// (Checksum = "true") AndAlso (AuthDesc = "B") - 21
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks></remarks>
    protected void populate(object sender, EventArgs e)
    {
        string WorkingKey = null;
        string Order_Id = null;
        string Merchant_Id = null;
        string Amount = null;
        string AuthDesc = null;
        string Checksum = null;
  
        try
        {
            //Assign following values to send it to verifychecksum function. 
            WorkingKey = "h78037bgnmafx703u1";
            // put in the 32 bit working key in the quotes provided here 
            Merchant_Id = Request.Form["Merchant_Id"];
            Order_Id = Request.Form["Order_Id"];
            Amount = Request.Form["Amount"];
            AuthDesc = Request.Form["AuthDesc"];
            Checksum = Request.Form["Checksum"];
            Checksum = myUtility.verifychecksum(Merchant_Id, Order_Id, Amount, AuthDesc, WorkingKey, Checksum);
            string ABCP_SiteTransactionId = "";
           string ABCP_CurrId = "";

            string ABCP_OrderDetails = "";
            string ABCP_DisplayResponse = "";
            string ABCP_BankTransactionId ="";
            string ABCP_BankAuthorisationCode = "";
            string ABCP_Method = "";
            string ABCP_MethodCode ="";
            string ABCP_SiteId = "";
       
        //#*#*#*#*#*#*#*#*#*#*#*
        int ABCP_Status = 0;
        int ABCP_ID = 1;
        try
        {
            if (Session["TID"] != null)
            {
                ABCP_SiteTransactionId = Session["TID"].ToString();
            }
            if (Request.Form["Merchant_Param"] != null)
            {
                ABCP_CurrId = Request.Form["Merchant_Param"].ToString().Split(new char[] { ',' })[1].ToString();
            }
            if (Request.Form["Notes"] != null)
            {
                ABCP_OrderDetails = Request.Form["Notes"].ToString();
            }
            if (Request.Form["AuthDesc"] != null)
            {
                ABCP_DisplayResponse = Request.Form["AuthDesc"].ToString();
            }
            if (Request.Form["nb_bid"] != null)
            {
                ABCP_BankTransactionId = Request.Form["nb_bid"].ToString();
            }
            if (Request.Form["nb_order_no"] != null)
            {
                ABCP_BankAuthorisationCode = Request.Form["nb_order_no"].ToString();
            }
            if (Request.Form["card_category"] != null)
            {
                ABCP_Method = Request.Form["card_category"].ToString();
            }
            if (Request.Form["bank_name"]!=null)
            {
                ABCP_MethodCode = Request.Form["bank_name"].ToString();
            }
            if (Session["Webname"] != null)
            {
                ABCP_SiteId = Session["Webname"].ToString();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString() + " Method name : " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }
        //Dim ABCP_SiteId = "www.Jaypeejournals.com"
        //#*#*#*#*#*#*#*#*#*#*#*
        string status = "";
        //##############
        bool paymentstatus = false;
        if ((Checksum == "true") && (AuthDesc == "Y" || AuthDesc == "B"))
        {
            status = " Status: Success";
            paymentstatus = true;
            ABCP_Status = 1;
            //sqlstr11 = "Update UserJournal set PaymentStatus=1 Where TID=" + Session("TID");
        }
        else if ((Checksum == "true") && (AuthDesc == "N"))
        {
            status = " Status: Failed";
            paymentstatus = false;
        }
        else
        {
            status = " Status: Error";
            paymentstatus = false;
        }
       

        try
        {
            int Result = 0;
            DALOnlinePayments objDALOnlinePayments = new DALOnlinePayments();
            LIBOnlinePayments objLibOnlinePayments = new LIBOnlinePayments();
            TransportationPacket tp = new TransportationPacket();
            objLibOnlinePayments.Status = ABCP_Status;
            objLibOnlinePayments.ID = ABCP_ID;
            objLibOnlinePayments.SiteId = ABCP_SiteId;
            objLibOnlinePayments.SiteTransactionId = ABCP_SiteTransactionId;
            objLibOnlinePayments.OrderID = Order_Id.ToString();
            objLibOnlinePayments.BankTransactionId = ABCP_BankTransactionId;
            objLibOnlinePayments.BankAuthorisationCode = ABCP_BankAuthorisationCode;
            objLibOnlinePayments.DisplayResponse = ABCP_DisplayResponse;
            objLibOnlinePayments.CurrId = ABCP_CurrId;
            objLibOnlinePayments.Method = ABCP_Method;
            objLibOnlinePayments.MethodCode = ABCP_MethodCode;
            
            objLibOnlinePayments.PaymentStatus = paymentstatus;
            //objLibOnlinePayments.TID = ABCP_SiteTransactionId;
           
            tp.MessagePacket = (object)objLibOnlinePayments;

            Result = objDALOnlinePayments.UpdateOnlinePayment(tp);


        }
        catch (Exception ex)
        {

            HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString() + " Method name : " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }
        prcEmail2User(status, ABCP_CurrId);
        }
        catch (Exception ex)
        {
            // MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

    }

    protected DataSet Details()
    {
        DataSet dsDetail = new DataSet();
        try
        {

            LIBOnlinePayments objLibPayment = new LIBOnlinePayments();
            DALOnlinePayments objDALPayment = new DALOnlinePayments();

            objLibPayment.CourseId = Convert.ToInt32(Session["cid"].ToString());
            objLibPayment.stid =Convert.ToInt32(Session["stid"].ToString());
            objLibPayment.PaymentMode = "Online";

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLibPayment;
            dsDetail = objDALPayment.GetUserPaymentsDetails(tp);
        }
        catch (Exception ex)
        {
        }
        return dsDetail;
    }
    private void prcEmail2User(string status, string priceSymbol)
    {
        try
        {
             DataSet dsDetail = new DataSet();
            dsDetail=Details();
            string sBody;

            string strStatus = status;
            if (status == " Status: Failed")
            {
                strStatus = "<span style='color:Red; font-weight:bold;'> Status: Failed</span>";
            }
            else if (status == " Status: Error")
            {
                strStatus = "<span style='color:Red; font-weight:bold;'> Status: Failed</span>";
            }
            else
            {
                strStatus = status;
            }

            if (dsDetail != null)
            {
                if (dsDetail.Tables != null)
                {
                    if (dsDetail.Tables[0].Rows != null)
                    {
                        if (dsDetail.Tables[0].Rows.Count > 0)
                        {
                            sBody = "Dear Customer,<br><br>Your purchase details are as below:<br><br>";
                            sBody = sBody + "User : " + dsDetail.Tables[0].Rows[0]["UserName"].ToString();
                            sBody = sBody + "<BR><BR>" + "  Transaction ID : " + Session["TID"].ToString();
                            sBody = sBody + "<BR><BR>" + "  Article details : " + dsDetail.Tables[0].Rows[0]["details"].ToString();
                            sBody = sBody + "<BR><BR>" + "  Price : " + priceSymbol + " " + dsDetail.Tables[0].Rows[0]["price"].ToString();
                            sBody = sBody + "<BR><BR>" + strStatus;
                            sBody = sBody + "<BR><BR>" + "  Date & Time : " + dsDetail.Tables[0].Rows[0]["PurDate"].ToString() + "<BR>";
                            sBody = sBody + "<BR><BR>" + " Thank you for shopping with us. You can access your article within 24 hours after verifying your transaction  " + "<BR>" + "<BR>";
                            
                            CommonUtility.SendMail(ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[0], ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[1], dsDetail.Tables[0].Rows[0]["EmailID"].ToString(), "", "", "", "Payment Success", sBody);
                            lblMessage.Text = sBody;
                        }
                    }
                }
            }
           
            
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString());
        }
    }

 

    protected void lnkhome_Click(object sender, System.EventArgs e)
    {
        try
        {
            Response.Redirect("StudentPanel.aspx", false);

        }
        catch (Exception ex)
        {
        }
    }

}
