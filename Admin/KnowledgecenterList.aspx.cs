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
using System.IO;
using fmsf.lib;
using fmsf.DAL;

public partial class Admin_KnowledgecenterList : System.Web.UI.Page
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
                BindKnowledgeCenterList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void BindKnowledgeCenterList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.KCID = 0;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetKNDetails(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvKnowledgecenterList.DataSource = ds;
                gvKnowledgecenterList.DataBind();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvKnowledgecenterList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string hdnId = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnId")).Value;
        string hdnfilepath = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnfilepath")).Value;

        try
        {
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.KCID = Convert.ToInt32(hdnId);
            tp.MessagePacket = (object)objLibExam;

            addResult = OBJDALExam.DeleteKnowledgeCenter(tp);

            string fileToDelete = "";
            string uploadFolder = Server.MapPath("../") ;
            if (hdnfilepath != "")
                {
                fileToDelete = uploadFolder + hdnfilepath;
                try
                {
                    if (File.Exists(fileToDelete))
                    {
                        if (File.Exists(fileToDelete))
                        {
                            File.Delete(fileToDelete);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                }
            
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Deleted Successfully.');", true);
            BindKnowledgeCenterList();




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void gvKnowledgecenterList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnId");

                LinkButton linkEdit = (LinkButton)e.Row.FindControl("linkEdit");
                linkEdit.PostBackUrl = "~/Admin/Knowledgecenter.aspx?kcid=" + hdnId.Value;
            }
                

            // LinkButton linkDelete = (LinkButton)e.Row.FindControl("linkDelete");
            //linkDelete.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Knowledge center ? '); ");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }





    protected void gvKnowledgecenterList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("addcoursedetails.aspx");
    }
    protected void gvKnowledgecenterList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKnowledgecenterList.PageIndex = e.NewPageIndex;
        BindKnowledgeCenterList();
    }
}
