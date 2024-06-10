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

public partial class ScreeningSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Screeningusername"] == null)
        {
            Response.Redirect("../Screeninglogin.aspx");
        }
        try
        {
            //if (Session.Count <= 0)
            //{
            //    Response.Redirect("StudentPanel.aspx");

            //}
            if (!Page.IsPostBack)
            {

              
                BindScreeningSetList();
               

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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.UserId = Session["Screeningusername"].ToString();
            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetStudentScreeningSetList(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            grdScreeningSet.DataSource = objLibScreeningListing;
            grdScreeningSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void grdScreeningSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsScreening");
                HiddenField hdnScrId = (HiddenField)e.Row.FindControl("hdnScreeningID");
                HiddenField hdnPaper = (HiddenField)e.Row.FindControl("hdPaperTitle");
                HiddenField hdnScreeningtype = (HiddenField)e.Row.FindControl("hdnScreeningtype");
               // HiddenField hdnScreeningPath = (HiddenField)e.Row.FindControl("hdnScreeningPath");
                if (hdnScreeningtype.Value.ToLower() == "manual")
                {
                    valu.PostBackUrl = "~/Student/ScreeningDownLoad.aspx?ScrId=" + hdnScrId.Value;
                }
                if (hdnScreeningtype.Value.ToLower() == "online")
                {
                    valu.PostBackUrl = "~/Student/ScreeningInstruction.aspx?ScrId=" + hdnScrId.Value + "&paper=" + hdnPaper.Value;
                }

                //valu.PostBackUrl = "~/Student/ScreeningInstruction.aspx?ScrId=" + hdnScrId.Value + "&paper=" + hdnPaper.Value;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}
