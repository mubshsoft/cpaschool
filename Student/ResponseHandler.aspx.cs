using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using System.Data;
using fmsf.lib;
using fmsf.DAL;
using System.Configuration;

public partial class Student_ResponseHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string workingKey = "236A94A1F0124CAD7E69BABC2D78EF05";//put in the 32bit alpha numeric key in the quotes provided here
        CCACrypto ccaCrypto = new CCACrypto();
        string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
        NameValueCollection Params = new NameValueCollection();
        string[] segments = encResponse.Split('&');
        foreach (string seg in segments)
        {
            string[] parts = seg.Split('=');
            if (parts.Length > 0)
            {
                string Key = parts[0].Trim();
                string Value = parts[1].Trim();
                Params.Add(Key, Value);
            }
        }

       
    
        string Order_Id = null;
        string Merchant_Id = "391205";
        string Amount = null;
        string AuthDesc = null;
        string Checksum = null;
        string ABCP_SiteTransactionId = "";
        string ABCP_CurrId = "";

        string ABCP_OrderDetails = "";
        string ABCP_DisplayResponse = "";
        string ABCP_BankTransactionId = "";
        string ABCP_BankAuthorisationCode = "";
        string ABCP_Method = "";
        string ABCP_MethodCode = "";
        string ABCP_SiteId = "";

        //#*#*#*#*#*#*#*#*#*#*#*
        int ABCP_Status = 0;
        int ABCP_ID = 1;
        try
        {
            for (int i = 0; i < Params.Count; i++)
            {
                Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                if (Params.Keys[i] == "order_id")
                {
                    Order_Id = Params[i];
                }
                if (Params.Keys[i] == "order_status")
                {
                    AuthDesc = Params[i];
                }

                if (Params.Keys[i] == "amount")
                {
                    Amount = Params[i];
                }
                if (Params.Keys[i] == "status_message")
                {
                    ABCP_OrderDetails = Params[i];
                }
                if (Params.Keys[i] == "currency")
                {
                    ABCP_CurrId = Params[i];
                }
                if (Params.Keys[i] == "response_code")
                {
                    ABCP_DisplayResponse = Params[i];
                }
                if (Params.Keys[i] == "payment_mode ")
                {
                    ABCP_Method = Params[i];
                }
                if (Params.Keys[i] == "bene_bank ")
                {
                    ABCP_MethodCode = Params[i];
                }
                if (Params.Keys[i] == "response_code")
                {
                    ABCP_BankAuthorisationCode = Params[i];
                }
                if (Params.Keys[i] == "bank_ref_no ")
                {
                    ABCP_BankTransactionId = Params[i];
                }
            }
      
           if (Session["TID"] != null)
                {
                    ABCP_SiteTransactionId = Session["TID"].ToString();
                } 
           
          
        
           
               
               
                if (Session["Webname"] != null)
                {
                    ABCP_SiteId = Session["Webname"].ToString();
                }
           
            //Dim ABCP_SiteId = "www.Jaypeejournals.com"
            //#*#*#*#*#*#*#*#*#*#*#*
            string status = "";
            //##############
            bool paymentstatus = false;
            if ((AuthDesc == "Success"))
            {
                status = " Status: Success";
                paymentstatus = true;
                ABCP_Status = 1;
                
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
                Response.Write("</br>");
                Response.Write(ex.InnerException);
                HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString() + " Method name : " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
            prcEmail2User(AuthDesc, ABCP_CurrId);
        }
        catch (Exception ex)
        {
            Response.Write("</br>");
            Response.Write(ex.InnerException);
            // MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

    }
    protected void populate(object sender, EventArgs e)
    {
       

    }

    protected DataSet Details()
    {
        DataSet dsDetail = new DataSet();
        try
        {

            LIBOnlinePayments objLibPayment = new LIBOnlinePayments();
            DALOnlinePayments objDALPayment = new DALOnlinePayments();

            objLibPayment.CourseId = Convert.ToInt32(Session["cid"].ToString());
            objLibPayment.stid = Convert.ToInt32(Session["stid"].ToString());
            objLibPayment.PaymentMode = "Online";

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLibPayment;
            dsDetail = objDALPayment.GetUserPaymentsDetails(tp);
        }
        catch (Exception ex)
        {
            Response.Write("</br>");
            Response.Write(ex.InnerException);
        }
        return dsDetail;
    }
    private void prcEmail2User(string status, string priceSymbol)
    {
        try
        {
            DataSet dsDetail = new DataSet();
            dsDetail = Details();
            string sBody;

            string strStatus = status;
            if (status == "Success")
            {
                strStatus = "<span style='color:Green; font-weight:bold;'> Status: Success</span>";
            }
            
            else
            {
                strStatus = "<span style='color:Red; font-weight:bold;'> Status: "+status+"</span>";
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
            Response.Write("</br>");
            Response.Write(ex.InnerException);
            HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString());
        }
    }
}