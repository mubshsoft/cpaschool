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

public partial class Admin_AddQuestion : System.Web.UI.Page
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


        if (!Page.IsPostBack)
        {

            BindCategoryList();
           
        }
    }



    protected void BindCategoryList()
    {
        try
        {
            LIBCategory objLIBCategory = new LIBCategory();
            DALCategory objDalCategory = new DALCategory();
            LIBCategoryListing objLibCategoryListing = new LIBCategoryListing();
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBCategory;

            tp = objDalCategory.GetCategoryList(tp);
            objLibCategoryListing = (LIBCategoryListing)tp.MessageResultset;
            gvCategoryList.DataSource = objLibCategoryListing;
            gvCategoryList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void gvCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                HiddenField hdnCustId = (HiddenField)e.Row.FindControl("hdnCategoryID");

                //Add delete confirmation message for Customer
                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteCategory");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this Section ? ') ");


            }


        }
        catch (Exception ex)
        { }



    }
    protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView gvTemp = (GridView)sender;
        string CategoryID = ((HiddenField)gvTemp.Rows[e.RowIndex].FindControl("hdnDeleteCategoryID")).Value;


        try
        {
            int addResult = 0;
            LIBCategory objLibCategory = new LIBCategory();
            DALCategory OBJDALCategory = new DALCategory();
            TransportationPacket tp = new TransportationPacket();

            objLibCategory.CategoryID = Convert.ToInt32(CategoryID);
            tp.MessagePacket = (object)objLibCategory;
            addResult = OBJDALCategory.DeleteCategory(tp);

            if (addResult > 0)
            {
                //lblStatus.Text = "Sales Manager Saved Successfuly";
                //lblStatus.CssClass = "green";
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Section  Deleted'); </script>");
                ////lblStatus.Text = "Category  Deleted";
                ////lblStatus.CssClass = "green";
                txtCategory.Text = "";
                BindCategoryList();
               
            }


            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Delete Section Type'); </script>");
                //lblStatus.Text = "Failed to Delete Category Type";
                //lblStatus.CssClass = "red";

            }
        }
        catch { }

    }
    protected void gvCategoryList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCategoryList.EditIndex = e.NewEditIndex;
        BindCategoryList();
       
    }
    protected void gvCategoryList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCategoryList.EditIndex = -1;
        BindCategoryList();

    }
    protected void gvCategoryList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string CategoryID = ((HiddenField)gvCategoryList.Rows[e.RowIndex].FindControl("hdnCategoryID")).Value;
        TextBox txtCategoryName = (TextBox)gvCategoryList.Rows[e.RowIndex].FindControl("txtCategoryName");
        int addResult = 0;
        LIBCategory objLibCategory = new LIBCategory();
        DALCategory OBJDALCategory = new DALCategory();
        TransportationPacket tp = new TransportationPacket();

        objLibCategory.CategoryName = txtCategoryName.Text;
        objLibCategory.CategoryID = Convert.ToInt32(CategoryID);

        tp.MessagePacket = (object)objLibCategory;
        addResult = OBJDALCategory.AddUpdateCategory(tp);

        if (addResult > 0)
        {
            gvCategoryList.EditIndex = -1;
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Section Updated'); </script>");
            //lblStatus.Text = "Category Update";
            //lblStatus.CssClass = "green";
            txtCategory.Text = "";
            BindCategoryList();
            
        }
        else if (addResult == -11)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Section'); </script>");
            //lblStatus.Text = "Duplicate Category ";
            //lblStatus.CssClass = "red";

        }

        else
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Update Section'); </script>");
            //lblStatus.Text = "Failed to Update Category";
            //lblStatus.CssClass = "red";

        }
    }
    protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCategoryList.PageIndex = e.NewPageIndex;


            BindCategoryList();

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (string.IsNullOrEmpty(txtCategory.Text))
        {
            return;
        }

        int addResult = 0;
        LIBCategory objLibCategory = new LIBCategory();
        DALCategory OBJDALCategory = new DALCategory();
        TransportationPacket tp = new TransportationPacket();

        objLibCategory.CategoryName = Utility.CheckNullString(txtCategory.Text);
        objLibCategory.CategoryID = objLibCategory.CategoryID;

        tp.MessagePacket = (object)objLibCategory;
        addResult = OBJDALCategory.AddUpdateCategory(tp);

        if (addResult > 0)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Section  Saved'); </script>");
            //lblStatus.Text = "Category  Saved";
            //lblStatus.CssClass = "green";
            txtCategory.Text = "";
            BindCategoryList();
           
        }
        else if (addResult == -11)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Duplicate Section'); </script>");
            //lblStatus.Text = "Duplicate Category ";
            //lblStatus.CssClass = "red";

        }

        else
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to save Section'); </script>");
            //lblStatus.Text = "Failed to save Category ";
            //lblStatus.CssClass = "red";

        }
    }
}
