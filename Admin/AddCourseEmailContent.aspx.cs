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
public partial class AddCourseEmailContent : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    hdncourseId.Value = Request.QueryString["courseid"];
                    hdnemailtype.Value = Request.QueryString["emailtype"];
                    bindcoursedetails();
                }


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }

    public void bindcoursedetails()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.CourseId = Convert.ToInt32(hdncourseId.Value);
            objLIBExam.ColName = (hdnemailtype.Value);
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseEmaliDetailByCID(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
          
            Editor1.Value = objLibExamListing[0].EmailContent;
            txtcourseemailid.Text = Convert.ToString(objLibExamListing[0].courseEmail);
           
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
           
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
           
            objLibExam.CourseId = (Convert.ToInt32(hdncourseId.Value));
           
             objLibExam.EmailContent = Utility.CheckNullString(Editor1.Value);
           
           
            tp.MessagePacket = (object)objLibExam;
            if (hdnemailtype.Value == "reg")
            {
                addResult = OBJDALExam.AddUpdateCourseRegEmailContent(tp);
            }
            if (hdnemailtype.Value == "approv")
            {
                addResult = OBJDALExam.AddUpdateCourseApprovEmailContent(tp);
            }

            if (addResult > 0)
            {
                DALExam OBJDALExam1 = new DALExam();
                string str = "update courseemail set courseidmail='" + txtcourseemailid.Text + "' where courseid=" + objLibExam.CourseId;
                OBJDALExam1.ExeNQcomsp(str);

                Uri ur = Request.Url;
                string AbsoluteURL = "";
               
                    AbsoluteURL = ur.AbsoluteUri.Replace("AddCourseEmailContent.aspx", "AddCourseEmail.aspx");
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Content Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                
                
            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Content');", true);
            }

            else
            {
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Course');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

   










    protected void btnBack_Click(object sender, EventArgs e)
    {
        Uri ur = Request.Url;
        string AbsoluteURL = "";

        AbsoluteURL = ur.AbsoluteUri.Replace("AddCourseEmailContent.aspx", "AddCourseEmail.aspx");
        Response.Redirect(AbsoluteURL);
    }
}
