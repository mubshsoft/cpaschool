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

public partial class Admin_Knowledgecenter : System.Web.UI.Page
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
                BindCorseDropDown();
                if (Request.QueryString.Count > 0)
                {
                    hdnkcid.Value = Request.QueryString["kcid"];
                   
                    bindKnowledgeCenter();
                }


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void BindCorseDropDown()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourse(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select-");

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
            string filename = "";
            string uploadFolder = Request.PhysicalApplicationPath + "KnowledgeCenter\\";

            if (ddlCourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Course');", true);
                return;
            }

            if (ddlSubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Subject Knowledge Center Type');", true);
                return;
            }

            if (ddlSubject.SelectedIndex == 2)
            {
                if (ddlSourceType.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Source - Online or Offline');", true);
                    return;
                }

                if (ddlSourceType.SelectedItem.Text  == "Online" && txtURL.Text.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Enter URL');", true);
                    return;
                }

               
            }

            if (txtCaption.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Caption cannot be left blank');", true);
                return;
            }

            if (Editor1.Value.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Description cannot be left blank');", true);
                return;
            }

            string text = Convert.ToString(ddlSubject.SelectedValue);
            string fileToDelete = "";

            string SourceType = "Offline";
            string URLtext = "";
            if (ddlSubject.SelectedIndex == 2 && ddlSourceType.SelectedItem.Text == "Online")
            {
                SourceType = "Online";
                URLtext = txtURL.Text.Trim();
                // for online link . ie https://www.youtube.com/
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    if (hdnimage.Value != "")
                    {

                        fileToDelete = Server.MapPath("../") + hdnimage.Value;
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
                    string type = "";
                    filename = FileUpload1.PostedFile.FileName;
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    if (extension != null)
                    {
                        type = CommonUtility.GetMimeType(extension);
                    }
                    if (ddlSubject.SelectedIndex == 2 && ddlSourceType.SelectedItem.Text == "Offline")
                    {
                        if (!type.ToString().Contains("video"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached video file only.');", true);
                            return;
                        }
                    }
                    FileUpload1.SaveAs(uploadFolder + text + filename);

                    path = "KnowledgeCenter/" + text + filename;

                }
                else
                {
                    if (hdnimage.Value != "")
                    {
                        filename = hdnFilename.Value;
                        path = hdnimage.Value;
                    }
                }

                if (path.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached file.');", true);
                    return;
                }
            }
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

           
            if (hdnkcid.Value !="" )
            {
                objLibExam.KCID = Convert.ToInt32(hdnkcid.Value);
            }
            else
            {
                objLibExam.KCID = -1;
            }

            objLibExam.Courseid =Convert.ToInt32(ddlCourse.SelectedValue);
            objLibExam.Caption = Utility.CheckNullString(txtCaption.Text);
            objLibExam.KnowledgeCenterDescription = Utility.CheckNullString(Editor1.Value);         
            objLibExam.KnowledgeCenterType = Utility.CheckNullString(ddlSubject.SelectedItem.Text);
            objLibExam.FileName = Utility.CheckNullString(filename);
            objLibExam.FilePath = Utility.CheckNullString(path);

            objLibExam.FileMode = Utility.CheckNullString(SourceType);
            objLibExam.URLlink = Utility.CheckNullString(URLtext);
            if (chkchecked.Checked == true)
            {
                objLibExam.Check = true;
            }
            else
            {
                objLibExam.Check = false;

            }
            
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateKnowledgeCenter(tp);

            if (addResult > 0)
            {
                Uri ur = Request.Url;
                string AbsoluteURL = "";
               
                    AbsoluteURL = ur.AbsoluteUri.Replace("Knowledgecenter.aspx", "KnowledgecenterList.aspx");
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Knowledge Center Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
             
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate entry');", true);
            }

            else
            {
                // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save knowledge center');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    public void bindKnowledgeCenter()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            objLIBExam.KCID = Convert.ToInt32(hdnkcid.Value);
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetKnowledgeCenterListByID(tp);
            objLibExamListing = (LIBStudentListing)tp.MessageResultset;

            txtCaption.Text = objLibExamListing[0].Caption;
            Editor1.Value = objLibExamListing[0].KnowledgeCenterDescription;
            txtURL.Text = objLibExamListing[0].URLlink;
            ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(objLibExamListing[0].Courseid.ToString()));
            ddlSubject.SelectedIndex = ddlSubject.Items.IndexOf(ddlSubject.Items.FindByText(objLibExamListing[0].KnowledgeCenterType));
            if (ddlSubject.SelectedIndex == 2)
            {
                ddlSourceType.Visible = true;
                ddlSourceType.SelectedIndex = ddlSourceType.Items.IndexOf(ddlSourceType.Items.FindByText(objLibExamListing[0].FileMode));

                if(ddlSourceType.SelectedItem.Text=="Online")
                {
                    dvURL.Visible= true;
                }
            }
            hdnFilename.Value= objLibExamListing[0].FileName;
            hdnimage.Value = objLibExamListing[0].FilePath;
            chkchecked.Checked = objLibExamListing[0].Check;
            
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("KnowledgecenterList.aspx");
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSubject.SelectedValue.ToString()=="2")
        {
            ddlSourceType.Visible = true;
        }
        else
        {
            ddlSourceType.Visible = false;
            
        }
    }

    protected void ddlSourceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSourceType.SelectedItem.Text == "Online")
        {
            dvURL.Visible = true;
        }
        else if (ddlSourceType.SelectedItem.Text == "Offline")
        {
            dvURL.Visible = false;
        }
    }
}
