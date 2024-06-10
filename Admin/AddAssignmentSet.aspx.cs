using System;
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

public partial class Admin_AddAssignmentSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
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
                BindAssignmentSetList();
              DataSet dsyear=  CLS_C.fnQuerySelectDs("SP_GetYearList");
              ddlyear.DataSource = dsyear;
              ddlyear.DataTextField = "year";
              ddlyear.DataValueField = "year";
              ddlyear.DataBind();
              ddlyear.Items.Insert(0, "-Select-");


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindAssignmentSetList()
    {
        try
        {
            int courseid = 0;
            int year = 0;
            if (ddlcoursefillter.SelectedItem.Text != "-Select-")
            {
                courseid = Convert.ToInt32(ddlcoursefillter.SelectedValue);
            }
            if (ddlyear.SelectedItem.Text != "--Select--")
            {
                year = Convert.ToInt32(ddlyear.SelectedValue);
            }
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CourseId = courseid;
            objLIBAssignment.Year = year;
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetAssignmentSetList_(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            grdAssignmentSet.DataSource = objLibAssignmentListing;
            grdAssignmentSet.DataBind();

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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetCourse(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibAssignmentListing;
            ddlCourse.DataTextField = objLIBAssignment.CourseDispalyText;
            ddlCourse.DataValueField = objLIBAssignment.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0,"-Select-");


            ddlcoursefillter.DataSource = objLibAssignmentListing;
            ddlcoursefillter.DataTextField = objLIBAssignment.CourseDispalyText;
            ddlcoursefillter.DataValueField = objLIBAssignment.CourseValueField;
            ddlcoursefillter.DataBind();
            ddlcoursefillter.Items.Insert(0, "-Select-");


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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CourseId = CourseId;
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetSemester(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlSem.DataSource = objLibAssignmentListing;
            ddlSem.DataTextField = objLIBAssignment.SemesterDispalyText;
            ddlSem.DataValueField = objLIBAssignment.SemesterValueField;
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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.SemesterId = SemId;
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetModule(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlModule.DataSource = objLibAssignmentListing;
            ddlModule.DataTextField = objLIBAssignment.ModuleDispalyText;
            ddlModule.DataValueField = objLIBAssignment.ModuleValueField;
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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.ModuleId = ModuleId;
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetPaper(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlPaper.DataSource = objLibAssignmentListing;
            ddlPaper.DataTextField = objLIBAssignment.PaperDispalyText;
            ddlPaper.DataValueField = objLIBAssignment.PaperValueField;
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
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Course');", true);
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            //lblreqcourse.Text = "Select Course";
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
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Paper');", true);
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Paper'); </script>");
            //lblreqpaper.Text = "Select Paper";
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Module');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
                //lblreqmodule.Text = "Select Module";
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Semester');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
                //lblreqsem.Text = "Select Semester";
                return;
            }
            else
            {
                lblreqsem.Text = "";
            }

        }
        try
        {
            int allowtedtime = 0;
            if (string.IsNullOrEmpty(txtTimeAllowted.Text) && ddlAssignmentType.SelectedItem.Text.ToLower()=="online")
            {
             
                lblTimeReq.Text = "Enter Time Period for the Assignment Set";
                return;
            }
            else
            {
               
                lblTimeReq.Text = "";
            }
            
           
            if (string.IsNullOrEmpty(txtAssignmentcode.Text))
            {
                lblreqAssignmentcode.Text = "Enter Assignment Code";
                return;
            }
            else
            {
                lblreqAssignmentcode.Text = "";
            }
            string text = txtAssignmentcode.Text;
            string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadAssignment\\";
            string path = "";
            if (FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(uploadFolder + text + extension);
                path = uploadFolder + text + extension;
                lblfileupload.Text = "";
                
            }
            else if(ddlAssignmentType.SelectedItem.Text.ToLower()=="manual")
            {
                lblfileupload.Text = "Please upload Assignment";
                return;
            }
            else if (ddlAssignmentType.SelectedItem.Text.ToLower() == "offline")
            {
                lblfileupload.Text = "Please upload Assignment";
                return;
            }
            if (ddlAssignmentType.SelectedItem.Text.ToLower() == "online")
            {
                allowtedtime = Convert.ToInt32(txtTimeAllowted.Text);
            }

            int addResult = 0;
           
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.Assignmentcode = txtAssignmentcode.Text;
            objLIBAssignment.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
            objLIBAssignment.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
            objLIBAssignment.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
            objLIBAssignment.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
            objLIBAssignment.TimeAllowted = allowtedtime * 60 ;
            objLIBAssignment.AssignmentType = (ddlAssignmentType.SelectedItem.Text);
            objLIBAssignment.AssignmentPath = path;
            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.AddAssignmentSet(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //lblMessage.Text = "Assignment Set Saved Successfully";
                txtAssignmentcode.Text = "";
                BindAssignmentSetList();
                ddlCourse.SelectedIndex = 0;
                ddlModule.SelectedIndex = 0;
                ddlPaper.SelectedIndex = 0;
                ddlSem.SelectedIndex = 0;
                txtTimeAllowted.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Assignment Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Assignment Set'); </script>");
                //lblMessage.Text = "Duplicate Assignment Set";

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Save Assignment Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Assignment Set'); </script>");
               // lblMessage.Text = "Failed to Save Assignment Set";

            }
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
           // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            //lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        BindSemesterDropDown(CourseId);
        LIBAssignment objLibAssignment = new LIBAssignment();

        DALAssignment objDalAssignment = new DALAssignment();
        TransportationPacket tp = new TransportationPacket();
        objLibAssignment.CourseId = CourseId;

        tp.MessagePacket = (object)objLibAssignment;

        hdncoursecode.Value = objDalAssignment.GetCourseCodeByID(tp);

    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSem.SelectedItem.Text == "-Select-")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Semester');", true);
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
           // lblreqsem.Text = "Select Semester";
            return;
        }
        int semId = Convert.ToInt32(ddlSem.SelectedValue);
        BindModuleDropDown(semId);
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModule.SelectedItem.Text == "-Select-")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Module');", true);
            //lblreqmodule.Text = "Select Module";
            return;
        }
        int ModuleId = Convert.ToInt32(ddlModule.SelectedValue);
        BindPaperDropDown(ModuleId);


    }
    protected void grdAssignmentSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              

                LinkButton lnkbtnAsgnCode = (LinkButton)e.Row.FindControl("lnkbtnAsgnCode");
                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsAssignment");
                LinkButton lnkEditAssignment = (LinkButton)e.Row.FindControl("lnkEditDetailsAssignment");
                LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopyAssignment");
                HiddenField hdnAsgnId = (HiddenField)e.Row.FindControl("hdnAsgnID");
                HiddenField hdnAssignmentType = (HiddenField)e.Row.FindControl("hdnAssignmentType");
                Label Assignmentcode = (Label)e.Row.FindControl("lblAssignmentcodeNo");
                valu.PostBackUrl = "~/Admin/AssignmentAddSelectSection.aspx?AsgnID=" + hdnAsgnId.Value;
                lnkEditAssignment.PostBackUrl = "~/Admin/AssignmentSelectSection.aspx?AsgnId=" + hdnAsgnId.Value;
                if (hdnAssignmentType.Value.ToLower() == "manual" || hdnAssignmentType.Value.ToLower() == "offline")
                {
                    
                    valu.Enabled = false;
                    lnkEditAssignment.Enabled = false;
                }
                if (hdnAssignmentType.Value.ToLower() == "online")
                {
                    lnkbtnAsgnCode.PostBackUrl = "~/Admin/ShowAssignment.aspx?AsgnId=" + hdnAsgnId.Value;
                }

                //if (hdnAssignmentType.Value.ToLower() == "offline" )
                //{
                //    lnkbtnAsgnCode.Enabled = false;
                //}
                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteAssignmentSet");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Assignment Set ? '); ");

               // copyques.PostBackUrl = "~/Admin/AssignmentCopyQuestion.aspx?AsgnId=" + hdnAsgnId.Value +"&Assignmentcode="+Assignmentcode.Text;
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void chkuseAssignment_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grdAssignmentSet.Rows)
        {
            LinkButton valu = (LinkButton)gv.FindControl("lnkDetailsAssignment");
            LinkButton copyques = (LinkButton)gv.FindControl("lnkCopyAssignment");
            HiddenField hdnAsgnId = (HiddenField)gv.FindControl("hdnAsgnId");

            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLibAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);

            tp.MessagePacket = (object)objLibAssignment;
              int maxque = OBJDALAssignment.GetMaxQuesNo(tp);
            if (chkuseAssignment.Checked == true)
            {
                valu.Visible = false;
                copyques.Visible = true;
                if (maxque == -1)
                {
                    copyques.Enabled = false;
                }
            }
            else
            {
                valu.Visible = true;
                copyques.Visible = false;
            }
        }
    }
    protected void grdAssignmentSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        string path = "";
        if (e.CommandName == "Delete")
        {
            id = Convert.ToInt32(e.CommandArgument);
            //string strChk = "select es.AsgnId,es.AssignmentPath from AssignmentSet es INNER JOIN Assignment_CATEGORY ec on es.AsgnId=ec.AsgnId where es.AsgnId=" + id;
            //DALAssignment objDalAssignment = new DALAssignment();
            //DataSet ds = new DataSet();
            //DataTable dtt = new DataTable();
            //dtt = objDalAssignment.getdata(strChk);

            //if (dtt.Rows.Count > 0)
            //{

            //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment has some section - cant be deleted');", true);
            //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment has some section - can't be deleted'); </script>");
            //    //lblMessage.Text = "Assignment has some section - can't be deleted";
            //}
            //else
            //{
                //string strChk1 = "select AssignmentPath from AssignmentSet  where AsgnId=" + id;

                //DataTable dtdelete = new DataTable();
                //dtdelete = objDalAssignment.getdata(strChk1);

                LIBAssignment objLibAssignment1 = new LIBAssignment();
                DALAssignment OBJDALAssignment1 = new DALAssignment();
                TransportationPacket tp1 = new TransportationPacket();
                objLibAssignment1.AsgnId = id;

                tp1.MessagePacket = (object)objLibAssignment1;
                //string str = "update AssignmentSet set Active=0 where AsgnId=" + id;
                //objDalAssignment.ExeNQcomsp(str);
                int result=OBJDALAssignment1.DeleteAssignment(tp1);
                //code by Manoj to delete uploaded file
               
                //if (dtdelete.Rows.Count > 0)
                //{

                //    string Filetodelete = dtdelete.Rows[0][0].ToString();
                //    //Filetodelete = Request.PhysicalApplicationPath + "Admin\\UploadAssignment\\";
                //    System.IO.FileInfo file = new System.IO.FileInfo(Filetodelete);
                //    if (file.Exists)
                //    {
                //        File.Delete(Filetodelete);
                //    }
                //}
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record deleted successfully');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Record deleted successfully'); </script>");
                    //lblMessage.Text = "Record deleted successfully";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                    
                }
                else if (result==-11)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignment has some Answers - can't be deleted');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment has some Answers - can't be deleted'); </script>");
                    //lblMessage.Text = "Assignment has some Answers - can't be deleted";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to delete');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to delete'); </script>");
                    //lblMessage.Text = "Assignment has some Answers - can't be deleted";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                }
               
            //}
            BindAssignmentSetList();
        } 
        if (e.CommandName == "manual")
                {
                    string file = e.CommandArgument.ToString();
                    Session["file"] = file;
                    Response.Redirect("download.aspx");
                   
                }
    }
    protected void grdAssignmentSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grdAssignmentSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdAssignmentSet.EditIndex = e.NewEditIndex;
        BindAssignmentSetList();
    }
    protected void grdAssignmentSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdAssignmentSet.EditIndex = -1;
        BindAssignmentSetList();

    }
    protected void grdAssignmentSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnAsgnId = ((HiddenField)grdAssignmentSet.Rows[e.RowIndex].FindControl("hdnAsgnId")).Value;
            HiddenField hdnAssignmentType = (HiddenField)grdAssignmentSet.Rows[e.RowIndex].FindControl("hdnAssignmentType");
            TextBox txtTimeAllowted = (TextBox)grdAssignmentSet.Rows[e.RowIndex].FindControl("txtTimeAllowted");

            if (hdnAssignmentType.Value.ToLower() == "manual" || hdnAssignmentType.Value.ToLower() == "offline")
            {
                grdAssignmentSet.EditIndex = -1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Not allowed to Updated time for offline and Manual assignment');", true);
                BindAssignmentSetList();
                return;
               

            }

                int addResult = 0;
            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLibAssignment.AsgnId = Convert.ToInt32(hdnAsgnId);
            objLibAssignment.TimeAllowted = Convert.ToInt32(txtTimeAllowted.Text);

            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.UpdateAssignmentSet(tp);

            if (addResult > 0)
            {
                grdAssignmentSet.EditIndex = -1;


                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Assignmentset Updated');", true);
                BindAssignmentSetList();
            }
            else if (addResult == -11)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Assignmentset');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Assignmentset');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
   

    protected void ddlAssignmentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAssignmentType.SelectedItem.Text.ToLower() == "online")
        {
            tronline.Visible = true;
            trmanual.Visible = false;
        }
        else if (ddlAssignmentType.SelectedItem.Text.ToLower() == "manual")
        {
            tronline.Visible = false;
            trmanual.Visible = true;
        }
        else
        {
                tronline.Visible = false;
                //trmanual.Visible = false;          // comment made by wahid hence in case of offline assignment task need to be upload
                trmanual.Visible = true;
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }
    protected void ddlcoursefillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAssignmentSetList();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAssignmentSetList();
    }
}
