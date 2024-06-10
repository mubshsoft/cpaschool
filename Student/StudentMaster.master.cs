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

public partial class Student_StudentMaster : System.Web.UI.MasterPage
{
    protected string username = "";
    protected string email = "";
    protected string ProfilePhoto = "";

    protected int NotificationCount=0;
    protected int MessageCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

        try
        {
            DataSet ds = new DataSet();
            string strQExam;
            strQExam = "select firstname + ' ' + lastname as fullname,*from student where email='" + Session["username"].ToString() + "'";
            ds = CLS_C.fnQuerySelectDs(strQExam);
            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            username = ds.Tables[0].Rows[0]["fullname"].ToString();
                            email = ds.Tables[0].Rows[0]["email"].ToString();
                            ProfilePhoto = ds.Tables[0].Rows[0]["Profileimage"].ToString().Replace("~/", "/");

                            if (string.IsNullOrEmpty(ProfilePhoto))
                            {
                                ProfilePhoto = "/Images/noimage.png";
                            }
                        }
                    }
                }
            }
            

            GetNotificationList();
        }
        catch (Exception ex)
        {
        }
    }

    protected void GetNotificationList()
    {
        DataSet ds = new DataSet();
        LIBStudent objLIBExam = new LIBStudent();
        DalAddStudent_CS objDalExam = new DalAddStudent_CS();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.stid = Convert.ToInt32(Session["stid"]);

        tp.MessagePacket = (object)objLIBExam;
        ds = objDalExam.GetNotificationList(tp);
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0].Rows.Cast<System.Data.DataRow>().Take(10).CopyToDataTable();
                        NotificationCount = ds.Tables[0].Rows.Count;
                        rptNotification.DataSource = dt;
                        rptNotification.DataBind();

                        //ds.Tables[0].DefaultView.RowFilter = "Mailtype = 'Reminder Mail'";
                        //DataTable dt1 = (ds.Tables[0].DefaultView).ToTable();

                        //if (dt1.Rows.Count > 0)
                        //{
                        //    MessageCount = dt1.Rows.Count;
                        //    rptMessage.DataSource = dt1;
                        //    rptMessage.DataBind();
                        //}
                        
                            
                    }
                }
            }
        }

    }

}
