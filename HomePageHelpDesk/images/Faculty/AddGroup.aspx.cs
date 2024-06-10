using System;
using System.IO;
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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class Faculty_AddGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../login.aspx");

            }
            if (!Page.IsPostBack)
            {

                BindCorseDropDown();
                
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    private DataSet GroupList()
    {
        DataSet ds = new DataSet();

        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.BatchGroupList(tp);

        return ds;
        
    }
    protected void BindGroupList()
    {
        try
        {
            //BindGroupList();
            DataSet ds = GroupList();
            ViewState["ds"] = ds;
            grdExamSet.DataSource = ds;
            grdExamSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindCorseDropDown()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetCourse(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select-");
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindBatch()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.CourseId = Convert.ToInt32(ddlCourse.SelectedValue);

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetBatchByCourseId(tp);
            ddlBatch.DataSource = ds;
            ddlBatch.DataTextField = "batchcode";
            ddlBatch.DataValueField = "bid";
            ddlBatch.DataBind();

            ddlBatch.Items.Insert(0, "--Select--");

           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        else
        {
            lblreqcourse.Text = "";
        }
        if (ddlBatch.SelectedItem.Text=="--Select--")
        {
            lblreqBatch.Text = "Select Batch";
            return;
        }
        else
        {
            lblreqBatch.Text = "";
        }

        if (string.IsNullOrEmpty(txtGroupName.Text))
        {
            lblGroupName.Text = "Enter Group Name";
            return;
        }
        else
        {
            lblGroupName.Text = "";
        }
        try
        {

            
            int addResult = 0;

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.GroupId = -1;
            objLIBExam.bid = Convert.ToInt32(ddlBatch.SelectedItem.Value);
            objLIBExam.GroupName = txtGroupName.Text;
            objLIBExam.userid =Convert.ToInt32(Session["fid"].ToString());

            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddBatchGroup(tp);

            if (addResult > 0)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Exam created successfully'); </script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Group Created Successfully');", true);
                //lblMessage.Text = "Exam Set Saved Successfully";

                BindGroupList();
                ddlCourse.SelectedIndex = 0;
                ddlBatch.SelectedIndex = 0;
                txtGroupName.Text = "";
               
            }
            else if (addResult == -2)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
                lblMessage.Text = "Group is Already Craeted.";

            }
            else if (addResult == -11)
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Exam Set'); </script>");
                lblMessage.Text = "Duplicate Group";

            }

            else
            {
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
                lblMessage.Text = "Failed to Save";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedItem.Text == "-Select-")
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Select Course'); </script>");
            lblreqcourse.Text = "Select Course";
            return;
        }
        int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
        BindGroupList();
        BindBatch();
        
    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBatch.SelectedItem.Text == "--Select--")
        {
          //  lblreqBatch.Text = "Select Course";

            BindGroupList();
            return;
        }
        
        try
        {
            DataSet ds = new DataSet();
            if (ViewState["ds"] != null)
            {
                ds = (DataSet)ViewState["ds"];
                ds.Tables[0].DefaultView.RowFilter = "bid = " + ddlBatch.SelectedValue;
                DataTable dt = (ds.Tables[0].DefaultView).ToTable();
                grdExamSet.DataSource = dt;
                grdExamSet.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName.Equals("Delete"))
        //{
        //    string id = Convert.ToString(e.CommandArgument);

        //    int addResult = 0;
        //    LIBExam objLibExam = new LIBExam();
        //    DALChapter OBJDALExam = new DALChapter();
        //    TransportationPacket tp = new TransportationPacket();

        //    objLibExam.GroupId = Convert.ToInt32(id);
        //    tp.MessagePacket = (object)objLibExam;

        //    addResult = OBJDALExam.DeleteAssessmentsQuestion(tp);
        //    if(addResult>0)
        //    {
        //        DataSet ds = (DataSet)ViewState["ds"];
        //        ds.Tables[0].DefaultView.RowFilter = "bid = " + ddlBatch.SelectedValue;
        //        DataTable dt = (ds.Tables[0].DefaultView).ToTable();
        //        grdExamSet.DataSource = dt;
        //        grdExamSet.DataBind();
        //    }
        //}

    }
    protected void grdExamSet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;

       
        int id = Convert.ToInt32(((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value);
        try
        {
            int addResult = 0;
            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.GroupId = Convert.ToInt32(id);
            tp.MessagePacket = (object)objLibExam;

            addResult = OBJDALExam.DeleteBatchGroup(tp);
            if (addResult > 0)
            {

                lblMessage.Text = "Record deleted successfully";

                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
               
            }
            BindGroupList();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton l = (LinkButton)e.Row.FindControl("lnkDeletePaper");
                LinkButton lnkAssign = (LinkButton)e.Row.FindControl("lnkAssign");

                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");
                HiddenField hdnBid = (HiddenField)e.Row.FindControl("hdnBid");

                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this group ? '); ");
                lnkAssign.PostBackUrl = "AssignStudentinGroup.aspx?GroupId="+hdnId.Value + "&bid=" + hdnBid.Value  ;

            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void grdExamSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int addResult = 0;
            // int id = Convert.ToInt32(e.CommandArgument);
            HiddenField hdnID = (HiddenField)grdExamSet.Rows[e.RowIndex].FindControl("hdnId");
            TextBox txtGroupName = (TextBox)grdExamSet.Rows[e.RowIndex].FindControl("txtGroupName");

            DALExam objDalExam = new DALExam();

            string str = "update batchgroup set GroupName='" + txtGroupName.Text + "' where groupid=" + hdnID.Value;
            objDalExam.ExeNQcomsp(str);
            
            grdExamSet.EditIndex = -1;
            
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Record Updated');", true);
            BindGroupList();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdExamSet.EditIndex = e.NewEditIndex;
        BindGroupList();
    }
    protected void grdExamSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdExamSet.EditIndex = -1;
        BindGroupList();
    }
}
