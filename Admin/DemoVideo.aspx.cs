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

public partial class Admin_DemoVideo : System.Web.UI.Page
{
    protected string DemoVideo = "";
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
                //if (Request.QueryString.Count > 0)
                //{
                //    hdnid.Value = Request.QueryString["id"];
                //    btnSave.Text = "Update";
                  
                //}
                BindDemoList();
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
            string filename = "";
            string uploadFolder = Request.PhysicalApplicationPath + "KnowledgeCenter\\";

            if (txtCaption.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Caption cannot be left blank');", true);
                return;
            }
            if (ddlSubject.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Subject Knowledge Center Type');", true);
                return;
            }

            //if (Editor1.Value.Length == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Description cannot be left blank');", true);
            //    return;
            //}

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

                if (ddlSubject.SelectedItem.Text.ToLower() =="pdf") 
                {
                    if(extension.ToLower() != ".pdf")
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
            objLibExam.Caption = Utility.CheckNullString(txtCaption.Text);
            //objLibExam.KnowledgeCenterDescription = Utility.CheckNullString(Editor1.Value);
            objLibExam.KnowledgeCenterType = Utility.CheckNullString(ddlSubject.SelectedItem.Text);
            objLibExam.FileName = Utility.CheckNullString(filename);
            objLibExam.FilePath = Utility.CheckNullString(path);
            if (chkchecked.Checked == true)
            {
                objLibExam.Check = true;
            }
            else
            {
                objLibExam.Check = false;

            }

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateDemofile(tp);

            if (addResult > 0)
            {
                if (btnSave.Text == "Save")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Added !');location.href='DemoVideo.aspx';</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Successfully Updated !');location.href='DemoVideo.aspx';</script>");
                }
                BindDemoList();
                hdnid.Value = "";
                txtCaption.Text = "";
                ddlSubject.SelectedIndex = 0;
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Course');", true);
            }

            else
            {
                // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam Question'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save demo file');", true);

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    public void bindDemo(int id)
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
            
            ds = objDalExam.GetDemoList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCaption.Text = ds.Tables[0].Rows[0]["Caption"].ToString();
                ddlSubject.SelectedIndex = ddlSubject.Items.IndexOf(ddlSubject.Items.FindByText(ds.Tables[0].Rows[0]["Type"].ToString()));
                hdnFilename.Value = ds.Tables[0].Rows[0]["FileName"].ToString();
                hdnimage.Value = ds.Tables[0].Rows[0]["FilePath"].ToString();
                
                chkchecked.Checked =Convert.ToBoolean(ds.Tables[0].Rows[0]["Checked"].ToString());
                btnSave.Text = "Update";
            }
            
            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindDemoList()
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

            ds = objDalExam.GetDemoList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDemoList.DataSource = ds;
                gvDemoList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvDemoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
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

            addResult = OBJDALExam.DeleteDemoFile(tp);

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

            BindDemoList();
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Deleted Successfully.');", true);
            
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvDemoList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");
                HiddenField type = (HiddenField)e.Row.FindControl("type");
                // LinkButton linkEdit = (LinkButton)e.Row.FindControl("linkEdit");
                // linkEdit.PostBackUrl = "~/Admin/DemoVideo.aspx?id=" + hdnId.Value;

                LinkButton linkPlay = (LinkButton)e.Row.FindControl("linkPlay");
                if (type.Value == "Video")
                {
                    linkPlay.Visible = true;
                }
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvDemoList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvDemoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDemoList.PageIndex = e.NewPageIndex;
        BindDemoList();
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }

  
    protected void gvDemoList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditData")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                hdnid.Value = id.ToString();
                bindDemo(id);
            }

            if (e.CommandName == "PlayVideo")
            {
                string path = "../" + e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvDemoList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblDescription.Text = lblCaption;

               // ifrm.Attributes.Add("src", path);
                DemoVideo = path;

                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openmodalPopUp('ModalPopupDivPlayVideo');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:$(function(){openmodalPopUp('ModalPopupDivPlayVideo');})</script>", false);

            }
        }
        catch (Exception ex)
        {

        }
    }
}
