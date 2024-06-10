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
using System.IO;

public partial class Student_AddUpdateTestimonial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
        }
       

        try
        {

            if (!Page.IsPostBack)
            {

                GetTestimonial();
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
            
            if (Editor1.Value.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Testimonials text cannot be left blank');", true);
                return;
            }

            
                
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();


            //if (hdnid.Value != "")
            //{
            //    objLibExam.stid = Convert.ToInt32(hdnid.Value);
            //}
            //else
            //{
            objLibExam.stid =Convert.ToInt32(Session["stid"].ToString());
            //}
           
            objLibExam.KnowledgeCenterDescription = Utility.CheckNullString(Editor1.Value);
            objLibExam.Check = false;

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdatTestimonials(tp);

            if (addResult > 0)
            {
                if (btnSave.Text == "Save")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Added !');location.href='StudentDashboard.aspx';</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Updated !');location.href='StudentDashboard.aspx';</script>");
                }
                //BindDemoList();
                hdnid.Value = "";
              
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

    public void GetTestimonial()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            objLIBExam.stid = Convert.ToInt32(Session["stid"].ToString());
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetTestimonialsList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Editor1.Value = ds.Tables[0].Rows[0]["description"].ToString();
                lnkEdit.Visible = true;
                btnSave.Enabled = false;
            }



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

   


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("StudentDashboard.aspx");
    }


  
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        btnSave.Text = "Update";
        btnSave.Enabled = true;
        lnkEdit.Enabled = false;
    }
}
