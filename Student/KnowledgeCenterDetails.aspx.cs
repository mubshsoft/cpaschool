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
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using fmsf.lib;
using fmsf.DAL;

public partial class Student_KnowledgeCenterDetails : System.Web.UI.Page
{
    protected string thumb = null;
    protected string video = null;
    protected string PlayVideo = null;
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {

            if (!Page.IsPostBack)
            {
                ddlSubject.SelectedIndex = 1;
             DataSet ds=   CLS_C.fnQuerySelectDs("select c.* from StudentRegcourse  s join course c on s.courseid=c.courseid where stid="+Session["stid"].ToString());
             ddlcourse.DataSource = ds;
             ddlcourse.DataTextField = "coursetitle";
             ddlcourse.DataValueField = "courseid";
             ddlcourse.DataBind();
             ddlcourse.Items.Insert(0, "Select Course");
                BindKnowledgeCenterList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindKnowledgeCenterList();
        }
        catch(Exception ex)
        {

        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcourse.SelectedIndex > 0)
            {

                DataSet ds = (DataSet)ViewState["ds"];
                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ds.Tables[0].DefaultView.RowFilter = "courseid=" + ddlcourse.SelectedValue + " and SubjectType = '" + ddlSubject.SelectedItem.Text.ToString() + "' and checked=1"; ;

                            gvKnowledgecenterList.DataSource = ds.Tables[0].DefaultView;
                            gvKnowledgecenterList.DataBind();

                        }
                    }
                }
            }
            else
            {
                BindKnowledgeCenterList();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void BindKnowledgeCenterList()
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

            ds = objDalExam.GetKNDetails(tp);
            ViewState["ds"] = ds;
            DataTable dt = new DataTable();
            dt = (DataTable)ds.Tables[0];
            DataView dataView = dt.DefaultView;

            dataView.RowFilter = "SubjectType = '" + ddlSubject.SelectedItem.Text.ToString() + "' and checked=1";

            if (dataView.Count > 0)
            {
                gvKnowledgecenterList.DataSource = dataView;
                gvKnowledgecenterList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void gvKnowledgecenterList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");
                HiddenField hdnFileMode = (HiddenField)e.Row.FindControl("hdnFileMode");
                HiddenField hdnURLlink = (HiddenField)e.Row.FindControl("hdnURLlink");
                HiddenField hdnsubjecttype = (HiddenField)e.Row.FindControl("hdnsubjecttype");


                HtmlAnchor lnkDownload = (HtmlAnchor)e.Row.FindControl("lnkDownload");
                // a1.HRef = "www.mySite.com/mypage.aspx";


                LinkButton linkPlay = (LinkButton)e.Row.FindControl("linkPlay");
                LinkButton linkPlayOnline = (LinkButton)e.Row.FindControl("linkPlayOnline");
                if (hdnsubjecttype.Value == "Video Pods")
                {

                    if (hdnFileMode.Value == "Online")
                    {
                        linkPlayOnline.Visible = true;
                        lnkDownload.Visible = false;
                    }
                    else if (hdnFileMode.Value == "Offline")
                    {
                        linkPlay.Visible = true;
                        lnkDownload.Visible = true;
                    }
                  
                          
                }
                string uploadFolder = Server.MapPath("~") + lnkDownload.HRef.Replace("../","/");
                System.IO.FileInfo file = new System.IO.FileInfo(uploadFolder);
                if (!file.Exists)
                {
                    lnkDownload.Visible = false;
                }
                //LinkButton linkEdit = (LinkButton)e.Row.FindControl("linkEdit");
                //linkEdit.PostBackUrl = "~/Admin/Knowledgecenter.aspx?kcid=" + hdnId.Value;
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }





    protected void gvKnowledgecenterList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("addcoursedetails.aspx");
    }
    protected void gvKnowledgecenterList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKnowledgecenterList.PageIndex = e.NewPageIndex;
        BindKnowledgeCenterList();
    }

    protected void gvKnowledgecenterList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Description")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet ds = new DataSet();

                LIBStudent objLIBExam = new LIBStudent();
                DalAddStudent_CS objDalExam = new DalAddStudent_CS();
                LIBStudentListing objLibExamListing = new LIBStudentListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.KCID = id;

                tp.MessagePacket = (object)objLIBExam;

                ds = objDalExam.GetKNDetails(tp);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlstKnowledgecenter.DataSource = ds;
                    dlstKnowledgecenter.DataBind();
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "javascript:document.getElementById('hrf1').click();", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:document.getElementById('hrf1').click();</script>");


            }

            if (e.CommandName == "PlayVideo")
            {
                string path = e.CommandArgument.ToString();
                PlayVideo = path;
                //ifrm.Attributes.Add("src", path);
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "javascript:openmodalPopUp('ModalPopupDivPlayVideo');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");

            }
            if (e.CommandName == "PlayOlineVideo")
            {
                string path = e.CommandArgument.ToString();
                PlayVideo = path;
                //ifrm.Attributes.Add("src", path);
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "javascript:openmodalPopUp('ModalPopupDivPlayVideo');", true);
              //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");

            }
            if (e.CommandName == "Download")
            {

                string path = e.CommandArgument.ToString();
                string uploadFolder = Server.MapPath("~") + "KnowledgeCenter\\" + "1Maldives_tablename.docx";
                System.IO.FileInfo file = new System.IO.FileInfo(uploadFolder);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    Response.Write("<script language='javascript' type='text/javascript'>alert('file does not exist'); history.go(-1)</script>");
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
}