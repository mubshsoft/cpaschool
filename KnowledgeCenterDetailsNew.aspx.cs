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

public partial class KnowledgeCenterDetailsNew : System.Web.UI.Page
{
    protected string thumb = null;
    protected string video = null;
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

    protected void gvKnowledgecenterList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            Image img = item.FindControl("img") as Image;
            LinkButton btn = (LinkButton)item.FindControl("linkdesc");

            string hdnsubjecttype = (item.FindControl("hdnsubjecttype") as Label).Text;
            if (hdnsubjecttype == "Video Pods")
            {
                img.ImageUrl = "images/KnowledgeCenter-video.png";
            }
            else
            {
                img.ImageUrl = "images/KnowledgeCenter-articles.png";
            }

            //btn.Visible = true;
            //string name = (item.FindControl("lblName") as Label).Text;
            //string country = (item.FindControl("lblCountry") as Label).Text;
        }
    }

    protected void Getdescription(object sender, EventArgs e)
    {
        //Reference the Repeater Item using Button.
        RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;

        int id =Convert.ToInt32((item.FindControl("hdnId") as Label).Text);
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
}