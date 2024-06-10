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
public partial class Admin_AssignExamToFaculty : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
               
                BindFacultyList();
                BindExamSetList();
                BindActivateFaculty();
            }


        }

        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void BindFacultyList()
    {
        DataSet ds = new DataSet();
        try
        {

            LIBFacultyDetails objLIBFacultyDetails = new LIBFacultyDetails();
            DALFacultyDetails objDALFacultyDetails = new DALFacultyDetails();
            LIBFacultyDetailsListing objLIBFacultyDetailsListing = new LIBFacultyDetailsListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBFacultyDetails;
            tp = objDALFacultyDetails.GetFacultyNameforReport(tp);

            objLIBFacultyDetailsListing = (LIBFacultyDetailsListing)tp.MessageResultset;

            ddlFaculty.DataSource = objLIBFacultyDetailsListing;
            ddlFaculty.DataTextField = "FacultyName";
            ddlFaculty.DataValueField = "Fid";
            ddlFaculty.DataBind();
            ddlFaculty.Items.Insert(0, "-Select-");


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void BindExamSetList()
    {
        try
        {
            int Examid = 0;
            if (Request.QueryString["Examid"].ToString() != null)
            {
                Examid = Convert.ToInt32(Request.QueryString["Examid"].ToString());
            }

            DataSet ds = new DataSet();
            LIBExam objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.ExamId = Examid;
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetExamDetailsById(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                lblAssignCode.Text = ds.Tables[0].Rows[0]["ExamCode"].ToString();
                lblCourseTitle.Text = ds.Tables[0].Rows[0]["CourseTitle"].ToString();
                lblPtitle.Text = ds.Tables[0].Rows[0]["PaperTitle"].ToString();
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlFaculty.SelectedItem.Text == "-Select-")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Faculty');", true);
                return;
            }

            int addResult = 0;

            int Examid = 0;
            int bid = 0;
            if (Request.QueryString["Examid"] != null)
            {
                Examid = Convert.ToInt32(Request.QueryString["Examid"]);
            }
            
            if (Request.QueryString["bid"] != null)
            {
                bid = Convert.ToInt32(Request.QueryString["bid"]);
            }

            LIBExam objLibAssignment = new LIBExam();
            DALExam OBJDALAssignment = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibAssignment.bid = bid;
            objLibAssignment.UserId = ddlFaculty.SelectedValue;
            objLibAssignment.ExamId = Examid;

            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateExamToFaculty(tp);
            if (addResult == 1)
            {
                ddlFaculty.SelectedIndex = 0;
                lblMessage.Text = "Assigned Successfully.";
                BindActivateFaculty();
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //Response.Write("<script> self.close();</script>");
            }
            else if (addResult == 2)
            {
                lblMessage.Text = "Already Assigned.";
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Already Assigned !'); </script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save'); </script>");
            }

            BindActivateFaculty();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>self.close();</script>");
    }

    protected void BindActivateFaculty()
    {
        try
        {
            string ss = Request.QueryString["Examid"].ToString();
            int Examid = 0;
            Examid = Convert.ToInt32(ss);

            LIBExam objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBExamListing objLibAssignmentListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.ExamId = Examid;

            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.GetAssignedExamtoFaculty(tp);
            grdActveFaculty.DataSource = ds;
            grdActveFaculty.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdActveFaculty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            if (e.CommandName == "Deactivate")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DALAssignment objDalExam = new DALAssignment();

                string str = "delete from FacultyActiveExam where id=" + id  ;
                objDalExam.ExeNQcomsp(str);

                BindActivateFaculty();
            }
        }
        catch (Exception ex)
        {
        }
    }
}