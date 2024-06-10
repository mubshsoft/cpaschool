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
public partial class Faculty_FacultyListExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
        }
        else
        {

        }
        if (!Page.IsPostBack)
        {
            BindCorseDropDown();
            BindAssignment();
        }
    }

    protected void BindCorseDropDown()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetCourse(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibAssignmentListing;
            ddlCourse.DataTextField = objLIBAssignment.CourseDispalyText;
            ddlCourse.DataValueField = objLIBAssignment.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select-");



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindAssignment()
    {
        try
        {
            string ss = Session["username"].ToString();
            int bid = 0;

            LIBExam objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBExamListing objLibAssignmentListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = ss;
            objLIBAssignment.BatchId = bid;


            tp.MessagePacket = (object)objLIBAssignment;
            DataSet ds = objDalAssignment.GetExamListToFaculty(tp);
            ViewState["ds"] = ds;
            GrdExam.DataSource = ds;
            GrdExam.DataBind();
          
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (ViewState["ds"] != null)
            {
                ds = (DataSet)ViewState["ds"];
                ds.Tables[0].DefaultView.RowFilter = "courseid = " + ddlCourse.SelectedValue;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();

                if (dt.Rows.Count > 0)
                {
                    ddlBatch.DataSource = dt.DefaultView.ToTable(true, "bid", "batchcode");
                    ddlBatch.DataTextField = "BatchCode";
                    ddlBatch.DataValueField = "bid";
                    ddlBatch.DataBind();
                    ddlBatch.Items.Insert(0, "SELECT");

                    GrdExam.DataSource = dt;
                    GrdExam.DataBind();
                    GrdExam.Visible = true;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Record Found.";
                    ddlBatch.Items.Clear();
                    GrdExam.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void GrdExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            if (ViewState["ds"] != null)
            {
                ds = (DataSet)ViewState["ds"];
                ds.Tables[0].DefaultView.RowFilter = "bid = " + ddlBatch.SelectedValue;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();

                if (dt.Rows.Count > 0)
                {
                    ddlListExamSet.DataSource = dt.DefaultView.ToTable(true, "Examid", "examCode");
                    ddlListExamSet.DataTextField = "examCode";
                    ddlListExamSet.DataValueField = "Examid";
                    ddlListExamSet.DataBind();
                    ddlListExamSet.Items.Insert(0, "SELECT");

                    GrdExam.DataSource = dt;
                    GrdExam.DataBind();
                    GrdExam.Visible = true;


                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "No Record Found.";
                    GrdExam.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void ddlListAssignmentSet_SelectedIndexChanged1(object sender, EventArgs e)
    {

        hdmasgnid.Value = ddlListExamSet.SelectedValue;
        GetUserList();
    }

    protected void GetUserList()
    {
        if (ddlListExamSet.SelectedItem.Text == "-Select-")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Exam Set');", true);
            return;
        }

        try
        {
            DataSet ds = new DataSet();
            LIBExam  objLIBAssignment = new LIBExam();
            DALExam objDalAssignment = new DALExam();
            LIBExamListing objLibAssignmentListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.BatchId = Convert.ToInt32(ddlBatch.SelectedItem.Value);
            objLIBAssignment.ExamId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);

            tp.MessagePacket = (object)objLIBAssignment;
           // string type = objDalAssignment.GetAssignmentTypeByAsgnId(tp);
           // objLIBAssignment.AssignmentType = type;
            tp.MessagePacket = (object)objLIBAssignment;
            ds = objDalAssignment.GetUserListBySubmiitedExam(tp);

            GrdUserList.DataSource = ds;
            GrdUserList.DataBind();

            //bindDescriptive();




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void bindDescriptive()
    {
        if (GrdUserList.Rows.Count > 0)
        {
            for (int i = 0; i < GrdUserList.Rows.Count; i++)
            {
                try
                {


                    LinkButton lnkbtnDesc = (LinkButton)GrdUserList.Rows[i].FindControl("lnkbtnDesc");
                    HiddenField hdnUserID = (HiddenField)GrdUserList.Rows[i].FindControl("hdnUserID");

                    DataSet ds = new DataSet();
                    LIBAssignment objLIBAssignment = new LIBAssignment();
                    DALAssignment objDalAssignment = new DALAssignment();
                    LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBAssignment.BatchId = Convert.ToInt32(hdnbatchid.Value);
                    objLIBAssignment.AsgnId = Convert.ToInt32(ddlListExamSet.SelectedItem.Value);
                    
                    tp.MessagePacket = (object)objLIBAssignment;
                    
                    ds = objDalAssignment.GetUserListBySubmiitedAssignment_HaveDescriptive(tp);
                    if (ds != null)
                    {
                        if (ds.Tables != null)
                        {
                            if (ds.Tables[0].Rows != null)
                            {
                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {

                                    if (ds.Tables[0].Rows[j]["UserId"].ToString() == hdnUserID.Value && ds.Tables[0].Rows[j]["descriptive"].ToString() == "1")
                                    {
                                        lnkbtnDesc.Visible = true;
                                    }


                                }

                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                }
            }
        }

    }

    protected void GrdUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUserList.PageIndex = e.NewPageIndex;
        GetUserList();
    }
    protected void GrdUserList_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                LinkButton lnkbtntype = (LinkButton)e.Row.FindControl("lnkbtntype");

                HiddenField hdnBatchid = (HiddenField)e.Row.FindControl("hdnBatchid");
                HiddenField hdnExamId = (HiddenField)e.Row.FindControl("hdnExamId");
                HiddenField hdnUserID = (HiddenField)e.Row.FindControl("hdnUserID");
                

                LinkButton lnkSubmitMarkformanual = (LinkButton)e.Row.FindControl("lnkSubmitMarkformanual");
                
                    lnkbtntype.Visible = true;
                    lnkbtntype.PostBackUrl = "~/Faculty/ExamInstruction.aspx?Exid=" + hdnExamId.Value + "&uid=" + hdnUserID.Value +"&Batchid="+ hdnBatchid.Value;
              
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void lnkbtndownloadDesc_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("download"))
        {
            string filename = Convert.ToString(e.CommandArgument);
            if (filename != "")
            {
                string path = filename;
                //path = Path.Combine(path, filename);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Session["file"] = filename;
                    Response.Redirect("Download.aspx");

                }
                else
                {
                    //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");

                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('This file does not exist.');", true);
                }
            }

        }

    }

    protected void lnkbtnDesc_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("descriptive"))
        {
            string userid = Convert.ToString(e.CommandArgument);

            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.AsgnId = Convert.ToInt32(hdmasgnid.Value);
            objLIBAssignment.UserId = userid;
            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetSubmitedDescriptiveAssignmentByUserId(tp);
            GrdDescAns.DataSource = ds;
            GrdDescAns.DataBind();
        }

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Course');", true);
            return;
        }
        else if (ddlBatch.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Batch');", true);
            return;
        }
        else if (ddlListExamSet.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Assignment');", true);
            return;
        }

        hdmasgnid.Value = ddlListExamSet.SelectedValue;
        GetUserList();
    }
}