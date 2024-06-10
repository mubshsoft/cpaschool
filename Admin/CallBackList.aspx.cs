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

public partial class Admin_CallBackList : System.Web.UI.Page
{
    string strSearch = "";
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

                BindCallbackList(strSearch);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }



    protected void BindCallbackList(string serach)
    {
        try
        {
            DataSet ds = new DataSet();

            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.Search = serach;

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetCallbackList(tp);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCallbackList.DataSource = ds;
                gvCallbackList.DataBind();

                gvCallbackList.Visible = true; 
                lblMessage.Visible = false;
            }
            else
            {
                gvCallbackList.Visible = false;
                lblMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void gvCallbackList_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvCallbackList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void gvCallbackList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCallbackList.PageIndex = e.NewPageIndex;

        if(ViewState["search"].ToString()!="")
        {
            strSearch = txtSearch.Text;
            BindCallbackList(strSearch);
        }
        else
        {
            BindCallbackList("");
        }
        
        
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if(txtSearch.Text.Length==0)
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Please Enter keyword to search'); </script>");
        //}
        //else
        //{
            ViewState["search"] = "search";
            BindCallbackList(txtSearch.Text);
        //}
    }
}
