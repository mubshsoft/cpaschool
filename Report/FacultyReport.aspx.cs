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
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_FacultyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
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
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
            if (!Page.IsPostBack)
            {
                
                bindgrid1();
            }


        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        
    }





   



    protected void grdFacultyDetails_DataBound(object sender, GridViewRowEventArgs e)
    {

       try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string hdnFid = ((HiddenField)e.Row.FindControl("hdnFid")).Value;
                string lblFacultyName = ((Label)e.Row.FindControl("lblFacultyName")).Text; 
                
             
               LinkButton l = (LinkButton)e.Row.FindControl("lnkRegisterDetails");
               l.PostBackUrl = "~/Report/FacultyCompleteFormReport.aspx?FId=" + hdnFid + "&FacultyName=" + lblFacultyName + "&PageName=" + "FacultyReport"; ;
            

                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPaperAssign");
                lnk.PostBackUrl = "~/Report/FacultyPaperAssign.aspx?FId=" + hdnFid +"&FacultyName=" + lblFacultyName;
               

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
   


    protected void bindgrid1()
    {
        DataSet ds = new DataSet();
        try
        {
                      
            LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
            DALFacultyDetails objDALFacultyDetails = new DALFacultyDetails();
            LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
            TransportationPacket tp = new TransportationPacket();

            //objLIBFacultyDetails.Fid = Convert.ToInt32(ddlFaculty.SelectedValue);

            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyNameforReport(tp);
            //tp = objDALFacultyDetails.GetFacultyReport1(tp);
            objLIBFacultyDetailsListing = (LIBFacultyDetailsListing)tp.MessageResultset;

            grdFacultyDetails.DataSource = objLIBFacultyDetailsListing;
            grdFacultyDetails.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;

       }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void grdFacultyDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdFacultyDetails.PageIndex = e.NewPageIndex;
            bindgrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}
