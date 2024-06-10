using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class KnowledgeCenterDetails : System.Web.UI.Page
{
    protected string thumb = null;
    protected string video = null;
    protected string DemoVideo = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {

            if (!Page.IsPostBack)
            {
                if (Session.Count > 0)
                {
                    if (Session["role"] != null)
                    {
                        if (Session["role"].ToString() == "Admin")
                        {
                            pnl.HRef = "admin/AdminLogin.aspx";
                            lblPanel.Text = "Admin Panel";
                        }
                        else if (Session["role"].ToString() == "Faculty")
                        {
                            pnl.HRef = "faculty/Facultypanel.aspx";
                            lblPanel.Text = "Faculty Panel";
                        }
                        else if (Session["role"].ToString() == "Student")
                        {
                            pnl.HRef = "Student/StudentDashboard.aspx";
                            lblPanel.Text = "Faculty Panel";
                        }
                        else
                        {
                            pnl.Visible = false;
                            
                        }
                    }
                }
                else
                {
                    pnl.Visible = false;
                    
                }
                BindKnowledgeCenterList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
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

            DataTable dt = new DataTable();
            dt = (DataTable)ds.Tables[0];
            DataView dataView = dt.DefaultView;

            dataView.RowFilter = "SubjectType = '" + Request.QueryString["SubjectType"].ToString() + "' and checked=1";
           
            if (dataView.Count  > 0)
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
                    else if(hdnFileMode.Value == "Offline")
                    {
                        linkPlay.Visible = true;
                        lnkDownload.Visible = true;
                    }
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
            if(e.CommandName== "Description")
            {
                int id =Convert.ToInt32(e.CommandArgument.ToString());
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

                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDiv');</script>");
               
               
            }

            if(e.CommandName== "PlayVideo")
            {
                string path = e.CommandArgument.ToString();
               
               // ifrm.Attributes.Add("src", path);
                // thumb = Server.MapPath("~") + "/KnowledgeCenter/"+ "2.jpg"; //"http://www." + ConfigurationSettings.AppSettings["JournalNameShort"].ToString() + ConfigurationSettings.AppSettings["JournalDomainName"].ToString() + ds.Tables[0].Rows[0]["ImagePath"].ToString().Replace("_eJournals/", "/eJournals/");
                //video = Server.MapPath("~") + "/KnowledgeCenter/" + "2Installing aspnet mvc - Part 1(720p).MP4";// "http://www." + ConfigurationSettings.AppSettings["JournalNameShort"].ToString() + ConfigurationSettings.AppSettings["JournalDomainName"].ToString() + dsVideos.Tables[0].Rows[0]["FilePath"].ToString().Replace("_eJournals/", "/eJournals/");

                DemoVideo = path;

                
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");
                
            }
            if (e.CommandName == "PlayOlineVideo")
            {
                string path = e.CommandArgument.ToString();
                DemoVideo = path;
                //ifrm.Attributes.Add("src", path);
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayOnlineVideo');</script>");

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

    [WebMethod]
    public static string CallBackdata(string Name, string Email, string Mobile)
    {

       
        int rtVal = 0;
        try
        {
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.StudentName = Utility.CheckNullString(Name);
            objLibExam.StudentEmail = Utility.CheckNullString(Email);
            objLibExam.ContactNumber1 = Utility.CheckNullString(Mobile);
            
            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateCallBack(tp);

            if (addResult > 0)
            {
                rtVal = addResult;
            }
            
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        
        return rtVal.ToString();

    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string ChkEmailAddress(string StudentEmail)
    {
        DataSet ds = new DataSet();
        string retJSON = "";

        LIBStudent objLibExam = new LIBStudent();
        DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
        LIBStudentListing objLibListing = new LIBStudentListing();
        TransportationPacket tp = new TransportationPacket();

        objLibExam.StudentEmail = StudentEmail;
        

        tp.MessagePacket = (object)objLibExam;
        tp = OBJDALExam.GetStudentDetails(tp);
        objLibListing = (LIBStudentListing)tp.MessageResultset;
        List<LIBStudent> ls = objLibListing;
        if (objLibListing != null)
        {
            if (objLibListing.Count > 0)
            {
                var json = new
                {
                    rows = ls

                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                 retJSON = js.Serialize(json);
            }
        }

        // Return JSON data
        
        return retJSON;

    }
    
}
