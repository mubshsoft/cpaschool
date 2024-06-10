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
public partial class Admin_AddBanner : System.Web.UI.Page
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
            string uploadFolder = Request.PhysicalApplicationPath + "Images\\slider\\";

            if (txtBannerHeading.Text.Length == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks cannot be left blank'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Banner Heading cannot be left blank');", true);
                return;
            }

            if (txtBannerDesc.Text.Length == 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Marks cannot be left blank'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Banner Description cannot be left blank');", true);
                return;
            }

            if (ddlDataOrientation.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Data Orientation');", true);
                return;
            }
            string fileToDelete = "";
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
                string fname = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(uploadFolder + fname);
                //  path = FileUpload1.PostedFile.FileName;
                path = fname;
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
            try
            {
                objLibExam.BannerHeading = Utility.CheckNullString(txtBannerHeading.Text);
                objLibExam.BannerDesc = Utility.CheckNullString(txtBannerDesc.Text);
                objLibExam.dataorientation = ddlDataOrientation.SelectedItem.Text;
                //objLibExam.dataorientation = Utility.CheckNullString(txtdataorientation.Text);
                objLibExam.dataslice1rotation = Utility.CheckNullString(txtdataslice1rotation.Text);
                objLibExam.dataslice2rotation = Utility.CheckNullString(txtdataslice2rotation.Text);
                objLibExam.dataslice1scale = Utility.CheckNullString(txtdataslice1scale.Text);
                objLibExam.dataslice2scale = Utility.CheckNullString(txtdataslice2scale.Text);
                objLibExam.Bannerimages = Utility.CheckNullString(path);

                tp.MessagePacket = (object)objLibExam;
                addResult = OBJDALExam.AddUpdateBanner(tp);

                if (addResult > 0)
                {
                    Uri ur = Request.Url;
                    string AbsoluteURL = "";
                    if (hdncourseId.Value == "")
                    {
                        AbsoluteURL = ur.AbsoluteUri.Replace("AddBanner.aspx", "CourseList.aspx");
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Banner Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                    }
                    else
                    {
                        AbsoluteURL = ur.AbsoluteUri.Replace("AddBanner.aspx?courseid=" + hdncourseId.Value, "CourseList.aspx");
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Banner Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                    }

                }
                else if (addResult == -11)
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Question'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Banner');", true);
                }

                else
                {
                    // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Banner');", true);

                }
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
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
            tp = objDalExam.GetCourseBannerListByID(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            txtBannerHeading.Text = objLibExamListing[0].BannerHeading;
            txtBannerDesc.Text = objLibExamListing[0].BannerDesc;
           // txtdataorientation.Text = objLibExamListing[0].dataorientation;
            ddlDataOrientation.SelectedIndex = ddlDataOrientation.Items.IndexOf(ddlDataOrientation.Items.FindByValue(objLibExamListing[0].dataorientation));

            txtdataslice1rotation.Text = objLibExamListing[0].dataslice1rotation;
            txtdataslice2rotation.Text = objLibExamListing[0].dataslice2rotation;

            txtdataslice1scale.Text = objLibExamListing[0].dataslice1scale;
            txtdataslice2scale.Text = objLibExamListing[0].dataslice2scale;

            hdnimage.Value = objLibExamListing[0].Bannerimages;
            //chkchecked.Checked = objLibExamListing[0].Check;
            //chkOffered.Checked = objLibExamListing[0].ChkCourseOffered;
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
