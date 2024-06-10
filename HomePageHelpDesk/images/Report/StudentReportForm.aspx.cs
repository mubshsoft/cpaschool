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

public partial class Admin_StudentReportForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
        
        lblShowDate.Text = Convert.ToString(DateTime.Now.ToString());
        txtCourseTitle.Text = Convert.ToString(Request.QueryString["CourseTitle"]);

        GetStudentDataOfActiveStudents();


    }

    protected void GetStudentData()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objStudent.aid = Convert.ToInt32(Request.QueryString["AppId"]);

            tp.MessagePacket = (object)objStudent;
            tp = objDalAddStudent_CS.GetStudentlistforStudentReport(tp);            
            objStudentListing = (LIBStudentListing)tp.MessageResultset;            

            if (objStudentListing != null)
            {
                if (objStudentListing.Count > 0)
                {
                                      
                   txtEmailAddress.Text = objStudentListing[0].StudentEmail;
                   txtFirstName.Text = objStudentListing[0].FirstName;
                   txtMiddleName.Text = objStudentListing[0].MiddleName;
                   txtLastName.Text = objStudentListing[0].LastName;
                   txtDOB.Text = objStudentListing[0].DOB;
                   txtPermanentAddress.Text = objStudentListing[0].Address1;
                   txtCorrespondenceAddress.Text = objStudentListing[0].Address2;
                   txtContactNumber.Text = objStudentListing[0].ContactNumber1;
                   txtMobileNumber.Text = objStudentListing[0].ContactNumber2;
                   txtGender.Text = objStudentListing[0].Gender;

                   txtProfession.Text = objStudentListing[0].CuurentProfession;
                   txtNationality.Text = objStudentListing[0].Nationality;
                   txtCategory.Text = objStudentListing[0].category;

                   txtBoard1.Text = objStudentListing[0].edboard1;
                   txtStream1.Text = objStudentListing[0].edstream1;
                   txtMarks1.Text = Convert.ToString(objStudentListing[0].edmarks1);
                   txtYears1.Text = objStudentListing[0].edyrs1;
                   

                   txtBoard2.Text = objStudentListing[0].edboard2;
                   txtStream2.Text = objStudentListing[0].edstream2;
                   txtMarks2.Text = Convert.ToString(objStudentListing[0].edmarks2);
                   txtYears2.Text = objStudentListing[0].edyrs2;

                   txtBoard3.Text = objStudentListing[0].edboard3;
                   txtStream3.Text = objStudentListing[0].edstream3;
                   txtMarks3.Text = Convert.ToString(objStudentListing[0].edmarks3);
                   txtYears3.Text = objStudentListing[0].edyrs3;
                   


                   txtBoard4.Text = objStudentListing[0].edboard4;
                   txtStream4.Text = objStudentListing[0].edstream4;
                   txtMarks4.Text = Convert.ToString(objStudentListing[0].edmarks4);
                   txtYears4.Text = objStudentListing[0].edyrs4;

                   txtTotExp.Text = Convert.ToString(objStudentListing[0].totExp);

                   txtOrg1.Text = objStudentListing[0].ExOrg1;
                   txtPh1.Text = objStudentListing[0].ExPh1;
                   txtDesignation1.Text = objStudentListing[0].ExDesignation1;
                   txtYear1.Text = objStudentListing[0].ExService1;


                   txtOrg2.Text = objStudentListing[0].ExOrg2;
                   txtPh2.Text = objStudentListing[0].ExPh2;
                   txtDesignation2.Text = objStudentListing[0].ExDesignation2;
                   txtYear2.Text = objStudentListing[0].ExService2;

                   lbldate.Visible = true;
                   ImageButton1.Visible = true;
                   ImageButton2.Visible = true;

                }


        }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void GetStudentDataOfActiveStudents()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBStudent objStudent = new LIBStudent();
            DalAddStudent_CS objDalAddStudent_CS = new DalAddStudent_CS();
            DalAddStudent objDalAddStudent = new DalAddStudent();
            LIBStudentListing objStudentListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();

            objStudent.stid = Convert.ToInt32(Request.QueryString["Stid"]);

            tp.MessagePacket = (object)objStudent;
            tp = objDalAddStudent_CS.GetStudentlistforStudentReportForActiveReport(tp);
            objStudentListing = (LIBStudentListing)tp.MessageResultset;

            if (objStudentListing != null)
            {
                if (objStudentListing.Count > 0)
                {

                    txtEmailAddress.Text = objStudentListing[0].StudentEmail;
                    txtFirstName.Text = objStudentListing[0].FirstName;
                    txtMiddleName.Text = objStudentListing[0].MiddleName;
                    txtLastName.Text = objStudentListing[0].LastName;
                    txtDOB.Text = objStudentListing[0].DOB;
                    txtPermanentAddress.Text = objStudentListing[0].Address1;
                    txtCorrespondenceAddress.Text = objStudentListing[0].Address2;
                    txtContactNumber.Text = objStudentListing[0].ContactNumber1;
                    txtMobileNumber.Text = objStudentListing[0].ContactNumber2;
                    txtGender.Text = objStudentListing[0].Gender;

                    txtProfession.Text = objStudentListing[0].CuurentProfession;
                    txtNationality.Text = objStudentListing[0].Nationality;
                    txtCategory.Text = objStudentListing[0].category;

                    txtBoard1.Text = objStudentListing[0].edboard1;
                    txtStream1.Text = objStudentListing[0].edstream1;
                    txtMarks1.Text = Convert.ToString(objStudentListing[0].edmarks1);
                    txtYears1.Text = objStudentListing[0].edyrs1;


                    txtBoard2.Text = objStudentListing[0].edboard2;
                    txtStream2.Text = objStudentListing[0].edstream2;
                    txtMarks2.Text = Convert.ToString(objStudentListing[0].edmarks2);
                    txtYears2.Text = objStudentListing[0].edyrs2;

                    txtBoard3.Text = objStudentListing[0].edboard3;
                    txtStream3.Text = objStudentListing[0].edstream3;
                    txtMarks3.Text = Convert.ToString(objStudentListing[0].edmarks3);
                    txtYears3.Text = objStudentListing[0].edyrs3;



                    txtBoard4.Text = objStudentListing[0].edboard4;
                    txtStream4.Text = objStudentListing[0].edstream4;
                    txtMarks4.Text = Convert.ToString(objStudentListing[0].edmarks4);
                    txtYears4.Text = objStudentListing[0].edyrs4;

                    txtTotExp.Text = Convert.ToString(objStudentListing[0].totExp);

                    txtOrg1.Text = objStudentListing[0].ExOrg1;
                    txtPh1.Text = objStudentListing[0].ExPh1;
                    txtDesignation1.Text = objStudentListing[0].ExDesignation1;
                    txtYear1.Text = objStudentListing[0].ExService1;


                    txtOrg2.Text = objStudentListing[0].ExOrg2;
                    txtPh2.Text = objStudentListing[0].ExPh2;
                    txtDesignation2.Text = objStudentListing[0].ExDesignation2;
                    txtYear2.Text = objStudentListing[0].ExService2;

                    lbldate.Visible = true;
                    ImageButton1.Visible = true;
                    ImageButton2.Visible = true;

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
        string page = Convert.ToString(Request.QueryString["PageName"]);
        if (page == "IntegratedReport")
        {
            Response.Redirect("ActiveStudentsReport.aspx");
        }

        else
        {
            Response.Redirect("StudentNewReport.aspx");
        }
    }
}

