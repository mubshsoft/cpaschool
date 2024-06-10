using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using fmsf.lib;
using fmsf.DAL;

public partial class Student_checkout : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Display(sender, e);
        }
        catch (Exception ex)
        {
        }
    }
    protected DataSet UserDetails()
    {
        DataSet dss = new DataSet();
        try
        {
            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.stid =Convert.ToInt32(Session["stid"]);
            objLIBExam.Courseid = Convert.ToInt32(Request.QueryString["Cid"]);
            tp.MessagePacket = (object)objLIBExam;

            dss = objDalExam.GetStudentDetailsforOnlienPayment(tp);
            if (dss != null)
                if (dss != null)
                {
                    if (dss.Tables != null)
                    {
                        if (dss.Tables[0].Rows != null)
                        {


                        }
                    }
                }


        }
        catch (Exception ex)
        {
            Response.Write(ex.InnerException);
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return dss;
    }

    protected void Display(Object sender, EventArgs e)
    {

        string WorkingKey = "";

        //*************************************************************************

        string str_delivery_cust_notes_CurrencyType = "";
        string ABCP_OrderDetails = null;
        int iFields = 0;
        ABCP_OrderDetails = "";
        double TPrice = 0;
        TPrice = 0;

        //******USER DETAILS******************
        DataSet dsUserDetail = new DataSet();
        dsUserDetail = UserDetails();
        if (dsUserDetail != null)
        {
            if (dsUserDetail.Tables != null)
            {
                if (dsUserDetail.Tables[0].Rows != null)
                {
                    if (dsUserDetail.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsUserDetail.Tables[0].Rows.Count; i++)
                        {
                            redirect_url.Value = "http://test.fmsflearningsystems.org/Student/ResponseHandler.aspx";// dsUserDetail.Tables[0].Rows[0]["RedirectUrl"].ToString();
                            cancel_url.Value = "http://test.fmsflearningsystems.org/Student/ResponseHandler.aspx";
                            billing_name.Value = dsUserDetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUserDetail.Tables[0].Rows[0]["LastName"].ToString();
                            billing_address.Value = dsUserDetail.Tables[0].Rows[0]["Address1"].ToString() + dsUserDetail.Tables[0].Rows[0]["Address2"].ToString();
                            billing_state.Value = "";// dsUserDetail.Tables[0].Rows[0]["State"].ToString();
                            billing_country.Value = dsUserDetail.Tables[0].Rows[0]["nationality"].ToString();
                            billing_city.Value = dsUserDetail.Tables[0].Rows[0]["Place"].ToString();
                            billing_zip.Value = "";// dsUserDetail.Tables[0].Rows[0]["zipCode"].ToString();
                            billing_tel.Value = dsUserDetail.Tables[0].Rows[0]["contactnumber1"].ToString();
                            //& ", " & RsU("Fax").ToString
                            billing_email.Value = dsUserDetail.Tables[0].Rows[0]["email"].ToString();
                            

                            delivery_name.Value = dsUserDetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUserDetail.Tables[0].Rows[0]["LastName"].ToString();
                            delivery_address.Value = dsUserDetail.Tables[0].Rows[0]["Address1"].ToString() + dsUserDetail.Tables[0].Rows[0]["Address2"].ToString();
                            delivery_state.Value = "";// dsUserDetail.Tables[0].Rows[0]["State"].ToString();
                            delivery_country.Value = dsUserDetail.Tables[0].Rows[0]["nationality"].ToString();
                            delivery_city.Value = dsUserDetail.Tables[0].Rows[0]["Place"].ToString();
                            delivery_zip.Value = "";// dsUserDetail.Tables[0].Rows[0]["zipCode"].ToString();
                            delivery_tel.Value = dsUserDetail.Tables[0].Rows[0]["contactnumber1"].ToString();
                            //& ", " & RsU("Fax").ToString
                           // delivery_cust_notes.Value = "";
                            TPrice = Convert.ToDouble(dsUserDetail.Tables[0].Rows[0]["fee"]);
                            ABCP_OrderDetails = Convert.ToString(dsUserDetail.Tables[0].Rows[0]["OrderDetails"]);

                        }
                    }
                }
            }
        }

       // billing_cust_notes.Value = RemoveSpecialCharacters(ABCP_OrderDetails);
        //******JOURNAL DETAILS END***********

        WorkingKey = "236A94A1F0124CAD7E69BABC2D78EF05";
        merchant_id.Value = "391205";
        amount.Value = TPrice.ToString("0.00");
        try
        {
            if (Request.QueryString["OrderNumber"].ToString() != null)
            {
                order_id.Value = Request.QueryString["OrderNumber"].ToString();
            }
            else
            {
                order_id.Value = System.DateTime.Now.ToFileTime().ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.InnerException);
        }


      //  Checksum.Value = myUtility.getchecksum(Merchant_Id.Value, Order_Id.Value, amount.Value, Redirect_Url.Value, WorkingKey);
        //if (Session["nowipCn"].ToString().ToUpper() == "INDIA")
        //{
        //    str_delivery_cust_notes_CurrencyType = "INR";
        //}
        //else
        //{
        //    str_delivery_cust_notes_CurrencyType = "USD";
        //}
        str_delivery_cust_notes_CurrencyType = "INR";
        currency.Value = str_delivery_cust_notes_CurrencyType;
        if (ABCP_OrderDetails.ToString().Length > 250)
        {
            ABCP_OrderDetails.ToString().Substring(0, 250);

        }


        //##############                
        int ABCP_Status = 0;
        int ABCP_ID = 0;
        string ABCP_SiteTransactionId = "FMSF";
        string ABCP_CurrId = str_delivery_cust_notes_CurrencyType;

        string ABCP_DisplayResponse = "";
        string ABCP_BankTransactionId = "";
        string ABCP_BankAuthorisationCode = "";
        string ABCP_Method = "";
        string ABCP_MethodCode = "";
        //string ABCP_SiteId = Session["Webname"].ToString();
        string ABCP_SiteId = "http://fmsflearningsystems.org/";
        try
        {
            int Result = 0;
            DALOnlinePayments objDALOnlinePayments = new DALOnlinePayments();
            LIBOnlinePayments objLibOnlinePayments = new LIBOnlinePayments();
            TransportationPacket tp = new TransportationPacket();
            objLibOnlinePayments.Status = ABCP_Status;
            objLibOnlinePayments.ID = ABCP_ID;
            objLibOnlinePayments.TID = "1";
            objLibOnlinePayments.SiteId = ABCP_SiteId;
            objLibOnlinePayments.SiteTransactionId = ABCP_SiteTransactionId;
            objLibOnlinePayments.OrderID = order_id.Value;
            objLibOnlinePayments.BankTransactionId = ABCP_BankTransactionId;
            objLibOnlinePayments.BankAuthorisationCode = ABCP_BankAuthorisationCode;
            objLibOnlinePayments.DisplayResponse = ABCP_DisplayResponse;
            objLibOnlinePayments.CurrId = ABCP_CurrId;
            objLibOnlinePayments.OrderDetails = ABCP_OrderDetails;
            objLibOnlinePayments.Method = ABCP_Method;
            objLibOnlinePayments.MethodCode = ABCP_MethodCode;
            objLibOnlinePayments.TransactionDate = DateTime.Now;
            //objLibOnlinePayments.Type = Session["JTYP"].ToString();
            objLibOnlinePayments.Amount = Convert.ToDecimal(amount.Value);
            tp.MessagePacket = (object)objLibOnlinePayments;

            Result = objDALOnlinePayments.InsertOnlinePaymentJ(tp);


        }
        catch (Exception ex)
        {
            Response.Write(ex.InnerException);

            HandleException.ExceptionLogging(ex.Source.ToString(), ex.Message.ToString() + " Method name : " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }
        finally
        {
        }

    }

    private string RemoveSpecialCharacters(string str)
    {
        string strorigFileName = null;
        try
        {

            int intCounter = 0;
            string[] arrSpecialChar = {
            "<",
            ">",
            ":",
            "?",
            "\"",
            "/",
            "{",
            "[",
            "}",
            "]",
            "`",
            "~",
            "!",
            "@",
            "#",
            "$",
            "%",
            "^",
            "&",
            "*",
            "(",
            ")",
            "+",
            "=",
            "|",
            "\\",
            "-"
        };
            strorigFileName = str;
            intCounter = 0;
            int i = 0;

            for (i = 0; i <= arrSpecialChar.Length - 1; i++)
            {
                //Do Until intCounter = arrSpecialChar.Length - 1

                str = strorigFileName.Replace(arrSpecialChar[i], "");//Strings.Replace(strorigFileName, arrSpecialChar[i], "");
                                                                     //intCounter = intCounter + 1
                strorigFileName = str;
                //    Loop
                //intCounter = 0
            }


        }
        catch (Exception ex)
        {
            //MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }
        return strorigFileName;
    }

}
