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
using fmsf.DAL;
using fmsf.lib;
using System.Data.SqlClient;

public partial class AddAboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
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
           
           

            getInstructionSummary();
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        int addResult = 0;

        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.InstructionText = Editor1.Value;

        tp.MessagePacket = (object)objLIBExam;
        addResult = objDalExam.AddAboutus(tp);

        if (addResult == 1)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Data added successfully'); </script>");

            Response.Redirect("adminlogin.aspx");
        }
        else if (addResult == 2)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Data updated successfully'); </script>");

            Response.Redirect("adminlogin.aspx");
           
        }

        else
        {
            //Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to Save Exam Set'); </script>");
            lblMessage.Text = "Failed to Save Data ";

        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }

    protected void  getInstructionSummary()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
          
            string st;
            st = objDalExam.GetAboutus();
            Editor1.Value = st;
         }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
   
}
