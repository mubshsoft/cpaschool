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

public partial class Admin_AddEventManagement : System.Web.UI.Page
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
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["EventId"] != null)
                    {
                        hdnEventid.Value = Request.QueryString["EventId"].ToString();
                        BindEventManagementList();
                        
                    }
                    BindCorseDropDown();
                }
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
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
            ddlCourse.Items.Insert(1, "ALL");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindEventManagementList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBEvent objLIBExam = new LIBEvent();
            DALExam objDalExam = new DALExam();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.eventID = Convert.ToInt32(hdnEventid.Value);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetEventManagement(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTitle.Text = ds.Tables[0].Rows[0]["title"].ToString();
                txtDesc.Text= ds.Tables[0].Rows[0]["description"].ToString();
                txtStartDate.Text = ds.Tables[0].Rows[0]["startdate"].ToString();
                txtEnddate.Text = ds.Tables[0].Rows[0]["enddate"].ToString();

                string ThemeColor = ds.Tables[0].Rows[0]["ThemeColor"].ToString();

                ddlColor.SelectedIndex = ddlColor.Items.IndexOf(ddlColor.Items.FindByText(ThemeColor));

                chkchecked.Visible = true;
                chkchecked.Checked =Convert.ToBoolean(ds.Tables[0].Rows[0]["status"].ToString());
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
            if (ddlCourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Course');", true);
                return;
            }

            if (txtTitle.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Title cannot be left blank');", true);
                return;
            }

            if (txtDesc.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Description cannot be left blank');", true);
                return;
            }

            if (ddlColor.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Color');", true);
                return;
            }

            if (txtStartDate.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Start Date');", true);
                return;
            }

            if (txtEnddate.Text.Length == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select End Date');", true);
                return;
            }

            if (Convert.ToDateTime(txtStartDate.Text.ToString())> Convert.ToDateTime(txtEnddate.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('End Date must be greater than start Date');", true);
                return;
            }

           

            

            int addResult = 0;
            LIBEvent objLibExam = new LIBEvent();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            
            try
            {
                
                objLibExam.CourseID = Utility.CheckNullString(ddlCourse.SelectedValue);
                objLibExam.title = Utility.CheckNullString(txtTitle.Text);
                objLibExam.description = Utility.CheckNullString(txtDesc.Text);
                objLibExam.start_date =Convert.ToDateTime(txtStartDate.Text);
                objLibExam.end_date = Convert.ToDateTime(txtEnddate.Text);
                objLibExam.ThemeColor = ddlColor.SelectedItem.Text;

                if (hdnEventid.Value != "")
                {
                    objLibExam.eventID = (Convert.ToInt32(hdnEventid.Value));
                    chkchecked.Visible = true;
                    if (chkchecked.Checked)
                    {
                        objLibExam.Check = true;
                    }
                    else
                    {
                        objLibExam.Check = false;
                    }
                }
                else
                {
                    objLibExam.eventID = -1;
                    objLibExam.Check = true;
                }

                tp.MessagePacket = (object)objLibExam;
                addResult = OBJDALExam.AddUpadteEventManagement(tp);

                Uri ur = Request.Url;
                string AbsoluteURL = "";

                AbsoluteURL = ur.AbsoluteUri.Replace("AddEventManagement.aspx?EventId=" + hdnEventid.Value, "EventManagementList.aspx");
                if (addResult ==1 )
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Event Saved successfully'); location.href='" + AbsoluteURL + "';</script>");
                }
                else if (addResult > 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Event Updated successfully'); location.href='" + AbsoluteURL + "';</script>");
                }
                else if (addResult == -11)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Event');", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to save Event');", true);

                }
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EventManagementList.aspx");
    }
}