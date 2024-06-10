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
public partial class Student_print1 : System.Web.UI.Page
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
}