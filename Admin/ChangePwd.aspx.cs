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
using fmsf.lib;
using fmsf.DAL;
using System.Net.Mail;

public partial class Admin_ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["username"] == null)
        //{
        //    Response.Redirect("../Default-new.aspx");
        //}
        //else
        //{
        //    if (Session["username"].ToString() == "admin")
        //    { }
        //    else
        //    {
        //        Response.Redirect("../login.aspx");
        //    }
        //}


        try
        {
            if (!Page.IsPostBack)
            {
                BindCourseList();
            }
        }
             catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }




    protected void BindCourseList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetCourseList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = "CourseTitle";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "--Select--");

         }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        

    }


    protected void BindBatch()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.CourseId= Convert.ToInt32(ddlCourse.SelectedValue);
                  
            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetBatchByCourseId(tp);
            ddlbatch.DataSource = ds;
            ddlbatch.DataTextField = "batchcode";
            ddlbatch.DataValueField = "bid";
            ddlbatch.DataBind();
   
            ddlbatch.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }



    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "--Select--")
        {
            return;
        }
        BindBatch();
    }



    protected void BindStudentData()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);
            
           
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetStudentData(tp);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }



    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindStudentData();
    }



    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindStudentData();
    }


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           
            string hdnstid = ((HiddenField)GridView1.Rows[e.RowIndex].FindControl("hdnstid")).Value;
            string hdnemail =((HiddenField)GridView1.Rows[e.RowIndex].FindControl("hdnemail")).Value;

            //string hdnstid = ((HiddenField)GridView1.Rows[e.RowIndex].FindControl("hdnstid")).Value;

            TextBox txtFirstName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLastName");
            TextBox txtPassword = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPassword");
            Label lblEmail = (Label)GridView1.Rows[e.RowIndex].FindControl("lblEmail");

            int addResult = 0;
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.Stid = Convert.ToInt32(hdnstid);
            objLIBExam.StudentEmail = Convert.ToString(hdnemail);
            objLIBExam.FirstName = Convert.ToString(txtFirstName.Text);
            objLIBExam.LastName = Convert.ToString(txtLastName.Text);
            objLIBExam.Password = Convert.ToString(txtPassword.Text);

            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.UpdateStudentPassword(tp);


            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully');", true);

                GridView1.EditIndex = -1;
                BindStudentData();

                {
                    try
                    {


                        string mailBody = "";
                        mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' color='#CCCCCC' style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;'><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Hello " + txtFirstName.Text + "&nbsp; " + txtLastName.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Your New Password :   " + txtPassword.Text + "</td></tr></table></body></html>";

                        string m_strFromEmail = null;
                        string m_strFromName = "";
                        string m_strToMail = null;
                        string m_strToCC = null;

                        m_strFromEmail =  "coordinator@fmsflearningsystems.org";
                        m_strToMail = lblEmail.Text;
                        m_strToCC = "coordinator@fmsflearningsystems.org";



                        SendMailMessage(m_strFromEmail, m_strToMail, m_strToCC, "Change Password", mailBody);
                    }
                    catch (Exception ex)
                    {
                        //ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Query submitted successfully!');", True)







                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to update');", true);

                GridView1.EditIndex = -1;
                BindStudentData();
            }
            
        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }


    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStudentData();
    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageStudentInfo.aspx");
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
            //Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
            SmtpClient mSmtpClient = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient mSmtpClient = new SmtpClient("smtpout.secureserver.net");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(@from, "fmsf@123");
            mSmtpClient.Send(mMailMessage);
        }
        catch (Exception ex)
        {

        }
    }
}
