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

public partial class Admin_AssignAssignmentToFaculty : System.Web.UI.Page
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
                BindAssignmentSetList();
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

    protected void BindAssignmentSetList()
    {
        try
        {
            int AsgnId = 0;
            if(Request.QueryString["AsgnId"].ToString()!=null)
            {
                AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"].ToString());
            }
           
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.AsgnId = AsgnId;
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetAssignmentDetailsById(tp);
            if(ds.Tables[0].Rows.Count>0)
            {
                lblType.Text = ds.Tables[0].Rows[0]["AssignmentType"].ToString();
                lblAssignCode.Text = ds.Tables[0].Rows[0]["AsgnCode"].ToString();
                lblCourseTitle.Text = ds.Tables[0].Rows[0]["CourseTitle"].ToString();
                lblPtitle.Text = ds.Tables[0].Rows[0]["PaperTitle"].ToString();
            }
            

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ddlFaculty.SelectedItem.Text == "-Select-")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Faculty');", true);
                return;
            }

            int addResult = 0;

            int AsgnId = 0;
            if (Request.QueryString["AsgnId"] != null)
            {
                AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"]);
            }

            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            objLibAssignment.UserId = ddlFaculty.SelectedValue;
            objLibAssignment.AsgnId = AsgnId;

            tp.MessagePacket = (object)objLibAssignment;
            addResult = OBJDALAssignment.AddUpdateAssignmentToFaculty(tp);
            if (addResult == 1)
            {
                ddlFaculty.SelectedIndex = 0;
                lblMessage.Text = "Assigned Successfully.";
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
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>self.close();</script>");
    }

    protected void BindActivateFaculty()
    {
        try
        {
            string ss = Request.QueryString["AsgnId"].ToString();
            int AsgnId = 0;
            AsgnId = Convert.ToInt32(ss);

            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = AsgnId;
            
            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.GetAssignedAssignmenttoFaculty(tp);
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

                string str = "delete from FacultyActiveAssignment where id=" + id;
                objDalExam.ExeNQcomsp(str);

                BindActivateFaculty();
            }
        }
        catch (Exception ex)
        {
        }
    }
}