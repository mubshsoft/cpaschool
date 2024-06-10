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
public partial class EndAssignment : System.Web.UI.Page
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
                hdnAsgnId.Value = Request.QueryString["AsgnId"].ToString();
               // hdnAsgnId.Value = Session["AsgnId"].ToString();
                hdnusername.Value = Request.QueryString["username"].ToString();
                BindQuestionListwithsession();
                EndAssignmentTime();
               

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
           
            
           

            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.UserId = hdnusername.Value;
            

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            int adresult = objDalAssignment.GetToatalAttemptQue(tp);

            lbltxt.Text = "You have successfully completed your Assignment  ";
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
        Session["username"] = "";
        Session.Abandon();
        StringBuilder javaScript = new StringBuilder();

        javaScript.Append("\n<script language=JavaScript>\n");
        javaScript.Append("window.history.forward(1);\n");
        javaScript.Append("</script>\n");

        Page.RegisterClientScriptBlock("HistoryScript", javaScript.ToString());
      
    }

    protected void EndAssignmentTime()
    {
        string strQ;
        strQ = "update studentActiveAssignment set EndAssignmenttime='" + DateTime.Now.ToString() + "' where asgnid='" + hdnAsgnId.Value + "' and UserId='" + hdnusername.Value.ToString() + "'";
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

                LIBAssignment objLIBAssignment = new LIBAssignment();
                DALAssignment objDalAssignment = new DALAssignment();
                LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
                objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
                objLIBAssignment.UserId = Session["username"].ToString();
                objLIBAssignment.QuestionId = Convert.ToInt32(hdnQuestionId.Value); ;

                TransportationPacket tp = new TransportationPacket();
                tp.MessagePacket = (object)objLIBAssignment;
                tp = objDalAssignment.GetAnsText(tp);
                objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
                if (objLibAssignmentListing != null)
                {

                    if (objLibAssignmentListing.Count > 0)
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

