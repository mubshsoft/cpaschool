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

public partial class Admin_AddSampleSet : System.Web.UI.Page
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
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!Page.IsPostBack)
            {

                BindCorseDropDown();
                BindSampleSetList();
               

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindSampleSetList()
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.CourseId = courseid;
            objLIBSample.Year = year;
            tp.MessagePacket = (object)objLIBSample;

            tp = objDalSample.GetSampleSetList_(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            grdSampleSet.DataSource = objLibSampleListing;
            grdSampleSet.DataBind();

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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBSample;
            tp = objDalSample.GetSampleCourse(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibSampleListing;
            ddlCourse.DataTextField = objLIBSample.CourseDispalyText;
            ddlCourse.DataValueField = objLIBSample.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0,"-Select-");

            ddlcoursefillter.DataSource = objLibSampleListing;
            ddlcoursefillter.DataTextField = objLIBSample.CourseDispalyText;
            ddlcoursefillter.DataValueField = objLIBSample.CourseValueField;
            ddlcoursefillter.DataBind();
            ddlcoursefillter.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    //protected void BindSemesterDropDown(int CourseId)
    //{
    //    try
    //    {
    //        LIBSample objLIBSample = new LIBSample();
    //        DALSample objDalSample = new DALSample();
    //        LIBSampleListing objLibSampleListing = new LIBSampleListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBSample.CourseId = CourseId;
    //        tp.MessagePacket = (object)objLIBSample;
    //        tp = objDalSample.GetSemester(tp);
    //        objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
    //        ddlSem.DataSource = objLibSampleListing;
    //        ddlSem.DataTextField = objLIBSample.SemesterDispalyText;
    //        ddlSem.DataValueField = objLIBSample.SemesterValueField;
    //        ddlSem.DataBind();
    //        ddlSem.Items.Insert(0, "-Select-");



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}
    //protected void BindModuleDropDown(int SemId)
    //{
    //    try
    //    {
    //        LIBSample objLIBSample = new LIBSample();
    //        DALSample objDalSample = new DALSample();
    //        LIBSampleListing objLibSampleListing = new LIBSampleListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBSample.SemesterId = SemId;
    //        tp.MessagePacket = (object)objLIBSample;
    //        tp = objDalSample.GetModule(tp);
    //        objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
    //        ddlModule.DataSource = objLibSampleListing;
    //        ddlModule.DataTextField = objLIBSample.ModuleDispalyText;
    //        ddlModule.DataValueField = objLIBSample.ModuleValueField;
    //        ddlModule.DataBind();
    //        ddlModule.Items.Insert(0, "-Select-");



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}
    //protected void BindPaperDropDown(int ModuleId)
    //{
    //    try
    //    {
    //        LIBSample objLIBSample = new LIBSample();
    //        DALSample objDalSample = new DALSample();
    //        LIBSampleListing objLibSampleListing = new LIBSampleListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBSample.ModuleId = ModuleId;
    //        tp.MessagePacket = (object)objLIBSample;
    //        tp = objDalSample.GetPaper(tp);
    //        objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
    //        ddlPaper.DataSource = objLibSampleListing;
    //        ddlPaper.DataTextField = objLIBSample.PaperDispalyText;
    //        ddlPaper.DataValueField = objLIBSample.PaperValueField;
    //        ddlPaper.DataBind();
    //        ddlPaper.Items.Insert(0, "-Select-");



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}
    
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
        //if (ddlPaper.Items.Count>0)
        //{
        //if (ddlPaper.SelectedItem.Text == "-Select-")
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Paper');", true);
        //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Paper'); </script>");
        //    //lblreqpaper.Text = "Select Paper";
        //    return;
        //}
        //else
        //{
        //    lblreqpaper.Text = "";

        //}
        //}
        //if (ddlModule.Items.Count > 0)
        //{
        //    if (ddlModule.SelectedItem.Text == "-Select-")
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Module');", true);
        //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Module'); </script>");
        //        //lblreqmodule.Text = "Select Module";
        //        return;
        //    }
        //    else
        //    {
        //        lblreqmodule.Text = "";
        //    }
        //}
        //if (ddlSem.Items.Count > 0)
        //{
        //    if (ddlSem.SelectedItem.Text == "-Select-")
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Semester');", true);
        //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
        //        //lblreqsem.Text = "Select Semester";
        //        return;
        //    }
        //    else
        //    {
        //        lblreqsem.Text = "";
        //    }

        //}
        try
        {
            int allowtedtime = 0;
            if (string.IsNullOrEmpty(txtTimeAllowted.Text) )
            {
             
                lblTimeReq.Text = "Enter Time Period for the Sample Set";
                return;
            }
            else
            {
               
                lblTimeReq.Text = "";
            }
            
           
            if (string.IsNullOrEmpty(txtSamplecode.Text))
            {
                lblreqSamplecode.Text = "Enter Sample Code";
                return;
            }
            else
            {
                lblreqSamplecode.Text = "";
            }
            string text = txtSamplecode.Text;
            string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadSampleExam\\";
            string path = "";
            if (FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(uploadFolder + text + extension);
                path = uploadFolder + text + extension;
                lblfileupload.Text = "";
                
            }
            //else if(ddlSampleType.SelectedItem.Text.ToLower()=="manual")
            //{
            //    lblfileupload.Text = "Please upload Sample";
            //    return;
            //}
            //if (ddlSampleType.SelectedItem.Text.ToLower() == "online")
            //{
                allowtedtime = Convert.ToInt32(txtTimeAllowted.Text);
            //}

            int addResult = 0;
           
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.Samplecode = txtSamplecode.Text;
            objLIBSample.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
           // objLIBSample.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
            //objLIBSample.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
            //objLIBSample.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
            objLIBSample.TimeAllowted = Convert.ToInt32(allowtedtime) * 60;
            objLIBSample.SampleType = "online";
            objLIBSample.SamplePath = path;
            tp.MessagePacket = (object)objLIBSample;
            addResult = objDalSample.AddSampleSet(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //lblMessage.Text = "Sample Set Saved Successfully";
                txtSamplecode.Text = "";
                BindSampleSetList();
                ddlCourse.SelectedIndex = 0;
                //ddlModule.SelectedIndex = 0;
                //ddlPaper.SelectedIndex = 0;
                //ddlSem.SelectedIndex = 0;
                txtTimeAllowted.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Sample Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Sample Set'); </script>");
                //lblMessage.Text = "Duplicate Sample Set";

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Save Sample Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Sample Set'); </script>");
               // lblMessage.Text = "Failed to Save Sample Set";

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
      /////  BindSemesterDropDown(CourseId);
        LIBSample objLibSample = new LIBSample();

        DALSample objDalSample = new DALSample();
        TransportationPacket tp = new TransportationPacket();
        objLibSample.CourseId = CourseId;

        tp.MessagePacket = (object)objLibSample;

        hdncoursecode.Value = objDalSample.GetCourseCodeByID(tp);

    }
    //protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSem.SelectedItem.Text == "-Select-")
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Semester');", true);
    //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
    //        //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Semester'); </script>");
    //       // lblreqsem.Text = "Select Semester";
    //        return;
    //    }
    //    int semId = Convert.ToInt32(ddlSem.SelectedValue);
    //    BindModuleDropDown(semId);
    //}
    //protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlModule.SelectedItem.Text == "-Select-")
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Module');", true);
    //        //lblreqmodule.Text = "Select Module";
    //        return;
    //    }
    //    int ModuleId = Convert.ToInt32(ddlModule.SelectedValue);
    //    BindPaperDropDown(ModuleId);


    //}
    protected void grdSampleSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
                //LinkButton lnkEditExam = (LinkButton)e.Row.FindControl("lnkEditDetailsExam");
                //LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopySample");
                //HiddenField hdnSamId = (HiddenField)e.Row.FindControl("hdnSamId");
                //Label Samplecode = (Label)e.Row.FindControl("lblSamplecodeNo");
                //valu.PostBackUrl = "~/Admin/AddSelectSection.aspx?SampleID=" + hdnSamId.Value;
                //lnkEditExam.PostBackUrl = "~/Admin/SelectSection.aspx?SamId=" + hdnSamId.Value;
                //copyques.PostBackUrl = "~/Admin/CopyQuestion.aspx?SamId=" + hdnSamId.Value + "&examcode=" + examcode.Text;

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsSample");
                LinkButton lnkEditSample = (LinkButton)e.Row.FindControl("lnkEditDetailsSample");
                LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopySample");
                HiddenField hdnSamId = (HiddenField)e.Row.FindControl("hdnSamId");
                HiddenField hdnSampleType = (HiddenField)e.Row.FindControl("hdnSampleType");
                Label Samplecode = (Label)e.Row.FindControl("lblSamplecodeNo");
                valu.PostBackUrl = "~/Admin/SampleAddSelectSection.aspx?SamId=" + hdnSamId.Value;
                lnkEditSample.PostBackUrl = "~/Admin/SampleSelectSection.aspx?SamId=" + hdnSamId.Value;
                if (hdnSampleType.Value.ToLower() == "manual" || hdnSampleType.Value.ToLower() == "offline")
                {
                    valu.Enabled = false;
                    lnkEditSample.Enabled = false;
                }

                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteSampleSet");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Sample Set ? '); ");
               // copyques.PostBackUrl = "~/Admin/SampleCopyQuestion.aspx?SamId=" + hdnSamId.Value +"&Samplecode="+Samplecode.Text;
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdSampleSet.PageIndex = e.NewPageIndex;
            BindSampleSetList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void chkuseSample_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grdSampleSet.Rows)
        {
            LinkButton valu = (LinkButton)gv.FindControl("lnkDetailsSample");
            LinkButton copyques = (LinkButton)gv.FindControl("lnkCopySample");
            HiddenField hdnSamId = (HiddenField)gv.FindControl("hdnSamId");

            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLibSample.SamId = Convert.ToInt32(hdnSamId.Value);

            tp.MessagePacket = (object)objLibSample;
              int maxque = OBJDALSample.GetMaxQuesNo(tp);
            if (chkuseSample.Checked == true)
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
    protected void grdSampleSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "Delete")
        {
            id = Convert.ToInt32(e.CommandArgument);
            //string strChk = "select es.SamId from SampleSet es INNER JOIN Sample_CATEGORY ec on es.SamId=ec.SamId where es.SamId=" + id;
            //DALSample objDalSample = new DALSample();
            //DataSet ds = new DataSet();
            //DataTable dtt = new DataTable();
            //dtt = objDalSample.getdata(strChk);
            //if (dtt.Rows.Count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample has some section - can't be deleted');", true);
            //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample has some section - can't be deleted'); </script>");
            //    //lblMessage.Text = "Sample has some section - can't be deleted";
            
            //}
            //else
            //{
                
                LIBSample objLibSample1 = new LIBSample();
                DALSample OBJDALSample1 = new DALSample();
                TransportationPacket tp1 = new TransportationPacket();
                objLibSample1.SamId = id;

                tp1.MessagePacket = (object)objLibSample1;
               // string str = "delete from SampleSet where SamId=" + id;
                //objDalSample.ExeNQcomsp(str);
                int result=OBJDALSample1.DeleteSample(tp1);
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record deleted successfully');", true);
                    BindSampleSetList();
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Record deleted successfully'); </script>");
                    //lblMessage.Text = "Record deleted successfully";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                    
                }
                //else if (result==-11)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample has some Answers - can't be deleted');", true);
                //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample has some Answers - can't be deleted'); </script>");
                //    //lblMessage.Text = "Sample has some Answers - can't be deleted";
                //    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                //}
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to delete');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to delete'); </script>");
                    //lblMessage.Text = "Sample has some Answers - can't be deleted";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                }
            //}
         
        }
    }
    protected void grdSampleSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdSampleSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdSampleSet.EditIndex = e.NewEditIndex;
        BindSampleSetList();
    }
    protected void grdSampleSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdSampleSet.EditIndex = -1;
        BindSampleSetList();

    }
    protected void grdSampleSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnSamId = ((HiddenField)grdSampleSet.Rows[e.RowIndex].FindControl("hdnSamId")).Value;
            TextBox txtTimeAllowted = (TextBox)grdSampleSet.Rows[e.RowIndex].FindControl("txtTimeAllowted");


            int addResult = 0;
            LIBSample objLibSample = new LIBSample();
            DALSample OBJDALSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLibSample.SamId = Convert.ToInt32(hdnSamId);
            objLibSample.TimeAllowted = Convert.ToInt32(txtTimeAllowted.Text);

            tp.MessagePacket = (object)objLibSample;
            addResult = OBJDALSample.UpdateSampleSet(tp);

            if (addResult > 0)
            {
                grdSampleSet.EditIndex = -1;


                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sampleset Updated');", true);
                BindSampleSetList();
            }
            else if (addResult == -11)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Sampleset');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Sampleset');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    //protected void ddlSampleType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlSampleType.SelectedItem.Text.ToLower() == "online")
    //    {
    //        tronline.Visible = true;
    //        trmanual.Visible = false;
    //    }
    //    else if (ddlSampleType.SelectedItem.Text.ToLower() == "manual")
    //    {
    //        tronline.Visible = false;
    //        trmanual.Visible = true;
    //    }
    //    else
    //    {
           
    //            tronline.Visible = false;
    //            trmanual.Visible = false;
           
    //    }
    //}
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }
    protected void ddlcoursefillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSampleSetList();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSampleSetList();
    }
  
}
