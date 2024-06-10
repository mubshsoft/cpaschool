using System;
using System.Text;
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
public partial class EndExam : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["username"] == null)
        //{
        //    Response.Redirect("../login.aspx");
        //}
        try
        {

            if (!Page.IsPostBack)
            {
                hdnExamId.Value = Request.QueryString["ExamID"].ToString();
                hdnusername.Value = Request.QueryString["username"].ToString();
                //hdnExamId.Value = Session["ExamID"].ToString();
                BindQuestionListwithsession();
                EndExamTime();

            }
          
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       

    }

  
    protected void BindQuestionListwithsession()
    {
        try
        {
           
            
           

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
            objLIBExam.UserId = hdnusername.Value;
            

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            int adresult = objDalExam.GetToatalAttemptQue(tp);

            lbltxt.Text = "You have successfully completed your exam .Please relogin to go back to student panel" ; 
            //lbltxt.Text = "You Have successfully completed " + adresult + " Question!" + Session["paperTitle"].ToString();
          
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void EndExamTime()
    {
        string strQ;
        strQ = "update studentActiveExam set EndExamtime='" + DateTime.Now.ToString() + "' where examid='" + hdnExamId.Value + "' and UserId='" + hdnusername.Value + "'";
        CLS_C.fnExecuteQuery(strQ);


    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        Session["username"] = "";
        Session.Abandon();
        StringBuilder javaScript = new StringBuilder();

        javaScript.Append("\n<script language=JavaScript>\n");
        javaScript.Append("window.history.forward(1);\n");
        javaScript.Append("</script>\n");

        Page.RegisterClientScriptBlock("HistoryScript", javaScript.ToString());
      
    }


  
    


   

  
   

  
  

    protected void DLSTSECTION_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {

            DataListItem row = e.Item;
            if (e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hdnQuestionId = (HiddenField)e.Item.FindControl("hdnQuestionId");
                LinkButton lnkbtncatgno = (LinkButton)e.Item.FindControl("lnkbtncatgno");

                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                LIBExamListing objLibExamListing = new LIBExamListing();
                objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                objLIBExam.UserId = Session["username"].ToString();
                objLIBExam.QuestionId = Convert.ToInt32(hdnQuestionId.Value); ;

                TransportationPacket tp = new TransportationPacket();
                tp.MessagePacket = (object)objLIBExam;
                tp = objDalExam.GetAnsText(tp);
                objLibExamListing = (LIBExamListing)tp.MessageResultset;
                if (objLibExamListing != null)
                {

                    if (objLibExamListing.Count > 0)
                    {
                        lnkbtncatgno.ForeColor = System.Drawing.Color.Red;


                    }
                }

            }
        }
        catch (Exception ex)
        {
        }
    }
}

