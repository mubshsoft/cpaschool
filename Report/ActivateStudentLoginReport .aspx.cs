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


public partial class Report_ActivateStudentLoginReport_ : System.Web.UI.Page
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

    protected void BindGrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();

            objStudent.fromDate = Convert.ToDateTime(txtfrmdt.Text);
            objStudent.toDate = Convert.ToDateTime(txttodt.Text);

            tp.MessagePacket = (object)objStudent;

            tp = objDalAddStudent_CS.GetStudentLoginReport(tp);
            objStudentListing = (LIBStudentListing)tp.MessageResultset;

            grdReport.DataSource = objStudentListing;
            grdReport.DataBind();
            ImageButton1.Visible = true;
            ImageButton2.Visible = true;
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
            BindGrid1();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        lbltoactivatedt.Text = Convert.ToString(txttodt.Text);
        lblactivatedt.Text = Convert.ToString(txtfrmdt.Text);
        lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
        BindGrid1();
    }
   
}
