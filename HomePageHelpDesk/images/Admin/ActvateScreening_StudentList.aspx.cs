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

public partial class ActvateScreening_StudentList : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            BindYears();
            BindInActivateStudent();
            BindActivateStudent();
            
           
        }
        
    }
    protected void BindActivateStudent()
    {
        try
        {
            string ss = Request.QueryString["Scrid"].ToString();
            int Scrid = 0;
            Scrid=Convert.ToInt32(ss);

            int courseid = Convert.ToInt32(Request.QueryString["courseid"]);

            string activate = "-1";
           


            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Scrid;
           
            objLIBScreening.Activate = activate;
            objLIBScreening.CourseId = courseid;
            

            tp.MessagePacket = (object)objLIBScreening;
            DataSet ds = objDalScreening.ReportStudentActivateScreening(tp);
            grdActveStudent.DataSource = ds;
            grdActveStudent.DataBind();





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void BindInActivateStudent()
    {
        try
        {

            int Scrid = Convert.ToInt32(Request.QueryString["Scrid"]);

            int courseid = Convert.ToInt32(Request.QueryString["courseid"]);
            string strDll;
            if (ddlYear.SelectedIndex == 0)
            {
                strDll = "SELECT";
            }
            else
            {
                strDll = ddlYear.SelectedItem.Text;
            }




            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Scrid;
            objLIBScreening.CourseId = courseid;
            objLIBScreening.years = strDll;

            tp.MessagePacket = (object)objLIBScreening;
            DataSet ds = objDalScreening.StudentInActivateScreening(tp);
            grdInActiveStudent.DataSource = ds;
            grdInActiveStudent.DataBind();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                           
                            btnClose.Visible = true;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            btnClose.Visible = false;
                            btnSave.Visible = false;

                        }

                    }
                }
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
            for (int i = 0; i < grdInActiveStudent.Rows.Count; i++)
            {
                string userid = ((Label)grdInActiveStudent.Rows[i].FindControl("lbluserid")).Text.ToString();
                CheckBox chk = (CheckBox)grdInActiveStudent.Rows[i].FindControl("chk");
                if (chk.Checked == true)
                {
                    int addResult = 0;
                    LIBScreening objLIBScreening = new LIBScreening();
                    DALScreening objDalScreening = new DALScreening();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBScreening.ScrId = Convert.ToInt32(Request.QueryString["Scrid"]);
                    objLIBScreening.CourseId = Convert.ToInt32(Request.QueryString["courseid"]);
                    objLIBScreening.UserId = userid;
                    

                    tp.MessagePacket = (object)objLIBScreening;
                    addResult = objDalScreening.AddActivateStudentScreeningSet(tp);
                    //if (addResult == 1)
                    //{
                    //    //ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully');", true);


                    //}


                    //else
                    //{
                    //    //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Screening Set'); </script>");


                    //}
                }
            }
            BindActivateStudent();
            BindInActivateStudent();
        }
        catch
        {
        }
        }
    protected void grdInActiveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInActiveStudent.PageIndex = e.NewPageIndex;
        BindInActivateStudent();
    }
    protected void grdActveStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActveStudent.PageIndex = e.NewPageIndex;
        BindActivateStudent();
    }
    protected void grdActveStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            if (e.CommandName == "Deactivate")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DALScreening objDalExam = new DALScreening();

                string str = "delete from studentactivescreening where id=" + id;
                objDalExam.ExeNQcomsp(str);
                BindInActivateStudent();
                BindActivateStudent();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void BindYears()
    {
        try
        {
         
       

            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
           
            tp.MessagePacket = (object)objLIBScreening;
            DataSet ds = objDalScreening.StudentYears(tp);
                 
            ddlYear.DataSource = ds;
            ddlYear.DataValueField = "year";
            ddlYear.DataTextField = "year";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, "SELECT");





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(ddlYear.SelectedIndex==0)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Please Select Year');", true);
        //}

            BindInActivateStudent();
            BindActivateStudent();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindInActivateStudentSearch();
    }
    protected void BindInActivateStudentSearch()
    {
        try
        {

            int Scrid = Convert.ToInt32(Request.QueryString["Scrid"]);

            int courseid = Convert.ToInt32(Request.QueryString["courseid"]);
            string searchtxt = txtSearch.Text;





            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Scrid;
            objLIBScreening.CourseId = courseid;
            objLIBScreening.searchtxt = searchtxt;


            tp.MessagePacket = (object)objLIBScreening;
            DataSet ds = objDalScreening.StudentInActivateScreeningSearch(tp);
            grdInActiveStudent.DataSource = ds;
            grdInActiveStudent.DataBind();
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            btnClose.Visible = true;
                            btnSave.Visible = true;
                        }
                        else
                        {
                            btnClose.Visible = false;
                            btnSave.Visible = false;

                        }

                    }
                }
            }





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ScreeningActivateExam.aspx");
    }
}

