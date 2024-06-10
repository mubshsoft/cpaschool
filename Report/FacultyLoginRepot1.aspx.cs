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


public partial class Report_FacultyLoginRepot : System.Web.UI.Page
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

            objLIBFacultyDetails.fromDate = Convert.ToDateTime(txtfrmdt.Text);
            objLIBFacultyDetails.toDate = Convert.ToDateTime(txttodt.Text);


            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyLoginReport(tp);
            objLIBFacultyDetailsListing = (LIBFacultyDetailsListing)tp.MessageResultset;

            grdReport.DataSource = objLIBFacultyDetailsListing;
            grdReport.DataBind();
            grdReport.Visible = true;
            ImageButton1.Visible = true;
            print_grid.Visible = true;
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

   
    protected void grdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         try
        {
            grdReport.PageIndex = e.NewPageIndex;
            bindgrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        lbltoactivatedt.Text = Convert.ToString(txttodt.Text);
        lblactivatedt.Text = Convert.ToString(txtfrmdt.Text);
        lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
        bindgrid1();
    }
}

