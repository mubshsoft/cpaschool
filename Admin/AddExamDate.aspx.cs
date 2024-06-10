using System;
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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class Admin_AddExamDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "Admin")
            { }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }


        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!Page.IsPostBack)
            {
                hdnExamId.Value = Request.QueryString["exid"].ToString();

                hdnuserid.Value = Request.QueryString["uid"].ToString();
                hdnBatchId.Value = Request.QueryString["Batchid"].ToString();
                BindList();

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBExam objLIBExam = new LIBExam();              
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt16(hdnExamId.Value);
            objLIBExam.UserId = hdnuserid.Value;
            objLIBExam.BatchId = Convert.ToInt16(hdnBatchId.Value);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetDatedetail(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtSentDate.Text = ds.Tables[0].Rows[0]["SentDate"].ToString();
                txtReceivedDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        //DateTime? datet = null;
        try
        {
            //if (string.IsNullOrEmpty(txtSentDate.Text))
            //{
            //    lblSentDateReq.Text = "Enter Sent Date";
            //    return;
            //}
            //else
            //{
            //    lblSentDateReq.Text = "";
            //}

           
            //if (string.IsNullOrEmpty(txtReceivedDate.Text))
            //{
            //    lblReceivedDateReq.Text = "Enter Received Date";
            //    return;
            //}
            //else
            //{
            //    lblReceivedDateReq.Text = "";
            //}


            int addResult = 0;
           
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId =Convert.ToInt16(hdnExamId.Value);
            objLIBExam.UserId = hdnuserid.Value;
            objLIBExam.BatchId = Convert.ToInt16(hdnBatchId.Value);
            try
            {
                if (txtSentDate.Text != "")
                {

                    DateTime dtsent = DateTime.Parse(txtSentDate.Text);

                    objLIBExam.SentDate1 = dtsent.ToShortDateString();
                }
                else
                {
                    objLIBExam.SentDate1 = "";

                }
               
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                return;
            }
            try
            {
                if (txtReceivedDate.Text != "")
                {
                    DateTime dtrecvd = DateTime.Parse(txtReceivedDate.Text);
                    objLIBExam.ReceiveDate1 = dtrecvd.ToShortDateString();
                }
                else
                {
                    objLIBExam.ReceiveDate1 = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                return;
            }
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddExamDate(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Created successfully');", true);
                //lblMessage.Text = "Exam Set Saved Successfully";
              
            }
            else if (addResult == -11)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
                lblMessage.Text = "Duplicate Record";

            }

            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
                lblMessage.Text = "Failed to Save Exam Set";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminListExamSets.aspx?batchid=" + hdnBatchId.Value + "&exid=" + hdnExamId.Value + "");
    }
}
