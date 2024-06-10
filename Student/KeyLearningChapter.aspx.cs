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

public partial class Student_KeyLearningChapter : System.Web.UI.Page
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
                if (Request.QueryString.Count > 0)
                {
                    if(Request.QueryString["UnitID"].ToString() !=null)
                    {
                        int Unitid = Convert.ToInt32(Request.QueryString["UnitID"].ToString());
                        int chapterid = Convert.ToInt32(Request.QueryString["ChapterId"].ToString());

                        BindKeyLearning(Unitid, chapterid);
                    }
                    
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void BindKeyLearning(int unit, int chapterid)
    {
       
        DataSet ds = new DataSet();

        Chapter objLIBExam = new Chapter();
        DALChapter objDalExam = new DALChapter();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.UnitID = Convert.ToInt32(unit);
        objLIBExam.ChapterID = chapterid.ToString();
        tp.MessagePacket = (object)objLIBExam;
        ds = objDalExam.GetChapterbyId(tp);


        if (ds.Tables[0].Rows.Count > 0)
        {
            lblKeyLearning.Text = ds.Tables[0].Rows[0]["KeyPoints"].ToString();

        }
    }
}