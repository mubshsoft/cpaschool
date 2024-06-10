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

public partial class Admin_FacultyCompleteFormReport : System.Web.UI.Page
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
          
            BindFaculty();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }


    public void BindFaculty()
    {
        try
        {
            ImageButton2.Visible = true;
            lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
            LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
            DALFacultyDetails objDALFacultyDetails = new DALFacultyDetails();
            LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
            TransportationPacket tp = new TransportationPacket();


            objLIBFacultyDetails.Fid = Convert.ToInt32(Request.QueryString["Fid"]);
            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyCompleteReport(tp);
            objLIBFacultyDetailsListing = (LIBFacultyDetailsListing)tp.MessageResultset;

            if (objLIBFacultyDetailsListing != null)
            {
                if (objLIBFacultyDetailsListing.Count > 0)
                {

                    txtEmailAddress.Text = objLIBFacultyDetailsListing[0].Email;
                    txtFirstName.Text = objLIBFacultyDetailsListing[0].firstName;
                    txtMiddleName.Text = objLIBFacultyDetailsListing[0].MiddleName;
                    txtLastName.Text = objLIBFacultyDetailsListing[0].LastName;
                    txtDOB.Text = objLIBFacultyDetailsListing[0].DOB;
                    txtPermanentAddress.Text = objLIBFacultyDetailsListing[0].Address1;
                    txtCorrespondenceAddress.Text = objLIBFacultyDetailsListing[0].Address2;
                    txtContactNumber.Text = objLIBFacultyDetailsListing[0].ContactNumber1;
                    txtMobileNumber.Text = objLIBFacultyDetailsListing[0].ContactNumber2;
                    txtGender.Text = objLIBFacultyDetailsListing[0].Gender;
                    txtNationality.Text = objLIBFacultyDetailsListing[0].Nationality;
                    txtCategory.Text = objLIBFacultyDetailsListing[0].category;
                    txtprofile.Text = objLIBFacultyDetailsListing[0].Profile;

                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        string page = Convert.ToString(Request.QueryString["Page"]);

        if (page == "FacultyReport")
        {
            Response.Redirect("FacultyReport.aspx");

        }
        else
        {
            Response.Redirect("..Faculty/FacultyIntegratedReport.aspx");
        
        }


    }
}
