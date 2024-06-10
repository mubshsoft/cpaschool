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
public partial class Admin_ScreeningActivateExam : System.Web.UI.Page
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
                

                   
                    BindScreeningSetList();
                    BindActivateScreeningset();
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
            if (ddlScreeningset.SelectedItem.Text == "--Select--")
            {
                return;
            }
            //if (ddlbatch.SelectedItem.Text == "--Select--")
            //{
            //    return;
            //}
       
            if (txtactivateDate.Text.Length  > 0)
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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Convert.ToInt32(ddlScreeningset.SelectedValue.ToString());
            //objLIBScreening.CourseId = Convert.ToInt32(ddlbatch.SelectedValue.ToString());
            objLIBScreening.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBScreening.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);
            
            tp.MessagePacket = (object)objLIBScreening;
            addResult = objDalScreening.AddActivateScreeningSet(tp);
            string Screeningtype = objDalScreening.GetScreeningTypeByScrId(tp);
            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                #region upadte StudenAssignmetActive when Screening type is offline
                if (Screeningtype.ToLower() == "offline")
                {
                    int intScrId;
                    try
                    {
                        intScrId = Convert.ToInt32(ddlScreeningset.SelectedValue.ToString());
                        string strQScreening;
                        strQScreening = "update studentActiveScreening set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where ScrId=" + intScrId + "";
                        CLS_C.fnExecuteQuery(strQScreening);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion upadte StudenAssignmetActive when Screening type is offline
               // ddlbatch.SelectedIndex = 0;
                ddlScreeningset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                BindActivateScreeningset();
                
               
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Screening Set already assigned');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Screening Set already assigned'); </script>");
                //ddlbatch.SelectedIndex = 0;
                ddlScreeningset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
               //lblMessage.Text = "Screening Set already assigned";

            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Screening Set'); </script>");
                //lblMessage.Text = "Failed to Save ";

            }
        }
        catch (Exception ex)
        {
        }
            


            
    }

    protected void BindScreeningSetList()
    {
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetScreeningSetList(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            ddlScreeningset.DataSource = objLibScreeningListing;
            ddlScreeningset.DataTextField = "Screeningcode";
            ddlScreeningset.DataValueField = "ScrId";
            ddlScreeningset.DataBind();
            ddlScreeningset.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    //protected void BindBatch()
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        LIBScreening objLIBScreening = new LIBScreening();
    //        DALScreening objDalScreening = new DALScreening();
    //        LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBScreening.ScrId = Convert.ToInt32(ddlScreeningset.SelectedValue);
    //        tp.MessagePacket = (object)objLIBScreening;

    //        ds = objDalScreening.GetBatchByScrId(tp);
        
    //        ddlbatch.DataSource = ds;
    //        ddlbatch.DataTextField = "batchcode";
    //        ddlbatch.DataValueField = "bid";
    //        ddlbatch.DataBind();
    //        ddlbatch.Items.Insert(0, "--Select--");

    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }


    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }
    protected void ddlScreeningset_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlScreeningset.SelectedItem.Text == "--Select--")
        //{
        //    return;
        //}
        //BindBatch();
    }
    protected void BindActivateScreeningset()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            //objLIBScreening.ScreeningId = Convert.ToInt32(ddlScreeningset.SelectedValue);
            tp.MessagePacket = (object)objLIBScreening;

            ds = objDalScreening.GetActivateScreeningSetData(tp);
            grdScreeningSet.DataSource = ds;
            grdScreeningSet.DataBind();



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdScreeningSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdScreeningSet.EditIndex = e.NewEditIndex;
        BindActivateScreeningset();
    }
    protected void grdScreeningSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            string hdnScreeningid = ((HiddenField)grdScreeningSet.Rows[e.RowIndex].FindControl("hdnScrid")).Value;
            string hdnbid = ((HiddenField)grdScreeningSet.Rows[e.RowIndex].FindControl("hdnbid")).Value;
            TextBox txtactivateDate = (TextBox)grdScreeningSet.Rows[e.RowIndex].FindControl("txtactivateDate");
            TextBox txtDeactivateDate = (TextBox)grdScreeningSet.Rows[e.RowIndex].FindControl("txtDeactivateDate");

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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScreeningid);
            objLIBScreening.CourseId = Convert.ToInt32(hdnbid);
            objLIBScreening.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBScreening.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);

            tp.MessagePacket = (object)objLIBScreening;
            addResult = objDalScreening.UpdateActivateScreeningSet(tp);
            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully');", true);
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Update Successfully'); </script>");

                grdScreeningSet.EditIndex = -1;
                BindActivateScreeningset();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to update');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to update'); </script>");
                grdScreeningSet.EditIndex = -1;
                BindActivateScreeningset();
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void grdScreeningSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdScreeningSet.EditIndex = -1;
        BindActivateScreeningset();
    }
}
