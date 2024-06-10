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
using System.Data.SqlClient;
using fmsf.lib;
using fmsf.DAL;

public partial class Faculty_AssignStudentinGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["bid"].ToString() != "")
            {
                hdnBid.Value = Request.QueryString["bid"].ToString();
                hdnGroupid.Value= Request.QueryString["GroupId"].ToString();
            }

            BindStudent();
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
            objLIBExam.BatchId = Convert.ToInt32(hdnBid.Value);
            objLIBExam.GroupId = Convert.ToInt32(hdnGroupid.Value);

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetStudentByGroup(tp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdStudent.DataSource = ds;
                grdStudent.DataBind();
            }
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void Bulk_Insert(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Id", typeof(int)), new DataColumn("Stid", typeof(int)),
                        new DataColumn("Bid", typeof(int)),
                        new DataColumn("GroupId",typeof(int)),
                        new DataColumn("CreatedBy",typeof(string)),
                        new DataColumn("Approve",typeof(bool))});
        foreach (GridViewRow row in grdStudent.Rows)
        {
            if ((row.FindControl("chk") as CheckBox).Checked)
            {
                HiddenField hdnstid = (HiddenField)row.FindControl("hdnstid");
                HiddenField hdnbid = (HiddenField)row.FindControl("hdnbid");

                int Id = -1;
                int stid = int.Parse(hdnstid.Value);
                int bid = int.Parse(hdnbid.Value);
                int groupid = int.Parse(hdnGroupid.Value);
                int createdby = int.Parse(Session["fid"].ToString());
                Boolean Approve = true;

                dt.Rows.Add(Id, stid, bid, groupid, createdby, Approve);
            }
        }
        if (dt.Rows.Count > 0)
        {
            int addResult = 0;

            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow d = dt.Rows[i];

                objLIBExam.GroupId = Convert.ToInt32(d["GroupId"].ToString());
                objLIBExam.bid = Convert.ToInt32(d["Bid"].ToString());
                objLIBExam.stid = Convert.ToInt32(d["Stid"].ToString()); 
                objLIBExam.userid = Convert.ToInt32(d["CreatedBy"].ToString());
                objLIBExam.Check = Convert.ToBoolean(d["Approve"].ToString());

                tp.MessagePacket = (object)objLIBExam;
                addResult = objDalExam.AddStudentInGroup(tp);

                if (addResult > 0)
                {
                }

            }

            lblMessage.Visible = true;
            lblMessage.Text = "Student Assign Successfully.";
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Student Assign Successfully.'); </script>");
            //string consString = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(consString))
            //{
            //    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //    {
            //        //Set the database table name
            //        sqlBulkCopy.DestinationTableName = "StudentRegGroup";

            //        //[OPTIONAL]: Map the DataTable columns with that of the database table

            //        sqlBulkCopy.ColumnMappings.Add("Id", "Id");
            //        sqlBulkCopy.ColumnMappings.Add("Stid", "Stid");
            //        sqlBulkCopy.ColumnMappings.Add("Bid", "Bid");
            //        sqlBulkCopy.ColumnMappings.Add("GroupId", "GroupId");
            //        sqlBulkCopy.ColumnMappings.Add("CreatedBy", "CreatedBy");
            //        sqlBulkCopy.ColumnMappings.Add("Approve", "Approve");
            //        con.Open();
            //        //sqlBulkCopy.InsertIfNotExists = true;
            //        sqlBulkCopy.WriteToServer(dt);
            //        con.Close();
            //    }
            //}
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Check Student from the List.";
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Please Check Student from the List.'); </script>");
        }
    }

    protected void grdStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnApprove = (HiddenField)e.Row.FindControl("hdnApprove");
                CheckBox chk = (CheckBox)e.Row.FindControl("chk");

                if (hdnApprove.Value == "True")
                {
                    chk.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}