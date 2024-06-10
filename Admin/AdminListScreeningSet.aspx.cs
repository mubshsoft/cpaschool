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
public partial class AdminListScreeningSet : System.Web.UI.Page
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

               // hdnbatchid.Value = Request.QueryString["batchid"].ToString();

                BindCorseDropDown();
                //if (ddlListExamSet.SelectedItem.Text != "-Select-")
                //{
                //    GetScreeningActivateDateByScrId();
                //}

                if (Request.QueryString["cid"].Length > 0)
                {

                    ddlListCourse.SelectedIndex = ddlListCourse.Items.IndexOf(ddlListCourse.Items.FindByValue(Request.QueryString["cid"]));
                   BindScreeningDropDown();
                   ddlListExamSet.SelectedIndex = ddlListExamSet.Items.IndexOf(ddlListExamSet.Items.FindByValue(Request.QueryString["Scrid"]));
                   GetUserList();
                }


              


            }
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
            ddlListCourse.DataSource = objLibScreeningListing;
            ddlListCourse.DataTextField = objLIBScreening.CourseDispalyText;
            ddlListCourse.DataValueField = objLIBScreening.CourseValueField;
            ddlListCourse.DataBind();
            ddlListCourse.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlListCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlListCourse.SelectedItem.Text == "-Select-")
        {
           // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Course'); </script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Course');", true);
            return;
        }
        BindScreeningDropDown();
    }


    protected void BindScreeningDropDown()
    {
        //if (ddlListExamSet.SelectedItem.Text == "-Select-")
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Screening'); </script>");
        //    return;
        //}
        try
        {
            
            DataSet ds = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.CourseId = Convert.ToInt32(ddlListCourse.SelectedValue);
            tp.MessagePacket = (object)objLIBScreening;
            ds = objDalScreening.GetSubmitedScreeningByBatchId(tp);
            
            ddlListExamSet.DataSource = ds;
            ddlListExamSet.DataTextField = "ScrCode";
            ddlListExamSet.DataValueField = "Scrid";
            ddlListExamSet.DataBind();
            ddlListExamSet.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    //protected void GetScreeningActivateDateByScrId()
    //{
    //    if (ddlListExamSet.SelectedItem.Text == "-Select-")
    //    {
    //        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Select Screening'); </script>");
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Screening');", true);
            
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
    //        LIBScreening objLIBScreening = new LIBScreening();
    //        DALScreening objDalScreening = new DALScreening();
    //        LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBScreening.CourseId = Convert.ToInt32(ddlListCourse.SelectedValue);
    //        objLIBScreening.ScrId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
    //        tp.MessagePacket = (object)objLIBScreening;
    //        ds = objDalScreening.GetScreeningActivateDateByScrId(tp);
           
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
           
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Screening');", true);
            return;
        }
        //if (ddlActivationDate.SelectedItem.Text == "-Select-")
        //{
           
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Date');", true);
        //    return;
        //}
        try
        {
            DataSet ds = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.CourseId = Convert.ToInt32(ddlListCourse.SelectedValue);
            objLIBScreening.ScrId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
            //objLIBScreening.activateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Text);
            //objLIBScreening.DeactivateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Value);
            tp.MessagePacket = (object)objLIBScreening;
            string type=objDalScreening.GetScreeningTypeByScrId(tp);
            objLIBScreening.ScreeningType = type;
            tp.MessagePacket = (object)objLIBScreening;
            ds = objDalScreening.GetUserListBySubmiitedScreening(tp);
           
            GrdUserList.DataSource = ds;
            GrdUserList.DataBind();

            bindDescriptive();


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

   
  
   

    //protected void ddlActivationDate_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    Session["datescreening"] = ddlActivationDate.SelectedItem.Text;
    //    GetUserList();
    //}
    protected void ddlListExamSet_SelectedIndexChanged1(object sender, EventArgs e)
    {
      
        hdmScrid.Value = ddlListExamSet.SelectedValue;
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
              
                HiddenField hdnScrID = (HiddenField)e.Row.FindControl("hdnScrID");
                HiddenField hdnUserID = (HiddenField)e.Row.FindControl("hdnUserID");
                //GrdUserList.Columns[4].Visible=false;
                    lnkbtntype.PostBackUrl = "~/Admin/ScreeningInstructionAdmin.aspx?ScrId=" + hdnScrID.Value + "&uid=" + hdnUserID.Value + "&cid=" + ddlListCourse.SelectedValue;
                //}

            }


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
                    LIBScreening objLIBScreening = new LIBScreening();
                    DALScreening objDalScreening = new DALScreening();
                    LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBScreening.CourseId = Convert.ToInt32(ddlListCourse.SelectedValue);
                    objLIBScreening.ScrId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
                    //objLIBScreening.activateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Text);
                    //objLIBScreening.DeactivateDate = Convert.ToDateTime(ddlActivationDate.SelectedItem.Value);
                    tp.MessagePacket = (object)objLIBScreening;
                   
                    ds = objDalScreening.GetUserListBySubmiitedScreening_HaveDescriptive(tp);
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

    protected void lnkbtnDesc_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("descriptive"))
        {
            string userid = Convert.ToString(e.CommandArgument);

            DataSet ds = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBScreening.ScrId = Convert.ToInt32(hdmScrid.Value);
            objLIBScreening.UserId = userid;
            tp.MessagePacket = (object)objLIBScreening;

            ds = objDalScreening.GetSubmitedDescriptiveScreeningByUserId(tp);
            GrdDescAns.DataSource = ds;
            GrdDescAns.DataBind();
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScreeningPanel.aspx");
    }
}
