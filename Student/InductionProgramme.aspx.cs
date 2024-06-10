using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections;
using fmsf.lib;
using fmsf.DAL;
using System.Data.SqlClient;

public partial class Student_InductionProgramme : System.Web.UI.Page
{
    protected string inductionVideo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        if (!Page.IsPostBack)
        {
            try
            {
                BindCorseDropDown();
                ddlCourse.SelectedIndex = 1;
                bindInductionList(Convert.ToInt32(ddlCourse.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {

            }
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
            objLIBExam.Stid = Convert.ToInt32(Session["stid"]);
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourseBYid(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select Course-");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Course');", true);
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
        bindInductionList(CourseId);
    }
    protected void bindInductionList(int CourseId)
    {
        try
        {
            int courseid = Convert.ToInt32(ddlCourse.SelectedValue.ToString());
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
                ds.Tables[0].DefaultView.RowFilter = "courseid = " + courseid;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();
                gvInductionList.DataSource = dt;
                gvInductionList.DataBind();
            }
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
        bindInductionList(Convert.ToInt32(ddlCourse.SelectedValue.ToString()));
    }
    protected void gvInductionList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            

            if (e.CommandName == "PlayVideo")
            {
                string path = "../" + e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvInductionList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblDescription.Text = lblCaption;
                inductionVideo = path;
                //ifrm.Attributes.Add("src", path);

                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:openmodalPopUp('ModalPopupDivPlayVideo');</script>");
                
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "success", "<script>$(function(){openmodalPopUp('ModalPopupDivPlayVideo');})</script>", false);
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
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:$(function(){openmodalPopUp('ModalPopupDivPPT');})</script>",false);

            }

            if (e.CommandName == "PDF")
            {
                string path ="../"+ e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int id = (int)gvInductionList.DataKeys[row.RowIndex].Value;
                string lblCaption = ((Label)row.FindControl("lblCaption")).Text.ToString();
                lblCaptionppt.Text = lblCaption;

                lblHeding.Text = "Induction PDF";
                
                ifrm.Attributes.Add("src", path);
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>javascript:$(function(){openmodalPopUp('ModalPopupDivPPT');})</script>",false);
            }

        }
        catch (Exception ex)
        {

        }
    }
}