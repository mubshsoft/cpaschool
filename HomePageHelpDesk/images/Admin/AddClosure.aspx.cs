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

public partial class Admin_AddClosure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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
                hdnCourseId.Value = Request.QueryString["Cid"].ToString();

                hdnuserid.Value = Request.QueryString["stid"].ToString();
                hdnBatchId.Value = Request.QueryString["bt"].ToString();
                BindExamSetList();

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindExamSetList()
    {
        try
        {
            DataSet ds = new DataSet();
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = Convert.ToInt16(hdnCourseId.Value);
            objLIBExam.UserId = hdnuserid.Value;
            objLIBExam.BatchId = Convert.ToInt16(hdnBatchId.Value);
            tp.MessagePacket = (object)objLIBExam;

               ds = objDalExam.GetBatchClosuredetail(tp);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   txtDispatchedDate.Text = ds.Tables[0].Rows[0]["CertificateDispatchedDate"].ToString();
                   txtTestimonialsDate.Text = ds.Tables[0].Rows[0]["TestimonialsDate"].ToString();
                   txtTestiomonialStudent.Text = ds.Tables[0].Rows[0]["StudentTestimonialsDate"].ToString();
                   txtCertificateStudent.Text = ds.Tables[0].Rows[0]["StudentCertificateDispatchedDate"].ToString();
               }
              

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            
            //if (string.IsNullOrEmpty(txtTestimonialsDate.Text))
            //{
            //    lblTestimonialsDateReq.Text = "Enter Testimonials Date";
            //    return;
            //}
            //else
            //{
            //    lblTestimonialsDateReq.Text = "";
            //}

           
            //if (string.IsNullOrEmpty(txtDispatchedDate.Text))
            //{
            //    lblDispatchedDateReq.Text = "Enter Dispatched Date";
            //    return;
            //}
            //else
            //{
            //    lblDispatchedDateReq.Text = "";
            //}
            //if (string.IsNullOrEmpty(txtTestiomonialStudent.Text))
            //{
            //    lblTestiomonialStudent.Text = "Enter Date";
            //    return;
            //}
            //else
            //{
            //    lblTestiomonialStudent.Text = "";
            //}


            //if (string.IsNullOrEmpty(txtCertificateStudent.Text))
            //{
            //    lblCertificateStudent.Text = "Enter Date";
            //    return;
            //}
            //else
            //{
            //    lblCertificateStudent.Text = "";
            //}

            int addResult = 0;
           
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId =Convert.ToInt16(hdnCourseId.Value);
            objLIBExam.UserId = hdnuserid.Value;
            objLIBExam.BatchId = Convert.ToInt16(hdnBatchId.Value);
            try
            {
                if (txtTestimonialsDate.Text != "")
                {
                    DateTime dttxtTestimonialsDate = DateTime.Parse(txtTestimonialsDate.Text);
                    objLIBExam.TestimonialsDate1 = (txtTestimonialsDate.Text);
                }
                else
                {
                    objLIBExam.TestimonialsDate1 = "";
                }
             // objLIBExam.TestimonialsDate = DateTime.Parse(txtTestimonialsDate.Text);
               // objLIBExam.TestimonialsDate = txtTestimonialsDate.Text;
            }
            catch (Exception ex)
            {
                //string txtTestimonialsDate = txtTestimonialsDate.Text + " 00:00:00";
                lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                return;
            }
            try
            {
                if (txtDispatchedDate.Text != "")
                {
                    DateTime dttxtDispatchedDate = DateTime.Parse(txtDispatchedDate.Text);
                    objLIBExam.CertificateDispatchedDate1 = (txtDispatchedDate.Text);
                }
                else
                {
                    objLIBExam.CertificateDispatchedDate1 = "";
                }
                // objLIBExam.CertificateDispatchedDate = DateTime.Parse(txtDispatchedDate.Text);
               // objLIBExam.CertificateDispatchedDate = txtDispatchedDate.Text;
            }
            catch (Exception ex)
            {
                //string txtDispatchedDate = txtDispatchedDate.Text + " 00:00:00";
                lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                return;
            }


             try
             {
                 if (txtCertificateStudent.Text != "")
                 {
                     DateTime dtCertificateStudent = DateTime.Parse(txtCertificateStudent.Text);
                     objLIBExam.StudentCertificateDispatchedDate1 = (txtCertificateStudent.Text);
                 }
                 else
                 {
                     objLIBExam.StudentCertificateDispatchedDate1 = "";
                 }

                 //objLIBExam.StudentCertificateDispatchedDate = DateTime.Parse(txtCertificateStudent.Text);
                 //objLIBExam.StudentCertificateDispatchedDate = txtCertificateStudent.Text + " 00:00:00";
             }
             catch (Exception ex)
             {
                 //string txtCertificateStudent = txtCertificateStudent.Text + " 00:00:00";
                 lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                 return;
             }
             try
             {
                 if (txtTestiomonialStudent.Text != "")
                 {
                     DateTime dttxtTestiomonialStudent = DateTime.Parse(txtTestiomonialStudent.Text);
                     objLIBExam.StudentTestimonialsDate1 = (txtTestiomonialStudent.Text);
                 }
                 else
                 {
                     objLIBExam.StudentTestimonialsDate1 = "";
                 }
                 //objLIBExam.StudentTestimonialsDate = DateTime.Parse(txtTestiomonialStudent.Text);
                 //objLIBExam.StudentTestimonialsDate = txtTestiomonialStudent.Text;
             }
             catch (Exception ex)
             {
                 //string txtTestiomonialStudent = txtTestiomonialStudent.Text + " 00:00:00";
                 lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                 return;
             }

            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddBatchClosureDetails(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Created successfully');", true);
                //lblMessage.Text = "Exam Set Saved Successfully";
                txtTestimonialsDate.Text = "";
                txtTestiomonialStudent.Text = "";
                txtDispatchedDate.Text = "";
                txtCertificateStudent.Text = "";
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
    
}
