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

public partial class Admin_EditUnitWithAssestment : System.Web.UI.Page
{
    int pid = 0;
    int mid = 0;
    int semid = 0;
    int uid;

    string Ccode;
    string Stitle;
    string Mtitle;
    string Ptitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                Uri myReferrer = Request.UrlReferrer;
                
                ViewState["pageredirect"]= myReferrer.ToString();
                int chapterid = Convert.ToInt32(Request.QueryString["ChapterID"].ToString());
                int uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());
                DataSet ds = new DataSet();

                Chapter objLIBExam = new Chapter();
                DALChapter objDalExam = new DALChapter();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.UnitID = Convert.ToInt32(uid);
                objLIBExam.ChapterID = chapterid.ToString();
                tp.MessagePacket = (object)objLIBExam;
                ds = objDalExam.GetChapterbyId(tp);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnkcid.Value = ds.Tables[0].Rows[0]["ChapterID"].ToString();
                    txtChapter.Text = ds.Tables[0].Rows[0]["ChapterText"].ToString();
                    ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(ds.Tables[0].Rows[0]["Type"].ToString()));

                    if (ddlType.SelectedIndex == 1)
                    {
                        hdnFilename.Value = ds.Tables[0].Rows[0]["FileName"].ToString();
                        hdnimage.Value = ds.Tables[0].Rows[0]["FilePath"].ToString();
                        dvFile.Visible = true;
                        dvKeyLearning.Visible = false;

                    }
                    else if (ddlType.SelectedIndex == 3)
                    {
                        Editor1.Value = ds.Tables[0].Rows[0]["KeyPoints"].ToString();
                        dvKeyLearning.Visible = true;
                        dvFile.Visible = false;

                    }

                    else if (ddlType.SelectedIndex == 4)
                    {
                        hdnFilename.Value = ds.Tables[0].Rows[0]["FileName"].ToString();
                        hdnimage.Value = ds.Tables[0].Rows[0]["FilePath"].ToString();
                        dvFile.Visible = true;
                        dvKeyLearning.Visible = false;

                    }

                }
            }
        }
        catch (Exception ex)
        { }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string path = "";
            string filename = "";
            string uploadFolder = Request.PhysicalApplicationPath + "upload\\";

            if (ddlType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Type');", true);
                return;
            }

            if (txtChapter.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Chapter name cannot be left blank');", true);
                return;
            }



            string text = Convert.ToString(ddlType.SelectedValue);
            // string fileToDelete = "";

            pid = Convert.ToInt32(Request.QueryString["pid"].ToString());
            mid = Convert.ToInt32(Request.QueryString["mid"].ToString());
            uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());

            GetData(mid, pid);
            //  string URLtext = "";

            if (ddlType.SelectedIndex == 1 || ddlType.SelectedIndex == 4)
            {

                if (FileUpload1.HasFile)
                {
                    if (hdnimage.Value != "")
                    {

                        //fileToDelete = Server.MapPath("../") + hdnimage.Value;
                        //try
                        //{
                        //    if (File.Exists(fileToDelete))
                        //    {
                        //        File.Delete(fileToDelete);
                        //    }
                        //}
                        //catch (Exception ex)
                        //{

                        //}
                    }
                    string type = "";
                    filename = FileUpload1.PostedFile.FileName;
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    if (extension != null)
                    {
                        type = CommonUtility.GetMimeType(extension);
                    }
                    if (ddlType.SelectedIndex == 1)
                    {
                        if (!extension.ToLower().EndsWith("pdf"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached pdf file only.');", true);
                            return;
                        }
                    }

                    if (ddlType.SelectedIndex == 4)
                    {
                        if (!extension.ToLower().EndsWith(".mp4"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Attached MP4 Video File Only.');", true);
                            return;
                        }
                    }
                    string strpath = DateTime.Now.ToString("ddMMyyHHmmss") + "-" + uid + extension;

                    uploadFolder = uploadFolder + Ccode + "\\" + Stitle + "\\" + Mtitle + "\\" + Ptitle + "\\";
                    //FileUpload1.SaveAs(uploadFolder + uid + filename);
                    //path = "upload/" + Ccode + "/" + Stitle + "/" + Mtitle + "/" + Ptitle + "/" + uid + filename;
                    FileUpload1.SaveAs(uploadFolder + strpath);
                    path = "upload/" + Ccode + "/" + Stitle + "/" + Mtitle + "/" + Ptitle + "/" + strpath;

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
            else if (ddlType.SelectedIndex == 3)
            {
                if (Editor1.Value.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Key learning so far points.');", true);
                    return;
                }
            }
            int addResult = 0;
            Chapter objLibExam = new Chapter();
            DALChapter OBJDALExam = new DALChapter();
            TransportationPacket tp = new TransportationPacket();


            if (hdnkcid.Value != "")
            {
                objLibExam.ID = Convert.ToInt32(hdnkcid.Value);
            }
            else
            {
                objLibExam.ID = -1;
            }
            objLibExam.UnitID = uid;
            objLibExam.ChapterText = Utility.CheckNullString(txtChapter.Text);
            objLibExam.FileName = Utility.CheckNullString(filename);
            objLibExam.FilePath = Utility.CheckNullString(path);
            objLibExam.KeyLearning = Utility.CheckNullString(Editor1.Value);
            objLibExam.Type = Utility.CheckNullString(ddlType.SelectedItem.Text);

            if (chkchecked.Checked == true)
            {
                objLibExam.Status = true;
            }
            else
            {
                objLibExam.Status = false;

            }

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateChapter(tp);

            if (addResult > 0)
            {
                string actualURL = "";
                if (ViewState["pageredirect"].ToString() != null)
                {
                    actualURL = ViewState["pageredirect"].ToString();
                }
                if (ddlType.SelectedIndex == 1 || ddlType.SelectedIndex == 4)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Chapter is Updated successfully'); location.href='" + actualURL + "';</script>");
                }
                else if (ddlType.SelectedIndex == 2)
                {
                    //AbsoluteURL = ur.AbsoluteUri.Replace("AddUnitWithAssestment.aspx", "AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterId=" + addResult + "");
                   // AbsoluteURL = "AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterId=" + addResult + "";
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assessments is created successfully'); location.href='" + actualURL + "';</script>");
                }
                else
                {
                    Editor1.Value = "";
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Key Learning Points Updated Successfully'); location.href='" + actualURL + "';</script>");
                }

                ddlType.SelectedIndex = 0;
                txtChapter.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate entry');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save chapter');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    private void GetData(int ModuleId, int paperID)
    {
        DataSet ds = new DataSet();
        ds = CLS_C.fnQuerySelectDs("select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where Module.moduleid=" + Convert.ToInt32(ModuleId) + " and paper.paperID=" + Convert.ToInt32(paperID) + "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Ccode = ds.Tables[0].Rows[0]["CourseCode"].ToString();
            Stitle = ds.Tables[0].Rows[0]["semestertitle"].ToString();
            Mtitle = ds.Tables[0].Rows[0]["moduletitle"].ToString();
            Ptitle = ds.Tables[0].Rows[0]["PaperTitle"].ToString();

        }


    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if(ViewState["pageredirect"].ToString()!=null)
        {
            string actual = ViewState["pageredirect"].ToString();
            Response.Redirect(actual);
        }
        else
        {
            Response.Redirect("AdminLogin.aspx");
        }
        
    }

}