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

public partial class Admin_AddUnitWithAssestment : System.Web.UI.Page
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
                    pid = Convert.ToInt32(Request.QueryString["pid"].ToString());
                    semid = Convert.ToInt32(Request.QueryString["sid"].ToString());
                    mid = Convert.ToInt32(Request.QueryString["mid"].ToString());
                    uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());
                    BindChapterList();
                }


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
            semid = Convert.ToInt32(Request.QueryString["sid"].ToString());
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
                        if (!extension.ToLower().EndsWith(".pdf"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Attached PDF File Only.');", true);
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
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Attached File.');", true);
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

            objLibExam.Type = Utility.CheckNullString(ddlType.SelectedItem.Text);
            objLibExam.KeyLearning = Utility.CheckNullString(Editor1.Value);
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
                Uri ur = Request.Url;
                string AbsoluteURL = "";
                if (ddlType.SelectedIndex == 1)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Chapter is Uploaded Successfully'); </script>");
                }
                else if (ddlType.SelectedIndex == 2)
                {
                    //AbsoluteURL = ur.AbsoluteUri.Replace("AddUnitWithAssestment.aspx", "AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterId=" + addResult + "");
                    AbsoluteURL = "AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterId=" + addResult + "";
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assessments is Created Successfully'); location.href='" + AbsoluteURL + "';</script>");
                }
                else if (ddlType.SelectedIndex == 4)
                {

                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Chapter is Uploaded Successfully'); </script>");
                }
                else
                {
                    Editor1.Value = "";
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Key Learning Points Addedd Successfully'); </script>");

                }

                ddlType.SelectedIndex = 0;
                txtChapter.Text = "";
                BindChapterList();
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

    protected void BindChapterList()
    {
        try
        {
            uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());
            DataSet ds = new DataSet();
            Chapter objLIBExam = new Chapter();
            DALChapter objDalExam = new DALChapter();
            ChapterListing objLibExamListing = new ChapterListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UnitID = uid;

            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetChapterListbyUnit(tp);
            objLibExamListing = (ChapterListing)tp.MessageResultset;
            gvChapterList.DataSource = objLibExamListing;
            gvChapterList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void gvChapterList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton valu = (LinkButton)e.Row.FindControl("lnkQuestion");
                LinkButton lnkFiledownload = (LinkButton)e.Row.FindControl("lnkFiledownload");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

                Label lblType = (Label)e.Row.FindControl("lblType");

                HiddenField hdnChapterID = (HiddenField)e.Row.FindControl("hdnChapterID");

                pid = Convert.ToInt32(Request.QueryString["pid"].ToString());
                semid = Convert.ToInt32(Request.QueryString["sid"].ToString());
                mid = Convert.ToInt32(Request.QueryString["mid"].ToString());
                uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());

                if (lblType.Text == "Assessments Question")
                {
                    valu.PostBackUrl = "~/Admin/AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterID=" + Convert.ToInt32(hdnChapterID.Value);
                    valu.Visible = true;
                    lnkFiledownload.Visible = false;
                    lnkEdit.Visible = false;
                }
                else
                {
                    valu.Visible = false;
                    lnkFiledownload.Visible = true;
                    lnkEdit.Visible = true;
                    lnkEdit.PostBackUrl = "~/Admin/EditUnitWithAssestment.aspx?UnitID=" + uid + "&ChapterID=" + Convert.ToInt32(hdnChapterID.Value) + "&mid=" + mid + "&pid=" + pid +"";
                    lnkFiledownload.PostBackUrl = "~/Admin/AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterID=" + Convert.ToInt32(hdnChapterID.Value);
                }

                //LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteQuestion");
                //l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Question ? '); ");



            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlType.SelectedIndex == 1)
        {
            dvFile.Visible = true;
            dvKeyLearning.Visible = false;
        }

        else if (ddlType.SelectedIndex == 2)
        {
            dvFile.Visible = false;
            dvKeyLearning.Visible = false;
        }
        else if (ddlType.SelectedIndex == 4)
        {
            dvFile.Visible = true;
            dvKeyLearning.Visible = false;
        }
        else
        {
            dvFile.Visible = false;
            dvKeyLearning.Visible = true;
        }


       

    }
    //public void bindKnowledgeCenter()
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        LIBStudent objLIBExam = new LIBStudent();
    //        DalAddStudent_CS objDalExam = new DalAddStudent_CS();
    //        LIBStudentListing objLibExamListing = new LIBStudentListing();
    //        objLIBExam.KCID = Convert.ToInt32(hdnkcid.Value);
    //        TransportationPacket tp = new TransportationPacket();
    //        tp.MessagePacket = (object)objLIBExam;
    //        tp = objDalExam.GetKnowledgeCenterListByID(tp);
    //        objLibExamListing = (LIBStudentListing)tp.MessageResultset;

    //        txtChapter.Text = objLibExamListing[0].Caption;
    //        ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(objLibExamListing[0].Courseid.ToString()));

    //        hdnFilename.Value = objLibExamListing[0].FileName;
    //        hdnimage.Value = objLibExamListing[0].FilePath;
    //        chkchecked.Checked = objLibExamListing[0].Check;

    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}


    protected void gvChapterList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                int ID = Convert.ToInt32(e.CommandArgument.ToString());
                int uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());

                Chapter objLIBExam = new Chapter();
                DALChapter objDalExam = new DALChapter();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.UnitID = Convert.ToInt32(uid);
                objLIBExam.ID = ID;
                tp.MessagePacket = (object)objLIBExam;

                int addResult = objDalExam.DeleteAssessmentChapter(tp);
                if (addResult > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Chapter is Removed Successfully'); </script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to remove chapter');", true);
                }
            }
            if (e.CommandName == "Edit")
            {
                int chapterid = Convert.ToInt32(e.CommandArgument.ToString());
                int uid = Convert.ToInt32(Request.QueryString["unitid"].ToString()); ;
                DataSet ds = new DataSet();

                Chapter objLIBExam = new Chapter();
                DALChapter objDalExam = new DALChapter();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.UnitID = Convert.ToInt32(uid);
                objLIBExam.ChapterID = chapterid.ToString();
                tp.MessagePacket = (object)objLIBExam;
                ds = objDalExam.GetChapterbyId(tp);


                //Response.Redirect("AddAssessmentsQuestion.aspx?UnitID=" + uid + "&ChapterID=" + chapterid + "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    hdnkcid.Value = ds.Tables[0].Rows[0]["ChapterID"].ToString();
                    txtChapter.Text = ds.Tables[0].Rows[0]["ChapterText"].ToString();
                    ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(ds.Tables[0].Rows[0]["Type"].ToString()));

                    //if (ddlType.SelectedIndex == 1)
                    //{
                    //    dvFile.Visible = true;

                    //}
                    //else if (ddlType.SelectedIndex == 3)
                    //{

                    //    dvFile.Visible = false;

                    //}


                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }

    

    protected void gvChapterList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            
                GridView gvTemp = (GridView)sender;
                int ID =Convert.ToInt32(((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value);
                int uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());

                Chapter objLIBExam = new Chapter();
                DALChapter objDalExam = new DALChapter();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.UnitID = Convert.ToInt32(uid);
                objLIBExam.ID = ID;
                tp.MessagePacket = (object)objLIBExam;

                int addResult = objDalExam.DeleteAssessmentChapter(tp);
                if (addResult > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Chapter is Removed Successfully'); </script>");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to remove chapter');", true);
                }

                BindChapterList();
            
        }
        catch (Exception ex)
        { }
    }
}