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

public partial class Admin_AddInduction : System.Web.UI.Page
{
    protected string inductionVideo = "";
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

                BindCorseDropDown();
                bindInductionList();
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
            string uploadFolder = Request.PhysicalApplicationPath + "InductionFile\\";

            if (ddlCourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Course');", true);
                return;
            }

            if (ddlSubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Type');", true);
                return;
            }

            if (ddlSubject.SelectedItem.Text.ToLower() == "ppt")
            {
                if (txtURL.Text.Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Google Drive share link for PPT');", true);
                    return;
                }
            }
            if (txtCaption.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Caption cannot be left blank');", true);
                return;
            }
            string text = Convert.ToString(ddlSubject.SelectedValue);
            string fileToDelete = "";
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

                if (ddlSubject.SelectedItem.Text.ToLower() == "pdf")
                {
                    if (extension.ToLower() != ".pdf")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached PDF file only.');", true);
                        return;
                    }
                }

                if (ddlSubject.SelectedItem.Text.ToLower() == "video")
                {
                    if (!type.ToString().Contains("video"))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached video file only.');", true);
                        return;
                    }
                }

                //if (ddlSubject.SelectedItem.Text.ToLower() == "ppt")
                //{
                    
                //    //if (!type.ToString().Contains("presentation"))
                //    //{
                //    //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please attached PPT file only.');", true);
                //    //    return;
                //    //}
                //}

                FileUpload1.SaveAs(uploadFolder + text + filename);

                path = "InductionFile/" + text + filename;

            }
            else
            {
                if (hdnimage.Value != "")
                {
                    filename = hdnFilename.Value;
                    path = hdnimage.Value;
                }
            }

            if (ddlSubject.SelectedItem.Text.ToLower() == "ppt")
            {
            }
            else
            {
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


            if (hdnid.Value != "")
            {
                objLibExam.KCID = Convert.ToInt32(hdnid.Value);
            }
            else
            {
                objLibExam.KCID = -1;
            }

            objLibExam.Courseid = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
            objLibExam.KnowledgeCenterType = Utility.CheckNullString(ddlSubject.SelectedItem.Text);
            objLibExam.Caption = Utility.CheckNullString(txtCaption.Text);
            if (ddlSubject.SelectedItem.Text.ToLower() == "ppt")
            {
                objLibExam.FileName = "Google Drive Link";
                objLibExam.FilePath = Utility.CheckNullString(txtURL.Text);
            }
            else
            {
                objLibExam.FileName = Utility.CheckNullString(filename);
                objLibExam.FilePath = Utility.CheckNullString(path);
            }

            if (chkchecked.Checked == true)
            {
                objLibExam.Check = true;
            }
            else
            {
                objLibExam.Check = false;

            }

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateInduction(tp);

            if (addResult > 0)
            {
                if (btnSave.Text == "Save")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Added !');location.href='AddInduction.aspx';</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Updated !');location.href='AddInduction.aspx';</script>");
                }
                bindInductionList();
                hdnid.Value = "";
                txtCaption.Text = "";
                ddlCourse.SelectedIndex = 0;
                ddlSubject.SelectedIndex = 0;
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Induction File.');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save demo file');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    public void bindInduction(int id)
    {
        try
        {
            DataSet ds = new DataSet();
            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            objLIBExam.KCID = id;
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetInductionList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCaption.Text = ds.Tables[0].Rows[0]["Caption"].ToString();
                ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(ds.Tables[0].Rows[0]["CourseId"].ToString()));
                ddlSubject.SelectedIndex = ddlSubject.Items.IndexOf(ddlSubject.Items.FindByText(ds.Tables[0].Rows[0]["Type"].ToString()));
                hdnFilename.Value = ds.Tables[0].Rows[0]["FileName"].ToString();
                
                if (ds.Tables[0].Rows[0]["Type"].ToString() == "PPT")
                {
                    txtURL.Text = ds.Tables[0].Rows[0]["FilePath"].ToString();
                    hdnimage.Value = "";
                    dvPPT.Visible = true;
                    dvFile.Visible = false;
                }
                else
                {
                    hdnimage.Value = ds.Tables[0].Rows[0]["FilePath"].ToString();
                    dvPPT.Visible = false;
                    dvFile.Visible = true;
                }
                

                chkchecked.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Checked"].ToString());
                btnSave.Text = "Update";
            }



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void bindInductionList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.KCID = 0;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetInductionList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvInductionList.DataSource = ds;
                gvInductionList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvInductionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value;
        string hdnfilepath = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnfilepath")).Value;

        try
        {
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.KCID = Convert.ToInt32(hdnId);
            tp.MessagePacket = (object)objLibExam;

            addResult = OBJDALExam.DeleteInductionFile(tp);

            string fileToDelete = "";
            string uploadFolder = Server.MapPath("../");
            if (hdnfilepath != "")
            {
                fileToDelete = uploadFolder + hdnfilepath;
                try
                {
                    if (File.Exists(fileToDelete))
                    {
                        if (File.Exists(fileToDelete))
                        {
                            File.Delete(fileToDelete);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            bindInductionList();
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Deleted Successfully.');", true);

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvInductionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");
                HiddenField type = (HiddenField)e.Row.FindControl("type");

                LinkButton linkPlay = (LinkButton)e.Row.FindControl("linkPlay");
                LinkButton linkPPT = (LinkButton)e.Row.FindControl("linkPPT");
                LinkButton LinkPDF = (LinkButton)e.Row.FindControl("LinkPDF");

                if (type.Value == "Video")
                {
                    linkPlay.Visible = true;
                }
                if (type.Value == "PPT")
                {
                    linkPPT.Visible = true;
                }
                if (type.Value == "PDF")
                {
                    LinkPDF.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvInductionList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvInductionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInductionList.PageIndex = e.NewPageIndex;
        bindInductionList();
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }


    protected void gvInductionList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditData")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                hdnid.Value = id.ToString();
                bindInduction(id);
            }

            if (e.CommandName == "PlayVideo")
            {
                string path = "../" + e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvInductionList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblDescription.Text = lblCaption;
                inductionVideo = path;
                //ifrm.Attributes.Add("src", path);

                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");

            }

            if (e.CommandName == "PPT")
            {
                string path = e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvInductionList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblCaptionppt.Text = lblCaption;

                lblHeding.Text = "Induction PPT";
                ifrm.Attributes.Add("src", path);
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPPT');</script>");

            }

            if (e.CommandName == "PDF")
            {
                string path = "../" + e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvInductionList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblCaptionppt.Text = lblCaption;

                lblHeding.Text = "Induction PDF";

                ifrm.Attributes.Add("src", path);
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPPT');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSubject.SelectedItem.Text=="PPT")
        {
            dvFile.Visible = false;
            dvPPT.Visible = true;
        }
        else
        {
            dvFile.Visible = true;
            dvPPT.Visible = false;
        }
    }
}
