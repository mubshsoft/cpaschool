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

public partial class ActvateAssignment_StudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
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
        if (!Page.IsPostBack)
        {

            BindActivateStudent();
            BindInActivateStudent();
        }
       
    }
    protected void BindActivateStudent()
    {
        try
        {
            string ss = Request.QueryString["AsgnId"].ToString();
            int AsgnId = 0;
            AsgnId=Convert.ToInt32(ss);

            int bid = Convert.ToInt32(Request.QueryString["bid"]);

            string activate = "-1";



            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = AsgnId;
            objLIBAssignment.BatchId = bid;
            objLIBAssignment.Activate = activate;
            objLIBAssignment.CourseId = 0;

            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.ReportStudentActivateAssignment(tp);
            grdActveStudent.DataSource = ds;
            grdActveStudent.DataBind();





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindInActivateStudent()
    {
        try
        {

            int AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"]);

            int bid = Convert.ToInt32(Request.QueryString["bid"]);





            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = AsgnId;
            objLIBAssignment.BatchId = bid;


            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.StudentInActivateAssignment(tp);
            grdInActiveStudent.DataSource = ds;
            grdInActiveStudent.DataBind();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                           
                            btnClose.Visible = true;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            btnClose.Visible = false;
                            btnSave.Visible = false;

                        }

                    }
                }
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
            for (int i = 0; i < grdInActiveStudent.Rows.Count; i++)
            {
                string userid = ((Label)grdInActiveStudent.Rows[i].FindControl("lbluserid")).Text.ToString();
                CheckBox chk = (CheckBox)grdInActiveStudent.Rows[i].FindControl("chk");
                if (chk.Checked == true)
                {
                    int addResult = 0;
                    LIBAssignment objLIBAssignment = new LIBAssignment();
                    DALAssignment objDalAssignment = new DALAssignment();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"]);
                    objLIBAssignment.BatchId = Convert.ToInt32(Request.QueryString["bid"]);
                    objLIBAssignment.UserId = userid;
                    

                    tp.MessagePacket = (object)objLIBAssignment;
                    addResult = objDalAssignment.AddActivateStudentAssignmentSet(tp);
                    //if (addResult == 1)
                    //{
                    //    //ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);


                    //}


                    //else
                    //{
                    //    //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Assignment Set'); </script>");


                    //}
                }
            }
            BindActivateStudent();
            BindInActivateStudent();
        }
        catch
        {
        }
        }
    protected void grdInActiveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInActiveStudent.PageIndex = e.NewPageIndex;
        BindInActivateStudent();
    }
    protected void grdActveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActveStudent.PageIndex = e.NewPageIndex;
        BindActivateStudent();
    }
    protected void grdActveStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            if (e.CommandName == "Deactivate")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DALAssignment objDalExam = new DALAssignment();

                string str = "delete from studentactiveassignment where id=" + id;
                objDalExam.ExeNQcomsp(str);
                BindInActivateStudent();
                BindActivateStudent();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>self.close(); location.href='AssignmentActivateExam.aspx';</script>");
        
    }
}

