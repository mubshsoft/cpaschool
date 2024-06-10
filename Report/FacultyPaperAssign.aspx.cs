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



public partial class Admin_FacultyPaperAssign : System.Web.UI.Page
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
        ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
        
        lblFacultyName.Text = Convert.ToString(Request.QueryString["FacultyName"]);
        lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
        bindgrid1();
        
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

            objLIBFacultyDetails.Fid = Convert.ToInt32(Request.QueryString["Fid"]);

            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyReport1(tp);
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





    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportToExcel("FacultySubjectAssignReportList.xls", grdFacultyDetails);
    }
    protected void btnExportToWord_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.ExportToWord("FacultySubjectAssignReportList.doc", grdFacultyDetails);
    }
    protected void grdFacultyDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
