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

public partial class Student_CaseStudySet : System.Web.UI.Page
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
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = Session["username"].ToString();
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetStudentCaseStudySetList(tp);
            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;
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
                    valu.PostBackUrl = "~/Student/CaseStudyDownload.aspx?CSId=" + hdnAsgnId.Value + "&type=Offline";
                }
                if (hdnAssignmenttype.Value.ToLower() == "online")
                {
                    valu.PostBackUrl = "~/Student/CaseStudyDownload.aspx?CSId=" + hdnAsgnId.Value + "&type=Online";
                    //valu.PostBackUrl = "~/Student/AssignmentInstruction.aspx?AsgnId=" + hdnAsgnId.Value + "&paper=" + hdnPaper.Value;
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
