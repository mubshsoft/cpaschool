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
public partial class ShowExam : System.Web.UI.Page
{
    
  
   protected void Page_Load(object sender, EventArgs e)
     {
        //ClientScript.RegisterStartupScript(typeof(Page), "timer_script", "<script>countdown_clock();</script>");

        
        try
        {
           if (!Page.IsPostBack)
           {
               if (Session["username"] == null)
               {
                   Response.Redirect("../login.aspx");
               }
               else
               {
                   BindExamSetList();
               }
           }
            
         
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
      
   }
   protected void BindExamSetList()
   {
       try
       {
           LIBExam objLIBExam = new LIBExam();
           DALExam objDalExam = new DALExam();
           LIBExamListing objLibExamListing = new LIBExamListing();
           TransportationPacket tp = new TransportationPacket();

           tp.MessagePacket = (object)objLIBExam;

           tp = objDalExam.GetExamSetList(tp);
           objLibExamListing = (LIBExamListing)tp.MessageResultset;
           GrdUserList.DataSource = objLibExamListing;

           GrdUserList.DataBind();
         

       }
       catch (Exception ex)
       {
           HandleException.ExceptionLogging(ex.Source, ex.Message, true);
       }


   }
   
    }




