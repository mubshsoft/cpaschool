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
public partial class ActivateExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default.aspx");
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
                

                   
                    BindExamSetList();
                 
                    BindCorseDropDown();

                 BindActivateExamset();


            }
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
            ddlcoursefillter.DataSource = objLibExamListing;
            ddlcoursefillter.DataTextField = objLIBExam.CourseDispalyText;
            ddlcoursefillter.DataValueField = objLIBExam.CourseValueField;
            ddlcoursefillter.DataBind();
            ddlcoursefillter.Items.Insert(0, "--Select--");



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
            if (ddlexamset.SelectedItem.Text == "--Select--")
            {
                return;
            }
            if (ddlbatch.SelectedItem.Text == "--Select--")
            {
                return;
            }
       
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

            int addResult, addResult1;
            addResult = 0;
            addResult1 = 0;
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(ddlexamset.SelectedValue.ToString());
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue.ToString());
            objLIBExam.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBExam.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);
            
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.AddActivateExamSet(tp);
            if(chbSupply.Checked==true)
            {
                addResult1 = objDalExam.AddStudentSupplExam(tp);
                //if(addResult1==1)
            }
            if (addResult == 1 && addResult1 == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Supplymentry Exam Successfully');", true);
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //lblMessage.Text = "Exam Set Saved Successfully";
                ddlbatch.SelectedIndex = 0;
                ddlexamset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                BindActivateExamset();
                addResult = 4;
            }
            else if (addResult == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);
                //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                //lblMessage.Text = "Exam Set Saved Successfully";
                ddlbatch.SelectedIndex = 0;
                ddlexamset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
                BindActivateExamset();  
            }
            else if (addResult == 2)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Exam Set already assigned');", true);
                //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Exam Set already assigned'); </script>");
                ddlbatch.SelectedIndex = 0;
                ddlexamset.SelectedIndex = 0;
                txtDeactivateDate.Text = "";
                txtactivateDate.Text = "";
               // lblMessage.Text = "Exam Set already assigned";

                //BindExamSetList();
              

            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
                //lblMessage.Text = "Failed to Save ";

            }
        }
        catch (Exception ex)
        {
        }
            


            
    }

    protected void BindExamSetList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetExamSetList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlexamset.DataSource = objLibExamListing;
            ddlexamset.DataTextField = "ExamCode";
            ddlexamset.DataValueField = "ExamId";
            ddlexamset.DataBind();
            ddlexamset.Items.Insert(0, "--Select--");

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
            objLIBExam.ExamId=Convert.ToInt32(ddlexamset.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetBatchByExamId(tp);
        
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
    protected void ddlexamset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlexamset.SelectedItem.Text == "--Select--")
        {
            return;
        }
        BindBatch();
    }
    protected void BindActivateExamset()
    {
        DataSet ds = new DataSet();
        try
        {
            int courseid = 0;
            int year = 0;
            if (ddlcoursefillter.SelectedItem.Text != "--Select--")
            {
                courseid = Convert.ToInt32(ddlcoursefillter.SelectedValue);
            }
            if (ddlyear.SelectedItem.Text != "--Select--")
            {
                year = Convert.ToInt32(ddlyear.SelectedValue);
            }
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = courseid;
            objLIBExam.Year = year;
            //objLIBExam.ExamId = Convert.ToInt32(ddlexamset.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetActivateExamSetData_(tp);
            grdExamSet.DataSource = ds;
            grdExamSet.DataBind();

           

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void grdExamSet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdExamSet.EditIndex = e.NewEditIndex;
        BindActivateExamset();
    }
    protected void grdExamSet_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            string hdnexamid = ((HiddenField)grdExamSet.Rows[e.RowIndex].FindControl("hdnexamid")).Value;
            string hdnbid = ((HiddenField)grdExamSet.Rows[e.RowIndex].FindControl("hdnbid")).Value;
            TextBox txtactivateDate = (TextBox)grdExamSet.Rows[e.RowIndex].FindControl("txtactivateDate");
            TextBox txtDeactivateDate = (TextBox)grdExamSet.Rows[e.RowIndex].FindControl("txtDeactivateDate");

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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(hdnexamid);
            objLIBExam.BatchId = Convert.ToInt32(hdnbid);
            objLIBExam.activateDate = Convert.ToDateTime(txtactivateDate.Text);
            objLIBExam.DeactivateDate = Convert.ToDateTime(txtDeactivateDate.Text);
            
            tp.MessagePacket = (object)objLIBExam;
            addResult = objDalExam.UpdateActivateExamSet(tp);
            if (addResult > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Update Successfully');", true);
               
                grdExamSet.EditIndex = -1;
                BindActivateExamset();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to update');", true);

                grdExamSet.EditIndex = -1;
                BindActivateExamset();
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void grdExamSet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdExamSet.EditIndex = -1;
        BindActivateExamset();
    }
   
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindActivateExamset();
    }
    protected void ddlcoursefillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindActivateExamset();
    }
    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdExamSet.PageIndex =e.NewPageIndex ;
        BindActivateExamset();
    }
    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DataSet ds = new DataSet();
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        HiddenField hdnexamid = (HiddenField)e.Row.FindControl("hdnexamid");
        //        HiddenField hdnbid = (HiddenField)e.Row.FindControl("hdnbid");
        //        CheckBox chk = (CheckBox)e.Row.FindControl("chkSupplyMentryExam");
        //        LinkButton lnb_NormalStudent = (LinkButton)e.Row.FindControl("lnb_NormalStudent");
        //        LinkButton lnb_SupplyStudent = (LinkButton)e.Row.FindControl("lnb_SupplyStudent");
        //        //try
        //        //{
        //        //    LIBExam objLIBExam = new LIBExam();
        //        //    DALExam objDalExam = new DALExam();
        //        //    TransportationPacket tp = new TransportationPacket();
        //        //    objLIBExam.ExamId = Convert.ToInt32(hdnexamid);
        //        //    objLIBExam.BatchId = Convert.ToInt32(hdnbid);
        //        //    tp.MessagePacket = (object)objLIBExam;
        //        //    ds = objDalExam.GetActiveExamForSupply(tp);
        //        //    if (ds.Tables[0] != null)
        //        //    {
        //        //        if (ds.Tables[0].Rows.Count > 0)
        //        //        {
        //        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        //            {
        //        //                if (hdnexamid.Value == ds.Tables[0].Rows[i]["ExamId"].ToString() && hdnbid.Value == ds.Tables[0].Rows[i]["bid"].ToString())
        //        //                {
        //        //                    chk.Checked = true;
        //        //                    if (chk.Checked == true)
        //        //                    {
        //        //                        lnb_SupplyStudent.Visible = true;
        //        //                        lnb_NormalStudent.Visible = false;
        //        //                    }
        //        //                }
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    Response.Write(ex.Message);
        //        //}
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
    }
    protected void grdExamSet_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.CommandName == "ExamCodeNormal")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField hdnexamid = (HiddenField)grdExamSet.Rows[index].FindControl("hdnexamid");
            HiddenField hdnbid = (HiddenField)grdExamSet.Rows[index].FindControl("hdnbid");
            try
            {
                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.ExamId = Convert.ToInt32(hdnexamid.Value);
                objLIBExam.BatchId = Convert.ToInt32(hdnbid.Value);
                tp.MessagePacket = (object)objLIBExam;
                ds = objDalExam.GetActiveExamForSupply(tp);
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (hdnexamid.Value == ds.Tables[0].Rows[i]["ExamId"].ToString() && hdnbid.Value == ds.Tables[0].Rows[i]["bid"].ToString())
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('Actvate_StudentListByFeeCheck.aspx?Examid=" + hdnexamid.Value + "&bid=" + hdnbid.Value + "');", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('Actvate_StudentList.aspx?Examid=" + hdnexamid.Value + "&bid=" + hdnbid.Value + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
