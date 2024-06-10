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

public partial class SampleSet : System.Web.UI.Page
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            //objLIBSample.UserId = Session["username"].ToString();
            tp.MessagePacket = (object)objLIBSample;

            tp = objDalSample.GetStudentSampleSetList(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            grdSampleSet.DataSource = objLibSampleListing;
            grdSampleSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdSampleSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsSample");
                HiddenField hdnSamId = (HiddenField)e.Row.FindControl("hdnSampleID");
               // HiddenField hdnPaper = (HiddenField)e.Row.FindControl("hdPaperTitle");
               // HiddenField hdnSampletype = (HiddenField)e.Row.FindControl("hdnSampletype");
               //// HiddenField hdnSamplePath = (HiddenField)e.Row.FindControl("hdnSamplePath");
               // if (hdnSampletype.Value.ToLower() == "manual")
               // {
               //     valu.PostBackUrl = "~/Student/SampleDownLoad.aspx?SamId=" + hdnSamId.Value;
               // }
               // if (hdnSampletype.Value.ToLower() == "online")
               // {
               //     valu.PostBackUrl = "~/Student/SampleInstruction.aspx?SamId=" + hdnSamId.Value + "&paper=" + hdnPaper.Value;
               // }

                valu.PostBackUrl = "~/Student/SampleInstruction.aspx?SamId=" + hdnSamId.Value;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdSampleSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSampleSet.PageIndex = e.NewPageIndex;
        BindSampleSetList();
    }
}
