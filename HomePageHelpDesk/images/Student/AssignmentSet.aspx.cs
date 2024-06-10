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
using fmsf.DAL;
using fmsf.lib;

public partial class AssignmentSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("StudentPanel.aspx");

            }
            if (!Page.IsPostBack)
            {

              
                BindAssignmentSetList();
               

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
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = Session["username"].ToString();
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetStudentAssignmentSetList(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            grdAssignmentSet.DataSource = objLibAssignmentListing;
            grdAssignmentSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdAssignmentSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsAssignment");
                HiddenField hdnAsgnId = (HiddenField)e.Row.FindControl("hdnAssignmentID");
                HiddenField hdnPaper = (HiddenField)e.Row.FindControl("hdPaperTitle");
                HiddenField hdnAssignmenttype = (HiddenField)e.Row.FindControl("hdnAssignmenttype");
               // HiddenField hdnAssignmentPath = (HiddenField)e.Row.FindControl("hdnAssignmentPath");
                if (hdnAssignmenttype.Value.ToLower() == "manual" || hdnAssignmenttype.Value.ToLower() == "offline")
                {
                    valu.PostBackUrl = "~/Student/AssignmentDownLoad.aspx?AsgnId=" + hdnAsgnId.Value;
                }
                if (hdnAssignmenttype.Value.ToLower() == "online")
                {
                    valu.PostBackUrl = "~/Student/AssignmentInstruction.aspx?AsgnId=" + hdnAsgnId.Value + "&paper=" + hdnPaper.Value;
                }

                //valu.PostBackUrl = "~/Student/AssignmentInstruction.aspx?AsgnId=" + hdnAsgnId.Value + "&paper=" + hdnPaper.Value;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdAssignmentSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAssignmentSet.PageIndex = e.NewPageIndex;
        BindAssignmentSetList();
    }
}
