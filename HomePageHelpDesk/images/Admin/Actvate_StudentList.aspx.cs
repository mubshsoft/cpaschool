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

public partial class Actvate_StudentList : System.Web.UI.Page
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

            BindActivateStudent();
            BindInActivateStudent();
        }
       
    }
    protected void BindActivateStudent()
    {
        try
        {
            string ss = Request.QueryString["Examid"].ToString();
            int examid = 0;
            examid=Convert.ToInt32(ss);

            int bid = Convert.ToInt32(Request.QueryString["bid"]);

            string activate = "-1";



            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            objLIBExam.BatchId = bid;
            objLIBExam.Activate = activate;
            objLIBExam.CourseId = 0;

            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.ReportStudentActivateExam(tp);
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

            int examid = Convert.ToInt32(Request.QueryString["examid"]);

            int bid = Convert.ToInt32(Request.QueryString["bid"]);





            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = examid;
            objLIBExam.BatchId = bid;


            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = objDalExam.StudentInActivateExam(tp);
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
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
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
                    LIBExam objLIBExam = new LIBExam();
                    DALExam objDalExam = new DALExam();
                    TransportationPacket tp = new TransportationPacket();
                    objLIBExam.ExamId = Convert.ToInt32(Request.QueryString["examid"]);
                    objLIBExam.BatchId = Convert.ToInt32(Request.QueryString["bid"]);
                    objLIBExam.UserId = userid;
                    

                    tp.MessagePacket = (object)objLIBExam;
                    addResult = objDalExam.AddActivateStudentExamSet(tp);
                    
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
            DALExam objDalExam = new DALExam();

            string str = "delete from studentactiveexam  where id=" + id;
           //string str = "update studentactiveexam set Activate=1  where id=" + id;
            objDalExam.ExeNQcomsp(str);
           
            BindInActivateStudent();
            BindActivateStudent();
        }
        }
        catch (Exception ex)
        {
        }
    }
}

