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

public partial class Admin_StudentIDCard : System.Web.UI.Page
{
    int bid = 0;
    int cid = 0;
    int stid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["stid"] != null)
            {
                stid = Convert.ToInt32(Request.QueryString["stid"].ToString());
                bid = Convert.ToInt32(Request.QueryString["bid"].ToString());

                BindStudent();
            }
        }
    }

    protected void BindStudent()
    {
        DataSet ds = new DataSet();
        try
        {

            TransportationPacket tp = new TransportationPacket();

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.BatchId = Convert.ToInt32(bid);

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetStudentByBatch(tp);
            ds.Tables[0].DefaultView.RowFilter = "stid = " + stid;
            DataTable dt = (ds.Tables[0].DefaultView).ToTable();

            if (dt.Rows.Count > 0)
            {
                lnkprint.Attributes.Add("href", "print1.aspx?stid=" + stid + "&bid=" + bid);
                // lnkDownload.Attributes.Add("onclick", "javascript:DownloadIdCard('IdCard');");
                lblCoursename.Text = dt.Rows[0]["CourseTitle"].ToString();
                lblBactch.Text = dt.Rows[0]["Batchcode"].ToString();
                lblname.Text = dt.Rows[0]["name"].ToString();
                lblEmail.Text = dt.Rows[0]["emailid"].ToString();
                lblDob.Text = dt.Rows[0]["dob"].ToString();
                lblAddress.Text = dt.Rows[0]["address1"].ToString();
                if (dt.Rows[0]["ProfileImage"].ToString() != null)
                {
                    ProfilePhoto.ImageUrl = dt.Rows[0]["ProfileImage"].ToString();
                }
                else
                {
                    ProfilePhoto.ImageUrl = Server.MapPath("..") + "/Images/noimage.png";
                }

                bool idcard = Convert.ToBoolean(dt.Rows[0]["icard"].ToString());

                if (idcard)
                {
                    btnSave.Visible = false;
                }

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int addResult = 0;
        LIBStudent objLIBExam = new LIBStudent();
        DalAddStudent_CS objDalExam = new DalAddStudent_CS();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.stid = Convert.ToInt32(Request.QueryString["stid"]);
        objLIBExam.batchid = Convert.ToInt32(Request.QueryString["bid"]);
        objLIBExam.StudentEmail = lblEmail.Text.Trim();

        tp.MessagePacket = (object)objLIBExam;
        addResult = objDalExam.CreateStudentIdCard(tp);
        if (addResult > 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('ID Card Generated Successfully');", true);
            btnSave.Visible = false;
        }

    }
}