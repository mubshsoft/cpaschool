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
using System.IO;
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_TestimonialList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {

            if (!Page.IsPostBack)
            {
                BindTestimonialList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void BindTestimonialList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.stid = 0;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetTestimonialsList(tp);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvTestimonialList.DataSource = ds;
                gvTestimonialList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void gvTestimonialList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
               
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvTestimonialList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

  
    protected void gvTestimonialList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTestimonialList.PageIndex = e.NewPageIndex;
        BindTestimonialList();
    }

    protected void gvTestimonialList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Testimonial")
            {
                int stid = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();

                LIBStudent objLIBExam = new LIBStudent();
                DalAddStudent_CS objDalExam = new DalAddStudent_CS();
                LIBStudentListing objLibExamListing = new LIBStudentListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.stid = stid;

                tp.MessagePacket = (object)objLIBExam;

                ds = objDalExam.GetTestimonialsList(tp);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    lblTestimonial.Text = ds.Tables[0].Rows[0]["description"].ToString();
                    if(ds.Tables[0].Rows[0]["status"].ToString()=="True")
                    {
                        chkchecked.Checked = true;
                    }
                    else
                    {
                        chkchecked.Checked = false;
                    }
                    
                    hdnStid.Value = stid.ToString();
                }

                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDiv');</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.stid = Convert.ToInt32(hdnStid.Value);
           
            objLibExam.KnowledgeCenterDescription = Utility.CheckNullString(lblTestimonial.Text);

            if (chkchecked.Checked == true)
            {
                objLibExam.Check = true;
            }
            else
            {
                objLibExam.Check = false;

            }
            

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdatTestimonials(tp);

            if (addResult > 0)
            {
               
                    Uri ur = Request.Url;
                    string AbsoluteURL = "";

                    AbsoluteURL = ur.AbsoluteUri.Replace("TestimonialList.aspx", "AdminLogin.aspx");

                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Testimonial Approved !'); location.href='" + AbsoluteURL + "';</script>");
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Testimonial Approved !'); </script>");
                    BindTestimonialList();
                    hdnStid.Value = "";
               
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Testimonials');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Testimonials');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

   
}
