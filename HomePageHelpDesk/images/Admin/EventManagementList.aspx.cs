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
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_EventManagementList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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
                BindEventManagementList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void BindEventManagementList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBEvent objLIBExam = new LIBEvent();
            DALExam objDalExam = new DALExam();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.eventID = 0;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetEventManagement(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEventManagementList.DataSource = ds;
                gvEventManagementList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvEventManagementList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value;
        

        try
        {
            int addResult = 0;
            LIBEvent objLibExam = new LIBEvent();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.eventID = Convert.ToInt32(hdnId);
            tp.MessagePacket = (object)objLibExam;

            addResult = OBJDALExam.DeleteEventManagement(tp);

            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Deleted Successfully.');", true);
            BindEventManagementList();




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvEventManagementList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");

                LinkButton linkEdit = (LinkButton)e.Row.FindControl("linkEdit");
                linkEdit.PostBackUrl = "~/Admin/AddEventManagement.aspx?EventId=" + hdnId.Value;
            }


            // LinkButton linkDelete = (LinkButton)e.Row.FindControl("linkDelete");
            //linkDelete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Knowledge center ? '); ");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }





    protected void gvEventManagementList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("addcoursedetails.aspx");
    }
    protected void gvEventManagementList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEventManagementList.PageIndex = e.NewPageIndex;
        BindEventManagementList();
    }
}
