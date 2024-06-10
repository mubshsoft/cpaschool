using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using fmsf.lib;
using fmsf.DAL;

public partial class Faq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (!Page.IsPostBack)
            {
                BindCorseDropDown();
                int i = ddlCourse.SelectedIndex + 1;
                GetFaq(i);
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
            ddlCourse.DataSource = objLibExamListing;
            ddlCourse.DataTextField = objLIBExam.CourseDispalyText;
            ddlCourse.DataValueField = objLIBExam.CourseValueField;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, "-Select Course-");

           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    private void GetFaq(int courseid)
    {
        DataSet ds = new DataSet();

        LIBStudent objLIBExam = new LIBStudent();
        DalAddStudent_CS objDalExam = new DalAddStudent_CS();
        LIBStudentListing objLibExamListing = new LIBStudentListing();
        TransportationPacket tp = new TransportationPacket();

        objLIBExam.Courseid = courseid;
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.GetFAQList(tp);
        ArrayList arr = new ArrayList();
        StringBuilder sb = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                int id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                string strToprow = "";
                if (id == 1)
                {
                    strToprow = "show";
                }

               
                string strLnk = ds.Tables[0].Rows[i]["ID"].ToString();
                string strq = ds.Tables[0].Rows[i]["FaqQuestions"].ToString();
                string strans = ds.Tables[0].Rows[i]["FaqAnswers"].ToString();
                string heading = ds.Tables[0].Rows[i]["heading"].ToString();
                
               
                // sb.Append("<div class='accordion' id='accordionExample'>");
               
                sb.Append("<div class='card'>");
                if (!arr.Contains(heading))
                {
                    sb.Append("<h2 class='mb-0' style='padding-left:10px;background-color:#3598db;color:white;'>");
                    sb.Append(heading.ToString());
                    sb.Append("</h2>");
                    arr.Add(heading);
                }
                
                sb.Append("<div class='card-header' id='" + id + "'>");
                sb.Append("<h2 class='mb-0'>");
                sb.Append("<button type = 'button' class='btn btn-link' data-toggle='collapse' data-target='#collapse" + id + "'>" + strq + "</a>");
                sb.Append("</h2>");
                sb.Append("</div>");
                sb.Append("<div id='collapse" + id + "' class='collapse' aria-labelledby='" + id + "' data-parent='#accordionExample'>");
                sb.Append("<div class='card-body'>");
                sb.Append("<p>" + strans + "</p>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                // sb.Append("</div>");


            }

            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
            lblMessage.Visible = false ;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No record found !.";
            return;
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Select Course";
            return;
        }
        else
        {
            int CourseId = Convert.ToInt32(ddlCourse.SelectedValue);
            GetFaq(CourseId);
            lblMessage.Visible = false ;
        }
       
    }
}