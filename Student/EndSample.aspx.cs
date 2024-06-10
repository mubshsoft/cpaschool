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
public partial class EndSample : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {

            if (!Page.IsPostBack)
            {
                hdnSamId.Value = Request.QueryString["SamId"].ToString();
               
                hdnusername.Value = Request.QueryString["username"].ToString();
                BindQuestionListwithsession();
                EndSampleTime();
               

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
           
            
           

            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            objLIBSample.SamId = Convert.ToInt32(hdnSamId.Value);
            objLIBSample.UserId = hdnusername.Value;
            

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBSample;
            int adresult = objDalSample.GetToatalAttemptQue(tp);

            //lbltxt.Text = "You have successfully completed your Sample for " + Session["paperTitle"].ToString(); ;
            lbltxt.Text = "You have successfully completed your Sample Exam." ; 
            //lbltxt.Text = "You Have successfully completed " + adresult + " Question!" + Session["paperTitle"].ToString();
          
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        Session["Sampleusername"] = "";
        Session.Abandon();
        StringBuilder javaScript = new StringBuilder();

        javaScript.Append("\n<script language=JavaScript>\n");
        javaScript.Append("window.history.forward(1);\n");
        javaScript.Append("</script>\n");

        Page.RegisterClientScriptBlock("HistoryScript", javaScript.ToString());
      
    }

    protected void EndSampleTime()
    {
        string strQ;
        strQ = "update studentActiveSample set EndSampletime='" + DateTime.Now.ToString() + "' where SamId='" + hdnSamId.Value + "' and UserId='" + hdnusername.Value.ToString() + "'";
        CLS_C.fnExecuteQuery(strQ);


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

                LIBSample objLIBSample = new LIBSample();
                DALSample objDalSample = new DALSample();
                LIBSampleListing objLibSampleListing = new LIBSampleListing();
                objLIBSample.SamId = Convert.ToInt32(hdnSamId.Value);
                objLIBSample.UserId = Session["Sampleusername"].ToString();
                objLIBSample.QuestionId = Convert.ToInt32(hdnQuestionId.Value); ;

                TransportationPacket tp = new TransportationPacket();
                tp.MessagePacket = (object)objLIBSample;
                tp = objDalSample.GetAnsText(tp);
                objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
                if (objLibSampleListing != null)
                {

                    if (objLibSampleListing.Count > 0)
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

