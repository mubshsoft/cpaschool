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
using fmsf.lib;
using fmsf.DAL;
public partial class AdminListAssignmentSet : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {

                hdnbatchid.Value = Request.QueryString["batchid"].ToString();

                BindAssignmentDropDown();
                //if (ddlListExamSet.SelectedItem.Text != "-Select-")
                //{
                //    GetAssignmentActivateDateByAsgnId();
                //}
              
                  

              


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }





    protected void BindAssignmentDropDown()
    {
        //if (ddlListExamSet.SelectedItem.Text == "-Select-")
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Assignment'); </script>");
        //    return;
        //}
        try
        {
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.BatchId = Convert.ToInt32(hdnbatchid.Value);
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetSubmitedAssignmentByBatchId(tp);
            
            
            ddlListExamSet.DataSource = ds;
            ddlListExamSet.DataTextField = "AsgnCode";
            ddlListExamSet.DataValueField = "Asgnid";
            ddlListExamSet.DataBind();
            ddlListExamSet.Items.Insert(0, "-Select-");

           

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    //protected void GetAssignmentActivateDateByAsgnId()
    //{
    //    if (ddlListExamSet.SelectedItem.Text == "-Select-")
    //    {
    //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Assignment'); </script>");
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Assignment');", true);
    //        return;
    //    }
    //    //if (ddlActivationDate.SelectedItem.Text == "-Select-")
    //    //{
    //    //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Date'); </script>");
    //    //    return;
    //    //}
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        LIBAssignment objLIBAssignment = new LIBAssignment();
    //        DALAssignment objDalAssignment = new DALAssignment();
    //        LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBAssignment.BatchId = Convert.ToInt32(hdnbatchid.Value);
    //        objLIBAssignment.AsgnId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
    //        tp.MessagePacket = (object)objLIBAssignment;
    //        ds = objDalAssignment.GetAssignmentActivateDateByAsgnId(tp);
           
    //        ddlActivationDate.DataSource = ds;
    //        ddlActivationDate.DataTextField = "ActivateDate";
    //        ddlActivationDate.DataValueField = "DeactivateDate";
    //        ddlActivationDate.DataBind();
    //        ddlActivationDate.Items.Insert(0, "-Select-");



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}


    protected void GetUserList()
    {
        if (ddlListExamSet.SelectedItem.Text == "-Select-")
        {
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Assignment'); </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Assignment');", true);
            return;
        }
        //if (ddlActivationDate.SelectedItem.Text == "-Select-")
        //{
        //    //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Date'); </script>");
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Date');", true);
            
        //    return;
        //}
        try
        {
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.BatchId = Convert.ToInt32(hdnbatchid.Value);
            objLIBAssignment.AsgnId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
            //objLIBAssignment.activateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Text);
            //objLIBAssignment.DeactivateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Value);
            tp.MessagePacket = (object)objLIBAssignment;
            string type=objDalAssignment.GetAssignmentTypeByAsgnId(tp);
            objLIBAssignment.AssignmentType = type;
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetUserListBySubmiitedAssignment(tp);
            //objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblMessage.Text = "Pending Assignment from student.";
                btnAssign.Enabled = false;
            }
            GrdUserList.DataSource = ds;
            GrdUserList.DataBind();

            bindDescriptive();
           



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void bindDescriptive()
    {
        if (GrdUserList.Rows.Count > 0)
        {
            for (int i = 0; i < GrdUserList.Rows.Count; i++)
            {
                try
                {


                    LinkButton lnkbtnDesc = (LinkButton)GrdUserList.Rows[i].FindControl("lnkbtnDesc");
                    HiddenField hdnUserID = (HiddenField)GrdUserList.Rows[i].FindControl("hdnUserID");
                   
                    DataSet ds = new DataSet();
                    LIBAssignment objLIBAssignment = new LIBAssignment();
                    DALAssignment objDalAssignment = new DALAssignment();
                    LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBAssignment.BatchId = Convert.ToInt32(hdnbatchid.Value);
                    objLIBAssignment.AsgnId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
                    //objLIBAssignment.activateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Text);
                    //objLIBAssignment.DeactivateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Value);
                    tp.MessagePacket = (object)objLIBAssignment;
                    //string type = objDalAssignment.GetAssignmentTypeByAsgnId(tp);
                    //objLIBAssignment.AssignmentType = type;
                    //tp.MessagePacket = (object)objLIBAssignment;
                    ds = objDalAssignment.GetUserListBySubmiitedAssignment_HaveDescriptive(tp);
                    if (ds != null)
                    {
                        if (ds.Tables != null)
                        {
                            if (ds.Tables[0].Rows != null)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {

                                    if (ds.Tables[0].Rows[j]["UserId"].ToString() == hdnUserID.Value && ds.Tables[0].Rows[j]["descriptive"].ToString() == "1")
                                    {
                                        lnkbtnDesc.Visible = true;
                                    }
                                    

                                }

                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                }
            }
        }

    }

    protected void lnkbtnDesc_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("descriptive"))
        {
            string userid = Convert.ToString(e.CommandArgument);

            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
           
            objLIBAssignment.AsgnId = Convert.ToInt32(hdmasgnid.Value);
            objLIBAssignment.UserId = userid;
            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetSubmitedDescriptiveAssignmentByUserId(tp);
            GrdDescAns.DataSource = ds;
            GrdDescAns.DataBind();
        }

    }
    protected void lnkbtndownloadDesc_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("download"))
        {
            string filename = Convert.ToString(e.CommandArgument);
            if (filename != "")
            {
                string path = filename;
                //path = Path.Combine(path, filename);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Session["file"] = filename;
                    Response.Redirect("Download.aspx");
                    
                }
                else
                {
                    //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");

                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('This file does not exist.');", true);
                }
            }

        }

    }

    protected void lnkbtndownload_Command(object sender, CommandEventArgs e)
    {
        //if (e.CommandName.Equals("download"))
        //{
        //    string filename = Convert.ToString(e.CommandArgument);
        //    if (filename != "")
        //    {
        //        string path = filename;
        //        //path = Path.Combine(path, filename);
        //        System.IO.FileInfo file = new System.IO.FileInfo(path);
        //        if (file.Exists)
        //        {
        //            Response.Clear();
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        //            Response.AddHeader("Content-Length", file.Length.ToString());
        //            Response.ContentType = "application/octet-stream";
        //            Response.WriteFile(file.FullName);
        //            Response.End();
        //        }
        //        else
        //        {
        //            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");

        //            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('This file does not exist.');", true);
        //        }
        //    }

        //}

    }

    //protected void ddlActivationDate_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //   // Session["Dateassignment"] = ddlActivationDate.SelectedItem.Text;
    //    GetUserList();
    //}
    protected void ddlListExamSet_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //GetAssignmentActivateDateByAsgnId();
        hdmasgnid.Value = ddlListExamSet.SelectedValue;
        GetUserList();
    }
    protected void GrdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUserList.PageIndex = e.NewPageIndex;
        GetUserList();
    }
    protected void GrdUserList_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                
                LinkButton lnkbtntype = (LinkButton)e.Row.FindControl("lnkbtntype");
                LinkButton lnkbtndownload = (LinkButton)e.Row.FindControl("lnkbtndownload");
                HiddenField hdnAssignpath = (HiddenField)e.Row.FindControl("hdnAssignpath");
                HiddenField hdnAsgnId = (HiddenField)e.Row.FindControl("hdnAsgnId");
                HiddenField hdnUserID = (HiddenField)e.Row.FindControl("hdnUserID");
                HiddenField hdntype = (HiddenField)e.Row.FindControl("hdntype");

                HiddenField hdnTotalMarks = (HiddenField)e.Row.FindControl("hdnTotalMarks");
                HiddenField hdnstatus = (HiddenField)e.Row.FindControl("hdnstatus");
                LinkButton lnkbtnFacultyFeedback = (LinkButton)e.Row.FindControl("lnkbtnFacultyFeedback");

                if (hdntype.Value.ToLower() == "download")
                {
                   
                    lnkbtntype.Visible = false;
                    lnkbtndownload.Visible = true;
                    
                    // lnkbtndownload.PostBackUrl = "~/Admin/Handler.ashx?FILE=" + hdnAssignpath.Value;  comment by wahid 19-09-2020
                    lnkbtndownload.PostBackUrl= "~/Admin/AssignmentDownload.aspx?AsgnId="+ hdnAsgnId.Value + "&uid=" + hdnUserID.Value;
                }
                if (hdntype.Value.ToLower() == "details")
                {
                    //lnkbtntinstruction.Enabled = true;
                    lnkbtndownload.Visible = false;
                    lnkbtntype.Visible = true;
                    
                   lnkbtntype.PostBackUrl = "~/Admin/AssignmentInstructionAdmin.aspx?AsgnId=" + hdnAsgnId.Value + "&uid=" + hdnUserID.Value;
                    
                }
                if(hdnstatus.Value=="True" && hdnTotalMarks.Value !=null)
                {
                    lnkbtnFacultyFeedback.Visible = true;
                }
                else
                {
                    lnkbtnFacultyFeedback.Visible = false;
                }

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlListExamSet.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please select Assignment !');", true);
        }
        else
        {
            string AsgnId = ddlListExamSet.SelectedValue;
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('AssignAssignmentToFaculty.aspx?AsgnId=" + AsgnId + "');", true);
        }
    }
}
