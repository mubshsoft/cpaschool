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

public partial class Admin_CaseStudyActivate : System.Web.UI.Page
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


        try
        {

            if (!Page.IsPostBack)
            {



                BindCaseStudySetList();
                BindActivateCaseStudyset();
                //BindBatch();




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
            if (ddlCaseStudyset.SelectedItem.Text == "--Select--")
            {
                return;
            }
            if (ddlbatch.SelectedItem.Text == "--Select--")
            {
                return;
            }

            if (txtactivateDate.Text.Length > 0)
            {
                DateTime d;

                try
                {
                    d = DateTime.Parse(txtactivateDate.Text);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                    return;
                }
            }
            else
            {
                lblMessage.Text = "Can not be blank";
            }



            if (txtactivateDate.Text.Length > 0)
            {
                DateTime d;

                d = DateTime.Parse(txtactivateDate.Text);
                if (d < System.DateTime.Now.Date)
                {
                    lblMessage.Text = "Activate Date should be greater than current date";
                    return;
                }
            }


            if (txtDeactivateDate.Text.Length > 0)
            {
                DateTime d;

                try
                {
                    d = DateTime.Parse(txtDeactivateDate.Text);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                    return;
                }
            }
            else
            {
                lblMessage.Text = "Can not be blank";
            }

            if (txtDeactivateDate.Text.Length > 0)
            {
                DateTime d;

                d = DateTime.Parse(txtDeactivateDate.Text);
                if (d < System.DateTime.Now.Date)
                {
                    lblMessage.Text = "Deactivate Date should be greater than current date";
                    return;
                }
            }


            int addResult = 0;
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(ddlCaseStudyset.SelectedValue.ToString());
            objLIBAssignment.BatchId = Convert.ToInt32(ddlbatch.SelectedValue.ToString());
            objLIBAssignment.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBAssignment.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);

            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.AddActivateCaseStudySet(tp);
            //string assignmenttype = objDalAssignment.GetAssignmentTypeByAsgnId(tp);
            if (addResult > 0)
            {
               
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                #region upadte StudenAssignmetActive when assignment type is offline
                //if ((assignmenttype.ToLower() == "offline") || (assignmenttype.ToLower() == "manual"))
                //{
                //    int intAsgnId;
                //    try
                //    {
                //        /*  comment made by wahid on 19-09 -2020
                //        intAsgnId = Convert.ToInt32(ddlAssignmentset.SelectedValue.ToString());
                //        string strQAssignment;
                //        strQAssignment = "update studentActiveAssignment set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where AsgnId=" + intAsgnId + "";
                //        CLS_C.fnExecuteQuery(strQAssignment);
                //        */
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
                #endregion upadte StudenAssignmetActive when assignment type is offline
                ddlbatch.SelectedIndex = 0;
                ddlCaseStudyset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                BindActivateCaseStudyset();


            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Case Study Already Assigned');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Assignment Set already assigned'); </script>");
                ddlbatch.SelectedIndex = 0;
                ddlCaseStudyset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                //lblMessage.Text = "Assignment Set already assigned";

            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Case Study'); </script>");
                //lblMessage.Text = "Failed to Save ";

            }
        }
        catch (Exception ex)
        {
        }




    }

    protected void BindCaseStudySetList()
    {
        try
        {
            int courseid = 0;
            int year = 0;

            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CourseId = courseid;
            objLIBAssignment.Year = year;
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetCaseStudySetList(tp);
            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;
            ddlCaseStudyset.DataSource = objLibAssignmentListing;
            ddlCaseStudyset.DataTextField = "CSCode";
            ddlCaseStudyset.DataValueField = "CSId";
            ddlCaseStudyset.DataBind();
            ddlCaseStudyset.Items.Insert(0, "--Select--");

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
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(ddlCaseStudyset.SelectedValue);
            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetBatchByCSId(tp);

            ddlbatch.DataSource = ds;
            ddlbatch.DataTextField = "batchcode";
            ddlbatch.DataValueField = "bid";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }
    protected void ddlCaseStudyset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCaseStudyset.SelectedItem.Text == "--Select--")
        {
            return;
        }
        BindBatch();
    }
    protected void BindActivateCaseStudyset()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            
            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetActivateCaseStudySetData(tp);
            grdAssignmentSet.DataSource = ds;
            grdAssignmentSet.DataBind();



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdAssignmentSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdAssignmentSet.EditIndex = e.NewEditIndex;
        BindActivateCaseStudyset();
    }
    protected void grdAssignmentSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            string hdnAssignmentid = ((HiddenField)grdAssignmentSet.Rows[e.RowIndex].FindControl("hdnAsgnid")).Value;
            string hdnbid = ((HiddenField)grdAssignmentSet.Rows[e.RowIndex].FindControl("hdnbid")).Value;
            TextBox txtactivateDate = (TextBox)grdAssignmentSet.Rows[e.RowIndex].FindControl("txtactivateDate");
            TextBox txtDeactivateDate = (TextBox)grdAssignmentSet.Rows[e.RowIndex].FindControl("txtDeactivateDate");

            if (txtactivateDate.Text.Length > 0)
            {
                DateTime d;

                try
                {
                    d = DateTime.Parse(txtactivateDate.Text);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                    return;
                }
            }
            else
            {
                lblMessage.Text = "Can not be blank";
            }



            //if (txtactivateDate.Text.Length > 0)
            //{
            //    DateTime d;

            //    d = DateTime.Parse(txtactivateDate.Text);
            //    if (d < System.DateTime.Now.Date)
            //    {
            //        lblMessage.Text = "Activate Date should be greater than current date";
            //        return;
            //    }
            //}


            if (txtDeactivateDate.Text.Length > 0)
            {
                DateTime d;

                try
                {
                    d = DateTime.Parse(txtDeactivateDate.Text);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Invalid date!format should be mm/dd/yyyy";
                    return;
                }
            }
            else
            {
                lblMessage.Text = "Can not be blank";
            }

            if (txtDeactivateDate.Text.Length > 0)
            {
                DateTime d;

                d = DateTime.Parse(txtDeactivateDate.Text);
                if (d < System.DateTime.Now.Date)
                {
                    lblMessage.Text = "Deactivate Date should be greater than current date";
                    return;
                }
            }


            int addResult = 0;
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(hdnAssignmentid);
            objLIBAssignment.BatchId = Convert.ToInt32(hdnbid);
            objLIBAssignment.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBAssignment.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);

            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.UpdateActivateCaseStudySet(tp);
            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully');", true);
                // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Update Successfully'); </script>");

                grdAssignmentSet.EditIndex = -1;
                BindActivateCaseStudyset();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to update');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to update'); </script>");
                grdAssignmentSet.EditIndex = -1;
                BindActivateCaseStudyset();
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void grdAssignmentSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdAssignmentSet.EditIndex = -1;
        BindActivateCaseStudyset();
    }
}
