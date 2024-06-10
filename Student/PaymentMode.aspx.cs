using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using fmsf.lib;
using fmsf.DAL;
public partial class Student_PaymentMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lblPrice.Text = Request.QueryString["amt"];
        
        ViewState["semid"] = Request.QueryString["semid"];

        string strNationality = "";
        string country = "India";
        DataSet dsNationality = new DataSet();
        dsNationality = CLS_C.fnQuerySelectDs("select * from student where stid=" + Session["stid"]);
        if (dsNationality.Tables[0].Rows.Count > 0)
        {
            strNationality = dsNationality.Tables[0].Rows[0]["nationality"].ToString();
        }
        if (strNationality.ToLower().ToString()=="india")
        {
            country = "Indian";
        }
        else
        {
            country = "Others";
        }
            DataSet ds = new DataSet();
        ds = CLS_C.fnQuerySelectDs("select sr.stid,sr.courseid,f.type,f.fee,f.applicantcategory from studentRegCourse sr Inner join FeeDetails f on sr.courseid=f.courseid inner join  student st on sr.stid=st.stid where sr.stid=" + Session["stid"]  + " and f.courseid="+ Request.QueryString["Cid"] +"  and f.applicantcategory=st.applicantcategory and f.nationality='"+ country + "'");
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblFeeType.Text= ds.Tables[0].Rows[0]["type"].ToString();
                        
                        if (strNationality.ToLower().ToString() == "india")
                        {
                            lblCurrencyType.Text = "INR";
                           // lblddAmount.Text = lblPrice.Text ;
                            //lblchqAmount.Text = lblPrice.Text;
                        }
                        else
                        {
                            lblCurrencyType.Text = "USD";
                            //lblddAmount.Text = lblPrice.Text + " USD";
                           // lblchqAmount.Text = lblPrice.Text + " USD";
                        }
                    }
                }
            }
        }
    }
    protected void rdoCheque_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            pnlCheque.Visible = true;
            pnlDD.Visible = false;

        }
        catch (Exception ex)
        {
        }
    }
    protected void rdoDD_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            pnlCheque.Visible = false;
            pnlDD.Visible = true;

        }
        catch (Exception ex)
        {
        }
    }
    protected void rdoOnline_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            pnlCheque.Visible = false;
            pnlDD.Visible = false ;
            string OrderNumber = System.DateTime.Now.ToFileTime().ToString();
            try
            {
                LIBOnlinePayments objLibPayment = new LIBOnlinePayments();
                DALOnlinePayments objDALPayment = new DALOnlinePayments();
                TransportationPacket tp = new TransportationPacket();
                objLibPayment.DDNo = OrderNumber;
                objLibPayment.Amount = Convert.ToInt32(lblPrice.Text);
                objLibPayment.BranchName = "";
                objLibPayment.BankName = "";
                objLibPayment.PaymentMode = "Online";
                objLibPayment.PaymentType = lblFeeType.Text;
                objLibPayment.stid = Convert.ToInt32(Session["stid"].ToString());
                objLibPayment.CourseId = Convert.ToInt32(Request.QueryString["Cid"]);
                if (lblFeeType.Text == "One Time Fee")
                {
                    objLibPayment.SemId = 0;
                }
                else
                {
                    objLibPayment.SemId = Convert.ToInt32(Request.QueryString["semid"]);
                }
                objLibPayment.DDdate = System.DateTime.Now;

                tp.MessagePacket = (object)objLibPayment;
                short Result = 0;

                string[] strOutPut2;
                strOutPut2 = objDALPayment.InsertPayment4DD(tp, ref Result);


                if (Convert.ToInt32(strOutPut2[0].ToString()) > 0)
                {
                    lblMessage.Text = "Payment submitted Successfully.";
                    //prcSendMail("DD Number:" + txtDD.Text);
                }

            }
            catch (Exception ex)
            {
            }
            

            Response.Redirect("checkout.aspx?cid=" + Request.QueryString["Cid"] + "&stid=" + Session["stid"] + "&OrderNumber="+ OrderNumber, false);
           
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmitDD_Click(object sender, EventArgs e)
    {
        try
        {
            pnlCheque.Visible = false;
            pnlDD.Visible = true;

            try
            {

                LIBOnlinePayments objLibPayment = new LIBOnlinePayments();
                DALOnlinePayments objDALPayment = new DALOnlinePayments();
                TransportationPacket tp = new TransportationPacket();
                objLibPayment.DDNo = txtDD.Text;
                objLibPayment.Amount =Convert.ToInt32(lblPrice.Text);
                objLibPayment.BranchName = txtddBranch.Text; 
                objLibPayment.BankName = txtddBank.Text;
                objLibPayment.PaymentMode = "DD";
                objLibPayment.PaymentType = lblFeeType.Text;
                objLibPayment.stid =Convert.ToInt32(Session["stid"].ToString());
                objLibPayment.CourseId = Convert.ToInt32(Request.QueryString["Cid"]);
                if(lblFeeType.Text== "One Time Fee")
                {
                    objLibPayment.SemId = 0;
                }
                else
                {
                    objLibPayment.SemId = Convert.ToInt32(Request.QueryString["semid"]);
                }
                objLibPayment.DDdate =Convert.ToDateTime(txtddDate.Text);// System.DateTime.Now;

                tp.MessagePacket = (object)objLibPayment;
                short Result = 0;
               
                string[] strOutPut2;
                strOutPut2 = objDALPayment.InsertPayment4DD(tp, ref Result);


                if (Convert.ToInt32(strOutPut2[0].ToString()) > 0)
                {
                    lblMessage.Text = "Payment submitted Successfully.";
                    prcSendMail("DD Number:" + txtDD.Text);
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Your payment is addedd successfully'); </script>");
                }
                else if (Convert.ToInt32(strOutPut2[0].ToString()) == -2)
                {
                    lblMessage.Text = "Payment is already submitted with DD number - " + txtDD.Text ;
                }
                else if (Convert.ToInt32(strOutPut2[0].ToString()) == -11 || Convert.ToInt32(strOutPut2[0].ToString())==-12)
                {
                    lblMessage.Text = "Payment is already submitted";
                }
                else
                {
                    lblMessage.Text = "Failed to submitted";
                }

            }
            catch (Exception ex)
            {
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void prcSendMail(string paymentmode)
    {
        try
        {
            string StrAuthor = "";
            string StrAdmin = "";
            DataSet dsUserDetail = new DataSet();
            dsUserDetail = UserDetails();
            string emailid = "";
            string strname = "";
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
                                strname = dsUserDetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + dsUserDetail.Tables[0].Rows[0]["LastName"].ToString();
                                string address = dsUserDetail.Tables[0].Rows[0]["Address1"].ToString() + dsUserDetail.Tables[0].Rows[0]["Address2"].ToString() + "<br>" + dsUserDetail.Tables[0].Rows[0]["Place"].ToString() + " ," + dsUserDetail.Tables[0].Rows[0]["nationality"].ToString();

                                StrAuthor = CommonUtility.prcFindInFile(HttpContext.Current.Server.MapPath("../Admin/MailFormats/") + "PaymentMail4Student.htm", "#name#", strname);
                                StrAuthor = CommonUtility.prcFindInString(StrAuthor, "#paymentmode#", paymentmode);
                                
                                StrAdmin = CommonUtility.prcFindInFile(HttpContext.Current.Server.MapPath("../Admin/MailFormats/") + "PaymentMail4Admin.htm", "#name#", strname);
                                StrAdmin = CommonUtility.prcFindInString(StrAdmin, "#paymentmode#", paymentmode);
                                StrAdmin = CommonUtility.prcFindInString(StrAdmin, "#phone#", dsUserDetail.Tables[0].Rows[0]["contactnumber1"].ToString());
                                StrAdmin = CommonUtility.prcFindInString(StrAdmin, "#emailid#", dsUserDetail.Tables[0].Rows[0]["email"].ToString());
                                StrAdmin = CommonUtility.prcFindInString(StrAdmin, "#orderDetails#", dsUserDetail.Tables[0].Rows[0]["orderDetails"].ToString());
                                StrAdmin = CommonUtility.prcFindInString(StrAdmin, "#address#", address);

                                emailid = dsUserDetail.Tables[0].Rows[0]["email"].ToString();
                                
                            }
                        }
                    }
                }
            }


            string subject = "Thank you for submitting Payment from - "+ paymentmode;
            

            CommonUtility.SendMail(ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[0], ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[1], emailid, "", "", "", subject, StrAuthor);
            CommonUtility.SendMail(ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[0], ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[1], ConfigurationSettings.AppSettings["Admin"].Split(new char[] { ';' })[0], "", "", "", "Payment Received through "+ paymentmode, StrAdmin);

        }
        catch (Exception e1)
        {
            HandleException.ExceptionLogging(e1.Source.ToString(), e1.Message.ToString());

        }
        //**
    }

    protected DataSet UserDetails()
    {
        DataSet dss = new DataSet();
        try
        {
            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.stid = Convert.ToInt32(Session["stid"]);
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
    protected void btnSubmitCheque_Click(object sender, EventArgs e)
    {
        try
        {
            pnlCheque.Visible = true;
            pnlDD.Visible = false;

            try
            {

                LIBOnlinePayments objLibPayment = new LIBOnlinePayments();
                DALOnlinePayments objDALPayment = new DALOnlinePayments();
                TransportationPacket tp = new TransportationPacket();
                objLibPayment.DDNo = txtChequeNo.Text;
                objLibPayment.Amount = Convert.ToInt32(lblPrice.Text);
                objLibPayment.BranchName = txtchqBranch.Text;
                objLibPayment.BankName = txtchqBank.Text;
                objLibPayment.PaymentMode = "Cheque";
                objLibPayment.PaymentType = lblFeeType.Text;
                objLibPayment.stid = Convert.ToInt32(Session["stid"].ToString());
                objLibPayment.CourseId = Convert.ToInt32(Request.QueryString["Cid"]);
                if (lblFeeType.Text == "One Time Fee")
                {
                    objLibPayment.SemId = 0;
                }
                else
                {
                    objLibPayment.SemId = Convert.ToInt32(Request.QueryString["semid"]);
                }
                objLibPayment.DDdate =Convert.ToDateTime(txtchqDate.Text);// System.DateTime.Now;

                tp.MessagePacket = (object)objLibPayment;
                short Result = 0;

                string[] strOutPut2;
                strOutPut2 = objDALPayment.InsertPayment4DD(tp, ref Result);


                if (Convert.ToInt32(strOutPut2[0].ToString()) > 0)
                {
                    lblMessage.Text = "Payment submitted Successfully.";
                    prcSendMail("Cheque Number:" + txtChequeNo.Text);
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Your payment is addedd successfully'); </script>");
                }
                else if (Convert.ToInt32(strOutPut2[0].ToString()) == -2)
                {
                    lblMessage.Text = "Payment is already submitted with DD number - " + txtDD.Text;
                }
                else if (Convert.ToInt32(strOutPut2[0].ToString()) == -11 || Convert.ToInt32(strOutPut2[0].ToString()) == -12)
                {
                    lblMessage.Text = "Payment is already submitted";
                }
                else
                {
                    lblMessage.Text = "Failed to submitted";
                }

            }
            catch (Exception ex)
            {
            }
        }
        catch (Exception ex)
        {
        }
    }
}