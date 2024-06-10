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


public partial class Admin_QueryReport : System.Web.UI.Page
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
        ImageButton2.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
        lblQueryTo.Visible = false;
        lblQueryTo1.Visible = false;

        lbldate.Visible = false;
        lblshowdate.Visible = false;

        lblStatus.Visible = false;
        lblStatus1.Visible = false;
        //ImageButton1.Visible = false;
        //ImageButton2.Visible = false;

        if (!IsPostBack)
        {
           
            BindCourseList();
        }
    }



    protected void BindCourseList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetCourseList(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = "CourseTitle";
            ddlCourse.DataValueField = "CourseId";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "--Select--");

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

  

    protected void bindgrid()
    {
        try
        {
            int status = Convert.ToInt32(ddlStauts.SelectedValue);
            int fid = Convert.ToInt32(ddlTo.SelectedValue);
            DataSet ds=new DataSet();
            
            LIBQueryDetails ObjLIBQueryDetails = new LIBQueryDetails();
            DALQueryDetails objDALQueryDetails = new DALQueryDetails();
            LIBQueryDetailsListing ObjLIBQueryDetailsListing = new LIBQueryDetailsListing();
            TransportationPacket tp = new TransportationPacket();
           
            ObjLIBQueryDetails.FID = fid;
            ObjLIBQueryDetails.Status = status;
            ObjLIBQueryDetails.bid = Convert.ToInt32(ddlbatch.SelectedValue);

            tp.MessagePacket = (object)ObjLIBQueryDetails;
            ds = objDALQueryDetails.GetQueryReport1(tp);
            //ObjLIBQueryDetailsListing = (LIBQueryDetailsListing)tp.MessageResultset;
            grdQueryDetails.DataSource = ds;
            grdQueryDetails.DataBind();
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }






    protected void grdQueryDetails_DataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblReplyDate = (Label)e.Row.FindControl("lblReplyDate");   
                if (lblReplyDate.Text == "")
                {
                    lblReplyDate.Text = "";
                }

               

                LinkButton lnkSubject = (LinkButton)e.Row.FindControl("lnkSubject");
                 HiddenField hdnQueryId = (HiddenField)e.Row.FindControl("hdnQueryId");
                lnkSubject.Attributes.Add("OnClick", "window.open('../Report/QueryDetails.aspx?lstquerydetails=" + hdnQueryId.Value + "','mywindow','left=300,top=20,width=510,height=650,location=0,toolbar=0,resizable=0')");


               
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }




    }




    protected void ImageButton3_Click(object sender, EventArgs e)
    {
        lblQueryTo.Visible = true;
        lblQueryTo1.Visible = true;

        lbldate.Visible = true;
        lblshowdate.Visible = true;

        lblStatus.Visible = true;
        lblStatus1.Visible = true;

        lblbatch.Visible = true;
        lblbatch1.Visible = true;

        lblcourse.Visible = true;
        lblcourse1.Visible = true;


        lblbatch1.Text = Convert.ToString(ddlbatch.SelectedItem);
        lblcourse1.Text = Convert.ToString(ddlbatch.SelectedItem);
        lblQueryTo1.Text = Convert.ToString(ddlTo.SelectedItem);
        lblStatus1.Text = Convert.ToString(ddlStauts.SelectedItem);
        lblshowdate.Text = Convert.ToString(DateTime.Now.ToString());
        ImageButton2.Visible = true;
        bindgrid();


    }
    protected void grdQueryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdQueryDetails.PageIndex = e.NewPageIndex;
            bindgrid();
        }
        catch(Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

        }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBatch();

    }
}
