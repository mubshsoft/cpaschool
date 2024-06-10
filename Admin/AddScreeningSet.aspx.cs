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

public partial class Admin_AddScreeningSet : System.Web.UI.Page
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
                BindScreeningSetList();
                DataSet dsyear = CLS_C.fnQuerySelectDs("SP_GetYearList");
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
    protected void BindScreeningSetList()
    {
        try
        {
            int year = 0;

            if (ddlyear.SelectedItem.Text != "--Select Year--")
            {
                year = Convert.ToInt32(ddlyear.SelectedValue);
            }
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.Year = year;
            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetScreeningSetList_(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            grdScreeningSet.DataSource = objLibScreeningListing;
            grdScreeningSet.DataBind();

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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBScreening;
            tp = objDalScreening.GetScreeningCourse(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibScreeningListing;
            ddlCourse.DataTextField = objLIBScreening.CourseDispalyText;
            ddlCourse.DataValueField = objLIBScreening.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0,"-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdScreeningSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdScreeningSet.EditIndex = e.NewEditIndex;
        BindScreeningSetList();
    }
    protected void grdScreeningSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdScreeningSet.EditIndex = -1;
        BindScreeningSetList();

    }
    protected void grdScreeningSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string hdnScrId = ((HiddenField)grdScreeningSet.Rows[e.RowIndex].FindControl("hdnScrId")).Value;
            TextBox txtTimeAllowted = (TextBox)grdScreeningSet.Rows[e.RowIndex].FindControl("txtTimeAllowted");


            int addResult = 0;
            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLibScreening.ScrId = Convert.ToInt32(hdnScrId);
            objLibScreening.TimeAllowted = Convert.ToInt32(txtTimeAllowted.Text);

            tp.MessagePacket = (object)objLibScreening;
            addResult = OBJDALScreening.UpdateScreeningSet(tp);

            if (addResult > 0)
            {
                grdScreeningSet.EditIndex = -1;


                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screeningset Updated');", true);
                BindScreeningSetList();
            }
            else if (addResult == -11)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Screeningset');", true);
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Update Screeningset');", true);
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
            grdScreeningSet.PageIndex = e.NewPageIndex;
            BindScreeningSetList();

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
            if (string.IsNullOrEmpty(txtTimeAllowted.Text))
            {
             
                lblTimeReq.Text = "Enter Time Period for the Screening Set";
                return;
            }
            else
            {
               
                lblTimeReq.Text = "";
            }
            
           
            if (string.IsNullOrEmpty(txtScreeningcode.Text))
            {
                lblreqScreeningcode.Text = "Enter Screening Code";
                return;
            }
            else
            {
                lblreqScreeningcode.Text = "";
            }
            string text = txtScreeningcode.Text;
            string uploadFolder = Request.PhysicalApplicationPath + "Admin\\UploadScreeningExam\\";
            string path = "";
            if (FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(uploadFolder + text + extension);
                path = uploadFolder + text + extension;
                lblfileupload.Text = "";
                
            }
            //else if(ddlScreeningType.SelectedItem.Text.ToLower()=="manual")
            //{
            //    lblfileupload.Text = "Please upload Screening";
            //    return;
            //}
            //if (ddlScreeningType.SelectedItem.Text.ToLower() == "online")
            //{
               
            //}
             allowtedtime = Convert.ToInt32(txtTimeAllowted.Text);
            int addResult = 0;
           
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.Screeningcode = txtScreeningcode.Text;
            objLIBScreening.CourseId = Convert.ToInt32(ddlCourse.SelectedItem.Value);
           // objLIBScreening.SemesterId = Convert.ToInt32(ddlSem.SelectedItem.Value);
            //objLIBScreening.ModuleId = Convert.ToInt32(ddlModule.SelectedItem.Value);
            //objLIBScreening.paperId = Convert.ToInt32(ddlPaper.SelectedItem.Value);
            objLIBScreening.TimeAllowted = Convert.ToInt32(allowtedtime) * 60;
            objLIBScreening.ScreeningType = "online";
            objLIBScreening.ScreeningPath = path;
            tp.MessagePacket = (object)objLIBScreening;
            addResult = objDalScreening.AddScreeningSet(tp);

            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //lblMessage.Text = "Screening Set Saved Successfully";
                txtScreeningcode.Text = "";
                BindScreeningSetList();
                ddlCourse.SelectedIndex = 0;
                //ddlModule.SelectedIndex = 0;
                //ddlPaper.SelectedIndex = 0;
                //ddlSem.SelectedIndex = 0;
                txtTimeAllowted.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Screening Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Duplicate Screening Set'); </script>");
                //lblMessage.Text = "Duplicate Screening Set";

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Save Screening Set');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Screening Set'); </script>");
               // lblMessage.Text = "Failed to Save Screening Set";

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
        LIBScreening objLibScreening = new LIBScreening();

        DALScreening objDalScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLibScreening.CourseId = CourseId;

        tp.MessagePacket = (object)objLibScreening;

        hdncoursecode.Value = objDalScreening.GetCourseCodeByID(tp);

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
    protected void grdScreeningSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
                //LinkButton lnkEditExam = (LinkButton)e.Row.FindControl("lnkEditDetailsExam");
                //LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopyScreening");
                //HiddenField hdnScrId = (HiddenField)e.Row.FindControl("hdnScrId");
                //Label Screeningcode = (Label)e.Row.FindControl("lblScreeningcodeNo");
                //valu.PostBackUrl = "~/Admin/AddSelectSection.aspx?ScreeningID=" + hdnScrId.Value;
                //lnkEditExam.PostBackUrl = "~/Admin/SelectSection.aspx?ScrId=" + hdnScrId.Value;
                //copyques.PostBackUrl = "~/Admin/CopyQuestion.aspx?ScrId=" + hdnScrId.Value + "&examcode=" + examcode.Text;

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsScreening");
                LinkButton lnkEditScreening = (LinkButton)e.Row.FindControl("lnkEditDetailsScreening");
                LinkButton copyques = (LinkButton)e.Row.FindControl("lnkCopyScreening");
                HiddenField hdnScrId = (HiddenField)e.Row.FindControl("hdnScrID");
                HiddenField hdnScreeningType = (HiddenField)e.Row.FindControl("hdnScreeningType");
                Label Screeningcode = (Label)e.Row.FindControl("lblScreeningcodeNo");
                valu.PostBackUrl = "~/Admin/ScreeningAddSelectSection.aspx?ScrID=" + hdnScrId.Value;
                lnkEditScreening.PostBackUrl = "~/Admin/ScreeningSelectSection.aspx?ScrId=" + hdnScrId.Value;
                if (hdnScreeningType.Value.ToLower() == "manual" || hdnScreeningType.Value.ToLower() == "offline")
                {
                    valu.Enabled = false;
                    lnkEditScreening.Enabled = false;
                }

                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteScreeningSet");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Screening Set ? '); ");
               // copyques.PostBackUrl = "~/Admin/ScreeningCopyQuestion.aspx?ScrId=" + hdnScrId.Value +"&Screeningcode="+Screeningcode.Text;
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void chkuseScreening_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grdScreeningSet.Rows)
        {
            LinkButton valu = (LinkButton)gv.FindControl("lnkDetailsScreening");
            LinkButton copyques = (LinkButton)gv.FindControl("lnkCopyScreening");
            HiddenField hdnScrId = (HiddenField)gv.FindControl("hdnScrId");

            LIBScreening objLibScreening = new LIBScreening();
            DALScreening OBJDALScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);

            tp.MessagePacket = (object)objLibScreening;
              int maxque = OBJDALScreening.GetMaxQuesNo(tp);
            if (chkuseScreening.Checked == true)
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
    protected void grdScreeningSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "Delete")
        {
            id = Convert.ToInt32(e.CommandArgument);
            //string strChk = "select es.ScrId from ScreeningSet es INNER JOIN Screening_CATEGORY ec on es.ScrId=ec.ScrId where es.ScrId=" + id;
            //DALScreening objDalScreening = new DALScreening();
            //DataSet ds = new DataSet();
            //DataTable dtt = new DataTable();
            //dtt = objDalScreening.getdata(strChk);
            //if (dtt.Rows.Count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening has some section - can't be deleted');", true);
            //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening has some section - can't be deleted'); </script>");
            //    //lblMessage.Text = "Screening has some section - can't be deleted";
            
            //}
            //else
            //{
                
                LIBScreening objLibScreening1 = new LIBScreening();
                DALScreening OBJDALScreening1 = new DALScreening();
                TransportationPacket tp1 = new TransportationPacket();
                objLibScreening1.ScrId = id;

                tp1.MessagePacket = (object)objLibScreening1;
                //string str = "delete from ScreeningSet where ScrId=" + id;
                //objDalScreening.ExeNQcomsp(str);
                int result=OBJDALScreening1.DeleteScreening(tp1);
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record deleted successfully');", true);
                    BindScreeningSetList();
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Record deleted successfully'); </script>");
                    //lblMessage.Text = "Record deleted successfully";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                    
                }
                //else if (result==-11)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening has some Answers - can't be deleted');", true);
                //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening has some Answers - can't be deleted'); </script>");
                //    //lblMessage.Text = "Screening has some Answers - can't be deleted";
                //    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                //}
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to delete');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to delete'); </script>");
                    //lblMessage.Text = "Screening has some Answers - can't be deleted";
                    //lblMessage.ForeColor = System.Drawing.Color.DarkGreen;

                }
            //}
         
        }
    }
    protected void grdScreeningSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
       BindScreeningSetList();
    }

    
}
