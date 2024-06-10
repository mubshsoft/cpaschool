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
public partial class ListSocial : System.Web.UI.Page
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
               


                    BindCourseList();

               


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }

   
 
    protected void BindCourseList()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = CLS_C.fnQuerySelectDs("select * from tblmstSocialMedia");
            gvQuestionList.DataSource = ds;
            gvQuestionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

   
    



    protected void gvQuestionList_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited.  
        gvQuestionList.EditIndex = e.NewEditIndex;
        BindCourseList();
    }

    protected void gvQuestionList_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        gvQuestionList.EditIndex = -1;
        BindCourseList();
    }
    protected void gvQuestionList_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
      
        TextBox txt_OrderNumber = gvQuestionList.Rows[e.RowIndex].FindControl("txt") as TextBox;
        try
        {
            long addResult = 0;


            addResult = CLS_C.fnExecuteQuery("update tblmstSocialMedia set lnk='" + txt_OrderNumber.Text + "' where id=" + gvQuestionList.DataKeys[e.RowIndex].Value.ToString());
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        gvQuestionList.EditIndex = -1;

        BindCourseList();
    }
   
}
