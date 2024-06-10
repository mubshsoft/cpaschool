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

public partial class Faculty_FacultyIntegratedReport1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblcourse.Text = Convert.ToString(Request.QueryString["Course"]);
        lblBatch.Text = Convert.ToString(Request.QueryString["Batch"]);
        lblStudentName.Text = Convert.ToString(Request.QueryString["FacultyName"]);
        // if (Session["username"] == null)
        //{
        //    Response.Redirect("../login.aspx");
        //}
        //else
        //{
        //    if (Session["role"].ToString() == "Admin")
        //    { }
        //    else
        //    {
        //        Response.Redirect("../login.aspx");
        //    }
        //}
        //try
        //{
        ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
            if (!Page.IsPostBack)
            {

        bindgrid1();
        BindLoginGrid();
        bindQuerygrid();
            }


        }

        //catch (Exception ex)
        //{
        //    HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        //}

    //}

    protected void BindLoginGrid()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();

            objStudent.Fid = Convert.ToInt32(Request.QueryString["Fid"]);

         

            tp.MessagePacket = (object)objStudent;

            tp = objDalAddStudent_CS.GetFacultyLastLoginReport(tp);
            objStudentListing = (LIBStudentListing)tp.MessageResultset;

            GridLoginReport.DataSource = objStudentListing;
            GridLoginReport.DataBind();





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void GridLoginReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdReport.PageIndex = e.NewPageIndex;
            BindLoginGrid();
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

            objLIBFacultyDetails.Fid = Convert.ToInt32(Request.QueryString["Fid"]);

            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyReport1(tp);
            objLIBFacultyDetailsListing = (LIBFacultyDetailsListing)tp.MessageResultset;

            grdReport.DataSource = objLIBFacultyDetailsListing;
            grdReport.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;

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

    protected void bindQuerygrid()
    {
        try
        {

            LIBQueryDetails ObjLIBQueryDetails = new LIBQueryDetails();
            DALQueryDetails objDALQueryDetails = new DALQueryDetails();
            LIBQueryDetailsListing ObjLIBQueryDetailsListing = new LIBQueryDetailsListing();
            TransportationPacket tp = new TransportationPacket();
            ObjLIBQueryDetails.FID = Convert.ToInt32(Request.QueryString["Fid"]);
            
            tp.MessagePacket = (object)ObjLIBQueryDetails;
            tp = objDALQueryDetails.GetNumberOfQueries4Faculty(tp);
            ObjLIBQueryDetailsListing = (LIBQueryDetailsListing)tp.MessageResultset;
            grdQueryDetails.DataSource = ObjLIBQueryDetailsListing;
            grdQueryDetails.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }









}
