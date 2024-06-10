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
    protected IntegrationKit.libfuncs myUtility = new IntegrationKit.libfuncs();
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
                            Redirect_Url.Value = "http://fmsflearningsystems.org/Student/redirecturl.aspx";// dsUserDetail.Tables[0].Rows[0]["RedirectUrl"].ToString();
                            billing_cust_name.Value = dsUserDetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUserDetail.Tables[0].Rows[0]["LastName"].ToString();
                            billing_cust_address.Value = dsUserDetail.Tables[0].Rows[0]["Address1"].ToString() + dsUserDetail.Tables[0].Rows[0]["Address2"].ToString();
                            billing_cust_state.Value = "";// dsUserDetail.Tables[0].Rows[0]["State"].ToString();
                            billing_cust_country.Value = dsUserDetail.Tables[0].Rows[0]["nationality"].ToString();
                            billing_cust_city.Value = dsUserDetail.Tables[0].Rows[0]["Place"].ToString();
                            billing_zip_code.Value = "";// dsUserDetail.Tables[0].Rows[0]["zipCode"].ToString();
                            billing_cust_tel.Value = dsUserDetail.Tables[0].Rows[0]["contactnumber1"].ToString();
                            //& ", " & RsU("Fax").ToString
                            billing_cust_email.Value = dsUserDetail.Tables[0].Rows[0]["email"].ToString();
                            

                            delivery_cust_name.Value = dsUserDetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUserDetail.Tables[0].Rows[0]["LastName"].ToString();
                            delivery_cust_address.Value = dsUserDetail.Tables[0].Rows[0]["Address1"].ToString() + dsUserDetail.Tables[0].Rows[0]["Address2"].ToString();
                            delivery_cust_state.Value = "";// dsUserDetail.Tables[0].Rows[0]["State"].ToString();
                            delivery_cust_country.Value = dsUserDetail.Tables[0].Rows[0]["nationality"].ToString();
                            delivery_cust_city.Value = dsUserDetail.Tables[0].Rows[0]["Place"].ToString();
                            delivery_zip_code.Value = "";// dsUserDetail.Tables[0].Rows[0]["zipCode"].ToString();
                            delivery_cust_tel.Value = dsUserDetail.Tables[0].Rows[0]["contactnumber1"].ToString();
                            //& ", " & RsU("Fax").ToString
                            delivery_cust_notes.Value = "";
                            TPrice = Convert.ToDouble(dsUserDetail.Tables[0].Rows[0]["fee"]);
                            ABCP_OrderDetails = Convert.ToString(dsUserDetail.Tables[0].Rows[0]["OrderDetails"]);

                        }
                    }
                }
            }
        }

        billing_cust_notes.Value = RemoveSpecialCharacters(ABCP_OrderDetails);
        //******JOURNAL DETAILS END***********

        WorkingKey = "h78037bgnmafx703u1";
        Merchant_Id.Value = "M_tarun_jo_15481";
        Amount.Value = TPrice.ToString("0.00");
        try
        {
            if (Request.QueryString["OrderNumber"].ToString() != null)
            {
                Order_Id.Value = Request.QueryString["OrderNumber"].ToString();
            }
            else
            {
                Order_Id.Value = System.DateTime.Now.ToFileTime().ToString();
            }
        }
        catch (Exception ex)
        {

        }


        Checksum.Value = myUtility.getchecksum(Merchant_Id.Value, Order_Id.Value, Amount.Value, Redirect_Url.Value, WorkingKey);
        //if (Session["nowipCn"].ToString().ToUpper() == "INDIA")
        //{
        //    str_delivery_cust_notes_CurrencyType = "INR";
        //}
        //else
        //{
        //    str_delivery_cust_notes_CurrencyType = "USD";
        //}
        str_delivery_cust_notes_CurrencyType = "INR";
        Merchant_Param.Value = str_delivery_cust_notes_CurrencyType;
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
            objLibOnlinePayments.OrderID = Order_Id.Value;
            objLibOnlinePayments.BankTransactionId = ABCP_BankTransactionId;
            objLibOnlinePayments.BankAuthorisationCode = ABCP_BankAuthorisationCode;
            objLibOnlinePayments.DisplayResponse = ABCP_DisplayResponse;
            objLibOnlinePayments.CurrId = ABCP_CurrId;
            objLibOnlinePayments.OrderDetails = ABCP_OrderDetails;
            objLibOnlinePayments.Method = ABCP_Method;
            objLibOnlinePayments.MethodCode = ABCP_MethodCode;
            objLibOnlinePayments.TransactionDate = DateTime.Now;
            //objLibOnlinePayments.Type = Session["JTYP"].ToString();
            objLibOnlinePayments.Amount = Convert.ToDecimal(Amount.Value);
            tp.MessagePacket = (object)objLibOnlinePayments;

            Result = objDALOnlinePayments.InsertOnlinePaymentJ(tp);


        }
        catch (Exception ex)
        {

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
