﻿using System;
using System.IO;
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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class AddPaperFile : System.Web.UI.Page
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
            if (Session.Count <= 0)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!Page.IsPostBack)
            {

                BindCorseDropDown();
                BindPaperFileList();
               

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindPaperFileList()
    {
        try
        {

            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetPaperFile(tp);

            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdExamSet.DataSource = ds;
            grdExamSet.DataBind();

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
            ddlCourse.Items.Insert(0,"-Select-");

           



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindSemesterDropDown(int CourseId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = CourseId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSemester(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlSem.DataSource = objLibExamListing;
            ddlSem.DataTextField = objLIBExam.SemesterDispalyText;
            ddlSem.DataValueField = objLIBExam.SemesterValueField;
            ddlSem.DataBind();
            ddlSem.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindModuleDropDown(int SemId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.SemesterId = SemId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetModule(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlModule.DataSource = objLibExamListing;
            ddlModule.DataTextField = objLIBExam.ModuleDispalyText;
            ddlModule.DataValueField = objLIBExam.ModuleValueField;
            ddlModule.DataBind();
            ddlModule.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindPaperDropDown(int ModuleId)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ModuleId = ModuleId;
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetPaper(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlPaper.DataSource = objLibExamListing;
            ddlPaper.DataTextField = objLIBExam.PaperDispalyText;
            ddlPaper.DataValueField = objLIBExam.PaperValueField;
            ddlPaper.DataBind();
            ddlPaper.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        else
        {
            lblreqcourse.Text = "";

        }
        if (ddlPaper.Items.Count>0)
        {
        if (ddlPaper.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Paper'); </script>");
            lblreqpaper.Text = "Select Paper";
            return;
        }
        else
        {
            lblreqpaper.Text = "";

        }
        }
        if (ddlModule.Items.Count > 0)
        {
            if (ddlModule.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
                lblreqmodule.Text = "Select Module";
                return;
            }
            else
            {
                lblreqmodule.Text = "";
            }
        }
        if (ddlSem.Items.Count > 0)
        {
            if (ddlSem.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
                lblreqsem.Text = "Select Semester";
                return;
            }
            else
            {
                lblreqsem.Text = "";
            }

        }
        if (ddlBatch.Items.Count > 0)
        {
            if (ddlBatch.SelectedItem.Text == "-Select-")
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
                lblreqbatch.Text = "Select Batch";
                return;
            }
            else
            {
                lblreqbatch.Text = "";
            }

        }
        if (string.IsNullOrEmpty(txtfilecaption.Text))
        {
            lblpapercaption.Text = "Enter File Caption";
            return;
        }
        else
        {
            lblpapercaption.Text = "";
        }
        try
        {

            string text = txtfilecaption.Text +"_"+ddlCourse.SelectedValue+"_"+ddlSem.SelectedItem.Text+"_papid"+ddlPaper.SelectedValue;
            string uploadFolder = Request.PhysicalApplicationPath + "Admin\\PaperFiles\\";
            string path = "";
            string filepath = "";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.FileName.Length == 0)
                {
                    lblfileupload.Text = "Please upload File";
                    return;
                }
                if (FileUpload1.PostedFile.ContentLength > 41943041)
                {
                    lblfileupload.Text = "Please upload file less than and equel to 40 mb";
                    return;
                }
                //if (FileUpload1.PostedFile.ContentType != "octet-stream" || FileUpload1.PostedFile.ContentType != "video")
                //{
                //    lblfileupload.Text = "Please upload only videoes file";
                //    return;
                //}
                if (FileUpload1.PostedFile.FileName.Length > 0)
                {

                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(uploadFolder + text + extension);
                    path = uploadFolder + text + extension;
                    filepath = "Admin\\PaperFiles\\" + text + extension;
                    lblfileupload.Text = "";
                }

            }
            else
            {
                lblfileupload.Text = "Please upload File";
                return;
            }
            int addResult = 0;
           
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
         
            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
            objLIBExam.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
            objLIBExam.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
            objLIBExam.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
            objLIBExam.BatchId = Convert.ToInt32(ddlBatch.SelectedItem.Value);
            objLIBExam.FileCaption = txtfilecaption.Text;
            objLIBExam.UploadFilePath = filepath; 
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddPaperFile(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('File saved successfully');", true);
                //lblMessage.Text = "Exam Set Saved Successfully";
                string Notifications = "insert into Notifications(Subject,Body,SendFrom,CourseId)values('Video Lecture is uploaded','Video Lecture','Admin'," + ddlCourse.SelectedItem.Value + ")";
                CLS_C.fnExecuteQuery(Notifications);
                BindPaperFileList();
                ddlCourse.SelectedIndex = 0;
                ddlModule.SelectedIndex = 0;
                ddlPaper.SelectedIndex = 0;
                ddlSem.SelectedIndex = 0;
              
            }
            else if (addResult == -11)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
                lblMessage.Text = "Duplicate File Caption";

            }

            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
                lblMessage.Text = "Failed to Save";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void BindBatch()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetBatchByCourseId(tp);

            ddlBatch.DataSource = ds;
            ddlBatch.DataTextField = "batchcode";
            ddlBatch.DataValueField = "bid";
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, "--Select--");

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
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        BindSemesterDropDown(CourseId);
        BindBatch();
        LIBExam objLibExam = new LIBExam();

        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLibExam.CourseId = CourseId;

        tp.MessagePacket = (object)objLibExam;

        hdncoursecode.Value = objDalExam.GetCourseCodeByID(tp);

    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSem.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
            lblreqsem.Text = "Select Semester";
            return;
        }
        int semId = Convert.ToInt32(ddlSem.SelectedValue);
        BindModuleDropDown(semId);
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModule.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
            lblreqmodule.Text = "Select Module";
            return;
        }
        int ModuleId = Convert.ToInt32(ddlModule.SelectedValue);
        BindPaperDropDown(ModuleId);


    }

    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdExamSet.PageIndex = e.NewPageIndex;
        BindPaperFileList();
    }
    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
       
    }
    protected void grdExamSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;

        string hdnupaloadimagepath = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnupaloadimagepath")).Value;
        int id = Convert.ToInt32(((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value);
        try
        {
            int addResult = 0;
           // int id = Convert.ToInt32(e.CommandArgument);

            DALExam objDalExam = new DALExam();

            string str = "delete from paperfile where id=" + id;
            objDalExam.ExeNQcomsp(str);

           // string uploadFolder = Request.PhysicalApplicationPath + "Admin\\PaperFiles\\";
            string filename = hdnupaloadimagepath;
            System.IO.FileInfo file = new System.IO.FileInfo(filename);
            if (file.Exists)
            {
                File.Delete(filename);
            }

            lblMessage.Text = "Record deleted successfully";

            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            BindPaperFileList();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeletePaper");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this lecture ? '); ");



            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void grdExamSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int addResult = 0;
            // int id = Convert.ToInt32(e.CommandArgument);
            HiddenField hdnID = (HiddenField)grdExamSet.Rows[e.RowIndex].FindControl("hdnId");
            TextBox txtFileCaption = (TextBox)grdExamSet.Rows[e.RowIndex].FindControl("txtFileCaption");
           
            DALExam objDalExam = new DALExam();

            string str = "update paperfile set Filecaption='" + txtFileCaption.Text + "' where id=" + hdnID.Value;
            objDalExam.ExeNQcomsp(str);



            grdExamSet.EditIndex = -1;


            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('FileCaption Updated');", true);
            BindPaperFileList();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdExamSet.EditIndex = e.NewEditIndex;
        BindPaperFileList();
    }
    protected void grdExamSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdExamSet.EditIndex = -1;
        BindPaperFileList();
    }
}
