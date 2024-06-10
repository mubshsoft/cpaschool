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

public partial class Admin_GeneratestudentIDCard : System.Web.UI.Page
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
                BindCorseDropDown();
               
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

    protected void BindBatch()
    {

        DataSet ds = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.CourseId = Convert.ToInt32(ddlcoursefillter.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetBatchByCourseId(tp);

            ddlbatch.DataSource = ds;
            ddlbatch.DataTextField = "batchcode";
            ddlbatch.DataValueField = "bid";
            ddlbatch.DataBind();
            ddlbatch.Items.Insert(0, "--Select--");

            if (ViewState["chkbatch"] != null)
            {
                ddlbatch.SelectedIndex = Convert.ToInt32(ViewState["chkbatch"].ToString());
            }

            // BindStudent();

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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing(); 
             TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue);
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds=new DataSet();
            ds = objDalExam.GetExamListByBatch(tp);

            ds.Tables[0].DefaultView.RowFilter = "bid = "+ ddlbatch.SelectedValue ;
            DataTable dt = (ds.Tables[0].DefaultView).ToTable();

           

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
   
    protected void BindStudent()
    {
        DataSet ds = new DataSet();
        try
        {
           
            
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.BatchId = Convert.ToInt32(ddlbatch.SelectedValue); ;
            
            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetStudentByBatch(tp);
            grdStudent.DataSource = ds;
            grdStudent.DataBind();



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
   
    protected void ddlcoursefillter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBatch();
    }
    protected void grdStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStudent.PageIndex = e.NewPageIndex;
        BindStudent();
    }
    protected void grdStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnicardStatus = (HiddenField)e.Row.FindControl("hdnicardStatus");
                HiddenField hdnbid = (HiddenField)e.Row.FindControl("hdnbid");
                LinkButton lnb_NormalStudent = (LinkButton)e.Row.FindControl("lnb_NormalStudent");

                if (hdnicardStatus.Value=="True" )
                {
                    lnb_NormalStudent.Text = "ID Card";
                }
              
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void grdStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.CommandName == "Student")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField hdncourseid = (HiddenField)grdStudent.Rows[index].FindControl("hdncourseid");
            HiddenField hdnbid = (HiddenField)grdStudent.Rows[index].FindControl("hdnbid");
            HiddenField hdnStid = (HiddenField)grdStudent.Rows[index].FindControl("hdnStid");
            HiddenField hdnicardStatus = (HiddenField)grdStudent.Rows[index].FindControl("hdnicardStatus");
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('StudentIDCard.aspx?cid=" + hdncourseid.Value + "&bid=" + hdnbid.Value + "&stid=" + hdnStid.Value + "&idcard = " + hdnicardStatus.Value.Trim() + "');", true);
             ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "window.openPopup('StudentIDCard.aspx?cid=" + hdncourseid.Value + "&bid=" + hdnbid.Value + "&stid=" + hdnStid.Value + "&idcard = " + hdnicardStatus.Value.Trim() + "');", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void ddlbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["chkbatch"] = ddlbatch.SelectedIndex;
        BindStudent();

    }
}
