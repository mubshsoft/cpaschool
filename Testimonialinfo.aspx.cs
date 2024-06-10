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
using System.IO;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using fmsf.lib;
using fmsf.DAL;

public partial class Testimonialinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                TestimonialList();
            }
        }
        catch (Exception ex)
        { }
    }

    protected void TestimonialList()
    {
        try
        {
            DataSet ds = new DataSet();

            LIBStudent objLIBExam = new LIBStudent();
            DalAddStudent_CS objDalExam = new DalAddStudent_CS();
            LIBStudentListing objLibExamListing = new LIBStudentListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.stid = Convert.ToInt32(Request.QueryString["stid"].ToString());

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetTestimonialsList(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTestimonial.Text = ds.Tables[0].Rows[0]["description"].ToString();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}