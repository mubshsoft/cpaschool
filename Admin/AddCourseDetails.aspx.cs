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
public partial class AddCourseDetails : System.Web.UI.Page
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
                    bindcoursedetails();
                }


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
            string path = "";
            string uploadFolder = Request.PhysicalApplicationPath + "Courseimage\\";
           
            if (txtCourse.Text.Length == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks cannot be left blank'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Course cannot be left blank');", true);
                return;
            }
            string text = Convert.ToString(txtCourse.Text);// DateTime.Now.ToString("HHmm");
            string fileToDelete="";
            if (FileUpload1.HasFile)
            {
                if (hdnimage.Value != "")
                {
                    fileToDelete = uploadFolder + hdnimage.Value;
                    try
                    {
                        if (File.Exists(fileToDelete))
                        {
                            File.Delete(fileToDelete);
                            

                        }


                    }
                    catch (Exception ex)
                    {

                    }
                }
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(uploadFolder + text + extension);
                //  path = FileUpload1.PostedFile.FileName;
                path = text + extension;
                //}
            }
            else
            {
                if (hdnimage.Value != "")
                {
                    path = hdnimage.Value;
                }
            }
           
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            if (hdncourseId.Value != "")
            {
                objLibExam.CourseId = (Convert.ToInt32(hdncourseId.Value));
            }
            else
            {
                objLibExam.CourseId = 0;
            }
            objLibExam.CourseName = Utility.CheckNullString(txtCourse.Text);
            objLibExam.Text1 = Utility.CheckNullString(Editor1.Value);
            //objLibExam.Text2 = Utility.CheckNullString(txtText2.Text);
            //objLibExam.Text3 = Utility.CheckNullString(txtText3.Text);
            //objLibExam.Text4 = Utility.CheckNullString(txtText4.Text);
            objLibExam.TextDetails = Utility.CheckNullString(txtTextDetails.Text);
            objLibExam.ImagePath = Utility.CheckNullString(path);
            if (chkchecked.Checked == true)
            {
                objLibExam.Check = true;
            }
            else
            {
                objLibExam.Check =false;

            }
            if (chkOffered.Checked == true)
            {
                objLibExam.ChkCourseOffered = true;
            }
            else
            {
                objLibExam.ChkCourseOffered = false;

            }
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateCourse(tp);

            if (addResult > 0)
            {
                Uri ur = Request.Url;
                string AbsoluteURL = "";
                if (hdncourseId.Value == "")
                {
                    AbsoluteURL = ur.AbsoluteUri.Replace("addcoursedetails.aspx", "CourseList.aspx");
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Course Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                }
                else
                {
                    AbsoluteURL = ur.AbsoluteUri.Replace("AddCourseDetails.aspx?courseid=" + hdncourseId.Value, "CourseList.aspx");
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Course Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                }
                
            }
            else if (addResult == -11)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Course');", true);
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

    public void bindcoursedetails()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.CourseId = Convert.ToInt32(hdncourseId.Value);
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseListByID(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            txtCourse.Text = objLibExamListing[0].CourseName;
            Editor1.Value = objLibExamListing[0].Text1;
           
            txtTextDetails.Text = objLibExamListing[0].TextDetails;
            hdnimage.Value = objLibExamListing[0].ImagePath;
            chkchecked.Checked = objLibExamListing[0].Check;
            chkOffered.Checked = objLibExamListing[0].ChkCourseOffered ;
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }










    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("courselist.aspx");
    }
}
