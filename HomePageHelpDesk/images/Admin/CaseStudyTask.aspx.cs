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
using System.IO;

public partial class Admin_CaseStudyTask : System.Web.UI.Page
{
    protected string secname = null;
    protected string secText = null;
    protected DataSet dsInstruction;
    int NOS = 0;
    string strHeading = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        if (!Page.IsPostBack)
        {
            if(Request.QueryString["ActionType"]!=null)
            {
                if(Request.QueryString["ActionType"].ToString()=="Add")
                {
                    txtCasestudy.Visible = true;
                    btnSave.Visible = true;
                }
                else if (Request.QueryString["ActionType"].ToString() == "Show")
                {
                    txtCasestudy.Visible = false;
                    fcasestudy.Visible = true;
                    btnSave.Visible = false;
                }
                hdnid.Value = Request.QueryString["CSId"].ToString();
            }
            BindInstructionList();
          
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
        }

    }
    
    protected void BindInstructionList()
    {
        try
        {
            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            LIBCaseStudyListing objLibAssignmentListing = new LIBCaseStudyListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId = Convert.ToInt32(Request.QueryString["CSId"]);
            
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetCaseStudyInstruction(tp);

            objLibAssignmentListing = (LIBCaseStudyListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblCourseName.Text = objLibAssignmentListing[0].CourseTitle;
                    lblCourseCode.Text = objLibAssignmentListing[0].CourseCode;
                    lblCaseStudyCode.Text = objLibAssignmentListing[0].CSCode;
                    lblPaperName.Text = objLibAssignmentListing[0].PaperTitle;
                    txtCasestudy.Text= objLibAssignmentListing[0].CaseStudyText;
                    lblcaseStudy.Text = objLibAssignmentListing[0].CaseStudyText;
                }
            }




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
   
    private void export()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=QuestionPaper_" + Request.QueryString["AsgnId"] + ".doc");

        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-word ";
        // string str = " <style type='text/css'> .text1  { font-family: Verdana, Arial, Helvetica, sans-serif;   font-size: 12px;   font-style: normal;   font-weight: normal;  }  </style>";
        StringWriter stringWriter = new StringWriter();

        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        this.RenderControl(htmlTextWriter);
        //stringWriter.WriteLine(str);
        Response.Write(stringWriter.ToString());
        Response.End();
    }
    //protected void BindQuestionList(int asgnid)
    //{
    //    try
    //    {
    //        DataSet ds2 = new DataSet();
    //        LIBAssignment objLIBAssignment = new LIBAssignment();
    //        DALAssignment objDalAssignment = new DALAssignment();
    //        LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBAssignment.AsgnId = asgnid;
    //        tp.MessagePacket = (object)objLIBAssignment;
    //        ds2 = objDalAssignment.GetQuestionList_(tp);

    //        dlsquestion.DataSource = ds2;
    //        dlsquestion.DataBind();



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
  
        try
        {
            if (string.IsNullOrEmpty(txtCasestudy.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Enter Case Study');", true);
                
                return;
            }
            

            int addResult = 0;

            LIBCaseStudy objLIBAssignment = new LIBCaseStudy();
            DALCaseStudy objDalAssignment = new DALCaseStudy();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.CSId =Convert.ToInt32(hdnid.Value);
            objLIBAssignment.CaseStudyText = txtCasestudy.Text;
            
            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.AddCaseStudyText(tp);

            if (addResult > 0)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Saved Successfully'); location.href='AddStudentTopic.aspx';", true);
              
                txtCasestudy.Text = "";
            }
            else if (addResult == -11)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Duplicate Case Study Set');", true);
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Failed to Save Case Study Set');", true);
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void ImgBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCaseStudySet.aspx");
    }
}
