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
public partial class Admin_SampleActivateExam : System.Web.UI.Page
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
                

                   
                    BindSampleSetList();
                    BindActivateSampleset();
                    //BindBatch();

              


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
            if (ddlSampleset.SelectedItem.Text == "--Select--")
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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SamId = Convert.ToInt32(ddlSampleset.SelectedValue.ToString());
            objLIBSample.BatchId = Convert.ToInt32(ddlbatch.SelectedValue.ToString());
            objLIBSample.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBSample.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);
            
            tp.MessagePacket = (object)objLIBSample;
            addResult = objDalSample.AddActivateSampleSet(tp);
            string Sampletype = objDalSample.GetSampleTypeBySamId(tp);
            if (addResult > 0)
            {
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                #region upadte StudenAssignmetActive when Sample type is offline
                if (Sampletype.ToLower() == "offline")
                {
                    int intScrId;
                    try
                    {
                        intScrId = Convert.ToInt32(ddlSampleset.SelectedValue.ToString());
                        string strQSample;
                        strQSample = "update studentActiveSample set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where ScrId=" + intScrId + "";
                        CLS_C.fnExecuteQuery(strQSample);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                #endregion upadte StudenAssignmetActive when Sample type is offline
               // ddlbatch.SelectedIndex = 0;
                ddlSampleset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                BindActivateSampleset();
                
               
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Sample Set already assigned');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Sample Set already assigned'); </script>");
                //ddlbatch.SelectedIndex = 0;
                ddlSampleset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
               //lblMessage.Text = "Sample Set already assigned";

            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Sample Set'); </script>");
                //lblMessage.Text = "Failed to Save ";

            }
        }
        catch (Exception ex)
        {
        }
            


            
    }

    protected void BindSampleSetList()
    {
        try
        {
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBSample;

            tp = objDalSample.GetSampleSetList(tp);
            objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
            ddlSampleset.DataSource = objLibSampleListing;
            ddlSampleset.DataTextField = "Samplecode";
            ddlSampleset.DataValueField = "SamId";
            ddlSampleset.DataBind();
            ddlSampleset.Items.Insert(0, "--Select--");

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
    //        LIBSample objLIBSample = new LIBSample();
    //        DALSample objDalSample = new DALSample();
    //        LIBSampleListing objLibSampleListing = new LIBSampleListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBSample.SamId = Convert.ToInt32(ddlSampleset.SelectedValue);
    //        tp.MessagePacket = (object)objLIBSample;

    //        ds = objDalSample.GetBatchBySamId(tp);
        
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
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }
    protected void ddlSampleset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSampleset.SelectedItem.Text == "--Select--")
        {
            return;
        }
        BindBatch();
    }

    protected void BindBatch()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SamId = Convert.ToInt32(ddlSampleset.SelectedValue);
            tp.MessagePacket = (object)objLIBSample;

            ds = objDalSample.GetBatchBySampleId(tp);

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
    protected void BindActivateSampleset()
    {
        DataSet ds = new DataSet();
        try
        {
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            TransportationPacket tp = new TransportationPacket();
            //objLIBSample.SampleId = Convert.ToInt32(ddlSampleset.SelectedValue);
            tp.MessagePacket = (object)objLIBSample;

            ds = objDalSample.GetActivateSampleSetData(tp);
            grdSampleSet.DataSource = ds;
            grdSampleSet.DataBind();



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdSampleSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdSampleSet.EditIndex = e.NewEditIndex;
        BindActivateSampleset();
    }
    protected void grdSampleSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            string hdnSampleid = ((HiddenField)grdSampleSet.Rows[e.RowIndex].FindControl("hdnSamId")).Value;
            string hdnbid = ((HiddenField)grdSampleSet.Rows[e.RowIndex].FindControl("hdnbid")).Value;
            TextBox txtactivateDate = (TextBox)grdSampleSet.Rows[e.RowIndex].FindControl("txtactivateDate");
            TextBox txtDeactivateDate = (TextBox)grdSampleSet.Rows[e.RowIndex].FindControl("txtDeactivateDate");

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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();
            objLIBSample.SamId = Convert.ToInt32(hdnSampleid);
            objLIBSample.CourseId = Convert.ToInt32(hdnbid);
            objLIBSample.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBSample.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);

            tp.MessagePacket = (object)objLIBSample;
            addResult = objDalSample.UpdateActivateSampleSet(tp);
            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully');", true);
               // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Update Successfully'); </script>");

                grdSampleSet.EditIndex = -1;
                BindActivateSampleset();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to update');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to update'); </script>");
                grdSampleSet.EditIndex = -1;
                BindActivateSampleset();
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void grdSampleSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdSampleSet.EditIndex = -1;
        BindActivateSampleset();
    }
}
